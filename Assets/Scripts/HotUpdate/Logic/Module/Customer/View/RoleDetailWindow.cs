using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;

public class RoleDetailWindow : BaseWindow
{
    private fun_Customer.role_detail_view view;
    private int tabType = 0;
    private NpcConfig curInfo;
    private List<Ft_npc_rewardConfig> listData;

    public RoleDetailWindow()
    {
        packageName = "fun_Customer";
        // 设置委托
        BindAllDelegate = fun_Customer.fun_CustomerBinder.BindAll;
        CreateInstanceDelegate = fun_Customer.role_detail_view.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Customer.role_detail_view;
        SetBg(view.bg, "Customer/ELIDA_jumin_dangan_bg.png");
        view.char_title.text = Lang.GetValue("customer_11");
        view.like_title.text = Lang.GetValue("customer_12");
        view.ident_title.text = Lang.GetValue("customer_13");

        view.gift_title.text = Lang.GetValue("customer_14");

        StringUtil.SetBtnTab(view.info_btn, Lang.GetValue("customer_15"));
        StringUtil.SetBtnTab(view.like_btn, Lang.GetValue("customer_16"));

        view.style_list.itemRenderer = RenderStyleList;
        view.like_list.itemRenderer = RenderGiftList;
        view.like_list.SetVirtual();

        view.list.itemRenderer = RenderLevelList;
        view.list.SetVirtual();
        view.info_btn.onClick.Add(() =>
        {
            if (tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.like_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

        AddEventListener(NpcEvent.NpcBuyTimes, UpdateLvList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        curInfo = CustomerModel.Instance.GetNpcInfo(id);
        view.tab.selectedIndex = 0;
        ChangeTab(0);
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if (tabType == 0)
        {
            UpdateNpcInfo();
        }
        else
        {
            UpdateLvList();
        }
    }

    private void UpdateNpcInfo()
    {
        if (Lang.GetValue(curInfo.Name) != "") view.nameLab.text = Lang.GetValue(curInfo.Name);
        view.style_list.numItems = curInfo.LikeLabels.Length;
        view.style_list.numItems = curInfo.LikeGifts.Length;
        view.decLab.text = Lang.GetValue(curInfo.Introduce);
        view.pic.url = "npc/head/" + curInfo.Head + "_1.png";
        view.char_lab.text = Lang.GetValue(curInfo.Personality);
        view.like_lab.text = Lang.GetValue(curInfo.Preference);
        view.ident_lab.text = Lang.GetValue(curInfo.Identity);
    }

    public void UpdateLvList()
    {
        listData = CustomerModel.Instance.GetNpcRewardList(curInfo.Id);
        view.list.numItems = listData.Count;
    }

    private void RenderLevelList(int index, GObject item)
    {
        var cell = item as fun_Customer.like_item;
        cell.pos.selectedIndex = index % 2 == 0 ? 1 : 0;
        var levelInfo = listData[index];
        cell.lvLab.text = levelInfo.Level.ToString();

        if (levelInfo.Level > curInfo.Level)
        {
            cell.status.selectedIndex = 0;
            cell.nameLab.text = "？？？？？？";
            cell.lockLab.text = Lang.GetValue("customer_17", levelInfo.Level.ToString());
        }
        else
        {
            var plotConfig = PlotModel.Instance.GetPlotConfig(levelInfo.PoltId);
            if (plotConfig != null)
            {
                cell.nameLab.text = Lang.GetValue(plotConfig.PlotName);
            }
            if (curInfo.LevelRewards == null || Array.IndexOf(curInfo.LevelRewards, (uint)levelInfo.Level) == -1)
            {
                cell.status.selectedIndex = 1;
                cell.gotoLab.text = Lang.GetValue("travel_button_go");
            }
            else
            {
                cell.status.selectedIndex = 2;
                cell.gotoLab.text = Lang.GetValue("customer_18");
            }
        }

        cell.reward_list.itemRenderer = (int inddex, GObject rewardItem) =>
        {
            var rewardCell = rewardItem as fun_Customer.rewrad_item1;
            var reward = levelInfo.Rewards[inddex];
            var itemVo = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.numLab.text = reward.Value.ToString();
        };
        cell.reward_list.numItems = levelInfo.Rewards.Length;
        cell.end.selectedIndex = index == listData.Count - 1 ? 1 : 0;
        cell.data = levelInfo.Level;
        cell.onClick.Add(GetReward);
    }

    private void GetReward(EventContext context)
    {
        var item = context.sender as fun_Customer.like_item;
        var level = (int)item.data;
        if (item.status.selectedIndex == 1)
        {
            var levelInfo = CustomerModel.Instance.GetNpcRewardInfo(curInfo.Id, level);
            PlotController.Instance.PlayPlot(levelInfo.PoltId,()=>
            {
                CustomerController.Instance.ReqNpcGetReward((uint)curInfo.Id, (uint)level);
            });
        }else if(item.status.selectedIndex == 2)
        {
            var levelInfo = CustomerModel.Instance.GetNpcRewardInfo(curInfo.Id, level);
            PlotController.Instance.PlayPlot(levelInfo.PoltId, () =>
            {
                
            });
        }

    }
    private void RenderStyleList(int index, GObject item)
    {
        var cell = item as fun_Customer.style_item;
        var info = curInfo.LikeLabels[index];
        cell.pic.url = "HandBookNew/style_icon_" + info + ".png";
    }
    private void RenderGiftList(int index, GObject item)
    {
        var cell = item as fun_Customer.rewrad_item;
        var info = curInfo.LikeGifts[index];
        var itemVo = ItemModel.Instance.GetItemById(info);
        cell.numLab.text = "";
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

