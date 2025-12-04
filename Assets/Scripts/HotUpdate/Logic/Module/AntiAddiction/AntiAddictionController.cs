using ADK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HttpCertificationData
{
    public int verifyStatus;
    public string idCard;//身份证号码
    public string realName; //真实姓名
    public bool isMinor; //是否是未成年
    public long[] rechargeLimit;//消费限制 第0个元素：单笔订单金额限制 第1个元素：每月消费累计限制
    public bool isHoliday;//是否是周五、六、日 或者节假日
    public bool playTimeLimit;//是否可以玩 true：可以玩 false：不可以玩，成年用户一直返回true，未成年只有在周五、六、日、节假日的20-21点返回true
    public uint monthRecharge;//当月累计消费金额（版号提审用）
}

/// <summary>
/// 防沉迷控制器
/// </summary>
public class AntiAddictionController : BaseController<AntiAddictionController>
{

    /// <summary>
    /// 请求身份验证
    /// </summary>
    /// <param name="realname"></param>
    /// <param name="idCard"></param>
    public void ReqCertification(string openid, string login_token, string login_salt, string idCard, string realname)
    {
        Http.Get<HttpCertificationData>(ApiName.GAME_IDCARD, OnCertificationCallBack, false, openid, login_token, login_salt, idCard, realname);
    }
    private void OnCertificationCallBack(ResponseResult<HttpCertificationData> responseResult)
    {
        if (responseResult.code == 0)
        {
            var data = responseResult.data;
            if (data.verifyStatus == 0)//验证成功
            {
                if (data.playTimeLimit)//可以玩
                {
                    if (data.isMinor)//未成年人弹框提示
                    {
                        var tips = Lang.GetValue("text_fang_tips1") + "\n\n" + Lang.GetValue("text_fang_tips3");
                        ADK.UILogicUtils.ShowConfirm(tips, StartPreLoad, null, false, true);
                    }
                    else//已成年走后续资源预加载登录流程
                    {
                        StartPreLoad();
                    }
                }
                else//未成年禁止玩
                {
                    ADK.UILogicUtils.ShowNotice("您为未成年人(未满18周岁)玩家，当前时间段不在可玩时间段内");
                }
            }
            else if (data.verifyStatus == 1)//认证中
            {
                ADK.UILogicUtils.ShowNotice("正在认证中，请稍后再来");
            }
            if (data.verifyStatus == 2)//验证失败
            {
                ADK.UILogicUtils.ShowNotice("认证失败，请再次认证");
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(responseResult.message))
            {
                ADK.UILogicUtils.ShowNotice(responseResult.message);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("错误码:" + responseResult.code);
            }
            Debug.LogError("code：" + responseResult.code);
            Debug.LogError("message:" + responseResult.message);
        }
    }

    private void StartPreLoad()
    {
        LoginController.Instance.CloseLogin();
        Coroutiner.StartCoroutine(PreLoadManager.Instance.StartPreLoad());
    }

    /// <summary>
    /// 获取用户实名信息
    /// </summary>
    /// <param name="openid"></param>
    /// <param name="login_token"></param>
    /// <param name="login_salt"></param>
    public void VerifyStatus(string openid, string login_token, string login_salt)
    {
        Http.Get<HttpCertificationData>(ApiName.GAME_VERIFYSTATUS, OnVerifyStatusCallBack, false, openid, login_token, login_salt);
    }
    private void OnVerifyStatusCallBack(ResponseResult<HttpCertificationData> responseResult)
    {
        if (responseResult.code == 0)
        {
            var data = responseResult.data;
            if (data.verifyStatus == 0)//验证成功
            {
                if (data.playTimeLimit)//可以玩
                {
                    StartPreLoad();
                }
                else//未成年禁止玩
                {
                    var tips = Lang.GetValue("text_fang_tips1") + "\n\n" + Lang.GetValue("text_fang_tips2");
                    ADK.UILogicUtils.ShowConfirm(tips, ADK.ADKTool.QuitGame, null, false);
                }
            }
            else if (data.verifyStatus == 1)//认证中
            {
                ADK.UILogicUtils.ShowConfirm("正在认证中，请稍后再来", ADK.ADKTool.QuitGame, null, false);
            }
            else if (data.verifyStatus == -1 || data.verifyStatus == 2)//未实名验证或者验证失败开始弹窗实名认证弹框
            {
                UIManager.Instance.CloseWindow(UIName.LoginWindow);
                UIManager.Instance.CloseWindow(UIName.RegisterWindow);
                UIManager.Instance.OpenWindow<CertificationWindow>(UIName.CertificationWindow);
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(responseResult.message))
            {
                ADK.UILogicUtils.ShowNotice(responseResult.message);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("错误码:" + responseResult.code);
            }
            Debug.LogError("code：" + responseResult.code);
            Debug.LogError("message:" + responseResult.message);
        }
    }
}
