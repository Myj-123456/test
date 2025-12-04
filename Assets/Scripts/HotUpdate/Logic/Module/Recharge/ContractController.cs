using System.Collections;
using System.Collections.Generic;
using protobuf.card;
using protobuf.messagecode;
using UnityEngine;

public class ContractController : BaseController<ContractController>
{
    protected override void InitListeners()
    {
        //合约
        AddNetListener<S_MSG_CONTRACT_INFO>((int)MessageCode.S_MSG_CONTRACT_INFO, ContractInfo);
        //合约任务奖励
        AddNetListener<S_MSG_CONTRACT_TASK_REWARD>((int)MessageCode.S_MSG_CONTRACT_TASK_REWARD, ContractTaskReward);
        //合约等级奖励
        AddNetListener<S_MSG_CONTRACT_LEVEL_REWARD>((int)MessageCode.S_MSG_CONTRACT_LEVEL_REWARD, ContractLevelReward);
    }
    //合约
    public void ContractInfo(S_MSG_CONTRACT_INFO data)
    {
        var activityInfo = DrawModel.Instance.GetGameEventInfo((int)data.activityId);
        if (ContractModel.Instance.contractData.ContainsKey(data.activityId))
        {
            ContractModel.Instance.contractData[data.activityId] = data;
        }
        else
        {
            ContractModel.Instance.contractData.Add(data.activityId, data);
        }
        if (activityInfo.Type == (int)ActivityType.Contract)
        {   
            EventManager.Instance.DispatchEvent(ContractEvent.Contract);
        }
    }

    public void ReqContractInfo(uint activityId)
    {
        C_MSG_CONTRACT_INFO c_MSG_CONTRACT_INFO = new C_MSG_CONTRACT_INFO();
        c_MSG_CONTRACT_INFO.activityId = activityId;
        SendCmd((int)MessageCode.C_MSG_CONTRACT_INFO, c_MSG_CONTRACT_INFO);
    }
    //合约任务奖励
    public void ContractTaskReward(S_MSG_CONTRACT_TASK_REWARD data)
    {
        ContractModel.Instance.UpdateContractTask(data);
        EventManager.Instance.DispatchEvent(ContractEvent.ContractTaskReward);
    }
    public void ReqContractTaskReward(uint activityId,uint pos)
    {
        C_MSG_CONTRACT_TASK_REWARD c_MSG_CONTRACT_TASK_REWARD = new C_MSG_CONTRACT_TASK_REWARD();
        c_MSG_CONTRACT_TASK_REWARD.activityId = activityId;
        c_MSG_CONTRACT_TASK_REWARD.pos = pos;
        SendCmd((int)MessageCode.C_MSG_CONTRACT_TASK_REWARD, c_MSG_CONTRACT_TASK_REWARD);
    }
    //合约等级奖励
    public void ContractLevelReward(S_MSG_CONTRACT_LEVEL_REWARD data)
    {
        ContractModel.Instance.UpdateContract(data);
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(ContractEvent.ContractLevelReward);
    }

    public void ReqContractLevelReward(uint activityId, uint isSenior, uint level)
    {
        C_MSG_CONTRACT_LEVEL_REWARD c_MSG_CONTRACT_LEVEL_REWARD = new C_MSG_CONTRACT_LEVEL_REWARD();
        c_MSG_CONTRACT_LEVEL_REWARD.activityId = activityId;
        c_MSG_CONTRACT_LEVEL_REWARD.isSenior = isSenior;
        c_MSG_CONTRACT_LEVEL_REWARD.level = level;
        SendCmd((int)MessageCode.C_MSG_CONTRACT_LEVEL_REWARD, c_MSG_CONTRACT_LEVEL_REWARD);
    }
}
