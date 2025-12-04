using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace ADK
{
    /// <summary>
    /// 协程的运行模式
    /// 
    /// </summary>

    public enum CoroutineMode
    {
        /// <summary>
        /// 与普通的协程一样，当OnDisable时自动中止
        /// </summary>
        Normal,
        /// <summary>
        /// 当OnDisable时自动暂停,在OnEnable会自动继续执行当前进度
        /// </summary>
        ContinueWhenEnable,
        /// <summary>
        /// 全局协程， 在OnDisable时不会停止，直到协程运行结束或对象被销毁或手动StopCoroutineEX
        /// </summary>
        Always,
    }



    /// <summary>
    /// 安全的全局协程扩展
    ///  2019/3/8
    /// </summary>
    public class Coroutiner
    {

        #region 全局
        private static Dictionary<string, Coroutiner> _coroutinerDic = new Dictionary<string, Coroutiner>();

        public static Coroutiner GetCoroutiner(string key)
        {
            Coroutiner cor;
            if (_coroutinerDic.TryGetValue(key,out cor)==false)
            {
                var go = CoroutineHelper.Instance.gameObject;
                var mono = go.AddComponent<CoroutinerAutoCreate>();
                mono.key = key;
                cor = new Coroutiner(mono);
                _coroutinerDic.Add(key, cor);
            }
            return cor;
        }
        public static void DestroyCoroutiner(string key)
        {
            Coroutiner cor;
            if (_coroutinerDic.TryGetValue(key, out cor))
            {
                GameObject.Destroy(cor._mono);
            }
        }

        public static Coroutine StartCoroutine(IEnumerator ie)
        {
            return CoroutineHelper.Instance.StartCoroutine(ie);
        }
        public static void StopCoroutine(Coroutine co)
        {
            CoroutineHelper.Instance.StopCoroutine(co);
        }
        public static void StopCoroutine(IEnumerator ie)
        {
            CoroutineHelper.Instance.StopCoroutine(ie);
        }

        public class CoroutinerAutoCreate:MonoBehaviour
        {
            public string key;
        }
        #endregion

        private MonoBehaviour _mono;
        private CoroutineMono _coroMono;

        public Coroutiner(MonoBehaviour mono)
        {
            _mono = mono;
        }
        /// <summary>
        /// 启动协程， 
        /// 如果协程已存在，协程会不会重复执行
        /// 如果协程已存在但已暂停，则重新恢复执行原有进度
        /// 如果协程已存在但CoroutineMode模式不一样，则改变模式，执行进度不变
        /// 否则报错
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"> 协程方法 </param>
        /// <param name="mode">执行模式,参见CoroutineMode</param>
        /// <param name="values">协程方法 参数</param>
        public void StartCoroutine(string methodName, CoroutineMode mode = CoroutineMode.ContinueWhenEnable, params object[] values)
        {
            _coroMono = GetCoroutineMono();
            _coroMono.StartCoroutine(_mono, methodName, mode, values);
        }

       
        public void StartCoroutine(string methodName, IEnumerator ietor, CoroutineMode mode = CoroutineMode.ContinueWhenEnable)
        {
            _coroMono = GetCoroutineMono();
            _coroMono.StartCoroutine(_mono, methodName, ietor, mode);
        }
        //为什么要改个名字呢，不叫StartCoroutine与上面的方法一样呢，因为lua会分不清两个方法。
        public void Start(string methodName, IEnumerator ietor, CoroutineMode mode = CoroutineMode.ContinueWhenEnable)
        {
            _coroMono = GetCoroutineMono();
            _coroMono.StartCoroutine(_mono, methodName, ietor, mode);
        }
        /// <summary>
        /// 重新执行协程，原有的协程会停掉，重头开始执行
        /// </summary>
        public void ReStart(string methodName, CoroutineMode mode = CoroutineMode.ContinueWhenEnable, params object[] values)
        {
            _coroMono = GetCoroutineMono();
            _coroMono.StopCoroutine(_mono, methodName);
            _coroMono.StartCoroutine(_mono, methodName, mode, values);
        }
        public void ReStart(string key, IEnumerator ietor, CoroutineMode mode = CoroutineMode.ContinueWhenEnable)
        {
            _coroMono = GetCoroutineMono();
            _coroMono.StopCoroutine(_mono, key);
            _coroMono.StartCoroutine(_mono, key, ietor, mode);
        }
        /// <summary>
        /// 暂停当前协程
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        public void Pause(string methodName)
        {
            if (_coroMono != null)
            {
                _coroMono.PauseCoroutine(_mono, methodName);
            }
        }
        /// <summary>
        /// 恢复执行暂停的协程，进度不变
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        public void Resume(string methodName)
        {
            if (_coroMono != null)
            {
                _coroMono.ResumeCoroutine(_mono, methodName);
            }
        }
        /// <summary>
        /// 停止当前协程，进度重置
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        public void Stop(string methodName)
        {
            if (_coroMono != null)
            {
                _coroMono.StopCoroutine(_mono, methodName);
            }
        }
        /// <summary>
        /// 停止所有扩展的协程
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        public void StopAll()
        {
            if (_coroMono != null)
            {
                _coroMono.StopAllCoroutines(_mono);
            }
        }
        /// <summary>
        /// 指定的协程是已完成
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public bool IsDone(string methodName)
        {
            if (_coroMono != null)
            {
                return _coroMono.IsDone(_mono, methodName);
            }
            return false;
        }
        /// <summary>
        /// 指定的协程是否运行中
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public bool IsRuning(string methodName)
        {
            if (_coroMono != null)
            {
                return _coroMono.IsRuning(_mono, methodName);
            }
            return false;
        }

        private CoroutineMono GetCoroutineMono()
        {
            if (_coroMono == null)
            {
                _coroMono = _mono.GetComponent<CoroutineMono>();
                if (_coroMono == null)
                    _coroMono = _mono.gameObject.AddComponent<CoroutineMono>();
            }
            return _coroMono;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        #region CoroutineHelper
        class CoroutineHelper : MonoBehaviour
        {
            private static CoroutineHelper _Instance;

            public static CoroutineHelper Instance
            {
                get
                {
                    if (_Instance == null)
                        _Instance = ADKTool.GetADKRootComponent<CoroutineHelper>("ADK.Coroutiner");
                    return _Instance;
                }
            }
        }
        #endregion


        #region CoroutineMono
        /// <summary>
        /// 
        /// 以组合的模式安全使用协程
        /// 
        ///  2018/3/8
        /// </summary>
        class CoroutineMono : MonoBehaviour
        {
            private Dictionary<int, Dictionary<string, IEnumeratorEX>> _dic = new Dictionary<int, Dictionary<string, IEnumeratorEX>>();


            //------------------  公共方法  ---------------------
            public void StartCoroutine(MonoBehaviour mono, string methodName, CoroutineMode mode, object[] param)
            {
                Dictionary<string, IEnumeratorEX> dic = null;
                IEnumeratorEX itor = GetItor(mono, methodName, out dic);
                int paramNum = param != null ? param.Length : 0;
                if (itor != null)
                {
                    if (itor.isDone)
                    {
                        itor = CreateItor(itor, mono, methodName, param);
                        if (itor == null)
                            return;
                    }
                    else
                    {
                        if (mode != itor.mode)
                        {
                            PauseCoroutine(itor);
                        }
                        else if (itor.isPause == false)
                        {
                            Debug.LogWarning("StartCoroutine Error, the " + methodName + " is runing!");
                            return;
                        }
                    }

                }
                else
                {
                    itor = CreateItor(null, mono, methodName, param);
                    if (itor == null)
                        return;
                    dic.Add(methodName, itor);
                }
                itor.mono = mono;
                itor.methodparamNum = paramNum;
                itor.mode = mode;
                StartCoroutine(itor);

            }
            public void StartCoroutine(MonoBehaviour mono, string methodName, IEnumerator ie, CoroutineMode mode)
            {
                Dictionary<string, IEnumeratorEX> dic = null;
                IEnumeratorEX itor = GetItor(mono, methodName, out dic);
                if (itor != null)
                {
                    StopCoroutine(itor);
                }

                itor = CreateItor(null, ie);
                if (itor == null)
                    return;
                if (dic.ContainsKey(methodName))
                    dic[methodName] = itor;
                else
                    dic.Add(methodName, itor);
                itor.mono = mono;
                itor.methodparamNum = 0;
                itor.mode = mode;
                StartCoroutine(itor);
            }

            public void PauseCoroutine(MonoBehaviour mono, string methodName)
            {
                IEnumeratorEX itor = GetItor(mono, methodName);
                if (itor != null)
                {
                    PauseCoroutine(itor);
                }
            }
            public void ResumeCoroutine(MonoBehaviour mono, string methodName)
            {
                IEnumeratorEX itor = GetItor(mono, methodName);
                if (itor != null)
                {
                    ResumeCoroutine(itor);
                }
            }

            public void StopCoroutine(MonoBehaviour mono, string methodName)
            {
                IEnumeratorEX itor = GetItor(mono, methodName);
                StopCoroutine(itor);
                Dictionary<string, IEnumeratorEX> dic = null;
                int monoId = mono.GetInstanceID();
                if (_dic.TryGetValue(monoId, out dic))
                {
                    if (dic.ContainsKey(methodName))
                        dic.Remove(methodName);
                }
            }

            public void StopAllCoroutines(MonoBehaviour mono)
            {
                Dictionary<string, IEnumeratorEX> dic = null;
                int monoId = mono.GetInstanceID();
                if (_dic.TryGetValue(monoId, out dic))
                {
                    foreach (var d in dic)
                    {
                        if (!d.Value.isDone)
                            StopCoroutine(d.Value);
                    }
                }
                _dic.Clear();
            }

            public bool IsDone(MonoBehaviour mono, string methodName)
            {
                IEnumeratorEX ie = GetItor(mono, methodName);
                if (ie != null)
                {
                    return ie.isDone;
                }
                return true;
            }
            public bool IsRuning(MonoBehaviour mono, string methodName)
            {
                IEnumeratorEX ie = GetItor(mono, methodName);
                if (ie != null)
                {
                    if (ie.isDone == false && ie.isPause == false)
                    {
                        return true;
                    }
                }
                return false;
            }


            //----------------  私有  --------------------

            protected void OnEnable()
            {
                foreach (var k in _dic)
                {
                    foreach (var d in k.Value)
                    {
                        if (d.Value.isDone == false)
                            ResumeCoroutine(d.Value);
                    }
                }
            }
            protected void OnDisable()
            {
                foreach (var k in _dic)
                {
                    foreach (var d in k.Value)
                    {
                        if (d.Value.isDone == false)
                        {
                            if (d.Value.mode == CoroutineMode.Normal)
                                StopCoroutine(d.Value);
                            else if (d.Value.mode == CoroutineMode.ContinueWhenEnable)
                                PauseCoroutine(d.Value);
                        }
                    }
                }
            }
            protected void OnDestroy()
            {
                foreach (var k in _dic)
                {
                    foreach (var d in k.Value)
                    {
                        if (d.Value.isDone == false)
                            StopCoroutine(d.Value);
                    }
                }
            }


            private void StartCoroutine(IEnumeratorEX itor)
            {
                if (itor.isDone)
                    return;
                if (itor.mode == CoroutineMode.Always)
                {
                    itor.isPause = false;
                    CoroutineHelper.Instance.StartCoroutine(itor);
                }
                else
                {
                    if (itor.mono != null && gameObject != null)
                    {
                        if (gameObject.activeInHierarchy)
                        {
                            itor.isPause = false;
                            itor.mono.StartCoroutine(itor);
                        }
                        else if (itor.mode == CoroutineMode.Normal)
                            Debug.LogError("StartCoroutine Error, the gameObject is not active!");
                    }
                    else
                        Debug.LogError("StartCoroutine Error, the gameObject or MonoBehaviour was  Destory!");
                }


            }
            private void StopCoroutine(IEnumeratorEX itor)
            {
                itor.isDone = true;
                itor.isPause = false;
                if (itor.mode == CoroutineMode.Always)
                {
                    CoroutineHelper.Instance.StopCoroutine(itor);
                }
                else
                {
                    if (itor.mono != null)
                    {
                        itor.mono.StopCoroutine(itor);
                    }
                    else
                        Debug.LogError("StartCoroutine Error, the MonoBehaviour was  Destory!");
                }
            }

            private void PauseCoroutine(IEnumeratorEX itor)
            {
                if (itor.isDone)
                    return;
                if (itor.mode == CoroutineMode.Always)
                {
                    CoroutineHelper.Instance.StopCoroutine(itor);
                }
                else
                {
                    if (itor.mono != null)
                    {
                        itor.mono.StopCoroutine(itor);
                    }
                    else
                        Debug.LogError("StartCoroutine Error, the MonoBehaviour was  Destory!");
                }
                itor.isPause = true;
            }
            private void ResumeCoroutine(IEnumeratorEX itor)
            {
                if (itor.isDone)
                    return;
                if (itor.isPause)
                    StartCoroutine(itor);
            }

            private IEnumeratorEX CreateItor(IEnumeratorEX itor, MonoBehaviour mono, string methodName, object[] param)
            {

                IEnumerator ie = null;
                int paramNum = param != null ? param.Length : 0;
                MethodInfo m = ReflectionUtil.GetMemberInfo(mono.GetType(), methodName, paramNum) as MethodInfo;
                if (paramNum == 0)
                    ie = m.Invoke(mono, null) as IEnumerator;
                else
                    ie = m.Invoke(mono, param) as IEnumerator;
                if (ie == null)
                {
                    Debug.LogError("CreateItor Error.The method " + methodName + " is not return IEnumerator");
                    return null;
                }
                if (itor == null)
                    itor = new IEnumeratorEX();
                itor.method = m;
                itor._routine = ie;
                itor.isDone = false;
                itor.isPause = false;
                return itor;
            }
            private IEnumeratorEX CreateItor(IEnumeratorEX itor, IEnumerator ie)
            {
                if (itor == null)
                    itor = new IEnumeratorEX();
                itor.method = null;
                itor._routine = ie;
                itor.isDone = false;
                itor.isPause = false;
                return itor;
            }
            private IEnumeratorEX GetItor(MonoBehaviour mono, string methodName, out Dictionary<string, IEnumeratorEX> dic)
            {
                dic = null;
                int monoId = mono.GetInstanceID();
                if (_dic.TryGetValue(monoId, out dic) == false)
                {
                    dic = new Dictionary<string, IEnumeratorEX>();
                    _dic.Add(monoId, dic);
                }
                IEnumeratorEX ie = null;

                dic.TryGetValue(methodName, out ie);
                return ie;
            }
            private IEnumeratorEX GetItor(MonoBehaviour mono, string methodName)
            {
                Dictionary<string, IEnumeratorEX> dic = null;
                return GetItor(mono, methodName, out dic);
            }
        }
        #endregion

        #region IEnumeratorEX
        //////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 中间层，包装原来的迭代器
        ///  2018/3/8
        /// </summary>
        class IEnumeratorEX : IEnumerator
        {

            public bool isDone = false;
            public bool isPause = false;
            public CoroutineMode mode;
            public MonoBehaviour mono;
            public MethodInfo method;
            public int methodparamNum = 0;

            public IEnumerator _routine;

            public IEnumeratorEX()
            {

            }

            object IEnumerator.Current
            {
                get
                {
                    return _routine.Current;
                }
            }

            public bool MoveNext()
            {
                // 在这里可以：
                //     1. 标记协程的执行
                //     2. 记录协程本次执行的时间

                bool next = _routine.MoveNext();
                isPause = false;
                if (next)
                {
                    // 一次普通的执行
                }
                else
                {
                    isDone = true;
                    // 协程运行到末尾，已结束
                }

                return next;
            }

            public void Reset()
            {
                isDone = false;
                isPause = false;
                _routine.Reset();
            }

        }
        #endregion
    }
}