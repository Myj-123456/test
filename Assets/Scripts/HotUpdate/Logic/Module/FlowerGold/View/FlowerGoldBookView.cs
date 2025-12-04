using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FlowerGoldBookView : BaseView
{
   private fun_FlowerGold.flower_gold_book_view view;
    private int curQuality = 0;

    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public FlowerGoldBookView()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.flower_gold_book_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.flower_gold_book_view;
        SetBg(view.bg, "Pet/ELIDA_lingshou_wenquan_tuce_BG.png");
        view.titleLab.text = Lang.GetValue("fairy_1");
        view.addLab.text = Lang.GetValue("fairy_2");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.chose_grp.list.itemRenderer = RenderQualityList;
        view.chose_btn.onClick.Add(() =>
        {
            if (view.showChose.selectedIndex == 1)
            {
                view.showChose.selectedIndex = 0;
            }
            else
            {
                view.showChose.selectedIndex = 1;
            }

        });
        view.detail_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<NatureInfoWindow>(UIName.NatureInfoWindow);
        });
        AddEventListener(FlowerGoldEvent.FairyExchange, UpdataList);
        AddEventListener(FlowerGoldEvent.FairyUpgrade, UpdataList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        InitUI();
        FlowerGoldModel.Instance.FilterBookData(curQuality);
        UpdataList();
    }

    private void InitUI()
    {
        curQuality = 0;
        view.chose_grp.quality.selectedIndex = curQuality;
        InitQualityList();
        view.showChose.selectedIndex = 0;
    }

    private void InitQualityList()
    {
        view.chose_grp.list.numItems = 5;
        view.chose_grp.quality.selectedIndex = curQuality > 4 ? 4 : curQuality;
        StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("pet_quality_" + curQuality));
    }

    private void UpdateAttr()
    {
        view.numLab.text = Lang.GetValue("fairy_3",FlowerGoldModel.Instance.fairys.Count + "/" + FlowerGoldModel.Instance.fairyList.Count);
        var attrs = FlowerGoldModel.Instance.GetFairyAttr();
        view.attackLab.text = Lang.GetValue("player_attack") + "：+" + (attrs.ContainsKey((int)PlayerAttr.Attack)? attrs[(int)PlayerAttr.Attack]:0);
        view.denfenLab.text = Lang.GetValue("player_defense") + "：+" + (attrs.ContainsKey((int)PlayerAttr.Defense) ? attrs[(int)PlayerAttr.Defense] : 0);
        view.hpLab.text = Lang.GetValue("player_hp") + "：+" + (attrs.ContainsKey((int)PlayerAttr.Hp) ? attrs[(int)PlayerAttr.Hp] : 0);
        view.speedLab.text = Lang.GetValue("player_speed") + "：+" + (attrs.ContainsKey((int)PlayerAttr.Speed) ? attrs[(int)PlayerAttr.Speed] : 0);
    }

    private void UpdataList()
    {
        view.list.numItems = FlowerGoldModel.Instance.fairyHome.Count;
        UpdateAttr();
    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_FlowerGold.flower_gold_book_item;
        var fairyData = FlowerGoldModel.Instance.fairyHome[index];
        var itemVo = ItemModel.Instance.GetItemById(fairyData.Id);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.nameLab.text = Lang.GetValue(itemVo.Name);
        if (fairyData.Unlock)
        {
            cell.status.selectedIndex = 1;
            var fairyServerData = FlowerGoldModel.Instance.GetFairyServerData((uint)fairyData.Id);
            if (fairyData.IsMaxLeve)
            {
                cell.levelLab.text = Lang.GetValue("guild.bt_manage_full");

            }
            else
            {
                cell.levelLab.text = Lang.GetValue("invite_friends_16", fairyServerData.level.ToString());
            }

            
            cell.show_lv.visible = FlowerGoldModel.Instance.IsCanLevel(fairyData.Id);
        }
        else
        {
            cell.show_lv.visible = false;
            
            var shardInfo = ItemModel.Instance.GetItemById(fairyData.ShardId);
            cell.shard_img.url = ImageDataModel.Instance.GetIconUrl(shardInfo);
            var count = StorageModel.Instance.GetItemCount(fairyData.ShardId);
            cell.pro.max = fairyData.ComposeNum;
            cell.pro.value = count;
            cell.proLab.text = TextUtil.ChangeCoinShow(count) + "/" + fairyData.ComposeNum;
            if (fairyData.ComposeNum > count)
            {
                cell.tipLab.text = "";
                cell.status.selectedIndex = 0;
            }
            else
            {
                cell.tipLab.text = Lang.GetValue("flower_info_27");
                cell.status.selectedIndex = 2;
            }
        }
        cell.bg.url = "HandBookNew/bg_new_" + fairyData.Quality + ".png";
        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[fairyData.Quality - 1]);
        cell.data = index;
        cell.onClick.Add(OpenInfoView);

    }

    private void OpenInfoView(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var fairyData = FlowerGoldModel.Instance.fairyHome[index];
        if (!fairyData.Unlock)
        {
            var count = StorageModel.Instance.GetItemCount(fairyData.ShardId);
            if (fairyData.ComposeNum <= count)
            {
                FlowerGoldController.Instance.ReqFairyExchange((uint)fairyData.Id);
                return;
            }
        }
        UIManager.Instance.OpenPanel<FlowerGoldInfoWindow>(UIName.FlowerGoldInfoWindow,UILayer.UI, index);
    }

    private void RenderQualityList(int index, GObject item)
    {
        var cell = item as fun_FlowerGold.chose_quality_item;
        if (index == 0)
        {
            cell.quality_img.url = "";
            cell.titileLab.text = Lang.GetValue("guild_Match_3");
        }
        else
        {
            cell.quality_img.url = "HandBookNew/rare_icon_" + (index == 4 ? 5 : index) + ".png";
            cell.titileLab.text = Lang.GetValue("pet_quality_" + +(index == 4 ? 5 : index));
        }
        cell.data = index == 4 ? 5 : index;
        cell.onClick.Add(ChoseQualityClick);
    }

    private void ChoseQualityClick(EventContext context)
    {
        int type = (int)(context.sender as GComponent).data;
        if (type != curQuality)
        {
            curQuality = type;
            view.chose_grp.quality.selectedIndex = curQuality == 4 ? 5 : curQuality;
            StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("pet_quality_" + curQuality));
            view.showChose.selectedIndex = 0;
            FlowerGoldModel.Instance.FilterBookData(curQuality);
            UpdataList();
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

