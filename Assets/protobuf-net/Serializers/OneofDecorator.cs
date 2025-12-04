using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;

namespace ProtoBuf.Serializers
{
    internal class OneofDecorator : ProtoDecoratorBase
    {
        RuntimeTypeModel model;

        private readonly Type parentType;


        Dictionary<int, OneofAttType> oneofAttTypes;
        Dictionary<int, IProtoSerializer> oneofAttSer;
        FieldInfo valueFieldInfo;
        int fieldOffset;
        //public static ObjectIntCache intCache = new ObjectIntCache();

        internal OneofDecorator(RuntimeTypeModel model,Type parentType,  Dictionary<int, OneofAttType> oneofAttTypes,string name) : base(null)
        {
            this.model = model;
            this.parentType = parentType;
            this.oneofAttTypes = oneofAttTypes;


            valueFieldInfo = parentType.GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);

            var offsetFieldInfo = parentType.GetField(name + "__member_offset", BindingFlags.NonPublic | BindingFlags.Instance);
            this.fieldOffset = UnsafeUtility.GetFieldOffset(offsetFieldInfo);
            oneofAttSer = new Dictionary<int, IProtoSerializer>();

        }
        public unsafe void SetOffSetValue(object obj,int offset)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            *((int*)(pa + fieldOffset)) = offset;
        }
        public unsafe int GetOffSetValue(object obj)
        {
            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(obj, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);
            int value = *((int*)(pa + fieldOffset));
            return value;
        }

        public override Type ExpectedType { get { return parentType; } }

        public override bool ReturnsValue { get { return false; } }

        public override bool RequiresOldValue { get { return false; } }

        public override object Read(object value, ProtoReader source)
        {
            int fieldNumber = source.FieldNumber;


            OneofAttType attType;
            if(!oneofAttTypes.TryGetValue(fieldNumber,out attType))
            {
                return null;
            }

            IProtoSerializer tail;
            if(!oneofAttSer.TryGetValue(fieldNumber,out tail))
            {
                tail = ValueMember.TryGetCoreSerializer(model, attType.format, attType.type, out attType.wireType, false, false, false, false);
                 
                oneofAttSer.Add(fieldNumber, tail);
            }
            object obj = null;


            if (tail != null)
            {
                obj = tail.Read(null, source);
            }
            else
            {
                int key = model.GetKey(attType.type, false, false);
           
               obj =ProtoReader.ReadObject(null, key, source);


            }

            valueFieldInfo.SetValue(value, obj);
            SetOffSetValue(value, fieldNumber);
      


            return null;
        }

        public override void Write(object value, ProtoWriter dest)
        {

            object obj =valueFieldInfo.GetValue(value);
            int fieldNumber = GetOffSetValue(value);

         
            OneofAttType attType;
            if (!oneofAttTypes.TryGetValue(fieldNumber, out attType))
            {
                return ;
            }

            IProtoSerializer tail;
            if (!oneofAttSer.TryGetValue(fieldNumber, out tail))
            {
                tail = ValueMember.TryGetCoreSerializer(model, attType.format, attType.type, out attType.wireType, false, false, false, false);
                oneofAttSer.Add(fieldNumber, tail);
            }

            if (tail != null)
            {
                ProtoWriter.WriteFieldHeader(fieldNumber, attType.wireType, dest);
                tail.Write(obj, dest);
               
            }
            else
            {
                int key = model.GetKey(attType.type,false,false);

                ProtoWriter.WriteFieldHeader(fieldNumber, WireType.String, dest);
                ProtoWriter.WriteObject(obj, key, dest);


            }
            dest.ResetWireType();



        }
    }
}