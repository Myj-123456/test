using ADK;
using Elida.Config;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractRewardPreview : BaseWindow
{
    private fun_Recharge.contractRewardPreview view;
    private List<Ft_contract_rewardConfig> rewardDataList;

    private List<CommonRewardObject> commonListData;
    private List<SupremeRewardObject> supremeRewardDataList;
    private List<AdvancedRewardObject> advancedRewardDataList;
    private int activiId = 0;
    int showType = 0;
    public ContractRewardPreview()
    {
        packageName = "fun_Recharge";
        // 设置委托
        BindAllDelegate = fun_Recharge.fun_RechargeBinder.BindAll;
        ClickBlankClose = true;
        CreateInstanceDelegate = fun_Recharge.contractRewardPreview.CreateInstance;     
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Recharge.contractRewardPreview;
        SetBg(view.bg, "Recharge/ELIDA_heyue_jiangliyulan_kuang.png");
        view.normalTitleLab.text = Lang.GetValue("Contract_commonTitle");
        view.gaojiBtn.titleLab1.text = Lang.GetValue("Contract_advanceTitle");
        view.gaojiBtn.titleLab2.text = Lang.GetValue("Contract_advanceTitle");
        view.zunxiangBtn.titleLab1.text = Lang.GetValue("Contract_superTitle");
        view.zunxiangBtn.titleLab2.text = Lang.GetValue("Contract_superTitle");
        StringUtil.SetBtnTab(view.buyBtn, Lang.GetValue("Contract_upReward"));
        view.buyBtn.onClick.Add(() => {
            UIManager.Instance.OpenWindow<ContractPayWindow>(UIName.ContractPayWindow);
        });

        //view.titleLab.text = Lang.GetValue("title_activity_3");
        //view.poorLab.text = Lang.GetValue("incomplete");

        //StringUtil.SetBtnTab(view.day_btn, Lang.GetValue("Daily_task_17"));
        //StringUtil.SetBtnTab(view.week_btn, Lang.GetValue("task_6"));

        //StringUtil.SetBtnTab3(view.day_btn, Lang.GetValue("Daily_task_17"));
        //StringUtil.SetBtnTab3(view.week_btn, Lang.GetValue("task_6"));

        //view.list.itemRenderer = ListRenderer;


        //view.anim.loop = true;
        //view.anim.url = "meirerenwu";
        //view.anim.animationName = "animation";
        //InitPro();

        //view.list.height = view.close_btn.y - view.day_btn.y - 146;

        //view.day_btn.onClick.Add(() =>
        //{
        //    if (taskTabType != 0)
        //    {
        //        taskTabType = 0;
        //        UpdateTask();
        //    }
        //});

        //view.week_btn.onClick.Add(() =>
        //{
        //    if (taskTabType != 1)
        //    {
        //        taskTabType = 1;
        //        UpdateTask();
        //    }
        //});
        //AddEventListener(TaskEvent.TaskProAreward, UpdateTask);
        //EventManager.Instance.AddEventListener(DailyTaskEvent.DailyTask, UpdateTask);
        //EventManager.Instance.AddEventListener(PlayerEvent.GameCrossDay, UpdateTask);
    }
    private void RenderList(int index, GObject item)
    {
        var rewardInfo = commonListData[index];
        var rewardCell = item as fun_Recharge.item_com;
        var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
        rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        rewardCell.numLab.text = rewardInfo.Value.ToString();
        UILogicUtils.SetItemShow(rewardCell, IDUtil.GetEntityValue(rewardInfo.EntityID));
    }
    private void RenderSuperList(int index, GObject item)
    {
        if(showType==1)
        {
            var rewardInfo = supremeRewardDataList[index];
            var rewardCell = item as fun_Recharge.item_com;
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.numLab.text = rewardInfo.Value.ToString();
            UILogicUtils.SetItemShow(rewardCell, IDUtil.GetEntityValue(rewardInfo.EntityID));
        }
        else
        {
            var rewardInfo = advancedRewardDataList[index];
            var rewardCell = item as fun_Recharge.item_com;
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.numLab.text = rewardInfo.Value.ToString();
            UILogicUtils.SetItemShow(rewardCell, IDUtil.GetEntityValue(rewardInfo.EntityID));
        }
    }
    private void InitReward()
    {
        //var dayProData = TaskModel.Instance.GetTaskProList(1).Find(x => x.Id == curIndex)!;
        //var rewardsData = dayProData.ProgressRewards;
        //view.tipLab.text = Lang.GetValue("Daily_task_pro", "#7d7056", "#28aa09", dayProData.ProgressNum + "");
        //view.list.itemRenderer = (int idx, GObject reward) =>
        //{
        //    var value = rewardsData[idx];
        //    var rewardItem = reward as fun_DailyTask.DailyTaskCell;

        //    UILogicUtils.SetItemShow(rewardItem, IDUtil.GetEntityValue(value.EntityID));
        //    rewardItem.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(value.EntityID);
        //    rewardItem.bg.url = "MyInfo/show_flower_bg3.png";
        //    var drop = new StorageItemVO();
        //    drop.itemDefId = IDUtil.GetEntityValue(value.EntityID);
        //    drop.count = 100;
        //};
        //view.list.numItems = rewardsData.Length;
    }
    public override void OnShown()
    {
        base.OnShown();
        activiId = (int)data;
        rewardDataList = ContractModel.Instance.GetContractRewardList(activiId);
        ////刷新显示
        //InitReward();
        var flowerVo = ItemModel.Instance.GetItemByEntityID(rewardDataList[19].AdvancedRewards[0].EntityID);
        view.spine1.loop = true;
        view.spine1.forcePlay = true;
        view.spine1.url = "flowers/" + flowerVo.ItemDefId;
        view.spine1.animationName = "step_" + 3 + "_idle";

        var flowerVo2 = ItemModel.Instance.GetItemByEntityID(rewardDataList[39].AdvancedRewards[0].EntityID);
        view.spine2.loop = true;
        view.spine2.forcePlay = true;
        view.spine2.url = "flowers/" + flowerVo2.ItemDefId;
        view.spine2.animationName = "step_" + 3 + "_idle";

        view.flowerLab1.text = Lang.GetValue(flowerVo.Name);
        view.flowerLab2.text=Lang.GetValue(flowerVo2.Name);

        commonListData = ContractModel.Instance.GetPreviewCommonRewardList(activiId);
        supremeRewardDataList = ContractModel.Instance.GetPreviewSuperRewardList(activiId);
        advancedRewardDataList = ContractModel.Instance.GetPreviewAdvanceRewardList(activiId);

        view.listright.itemRenderer = RenderSuperList;
        view.listright.numItems = advancedRewardDataList.Count;
        view.gaojiBtn.onClick.Add(() =>
        {
            showType = 0;
            view.show.selectedIndex = 0;
            view.listright.numItems = advancedRewardDataList.Count;
            
        });
        view.zunxiangBtn.onClick.Add(() =>
        {
            showType = 1;
            view.show.selectedIndex =1;
            view.listright.numItems = supremeRewardDataList.Count;
        });
        view.listleft.itemRenderer = RenderList;
        view.listleft.numItems = commonListData.Count;
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}
