using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.card;
using Elida.Config;
using System;

public class ContractView : BaseView
{
   private fun_Contract.contract_view view;
    private int activityId;
    private List<I_CONTRACT_TASK_VO> taskList;
    private List<Ft_contract_rewardConfig> listData;
    private S_MSG_CONTRACT_INFO contractData;
    private int type;
   public ContractView()
    {
        packageName = "fun_Contract";
        // 设置委托
        BindAllDelegate = fun_Contract.fun_ContractBinder.BindAll;
        CreateInstanceDelegate = fun_Contract.contract_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Contract.contract_view;
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.task_list.itemRenderer = RenderTaskList;

        view.buy1_btn.onClick.Add(() =>
        {
            var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT);
            RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        });
        view.buy2_btn.onClick.Add(() =>
        {
            var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT_SUPER);
            RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        });
        view.buy_lv_btn.onClick.Add(() =>
        {
            var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.BUY_CONTRACT_LEVEL);
            RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        });
        view.day_btn.onClick.Add(() =>
        {
            type = 1;
            UpdateTaskList();
        });
        view.challenge_btn.onClick.Add(() =>
        {
            type = 0;
            UpdateTaskList();
        });
        EventManager.Instance.AddEventListener(ContractEvent.Contract, UpdateData);
        EventManager.Instance.AddEventListener(ContractEvent.ContractTaskReward, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        type = 1;
        activityId = DrawModel.Instance.GetActivityId(ActivityType.Contract);
        ContractController.Instance.ReqContractInfo((uint)activityId);
    }
    private void UpdateData()
    {
        listData = ContractModel.Instance.GetContractRewardList(activityId);
        contractData = ContractModel.Instance.GetContractData((uint)activityId);
        var lv = GetCurLevel();
        view.lvLab.text = lv.ToString();
        var curExp = (contractData.contract.exp % GlobalModel.Instance.module_profileConfig.contractLevelup);
        view.pro.max = GlobalModel.Instance.module_profileConfig.contractLevelup;
        view.pro.value = curExp;
        view.proLab.text = curExp + "/" + GlobalModel.Instance.module_profileConfig.contractLevelup;
        view.list.numItems = lv > listData.Count ? lv : listData.Count;
        UpdateTaskList();
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Contract.contract_item;
        var info = listData[index];
        if(info == null)
        {
            info = listData[listData.Count - 1];
        }
        cell.lvLab.text = (index + 1).ToString();
        cell.reward1.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Contract.reward_item1;
            var rewardInfo = info.CommonRewards[idx];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.countLab.text = rewardInfo.Value.ToString();
        };
        cell.reward1.numItems = info.CommonRewards.Length;
        cell.reward2.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Contract.reward_item1;
            if(contractData.contract.seniorType == 2)
            {
                var rewardInfo = info.SupremeRewards[idx];
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
                rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                rewardCell.countLab.text = rewardInfo.Value.ToString();
            }
            else
            {
                var rewardInfo = info.AdvancedRewards[idx];
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
                rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                rewardCell.countLab.text = rewardInfo.Value.ToString();
            }
            
        };
        cell.reward2.numItems = contractData.contract.seniorType == 2?info.AdvancedRewards.Length:info.SupremeRewards.Length;
        cell.get_btn1.data = (index + 1);
        cell.get_btn2.data = (index + 1);
        cell.get_btn1.onClick.Add(GetLevelReward1);
        cell.get_btn2.onClick.Add(GetLevelReward2);
    }
    private void GetLevelReward1(EventContext context)
    {
        var lv = (int)(context.sender as GObject).data;
        var info = listData[lv - 1];
        if (info == null)
        {
            info = listData[listData.Count - 1];
        }
        var level = GetCurLevel();
        if (level < lv || (contractData.contract.normalRewardLevels != null && Array.IndexOf(contractData.contract.normalRewardLevels, (uint)lv) != -1))
        {

        }
        else
        {
            ContractController.Instance.ReqContractLevelReward(contractData.activityId, 0, (uint)lv);
        }
        
    }
    private void GetLevelReward2(EventContext context)
    {
        if(contractData.contract.seniorType == 0)
        {
            return;
        }
        var lv = (int)(context.sender as GObject).data;
        var info = listData[lv - 1];
        if (info == null)
        {
            info = listData[listData.Count - 1];
        }
        var level = GetCurLevel();
        if (level < lv || (contractData.contract.seniorRewardLvels != null && Array.IndexOf(contractData.contract.seniorRewardLvels, (uint)lv) != -1))
        {

        }
        else
        {
            ContractController.Instance.ReqContractLevelReward(contractData.activityId, 1, (uint)lv);
        }
        
    }
    private void UpdateTaskList()
    {
        taskList = ContractModel.Instance.GetContractTaskData(contractData.activityId, type);
        view.task_list.numItems = taskList.Count;
    }
    public void RenderTaskList(int index,GObject item)
    {
        var cell = item as fun_Contract.task_item;
        var info = taskList[index];
        var taskInfo = ContractModel.Instance.GetContractTaskInfo((int)info.taskId);
        cell.list.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Contract.reward_item1;
            rewardCell.countLab.text = taskInfo.ContractExp.ToString();
        };
        cell.pro.max = info.needCnt;
        cell.pro.value = info.curCnt;
        cell.proLab.text = info.needCnt + "/" + info.curCnt;
        cell.list.numItems = 1;
        cell.status.selectedIndex = ContractModel.Instance.GetContrackTask(info);
        cell.get_btn.data = info;
        cell.onClick.Add(GetTaskReward);
    }
    private void GetTaskReward(EventContext context)
    {
        var info = (context.sender as GObject).data as I_CONTRACT_TASK_VO;
        ContractController.Instance.ReqContractTaskReward(info.taskId, info.pos);
    }
    public int GetCurLevel()
    {
        var level = (int)contractData.contract.exp / GlobalModel.Instance.module_profileConfig.contractLevelup;
        return level;
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        

    }

}

