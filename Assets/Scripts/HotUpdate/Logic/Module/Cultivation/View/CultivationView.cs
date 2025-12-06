using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityTimer;
using System;
using Elida.Config;
using DG.Tweening;

public class CultivationView : BaseView
{
    private fun_CultivateSeeds.cultivation_new_panel viewSkin;
    private GLoader3D animeContainer;
    //private fun_CultivateSeeds.btn_shop shopBtn;
    private common_New.greenPicBtn2 skipBtn;

    private List<fun_CultivateSeeds.cultivation_seed2> itemCostArr;
    private List<fun_CultivateSeeds.cultivation_need_seed> itemNeedArr;
    private List<StaticSeedCondition> currCultivationList;

    private List<GTween> teweenItems;

    private List<GImage> teweenTargetItems;

    private int currSelectFlower;
    private StaticSeedCondition cuurStaticSeedCondition;

    private float effectStartY;
    private float effectEndY;

    private string[] txtColorArr = new string[] { "#f45bfc", "#2c93e5", "#209323", "#fb6eaa", "#f5b535", "#b579f5" };

    public CultivationView()
    {
        packageName = "fun_CultivateSeeds";
        // 设置委托
        BindAllDelegate = fun_CultivateSeeds.fun_CultivateSeedsBinder.BindAll;
        CreateInstanceDelegate = fun_CultivateSeeds.cultivation_new_panel.CreateInstance;
        fairyBatching = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_CultivateSeeds.cultivation_new_panel;

        SetBg(viewSkin.bg,"Cultivation/ELIDA_peiyu_bg.jpg");
        animeContainer = new GLoader3D();
        animeContainer.autoSize = true;
        viewSkin.AddChild(animeContainer);

        //succulentRootV = new SucculentRootView(viewSkin.succulent);
        StringUtil.SetBtnTab(viewSkin.close_btn, Lang.GetValue("mail_button_return"));
        StringUtil.SetBtnTab(viewSkin.backBtn, Lang.GetValue("mail_button_return"));
        StringUtil.SetBtnTab(viewSkin.go_plant, Lang.GetValue("cultivation_2"));
        StringUtil.SetBtnTab(viewSkin.share_btn, Lang.GetValue("text_breed36"));

        viewSkin.nullTip.text = Lang.GetValue("text_breed30");//暂无新花解锁…
        //viewSkin.from_txt.text = Lang.GetValue("text_breed31");//通过培育商店/完成订单，可获得培育道具！
        //viewSkin.share_txt.text = Lang.GetValue("text_breed33");//通过求助可减少培育等待时间！
        viewSkin.completeLab.text = Lang.GetValue("cultivation_3");
        viewSkin.tip.text = Lang.GetValue("cultivation_4");

        //viewSkin.succulLab1.text = Lang.GetValue("succulentType");
        //viewSkin.succulLab2.text = Lang.GetValue("flower_rack");
        //viewSkin.flowerLab1.text = Lang.GetValue("name_flower_from1");
        //viewSkin.flowerLab2.text = Lang.GetValue("name_tab13");

        StringUtil.SetBtnTab(viewSkin.btn_video, Lang.GetValue("flower_order_05"));
        //StringUtil.SetBtnTab(viewSkin.img_video, Lang.GetValue("flower_order_05"));
        //viewSkin.bg.url = "Cultivation/peiyuhuatai_BG.png";

        StringUtil.SetBtnTab(viewSkin.shop_btn, Lang.GetValue("cultivate_shop_04"));
        //StringUtil.SetBtnTab(viewSkin.rareBtn, Lang.GetValue("rare_24"));
        skipBtn = viewSkin.skip_btn as common_New.greenPicBtn2;
        StringUtil.SetBtnUrl(skipBtn, ImageDataModel.CASH_ICON_URL);
        viewSkin.tweenCom.flower.itemList.itemRenderer = ItemRender;
        viewSkin.tweenCom.flower.itemList.onClickItem.Add(OnItemClick);
        viewSkin.tweenCom.flower.itemList.scrollPane.onScroll.Add(ChangeLeftOrRightBtn);
        //viewSkin.back_btn.onClick.Add(OnBackClick);
        StringUtil.SetBtnTab2(viewSkin.cultivation_btn, Lang.GetValue("name_flower_from1"));//开始培育

        viewSkin.cultivation_btn.onClick.Add(OnCultivationClick);
        StringUtil.SetBtnTab(viewSkin.plant_btn, Lang.GetValue("text_breed35"));//收获
        viewSkin.video_txt.text = Lang.GetValue("text_breed39");//观看视频可减半培育等待时间
        viewSkin.plant_btn.onClick.Add(OnHarvestClick);

        skipBtn.onClick.Add(OnSkipClick);

        viewSkin.shop_btn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.RandomShop, true))
            {
                return;
            }
            UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView,UILayer.UI,0);
        });

        //viewSkin.btn_video.enabled = false;
        //viewSkin.img_video.enabled = false;
        //viewSkin.share_info.visible = false;
        //viewSkin.share_btn.visible = false;
        //viewSkin.n139.visible = false;

        effectEndY = viewSkin.effect_img.y;
        effectStartY = viewSkin.effect_img.y - 100;

        //StringUtil.SetBtnTab(viewSkin.share_btn, Lang.GetValue("text_breed36"));//分享

        itemCostArr = new List<fun_CultivateSeeds.cultivation_seed2>();
        itemCostArr.Add(viewSkin.need_item_1);
        itemCostArr.Add(viewSkin.need_item_2);
        itemCostArr.Add(viewSkin.need_item_3);
        itemCostArr.Add(viewSkin.need_item_4);
        itemNeedArr = new List<fun_CultivateSeeds.cultivation_need_seed>();
        //itemNeedArr.Add(viewSkin.need1);
        //itemNeedArr.Add(viewSkin.need2); 
        //itemNeedArr.Add(viewSkin.need3);

        foreach (fun_CultivateSeeds.cultivation_seed2 value in itemCostArr)
        {
            value.costBtn.onClick.Add(OnCostItemClick);
            //value.Img.draggable = true;
            value.Img.onClick.Add(OnImageTouchEnd);
        }

        viewSkin.backBtn.onClick.Add(() =>
        {
            UpdateData();
        });

        viewSkin.go_plant.onClick.Add(() =>
        {
            UIManager.Instance.ClosePanel(UIName.CultivationView);
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
            SceneManager.Instance.MoveToPantFlower(() =>
            {
                //CheckGuide11();
                if (GuideModel.Instance.IsGuiding)
                {
                    GuideController.Instance.NextGuide();
                }
            });
        });

        viewSkin.leftBtn.onClick.Add(LeftHandle);
        viewSkin.rightBtn.onClick.Add(RightHandle);

        AddListerEvent();
        viewSkin.spine1.url = "peiyuwc";
        viewSkin.spine1.forcePlay = true;
        viewSkin.spine1.loop = true;
        viewSkin.spine1.animationName = "idle";

        viewSkin.question_btn.onClick.Add(() =>
        {
            //UIManager.Instance.OpenWindow<>(UIName.HelpWindow,)
        });

        //viewSkin.share_btn.onClick.Add(() =>
        //{
        //    CultivationController.Instance.ReqCultivateHelp();
        //});

        viewSkin.btn_video.onClick.Add(() =>
        {
            CultivationController.Instance.ReqCultivateVideo();
        });
        viewSkin.share_btn.onClick.Add(() =>
        {
            ShareController.Instance.ReqShareFlowerReward();
        });
    }

    private void AddListerEvent()
    {
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationRepair, UpdateCostData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationPlant, UpdateData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationHarvest, UpdateHarvestData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationSpeed, UpdateData);
        EventManager.Instance.AddEventListener(CultivationShopEvent.ReqCultivateBuy, UpdateCostData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivateHelp, UpdateData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivateVideo, UpdateData);

        EventManager.Instance.AddEventListener(ShareEvent.ShareFlowerReward, UpdateDateShare);
    }
    private void UpdateDateShare()
    {
        viewSkin.share_btn.visible = false;
    }
    private void ItemRender(int index, GObject item)
    {
        fun_CultivateSeeds.cultivation_seed cell = item as fun_CultivateSeeds.cultivation_seed;
        StaticSeedCondition staticSeedCondition = currCultivationList[index];
        cell.data = staticSeedCondition;
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(staticSeedCondition.FlowerId);
        if(itemData != null)
        {
            cell.pic.url = ImageDataModel.Instance.GetFlowerStatusUrl(staticSeedCondition.FlowerId, 2);
            cell.name_txt.text = Lang.GetValue(itemData.Name);
        }
        else
        {
            return;
        }
        //cell.pic.url = ImageDataModel.Instance.GetIconUrlByItemId(staticSeedCondition.FlowerId);
        
    }

    private void OnItemClick(EventContext context)
    {
        fun_CultivateSeeds.cultivation_seed cell = context.data as fun_CultivateSeeds.cultivation_seed;
        StaticSeedCondition staticSeedCondition = cell.data as StaticSeedCondition;
        cuurStaticSeedCondition = staticSeedCondition;
        currSelectFlower = staticSeedCondition.FlowerId;
        //Ft_plant_cropConfig plant = PlantModel.Instance.GetPlantCropConfigData(currSelectFlower);
        viewSkin.effect_img.y = effectStartY;
        viewSkin.effect_img.url = ImageDataModel.Instance.GetIconUrlByItemId(staticSeedCondition.SeedId);
        CloseTween();
        for (int i = 0; i < staticSeedCondition.ItemIds.Count; i++)
        {
            UpdateCost(itemCostArr[i], staticSeedCondition.ItemIds[i]);
        }
        viewSkin.cultivation_btn.enabled = false;
        
        DOTween.Sequence().Append(DOTween.To(() => viewSkin.effect_img.y, x => viewSkin.effect_img.y = x, effectEndY, 0.5f).SetEase(Ease.OutCubic))
            .Append(DOTween.To(() => viewSkin.effect_img.alpha, x => viewSkin.effect_img.alpha = x, 0f, 0.25f).SetEase(Ease.OutCubic)).OnComplete(() =>
            {
                viewSkin.effect_img.alpha = 1;
                viewSkin.effect_img.url = "";
                viewSkin.flower_name.text = "";
                
                //viewSkin.form.visible = false;
                viewSkin.flower_img.grayed = false;
                UpdateFlowerImg(currSelectFlower, 0,true);
                viewSkin.status.selectedIndex = 2;


            }).Play();
    }

    private void UpdateHarvestData()
    {
        viewSkin.status.selectedIndex = 7;
        viewSkin.share_btn.visible = true;
        //UpdateData();
    }

    private void UpdateCostData()
    {
        for (int i = 0; i < cuurStaticSeedCondition.ItemIds.Count; i++)
        {
            UpdateCost(itemCostArr[i], cuurStaticSeedCondition.ItemIds[i], false);
        }
    }

    private void UpdateData()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if (CultivationModel.Instance.flowerId != 0 && CultivationModel.Instance.harvestTime != 0)
        {
            //viewSkin.status.selectedIndex = 3;
            UpdateCultivationLeft();
            UpdateTimerInfo(true);
        }
        else
        {
            SeleteList();
        }
    }

    private void UpdateFlowerImg(int flowerId, int status,bool isPlayGrow)
    {
        Module_item_defConfig itemVo = ItemModel.Instance.GetItemById(flowerId);
        if (itemVo != null)
        {
            long avatarId = flowerId;
            if (itemVo.Alter_avatar != 0)
            {
                avatarId = itemVo.Alter_avatar;
            }
            viewSkin.spine.url = "flowers/" + itemVo.ItemDefId;
            viewSkin.spine.forcePlay = true;
            if (isPlayGrow)
            {
                viewSkin.spine.Complete = null;
                viewSkin.spine.loop = false;
                viewSkin.spine.animationName = "step_" + (status + 1) + "_grow";
                viewSkin.spine.Complete = OnAnimationEventHandler;
            }
            else
            {
                viewSkin.spine.loop = true;
                if (viewSkin.spine.animationName != "step_" + (status + 1) + "_idle")
                {
                    viewSkin.spine.animationName = "step_" + (status + 1) + "_idle";
                }
            }
            //if (status == 2)
            //{
            //    //viewSkin.flower_img.SetScale(0.7f, 0.7f);
            //    viewSkin.flower_img.visible = true;
            //    viewSkin.flower_img1.visible = false;
            //    viewSkin.flower_img.url = ImageDataModel.Instance.GetFlowerStatusUrl(flowerId, status);
            //}
            //else
            //{
            //    //viewSkin.flower_img.SetScale(1f, 1f);
            //    viewSkin.flower_img.visible = false;
            //    viewSkin.flower_img1.visible = true;
            //    viewSkin.flower_img1.url = ImageDataModel.Instance.GetFlowerStatusUrl(flowerId, status);
            //}
            //viewSkin.cultivateType.selectedIndex = ItemModel.Instance.IsSucculent(itemVo) ? 1 : 0;
        }
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "step_1_grow")
        {
            viewSkin.spine.loop = true;
            viewSkin.spine.animationName = "step_1_idle";
        }else if(name == "step_2_grow")
        {
            viewSkin.spine.loop = true;
            viewSkin.spine.animationName = "step_2_idle";
        }
        else if (name == "step_3_grow")
        {
            viewSkin.spine.loop = true;
            viewSkin.spine.animationName = "step_3_idle";
        }
        viewSkin.spine.Complete = null;
    }

    //private void UpdateNeed(fun_CultivateSeeds.cultivation_need_seed cell, ItemIdObject data)
    //{
    //    cell.status.selectedIndex = 0;
    //    string entityId = data.EntityID;
    //    var itemData = ItemModel.Instance.GetItemByEntityID(entityId);
    //    cell.needLab.text = Lang.GetValue("cultivation_1", Lang.GetValue(itemData.Name));

    //}

    private bool UpdateCost(fun_CultivateSeeds.cultivation_seed2 cell, ItemIdObject data, bool isInit = true)
    {
        //common_New.greenPicBtn2 costBtn = cell.cost_btn as common_New.greenPicBtn2;
        string entityId = data.EntityID;
        int count = data.Value;
        if (isInit)
        {
            cell.status.selectedIndex = 0;
        }
        //cell.buffImg.visible = false;
        cell.Img.url = ImageDataModel.Instance.GetIconUrlByEntityId(entityId);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(entityId);
        cell.title_txt.text = Lang.GetValue(itemData.Name);
        Module_fertilizerConfig costData = CultivationModel.Instance.GetFertilizerConfigById(entityId);
        int has = 0;
        //cell.costBtn.enabled = true;
        if (StorageModel.Instance.GetItemById(itemData.ItemDefId) != null)
        {
            has = StorageModel.Instance.GetItemById(itemData.ItemDefId).count;
        }
        cell.costBtn.visible = has < count;
        if (has >= count)
        {
            //StringUtil.SetBtnTab(costBtn, "");
            cell.count_txt.text = has + "/" + count;
            cell.Img.touchable = true;
        }
        else
        {
            //StringUtil.SetBtnTab(costBtn, "x" + (costData.QuickBuyCost * (count - has)));
            cell.count_txt.text = "[color=#f3c716]" + has + "[/color]" + "/" + count;
            cell.Img.touchable = false;
        }
        object[] obj = new object[] { itemData, has, count, costData.QuickBuyCost };
        cell.Img.data = obj;
        return has >= count;

    }

    private int curPageX { get { return viewSkin.tweenCom.flower.itemList.scrollPane.currentPageX; } }

    private void ChangeLeftOrRightBtn()
    {
        viewSkin.leftBtn.enabled = curPageX > 0;
        viewSkin.rightBtn.enabled = !viewSkin.tweenCom.flower.itemList.scrollPane.isRightMost;
    }


    public override void OnShown()
    {
        base.OnShown();
        if (CultivationModel.Instance.flowerId != 0 && CultivationModel.Instance.harvestTime != 0)
        {
            UpdateCultivationLeft();
            UpdateTimerInfo(false);
        }
        else
        {
            SeleteList();
        }
    }

    private void UpdateCultivationLeft()
    {
        if (CultivationModel.Instance.flowerId > 0)
        {
            //UpdateFlowerImg(CultivationModel.Instance.flowerId, 1,false);
            StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[CultivationModel.Instance.flowerId];
            viewSkin.nameBg.url = "Cultivation/name_bg_" + condition.FlowerQuality.ToString() + ".png";
            viewSkin.flower_name.text = Lang.GetValue(ItemModel.Instance.GetItemById(CultivationModel.Instance.flowerId).Name);
            viewSkin.flower_name.strokeColor = StringUtil.HexToColor(txtColorArr[condition.FlowerQuality - 1]);
            //viewSkin.decLab.text = Lang.GetValue(condition.FlowerLanguage);
        }
        viewSkin.plant_btn.visible = false;

    }

    private int leftTime;
    private CountDownTimer timer;
    private void UpdateTimerInfo(bool isPlayGrow)
    {
        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[CultivationModel.Instance.flowerId];
        if (condition != null)
        {
            leftTime = CultivationModel.Instance.harvestTime - (int)ServerTime.Time;
            if (leftTime <= 0)
            {
                viewSkin.process.max = 100;
                viewSkin.process.value = 0;
                viewSkin.time_txt.text = "";
                //viewSkin.share_btn.visible = viewSkin.share_info.visible = false;
                viewSkin.process.visible = skipBtn.visible = false;
                viewSkin.plant_btn.visible = true;
                UpdateFlowerImg(CultivationModel.Instance.flowerId, 2, isPlayGrow);
                viewSkin.status.selectedIndex = 6;
            }
            else
            {
                if (isPlayGrow && viewSkin.status.selectedIndex != 3)
                {
                    UpdateFlowerImg(CultivationModel.Instance.flowerId, 1, true);
                }
                else
                {
                    UpdateFlowerImg(CultivationModel.Instance.flowerId, 1, false);
                }
                
                viewSkin.status.selectedIndex = 3;
                float cost = Mathf.Ceil(leftTime / CultivationModel.Instance.costMinTime / 60) * CultivationModel.Instance.costMinRate;
                StringUtil.SetBtnTab(skipBtn, "x" + cost);
                viewSkin.process.visible = skipBtn.visible = true;
                viewSkin.process.max = 100;
                int time = CultivationModel.Instance.harvestTime - (int)ServerTime.Time;
                viewSkin.process.value = (float)time / condition.WaitingTime * 100;
                if (timer == null)
                {
                    timer = new CountDownTimer(viewSkin.time_txt, leftTime);
                    timer.UpdateCallBacker = () =>
                    {
                        int time = CultivationModel.Instance.harvestTime - (int)ServerTime.Time;
                        float cost = Mathf.Ceil(time / CultivationModel.Instance.costMinTime / 60) * CultivationModel.Instance.costMinRate;
                        StringUtil.SetBtnTab(skipBtn, "x" + cost);
                        float value = (float)time / condition.WaitingTime * 100;
                        viewSkin.process.value = value;
                    };
                    timer.CompleteCallBacker = () =>
                    {
                        timer.Clear();
                        timer = null;
                        UpdateData();
                        if(GuideModel.Instance.IsGuiding && GuideModel.Instance.curGuideStep == 13)
                        {
                            GuideController.Instance.NextGuide();
                        }
                    };
                }
                UpdateHelpCount();
                viewSkin.videoGrp.visible = CultivationModel.Instance.videoTime == 0;
            }
        }
    }

    private void UpdateHelpCount()
    {
        var count = CultivationModel.Instance.helpMaxCount - CultivationModel.Instance.helpCnt;
        if (count < 0) count = 0;
        //StringUtil.SetBtnTab(viewSkin.share_btn, Lang.GetValue("text_breed3") + count + "/" + CultivationModel.Instance.helpMaxCount);//求助
        //viewSkin.share_btn.enabled = CultivationModel.Instance.helpMaxCount > CultivationModel.Instance.helpCnt;
    }

    private void SeleteList()
    {
        //viewSkin.status.selectedIndex = 1;
        currCultivationList = CultivationModel.Instance.GetNoCultivationList();
        viewSkin.tweenCom.flower.itemList.numItems = currCultivationList.Count;
        viewSkin.status.selectedIndex = currCultivationList.Count == 0 ? 0 : 1;
        viewSkin.spine.url = "";
        viewSkin.flower_img.url = "";
        viewSkin.flower_img1.url = "";
        //viewSkin.no_img.visible = viewSkin.no_item.visible = currCultivationList.Count == 0;
        StartCoroutine(NextFrameAction());
        PlayTween();


    }

    public void PlayTween()
    {
        if (viewSkin.status.selectedIndex == 1)
        {
            viewSkin.touchable = false;
            viewSkin.tweenCom.left.Play(() =>
            {
                viewSkin.touchable = true;
                ShowTargetWeakGuide();
            });
            viewSkin.tweenCom.flower.open.Play();
        }
    }

    /// <summary>
    /// 检测弱引导
    /// </summary>
    /// <returns></returns>
    private void ShowTargetWeakGuide()
    {
        if (GuideModel.Instance.IsCancelGuide) return;
        if (viewSkin.tweenCom.flower.itemList.numItems <= 0) return;
        var taskData = TaskModel.Instance.mainTask;
        if (taskData != null)
        {
            var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
            if (taskInfo != null && taskInfo.TaskType == 24)//成功培育XX花
            {
                var flowerId = taskInfo.TypeParam;
                if (flowerId <= 0)//不存在
                {
                    return;
                }
                var list_flowerInd = flowerId <= 0 ? 0 : currCultivationList.FindIndex(0, (v => { return v.FlowerId == flowerId; }));
                if (list_flowerInd >= 0)
                {
                    viewSkin.tweenCom.flower.itemList.ScrollToView(list_flowerInd);
                    int index = viewSkin.tweenCom.flower.itemList.ItemIndexToChildIndex(list_flowerInd);
                    var target = viewSkin.tweenCom.flower.itemList.GetChildAt(index);
                    GuideController.Instance.ShowTargetWeakGuide(target, Vector2.zero);
                }
            }
        }
    }

    public void CloseTween()
    {
        if (viewSkin.status.selectedIndex == 1)
        {
            viewSkin.touchable = false;
            viewSkin.tweenCom.right.Play(() =>
            {
                viewSkin.touchable = true;
                viewSkin.status.selectedIndex = 2;
            });
            viewSkin.tweenCom.flower.close.Play();
        }
    }

    IEnumerator NextFrameAction()
    {
        yield return new WaitForEndOfFrame();
        ChangeLeftOrRightBtn();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void OnBackClick()
    {
        if (animeContainer != null && animeContainer.visible)
        {
            animeContainer.visible = false;
        }
        viewSkin.status.selectedIndex = 1;

    }

    private void OnCultivationClick()
    {
        if (currSelectFlower == 0)
        {
            return;
        }
        CultivationController.Instance.ResCultivationPlant((uint)currSelectFlower);
    }

    private void OnHarvestClick()
    {
        CultivationController.Instance.ResCultivationHarvest();
    }

    private void OnSkipClick()
    {
        int time = CultivationModel.Instance.harvestTime - (int)ServerTime.Time;
        float cost = Mathf.Ceil(time / CultivationModel.Instance.costMinTime / 60) * CultivationModel.Instance.costMinRate;
        if (MyselfModel.Instance.diamond >= cost)
        {
            skipBtn.visible = false;
            CultivationController.Instance.ResCultivationSpeedUp();
        }
        else
        {
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
        }
    }

    private void OnCostItemClick(EventContext context)
    {
        //cuurStaticSeedCondition.ItemIds;

        //object[] data = (context.sender as GComponent).data as object[];
        var param = new object[] { (uint)currSelectFlower, cuurStaticSeedCondition.ItemIds };
        UIManager.Instance.OpenWindow<CultivationBuyWindow>(UIName.CultivationBuyWindow, param);
        //Module_item_defConfig itemData = data[0] as Module_item_defConfig;
        //int price = (int)data[3] * ((int)data[2] - (int)data[1]);
        //if ((int)MyselfModel.Instance.diamond >= price)
        //{
        //    CultivationController.Instance.ResCultivationRepair((uint)currSelectFlower, (uint)itemData.ItemDefId);
        //}
        //else
        //{
        //    UILogicUtils.ShowNotice(Lang.GetValue("text_breed37") + price);
        //}
    }

    private void OnImageTouchEnd(EventContext context)
    {
        Module_item_defConfig itemData;
        int index1 = 0;
        int status = 0;
        bool showTips = false;
        bool enable = true;
        for (int i = 0; i < itemCostArr.Count; i++)
        {
            fun_CultivateSeeds.cultivation_seed2 value = itemCostArr[i];
            if (value.Img.url == (context.sender as GLoader).url)
            {
                if (value.status.selectedIndex == 1)
                {
                    status = 1;
                }
                else
                {
                    object[] data = value.Img.data as object[];
                    itemData = data[0] as Module_item_defConfig;
                    index1 = itemCostArr.IndexOf(value);
                    showTips = (int)data[1] < (int)data[2];
                    if (!showTips)
                    {
                        value.status.selectedIndex = 1;
                        //itemNeedArr[i].status.selectedIndex = 1;
                        ShowTip(itemData.Name);
                    }
                }
            }
            else
            {
                if (value.status.selectedIndex == 0 && enable)
                {
                    enable = false;
                }
            }
        }

        if (status != 1)
        {
            viewSkin.cultivation_btn.enabled = enable;

        }
    }

    private void ShowTip(string name)
    {
        var cell = itemNeedArr.Count > 0 ? itemNeedArr[0] : fun_CultivateSeeds.cultivation_need_seed.CreateInstance();
        if (itemNeedArr.Count > 0) itemNeedArr.RemoveAt(0);
        cell.needLab.text = Lang.GetValue("cultivation_1", Lang.GetValue(name));
        viewSkin.tipCom.AddChild(cell);
        cell.x = 0;
        cell.y = 0;
        cell.alpha = 0;
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => cell.alpha, x => cell.alpha = x, 1f, 0.25f).SetEase(Ease.OutCubic));
        sequence.AppendInterval(0.5f);
        sequence.Append(DOTween.To(() => cell.xy, x => cell.xy = x, new Vector2(0, -220), 0.8f).SetEase(Ease.OutCubic))
               .Join(DOTween.To(() => cell.alpha, x => cell.alpha = x, 0.3f, 0.8f).SetEase(Ease.OutCubic));
        sequence.OnComplete(() =>
        {
            sequence.Kill();
            sequence = null;
            cell.parent.RemoveChild(cell);
            if (itemNeedArr.Count < 10) itemNeedArr.Add(cell);
            else cell.Dispose();
        });
        sequence.Play();
    }

    private void LeftHandle()
    {
        viewSkin.tweenCom.flower.itemList.scrollPane.ScrollLeft(1, true);
        ChangeLeftOrRightBtn();
    }

    private void RightHandle()
    {
        viewSkin.tweenCom.flower.itemList.scrollPane.ScrollRight(1, true);
        ChangeLeftOrRightBtn();
    }
}

