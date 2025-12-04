using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FloristView : BaseView
{
    private fun_Florist.florist_view view;
    private int tabType = 0;
    private int had = 0;
    private int quality = 0;
    public FloristView()
    {
        packageName = "fun_Florist";
        // 设置委托
        BindAllDelegate = fun_Florist.fun_FloristBinder.BindAll;
        CreateInstanceDelegate = fun_Florist.florist_view.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Florist.florist_view;
        SetBg(view.bg, "FlowerGold/ELIDA_huaxian_tcxiangqing_hxbg01.jpg");
        SetBg(view.level_view.bg, "Florist/ELIDA_huadian_tisheng_di01.png");
        SetBg(view.level_view.pic, "Florist/ELIDA_huadian_tisheng_di02.png");
        view.titleLab.text = Lang.GetValue("florist_4");
        view.level_view.lvLab.text = Lang.GetValue("slang_27");
        view.level_view.deskLimit.text = Lang.GetValue("florist_5");
        view.level_view.flowerLimit.text = Lang.GetValue("florist_6");
        view.level_view.rewardLab.text = Lang.GetValue("florist_7");
        view.level_view.limitLab.text = Lang.GetValue("florist_8");
        view.book_view.powerName.text = Lang.GetValue("power_name");
        StringUtil.SetBtnTab(view.level_view.levelUp_btn, Lang.GetValue("slang_57"));

        StringUtil.SetBtnTab(view.book_view.chose_btn, Lang.GetValue("pray_8"));

        view.book_view.chose_grp.have_btn.titileLab.text = Lang.GetValue("florist_23");
        view.book_view.chose_grp.no_btn.titileLab.text = Lang.GetValue("florist_24");

        view.book_view.chose_grp.quality_btn1.titileLab.text = Lang.GetValue("pet_quality_1");
        view.book_view.chose_grp.quality_btn2.titileLab.text = Lang.GetValue("pet_quality_2");
        view.book_view.chose_grp.quality_btn3.titileLab.text = Lang.GetValue("pet_quality_3");
        view.book_view.chose_grp.quality_btn5.titileLab.text = Lang.GetValue("pet_quality_5");

        view.book_view.chose_grp.quality_btn1.pic.url = "HandBookNew/rare_icon_1.png";
        view.book_view.chose_grp.quality_btn2.pic.url = "HandBookNew/rare_icon_2.png";
        view.book_view.chose_grp.quality_btn3.pic.url = "HandBookNew/rare_icon_3.png";
        view.book_view.chose_grp.quality_btn5.pic.url = "HandBookNew/rare_icon_5.png";


        StringUtil.SetBtnTab(view.level_btn, Lang.GetValue("florist_9"));
        StringUtil.SetBtnTab(view.florist_btn, Lang.GetValue("florist_10"));
        StringUtil.SetBtnTab(view.plant_btn, Lang.GetValue("florist_11"));
        view.book_view.list.itemRenderer = RenderBookList;
        view.book_view.list.SetVirtual();
        FlowerShopModel.Instance.FilterBook();

        view.book_view.chose_grp.have_btn.onClick.Add(() =>
        {
            FilterHave(1);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });

        view.book_view.chose_grp.no_btn.onClick.Add(() =>
        {
            FilterHave(2);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });

        view.book_view.chose_grp.quality_btn1.onClick.Add(() =>
        {
            FilterQuatily(1);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });
        view.book_view.chose_grp.quality_btn2.onClick.Add(() =>
        {
            FilterQuatily(2);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });
        view.book_view.chose_grp.quality_btn3.onClick.Add(() =>
        {
            FilterQuatily(3);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });
        view.book_view.chose_grp.quality_btn5.onClick.Add(() =>
        {
            FilterQuatily(5);
            FlowerShopModel.Instance.FilterBook(had, quality);
            UpdateList();
        });
        view.book_view.chose_btn.onClick.Add(() =>
        {
            view.book_view.showChose.selectedIndex = view.book_view.showChose.selectedIndex == 0 ? 1 : 0;
        });

        view.level_btn.onClick.Add(() =>
        {
            if (tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.florist_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.plant_btn.onClick.Add(() =>
        {
            view.tab.selectedIndex = tabType;

            UILogicUtils.ShowNotice(Lang.GetValue("text_book39"));
        });
        view.level_view.levelUp_btn.onClick.Add(() =>
        {
            var limitData = FlowerShopModel.Instance.GetLimitList((int)FlowerShopModel.Instance.shopLevel + 1);
            foreach (var value in limitData)
            {
                var info = value;
                if ((info.type == 1 && info.num > (int)PlayerModel.Instance.pen.drawingPower) ||
                    (info.type == 2 && info.num > MyselfModel.Instance.level) ||
                    (info.type == 3 && info.num > StorageModel.Instance.seedCount) ||
                    (info.type == 4 && info.num > IkeModel.Instance.GetVaseCount()) ||
                    (info.type == 5 && info.num > DressModel.Instance.GetDressCount()))
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("florist_22"));
                    return;
                }
            }
            foreach (var value in limitData)
            {
                if (FlowerShopModel.Instance.rewardIds.IndexOf((uint)value.type) == -1)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("florist_34"));
                    return;
                }
            }
            FlowerShopController.Instance.ReqFloristUpgrade();

        });
        AddEventListener(FloristEvent.FloristReward, UpdateLimit);
        AddEventListener(FloristEvent.FloristUpgrade, UpdateLevel);
        AddEventListener(FloristEvent.FloristInfo, UpdatePower);

        view.level_view.reward_list.onClickItem.Add(OnClickRewardItem);

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.tab.selectedIndex = 0;
        ChangeTab(0);
    }
    private void OnClickRewardItem(EventContext context)
    {
        var upRewardObject = (context.data as GComponent).data as UpRewardObject;
        var itemVo = ItemModel.Instance.GetItemByEntityID(upRewardObject.EntityID);
        if (itemVo != null)
        {
            //UILogicUtils.ShowItemTips(itemVo.ItemDefId);
            UILogicUtils.ShowItemGainTips(itemVo.ItemDefId);
        }
    }

    private void FilterHave(int have)
    {
        if (have == 1)
        {
            view.book_view.chose_grp.have_btn.status.selectedIndex = had == 1 ? 0 : 1;
            view.book_view.chose_grp.no_btn.status.selectedIndex = 0;
            had = had == 1 ? 0 : 1;
        }
        else
        {
            view.book_view.chose_grp.have_btn.status.selectedIndex = 0;
            view.book_view.chose_grp.no_btn.status.selectedIndex = had == 2 ? 0 : 1;
            had = had == 2 ? 0 : 2;
        }
    }

    private void FilterQuatily(int qua)
    {
        for (int i = 1; i < 6; i++)
        {
            if (i == 4) continue;
            var cell = view.book_view.chose_grp.GetChild("quality_btn" + i) as fun_Florist.chose_quality_item;
            if (qua == i)
            {
                if (cell.status.selectedIndex == 1)
                {
                    cell.status.selectedIndex = 0;
                    quality = 0;
                }
                else
                {
                    cell.status.selectedIndex = 1;
                    quality = qua;
                }
            }
            else
            {
                cell.status.selectedIndex = 0;
            }
        }
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if (tabType == 0)
        {
            UpdateLevel();
        }
        else if (tabType == 1)
        {
            BattleController.Instance.ReqModulePower(3);
            view.book_view.showChose.selectedIndex = 0;
            UpdateList();
        }
        else
        {

        }
    }

    private void UpdateLevel()
    {
        var lvView = view.level_view;
        lvView.curLv.text = Lang.GetValue("levelup_explain", FlowerShopModel.Instance.shopLevel.ToString());
        var curLvInfo = FlowerShopModel.Instance.GetShopLvInfo((int)FlowerShopModel.Instance.shopLevel);
        lvView.curDesk.text = curLvInfo.SellLimit.ToString();
        lvView.curFlower.text = curLvInfo.FlowerLimit.ToString();
        if (!FlowerShopModel.Instance.IsMaxShopLv())
        {
            lvView.max.selectedIndex = 0;
            lvView.nextLv.text = Lang.GetValue("levelup_explain", (FlowerShopModel.Instance.shopLevel + 1).ToString());
            var nextLvInfo = FlowerShopModel.Instance.GetShopLvInfo((int)FlowerShopModel.Instance.shopLevel + 1);
            lvView.nextDesk.text = nextLvInfo.SellLimit.ToString();
            lvView.nextFlower.text = nextLvInfo.FlowerLimit.ToString();
            UpdateLimit();
            lvView.reward_list.itemRenderer = (int index, GObject item) =>
            {
                var cell = item as fun_Florist.reward_item;
                var rewardInfo = nextLvInfo.UpRewards[index];
                var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
                cell.numLab.text = rewardInfo.Value.ToString();
                cell.data = rewardInfo;
                if (itemVo != null)
                {
                    cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                    cell.nameLab.text = Lang.GetValue(itemVo.Name);
                }

            };
            lvView.reward_list.numItems = nextLvInfo.UpRewards.Length;
        }
        else
        {
            lvView.max.selectedIndex = 1;
            lvView.nextLv.text = "Max";
            lvView.nextDesk.text = "Max";
            lvView.nextFlower.text = "Max";
        }


    }

    private void UpdateLimit()
    {
        var limitData = FlowerShopModel.Instance.GetLimitList((int)FlowerShopModel.Instance.shopLevel + 1);
        var limitView = view.level_view.limitCom;
        limitView.status.selectedIndex = limitData.Count - 1;
        for (int i = 0; i < limitData.Count; i++)
        {
            var cell = limitView.GetChild("item" + (i + 1)) as fun_Florist.limit_item;
            var info = limitData[i];
            cell.data = info;
            var itemVo = ItemModel.Instance.GetItemByEntityID(info.itemId);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.numLab.text = info.value.ToString();

            var isCanget = false;
            if (info.type == 1)
            {
                cell.limitLab.text = TextUtil.ChangeCoinShow1(PlayerModel.Instance.pen.drawingPower) + "/" + TextUtil.ChangeCoinShow1(info.num);
                cell.nameLab.text = Lang.GetValue("power_name");
                isCanget = (int)PlayerModel.Instance.pen.drawingPower >= info.num;
            }
            else if (info.type == 2)
            {
                cell.limitLab.text = MyselfModel.Instance.level + "/" + info.num;
                cell.nameLab.text = Lang.GetValue("florist_12");
                isCanget = (int)MyselfModel.Instance.level >= info.num;
            }
            else if (info.type == 3)
            {
                cell.limitLab.text = StorageModel.Instance.seedCount + "/" + info.num;
                cell.nameLab.text = Lang.GetValue("florist_13");
                isCanget = StorageModel.Instance.seedCount >= info.num;
            }
            else if (info.type == 4)
            {
                cell.limitLab.text = IkeModel.Instance.GetVaseCount() + "/" + info.num;
                cell.nameLab.text = Lang.GetValue("florist_14");
                isCanget = IkeModel.Instance.GetVaseCount() >= info.num;
            }
            else
            {
                cell.limitLab.text = DressModel.Instance.GetDressCount() + "/" + info.num;
                cell.nameLab.text = Lang.GetValue("florist_15");
                isCanget = DressModel.Instance.GetDressCount() >= info.num;
            }
            if (FlowerShopModel.Instance.rewardIds.IndexOf((uint)info.type) != -1)
            {
                cell.status.selectedIndex = 2;
                cell.enabled = false;
            }
            else
            {
                cell.status.selectedIndex = isCanget ? 1 : 0;
                cell.enabled = true;
            }
            cell.onClick.Add(LimitClick);
        }
    }
    private void LimitClick(EventContext context)
    {
        var info = (context.sender as GComponent).data as LimitData;
        if ((info.type == 1 && info.num > (int)PlayerModel.Instance.pen.drawingPower) ||
            (info.type == 2 && info.num > MyselfModel.Instance.level) ||
            (info.type == 3 && info.num > StorageModel.Instance.seedCount) ||
            (info.type == 4 && info.num > IkeModel.Instance.GetVaseCount()) ||
            (info.type == 5 && info.num > DressModel.Instance.GetDressCount()))
        {
            UIManager.Instance.OpenWindow<FloristGotoWindow>(UIName.FloristGotoWindow, info);
            return;
        }
        if (FlowerShopModel.Instance.rewardIds.IndexOf((uint)info.type) != -1)
        {
            return;
        }
        FlowerShopController.Instance.ReqFloristReward((uint)info.type);
    }

    private void UpdateList()
    {
        view.book_view.list.numItems = FlowerShopModel.Instance.floristSuitHome.Count;
    }
    private void RenderBookList(int index, GObject item)
    {
        var cell = item as fun_Florist.florist_book_item;
        var info = FlowerShopModel.Instance.floristSuitHome[index];
        cell.bg.url = "Florist/ELIDA_huadian_jjgl_taozhuang01.png";
        cell.nameLab.text = Lang.GetValue(info.Name);
        cell.rare_img.url = "HandBookNew/rare_icon_" + info.Quality + ".png";
        cell.quality_img.url = "Florist/florist_quality_" + info.Quality + ".png";
        cell.quality.selectedIndex = info.Quality;
        cell.collectLab.text = Lang.GetValue("florist_26", info.HavecCount + "/" + info.Furnitures.Length);
        if (info.IsDefault == 1 && FlowerShopModel.Instance.shopLevel < info.ExpandLv)
        {
            cell.limit.selectedIndex = 1;
            cell.limitLab.text = Lang.GetValue("florist_27", info.ExpandLv.ToString());
        }
        else
        {
            cell.limit.selectedIndex = 0;
        }
        cell.data = index;
        cell.onClick.Add(ClickBook);
    }

    private void ClickBook(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var info = FlowerShopModel.Instance.floristSuitHome[index];
        if (info.IsDefault == 1 && FlowerShopModel.Instance.shopLevel < info.ExpandLv)
        {
            return;
        }
        UIManager.Instance.OpenPanel<FloristInfoView>(UIName.FloristInfoView, UILayer.UI, index);
    }

    private void UpdatePower()
    {
        view.book_view.powerNum.text = TextUtil.ChangeCoinShow2(FlowerShopModel.Instance.floristDrawingPower);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

