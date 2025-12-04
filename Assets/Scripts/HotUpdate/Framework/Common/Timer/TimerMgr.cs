using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace UnityTimer
{
    public class TimerManager : MonoBehaviour
    {
        //protected List<Timer> _timers = new List<Timer>();

        //初始化默认new 1个空间出来
        protected Timer[] m_szTimers = new Timer[1];

        //已使用的空间
        protected uint m_iUsedSize = 0;

        //protected List<Timer> _timersToAdd = new List<Timer>();

        protected void Resize()
        {
            int iOldCapacity = m_szTimers.Length;
            int iNewCapacity = iOldCapacity * 2;

            Timer[] szTempTimer = new Timer[iNewCapacity];

            //尾部全部设置成null
            for (int i = iOldCapacity; i < iNewCapacity; ++i)
            {
                szTempTimer[i] = null;
            }

            //copy oldData -> newData
            Array.Copy(m_szTimers, szTempTimer, m_szTimers.Length);

            //指向新地址
            m_szTimers = szTempTimer;

            //解除引用
            szTempTimer = null;
        }

        /// <summary>
        /// 小顶堆排序   
        /// </summary>
        public void HeapAdjustSmall(int parent)
        {
            if (parent >= m_szTimers.Length)
            {
                return;
            }

            Timer tmp = m_szTimers[parent];

            //时间复杂度应该在O(LogN)附近
            for (int child = parent * 2 + 1; child < m_iUsedSize; child = child * 2 + 1)
            {
                if (child + 1 < m_iUsedSize && m_szTimers[child].EndTime > m_szTimers[child + 1].EndTime)
                {
                    child++;
                }
                if (tmp.EndTime > m_szTimers[child].EndTime)
                {
                    m_szTimers[parent] = m_szTimers[child];
                    parent = child;
                }
                else
                {
                    break;
                }
            }
            m_szTimers[parent] = tmp;
        }

        public void AddTimer(Timer timer)
        {
            if (null == timer)
            {
                return;
            }

            if (m_iUsedSize >= m_szTimers.Length)
            {
                Resize();
            }

            uint hole = m_iUsedSize;
            ++m_iUsedSize;

            // 由于新结点在最后，因此将其进行上滤，以符合最小堆
            for (uint parent = (hole - 1) / 2; hole > 0; parent = (hole - 1) / 2)
            {
                //把时间最短的计时器交换到树根节点
                if (m_szTimers[parent].EndTime > timer.EndTime)
                {
                    m_szTimers[hole] = m_szTimers[parent];
                    hole = parent;
                }
                else
                {
                    break;
                }
            }
            m_szTimers[hole] = timer;
        }

        public void PopTimer()
        {
            if (0 == m_iUsedSize)
            {
                return;
            }

            if (null != m_szTimers[0])
            {
                m_szTimers[0] = m_szTimers[--m_iUsedSize];
                HeapAdjustSmall(0);
            }
        }

        public void RegisterTimer(Timer timer)
        {
            AddTimer(timer);
        }

        public void CancelAllTimers()
        {
            Timer timer = null;
            for (int i = 0; i < m_szTimers.Length; ++i)
            {
                timer = m_szTimers[i];
                if (null != timer)
                {
                    timer.Cancel();
                    m_szTimers[i] = null;
                }
            }

            m_iUsedSize = 0;
        }

        protected void Update()
        {
            UpdateAllTimers();
        }

        protected void UpdateAllTimers()
        {
            Timer tm = null;
            //for (int i = 0; i < m_szTimers.Length; ++i)
            //{
            //    tm = m_szTimers[i];
            //    if (null != tm)
            //        tm.Update();
            //}

            Timer tmp = null;

            tmp = m_szTimers[0];

            while (m_iUsedSize > 0)
            {
                if (null == tmp)
                    break;

                tmp.Update();

                //循环类型的计时器，如果到了时间，重新排序，而不清理
                if (tmp.isCompletedThisFrame && tmp.isLooped)
                {
                    HeapAdjustSmall(0);
                    tmp = m_szTimers[0];
                    continue;
                }

                if (!tmp.isDone)
                    break;

                PopTimer();
                tmp = m_szTimers[0];
            }
        }
    }

    public class GlobalTimerManager : TimerManager
    {
    }

}