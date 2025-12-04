using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace ADK
{
    /// <summary>
    /// 等待完成
    /// 
    /// </summary>
    public abstract class CustomWaitFor<T> : CustomYieldInstruction where T: CustomWaitFor<T> ,new()
    {
        private static List<T> _pools = new List<T>();

        public const int Err_Timeout = -1;

        private bool _isDone = false;
        private float _timeout = 0;
        private float _startTime;

        public string error;
        public int code { get;  private set; }
        public bool isTimeout { get; private set; }

        public static T Create()
        {
            T wait = null;
            if(_pools.Count>0)
            {
                wait = _pools[_pools.Count - 1];
                _pools.RemoveAt(_pools.Count - 1);
            }
            else
                wait = new T();
            return wait;
        }
        public void SetTimeout(float t)
        {
            _startTime = Time.realtimeSinceStartup;
            _timeout = t;
        }
        public void Done(int code=0)
        {
            this.code = code;
            _isDone = true;
        }
        public bool isDone
        {
            get { return _isDone; }
            
        }
        public void Timeout()
        {
            _isDone = true;
            isTimeout = true;
            code = Err_Timeout;
        }
        public void Release()
        {
            Reset();
            if(_pools.Count<10)
                _pools.Add(this as T);
        }
        public new void Reset()
        {
            base.Reset();
            Clear();
        }

        public virtual void Clear()
        {
            _isDone = false;
            code = 0;
            _timeout = 0;
        }

    

        public override bool keepWaiting
        {
            get
            {
                if(_timeout>0)
                {
                    if (Time.realtimeSinceStartup - _startTime > _timeout)
                    {
                        Timeout();
                    }
                        
                }
                return !_isDone;
            }
        }

    }
}