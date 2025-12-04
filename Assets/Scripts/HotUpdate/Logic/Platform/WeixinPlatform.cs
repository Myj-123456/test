#if WEIXINMINIGAME
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using WeChatWASM;

public class WeixinPlatform: Singleton<WeixinPlatform>
{
    private WXRewardedVideoAd rewardedVideoAd;

    private bool isCanShare = true;

    private bool isCanVideo = true;
    //初始化SDK
    public void Init(Action callback)
    {
        WX.InitSDK((int code) => {
            callback();
        });
    }

    //从后台进入游戏
   public void OnShow(Action<OnShowListenerResult> callback)
    {
        WX.OnShow(callback);
    }

    //游戏进入后台
    public void OnHide(Action<GeneralCallbackResult> callback)
    {
        WX.OnHide(callback);
    }

    //创建激励广告
    public void CreateRewardedAd()
    {
        var param = new WXCreateRewardedVideoAdParam();
        param.adUnitId = "";
        param.multiton = false;
        rewardedVideoAd = WX.CreateRewardedVideoAd(param);
        rewardedVideoAd.Load((res) =>
        {
            Debug.Log("rewardedVideoAd onLoad event");
        });
        rewardedVideoAd.OnError((err) =>
        {
            Debug.Log("rewardedVideoAd onError event:" + err.errCode);
        });
    }

    //播放激励广告
    public async Task<bool> ShowRewardedAd()
    {
        if(rewardedVideoAd == null)
        {
            var param = new WXCreateRewardedVideoAdParam();
            param.adUnitId = "";
            param.multiton = false;
            rewardedVideoAd = WX.CreateRewardedVideoAd(param);
            rewardedVideoAd.Load((res) =>
            {
                Debug.Log("rewardedVideoAd onLoad event");
            });
            rewardedVideoAd.OnError((err) =>
            {
                Debug.Log("rewardedVideoAd onError event:" + err.errCode);
            });
        }
        var tcs = new TaskCompletionSource<bool>();
        //rewardedVideoAd.OffClose();
        Action<WXRewardedVideoAdOnCloseResponse> closeHandler = null;
        closeHandler = res =>
        {
            // 注销监听
            rewardedVideoAd.OffClose(closeHandler);
            tcs.TrySetResult(res.isEnded);
        };
        rewardedVideoAd.OnClose(closeHandler);
        rewardedVideoAd.Show(null, (err) =>
        {
            rewardedVideoAd.Load((res) =>
            {
                rewardedVideoAd.Show();
            }, (err) =>
            {
                Debug.Log("rewardedVideoAd onError event:" + err.errCode);
                tcs.SetResult(false);
            });
        });
        return await tcs.Task;
    }

    //获取登录code
    public async Task<string> GetLoginCode()
    {
        var tcs = new TaskCompletionSource<string>();
        var param = new LoginOption();
        param.success = (res) =>
        {
            tcs.SetResult(res.code);
        };
        param.fail = (err) =>
        {
            Debug.Log("getLoginCode fail:" + err.errno + " " + err.errMsg);
            tcs.SetResult(null);
        };
        WX.Login(param);
        return await tcs.Task;
    }

    //授权隐私协议
    public async Task<bool> RequirePrivacyAuthorize()
    {
        var tcs = new TaskCompletionSource<bool>();
        var sysInfo = WX.GetSystemInfoSync();
        var sdkVersion = sysInfo.SDKVersion;
        Debug.Log("sdkVersion:" + sdkVersion);

        Version version = new Version(sdkVersion);
        Version limitVersion = new Version("2.32.3");
        if(version < limitVersion)
        {
            tcs.SetResult(true);
        }
        else
        {
            var param = new RequirePrivacyAuthorizeOption();
            param.success = (res) =>
            {
                Debug.Log("用户同意授权:" + res);
                tcs.SetResult(true);
            };
            param.fail = (err) =>
            {
                Debug.Log("用户拒绝授权:" + err.errMsg);
                tcs.SetResult(false);
            };
            WX.RequirePrivacyAuthorize(param);
        }

        return await tcs.Task;
    }


    //获取用户信息
    public async Task<PlatfromUserInfo> GetUserInfo()
    {
        var tcs = new TaskCompletionSource<PlatfromUserInfo>();
        var sysInfo = WX.GetSystemInfoSync();
        var sdkVersion = sysInfo.SDKVersion;

        var screenW = sysInfo.screenWidth;
        var screenH = sysInfo.screenHeight;

        double ww = 550;
        double hh = 406;

        double www = screenW - 100;
        double hhh = www / ww * hh;
        //判断用户是否授权过
        Version version = new Version(sdkVersion);
        Version limitVersion = new Version("2.0.1");
        var settingParam = new GetSettingOption();
        settingParam.success = (res) =>
        {
            if (version >= limitVersion && res.authSetting["scope.userInfo"])
            {
                var button = WX.CreateUserInfoButton((int)(screenW / 2 - www / 2), (int)(screenH / 2 - hhh / 2), (int)www, (int)hhh,"en",false);
                button.OnTap((res) => {
                    button.Destroy();
                    Debug.Log("createUserInfoButton: " + res.GetType());
                    var userInfo = new PlatfromUserInfo(res.userInfo.nickName,res.userInfo.avatarUrl);
                    tcs.SetResult(userInfo);
                });
            }
            else
            {
                var userParam = new GetUserInfoOption();
                userParam.success = (res) =>
                {
                    var userInfo = new PlatfromUserInfo(res.userInfo.nickName, res.userInfo.avatarUrl);
                    tcs.SetResult(userInfo);
                };
                userParam.fail = (err) =>
                {
                    Debug.Log("GetUserInfo: " + err.errMsg);
                    tcs.SetResult(null);
                };
                WX.GetUserInfo(userParam);
            }
        };
        settingParam.fail = (err) =>
        {
            Debug.Log("GetUserInfo: " + err.errMsg);
            tcs.SetResult(null);
        };
        WX.GetSetting(settingParam);
        return await tcs.Task;
    }
    //分享
    public async Task<bool> ShareMessage(byte[] bytes,string url)
    {
        var tcs = new TaskCompletionSource<bool>();
        var filePath = WX.env.USER_DATA_PATH + url;
        var fs = WX.GetFileSystemManager();
        try
        {
            fs.WriteFileSync(filePath, bytes);
            var param = new ShareAppMessageOption();
            param.imageUrl = filePath;
            WX.ShareAppMessage(param);
            tcs.SetResult(true);
        }
        catch (Exception ex)
        {
            Debug.Log($"保存文件出错:{ex.Message}");
            tcs.SetResult(false);
        }
        return await tcs.Task;
    }

    //删除文件
    public void Unlink(string url)
    {
        var filePath = WX.env.USER_DATA_PATH + url;
        var fs = WX.GetFileSystemManager();
        var param = new UnlinkParam();
        param.filePath = filePath;
        fs.Unlink(param);
    }
    //客服消息
    public async Task<bool> OpenCustomerServiceConversation()
    {
        var tcs = new TaskCompletionSource<bool>();
        var param = new OpenCustomerServiceConversationOption();
        param.success = (res) =>
        {
            Debug.Log("[新的ios] success:" + res);
            tcs.SetResult(true);
        };
        param.fail = (err) =>
        {
            Debug.LogWarning("[新的ios] fail:" + err.errMsg);
            tcs.SetResult(false);
        };
        WX.OpenCustomerServiceConversation(param);
        return await tcs.Task;
    }
    //米大师支付
    public async Task<bool> RequestMidasPayment()
    {
        var tcs = new TaskCompletionSource<bool>();
        var param = new RequestMidasPaymentOption();
        param.success = (res)=>{
            Debug.Log("[MidasPay] success:" + res);
            tcs.SetResult(true);
        };
        param.fail = (err) =>
        {
            Debug.Log("[MidasPay] fail:" + err.errMsg);
            tcs.SetResult(false);
        };
        WX.RequestMidasPayment(param);
        return await tcs.Task;
    }

    public LaunchOptionsGame GetExtraInfo()
    {
        var options = WX.GetLaunchOptionsSync();
        return options;
    }
}
#endif