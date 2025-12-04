using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class DressDetailWindow : BaseWindow
{
   private fun_Dress.dress_detail_view view;
    private int[] actionIds;
    private Ft_shop_clothesConfig shopData;
    public DressDetailWindow()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_detail_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_detail_view;
        SetBg(view.bg, "Common/ELIDA_xhshengji_hyhs_bg-zhong.png");
        view.list_gainway.itemRenderer = RenderList;
        view.list_gainway.SetVirtual();
        view.sub_title.text = Lang.GetValue("recharge_main_29");
        view.buy_btn.onClick.Add(() =>
        {
            var lv = DressModel.Instance.GetShopLv();
            if(lv < shopData.UnlockLv)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("dress_16", shopData.UnlockLv.ToString()));
                return;
            }
            DressController.Instance.ReqDressClothesBuy((uint)shopData.Id);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int id = (int)data;
        var itemVo = ItemModel.Instance.GetItemById(id);
        var dressInfo = DressModel.Instance.GetDressInfo(id);
        view.txt_des.text = Lang.GetValue(itemVo.Description);
        view.charmNum.text = "+" + dressInfo.CharmNum;
        view.quality_bg.url = "Dress/QualityIcon/ELIDA_huanzhuang_djd0" + dressInfo.Quality + ".png";
        view.img_quality.url = "HandBookNew/rare_icon_" + dressInfo.Quality + ".png";
        view.img_icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.txt_name.text = Lang.GetValue(itemVo.Name);
        if (dressInfo.Unlock)
        {
            view.txt_ownNum.text = Lang.GetValue("Vip_store_txt5");
            view.type.selectedIndex = 2;
        }
        else
        {
            view.txt_ownNum.text = Lang.GetValue("handBook_2");
            shopData = DressModel.Instance.GetDressShopInfo1(id);
            if (shopData == null)
            {

                actionIds = itemVo.ActionIds;
                view.list_gainway.numItems = actionIds.Length;
                view.type.selectedIndex = 0;
            }
            else
            {
                var costVo = ItemModel.Instance.GetItemByEntityID(shopData.Prices[0].EntityID);
                view.type.selectedIndex = 1;
                var count = StorageModel.Instance.GetItemCount(shopData.Prices[0].EntityID);
                view.buy_btn.enabled = count >= shopData.Prices[0].Value;
                StringUtil.SetBtnTab(view.buy_btn, shopData.Prices[0].Value.ToString());
                StringUtil.SetBtnUrl(view.buy_btn, ImageDataModel.Instance.GetIconUrl(costVo));
            }
        }
    }

    private void RenderList(int index, GObject item)
    {
        common_New.ItemGainRender cell = item as common_New.ItemGainRender;
        ADK.StringUtil.SetBtnTab(cell.btnGo, Lang.GetValue("travel_button_go"));
        var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(actionIds[index]);
        if (ft_jumpConfig != null)
        {
            cell.txt_gainWay.text = Lang.GetValue(ft_jumpConfig.JumpName);
        }
        cell.btnGo.data = ft_jumpConfig;
        cell.btnGo.onClick.Add(OnGo);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void OnGo(EventContext context)
    {
        var data = (context.sender as GComponent).data as Ft_jumpConfig;
        UIManager.Instance.CloseAllWindown();
        if (data.JumpType == 1)
        {
            UIManager.Instance.OpenPanelByName(data.JumpParam);
        }
    }
}

