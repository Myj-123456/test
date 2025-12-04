using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace ADK
{
    /// <summary>
    /// 等待数据协程
    /// 
    /// </summary>
    public class WaitForData : CustomWaitFor<WaitForData>
    {
        public event Action<object, int> onData;
        public object data { get; private set; }


        public void SetData(object data,int code=0)
        {
            this.data = data;
            Done(code);
            if (onData != null)
                onData.Invoke(data, code);
        }


        public override void Clear()
        {
            base.Clear();
            data = null;
            onData = null;
        }

    

    }
}