using ADK;
using Elida.Config;
using FairyGUI;

public class FlowerTips : BaseWindow
{
    private common_New.ItemFlowerTips view;
    public FlowerTips()
    {
        packageName = "common_New";
        // 设置委托
        BindAllDelegate = common_New.common_NewBinder.BindAll;
        CreateInstanceDelegate = common_New.ItemFlowerTips.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as common_New.ItemFlowerTips;
        SetBg(view.bg, "Common/ELIDA_xhshengji_hyhs_bg.png");
        view.sub_title.text = Lang.GetValue("flower_info_16");
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("system01"));
        view.txt_ownNum.text = Lang.GetValue("recharge_main_30");
        view.goto_btn.onClick.Add(() =>
        {
            UIManager.Instance.CloseAllWindown();
            UIManager.Instance.OpenPanel<CultivationView>(UIName.CultivationView);
        });
    }


    private int flowerId;
    private Module_item_defConfig item;
    public override void OnShown()
    {
        base.OnShown();
        item = data as Module_item_defConfig;
        if (item == null) return;
        flowerId = item.ItemDefId;
        view.img_icon.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(item);
        view.txt_name.text = Lang.GetValue(item.Name);
        view.txt_des.text = Lang.GetValue(item.Description);

        var condition = item.Type == 4001? FlowerHandbookModel.Instance.GetStaticSeedCondition(item.ItemDefId): FlowerHandbookModel.Instance.GetStaticSeedCondition1(item.ItemDefId);
        view.img_quality.url = "HandBookNew/rare_icon_" + condition.FlowerQuality + ".png";
        for(int i = 0;i < condition.ItemIds.Count; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as common_New.Item_flower_need;
            var need = condition.ItemIds[i];
            var itemVo = ItemModel.Instance.GetItemByEntityID(need.EntityID);
            var count = StorageModel.Instance.GetItemCount(need.EntityID);
            cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.numLab.text = (count < need.Value ? "<font color = '#f7883f'>" : "<font color = '#ffffff'>") + count + "</font>/" + need.Value;
            cell.nameLab.text = Lang.GetValue(itemVo.Name);
        }
    }
}


