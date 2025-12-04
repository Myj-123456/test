
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class GuildShopWindow : BaseWindow
{
   private fun_Guild_New.guild_shop_view view;
    private List<Ft_club_shopConfig> listData;
    private int page;
   public GuildShopWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_shop_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_shop_view;
        SetBg(view.bg, "Guild/ELIDA_huameng_shangpu_bg01.png");
        SetBg(view.bg1, "Guild/ELIDA_huameng_shangpu_bg02.png");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        EventManager.Instance.AddEventListener(GuildEvent.GuildShopInfo, UpdateList);
        EventManager.Instance.AddEventListener(GuildEvent.GuildShopBuy, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        listData = GuildModel.Instance.shopConfig;
        page = (int)Mathf.Ceil((float)listData.Count / 3f);
        GuildController.Instance.ReqGuildShopInfo();
    }

    public void UpdateList()
    {
        view.list.numItems = page;
    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Guild_New.guild_shop_item;
       
        cell.list.itemRenderer = (int idx, GObject shopItem) =>
        {
            var shopCell = shopItem as fun_Guild_New.guild_shop_cell;
            var shopData = listData[index*3 + idx];
            if (shopData.UnlockClubLv > GuildModel.Instance.guild.level)
            {
                shopCell.unlock.selectedIndex = 1;
                shopCell.lockLab.text = Lang.GetValue("guild_plant_3", shopData.UnlockClubLv.ToString());
            }
            else
            {
                shopCell.unlock.selectedIndex = 0;
            }
            if (shopData.LimitConfigs[0] == 1)
            {
                var num = 0;
                if (GuildModel.Instance.buyCntStat.ContainsKey((uint)shopData.IndexId))
                {
                    num = (int)GuildModel.Instance.buyCntStat[(uint)shopData.IndexId];
                }
                shopCell.limit.selectedIndex = 1;
                shopCell.limitLab.text = num + "/" + shopData.LimitConfigs[1];
                
            }
            else
            {
                shopCell.limit.selectedIndex = 0;
            }
            var itemVo = ItemModel.Instance.GetItemByEntityID(shopData.ItemIds[0].EntityID);
            shopCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            var costVo = ItemModel.Instance.GetItemByEntityID(shopData.Prices[0].EntityID);
            shopCell.costLab.text = shopData.Prices[0].Value.ToString();
            shopCell.costImg.url = ImageDataModel.Instance.GetIconUrl(costVo);

            shopCell.data = shopData;
            shopCell.onClick.Add(BuyItem);
        };
        var len = (index * 3 + 3) > listData.Count ? listData.Count - (index * 3) : 3;
        cell.list.numItems = len;
    }

    private void BuyItem(EventContext context)
    {
        var shopData = (context.sender as GComponent).data as Ft_club_shopConfig;
        var num = StorageModel.Instance.GetItemCount(IDUtil.GetEntityValue(shopData.Prices[0].EntityID));
        var costVo = ItemModel.Instance.GetItemByEntityID(shopData.Prices[0].EntityID);
        if (num < shopData.Prices[0].Value)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_87", Lang.GetValue(costVo.Name)));
            return;
        }
        GuildController.Instance.ReqGuildShopBuy((uint)shopData.IndexId);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

