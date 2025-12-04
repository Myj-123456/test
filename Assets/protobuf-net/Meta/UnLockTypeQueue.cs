using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System;
namespace ProtoBuf.Meta
{
    /// <summary>
    /// 
    /// </summary>
    public class UnLockTypeQueue
    {
        private static Dictionary<Type, Queue<object>> mPool = new Dictionary<Type, Queue<object>>();
        int mCurrentThreadId = 0;
        public int GetCount(Type t)
        {
            Queue<object> queue;
            if (mPool.TryGetValue(t, out queue))
            {
                return queue.Count;
            }
            return 0;
        }
        public bool TryPop(Type t, out object obj)
        {

            int threadId = Thread.CurrentThread.ManagedThreadId;
            obj = null;
            Interlocked.CompareExchange(ref mCurrentThreadId, threadId, 0);
            if (mCurrentThreadId != threadId)
            {
                SpinWait mSpinWait = new SpinWait();
                do
                {
                    mSpinWait.SpinOnce();
                    Interlocked.CompareExchange(ref mCurrentThreadId, threadId, 0);
                } while (mCurrentThreadId != threadId);

            }

            Queue<object> queue;
            if (mPool.TryGetValue(t, out queue))
            {
                if (queue.Count > 0)
                {
                    obj = queue.Dequeue();

                    Interlocked.Exchange(ref mCurrentThreadId, 0);
                    return true;
                }
            }

            Interlocked.Exchange(ref mCurrentThreadId, 0);

            return false;
        }
        public void Push(object obj)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref mCurrentThreadId, threadId, 0);
            if (mCurrentThreadId != threadId)
            {
                SpinWait mSpinWait = new SpinWait();
                do
                {
                    mSpinWait.SpinOnce();
                    Interlocked.CompareExchange(ref mCurrentThreadId, threadId, 0);
                } while (mCurrentThreadId != threadId);

            }


            Type t = obj.GetType();
            Queue<object> queue;
            if (!mPool.TryGetValue(t, out queue))
            {
                queue = new Queue<object>();
                mPool.Add(t, queue);
            }


            queue.Enqueue(obj);


            Interlocked.Exchange(ref mCurrentThreadId, 0);

        }


    }
}