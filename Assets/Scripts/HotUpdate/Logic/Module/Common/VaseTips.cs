using Elida.Config;

public class VaseTips : BaseWindow
{
    private common_New.VaseTips view;
    public VaseTips()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.VaseTips.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as common_New.VaseTips;
    }

    public override void OnShown()
    {
        base.OnShown();
        var item = data as Module_item_defConfig;
        if (item == null) return;
        view.img_icon.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
        view.txt_name.text = Lang.GetValue(item.Name);
        view.txt_des.text = Lang.GetValue(item.Description);
        var staticFlowerPoint = IkeModel.Instance.GetStaticFlowerPoint(item.ItemDefId);
        if (staticFlowerPoint != null)
        {
            view.img_quality.url = "HandBookNew/bg_new_" + staticFlowerPoint.VaseQuality + ".png";
            bool unlock = IkeModel.Instance.IsUnlockVase(staticFlowerPoint.VaseId);
            view.txt_gain.text = unlock ? "已拥有" : "未拥有";
        }
    }

}


