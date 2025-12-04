using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class CultivationBuyWindow : BaseWindow
{
    private fun_CultivateSeeds.cultivation_buy view;
    private List<ItemIdObject> listData;
    private int cost;
    private uint selectFlower;
    public CultivationBuyWindow()
    {
        packageName = "fun_CultivateSeeds";
        // 设置委托
        BindAllDelegate = fun_CultivateSeeds.fun_CultivateSeedsBinder.BindAll;
        CreateInstanceDelegate = fun_CultivateSeeds.cultivation_buy.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_CultivateSeeds.cultivation_buy;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.title.text = Lang.GetValue("cultivation_buy_1");
        StringUtil.SetBtnTab(view.goBtn, Lang.GetValue("cultivation_buy_3"));
        StringUtil.SetBtnTab(view.buyBtn, Lang.GetValue("cultivation_buy_4"));

        view.tipLab.text = Lang.GetValue("cultivation_buy_2");

        view.list.itemRenderer = RenderList;

        view.goBtn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.RandomShop, true))
            {
                return;
            }
            UIManager.Instance.CloseWindow(UIName.CultivationBuyWindow);
            UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView,UILayer.UI,0);
        });

        view.buyBtn.onClick.Add(() =>
        {
            if ((int)MyselfModel.Instance.diamond >= cost)
            {
                CultivationController.Instance.ResCultivationRepair(selectFlower);
                UIManager.Instance.CloseWindow(UIName.CultivationBuyWindow);
            }
            else
            {
                UILogicUtils.ShowNotice(Lang.GetValue("text_breed37") + cost);
            }
        });

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var param = data as object[];
        selectFlower = (uint)param[0];
        var itemIds = param[1] as List<ItemIdObject>;
        cost = 0;
        listData = new List<ItemIdObject>();
        for (int i = 0; i < itemIds.Count; i++)
        {
            var count = StorageModel.Instance.GetItemCount(itemIds[i].EntityID);
            if (count < itemIds[i].Value)
            {
                listData.Add(itemIds[i]);
                Module_fertilizerConfig costData = CultivationModel.Instance.GetFertilizerConfigById(itemIds[i].EntityID);
                cost += costData.QuickBuyCost * (itemIds[i].Value - count);
            }
        }
        StringUtil.SetBtnCount(view.buyBtn, cost.ToString());
        view.list.numItems = listData.Count;

    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_CultivateSeeds.cultivation_seed1;
        string entityId = listData[index].EntityID;
        int count = listData[index].Value;
        var has = StorageModel.Instance.GetItemCount(entityId);
        cell.count_txt.text = "[color=#f3c716]" + has + "[/color]" + "/" + count;
        cell.Img.url = ImageDataModel.Instance.GetIconUrlByEntityId(entityId);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(entityId);
        cell.title_txt.text = Lang.GetValue(itemData.Name);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

