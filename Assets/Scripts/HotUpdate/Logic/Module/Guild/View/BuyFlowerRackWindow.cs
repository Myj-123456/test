
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class BuyFlowerRackWindow : BaseWindow
{
   private fun_Guild_plant.buy_flower_jia view;
    private Ft_club_plantConfig plantInfo;
    private Ft_club_permissionConfig limtData;
    private int curSelelct = 0;
    public BuyFlowerRackWindow()
    {
        packageName = "fun_Guild_plant";
        // 设置委托
        BindAllDelegate = fun_Guild_plant.fun_Guild_plantBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_plant.buy_flower_jia.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_plant.buy_flower_jia;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.btn, Lang.GetValue("UserInfoOn"));
        view.item1.onClick.Add(() =>
        {
            if(curSelelct != 1 && limtData.FlowerHouse == 1)
            {
                curSelelct = 1;
                view.tab.selectedIndex = 1;
            }
            else
            {
                if(limtData.FlowerHouse != 1)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("guildStore_19"));
                    view.tab.selectedIndex = 0;
                }
                
            }
        });

        view.item2.onClick.Add(() =>
        {
            if(curSelelct != 0)
            {
                curSelelct = 0;
                view.tab.selectedIndex = 0;
            }
        });

        view.btn.onClick.Add(() =>
        {
            if(curSelelct == 1)
            {
                //var itemVo1 = ItemModel.Instance.GetItemByEntityID(plantInfo.ClubOpenCosts[0].CounterCount);
                var num = GuildModel.Instance.guild.gold;
                if (num < plantInfo.ClubOpenCost)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_90", Lang.GetValue("my_info_7") +Lang.GetValue("guild_test_2")));
                    return;
                }
            }
            else
            {
                
                var itemVo2 = ItemModel.Instance.GetItemByEntityID(plantInfo.NormalOpenCosts[0].CounterCount);
                var num = StorageModel.Instance.GetItemCount(plantInfo.NormalOpenCosts[0].CounterCount);
                if (num < plantInfo.NormalOpenCosts[0].Limit)
                {
                    UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_90", Lang.GetValue(itemVo2.Name)));
                    return;
                }
            }
            var type = curSelelct == 1 ? 1 : 2;
            GuildPlantController.Instance.ReqGuildHouseEnable((uint)plantInfo.Id, (uint)type);
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        view.title_img.url = "Guild/plant_title_icon_" + id + ".png";
        plantInfo = GuildPlantModel.Instance.GetGuildPlantConfig(id);
        limtData = GuildModel.Instance.GetPositionInfo((int)GuildModel.Instance.guildMember.powerId);
        view.tab.selectedIndex = limtData.FlowerHouse;
        curSelelct = limtData.FlowerHouse;
        InitItem();
    }

    private void InitItem()
    {
        view.item1.txt_title.text = Lang.GetValue("my_info_7") + Lang.GetValue("guild_test_2") + Lang.GetValue("UserInfoOn");
        view.item1.txt_cost.text = Lang.GetValue("slang_59");
        view.item1.costLab.text = TextUtil.ChangeCoinShow(plantInfo.ClubOpenCost);
        view.item1.costImg.url = ImageDataModel.Instance.GuildMoneyIconUrl();
        view.item1.limitLab.text = Lang.GetValue("guild_plant_5");

        var itemVo2 = ItemModel.Instance.GetItemByEntityID(plantInfo.NormalOpenCosts[0].CounterCount);
        view.item2.txt_title.text = Lang.GetValue(itemVo2.Name) + Lang.GetValue("UserInfoOn");
        view.item2.txt_cost.text = Lang.GetValue("slang_59");
        view.item2.costLab.text = TextUtil.ChangeCoinShow(plantInfo.NormalOpenCosts[0].Limit);
        view.item2.costImg.url = ImageDataModel.CASH_ICON_URL;
        view.item2.limitLab.text = Lang.GetValue("guild_plant_6");



    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

