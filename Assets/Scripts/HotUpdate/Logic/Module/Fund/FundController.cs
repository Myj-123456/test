using System.Collections;
using System.Collections.Generic;
using protobuf.fund;
using protobuf.messagecode;
using UnityEngine;

public class FundController : BaseController<FundController>
{
    protected override void InitListeners()
    {
        //领取培育基金奖励
        AddNetListener<S_MSG_FUND_REWARD>((int)MessageCode.S_MSG_FUND_REWARD, FundReward);
    }

    public void FundReward(S_MSG_FUND_REWARD data)
    {
        FundModel.Instance.UpdateFundData(data.fundVo);
        DispatchEvent(FundEvent.FundReward);
    }

    public void ReqFundReward(uint fundType)
    {
        C_MSG_FUND_REWARD c_MSG_FUND_REWARD = new C_MSG_FUND_REWARD();
        c_MSG_FUND_REWARD.fundType = fundType;
        SendCmd((int)MessageCode.C_MSG_FUND_REWARD, c_MSG_FUND_REWARD);
    }
}
