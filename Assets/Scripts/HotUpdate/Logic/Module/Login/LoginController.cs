


using ADK;
using protobuf.common;
using protobuf.login;
using protobuf.messagecode;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;



/// <summary>
/// 登录控制器
/// </summary>
/// 
public class LoginController : BaseController<LoginController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_READY>((int)MessageCode.S_READY, ResReady);
        AddNetListener<S_MSG_GAMEINIT>((int)MessageCode.S_MSG_GAMEINIT, ResGameInit);
        AddNetListener<S_MSG_GAME_MISC>((int)MessageCode.S_MSG_GAME_MISC, ResGameMisc);
        AddEventListener(SystemEvent.CameraOrthoSizeFinish, OnCameraOrthoSizeFinish);
        //不重要信息。客户端不依赖接口字段就可以进入游戏
        AddNetListener<S_MSG_GAME_MILD>((int)MessageCode.S_MSG_GAME_MILD, GameMild);
    }

    private void ResReady(S_READY data)
    {
        ReqGameInit();
        ReqGameMild();
    }

    /// <summary>
    /// 从这里协议开始就算是进入游戏了
    /// </summary>
    /// <param name="data"></param>
    private void ResGameInit(S_MSG_GAMEINIT data)
    {
        Debug.Log("ResGameInit:" + data);
        MyselfModel.Instance.InitData(data);
        PlantModel.Instance.InitPlantList(data.plantList);
        StorageModel.Instance.InitSeedList(data.seedList);
        CultivationModel.Instance.ParseLandInfo(data.cultivate);
        StorageModel.Instance.ParseItemList(data.itemList);
        NpcOrderModel.Instance.InitOrderNpc(data);
        FlowerSellModel.Instance.InitTables(data.tableList);
        FlowerOrderModel.Instance.InitOrderList(data.orderList);
        GuildModel.Instance.guildName = data.guildName;
        MyselfModel.Instance.userShop = data.userShop;
        RechargeModel.Instance.UpdateRechargeInfo(data.rechargeInfo);
        FlowerShopModel.Instance.InitData(data.floristShopInfo.floristShop);
        PlayerModel.Instance.pen = data.pen;
        DressModel.Instance.UpdateDressData(data.dress.ware);
        DressModel.Instance.InitData(data.dress);
        
        FlowerGoldModel.Instance.fairys = data.fairys;
        PopGiftModel.Instance.giftPackList = data.giftPackList;
        PopGiftModel.Instance.tourList = data.tourList;
        GuideController.Instance.InitGuide();        
        GameInitSuccess();
    }


    //放到进入游戏再请求
    public void ResGameMisc(S_MSG_GAME_MISC data)
    {
        SeventhSignModel.Instance.ParseData(data.dailyLoginInfo);
        WelfareModel.Instance.InitDailyLogin(data.dailyLoginInfo);
        GameNoticeModel.Instance.noticeData = data.notice;
        VideoModel.Instance.videoWatch = data.videoWatch;
        GuildModel.Instance.guildMembers = data.guildMembers;

        LoginModel.Instance.isResGameMisc = true;
        
        TaskModel.Instance.mainTask = data.mainTask;
        TaskModel.Instance.progress = data.progress;
        FundModel.Instance.fundInfo = data.fundInfo;
        MyselfModel.Instance.welfareInfo = data.welfareInfo;
        MyselfModel.Instance.waterBucketSeries = TextUtil.ToStringList(data.welfareInfo.waterBucketSeries);
        WelfareModel.Instance.rookieRewards = data.mainTask.rookieRewards;
        CustomerModel.Instance.InitCustomerData(data.npcInfo);
        Coroutiner.StartCoroutine(EnterGameScene());
        MyselfModel.Instance.UpdateDailyInfo(data.dailyStatVo);
    }

    public void GameMild(S_MSG_GAME_MILD data)
    {
        IkeModel.Instance.vaseRewardInfo = data.vaseRewardInfo;
        if (data.blackUserIds == null)
        {
            FriendModel.Instance.blackUserIds = new List<uint>();
        }
        else
        {
            FriendModel.Instance.blackUserIds = data.blackUserIds.ToList();
        }
        DrawModel.Instance.furnitureExchangeStat = data.furnitureExchangeStat;
    }

    public void ReqGameMild()
    {
        C_MSG_GAME_MILD c_MSG_GAME_MILD = new C_MSG_GAME_MILD();
        SendCmd((int)MessageCode.C_MSG_GAME_MILD, c_MSG_GAME_MILD);
    }
    private bool isFristCameraOrthoSize = true;
    /// <summary>
    /// 场景镜头缓动完毕再检测弹框
    /// </summary>
    private void OnCameraOrthoSizeFinish()
    {
        if (!isFristCameraOrthoSize) return;//只运行一次
        isFristCameraOrthoSize = false;
        if (LoginModel.Instance.isResGameMisc)
        {
            InitPopModel.Instance.RecheckInitPopup();
        }
    }

    public void ReqGameMisc()
    {
        LoginModel.Instance.isResGameMisc = false;
        C_MSG_GAME_MISC c_MSG_GAME_MISC = new C_MSG_GAME_MISC();
        SendCmd((int)MessageCode.C_MSG_GAME_MISC, c_MSG_GAME_MISC);
    }


    /// <summary>
    /// 游戏初始化成功后需要处理的逻辑放这里
    /// </summary>
    private void GameInitSuccess()
    {
        if (GlobalModel.Instance.GetUnlocked(SysId.FlowerRank))
        {
            //FlowerRankController.Instance.ResRankInfo();
        }
        ReqGameMisc();
        GlobalModel.Instance.StartTick();
        if (LoginModel.Instance.isReConnect)//重连抛出事件
        {
            DispatchEvent(SystemEvent.Reconnect);
        }
        LoginModel.Instance.isReConnect = false;
        LoginModel.Instance.isGameInit = true;
    }

    /// <summary>
    /// 请求游戏初始化
    /// </summary>
    public void ReqGameInit()
    {
        C_MSG_GAMEINIT c_MSG_GAMEINIT = new C_MSG_GAMEINIT();
        SendCmd((int)MessageCode.C_MSG_GAMEINIT, c_MSG_GAMEINIT);
    }

    public void StartLogin()
    {
        ReqLogin();
    }

    /// <summary>
    /// 请求登录
    /// 正常流程需要发起预登录拿到相关参数再发起登录
    /// app登录的话需要先拿到playTimeLimit为true才允许发起ReqLogin流程
    /// </summary>
    public void ReqLogin()
    {
        PreLoadManager.Instance.ShowLoadingDes("请求登录");
        var pid = LoginHelper.GetPid();
        Debug.Log("请求登录,pid: " + pid);
        var platform = LoginHelper.GetPlatform();
        var loginPlatform = LoginHelper.GetLoginPlatform();
        var token = LoginHelper.GetToken();
        var salt = LoginHelper.GetSalt();
        Http.Get<HttpLoginData>(ApiName.GAME_LOGIN, OnLoginCallBack, false, pid, platform, loginPlatform, token, salt);
    }

    /// <summary>
    /// app预登录
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    public void ReqAppPreLogin(string username, string password)
    {
        Http.Get<HttpAppLoginRegisterData>(ApiName.GAME_APPPRELOGIN, OnAppPreLoginCallBack, false, username, password);
    }
    private void OnAppPreLoginCallBack(ResponseResult<HttpAppLoginRegisterData> responseResult)
    {
        if (responseResult.code == 0)
        {
            var httpAppLoginRegisterData = responseResult.data;
            LoginModel.Instance.openid = httpAppLoginRegisterData.openid;
            LoginModel.Instance.token = httpAppLoginRegisterData.token;
            LoginModel.Instance.salt = httpAppLoginRegisterData.salt;
            LoginModel.Instance.verifyStatus = httpAppLoginRegisterData.verifyStatus;
            CheckCertificationOrLogin();
        }
        else
        {
            if (!string.IsNullOrEmpty(responseResult.message))
            {
                ADK.UILogicUtils.ShowConfirm(responseResult.message, null, null, false);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("错误码：" + responseResult.code);
            }
            Debug.LogError("登录失败code：" + responseResult.code);
            Debug.LogError("message:" + responseResult.message);
        }
    }

    /// <summary>
    /// app注册
    /// </summary>
    public void ReqAppRegister(string username, string password, string confirmPassword)
    {
        Http.Get<HttpAppLoginRegisterData>(ApiName.GAME_APPREGISTER, OnAppRegisterCallBack, false, username, password, confirmPassword);
    }

    private void OnAppRegisterCallBack(ResponseResult<HttpAppLoginRegisterData> responseResult)
    {
        if (responseResult.code == 0)
        {
            var httpAppLoginRegisterData = responseResult.data;
            LoginModel.Instance.openid = httpAppLoginRegisterData.openid;
            LoginModel.Instance.token = httpAppLoginRegisterData.token;
            LoginModel.Instance.salt = httpAppLoginRegisterData.salt;
            LoginModel.Instance.verifyStatus = httpAppLoginRegisterData.verifyStatus;
            CheckCertificationOrLogin();
        }
        else
        {
            if (!string.IsNullOrEmpty(responseResult.message))
            {
                ADK.UILogicUtils.ShowConfirm(responseResult.message, null, null, false);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("错误码：" + responseResult.code);
            }
            Debug.LogError("登录失败code：" + responseResult.code);
            Debug.LogError("message:" + responseResult.message);
        }
    }


    /// <summary>
    /// 检测是否需要实名认证还是登录
    /// </summary>
    private void CheckCertificationOrLogin()
    {
        AntiAddictionController.Instance.VerifyStatus(LoginModel.Instance.openid, LoginModel.Instance.token, LoginModel.Instance.salt);
    }

    public void CloseLogin()
    {
        UIManager.Instance.CloseWindow(UIName.LoginWindow, true);
        UIManager.Instance.CloseWindow(UIName.CertificationWindow, true);
        UIManager.Instance.CloseWindow(UIName.RegisterWindow, true);
    }


    private void OnLoginCallBack(ResponseResult<HttpLoginData> responseResult)
    {
        if (responseResult.code == 0)
        {
            LoginModel.Instance.gameWssUrl = responseResult.data.gameWssUrl;
            LoginModel.Instance.chatWssUrl = responseResult.data.chatWssUrl;
            LoginModel.Instance.loginToken = responseResult.data.token;
            Debug.Log("token:" + responseResult.data.token);
            ServerTime.UpdateServerTime(responseResult.data.serverTime, 0);
            PreLoadManager.Instance.ShowLoadingDes("连接服务器");
            NetWorkManager.Instance.Connect(responseResult.data.gameWssUrl + "?token=" + responseResult.data.token, OnConnectSuccess);
        }
        else
        {
            if (!string.IsNullOrEmpty(responseResult.message))
            {
                ADK.UILogicUtils.ShowConfirm(responseResult.message, null, null, false);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("错误码：" + responseResult.code);
            }
            Debug.LogError("登录失败code：" + responseResult.code);
        }
    }

    private void OnConnectSuccess()
    {
        if (LoginModel.Instance.isReConnect)
        {
            Debug.Log("游戏服重连成功");
        }
        else
        {
            GlobalModel.Instance.InitModule_profileConfigData();
            InitController();
            Debug.Log("游戏服连接成功!");
        }
        ReConnectManager.Instance.StarReConnect();
        GlobalController.Instance.StartHeartBeat();
        //ReqGameInit();
        //ReqGameMild();
        ConnectChatServer();
    }

    /// <summary>
    /// 游戏服连接成功之后连接聊天服
    /// </summary>
    private void ConnectChatServer()
    {
        if (ChatNetWorkManager.Instance.isConnected) return;//聊天服已连接了 不再重复连接
        ChatNetWorkManager.Instance.Connect(LoginModel.Instance.chatWssUrl + "?token=" + LoginModel.Instance.loginToken, OnChatServerConnectSuccess);
    }
    /// <summary>
    /// 重连
    /// </summary>
    public void ReConnectChatServer()
    {
        var wssUrl = LoginModel.Instance.chatWssUrl;
        var loginToken = LoginModel.Instance.loginToken;
        if (!string.IsNullOrEmpty(wssUrl) && !string.IsNullOrEmpty(loginToken))
        {
            GlobalController.Instance.StopChatServerHeartBeat();
            ChatNetWorkManager.Instance.ReConnect(wssUrl + "/?token=" + loginToken, OnChatServerConnectSuccess);
        }
    }
    private void OnChatServerConnectSuccess()
    {
        Debug.Log("聊天服连接成功!");
        ChatReConnectManager.Instance.StarReConnect();
        GlobalController.Instance.StartChatServerHeartBeat();
    }

    /// <summary>
    /// 重连
    /// </summary>
    public void ReConnect()
    {
        var wssUrl = LoginModel.Instance.gameWssUrl;
        var loginToken = LoginModel.Instance.loginToken;
        if (!string.IsNullOrEmpty(wssUrl) && !string.IsNullOrEmpty(loginToken))
        {
            LoginModel.Instance.isReConnect = true;
            GlobalController.Instance.StopHeartBeat();
            NetWorkManager.Instance.ReConnect(wssUrl + "/?token=" + loginToken, OnConnectSuccess);
        }
    }

    /// <summary>
    /// 初始化一些控制器
    /// </summary>
    private void InitController()
    {
        _ = GlobalController.Instance;
        _ = MyselfController.Instance;
        _ = ServiceNotifyContorller.Instance;
        _ = MarqueeContorller.Instance;
    }

    private IEnumerator EnterGameScene()
    {
        if (!LoginModel.Instance.isEnterGameScene)
        {
            PreLoadManager.Instance.ShowLoadingDes("正在进入游戏");
            Debug.Log("跳转游戏场景");
            var package = YooAssets.GetPackage("DefaultPackage");
            var sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single;
            var physicsMode = LocalPhysicsMode.None;
            bool suspendLoad = false;
            SceneHandle handle = package.LoadSceneAsync(ResPath.GetScenePath("Game"), sceneMode, physicsMode, suspendLoad);
            yield return handle;
            LoginModel.Instance.isEnterGameScene = true;
            Coroutiner.StopCoroutine(EnterGameScene());
        }
    }
}

