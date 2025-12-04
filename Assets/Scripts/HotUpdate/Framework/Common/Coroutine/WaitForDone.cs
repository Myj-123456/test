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
    public class WaitForDone : CustomWaitFor<WaitForDone>
    {
        public float total = 0f;
        public float progress = 0;
        public ulong totalBytes = 0;
        public ulong progressBytes = 0;
        public string info= string.Empty;
        public Action onComplete;
        public float value
        {
            get
            {
                if (total == 0)
                    return 0;
               return progress / total;
            }
        }

        public override void Clear()
        {
            base.Clear();
            total = 0;
            progress = 0;
            totalBytes = 0;
            progressBytes = 0;
            info = string.Empty;
        }

    }
}