using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.plant;
using UnityEngine;

public class MailController : BaseController<MailController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_MAIL_LIST>((int)MessageCode.S_MSG_MAIL_LIST, MailListInfo);
        AddNetListener<S_MSG_MAIL_REWARD>((int)MessageCode.S_MSG_MAIL_REWARD, MailReward);
        AddNetListener<S_MSG_MAIL_DEL>((int)MessageCode.S_MSG_MAIL_DEL, MailDel);
    }

    public void MailListInfo(S_MSG_MAIL_LIST data)
    {
        MailModel.Instance.mailData = data.mailList;
        EventManager.Instance.DispatchEvent(MailEvent.MailListInfo);
    }

    public void ReqMailListInfo()
    {
        C_MSG_MAIL_LIST c_MSG_MAIL_LIST = new C_MSG_MAIL_LIST();
        SendCmd((int)MessageCode.C_MSG_MAIL_LIST, c_MSG_MAIL_LIST);
    }

    public void MailReward(S_MSG_MAIL_REWARD data)
    {
        MailModel.Instance.UpdateRewardStatus(data.mailIds);
        MailModel.Instance.GetReward(data.mailIds);
        EventManager.Instance.DispatchEvent(MailEvent.MailReward);
    }

    public void ReqMailReward(List<string> mailIds)
    {
        C_MSG_MAIL_REWARD c_MSG_MAIL_REWARD = new C_MSG_MAIL_REWARD();
        c_MSG_MAIL_REWARD.mailIds = mailIds;
        SendCmd((int)MessageCode.C_MSG_MAIL_REWARD, c_MSG_MAIL_REWARD);
    }

    public void MailDel(S_MSG_MAIL_DEL data)
    {
        MailModel.Instance.DelMail(data.mailIds);
        EventManager.Instance.DispatchEvent(MailEvent.MailDel);
    }

    public void ReqMailDel(List<string> mailIds)
    {
        C_MSG_MAIL_DEL c_MSG_MAIL_DEL = new C_MSG_MAIL_DEL();
        c_MSG_MAIL_DEL.mailIds = mailIds;
        SendCmd((int)MessageCode.C_MSG_MAIL_DEL, c_MSG_MAIL_DEL);
    }
}
