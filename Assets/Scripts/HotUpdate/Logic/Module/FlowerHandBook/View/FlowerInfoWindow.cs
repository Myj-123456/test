using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlowerInfoWindow : BaseWindow
{
   private fun_CultivationManual_new.FlowerInfoShow view;

   public FlowerInfoWindow()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.FlowerInfoShow.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivationManual_new.FlowerInfoShow;
        SetBg(view.bg, "HandBookNew/ELIDA_xhshengji_hyhs_bg.png");
        view.titleLab.text = Lang.GetValue("flower_info_16");
        
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var flowerId = (int)data;
        var item = ItemModel.Instance.GetItemById(flowerId);
        var bookTxtInfo = FLowerModel.Instance.GetBookTxtInfo(flowerId);
        var flowerInfo = FlowerHandbookModel.Instance.GetStaticSeedCondition(flowerId);
        view.nameLab.text = Lang.GetValue(item.Name);
        view.pot.url = "Cultivation/xianhuashengji_huaping.png";
        view.img.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(item);
        view.declab.text = "";
        view.rareImg.url = "HandBookNew/rare_icon_" + flowerInfo.FlowerQuality + ".png";

        view.keLab.text = Lang.GetValue("flower_info_23") + Lang.GetValue(bookTxtInfo.FlowerFamily);
        view.shuLab.text = Lang.GetValue("flower_info_24") + Lang.GetValue(bookTxtInfo.FlowerGenus);
        view.timeLab.text = Lang.GetValue("flower_info_25") + Lang.GetValue(bookTxtInfo.FlowerPeriod);

        view.introLab.text = Lang.GetValue(bookTxtInfo.FlowerIntroduction);
        view.declab.text = Lang.GetValue(bookTxtInfo.FlowerLanguage);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

