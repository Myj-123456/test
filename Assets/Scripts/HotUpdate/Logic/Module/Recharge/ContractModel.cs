using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using protobuf.card;
using UnityEngine;

public class ContractModel : Singleton<ContractModel>
{
    public Dictionary<uint, S_MSG_CONTRACT_INFO> contractData = new Dictionary<uint, S_MSG_CONTRACT_INFO>();//合约信息

    private List<Ft_contract_rewardConfig> _contractList;
    private List<CommonRewardObject> _commonRewardObjects;
    private List<AdvancedRewardObject> _advanceRewardObjects;
    private List<SupremeRewardObject> _superRewardObjects;

    public List<Ft_contract_rewardConfig> contractList { get { 
            if(_contractList == null)
            {
                var contractRewardData = ConfigManager.Instance.GetConfig<Ft_contract_rewardConfigData>("ft_contract_rewardsConfig");
                _contractList = contractRewardData.DataList;
            }
            return _contractList;
        } }

    private Dictionary<int, Ft_contract_taskConfig> _contractTaskMap;
    public Dictionary<int, Ft_contract_taskConfig> contractTaskMap { get
        {
            if(_contractTaskMap == null)
            {
                var taskData = ConfigManager.Instance.GetConfig<Ft_contract_taskConfigData>("ft_contract_tasksConfig");
                _contractTaskMap = taskData.DataMap;
            }
            return _contractTaskMap;
        } }

    
    //更新合约任务信息
    public void UpdateContractTask(S_MSG_CONTRACT_TASK_REWARD data)
    {
        if (contractData.ContainsKey(data.activityId))
        {
            var taskData = GetContractTask(data.activityId,data.pos);
            taskData.awardStatus = 1;
            contractData[data.activityId].contract.exp = data.exp;
        }
    }
    //更新合约信息
    public void UpdateContract(S_MSG_CONTRACT_LEVEL_REWARD data)
    {
        if (contractData.ContainsKey(data.activityId))
        {
            contractData[data.activityId].contract.normalRewardLevels = data.normalRewardLevels;
            contractData[data.activityId].contract.seniorRewardLvels = data.seniorRewardLevels;
        }
    }
    //获取合约信息
    public S_MSG_CONTRACT_INFO GetContractData(uint activityId)
    {
        if (contractData.ContainsKey(activityId))
        {
            return contractData[activityId];
        }
        return null;
    }
    //获取合约任务信息
    public I_CONTRACT_TASK_VO GetContractTask(uint activityId,uint pos)
    {
        if (contractData.ContainsKey(activityId))
        {
            return contractData[activityId].contractTaskList.Find(value => value.pos == pos);
        }
        return null;
    }
    //获取合约列表
    public List<Ft_contract_rewardConfig> GetContractRewardList(int activityId)
    {
        return contractList.FindAll(value => value.ActivityId == activityId);
    }
    //获取合约任务信息
    public Ft_contract_taskConfig GetContractTaskInfo(int id)
    {
        if (contractTaskMap.ContainsKey(id))
        {
            return contractTaskMap[id];
        }
        return null;
    }
    /// <summary>
    /// 获取合约奖励合并后的列表
    /// </summary>
    /// <param name="activityId"></param>
    /// <returns></returns>
    public List<CommonRewardObject> GetPreviewCommonRewardList(int activityId)
    {
        if (_commonRewardObjects!=null)
            return _commonRewardObjects;
        _commonRewardObjects = new List<CommonRewardObject>();
        GetContractRewardList(activityId).ForEach(e =>
        {
            for(var i=0; i < e.CommonRewards.Length; i++)
            {
                var temp= _commonRewardObjects.Find(x=>x.EntityID == e.CommonRewards[i].EntityID);
                if (temp != null)
                    temp.Value += e.CommonRewards[i].Value;
                else
                    _commonRewardObjects.Add(e.CommonRewards[i]);
            }
        });
        _commonRewardObjects.Sort((a, b) =>
        {
            long aL = IDUtil.GetEntityId(a.EntityID).value;
            long bL = IDUtil.GetEntityId(b.EntityID).value;
            if (aL == (long)BaseType.CASH && bL != (long)BaseType.CASH)
                return -1;  // a在前
            else if (aL != (long)BaseType.CASH && bL == (long)BaseType.CASH)
                return 1;   // b在前
            else
                return 0;   // 保持原有顺序
        });
        return _commonRewardObjects;
    }
    /// <summary>
    /// 获取合约奖励合并后的列表
    /// </summary>
    /// <param name="activityId"></param>
    /// <returns></returns>
    public List<SupremeRewardObject> GetPreviewSuperRewardList(int activityId)
    {
        if (_superRewardObjects != null)
            return _superRewardObjects;
        _superRewardObjects = new List<SupremeRewardObject>();
        GetContractRewardList(activityId).ForEach(e =>
        {
            for (var i = 0; i < e.SupremeRewards.Length; i++)
            {
                var temp = _superRewardObjects.Find(x => x.EntityID == e.SupremeRewards[i].EntityID);
                if (temp != null)
                    temp.Value += e.SupremeRewards[i].Value;
                else
                    _superRewardObjects.Add(e.SupremeRewards[i]);
            }
        });
        //还需要加上购买后立即获得的部分
        var payData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT_SUPER);
        for(var i=0;i< payData.Items.Length;i++)
        {
            _superRewardObjects.Find(x => x.EntityID == payData.Items[i].EntityID).Value += payData.Items[i].Value; ;
        }
        _superRewardObjects.Sort((a, b) =>
        {
            long aL = IDUtil.GetEntityId(a.EntityID).value;
            long bL = IDUtil.GetEntityId(b.EntityID).value;
            if (aL == (long)BaseType.CASH && bL != (long)BaseType.CASH)
                return -1;  // a在前
            else if (aL != (long)BaseType.CASH && bL == (long)BaseType.CASH)
                return 1;   // b在前
            else
                return 0;   // 保持原有顺序
        });
        return _superRewardObjects;
    }
    /// <summary>
    /// 获取合约奖励合并后的列表
    /// </summary>
    /// <param name="activityId"></param>
    /// <returns></returns>
    public List<AdvancedRewardObject> GetPreviewAdvanceRewardList(int activityId)
    {
        if (_advanceRewardObjects != null)
            return _advanceRewardObjects;
        _advanceRewardObjects = new List<AdvancedRewardObject>();
        GetContractRewardList(activityId).ForEach(e =>
        {
            for (var i = 0; i < e.AdvancedRewards.Length; i++)
            {
                var temp = _advanceRewardObjects.Find(x => x.EntityID == e.AdvancedRewards[i].EntityID);
                if (temp != null)
                    temp.Value += e.AdvancedRewards[i].Value;
                else
                    _advanceRewardObjects.Add(e.AdvancedRewards[i]);
            }
        });
        //还需要加上购买后立即获得的部分
        var payData = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT);
        for (var i = 0; i < payData.Items.Length; i++)
        {
            _advanceRewardObjects.Find(x => x.EntityID == payData.Items[i].EntityID).Value += payData.Items[i].Value;
        }
        _advanceRewardObjects.Sort((a, b) =>
        {
            long aL = IDUtil.GetEntityId(a.EntityID).value;
            long bL = IDUtil.GetEntityId(b.EntityID).value;
            if (aL == (long)BaseType.CASH && bL != (long)BaseType.CASH)
                return -1;  // a在前
            else if (aL != (long)BaseType.CASH && bL == (long)BaseType.CASH)
                return 1;   // b在前
            else
                return 0;   // 保持原有顺序
        });
        return _advanceRewardObjects;
    }

    public List<I_CONTRACT_TASK_VO> GetContractTaskData(uint activityId, int isDay)
    {
        var listData = new List<I_CONTRACT_TASK_VO>();
        if (contractData.ContainsKey(activityId))
        {
            foreach (var value in contractData[activityId].contractTaskList)
            {
                var taskInfo = GetContractTaskInfo((int)value.taskId);
                if (taskInfo.IsDay == isDay)
                {
                    listData.Add(value);
                }
            }
            listData.Sort(ConstrackSort);
        }

        return listData;
    }
    private int ConstrackSort(I_CONTRACT_TASK_VO a, I_CONTRACT_TASK_VO b)
    {
        return GetContrackTask(a) - GetContrackTask(b);
    } 
    public int GetContrackTask(I_CONTRACT_TASK_VO taskData)
    {
        if (taskData.awardStatus == 1)
        {
            return 2;
        }
        else
        {
            if (taskData.curCnt >= taskData.needCnt)
            {
                return 0;
            }
            return 1;
        }
    }
    public int GetContrackTask(uint activityId,uint taskId)
    {
        if (contractData.ContainsKey(activityId))
        {
            var taskData = contractData[activityId].contractTaskList.Find(value => value.taskId == taskId);
            if(taskData.awardStatus == 1)
            {
                return 2;
            }
            else
            {
                if(taskData.curCnt >= taskData.needCnt)
                {
                    return 0;
                }
                return 1;
            }
        }
        return 1;
    }

    public bool GetTaskContractRed(ActivityType type)
    {
        var activityId = DrawModel.Instance.GetActivityId(type);
        var contractData = GetContractData((uint)activityId);
        if(contractData != null)
        {
            foreach (var value in contractData.contractTaskList)
            {
                if(value.needCnt <= value.curCnt && value.awardStatus == 0)
                {
                    return true;
                }
            }
        }
        var listData = GetContractRewardList(activityId);
        var lv = GetCurLevel(activityId);
        var len = lv > listData.Count ? lv + 1: listData.Count;
        for(var i = 0;i < len; i++)
        {
            if (i <= lv || (contractData.contract.seniorRewardLvels == null || Array.IndexOf(contractData.contract.seniorRewardLvels, (uint)i) == -1))
            {
                return false;
            }
        }
        return true;
    }

    public int GetCurLevel(int activityId)
    {
        var contractData = GetContractData((uint)activityId);
        var level = (int)contractData.contract.exp / GlobalModel.Instance.module_profileConfig.contractLevelup;
        return level;
    }
}

