using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace UnityTimer
{
    public class Timer
    {
        public enum SCOPE
        {
            eLocal,
            eGlobal,
        }

        #region Public Properties/Fields

        /// <summary>
        /// 计时器回调时间持续时间
        /// </summary>
        public float duration { get; private set; }

        /// <summary>
        /// 执行完成后是否循环执行.
        /// </summary>
        public bool isLooped { get; set; }

        /// <summary>
        /// 本帧是否完成
        /// </summary>
        public bool isCompletedThisFrame { get; private set; }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool isCompleted { get; private set; }

        /// <summary>
        /// 计时器使用的是实时时间还是游戏时间
        /// </summary>
        public bool usesRealTime { get; private set; }

        /// <summary>
        /// 计时器是否暂停
        /// </summary>
        public bool isPaused
        {
            get { return this._timeElapsedBeforePause.HasValue; }
        }

        /// <summary>
        /// 是否取消了
        /// </summary>
        public bool isCancelled
        {
            get { return this._timeElapsedBeforeCancel.HasValue; }
        }

        /// <summary>
        /// 是否完成
        /// </summary>
        public bool isDone
        {
            get { return this.isCompleted || this.isCancelled || this.isOwnerDestroyed; }
        }

        #endregion

        #region Public Static Methods

        /// <summary>
        /// 注册一个新的计时器，在一定时间后触发一个事件
        /// 在切换场景的时候，注册的计时器会被销毁
        /// </summary>
        /// <param name="duration">在一定秒后执行事件</param>
        /// <param name="onComplete">计时器执行完回调事件.</param>
        /// <param name="onUpdate">每次执行计时器执行的回调</param>
        /// <param name="isLooped">计时器在执行后是否重复执行</param>
        /// <param name="useRealTime">是否使用实时时间</param>
        /// <param name="autoDestroyOwner">此计时器附加到的对象，物体被摧毁后,定时器将不执行</param>
        /// <returns>一个计时器对象</returns>
        public static Timer Regist(float duration, Action onComplete, bool isLooped = false, Action<float> onUpdate = null,
             bool useRealTime = true, MonoBehaviour autoDestroyOwner = null)
        {
            if (Timer._manager == null)
            {
                TimerManager managerInScene = Object.FindObjectOfType<TimerManager>();
                if (managerInScene != null && managerInScene.GetType() == typeof(TimerManager))
                {
                    Timer._manager = managerInScene;
                }
                else
                {
                    GameObject managerObject = new GameObject { name = "TimerManager" };
                    Timer._manager = managerObject.AddComponent<TimerManager>();
                }
            }

            Timer timer = new Timer(duration, onComplete, onUpdate, isLooped, useRealTime, autoDestroyOwner);
            Timer._manager.RegisterTimer(timer);
            return timer;
        }

        /// <summary>
        /// 作用同上，不同的是此API创建的计时器在程序的生命周期内都有效，不会随着场景的销毁而销毁
        /// </summary>
        public static Timer RegistGlobal(float duration, Action onComplete, bool isLooped = false, Action<float> onUpdate = null,
            bool useRealTime = true, MonoBehaviour autoDestroyOwner = null)
        {
            if (Timer._globalManager == null)
            {
                GlobalTimerManager globalManager = Object.FindObjectOfType<GlobalTimerManager>();
                if (globalManager != null && globalManager.GetType() == typeof(GlobalTimerManager))
                {
                    Timer._globalManager = globalManager;
                }
                else
                {
                    GameObject globalManagerObject = new GameObject { name = "GlobalTimerManager" };
                    Timer._globalManager = globalManagerObject.AddComponent<GlobalTimerManager>();
                    GameObject.DontDestroyOnLoad(Timer._globalManager);
                }
            }

            Timer timer = new Timer(duration, onComplete, onUpdate, isLooped, useRealTime, autoDestroyOwner);
            Timer._globalManager.RegisterTimer(timer);
            return timer;
        }

        public static void Cancel(Timer timer)
        {
            if (timer != null)
            {
                timer.Cancel();
            }
        }

        public static void CancelAllRegisteredTimers(SCOPE eScope = SCOPE.eLocal)
        {
            //如果计时器不存在，不需要做任何事情
            if (eScope == SCOPE.eLocal)
            {
                if (Timer._manager != null)
                {
                    Timer._manager.CancelAllTimers();
                }
            }
            else if (eScope == SCOPE.eGlobal)
            {
                if (Timer._globalManager != null)
                {
                    Timer._globalManager.CancelAllTimers();
                }
            }
        }

        #endregion

        #region Public Methods

        public void Cancel()
        {
            if (this.isDone)
            {
                return;
            }

            this._timeElapsedBeforeCancel = this.GetTimeElapsed();
            this._timeElapsedBeforePause = null;
        }

        public float GetTimeElapsed()
        {
            if (this.isCompleted || this.GetWorldTime() >= this.GetFireTime())
            {
                return this.duration;
            }

            return this._timeElapsedBeforeCancel ??
                   this._timeElapsedBeforePause ??
                   this.GetWorldTime() - this._startTime;
        }

        public float GetTimeRemaining()
        {
            return this.duration - this.GetTimeElapsed();
        }

        public float GetRatioComplete()
        {
            return this.GetTimeElapsed() / this.duration;
        }

        public float GetRatioRemaining()
        {
            return this.GetTimeRemaining() / this.duration;
        }

        #endregion

        #region Private Static Properties/Fields

        private static TimerManager _manager;
        private static GlobalTimerManager _globalManager;

        #endregion


        #region Private Properties/Fields

        private bool isOwnerDestroyed
        {
            get { return this._hasAutoDestroyOwner && this._autoDestroyOwner == null; }
        }

        private readonly Action _onComplete;
        private readonly Action<float> _onUpdate;
        private float _startTime;
        private float _endTime;
        private float _lastUpdateTime;

        private float? _timeElapsedBeforeCancel;
        private float? _timeElapsedBeforePause;

        private readonly MonoBehaviour _autoDestroyOwner;
        private readonly bool _hasAutoDestroyOwner;

        #endregion

        #region 属性区
        public float EndTime { get { return _endTime; } }
        #endregion

        #region Private Constructor (use static Register method to create new timer)

        private Timer(float duration, Action onComplete, Action<float> onUpdate,
            bool isLooped, bool usesRealTime, MonoBehaviour autoDestroyOwner)
        {
            this.duration = duration;
            this._onComplete = onComplete;
            this._onUpdate = onUpdate;

            this.isLooped = isLooped;
            this.usesRealTime = usesRealTime;

            this._autoDestroyOwner = autoDestroyOwner;
            this._hasAutoDestroyOwner = autoDestroyOwner != null;

            this._startTime = this.GetWorldTime();
            this._lastUpdateTime = this._startTime;
            _endTime = _startTime + duration;
        }

        #endregion

        #region  Methods

        public float GetWorldTime()
        {
            return this.usesRealTime ? Time.realtimeSinceStartup : Time.time;
        }

        private float GetFireTime()
        {
            return this._startTime + this.duration;
        }

        private float GetTimeDelta()
        {
            return this.GetWorldTime() - this._lastUpdateTime;
        }

        public void Update()
        {
            isCompletedThisFrame = false;

            if (this.isDone)
            {
                return;
            }

            if (this.isPaused)
            {
                this._startTime += this.GetTimeDelta();
                this._lastUpdateTime = this.GetWorldTime();
                return;
            }

            this._lastUpdateTime = this.GetWorldTime();

            if (this._onUpdate != null)
            {
                this._onUpdate(this.GetTimeElapsed());
            }

            if (this.GetWorldTime() >= this.GetFireTime())
            {
                isCompletedThisFrame = true;

                if (this._onComplete != null)
                {
                    this._onComplete();
                }

                if (this.isLooped)
                {
                    this._startTime = this.GetWorldTime();
                    _endTime = _startTime + duration;
                }
                else
                {
                    this.isCompleted = true;
                }
            }
        }

        #endregion

    }
}