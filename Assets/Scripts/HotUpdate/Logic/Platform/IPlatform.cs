#if WEIXINMINIGAME
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FairyGUI;
using UnityEngine;

public class IPlatform
{
    public static bool isCanShare
    {
        get
        {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
            return WeixinPlatform.Instance.isCanShare;
#endif
            return true;
        }
    }

    public static bool isCanVideo
    {
        get
        {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
            return WeixinPlatform.Instance.isCanVideo;
#endif
            return true;
        }
    }
    public static void Init(Action callback)
    {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        WeixinPlatform.Instance.Init(callback)
#endif
    }

    public static void InitOnHideAndOnShow()
    {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        WeixinPlatform.Instance.OnShow(OnShow);
        WeixinPlatform.Instance.OnHide(OnHide);
#endif

    }


    //游戏进入后台
    public static void OnHide(WeChatWASM.GeneralCallbackResult data)
    {
       
    }

    //从后台进入游戏
    public static void OnShow(WeChatWASM.OnShowListenerResult data)
    {
        if(ShareState.InBackGround)
            ShareState.InBackGround = false;
        if (data.query != null)
        {
           
        }
    }

public static void CreateRewardedAd()
    {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        WeixinPlatform.Instance.CreateRewardedAd(callback);
#endif
    }

    //播放激励广告
    public static async Task<bool> ShowRewardedAd()
    {
        using var cts = new CancellationTokenSource();
        var timeoutTask = Task.Delay(8000, cts.Token);

#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        var adTask = WeixinPlatform.Instance.ShowRewardedAd();
#else
        // 非微信平台模拟逻辑（立即返回成功）
        var adTask = Task.FromResult(true);
#endif

        try
        {
            var completedTask = await Task.WhenAny(adTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                Debug.Log("广告展示超时");
                return false;
            }

            // 取消超时计时器
            cts.Cancel();

            // 返回广告实际结果（处理可能的异常）
            return await adTask;
        }
        catch (OperationCanceledException)
        {
            // 超时取消是正常流程
            return false;
        }
        catch (Exception ex)
        {
            Debug.Log($"广告流程异常: {ex.Message}");
            return false;
        }
    }

    public static async Task<PlatfromUserInfo> GetUserInfo()
    {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        return await WeixinPlatform.Instance.GetUserInfo();
#else
        return await Task.FromResult(new PlatfromUserInfo()); // 返回默认对象 ;
#endif
    }

    //获取登录code
    public static async Task<string> GetLoginCode()
    {
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        return await WeixinPlatform.Instance.GetLoginCode();
#else
        return await Task.FromResult(""); // 返回默认对象 ;
#endif
    }

    //截图分享
    public static async Task<bool> Share(DisplayObject dObject, Rect clip,string url = "screenshot")
    {
        dObject.EnterPaintingMode(1024, null);

        await Task.Yield();
        RenderTexture tex = (RenderTexture)dObject.paintingGraphics.texture.nativeTexture;

        // 创建临时Texture2D
        Texture2D texture2D = new Texture2D(
            (int)clip.width,
            (int)clip.height,
            TextureFormat.RGB24, // 根据需求选择格式
            false
        );

        // 保存当前RenderTexture状态（重要！）
        RenderTexture prevActive = RenderTexture.active;

        // 设置目标RenderTexture为当前活动状态
        RenderTexture.active = tex;

        // 读取像素数据（坐标系原点在左下角）
        texture2D.ReadPixels(clip, 0, 0);
        texture2D.Apply(); // 必须调用Apply使修改生效

        // 恢复之前的RenderTexture状态
        RenderTexture.active = prevActive;

        // 保存为PNG
        byte[] bytes = texture2D.EncodeToPNG();
        string base64 = Convert.ToBase64String(bytes);
        //处理结束后结束绘画模式。id要和Enter方法的对应。
        dObject.LeavePaintingMode(1024);
        //string path = Path.Combine(Application.persistentDataPath, "screenshot.png");
        //File.WriteAllBytes(path, bytes);
#if UNITY_WEBGL && !UNITY_EDITOR && WECHAT_GAME
        await WeixinPlatform.Instance.shareMessage(bytes,$"{url}.png");
        var reslut = await StartWxShare();
        WeixinPlatform.Instance.Unlink($"{url}.png");
        return await Task.FromResult(reslut);
#else
        string path = Path.Combine(Application.persistentDataPath, $"{url}.png");
        File.WriteAllBytes(path, bytes);
        Debug.Log($"Saved to: {Application.persistentDataPath}");
        return await Task.FromResult(true);
#endif

    }

    private static TaskCompletionSource<bool> _shareTcs;
    private static int _startTime;
    private static Action<bool> _shareCallback;
    public static async Task<bool> StartWxShare()
    {
        _shareTcs = new TaskCompletionSource<bool>();
        _startTime = Environment.TickCount;
        ShareState.InBackGround = true;
        // 添加后台状态监听
        ShareState.OnBackGroundChanged += HandleBackGroundChanged;

        return await _shareTcs.Task;
    }

    private static void HandleBackGroundChanged(bool inBackground)
    {
        if (!inBackground)
        {
            ShareState.OnBackGroundChanged -= HandleBackGroundChanged;
            
            int duration = Environment.TickCount - _startTime;
            Debug.Log($"分享返回，耗时：{duration}");
            
            _shareTcs?.TrySetResult(duration > 2000);
        }
    }

}


public class PlatfromUserInfo
{
    public string nickName;
    public string avatarUrl;

    public PlatfromUserInfo(string nickName = null, string avatarUrl = null)
    {
        this.nickName = nickName;
        this.avatarUrl = avatarUrl;
    }
}

public static class ShareState
{
    public static event Action<bool> OnBackGroundChanged;

    private static bool _inBackGround;
    public static bool InBackGround
    {
        get => _inBackGround;
        set
        {
            if (_inBackGround != value)
            {
                _inBackGround = value;
                OnBackGroundChanged?.Invoke(value);
            }
        }
    }
}

public class JData<T> : IDisposable
{
    private readonly object _lock = new object();
    private CallBacker<T> _caller = new CallBacker<T>();
    private T _value;
    private bool _lockEvent;
    private T _lockedValue;

    public JData(T defaultValue = default)
    {
        _value = defaultValue;
    }

    public T Value
    {
        get
        {
            lock (_lock)
            {
                return _value;
            }
        }
        set
        {
            lock (_lock)
            {
                if (EqualityComparer<T>.Default.Equals(_value, value)) return;

                _value = value;
                if (!_lockEvent)
                {
                    ApplyChanged();
                }
            }
        }
    }

    public bool LockEvent
    {
        get
        {
            lock (_lock)
            {
                return _lockEvent;
            }
        }
        set
        {
            lock (_lock)
            {
                if (_lockEvent == value) return;

                _lockEvent = value;
                if (_lockEvent)
                {
                    _lockedValue = _value;
                }
                else
                {
                    if (!EqualityComparer<T>.Default.Equals(_lockedValue, _value))
                    {
                        _lockedValue = default;
                        ApplyChanged();
                    }
                    _lockedValue = default;
                }
            }
        }
    }

    public void AddListener(Action<T> listener)
    {
        lock (_lock)
        {
            _caller.Add(listener);
        }
    }

    public void RemoveListener(Action<T> listener)
    {
        lock (_lock)
        {
            _caller.Remove(listener);
        }
    }

    public void Dispose()
    {
        lock (_lock)
        {
            _caller.Clear();
            _value = default;
            _lockedValue = default;
        }
    }

    private void ApplyChanged()
    {
        _caller.Invoke(_value);
    }
}

public class CallBacker<T>
{
    private readonly object _callbackLock = new object();
    private readonly HashSet<Action<T>> _callbacks = new HashSet<Action<T>>();
    private readonly Dictionary<Action<T>, WeakReference> _weakTargets = new Dictionary<Action<T>, WeakReference>();

    public void Add(Action<T> callback, object target = null)
    {
        lock (_callbackLock)
        {
            if (target != null)
            {
                _weakTargets[callback] = new WeakReference(target);
            }
            _callbacks.Add(callback);
        }
    }

    public void Remove(Action<T> callback)
    {
        lock (_callbackLock)
        {
            _callbacks.Remove(callback);
            _weakTargets.Remove(callback);
        }
    }

    public void Clear()
    {
        lock (_callbackLock)
        {
            _callbacks.Clear();
            _weakTargets.Clear();
        }
    }

    public void Invoke(T arg)
    {
        List<Action<T>> callbacksToInvoke;
        lock (_callbackLock)
        {
            PruneDeadReferences();
            callbacksToInvoke = new List<Action<T>>(_callbacks);
        }

        foreach (var callback in callbacksToInvoke)
        {
            try
            {
                if (IsTargetAlive(callback))
                {
                    callback.Invoke(arg);
                }
            }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogError($"Callback invocation failed: {ex}");
            }
        }
    }

    private void PruneDeadReferences()
    {
        var deadCallbacks = new List<Action<T>>();
        foreach (var pair in _weakTargets)
        {
            if (!pair.Value.IsAlive)
            {
                deadCallbacks.Add(pair.Key);
            }
        }

        foreach (var dead in deadCallbacks)
        {
            _callbacks.Remove(dead);
            _weakTargets.Remove(dead);
        }
    }

    private bool IsTargetAlive(Action<T> callback)
    {
        if (!_weakTargets.TryGetValue(callback, out var weakRef)) return true;
        return weakRef.IsAlive;
    }
}
#endif