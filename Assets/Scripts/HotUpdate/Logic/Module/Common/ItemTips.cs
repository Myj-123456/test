using Elida.Config;

public class ItemTips : BaseWindow
{
    private common_New.ItemTips view;
    public ItemTips()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.ItemTips.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as common_New.ItemTips;
        SetBg(view.bg, "Common/ELIDA_xhshengji_hyhs_bg-xiao.png");
    }

    public override void OnShown()
    {
        base.OnShown();
        var item = data as Module_item_defConfig;
        if (item == null) return;
        if (item.Type == 4001 || item.Type == 4105)
        {
            view.type.selectedIndex = 1;
            view.img_icon.url = ImageDataModel.Instance.GetIconUrl(item);
            view.txt_ownNum.text = Lang.GetValue("Vip_store_txt5");
            var flowerInfo = item.Type == 4001 ? FlowerHandbookModel.Instance.GetStaticSeedCondition(item.ItemDefId) : FlowerHandbookModel.Instance.GetStaticSeedCondition1(item.ItemDefId);
            view.img_quality.url = "HandBookNew/" + "rare_icon_" + flowerInfo.FlowerQuality + ".png";
        }
        else if (item.Type == 4401 || item.Type == 4402)
        {
            view.type.selectedIndex = 1;
            //view.vase_img.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
            view.img_icon.url = ImageDataModel.Instance.GetIconUrl(item);
            view.txt_ownNum.text = Lang.GetValue("Vip_store_txt5");
            var vaseInfo = item.Type == 4401?IkeModel.Instance.GetStaticFlowerPoint(item.ItemDefId): IkeModel.Instance.GetStaticFlowerPoint1(item.ItemDefId);
            view.img_quality.url = "HandBookNew/" + "rare_icon_" + item.Quality + ".png";
        }
        else
        {
            view.img_icon.url = ImageDataModel.Instance.GetIconUrl(item);
            view.type.selectedIndex = 0;
            view.txt_ownNum.text = $"拥有数量：{TextUtil.ChangeCoinShow(StorageModel.Instance.GetItemCount(item.ItemDefId))}";
        }
        view.txt_name.text = Lang.GetValue(item.Name);
        view.txt_des.text = Lang.GetValue(item.Description);
    }

}


