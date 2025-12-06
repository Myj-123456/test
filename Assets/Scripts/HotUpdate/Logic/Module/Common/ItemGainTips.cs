using Elida.Config;
using FairyGUI;
using System;

public class ItemGainTips : BaseWindow
{
    private common_New.ItemGainTips view;
    public ItemGainTips()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.ItemGainTips.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as common_New.ItemGainTips;
        SetBg(view.bg, "Common/ELIDA_xhshengji_hyhs_bg-zhong.png");
        view.list_gainway.itemRenderer = RenderList;
        view.list_gainway.SetVirtual();
        view.sub_title.text = Lang.GetValue("recharge_main_29");
    }


    private int[] actionIds;
    public override void OnShown()
    {
        base.OnShown();
        var item = data as Module_item_defConfig;
        if (item == null) return;
        view.txt_des.text = Lang.GetValue(item.Description);
        if (item.Type == 4001 || item.Type == 4105)
        {
            view.type.selectedIndex = 1;
            view.img_icon.url = ImageDataModel.Instance.GetIconUrl(item);
            view.txt_ownNum.text = Lang.GetValue("handBook_2");
            var flowerInfo = item.Type == 4001 ? FlowerHandbookModel.Instance.GetStaticSeedCondition(item.ItemDefId) : FlowerHandbookModel.Instance.GetStaticSeedCondition1(item.ItemDefId);
            view.img_quality.url = "HandBookNew/" + "rare_icon_" + flowerInfo.FlowerQuality + ".png";
            var bookTxtInfo = FLowerModel.Instance.GetBookTxtInfo(flowerInfo.FlowerId);
            
            view.txt_des.text = Lang.GetValue(bookTxtInfo.FlowerLanguage);
        }
        else if(item.Type == 4401 || item.Type == 4402)
        {
            view.type.selectedIndex = 2;
            view.img_vase.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
            view.txt_ownNum.text = Lang.GetValue("handBook_2");
            var vaseInfo = item.Type == 4401 ? IkeModel.Instance.GetStaticFlowerPoint(item.ItemDefId) : IkeModel.Instance.GetStaticFlowerPoint1(item.ItemDefId);
            view.img_quality.url = "HandBookNew/" + "rare_icon_" + vaseInfo.VaseQuality + ".png";
        }
        else
        {
            view.img_icon.url = ImageDataModel.Instance.GetIconUrl(item);
            view.type.selectedIndex = 0;
            view.txt_ownNum.text = $"拥有数量：{TextUtil.ChangeCoinShow(StorageModel.Instance.GetItemCount(item.ItemDefId))}";
        }
        actionIds = item.ActionIds;
        view.txt_name.text = Lang.GetValue(item.Name);
        
        view.list_gainway.numItems = actionIds.Length;
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


