using System.Collections;
using System.Collections.Generic;
using protobuf.ikebana;
using protobuf.messagecode;
using UnityEngine;
using ADK;

public class IkeController : BaseController<IkeController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_IKEBANA_MAKE>((int)MessageCode.S_MSG_IKEBANA_MAKE, IkebanaMake);
        //鲜花手册， 领取花艺品解锁奖励
        AddNetListener<S_MSG_IKEBANA_REWARD>((int)MessageCode.S_MSG_IKEBANA_REWARD, IkebanaReward);
    }

    public void IkebanaMake(S_MSG_IKEBANA_MAKE data)
    {
        //if (GuideModel.Instance.IsGuide)//引导关闭插花界面
        //{
        //    UIManager.Instance.ClosePanel(UIName.IkeView);
        //}
        int cnt = (int)data.cnt, id = (int)data.combinationId;
        StaticFormula formula = IkeModel.Instance.GetFormula(id);
        IkeModel.Instance.UpdateMakeIke((uint)formula.CombinationId);
        if (formula != null)
        {
            foreach (var item in formula.FlowerCombinationIds)
            {
                StorageModel.Instance.AddToStorageByItemId(int.Parse(item.CounterCount), -(item.Limit * cnt));
            }

            StorageModel.Instance.AddToStorageByItemId(formula.IkebanaId, cnt);
            UIManager.Instance.OpenWindow<IkeResultWindow>(UIName.IkeResultWindow, formula.IkebanaId);
        }
        EventManager.Instance.DispatchEvent(IkebanaEvent.IkebanaMake);
    }

    public void ResIkebanaMake(uint combinationId, uint cnt)
    {
        C_MSG_IKEBANA_MAKE c_MSG_IKEBANA_MAKE = new C_MSG_IKEBANA_MAKE();
        c_MSG_IKEBANA_MAKE.combinationId = combinationId;
        c_MSG_IKEBANA_MAKE.cnt = cnt;
        SendCmd((int)MessageCode.C_MSG_IKEBANA_MAKE, c_MSG_IKEBANA_MAKE);
    }
    //鲜花手册， 领取花艺品解锁奖励
    public void IkebanaReward(S_MSG_IKEBANA_REWARD data)
    {
        IkeModel.Instance.vaseRewardInfo[data.combinationId].status = 2;
        var dropList = ItemModel.Instance.GetDropData(data.items);
        UILogicUtils.ShowGetReward(dropList, () =>
        {
            StorageModel.Instance.AddToStorage(data.items);
        });
        EventManager.Instance.DispatchEvent(IkebanaEvent.IkebanaReward);
    }

    public void ReqIkebanaReward(uint combinationId)
    {
        C_MSG_IKEBANA_REWARD c_MSG_IKEBANA_REWARD = new C_MSG_IKEBANA_REWARD();
        c_MSG_IKEBANA_REWARD.combinationId = combinationId;
        SendCmd((int)MessageCode.C_MSG_IKEBANA_REWARD, c_MSG_IKEBANA_REWARD);
    }
}
