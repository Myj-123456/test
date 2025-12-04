using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using System.Collections.Concurrent;
using ProtoBuf.Meta;

namespace ProtoBuf
{
    public sealed class ObjPool
    {
        private static UnLockTypeQueue pool = new UnLockTypeQueue();

        public static void Init(Assembly assembly)
        {
            var model = RuntimeTypeModel.Default;
            model.netDataPoolDelegate = ObjPool.Get;

            /*
            var types = model.GetTypes();
            UnityEngine.Profiling.Profiler.BeginSample("WarmUpProtoBuff");

            var assTypes = assembly.GetTypes();
            string [] names = new string[]{ "PB", "CcCommand" };
            foreach (Type assT in assTypes)
            {
                if ((assT.Namespace == names[0] || assT.Namespace == names[1]) && !assT.IsEnum && assT.IsSealed == true)
                {
                    model.Add(assT, true);
                }
            }

            foreach (var t in types)
            {
                var ser = ((MetaType)t).Serializer;
            }

            UnityEngine.Profiling.Profiler.EndSample();
            */
        }

        public static object Get(Type t)
        {
            if (!t.IsSubclassOf(typeof(ProtoBase)) 
                && !(t.IsGenericType && t.GetGenericTypeDefinition() == typeof(PbList<>)))
            {
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Dictionary<,>))
                {
                    return Activator.CreateInstance(t);
                }
                
                UnityEngine.Debug.LogError($"you get object type:{t} is not a protobase object");
                return null;
            }
            object result = null;
            if(pool.TryPop(t,out result)){
                return result;
            }

            return Activator.CreateInstance(t);
        }

        public static void Release(object obj)
        {
            if (obj == null) return;
            Type t = obj.GetType();

            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(PbList<>))
            {
                var l = obj as IPbList;
                l.Clear();

            }
            else
            {
                var p = obj as ProtoBase;
                if (p == null) return;
                p.__Reset__();

            
                pool.Push(p);
            }

        }

    }

    public class FieldInfoPlus 
    {
        public FieldInfo fieldInfo = null;
        public int offset = -1;
        public int size = 0;

        public FieldInfoPlus(int offset, int size, FieldInfo fieldInfo)
        {
            this.offset = offset;
            this.size = size;
            this.fieldInfo = fieldInfo;
        }

        public FieldInfoPlus(FieldInfo fieldInfo)
        {
            this.fieldInfo = fieldInfo;
        }
    }

    public class ProtoBase
    {
        public bool isSendMsgRelease;
        private static Dictionary<Type, FieldInfoPlus[]> fieldsDict = new Dictionary<Type, FieldInfoPlus[]>();
        public ProtoBase()
        {
        }
        public void Release()
        {
            isSendMsgRelease = false;
            ObjPool.Release(this);
        }
        public unsafe void __Reset__()
        {
            var t = GetType();
            FieldInfoPlus[] fields;
            if (!fieldsDict.TryGetValue(t, out fields))
            {
                var tmpFields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                fields = new FieldInfoPlus[tmpFields.Length];
                for (int i = 0, imax = tmpFields.Length; i < imax; i++)
                {
                    var f = tmpFields[i];
                    var fieldType = f.FieldType;
                    if (!fieldType.IsClass)
                    {
                        fields[i] = new FieldInfoPlus(UnsafeUtility.GetFieldOffset(f), UnsafeUtility.SizeOf(fieldType), f);
                    }
                    else
                    {
                        fields[i] = new FieldInfoPlus(f);
                    }
                }
                fieldsDict[t] = fields;
            }

            ulong gcHandle = 0;
            byte* pa = (byte*)UnsafeUtility.PinGCObjectAndGetAddress(this, out gcHandle);
            UnsafeUtility.ReleaseGCObject(gcHandle);

            foreach (var f in fields)
            {
                // 值类型直接 unsafe操作清0
                if (f.offset != -1)
                {
                    UnsafeUtility.MemClear((void*)(pa + f.offset), f.size);
                }
                else 
                {
                    //这个类型也是继承自ProtoBase 或者是list类型，也进入对象池
                    var fieldType = f.fieldInfo.FieldType;
                    var fInfo = f.fieldInfo;
                    var obj = fInfo.GetValue(this);
                    ObjPool.Release(obj);
            
                    // list不回收
                    if ((obj as IPbList) == null)
                    {
                        fInfo.SetValue(this, null);
                    }
                }
            }
        }
        public static T AutoSetValue<T>( T obj)
        {
            if (obj == null)
            {
                obj = (T)ObjPool.Get(typeof(T));
            }
            return obj;
        }

        public override string ToString()
        {
            var t = GetType();
            StringBuilder result = new StringBuilder();
            FieldInfoPlus[] fields;
            if (!fieldsDict.TryGetValue(t, out fields))
            {
                var tmpFields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                fields = new FieldInfoPlus[tmpFields.Length];
                for (int i = 0, imax = tmpFields.Length; i < imax; i++)
                {
                    var f = tmpFields[i];
                    var fieldType = f.FieldType;
                    if (!fieldType.IsClass)
                    {
                        fields[i] = new FieldInfoPlus(UnsafeUtility.GetFieldOffset(f), UnsafeUtility.SizeOf(fieldType), f);
                    }
                    else
                    {
                        fields[i] = new FieldInfoPlus(f);
                    }
                }
                fieldsDict[t] = fields;
            }
            foreach (var f in fields)
            {
                var fieldType = f.fieldInfo.FieldType;
                var fieldValue = f.fieldInfo.GetValue(this);
                if (fieldValue == null)
                {
                    continue;
                }

                result.Append($"[{f.fieldInfo.Name}]");
                if (!fieldType.IsClass || fieldType == typeof(string))
                {
                    result.Append($": {fieldValue}\n");
                }
                // list
                else if ((fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(PbList<>)))
                {
                    IPbList list = fieldValue as IPbList;
                    result.Append($"[{list.Count}]\n");
                    for (int i = 0, imax = list.Count; i < imax; i++)
                    {
                        object v = list[i];
                        var listItemType = v.GetType();
                        if (!listItemType.IsClass || listItemType == typeof(string))
                        {
                            result.Append($"    [{i}]:{list[i]}\n");
                        }
                        else if (listItemType.IsSubclassOf(typeof(ProtoBase)))
                        {
                            string str = v.ToString();
                            str = str.Replace("\n", "\n    ");
                            result.Append("    " + str);
                            result.Append("\n");
                        }
                    }
                }
                // protobase
                else if (fieldType.IsSubclassOf(typeof(ProtoBase)))
                {
                    result.Append("\n");
                    string str = fieldValue.ToString();
                    str = str.Replace("\n", "\n    ");
                    result.Append("    " + str);
                }
                else if(fieldType == typeof(object))
                {
                    if (fieldValue.GetType().IsSubclassOf(typeof(ProtoBase)))
                    {
                        result.Append($"[{fieldValue.GetType().Name}]");

                        result.Append("\n");
                        string str = fieldValue.ToString();
                        str = str.Replace("\n", "\n    ");
                        result.Append("    " + str);
                    }
                    else
                    {
                        result.Append($": {fieldValue}\n");
                    }
                }
            }

            return result.ToString();
        }

    }
}
