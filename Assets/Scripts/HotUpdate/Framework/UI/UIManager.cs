using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using YooAsset;


/// <summary>
/// UI层级
/// </summary>
public enum UILayer
{
    SceneUI,//场景层ui
    MainUI,
    UI,//一级UI
    SecondUI,//二级UI
    Window,
    Popup,
    Loading,
    Tips,
    Notice,
    Guide,
    Top
}

public class UIManager : Singleton<UIManager>
{
    private Dictionary<string, BaseView> panelDic = new Dictionary<string, BaseView>();
    private Dictionary<string, BaseWindow> windowDic = new Dictionary<string, BaseWindow>();
    private GRoot gRoot;
    private List<AssetHandle> _handles = new List<AssetHandle>(100);
    public bool IsTouchUI = false;//是否接触到ui
    private int showPanelNum = 0;//当前显示的界面数量
    private int showWindowNum = 0;//当前显示的界面数量

    private Dictionary<UILayer, GComponent> layerDic = new Dictionary<UILayer, GComponent>();

    public UIManager()
    {
        gRoot = GRoot.inst;
        InitLayers();
        //全局事件监听
        Stage.inst.onTouchBegin.Add(OnStageTouchBegin);
        Stage.inst.onTouchEnd.Add(OnStageTouchEnd);
    }

    private void InitLayers()
    {
        InitLayer(UILayer.SceneUI);
        InitLayer(UILayer.MainUI);
        InitLayer(UILayer.UI);
        InitLayer(UILayer.SecondUI);
        InitLayer(UILayer.Window);
        InitLayer(UILayer.Loading);
        InitLayer(UILayer.Tips);
        InitLayer(UILayer.Guide);
        InitLayer(UILayer.Notice);
        InitLayer(UILayer.Top);
    }

    private GComponent InitLayer(UILayer uILayer)
    {
        GComponent layer = new GComponent();
        layer.gameObjectName = uILayer.ToString();
        layer.name = "componentLayer";
        layer.MakeFullScreen();

        gRoot.AddChild(layer);
        layerDic.Add(uILayer, layer);
        return layer;
    }
    public GComponent GetLayer(UILayer uILayer)
    {
        if (layerDic.ContainsKey(uILayer))
        {
            return layerDic[uILayer];
        }
        Debug.LogWarning("UI层级不存在！");
        return null;
    }

    private void OnStageTouchBegin()
    {
        if (Stage.isTouchOnUI)
        {
            IsTouchUI = true;
        }
        EventManager.Instance.DispatchEvent(SystemEvent.StageTouchBegin);
    }

    private GComponent topLayer;
    private Queue<GLoader3D> clickEffectPool = new Queue<GLoader3D>();
    private void ShowClickEffect(float posX, float posY)
    {
        GLoader3D effect = GetEffectFromPool();
        if (effect == null) return;
        var pos = topLayer.GlobalToLocal(new Vector2(posX, posY));
        effect.visible = true;
        effect.playing = true;
        effect.x = pos.x;
        effect.y = pos.y;
        effect.Complete = (string name) =>
        {
            ReturnEffectToPool(effect);
        };
    }

    private GLoader3D GetEffectFromPool()
    {
        // 池中有可用对象
        if (clickEffectPool.Count > 0)
        {
            return clickEffectPool.Dequeue();
        }
        else
        {
            GLoader3D effect = (GLoader3D)UIObjectFactory.NewObject(ObjectType.Loader3D);
            effect.url = "shubiao";
            effect.animationName = "animation";
            effect.forcePlay = true;
            effect.loop = false;
            effect.scaleX = 1.8f;
            effect.scaleY = 1.8f;
            if (topLayer == null)
                topLayer = GetLayer(UILayer.Top);
            topLayer.AddChild(effect);
            return effect;
        }
    }

    private void ReturnEffectToPool(GLoader3D effect)
    {
        effect.visible = false;
        effect.playing = false;
        effect.Complete = null;
        clickEffectPool.Enqueue(effect);
    }


    private void OnStageTouchEnd(EventContext context)
    {
        IsTouchUI = false;
        ShowClickEffect(context.inputEvent.x, context.inputEvent.y);
        CheckCancelWeakGuide();
        GuideController.Instance.HideTargetWeakGuide();
    }

    private void CheckCancelWeakGuide()
    {
        if (!GuideModel.Instance.IsWeakGuiding)
        {
            if (!GuideModel.Instance.IsCancelGuide)//重置一次取消引导状态
            {
                GuideModel.Instance.IsCancelGuide = true;
            }
            return;
        }
        var targetUi = GuideModel.Instance.curGuideUI;
        if (targetUi == null)
        {
            Debug.Log("没有curGuideUI");
            return;
        }
        var dragObject = GRoot.inst.touchTarget;
        if (dragObject == null)
        {
            Debug.Log("没有touchTarget");
            if (targetUi != null)//需要检测引导ui
            {
                GuideController.Instance.CancelWeakGuide();
            }
            return;
        }
        GObject p = dragObject;
        while (p != null)
        {
            if (p == targetUi)
                break;
            p = p.parent;
        }
        if (p == targetUi)
        {
            Debug.Log("点击的是目标对象");
            GuideController.Instance.NextWeakGuide();
        }
        else
        {
            Debug.Log("点击的不是目标对象");
            GuideController.Instance.CancelWeakGuide();
        }
    }

    /// <summary>
    /// 同步方式从Resource文件夹打开界面
    /// </summary>
    /// <typeparam name="TPanel"></typeparam>
    /// <param name="panelName"></param>
    /// <param name="layer"></param>
    public void OpenPanelFromResource<TPanel>(string panelName, UILayer layer = UILayer.UI) where TPanel : BaseView, new()
    {
        Debug.Log("OpenPanel: " + panelName);
        BaseView panel;
        if (!panelDic.TryGetValue(panelName, out panel))
        {
            panel = new TPanel();
            UIPackage.AddPackage(panel.packageName);
            panel.BindAllDelegate?.Invoke();
            var contentPanel = panel.CreateInstanceDelegate?.Invoke().asCom;
            panel.ui = contentPanel;

            contentPanel.MakeFullScreen();
            contentPanel.AddRelation(gRoot, RelationType.Size);

            var uiLayer = GetLayer(layer);
            if (uiLayer != null)
            {
                uiLayer.AddChild(contentPanel);
                panel.OnInit();
                panel.Visible = true;
                panel.OnShown();
                panelDic.Add(panelName, panel);
            }
        }
        else
        {
            panel.Visible = true;
            panel.OnShown();
        }
    }

    /// <summary>
    /// 异步方式打开界面 传递数据
    /// </summary>
    /// <typeparam name="TPanel"></typeparam>
    /// <param name="panelName"></param>
    /// <param name="data"></param>
    /// <param name="layer"></param>
    public void OpenPanel<TPanel>(string panelName, UILayer layer = UILayer.UI, object data = null) where TPanel : BaseView, new()
    {
        Debug.Log("OpenPanel: " + panelName);
        BaseView panel;
        if (!panelDic.TryGetValue(panelName, out panel))
        {
            panel = new TPanel();
            panel.uiName = panelName;
            ADK.Coroutiner.StartCoroutine(LoadPanel(panel, layer, data));
        }
        else
        {
            if (panel.Visible) return;
            if (panel.IsShowOrHideMainUI)
            {
                ShowOrHideMainUI(false, false);
            }
            panel.Visible = true;
            panel.data = data;
            panel.OnShown();
            AddShowPanelNum(panel);
        }
    }

    private void AddShowPanelNum(BasePanel panel)
    {
        if (panel.IsAddShowNum)
        {
            showPanelNum += 1;
            DispatchPanelEvent(true, panel.uiName);
        }
    }

    private void AddShowWindowNum(BasePanel panel)
    {
        if (panel.IsAddShowNum)
        {
            showWindowNum += 1;
            CheckShowModal();
        }
    }

    private void SubShowWindowNum(BasePanel panel)
    {
        if (panel.IsAddShowNum)
        {
            showWindowNum -= 1;
            if (showWindowNum <= 0)
            {
                showWindowNum = 0;
            }
            CheckShowModal();
        }
        if (panel.IsShowOrHideMainUI)
        {
            ShowOrHideMainUI(true);
        }
    }

    private void SubShowPanelNum(BasePanel panel)
    {
        if (panel.IsAddShowNum)
        {
            showPanelNum -= 1;
            if (showPanelNum <= 0) showPanelNum = 0;
            DispatchPanelEvent(false, panel.uiName);
            ShowOrHideMainUI(true);
        }
    }

    public void OpenWindow<TWindow>(string windowName, object data = null, UILayer layer = UILayer.Window) where TWindow : BaseWindow, new()
    {
        Debug.Log("OpenWindow: " + windowName);
        BaseWindow window;
        if (!windowDic.TryGetValue(windowName, out window))
        {
            window = new TWindow();
            window.uiName = windowName;
            ADK.Coroutiner.StartCoroutine(LoadWindow(window, layer, data));
        }
        else
        {
            if (window.Visible) return;
            if (window.IsShowOrHideMainUI)
            {
                ShowOrHideMainUI(false);
            }
            window.Visible = true;
            var uiLayer = GetLayer(layer);
            if (uiLayer != null)
            {
                uiLayer.SetChildIndex(window.ui, uiLayer.numChildren - 1);
            }
            window.data = data;
            AddShowWindowNum(window);
            ShowWindow(window, false);
        }
    }

    private IEnumerator LoadWindow(BaseWindow window, UILayer layer, object data = null)
    {
        // 加载 bytes 文件
        AllAssetsHandle assetHandle = ResourceManager.Instance.LoadAllAssetsAsync(ResPath.GetFuiBytes(window.packageName));
        yield return assetHandle;
        window.assetHandle = assetHandle;

        TextAsset textAsset = null;
        Texture2D pngAsset = null;
        foreach (var assetObj in assetHandle.AllAssetObjects)
        {
            if (assetObj is TextAsset)
            {
                textAsset = assetObj as TextAsset;
            }
            else if (assetObj is Texture2D)
            {
                pngAsset = assetObj as Texture2D;
            }
        }
        if (windowDic.ContainsKey(window.uiName)) yield break;//避免弱网下重复初始化
        UIPackage.AddPackage(textAsset.bytes, window.packageName, (string name, string extension, System.Type type, out DestroyMethod method) =>
        {
            method = DestroyMethod.None; //注意：这里一定要设置为None
            return pngAsset;
        });
        window.BindAllDelegate?.Invoke();
        var contentPanel = window.CreateInstanceDelegate?.Invoke().asCom;
        window.ui = contentPanel;
        contentPanel.fairyBatching = window.fairyBatching;//开启动态合批

        if (!window.FullScreen)
        {
            contentPanel.Center();
            contentPanel.AddRelation(gRoot, RelationType.Center_Center);
            contentPanel.AddRelation(gRoot, RelationType.Middle_Middle);
        }
        else
        {
            contentPanel.MakeFullScreen();
            contentPanel.AddRelation(gRoot, RelationType.Size);
        }
        var uiLayer = GetLayer(layer);
        if (uiLayer != null)
        {
            if (window.IsShowOrHideMainUI)
            {
                ShowOrHideMainUI(false);
            }
            BindCloseHandler(window);
            window.data = data;
            window.Visible = true;
            contentPanel.data = window;
            uiLayer.AddChildAt(contentPanel, uiLayer.numChildren);
            AddShowWindowNum(window);
            ShowWindow(window, true);
            windowDic.Add(window.uiName, window);
        }
    }

    private void ShowWindow(BaseWindow window, bool isInit)
    {
        if (isInit) window.OnInit();
        window.OnShown();
        if (window.openWithTween)
        {
            if (isInit)
            {
                window.ui.SetScale(0.1f, 0.1f);
                window.ui.SetPivot(0.5f, 0.5f);
            }
            window.ui.TweenFade(1, 0.3f);
            window.ui.TweenScale(new Vector2(1, 1), 0.3f).SetEase(EaseType.BackOut).OnComplete(() =>
            {
                DispatchPanelEvent(true, window.uiName);
            });
        }
        else
        {
            DispatchPanelEvent(true, window.uiName);
        }
    }

    private void DispatchPanelEvent(bool isShow, string uiName)
    {
        EventManager.Instance.DispatchEvent(SystemEvent.ShowHidePanel, isShow, uiName);
    }

    /// <summary>
    /// 找到最后一个打开窗口的索引
    /// </summary>
    private int GetLastShowWindowIndex(GComponent uiLayer)
    {
        var hasModalLayer = false;
        for (var i = uiLayer.numChildren - 1; i >= 0; i--)
        {
            var window = uiLayer.GetChildAt(i);
            if (window.name == "ModalLayer")
            {
                hasModalLayer = true;
                continue;
            }
            var baseWindow = window.data as BaseWindow;
            if (window.visible && baseWindow.showModal)
            {
                return hasModalLayer ? i + 1 : i;
            }
        }
        return -1;
    }

    public void CloseAll()
    {
        CloseAllPannel();
        CloseAllWindown();
    }

    public void CloseAllWindown()
    {
        foreach (var keyValuePair in windowDic)
        {
            CloseWindow(keyValuePair.Key, true);
        }
        showWindowNum = 0;
        if (_modalLayer != null)
        {
            _modalLayer.visible = false;
        }
    }

    public void CloseAllPannel(bool Filter = false)
    {
        foreach (var keyValuePair in panelDic)
        {
            if (Filter && keyValuePair.Key == UIName.MainView)
            {
                continue;
            }
            ClosePanel(keyValuePair.Key);
        }
        showPanelNum = 0;
    }

    private GGraph _modalLayer;
    private void CheckShowModal()
    {
        var isShowWindow = showWindowNum > 0;
        if (isShowWindow)
        {
            var uiLayer = GetLayer(UILayer.Window);
            var lastShowWindowIndex = GetLastShowWindowIndex(uiLayer);
            if (lastShowWindowIndex == -1) return;//一个窗口都没有
            if (_modalLayer == null)
            {
                _modalLayer = CreateModal();
                _modalLayer.visible = true;

                uiLayer.AddChildAt(_modalLayer, lastShowWindowIndex);
            }
            else
            {
                _modalLayer.visible = true;
                uiLayer.SetChildIndex(_modalLayer, lastShowWindowIndex == 0 ? 0 : lastShowWindowIndex - 1);
            }
        }
        else
        {
            if (_modalLayer != null)
            {
                _modalLayer.visible = false;
            }
        }
    }


    private GGraph CreateModal()
    {
        var modalLayer = new GGraph();
        var a = 0.6f;
        modalLayer.DrawRect(GRoot.inst.width, GRoot.inst.height, 0, Color.white, new Color(0f, 0f, 0f, a));
        modalLayer.name = modalLayer.gameObjectName = "ModalLayer";
        modalLayer.onClick.Add(() =>
        {
            var topWindow = GetTopWindow();
            if (topWindow != null && topWindow.ClickBlankClose)
            {
                CloseWindow(topWindow.uiName);
            }
        });
        return modalLayer;
    }

    /// <summary>
    /// 获取最顶层正显示的Window
    /// </summary>
    /// <returns></returns>
    public BaseWindow GetTopWindow()
    {
        var uiLayer = GetLayer(UILayer.Window);
        for (var i = uiLayer.numChildren - 1; i >= 0; i--)
        {
            var window = uiLayer.GetChildAt(i);
            if (window.name == "ModalLayer")
            {
                continue;
            }
            if (window.visible)
            {
                return window.data as BaseWindow;
            }
        }
        return null;
    }

    private IEnumerator LoadPanel(BaseView panel, UILayer layer, object data = null)
    {
        // 加载 bytes 文件
        AllAssetsHandle assetHandle = ResourceManager.Instance.LoadAllAssetsAsync(ResPath.GetFuiBytes(panel.packageName));
        yield return assetHandle;
        panel.assetHandle = assetHandle;

        TextAsset textAsset = null;
        Texture2D pngAsset = null;
        foreach (var assetObj in assetHandle.AllAssetObjects)
        {
            if (assetObj is TextAsset)
            {
                textAsset = assetObj as TextAsset;
            }
            else if (assetObj is Texture2D)
            {
                pngAsset = assetObj as Texture2D;
            }
        }
        if (panelDic.ContainsKey(panel.uiName)) yield break;//避免弱网下重复初始化
        UIPackage.AddPackage(textAsset.bytes, panel.packageName, (string name, string extension, System.Type type, out DestroyMethod method) =>
        {
            method = DestroyMethod.None; //注意：这里一定要设置为None
            return pngAsset;
        });
        panel.BindAllDelegate?.Invoke();
        var contentPanel = panel.CreateInstanceDelegate?.Invoke().asCom;
        contentPanel.fairyBatching = panel.fairyBatching;//开启动态合批
        panel.ui = contentPanel;
        contentPanel.MakeFullScreen();
        contentPanel.AddRelation(gRoot, RelationType.Size);
        var uiLayer = GetLayer(layer);
        if (uiLayer != null)
        {
            if (panel.IsShowOrHideMainUI)
            {
                ShowOrHideMainUI(false, false);
            }
            BindCloseHandler(panel);
            uiLayer.AddChild(contentPanel);
            panel.Visible = true;
            panel.data = data;
            panel.OnInit();
            panel.OnShown();
            panelDic.Add(panel.uiName, panel);
            AddShowPanelNum(panel);
        }
    }

    /// <summary>
    /// 绑定统一的关闭处理
    /// </summary>
    private void BindCloseHandler(BaseView view)
    {
        var component = view.ui;
        if (component == null) return;
        GButton closeButton = component.GetChild("close_btn") as GButton;
        if (closeButton != null)
        {
            closeButton.onClick.Add(() =>
            {
                ClosePanel(view.uiName);
            });
        }
    }

    /// <summary>
    /// 绑定统一的关闭处理
    /// </summary>
    private void BindCloseHandler(BaseWindow view)
    {
        var component = view.ui;
        if (component == null) return;
        GButton closeButton = component.GetChild("close_btn") as GButton;
        if (closeButton != null)
        {
            closeButton.onClick.Add(() =>
            {
                CloseWindow(view.uiName);
            });
        }
    }

    /// <summary>
    /// 是否有窗口打开了
    /// </summary>
    public bool HasWindowShow
    {
        get { return showWindowNum > 0; }
    }

    /// <summary>
    /// 是否有全屏界面打开了
    /// </summary>
    public bool HasPanelShow
    {
        get { return showPanelNum > 0; }
    }
    public void ClosePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            var panel = panelDic[panelName];
            if (!panel.Visible)
            {
                return;
            }
            panel.Visible = false;
            panel.OnHide();
            SubShowPanelNum(panel);
        }
    }

    public void CloseWindow(string windowName, bool isImmediateClose = false)
    {
        if (windowDic.ContainsKey(windowName))
        {
            var window = windowDic[windowName];
            if (!window.Visible || window.isClosing)
            {
                return;
            }
            window.isClosing = true;

            if (isImmediateClose || !window.openWithTween)
            {
                window.Visible = false;
                window.OnHide();
                SubShowWindowNum(window);
                DispatchPanelEvent(false, window.uiName);
            }
            else
            {
                window.ui.TweenFade(0, 0.3f).SetEase(EaseType.CircOut);
                window.ui.TweenScale(new Vector2(0.1f, 0.1f), 0.3f).SetEase(EaseType.CircOut).OnComplete(() =>
                {
                    window.Visible = false;
                    window.OnHide();
                    SubShowWindowNum(window);
                    DispatchPanelEvent(false, window.uiName);
                });
            }
        }
    }


    /// <summary>
    /// 获取一个view
    /// </summary>
    /// <param name="viewName"></param>
    /// <returns></returns>
    public BaseView GetView(string viewName)
    {
        if (panelDic.TryGetValue(viewName, out BaseView baseView))
        {
            return baseView;
        }
        return null;
    }

    /// <summary>
    /// 获取一个window
    /// </summary>
    /// <param name="windWowName"></param>
    /// <returns></returns>
    public BaseWindow GetWindow(string windWowName)
    {
        if (windowDic.TryGetValue(windWowName, out BaseWindow baseWindow))
        {
            return baseWindow;
        }
        return null;
    }

    private void OnDestroy()
    {
        ReleaseHandles();
    }

    // 释放资源句柄列表
    private void ReleaseHandles()
    {
        foreach (var handle in _handles)
        {
            handle.Release();
        }
        _handles.Clear();
    }

    /// <summary>
    /// 显示隐藏主界面UI
    /// </summary>
    /// <param name="isShow"></param>
    public void ShowOrHideMainUI(bool isShow, bool isTween = true, bool isPlant = false)
    {
        if (HasPanelShow) return;//已经有全屏界面
        EventManager.Instance.DispatchEvent(SystemEvent.ShowOrHideMainUI, isShow, isTween, isPlant);
    }

    /// <summary>
    /// 销毁一个界面
    /// </summary>
    /// <param name="panelName"></param>
    public void DestroyPanel(string panelName)
    {
        BasePanel panel = GetView(panelName);
        if (panel == null)
        {
            panel = GetWindow(panelName);
        }
        if (panel == null) return;
        if (!string.IsNullOrEmpty(panel.packageName))
        {
            UIPackage.RemovePackage(panel.packageName);
            panelDic.Remove(panelName);
            windowDic.Remove(panelName);
            //资源从内存中卸载
            if (panel.assetHandle != null)
            {
                panel.assetHandle.Release();
                panel.assetHandle = null;
                ResourceManager.Instance.TryUnloadUnusedAsset(ResPath.GetFuiBytes(panel.packageName));
            }
        }
    }

    // 类型缓存
    private Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
    // 使用委托进一步优化性能
    private Dictionary<Type, Action<string, UILayer, object>> panelDelegateCache = new Dictionary<Type, Action<string, UILayer, object>>();
    private Dictionary<Type, Action<string, object, UILayer>> windowDelegateCache = new Dictionary<Type, Action<string, object, UILayer>>();
    /// <summary>
    /// 直接通过UIName打开面板，不需要指定泛型
    /// 此方法有点消耗，除了新手、获取途径、剧情其他都不要调用
    /// </summary>
    /// <param name="uiName"></param>
    /// <param name="layer"></param>
    /// <param name="data"></param>
    public void OpenPanelByName(string uiName, UILayer layer = UILayer.UI, object data = null)
    {
        try
        {
            if (!typeCache.TryGetValue(uiName, out Type panelType))
            {
                panelType = Type.GetType(uiName);
                if (panelType != null)
                {
                    typeCache[uiName] = panelType;
                }
                else
                {
                    Debug.LogError("找不到对应的类: " + uiName);
                    return;
                }
            }

            if (typeof(BaseView).IsAssignableFrom(panelType))
            {
                layer = UILayer.UI;

                if (!panelDelegateCache.TryGetValue(panelType, out Action<string, UILayer, object> invokeAction))
                {
                    // 创建并缓存委托
                    MethodInfo baseMethod = typeof(UIManager).GetMethod("OpenPanel", BindingFlags.Public | BindingFlags.Instance);
                    if (baseMethod != null)
                    {
                        MethodInfo genericMethod = baseMethod.MakeGenericMethod(panelType);
                        invokeAction = (name, l, d) => genericMethod.Invoke(this, new object[] { name, l, d });
                        panelDelegateCache[panelType] = invokeAction;
                    }
                }

                invokeAction?.Invoke(uiName, layer, data);
            }
            else if (typeof(BaseWindow).IsAssignableFrom(panelType))
            {
                layer = UILayer.Window;

                if (!windowDelegateCache.TryGetValue(panelType, out Action<string, object, UILayer> invokeAction))
                {
                    // 创建并缓存委托
                    MethodInfo baseMethod = typeof(UIManager).GetMethod("OpenWindow", BindingFlags.Public | BindingFlags.Instance);
                    if (baseMethod != null)
                    {
                        MethodInfo genericMethod = baseMethod.MakeGenericMethod(panelType);
                        invokeAction = (name, d, l) => genericMethod.Invoke(this, new object[] { name, d, l });
                        windowDelegateCache[panelType] = invokeAction;
                    }
                }

                invokeAction?.Invoke(uiName, data, layer);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("OpenPanelByName打开面板失败: " + uiName + "\n" + e.Message);
        }
    }
}
