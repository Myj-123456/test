using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ProtoBuf.Serializers
{
    internal class MapDecorator : ProtoDecoratorBase
    {
        private readonly int fieldNumber;
        private readonly Type declaredType;
        private readonly Type concreteType;
        private readonly IProtoSerializer keyTail, valueTail;
        private readonly int valueTypeKey;
        private PropertyInfo keyGetProperty;
        private PropertyInfo valueGetProperty;

        internal MapDecorator(RuntimeTypeModel model, Type declaredType, Type concreteType, int fieldNumber, IProtoSerializer ser) : base(ser)
        {
            this.declaredType = declaredType;

            var types = declaredType.GetGenericArguments();
            Helpers.DebugAssert(types.Length == 2, "must be a dictionary");
            var keyType = types[0];
            var valueType = types[1];

            WireType wireType;

            {
                var tail = ValueMember.TryGetCoreSerializer(model, DataFormat.Default, keyType, out wireType, false, false, false, false);
                if (tail != null)
                {
                    keyTail = new TagDecorator(1, wireType, false, tail);
                }
            }


            if (valueType.IsPrimitive || valueType == typeof(string))
            {
                var tail = ValueMember.TryGetCoreSerializer(model, DataFormat.Default, valueType, out wireType, false, false, false, false);
                valueTail = new TagDecorator(2, wireType, false, tail);
            }
            else
            {
                valueTypeKey = model.GetKey(valueType, false, false);
                valueTail = null;
            }


            this.concreteType = concreteType;
            this.fieldNumber = fieldNumber;
        }

        public override Type ExpectedType { get { return declaredType; } }

        public override bool ReturnsValue { get { return false; } }

        public override bool RequiresOldValue { get { return true; } }

        public override object Read(object value, ProtoReader source)
        {
            int field = source.FieldNumber;
            object origValue = value;
            if (value == null)
            {
                var del = ProtoBuf.Meta.RuntimeTypeModel.Default.netDataPoolDelegate;
                if (del != null)
                {
                    value = del(concreteType);
                }
                else
                {
                    value = Activator.CreateInstance(concreteType);
                }
            }
            var dict = ((IDictionary)value);

            var token = ProtoReader.StartSubItem(source);

            while (source.ReadFieldHeader() > 0)
            {
                object k = keyTail.Read(null, source);
                object v = null;
                if (valueTail != null)
                {
                    v = valueTail.Read(null, source);
                }
                else
                {
                    source.ReadFieldHeader();
                    v = ProtoReader.ReadObject(null, valueTypeKey, source);
                }
                
                dict.Add(k, v);
            }
            ProtoReader.EndSubItem(token, source);

            return dict; 
            //throw new NotImplementedException();
        }

        public override void Write(object value, ProtoWriter dest)
        {
            var itr = ((IEnumerable)value).GetEnumerator();

            while (itr.MoveNext())
            {
                var item = itr.Current;
                if (keyGetProperty == null)
                {
                    Type t = item.GetType();
                    keyGetProperty = t.GetProperty("Key");
                    valueGetProperty = t.GetProperty("Value");
                }
                ProtoWriter.WriteFieldHeader(fieldNumber, WireType.String, dest);
                SubItemToken token = ProtoWriter.StartSubItem(value, dest);
                object k = keyGetProperty.GetValue(item);
                object v = valueGetProperty.GetValue(item);
                keyTail.Write(k, dest);
                if (valueTail != null)
                {
                    valueTail.Write(v, dest);
                }
                else
                {
                    ProtoWriter.WriteFieldHeader(2, WireType.String, dest);
                    ProtoWriter.WriteObject(v, valueTypeKey, dest);
                }
                dest.ResetWireType();
                ProtoWriter.EndSubItem(token, dest);
            }
            //throw new NotImplementedException();
        }
    }
}