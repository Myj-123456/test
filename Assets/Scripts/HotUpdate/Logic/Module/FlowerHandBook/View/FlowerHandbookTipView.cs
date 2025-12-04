using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;

public class FlowerHandbookTipView : BaseView
{
   private fun_CultivationManual_new.handbook_info_brandNew viewSkin;

    private int _exhitCellPage = 0;

    private BookType _bookType;

    private int maxIndex;

    private GList _exhibitList;

    private int tabType;
    private int shardType = 0;

    private StaticHandbook currData { get
        {
            return FlowerHandbookModel.Instance.GetSortedPageItemData(_exhitCellPage);
        } }


    private SeedCropVO expVo
    {
        get
        {
            return FlowerHandbookModel.Instance.GetCropVoByBook(currData.FlowerId);
        }
    }
   public FlowerHandbookTipView()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.handbook_info_brandNew.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        viewSkin = ui as fun_CultivationManual_new.handbook_info_brandNew;
        //StringUtil.SetBtnTab(viewSkin.btn_detail, Lang.GetValue("slang_19"));//详细
        viewSkin.txt_curlv.text = Lang.GetValue("text_book4");//当前属性
        viewSkin.txt_next.text = Lang.GetValue("slang_21");//收益详情

        viewSkin.txt_title_1.text = Lang.GetValue("slang_22");//茬数：
        viewSkin.txt_title_2.text = Lang.GetValue("slang_22");//产时：
        viewSkin.txt_title_3.text = Lang.GetValue("slang_24");//种子
        viewSkin.txt_title_4.text = Lang.GetValue("slang_25");//朵数：
        viewSkin.txt_title_5.text = Lang.GetValue("slang_26");//出售价格：

        StringUtil.SetBtnTab(viewSkin.btn_detail, Lang.GetValue("details_title"));

        //StringUtil.SetBtnTab(viewSkin.close_btn, Lang.GetValue("mail_button_return"));

        SetBg(viewSkin.fullScreenBg,"HandBookNew/ELIDA_xhshengji_bg02.jpg");

        StringUtil.SetBtnTab2(viewSkin.go_btn, Lang.GetValue("name_flower_from1"));
        StringUtil.SetBtnTab2(viewSkin.lv_btn, Lang.GetValue("slang_57"));



        //viewSkin.level_btn.title = Lang.GetValue("slang_57");
        StringUtil.SetBtnTab(viewSkin.share_btn, Lang.GetValue("text_breed36"));
        StringUtil.SetBtnTab(viewSkin.btn_info, Lang.GetValue("flower_info_16"));
        StringUtil.SetBtnTab(viewSkin.btn_vase, Lang.GetValue("flower_info_17"));

        tabType = -1;
        viewSkin.list_1.itemRenderer = ItemListRender;

        _exhibitList = viewSkin.exhibitList;
        _exhibitList.itemRenderer = RenderExhibit;
        _exhibitList.SetVirtual();

        viewSkin.leftBtn.onClick.Add(LeftHandle);
        viewSkin.rightBtn.onClick.Add(RightHandle);
        viewSkin.lv_btn.onClick.Add(LevelHandle);

        _exhibitList.scrollPane.onScrollEnd.Add(OnExhibitRolling);

        viewSkin.close_btn.onClick.Add(CloseView);

        viewSkin.btn_detail.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FlowerHandBookLvUpDetailWindow>(UIName.FlowerHandBookLvUpDetailWindow, currData.FlowerId);
        });

        viewSkin.btn_info.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FlowerInfoWindow>(UIName.FlowerInfoWindow,currData.FlowerId);
        });

        viewSkin.btn_vase.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FlowerIkeVaseWindow>(UIName.FlowerIkeVaseWindow, currData.FlowerId);
        });

        viewSkin.go_btn.onClick.Add(() =>
        {
            SceneManager.Instance.MoveToCultivateHourse(); //移动到培育屋
            Close();
            UIManager.Instance.ClosePanel(UIName.FlowerHandbookView);
            UIManager.Instance.ClosePanel(UIName.VaseRewardView);
        });

        viewSkin.go_get_btn.onClick.Add(() =>
        {
           
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition(currData.FlowerId);
            var count = StorageModel.Instance.GetItemCount(condition.ShareId);
            if(count < condition.ShardNum)
            {
                //var itemVo = ItemModel.Instance.GetItemById(condition.TaskId);
                //UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_87",Lang.GetValue(itemVo.Name)));
                return;
            }
            FlowerHandbookController.Instance.ReqExchangeFlowerCard((uint)currData.FlowerId);
            
        });

        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpgrade, UpdateLevelInfo);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpGradeBreakLv, UpdateLevelInfo);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.PlaySpine, PlayLevelUp);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.ExchangeFlowerCard, HandlerLockState);
    }

    private void OnExhibitRolling()
    {
        if(_exhitCellPage != _exhibitList.scrollPane.currentPageX)
        {
            _exhitCellPage = _exhibitList.scrollPane.currentPageX;
            HandlerLockState();
        }
        ChangeLeftOrRightBtn();
    }



    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        viewSkin.effect.anim.Play();
        object[] openParams = data as object[];
        _exhitCellPage = (int)openParams[0];
        _bookType = (BookType)openParams[1];
        tabType = 0;
        HandlerLockState();
        maxIndex = FlowerHandbookModel.Instance.GetDataLength() - 1;
        _exhibitList.numItems = maxIndex + 1;
        _exhibitList.scrollPane.SetCurrentPageX(_exhitCellPage, false);
        ChangeLeftOrRightBtn();
    }

    private void UpdateLevelInfo()
    {
        UpdateBaseShow();
        UpdateRelativeInfo();
    }


    private void UpdateRelativeInfo()
    {
        var seedCondition = FlowerHandbookModel.Instance.GetStaticSeedCondition(currData.FlowerId);

        int count = StorageModel.Instance.GetItemCount(seedCondition.SeedId);
        bool isMax = false;
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(currData.FlowerId);
        var plant = PlantModel.Instance.GetPlantCropConfigData(seedCondition.LevelMould + "#" + (exp == null ?1:exp.level));

        viewSkin.count_txt_1.text = plant.Frequency.ToString();
        viewSkin.times_txt_1.text = plant.SeedProp.ToString();
        
        viewSkin.time_txt_1.text = TextUtil.ChangeTimeShow((int)plant.Interval);
        viewSkin.onecount_txt_1.text = plant.CropCount.ToString();
        viewSkin.baodicount_txt_1.text = plant.Baodi.ToString();
        viewSkin.up_1.visible = viewSkin.up_2.visible = viewSkin.up_3.visible = viewSkin.up_4.visible = viewSkin.up_5.visible = false;
        viewSkin.lb_curExp.text = OrderModel.Instance.GetFlowerAdditionExp(currData.FlowerId).ToString();
        viewSkin.lb_curGold.text = OrderModel.Instance.GetFlowerAdditionGold(currData.FlowerId).ToString();
        if (exp != null)
        {
            isMax = PlantModel.Instance.GetPlantCropMax(seedCondition.LevelMould + "#" + (exp.level + 1));
        }
        else
        {
            isMax = false;
        }
        if (isMax)
        {
            viewSkin.lv_btn.enabled = false;
            viewSkin.cost_img.visible = false;
            viewSkin.costLab.visible = false;
           
            viewSkin.count_txt_1.text = viewSkin.times_txt_1.text = viewSkin.time_txt_1.text = viewSkin.onecount_txt_1.text = viewSkin.baodicount_txt_1.text = "Max";
        }
        else
        {
            viewSkin.cost_img.visible = true;
            viewSkin.costLab.visible = true;
            viewSkin.lv_btn.enabled = true;
            var nextPlant = PlantModel.Instance.GetPlantCropConfigData(seedCondition.LevelMould + "#" + (plant.Level + 1));
            viewSkin.lv_btn.grayed = !(count >= nextPlant.SeedCost && MyselfModel.Instance.gold >= plant.GoldCost);

            viewSkin.costLab.text = nextPlant.GoldCost.ToString();

            viewSkin.count_txt_2.text = nextPlant.Frequency.ToString();
            viewSkin.times_txt_2.text = nextPlant.SeedProp.ToString();
            viewSkin.time_txt_2.text = TextUtil.ChangeTimeShow(nextPlant.Interval);
            viewSkin.onecount_txt_1.text = nextPlant.CropCount.ToString();
            viewSkin.baodicount_txt_1.text = nextPlant.Baodi.ToString();

            if (plant.Frequency != nextPlant.Frequency)
            {
                viewSkin.up_1.visible = true;
            }
            if (plant.SeedProp != nextPlant.SeedProp)
            {
                viewSkin.up_3.visible = true;
            }

            if (plant.Interval != nextPlant.Interval)
            {
                viewSkin.up_2.visible = true;

            }
            if (plant.CropCount != nextPlant.CropCount)
            {
                viewSkin.up_4.visible = true;
            }
            if (plant.Baodi != nextPlant.Baodi)
            {
                viewSkin.up_5.visible = true;
            }

        }
    }

    private void UpdateBaseShow()
    {
        Module_item_defConfig staticItem = ItemModel.Instance.GetItemById(currData.FlowerId);
        StaticSeedCondition condition = FlowerHandbookModel.Instance.GetStaticSeedCondition(currData.FlowerId);
        viewSkin.name_txt.text = Lang.GetValue(staticItem.Name);
        


        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(currData.FlowerId);
        var plant = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null?1: exp.level));

        viewSkin.quality.selectedIndex = condition.FlowerQuality;

        viewSkin.nameBg.url = "HandBookNew/name_bg_color_" + condition.FlowerQuality + ".png";
        viewSkin.rareImg.url = "HandBookNew/rare_icon_" + condition.FlowerQuality + ".png";
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
       

    }

    private void HandlerLockState()
    {
        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[currData.FlowerId];
        bool unlock = !condition.AlreadyCulitivated;
        viewSkin.share_btn.visible = false;
        viewSkin.locked.selectedIndex = unlock ? 1 : 0;
        viewSkin.type.selectedIndex = 1;
        
        if (unlock)
        {
            viewSkin.sub_title.text = Lang.GetValue("text_book10");
            UpdateUnlockFormula();
            if (condition.UnlockAccessible)
            { 
                viewSkin.locked.selectedIndex = 1;
            }
            else
            {
                viewSkin.locked.selectedIndex = 2;
            }
        }
        else
        {
            viewSkin.sub_title.text = Lang.GetValue("up_level_info");
            viewSkin.locked.selectedIndex = 0;
            UpdateLevelInfo();
        }
    }

    private void UpdateUnlockFormula()
    {
        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[currData.FlowerId];
        viewSkin.list_1.numItems = condition.ItemIds.Count;
        UpdateBaseShow();
    }

    private void ItemListRender(int index,GObject item)
    {
        fun_CultivationManual_new.handbookDemandItem cell = item as fun_CultivationManual_new.handbookDemandItem;
        int flowerId = currData.FlowerId; ;
        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[currData.FlowerId];
        Module_item_defConfig staticItem = ItemModel.Instance.GetItemByEntityID(condition.ItemIds[index].EntityID);
        if(staticItem != null)
        {
            cell.visible = true;
            cell.Img.url = ImageDataModel.Instance.GetIconUrl(staticItem);
            cell.title_txt.text = Lang.GetValue(staticItem.Name);
            cell.name_txt.text = condition.ItemIds[index].Value + "";
        }
        else
        {
            cell.visible = false;
        }
    }

    private void RenderExhibit(int index,GObject item)
    {
        fun_CultivationManual_new.handbookFlowerExhibit ui = item as fun_CultivationManual_new.handbookFlowerExhibit;
        StaticHandbook aimed = FlowerHandbookModel.Instance.GetSortedPageItemData(index);
        Module_item_defConfig staticItem = ItemModel.Instance.GetItemById(aimed.FlowerId);
        ui.flowerImg.url = "";
        ui.flowerImg.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(staticItem);
        //ui.spine.url = "flowers/" + staticItem.ItemDefId;
        //ui.spine.loop = true;
        
        //ui.spine.animationName = "step_3_idle";
        //ui.flowerImg.visible = true;
        //ui.flowerImg.scaleY = 1f;
        if(_bookType == 0)
        {
            ui.potImg.url = "Cultivation/xianhuashengji_huaping.png";
            ui.flowerImg.y = 533;
            ui.potImg.y = 530;
            ui.potImg.SetSize(117f, 145f);
        }
        int flowerId = aimed.FlowerId;
       

    }

    private void LeftHandle()
    {
        _exhitCellPage--;
        _exhibitList.scrollPane.ScrollLeft(1, true);
        ChangeListPage();
    }

    private void RightHandle()
    {
        _exhitCellPage++;
        _exhibitList.scrollPane.ScrollRight(1, true);
        ChangeListPage();
    }

    private void ChangeListPage()
    {
        HandlerLockState();
        ChangeLeftOrRightBtn();
    }

    private void ChangeLeftOrRightBtn()
    {
        viewSkin.leftBtn.enabled = _exhitCellPage > 0;
        viewSkin.rightBtn.enabled = _exhitCellPage < maxIndex;
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.FlowerHandbookTipView);
    }

    private void LevelHandle()
    {
        
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(currData.FlowerId);
        var seedCondition = FlowerHandbookModel.Instance.GetStaticSeedCondition(currData.FlowerId);
        var cropVo = PlantModel.Instance.GetPlantCropConfigData(seedCondition.LevelMould + "#" + (exp == null?1: exp.level));

        var nextCropVo = PlantModel.Instance.GetPlantCropConfigData(seedCondition.LevelMould + "#" + ((exp == null ? 1 : exp.level) + 1));
        int cost = nextCropVo.GoldCost;
        int count = StorageModel.Instance.GetItemCount(seedCondition.SeedId);
       
        if (MyselfModel.Instance.gold < cost)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("prompt_message1", cost.ToString()));
            return;
        }
        if (count < nextCropVo.SeedCost)
        {
            var item = ItemModel.Instance.GetItemById(seedCondition.SeedId);
            UILogicUtils.ShowNotice(Lang.GetValue("guild.notEnough", Lang.GetValue(item.Name)));
            return;
        }
        FlowerHandbookController.Instance.ResSeedUpgrade((uint)currData.FlowerId);
        
        
        
    }

    private void GradeHandle()
    {
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(currData.FlowerId);
        var seedCondition = FlowerHandbookModel.Instance.GetStaticSeedCondition(currData.FlowerId);
        var nextGradeInfo = FLowerModel.Instance.GetFlowerGradeConfig(seedCondition.FlowerQuality, exp.gradeLv + 1);
        uint type = 1;
        if(shardType == 0)
        {
            var count = StorageModel.Instance.GetItemCount(seedCondition.ShareId);
            var ItemVo = ItemModel.Instance.GetItemById(seedCondition.ShareId);
            if(count < nextGradeInfo.GradeCost1)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.notEnough", Lang.GetValue(ItemVo.Name)));
                return;
            }
            type = 1;
        }
        else
        {
            var count = StorageModel.Instance.GetCommonShardNum();
            var ItemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.universalShardId);
            if (count < nextGradeInfo.GradeCost2)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guild.notEnough", Lang.GetValue(ItemVo.Name)));
                return;
            }
            type = 2;
        }
        FlowerHandbookController.Instance.ReqSeedUpGradeGrade((uint)currData.FlowerId, type);
    }

    private void PlayLevelUp()
    {
        if(viewSkin.spine.url == null || viewSkin.spine.url == "")
        {
            viewSkin.spine.url = "xianhuashengji";
            viewSkin.spine.loop = false;
            viewSkin.spine.forcePlay = true;
        }
        viewSkin.spine.animationName = "animation";
    }
}

