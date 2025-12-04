#if !NO_RUNTIME
using System;

using ProtoBuf.Meta;
using System.Runtime.InteropServices;

#if FEAT_IKVM
using Type = IKVM.Reflection.Type;
using IKVM.Reflection;
#else
using System.Reflection;
#endif
using Unity.Collections.LowLevel.Unsafe;


namespace ProtoBuf.Serializers
{
    public unsafe class ObjectIntCache
    {
        object valueCache = default(int);
        int* cachePtr = null;

        public ObjectIntCache()
        {
            if (cachePtr == null)
            {
                GCHandle h = GCHandle.Alloc(valueCache, GCHandleType.Pinned);
                IntPtr ptr = h.AddrOfPinnedObject();
                cachePtr = (int*)(ptr).ToPointer();
            }
        }

        public object GetDefaultCacheValue(int value)
        {
            if (value == 0) return null;
            *cachePtr = value;
            return valueCache;
        }

        public object GetCacheValue(int value)
        {
            *cachePtr = value;
            return valueCache;
        }
    }

    public unsafe class ObjectUIntCache
    {
        object valueCache = default(uint);
        uint* cachePtr = null;

        public ObjectUIntCache()
        {
            if (cachePtr == null)
            {
                GCHandle h = GCHandle.Alloc(valueCache, GCHandleType.Pinned);
                IntPtr ptr = h.AddrOfPinnedObject();
                cachePtr = (uint*)(ptr).ToPointer();
            }
        }

        public object GetDefaultCacheValue(uint value)
        {
            if (value == 0) return null;
            *cachePtr = value;
            return valueCache;
        }

        public object GetCacheValue(uint value)
        {
            *cachePtr = value;
            return valueCache;
        }
    }

    public unsafe class ObjectLongCache
    {
        object valueCache = default(long);
        long* cachePtr = null;

        public ObjectLongCache()
        {
            if (cachePtr == null)
            {
                GCHandle h = GCHandle.Alloc(valueCache, GCHandleType.Pinned);
                IntPtr ptr = h.AddrOfPinnedObject();
                cachePtr = (long*)(ptr).ToPointer();
            }
        }

        public object GetDefaultCacheValue(long value)
        {
            if (value == 0) return null;
            *cachePtr = value;
            return valueCache;
        }

        public object GetCacheValue(long value)
        {
            *cachePtr = value;
            return valueCache;
        }
    }

    public unsafe class ObjectULongCache
    {
        object valueCache = default(ulong);
        ulong* cachePtr = null;

        public ObjectULongCache()
        {
            if (cachePtr == null)
            {
                GCHandle h = GCHandle.Alloc(valueCache, GCHandleType.Pinned);
                IntPtr ptr = h.AddrOfPinnedObject();
                cachePtr = (ulong*)(ptr).ToPointer();
            }
        }

        public object GetDefaultCacheValue(ulong value)
        {
            if (value == 0) return null;
            *cachePtr = value;
            return valueCache;
        }

        public object GetCacheValue(ulong value)
        {
            *cachePtr = value;
            return valueCache;
        }
    }

    public unsafe class ObjectBoolCache
    {
        object valueCache = default(bool);
        bool* cachePtr = null;

        public ObjectBoolCache()
        {
            if (cachePtr == null)
            {
                GCHandle h = GCHandle.Alloc(valueCache, GCHandleType.Pinned);
                IntPtr ptr = h.AddrOfPinnedObject();
                cachePtr = (bool*)(ptr).ToPointer();
            }
        }

        public object GetDefaultCacheValue(bool value)
        {
            if (value == false) return null;
            *cachePtr = value;
            return valueCache;
        }

        public object GetCacheValue(bool value)
        {
            *cachePtr = value;
            return valueCache;
        }
    }

    public class ValueTypeCache
    {
        public static object mLock = new object();
        public static ObjectIntCache intCache = new ObjectIntCache();
        public static ObjectUIntCache uintCache = new ObjectUIntCache();
        public static ObjectLongCache longCache = new ObjectLongCache();
        public static ObjectULongCache ulongCache = new ObjectULongCache();
        public static ObjectBoolCache boolCache = new ObjectBoolCache();
    }

    sealed unsafe class FieldDecorator : ProtoDecoratorBase
    {

        public override Type ExpectedType { get { return forType; } }
        private readonly FieldInfo field = null;
        private readonly int fieldOffset;
        private readonly WireType wireType;
        private readonly Type forType;
        // add by leinlin
        private readonly Func<object, object> GetFieldAction;

        private readonly Action<object, ProtoReader> SetFieldAction;
        public override bool RequiresOldValue { get { return true; } }
        public override bool ReturnsValue { get { return false; } }
        private bool NeedsHint
        {
            get { return ((int)wireType & ~7) != 0; }
        }
        public FieldDecorator(Type forType, FieldInfo field, WireType wireType, IProtoSerializer tail) : base(tail)
        {
            Helpers.DebugAssert(forType != null);
            Helpers.DebugAssert(field != null);
            this.forType = forType;
            this.fieldOffset = UnsafeUtility.GetFieldOffset(field);
            this.wireType = wireType;
            // add by leinlin
            Type fieldType = field.FieldType;
            if (fieldType == typeof(int))
            {
                GetFieldAction = GetIntFieldValue;
                SetFieldAction = SetIntFieldValue;
            }
            else if (fieldType == typeof(uint))
            {
                GetFieldAction = GetUIntFieldValue;
                SetFieldAction = SetUIntFieldValue;
            }
            else if (fieldType == typeof(long))
            {
                GetFieldAction = GetLongFieldValue;
                SetFieldAction = SetLongFieldValue;
            }
            else if (fieldType == typeof(ulong))
            {
                GetFieldAction = GetULongFieldValue;
                SetFieldAction = SetULongFieldValue;
            }
            else if (fieldType == typeof(bool))
            {
                GetFieldAction = GetBoolFieldValue;
                SetFieldAction = SetBoolFieldValue;
            }
            else if (fieldType.IsEnum)
            {
                GetFieldAction = GetEnumFieldValue;
                SetFieldAction = SetEnumFieldValue;
            }
            else 
            {
                this.field = field;
                GetFieldAction = GetClassFieldValue;
                SetFieldAction = SetClassFieldValue;
            }

            // end
        }
#if !FEAT_IKVM
        // 思路利用unity的UnsafeUtility无GC把int值取出来，然后再赋值给一个缓存住的object
        // add by leinlin begin

        #region get action
        private unsafe object GetIntFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            int value = *((int*)(pa + fieldOffset));
            return ValueTypeCache.intCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetUIntFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            uint value = *((uint*)(pa + fieldOffset));
            return ValueTypeCache.uintCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetLongFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            long value = *((long*)(pa + fieldOffset));
            return ValueTypeCache.longCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetULongFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            ulong value = *((ulong*)(pa + fieldOffset));
            return ValueTypeCache.ulongCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetBoolFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            bool value = *((bool*)(pa + fieldOffset));
            return ValueTypeCache.boolCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetEnumFieldValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            int value = *((int*)(pa + fieldOffset));
            return ValueTypeCache.intCache.GetDefaultCacheValue(value);
        }

        private unsafe object GetClassFieldValue(object obj)
        {
            var v = field.GetValue(obj);
            //if (v != null)
            //{
            //    var t = field.FieldType;
            //    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(PbList<>))
            //    {
            //        var len = (v as IPbList).Count;
            //        if (len == 0) return null;
            //    }
            //}

            return v;
        }
        #endregion

        #region set action
        private unsafe void SetIntFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((int*)(pa + fieldOffset)) = source.ReadInt32();
        }

        private unsafe void SetUIntFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((uint*)(pa + fieldOffset)) = source.ReadUInt32();
        }

        private unsafe void SetLongFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((long*)(pa + fieldOffset)) = source.ReadInt64();
        }

        private unsafe void SetULongFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((ulong*)(pa + fieldOffset)) = source.ReadUInt64();
        }

        private unsafe void SetBoolFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((bool*)(pa + fieldOffset)) = source.ReadBoolean();
        }

        private unsafe void SetEnumFieldValue(object obj, ProtoReader source)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((int*)(pa + fieldOffset)) = source.ReadInt32();
        }

        private unsafe void SetClassFieldValue(object obj, ProtoReader source)
        {
            object newValue = Tail.Read((Tail.RequiresOldValue ? field.GetValue(obj) : null), source);
            if (newValue != null) field.SetValue(obj, newValue);
        }

        #endregion

        // add by leinlin end
        public override void Write(object value, ProtoWriter dest)
        {
            lock (ValueTypeCache.mLock)
            {
                Helpers.DebugAssert(value != null);
                value = GetFieldAction(value);

                if (value != null) Tail.Write(value, dest);
            }
        }
        public override object Read(object value, ProtoReader source)
        {
            lock (ValueTypeCache.mLock)
            {
                Helpers.DebugAssert(value != null);
                // 检查是不是值类型的（目前支持 int32、uint32、long、ulong），是的话直接读取并设置就好了
                if (NeedsHint) source.Hint(wireType);
                SetFieldAction(value, source);

            }
            return null;
        }
#endif

#if FEAT_COMPILER
        protected override void EmitWrite(Compiler.CompilerContext ctx, Compiler.Local valueFrom)
        {
            ctx.LoadAddress(valueFrom, ExpectedType);
            ctx.LoadValue(field);
            ctx.WriteNullCheckedTail(field.FieldType, Tail, null);
        }
        protected override void EmitRead(Compiler.CompilerContext ctx, Compiler.Local valueFrom)
        {
            using (Compiler.Local loc = ctx.GetLocalWithValue(ExpectedType, valueFrom))
            {
                if (Tail.RequiresOldValue)
                {
                    ctx.LoadAddress(loc, ExpectedType);
                    ctx.LoadValue(field);  
                }
                // value is either now on the stack or not needed
                ctx.ReadNullCheckedTail(field.FieldType, Tail, null);

                if (Tail.ReturnsValue)
                {
                    using (Compiler.Local newVal = new Compiler.Local(ctx, field.FieldType))
                    {
                        ctx.StoreValue(newVal);
                        if (field.FieldType.IsValueType)
                        {
                            ctx.LoadAddress(loc, ExpectedType);
                            ctx.LoadValue(newVal);
                            ctx.StoreValue(field);
                        }
                        else
                        {
                            Compiler.CodeLabel allDone = ctx.DefineLabel();
                            ctx.LoadValue(newVal);
                            ctx.BranchIfFalse(allDone, true); // interpret null as "don't assign"

                            ctx.LoadAddress(loc, ExpectedType);
                            ctx.LoadValue(newVal);
                            ctx.StoreValue(field);

                            ctx.MarkLabel(allDone);
                        }
                    }
                }
            }
        }
#endif
    }
}
#endif