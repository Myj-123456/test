using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.ikebana;
using ADK;
using Elida.Config;

public class VaseRewardView : BaseView
{
   private fun_CultivationManual_new.handbookVaseRewardView view;

    private StaticFlowerPoint configData;
    private I_VASE_REWARD_STATUS svrData;
    private int currentVaseIndex;
    private int currTabIndex;
    private int currVaseId;
    private List<StaticFlower> currFlowerListData;
    private string[] txtColorArr = new string[] { "#d567f5", "#52ade8", "#53b161", "#fe8686", "#f0ae1f", "#9294ff" };
    public VaseRewardView()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.handbookVaseRewardView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivationManual_new.handbookVaseRewardView;
        SetBg(view.bgImg, "HandBookNew/ELIDA_xhshengji_bg02.jpg");
        StringUtil.SetBtnTab(view.oneKeyBtn, Lang.GetValue("handBook_14"));
        StringUtil.SetBtnTab(view.completeBtn, Lang.GetValue("common_claim_button"));
        StringUtil.SetBtnTab(view.unlockBtn, Lang.GetValue("handBook_12"));
        view.unlockDescLab.text = Lang.GetValue("handBook_13");//可领取当前花瓶已解锁的奖励

        view.list.itemRenderer = FlowerItemRender;

        view.tabBtn_0.onClick.Add(() =>
        {
            ChangeTab(0);
        });

        view.tabBtn_1.onClick.Add(() =>
        {
            ChangeTab(1);
        });

        view.tabBtn_2.onClick.Add(() =>
        {
            ChangeTab(2);
        });

        view.btn_left.onClick.Add(() =>
        {
            currentVaseIndex--;
            if(currentVaseIndex < 0)
            {
                currentVaseIndex = IkeModel.Instance.vaseConfigList.Count - 1;
            }
            ChangeViewShow();
        });

        view.btn_right.onClick.Add(() =>
        {
            currentVaseIndex++;
            if (currentVaseIndex > IkeModel.Instance.vaseConfigList.Count - 1)
            {
                currentVaseIndex = 0;
            }
            ChangeViewShow();
        });

        view.unlockBtn.onClick.Add(ClickUnlockBtnHandler);
        view.oneKeyBtn.onClick.Add(ClickOneKeyBtnHandler);
        view.completeBtn.onClick.Add(ClickGetAllComReward);
        //view.close_btn.onClick.Add(CloseView);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseOnekeyReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseFlowerReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.VaseGatherReward, UpdateData);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpgrade, UpdataFlowerList);
    }

    public override void OnShown()
    {
        base.OnShown();
        view.effect.anim.Play();
        currVaseId = (int)data;
        currentVaseIndex = IkeModel.Instance.GetVaseListIndex(currVaseId);
        configData = IkeModel.Instance.vaseConfigList[currentVaseIndex];
        //if (FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)currVaseId))
        //{
        //    svrData = FlowerHandbookModel.Instance.vaseRewardInfo[(uint)currVaseId];
        //}
        //else
        //{
        //    svrData = null;
        //}
       
        currTabIndex = -1;
        UpdataVase();
        SetSlotLang();
        ChangeTab(0);
        // 其他打开面板的逻辑

    }

    private void UpdateData()
    {
        if (FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)currVaseId))
        {
            svrData = FlowerHandbookModel.Instance.vaseRewardInfo[(uint)currVaseId];
        }
        else
        {
            svrData = null;
        }
        UpdataVase();
        UpdataFlowerList();
    }

    private void ChangeViewShow()
    {
        configData = IkeModel.Instance.bookDatHome[currentVaseIndex];
        currVaseId = configData.VaseId;
        //if (FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)currVaseId))
        //{
        //    svrData = FlowerHandbookModel.Instance.vaseRewardInfo[(uint)currVaseId];
        //}
        //else
        //{
        //    svrData = null;
        //}
        currTabIndex = -1;
        UpdataVase();
        SetSlotLang();
        ChangeTab(0);
    }

    private void ChangeTab(int pageIndex)
    {
        if (currTabIndex == pageIndex) return;
        currTabIndex = pageIndex;
        view.pageStatus.selectedIndex = pageIndex;
        UpdataFlowerList();
    }


    private void UpdataVase()
    {
        Module_item_defConfig item = ItemModel.Instance.GetItemById(configData.VaseId);
        view.vase.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
        view.name_txt.text = Lang.GetValue(item.Name);
        view.nameBg.url = "HandBookNew/name_bg_color_" + configData.VaseQuality + ".png";
        var gatherReward = configData.GatherRewards[0];
        //view.completeBtn.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(gatherReward.EntityID);
        view.getNum.text = gatherReward.Value.ToString();
        bool unlock = IkeModel.Instance.IsUnlockVase(configData.VaseId);

        var unlockReward = configData.UnlockRewards[0];
        view.unlockBtn.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(unlockReward.EntityID);
        view.unlockBtn.valueLab.text = unlockReward.Value.ToString();
        if (unlock)
        {
            view.unlockBtn.data = configData.VaseId;
            view.unLockStatus.selectedIndex = 1;
        }
        else if(unlock && svrData != null)
        {
            view.unLockStatus.selectedIndex = 2;
        }
        else
        {
            view.unLockStatus.selectedIndex = 0;
        }

        int allComStatus = IkeModel.Instance.IsCanGetGathReward(configData.VaseId);
        view.completeStatus.selectedIndex = allComStatus;

        if (IkeModel.Instance.IsAllGetted(configData.VaseId))
        {
            view.oneKeyStatus.selectedIndex = 1;
        }
        else
        {
            if (IkeModel.Instance.IsCanGetVaseReward(configData.VaseId))
            {
                view.oneKeyBtn.enabled = true;
            }
            else
            {
                view.oneKeyBtn.enabled = false;
            }
            view.oneKeyStatus.selectedIndex = 0;
        }
        if (view.completeStatus.selectedIndex == 1)
        {
            view.completeBtn.data = configData.VaseId;
        }
    }

    private void UpdataFlowerList()
    {
        currFlowerListData = IkeModel.Instance.GetFlowerBySlot((currTabIndex + 1), configData.VaseId);
        view.list.numItems = currFlowerListData.Count;
    }

    private void SetSlotLang()
    {
        for (int i = 0; i < 3; i++)
        {
            var flowerData = IkeModel.Instance.GetFlowerBySlot((i + 1), configData.VaseId);
            int count = 0;
            foreach (var item in flowerData)
            {
                StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[item.FlowersDI];
                if (condition.UnlockAccessible)
                {
                    count++;
                }
            }
            if (i == 0)
            {
                view.tabBtn_0.GetChild("titleLab").text = Lang.GetValue("handBook_10", (i + 1).ToString(), count.ToString(), flowerData.Count.ToString());
            }
            else if (i == 1)
            {
                view.tabBtn_1.GetChild("titleLab").text = Lang.GetValue("handBook_10", (i + 1).ToString(), count.ToString(), flowerData.Count.ToString());
            }
            else
            {
                view.tabBtn_2.GetChild("titleLab").text = Lang.GetValue("handBook_10", (i + 1).ToString(), count.ToString(), flowerData.Count.ToString());
            }
        }
    }

    private void FlowerItemRender(int index,GObject item)
    {
        fun_CultivationManual_new.handbook_brandNew_item1 cell = item as fun_CultivationManual_new.handbook_brandNew_item1;
        var flowerData = currFlowerListData[index];
        StaticHandbook data = FlowerHandbookModel.Instance.GetBookConfigByFlowerId(flowerData.FlowersDI);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(data.FlowerId);
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(data.FlowerId);
        StaticSeedCondition condition = FlowerHandbookModel.Instance.GetStaticSeedCondition(data.FlowerId);
        var plantCrop = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null?1: exp.level));
       

        bool unlock = IkeModel.Instance.IsUnlockVase(configData.VaseId);
        if (condition.UnlockAccessible && !FlowerHandbookModel.Instance.IsGetted((uint)currVaseId,(uint)flowerData.FlowersDI) && unlock)
        {
            cell.rewardStatus.selectedIndex = 1;
            cell.rewardBtn.data = flowerData;
        }
        else
        {
            cell.rewardStatus.selectedIndex = 0;
        }

        object[] param = new object[] { data, itemData, exp, plantCrop, condition, index };
        cell.data = param;
        cell.img1.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemData);
        cell.img1.visible = true;
        //cell.img1.scaleY = 1;
        cell.name_txt.visible = true;

        int cardId = condition.TaskId;
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        
        cell.decLab.text = Lang.GetValue("rare_lab");
        Color lvColor = StringUtil.HexToColor(txtColorArr[condition.FlowerQuality - 1]);
        cell.decLab.strokeColor = lvColor;
        cell.name_txt.strokeColor = lvColor;
        //cell.process_txt.color = lvColor;
        //cell.noitem_txt.color = lvColor;
        //cell.lockLv_txt.color = lvColor;
        cell.style_img.url = "HandBookNew/style_icon_" + condition.StyleType + ".png";

        int count = StorageModel.Instance.GetItemCount(condition.SeedId);
        if (condition.UnlockAccessible)
        {
            cell.img1.grayed = false;
            if (condition.AlreadyCulitivated)
            {

                cell.statius.selectedIndex = 0;
                cell.seed_img.url = ImageDataModel.Instance.GetIconUrlByItemId(condition.SeedId);
                if (exp != null)
                {

                    cell.level_txt.text = (exp.level).ToString();

                    if (PlantModel.Instance.GetPlantCropMax(condition.LevelMould + "#" + (exp.level + 1)))
                    {
                        cell.level_up.visible = false;

                    }
                    else
                    {
                        var nextPlantCrop = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp.level + 1));
                        var haveCount = StorageModel.Instance.GetItemCount(condition.SeedId);
                        cell.seedPro.max = nextPlantCrop.SeedCost;
                        cell.seedPro.value = haveCount;


                        var leveUp = true;
                        leveUp = (count >= nextPlantCrop.SeedCost && MyselfModel.Instance.gold >= nextPlantCrop.GoldCost);
                        

                        cell.level_up.visible = leveUp;
                    }
                }
            }
            else
            {

                cell.statius.selectedIndex = 2;
                cell.noitem_txt.text = Lang.GetValue("text_book9");
                cell.haveLab.text = Lang.GetValue("Vip_store_txt5");
                cell.level_up.visible = false;
            }
        }
        else
        {
            cell.statius.selectedIndex = 1;
            cell.img1.grayed = true;
            cell.lockLv_txt.text = Lang.GetValue(data.Curtips);
        }
        cell.bg_1.url = "HandBookNew/bg_new_" + condition.FlowerQuality + ".png";
        cell.rewardBtn.onClick.Add(GetFlowerUnlockReward);
        cell.onClick.Add(OpenTipView);
    }

    private void OpenTipView(EventContext context)
    {
        object[] param = (context.sender as GComponent).data as object[];
        var flowerData = param[0] as StaticHandbook;
        FlowerHandbookModel.Instance.FilterBookData( 0, 0, "");
        int index = FlowerHandbookModel.Instance.GetDataIndex(flowerData.FlowerId);
        object[] obj = new object[] { index, BookType.FLOWER };
        UIManager.Instance.OpenPanel<FlowerHandbookTipView>(UIName.FlowerHandbookTipView, UILayer.SecondUI, obj);
    }

    private void ClickUnlockBtnHandler(EventContext context)
    {
        FlowerHandbookController.Instance.ReqVaseReward((uint)configData.VaseId);
    }

    private void ClickOneKeyBtnHandler()
    {
        FlowerHandbookController.Instance.ReqVaseOnekeyReward((uint)configData.VaseId);
    }

    private void GetFlowerUnlockReward(EventContext context)
    {
        context.StopPropagation();
        StaticFlower data = (context.sender as GComponent).data as StaticFlower;
        FlowerHandbookController.Instance.ReqVaseFlowerReward((uint)configData.VaseId, (uint)data.FlowersDI);

    }
    public void ClickGetAllComReward()
    {
        FlowerHandbookController.Instance.ReqVaseGatherReward((uint)configData.VaseId);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

