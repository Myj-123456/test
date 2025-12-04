using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.card;
using UnityEngine;

public class ContractModel : Singleton<ContractModel>
{
    public Dictionary<uint, S_MSG_CONTRACT_INFO> contractData = new Dictionary<uint, S_MSG_CONTRACT_INFO>();//合约信息

    private List<Ft_contract_rewardConfig> _contractList;
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

    public List<I_CONTRACT_TASK_VO> GetContractTaskData(uint activityId, int type)
    {
        var listData = new List<I_CONTRACT_TASK_VO>();
        if (contractData.ContainsKey(activityId))
        {
            foreach (var value in contractData[activityId].contractTaskList)
            {
                var taskInfo = GetContractTaskInfo((int)value.taskId);
                if (taskInfo.TaskType == type)
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
}

