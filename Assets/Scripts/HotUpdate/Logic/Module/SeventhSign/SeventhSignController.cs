using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.misc;
using UnityEngine;

public class SeventhSignController : BaseController<SeventhSignController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_DAILY_LOGIN_AWARD>((int)MessageCode.S_MSG_DAILY_LOGIN_AWARD, DailyLoginAward);
        
    }

    public void DailyLoginAward(S_MSG_DAILY_LOGIN_AWARD data)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(data.items));
        SeventhSignModel.Instance.todayHaveDraw = true;
        EventManager.Instance.DispatchEvent(SeventhSignEvent.DailyLoginAward);
    }

    public void ReqDailyLoginAward()
    {
        C_MSG_DAILY_LOGIN_AWARD c_MSG_DAILY_LOGIN_AWARD = new C_MSG_DAILY_LOGIN_AWARD();
        SendCmd((int)MessageCode.C_MSG_DAILY_LOGIN_AWARD, c_MSG_DAILY_LOGIN_AWARD);
    }
}
