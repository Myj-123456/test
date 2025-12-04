using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
namespace ProtoBuf.Meta
{
    public interface IPbList : IEnumerable
    {
        public object this[int index]
        {
            get;
        }
        public void Add(object item);
        public int Count { get; }
        public void Clear();
    }
    public class PbList<T> : IPbList, IEnumerable<T>
    {
        private static readonly T[] EmptyArray = new T[0];

        private const int MinArraySize = 8;

        private T[] array = EmptyArray;
        private int count = 0;
        private IEnumerator<T> mEnumerator;

        public int Count => count;
        int IPbList.Count => Count;
        public int Length => count;
        public void Add(T item)
        {
            CheckNotNullUnconstrained(item, nameof(item));
            EnsureSize(count + 1);
            array[count++] = item;
        }

        private void EnsureSize(int size)
        {
            if (size > array.Length)
            {
                size = Math.Max(size, MinArraySize);
                int newSize = Math.Max(array.Length * 2, size);  //长度扩充长度后续需优化
                SetSize(newSize);
            }
        }

        private void SetSize(int size)
        {
            if (size > array.Length)
            {
                var tmp = new T[size];
                Array.Copy(array, 0, tmp, 0, count);
                array = tmp;
            }
        }
        public void Clear()
        {
            if (typeof(T).IsSubclassOf(typeof(ProtoBuf.ProtoBase)))
            {
                for (int i = 0; i < count; i++)
                {
                    ProtoBuf.ObjPool.Release(array[i]);
                    array[i] = default(T);
                }
            }
            //array = EmptyArray;
            count = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }
        public int IndexOf(T item)
        {
            CheckNotNullUnconstrained(item, nameof(item));
            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))  //后续优化
                {
                    return i;
                }
            }



            return -1;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(this.array, 0, array, arrayIndex, count);
        }

        public void AddRange(IEnumerable<T> values)
        {
            CheckNotNullUnconstrained(values, nameof(values));


            var otherList = values as PbList<T>;
            if (otherList != null)
            {
                EnsureSize(count + otherList.count);
                Array.Copy(otherList.array, 0, array, count, otherList.count);
                count += otherList.count;
                return;
            }

            var collection = values as ICollection;
            if (collection != null)
            {
                var extraCount = collection.Count;
                if (default(T) == null)
                {
                    foreach (var item in collection)
                    {
                        if (item == null)
                        {
                            throw new ArgumentException("Sequence contained null element", nameof(values));
                        }
                    }
                }
                EnsureSize(count + extraCount);
                collection.CopyTo(array, count);
                count += extraCount;
                return;
            }

            foreach (T item in values)
            {
                Add(item);
            }
        }




        public void Insert(int index, T item)
        {
            CheckNotNullUnconstrained(item, nameof(item));
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            EnsureSize(count + 1);
            Array.Copy(array, index, array, index + 1, count - index);
            array[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            Array.Copy(array, index + 1, array, index, count - index - 1);

            array[count] = default(T);
            count -= 1;
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            Array.Copy(array, index + 1, array, index, count - index - 1);

            array[count] = default(T);
            count -= 1;
        }
        /// <summary>
        /// 排序方法，暂时只处理自定义排序规则，冒泡排序
        /// </summary>
        /// <param name="comparison"></param>
        public void Sort(Comparison<T> comparison)
        {
            T temp;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                {
                    if (array[j + 1] == null) return;
                    if (comparison(array[j], array[j + 1])>0)
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            if (mEnumerator == null)
            {
                mEnumerator = new PbListEnumerator<T>(this);
            }
            return mEnumerator;
            //return new PbListEnumerator<T>(this); 
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        internal T CheckNotNullUnconstrained<T>(T value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
            return value;
        }

        void IPbList.Add(object item)
        {
            Add((T)item);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    if (index == count)//仅用于适配tdr 数组使用
                    {
                        if (typeof(T).IsSubclassOf(typeof(ProtoBuf.ProtoBase)))
                        {

                            object obj = ProtoBuf.ObjPool.Get(typeof(T));
                            Add((T)obj);
                            return array[index];
                        }
                        T t = default(T);
                        Add(t);
                        return array[index];
                    }
                    else
                    {
                        //为了临时兼容以前的Tdr，数组长度总是会创建的
                        var type = typeof(T);
                        if (type.IsValueType)
                        {
                            return default(T);
                        }
                        else
                        {
                            return Activator.CreateInstance<T>();
                        }


                    }
                    //throw new ArgumentOutOfRangeException(nameof(index));
                }

                return array[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    if (index == count)//仅用于适配tdr 数组使用
                    {
                        Add(value);
                        return;
                    }


                    throw new ArgumentOutOfRangeException(nameof(index));
                }

                CheckNotNullUnconstrained(value, nameof(value));
                array[index] = value;
            }

        }
        object IPbList.this[int index] { get => array[index]; }
        public override string ToString()
        {
            var writer = new StringWriter();
            writer.Write("List[\n");
            for (int i = 0; i < count; i++)
            {
                writer.Write("[");
                writer.Write(i);

                writer.Write("]=");
                writer.Write(this[i].ToString(), this);
                if (i != count - 1)
                {
                    writer.Write("\n");
                }
            }
            writer.Write("\n]");
            return writer.ToString();
        }
    }

    public class PbListEnumerator<T> : IEnumerator<T>
    {
        int position;
        PbList<T> pbList;
        public PbListEnumerator(PbList<T> pbList)
        {
            this.pbList = pbList;
            position = -1;
        }
        bool IEnumerator.MoveNext()
        {
            if (position != pbList.Count)
            {
                position++;
            }
            return position < pbList.Count;
        }
        public T Current
        {
            get
            {
                if (position < 0 || position >= pbList.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(position));
                }
                return pbList[position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
        void IDisposable.Dispose()
        {
            position = -1;
        }
    }
}