using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.card;
using Elida.Config;
using System;
using ADK;

public class ContractView : BaseView
{
   private fun_Recharge.contract_view view;
    private int activityId;
    private List<I_CONTRACT_TASK_VO> taskListDay;
    private List<I_CONTRACT_TASK_VO> taskListChallege;
    private List<Ft_contract_rewardConfig> listData;
    private S_MSG_CONTRACT_INFO contractData;
    private int type;
    private CountDownTimer timer;

    public ContractView(fun_Recharge.contract_view ui)
    {
        //packageName = "fun_Recharge";
        //// 设置委托
        //BindAllDelegate = fun_Contract.fun_ContractBinder.BindAll;
        //CreateInstanceDelegate = fun_Contract.contract_view.CreateInstance;
        view = ui;
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.taskList.itemRenderer = RenderTaskList;
        view.huadianBtn.onClick.Add(() =>
        {
            type = 1;
            view.show.selectedIndex = 0;
            UpdateData();
        });
        view.taskBtn.onClick.Add(() =>
        {
            type = 0;
            view.show.selectedIndex = 1;
            UpdateTaskList();
        });
        view.previewBtn.onClick.Add(() => {
            UIManager.Instance.OpenWindow<ContractRewardPreview>(UIName.ContractRewardPreview, activityId);
        });
        SetBg(view.buyLevelbg, "Common/common_two_tip_bg.png");
        view.addBtn.onClick.Add(() =>
        {
            view.contractBuyLevel.selectedIndex = 1;
        });
        view.buyLevelClose.onClick.Add(()=> 
        {
            view.contractBuyLevel.selectedIndex = 0;
        });
        view.btn_Opening.onClick.Add(() => 
        {
            UIManager.Instance.OpenWindow<ContractPayWindow>(UIName.ContractPayWindow);
            view.contractBuyLevel.selectedIndex = 0;
        });
        StringUtil.SetBtnTab(view.huadianBtn, Lang.GetValue("contract_title1"));
        StringUtil.SetBtnTab(view.taskBtn, Lang.GetValue("contract_title2"));
        StringUtil.SetBtnTab(view.exBtn, Lang.GetValue("Contract_exBtn"));
        view.tipLab1.text = Lang.GetValue("slang_56");
        view.tipLab2.text = Lang.GetValue("Contract_normalReward");
        view.tipLab3.text = Lang.GetValue("Contract_specialReward");


        EventManager.Instance.AddEventListener(ContractEvent.Contract, UpdateData);
        EventManager.Instance.AddEventListener(ContractEvent.ContractTaskReward, UpdateData);
    }

    public override void OnInit()
    {
        // base.OnInit();
        //view = ui as fun_Recharge.contract_view;
       

        //view.buy1_btn.onClick.Add(() =>
        //{
        //    var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT);
        //    RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        //});
        //view.buy2_btn.onClick.Add(() =>
        //{
        //    var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.CONTRACT_SUPER);
        //    RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        //});
        //view.buy_lv_btn.onClick.Add(() =>
        //{
        //    var info = RechargeModel.Instance.GetDiamondVo((int)E_DIAMOND_VALUE_TYPE.BUY_CONTRACT_LEVEL);
        //    RechargeController.Instance.ReqPlaceOrder(2, (uint)info.IndexId);
        //});
        
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        type = 1;
        activityId = DrawModel.Instance.GetActivityId(ActivityType.Contract);
        ContractController.Instance.ReqContractInfo((uint)activityId);
        UpdateTime();
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
    private void UpdateTime()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        var activityId = DrawModel.Instance.GetActivityId(ActivityType.Month_Draw);
        var activityInfo = DrawModel.Instance.GetGameEventInfo(activityId);
        var endTime = TimeUtil.GetNumericTime(activityInfo.WeixinEndTime) - ServerTime.Time;
        timer = new CountDownTimer(view.tipLab, (int)endTime, false);
        timer.prefixString = Lang.GetValue("text_card4");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            UIManager.Instance.ClosePanel(UIName.ContractView);
        };
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Recharge.contract_item;
        var info = listData[index];
        if(info == null)
        {
            info = listData[listData.Count - 1];
        }
        if (index == 0)
            cell.state.selectedIndex = 0;
        else if (index == listData.Count - 1)
            cell.state.selectedIndex = 2;
        else
            cell.state.selectedIndex = 1; 
        cell.lvLab.text = (index + 1).ToString();
        cell.reward1.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Recharge.item_com;
            var rewardInfo = info.CommonRewards[idx];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.numLab.text = rewardInfo.Value.ToString();
        };
        cell.reward1.numItems = info.CommonRewards.Length;
        cell.reward2.itemRenderer = (int idx, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Recharge.item_com;
            if(contractData.contract.seniorType == 2)
            {
                var rewardInfo = info.SupremeRewards[idx];
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
                rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                rewardCell.numLab.text = rewardInfo.Value.ToString();
            }
            else
            {
                var rewardInfo = info.AdvancedRewards[idx];
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
                rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                rewardCell.numLab.text = rewardInfo.Value.ToString();
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
        taskListDay = ContractModel.Instance.GetContractTaskData(contractData.activityId,1);
        taskListChallege = ContractModel.Instance.GetContractTaskData(contractData.activityId, 0);
        //view.taskList.numItems = taskList.Count;
        view.taskList.numItems = 2;
    }
    private I_CONTRACT_TASK_VO GetTaskItemData(int index,int idx)
    {
        if (index == 0)
            return taskListDay[idx];
        else 
            return taskListChallege[idx];
    }
    public void RenderTaskList(int index,GObject item)
    {
        var cell = item as fun_Recharge.taskListItem;
        if(index==0)
        {
            cell.list.numItems = taskListDay.Count;
            cell.titleLab.text = Lang.GetValue("Daily_task_17");
        }
        else
        {
            cell.titleLab.text = Lang.GetValue("Contract_challenge");
            cell.list.numItems = taskListChallege.Count;
        }
        cell.list.itemRenderer = (int idx, GObject taskItem) =>
        {
            var info = GetTaskItemData(index, idx);
            var taskInfo = ContractModel.Instance.GetContractTaskInfo((int)info.taskId);
            var taskCell = taskItem as fun_Recharge.task_item;
            taskCell.pro.max = info.needCnt;
            taskCell.pro.value = info.curCnt;
            taskCell.proLab.text =  info.curCnt + "/"+ info.needCnt;
            taskCell.status.selectedIndex = ContractModel.Instance.GetContrackTask(info);
            taskCell.tipLab.text= TaskModel.Instance.GetTaskDec(taskInfo.Description, taskInfo.TaskType, (int)info.needCnt, taskInfo.TypeParam, taskInfo.Ishistory);
            StringUtil.SetBtnTab(taskCell.getBtn, Lang.GetValue("slang_99"));
            StringUtil.SetBtnTab(taskCell.goBtn, Lang.GetValue("guide_button1"));
            var itemVo = ItemModel.Instance.GetItemById((int)BaseType.CONTRACT_EXP);
            taskCell.cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            taskCell.cell.numLab.text = taskInfo.ContractExp.ToString();
            UILogicUtils.SetItemShow(taskCell.cell, itemVo.ItemDefId);
            taskCell.getBtn.data = info;
            taskCell.getBtn.onClick.Add(GetTaskReward);
            //taskCell.get_btn.data = info;
            //cell.onClick.Add(GetTaskReward);
        };
    }
    private void GetTaskReward(EventContext context)
    {
        var info = (context.sender as GObject).data as I_CONTRACT_TASK_VO;
        ContractController.Instance.ReqContractTaskReward(contractData.activityId, info.pos);
    }
    public int GetCurLevel()
    {
        var level = (int)contractData.contract.exp / GlobalModel.Instance.module_profileConfig.contractLevelup;
        return level;
    }
    public override void OnHide()
    {
        //base.OnHide();
        // 其他关闭面板的逻辑
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }

}

