using System.Collections;
using System.Collections.Generic;
using System.Linq;
using protobuf.card;
using protobuf.messagecode;
using UnityEngine;

public class FairyFlowerController : BaseController<FairyFlowerController>
{
    protected override void InitListeners()
    {
        //��Ϣ
        AddNetListener<S_MSG_FLOWER_FAIRY_INFO>((int)MessageCode.S_MSG_FLOWER_FAIRY_INFO, FlowerFairyInfo);
        //��Լ������
        AddNetListener<S_MSG_FAIRY_CONTRACT_TASK_REWARD>((int)MessageCode.S_MSG_FAIRY_CONTRACT_TASK_REWARD, FairyContractTask);
        //��Լ�ȼ�����
        AddNetListener<S_MSG_FAIRY_CONTRACT_LEVEL_REWARD>((int)MessageCode.S_MSG_FAIRY_CONTRACT_LEVEL_REWARD, FairyContractLevel);
        //���ɲ�Ʒ����
        AddNetListener<S_MSG_FAIRY_FIGUIRE_UPGRADE>((int)MessageCode.S_MSG_FAIRY_FIGUIRE_UPGRADE, FairyFiguireUp);
        //ä�г鿨
        AddNetListener<S_MSG_FAIRY_BLIND_DRAW>((int)MessageCode.S_MSG_FAIRY_BLIND_DRAW, FairyBlindDraw);
        //��ǲ����
        AddNetListener<S_MSG_FAIRY_DISPATCH>((int)MessageCode.S_MSG_FAIRY_DISPATCH, FairyDispatch);
        //������ǲλ��
        AddNetListener<S_MSG_FAIRY_DISPATCH_UNLOCK_POS>((int)MessageCode.S_MSG_FAIRY_DISPATCH_UNLOCK_POS, FairyDispatchUnlock);
        //��ǲ����
        AddNetListener<S_MSG_FAIRY_DISPATCH_SPEED>((int)MessageCode.S_MSG_FAIRY_DISPATCH_SPEED, FairyDispatchSpeed);
        //��ǲ�ջ�
        AddNetListener<S_MSG_FAIRY_DISPATCH_HARVEST>((int)MessageCode.S_MSG_FAIRY_DISPATCH_HARVEST, FairyDispatchHarvest);
        //��������
        AddNetListener<S_MSG_FAIRY_HELP_APPLY>((int)MessageCode.S_MSG_FAIRY_HELP_APPLY, FairyHelpApply);
        //�Ҹ���������
        AddNetListener<S_MSG_FAIRY_HELP>((int)MessageCode.S_MSG_FAIRY_HELP, FairyHelp);
        //����������Ч
        AddNetListener<S_MSG_FAIRY_HELP_EFFECT>((int)MessageCode.S_MSG_FAIRY_HELP_EFFECT, FairyHelpEffect);
        //ä����Ϣ
        AddNetListener<S_MSG_FAIRY_BLIND_INFO>((int)MessageCode.S_MSG_FAIRY_BLIND_INFO, FairyBlindInfo);
    }
    //��Ϣ
    public void FlowerFairyInfo(S_MSG_FLOWER_FAIRY_INFO data)
    {
        FairyFlowerModel.Instance.help = data.help;
        FairyFlowerModel.Instance.fairyDispatchList = data.fairyDispatchList;
        FairyFlowerModel.Instance.figureList = data.figureList;
        FairyFlowerModel.Instance.fairContract = data.fairContract;
        FairyFlowerModel.Instance.fairContractTaskList = data.fairContractTaskList;
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FlowerFairyInfo);
    }
    public void ReqFlowerFairyInfo()
    {
        C_MSG_FLOWER_FAIRY_INFO c_MSG_FLOWER_FAIRY_INFO = new C_MSG_FLOWER_FAIRY_INFO();
        SendCmd((int)MessageCode.C_MSG_FLOWER_FAIRY_INFO, c_MSG_FLOWER_FAIRY_INFO);
    }
    //��Լ������
    public void FairyContractTask(S_MSG_FAIRY_CONTRACT_TASK_REWARD data)
    {
        FairyFlowerModel.Instance.UpdateContractTask(data.pos);
        FairyFlowerModel.Instance.fairContract.exp = data.exp;
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyContractTask);
    }

    public void ReqFairyContractTask(uint activityId,uint pos)
    {
        C_MSG_FAIRY_CONTRACT_TASK_REWARD c_MSG_FAIRY_CONTRACT_TASK_REWARD = new C_MSG_FAIRY_CONTRACT_TASK_REWARD();
        c_MSG_FAIRY_CONTRACT_TASK_REWARD.activityId = activityId;
        c_MSG_FAIRY_CONTRACT_TASK_REWARD.pos = pos;
        SendCmd((int)MessageCode.C_MSG_FAIRY_CONTRACT_TASK_REWARD, c_MSG_FAIRY_CONTRACT_TASK_REWARD);
    }
    //��Լ�ȼ�����
    public void FairyContractLevel(S_MSG_FAIRY_CONTRACT_LEVEL_REWARD data)
    {
        FairyFlowerModel.Instance.fairContract.normalRewardLevels = data.normalRewardLevels;
        FairyFlowerModel.Instance.fairContract.seniorRewardLvels = data.normalRewardLevels;
        var dropList = ItemModel.Instance.GetDropData(data.items);
        DropManager.ShowDrop(dropList);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyContractLevel);
    }

    public void ReqFairyContractLevel(uint activityId,uint isSenior,uint level)
    {
        C_MSG_FAIRY_CONTRACT_LEVEL_REWARD c_MSG_FAIRY_CONTRACT_LEVEL_REWARD = new C_MSG_FAIRY_CONTRACT_LEVEL_REWARD();
        c_MSG_FAIRY_CONTRACT_LEVEL_REWARD.activityId = activityId;
        c_MSG_FAIRY_CONTRACT_LEVEL_REWARD.isSenior = isSenior;
        c_MSG_FAIRY_CONTRACT_LEVEL_REWARD.level = level;
        SendCmd((int)MessageCode.C_MSG_FAIRY_CONTRACT_LEVEL_REWARD, c_MSG_FAIRY_CONTRACT_LEVEL_REWARD);
    }

    //���ɲ�Ʒ����
    public void FairyFiguireUp(S_MSG_FAIRY_FIGUIRE_UPGRADE data)
    {
        //FairyFlowerModel.Instance.UpdateFigure(data.figuire);
        //StorageModel.Instance.OddToStorageItems(data.costItems);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyFiguireUp);
    }
    public void ReqFairyFiguireUp(uint figureId)
    {
        C_MSG_FAIRY_FIGUIRE_UPGRADE c_MSG_FAIRY_FIGUIRE_UPGRADE = new C_MSG_FAIRY_FIGUIRE_UPGRADE();
        c_MSG_FAIRY_FIGUIRE_UPGRADE.figureId = figureId;
        SendCmd((int)MessageCode.C_MSG_FAIRY_FIGUIRE_UPGRADE, c_MSG_FAIRY_FIGUIRE_UPGRADE);
    }
    //ä�г鿨
    public void FairyBlindDraw(S_MSG_FAIRY_BLIND_DRAW data)
    {
        FairyFlowerModel.Instance.openPos.Add(data.pos);
        StorageModel.Instance.AddToStorage(data.items);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyBlindDraw);
    }

    public void ReqFairyBlindDraw(uint activityId,uint pos)
    {
        C_MSG_FAIRY_BLIND_DRAW c_MSG_FAIRY_BLIND_DRAW = new C_MSG_FAIRY_BLIND_DRAW();
        c_MSG_FAIRY_BLIND_DRAW.activityId = activityId;
        c_MSG_FAIRY_BLIND_DRAW.pos = pos;
        SendCmd((int)MessageCode.C_MSG_FAIRY_BLIND_DRAW, c_MSG_FAIRY_BLIND_DRAW);
    }
    //��ǲ����
    public void FairyDispatch(S_MSG_FAIRY_DISPATCH data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        FairyFlowerModel.Instance.UpdateDispatch(data.fairyDispatch);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyDispatch);
    }
    public void ReqFairyDispatch(uint pos,uint fairyId,uint cnt)
    {
        C_MSG_FAIRY_DISPATCH c_MSG_FAIRY_DISPATCH = new C_MSG_FAIRY_DISPATCH();
        c_MSG_FAIRY_DISPATCH.pos = pos;
        c_MSG_FAIRY_DISPATCH.fairyId = fairyId;
        c_MSG_FAIRY_DISPATCH.cnt = cnt;
        SendCmd((int)MessageCode.C_MSG_FAIRY_DISPATCH, c_MSG_FAIRY_DISPATCH);
    }
    //������ǲλ��
    public void FairyDispatchUnlock(S_MSG_FAIRY_DISPATCH_UNLOCK_POS data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        FairyFlowerModel.Instance.fairyDispatchList.Add(data.fairyDispatch);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyDispatchUnlock);
    }
    public void ReqFairyDispatchUnlock(uint pos)
    {
        C_MSG_FAIRY_DISPATCH_UNLOCK_POS c_MSG_FAIRY_DISPATCH_UNLOCK_POS = new C_MSG_FAIRY_DISPATCH_UNLOCK_POS();
        c_MSG_FAIRY_DISPATCH_UNLOCK_POS.pos = pos;
        SendCmd((int)MessageCode.C_MSG_FAIRY_DISPATCH_UNLOCK_POS, c_MSG_FAIRY_DISPATCH_UNLOCK_POS);
    }
    //��ǲ����
    public void FairyDispatchSpeed(S_MSG_FAIRY_DISPATCH_SPEED data)
    {
        StorageModel.Instance.OddToStorageItems(data.costItems);
        FairyFlowerModel.Instance.UpdateDispatch(data.fairyDispatch);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyDispatchSpeed);
    }

    public void ReqFairyDispatchSpeed(uint pos)
    {
        C_MSG_FAIRY_DISPATCH_SPEED c_MSG_FAIRY_DISPATCH_SPEED = new C_MSG_FAIRY_DISPATCH_SPEED();
        c_MSG_FAIRY_DISPATCH_SPEED.pos = pos;
        SendCmd((int)MessageCode.C_MSG_FAIRY_DISPATCH_SPEED, c_MSG_FAIRY_DISPATCH_SPEED);
    }
    //��ǲ�ջ�
    public void FairyDispatchHarvest(S_MSG_FAIRY_DISPATCH_HARVEST data)
    {
        StorageModel.Instance.AddToStorageItems(data.items);
        FairyFlowerModel.Instance.UpdateDispatch(data.fairyDispatch);
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyDispatchHarvest);
    }
    public void ReqFairyDispatchHarvest(uint pos)
    {
        C_MSG_FAIRY_DISPATCH_HARVEST c_MSG_FAIRY_DISPATCH_HARVEST = new C_MSG_FAIRY_DISPATCH_HARVEST();
        c_MSG_FAIRY_DISPATCH_HARVEST.pos = pos;
        SendCmd((int)MessageCode.C_MSG_FAIRY_DISPATCH_HARVEST, c_MSG_FAIRY_DISPATCH_HARVEST);
    }
    //��������
    public void FairyHelpApply(S_MSG_FAIRY_HELP_APPLY data)
    {
        FairyFlowerModel.Instance.help.status = data.status;
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyHelpApply);
    }
    public void ReqFairyHelpApply()
    {
        C_MSG_FAIRY_HELP_APPLY c_MSG_FAIRY_HELP_APPLY = new C_MSG_FAIRY_HELP_APPLY();
        SendCmd((int)MessageCode.C_MSG_FAIRY_HELP_APPLY, c_MSG_FAIRY_HELP_APPLY);
    }
    //�Ҹ���������
    public void FairyHelp(S_MSG_FAIRY_HELP data)
    {
        if(data.helpStatus == 0)
        {

        }
        else
        {

        }
    }

    public void ReqFairyHelp()
    {
        C_MSG_FAIRY_HELP c_MSG_FAIRY_HELP = new C_MSG_FAIRY_HELP();
        SendCmd((int)MessageCode.C_MSG_FAIRY_HELP, c_MSG_FAIRY_HELP);
    }
    //����������Ч
    public void FairyHelpEffect(S_MSG_FAIRY_HELP_EFFECT data)
    {
        FairyFlowerModel.Instance.help.status = data.status;
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyHelpEffect);
    }
    public void ReqFairyHelpEffect()
    {
        C_MSG_FAIRY_HELP_EFFECT c_MSG_FAIRY_HELP_EFFECT = new C_MSG_FAIRY_HELP_EFFECT();
        SendCmd((int)MessageCode.C_MSG_FAIRY_HELP_EFFECT, c_MSG_FAIRY_HELP_EFFECT);
    }
    //ä����Ϣ
    public void FairyBlindInfo(S_MSG_FAIRY_BLIND_INFO data)
    {
        if(data.openPos == null)
        {
            FairyFlowerModel.Instance.openPos = new List<uint>();
        }
        else
        {
            FairyFlowerModel.Instance.openPos = data.openPos.ToList();
        }
        EventManager.Instance.DispatchEvent(FairyFlowerEvent.FairyBlindInfo);
    }
    public void ReqFairyBlindInfo(uint activityId)
    {
        C_MSG_FAIRY_BLIND_INFO c_MSG_FAIRY_BLIND_INFO = new C_MSG_FAIRY_BLIND_INFO();
        c_MSG_FAIRY_BLIND_INFO.activityId = activityId;
        SendCmd((int)MessageCode.C_MSG_FAIRY_BLIND_INFO, c_MSG_FAIRY_BLIND_INFO);
    }
}
