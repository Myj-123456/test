using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ADK;
using protobuf.guild;

public class FlowerShareAlertWindow : BaseWindow
{
   private fun_GuildFlowerShare.flowerShare_alert _view;
    private FlowerShareAlert Alertdata;

   public FlowerShareAlertWindow()
    {
        packageName = "fun_GuildFlowerShare";
        // 设置委托
        BindAllDelegate = fun_GuildFlowerShare.fun_GuildFlowerShareBinder.BindAll;
        CreateInstanceDelegate = fun_GuildFlowerShare.flowerShare_alert.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_GuildFlowerShare.flowerShare_alert;

        //StringUtil.SetBtnTab(_view.btn_sure, Lang.GetValue("Share_txt28"));
        //StringUtil.SetBtnTab(_view.btn_cancel, Lang.GetValue("Share_txt29"));

        //_view.btn_cancel.onClick.Add(() =>
        //{
        //    if(Alertdata.CancelCallback != null)
        //    {
        //        Alertdata.CancelCallback();
        //    }
        //    UIManager.Instance.CloseWindow(UIName.FlowerShareAlertWindow);
        //});

        //_view.btn_sure.onClick.Add(() =>
        //{
        //    if (Alertdata.SureCallback != null)
        //    {
        //        Alertdata.SureCallback();
        //    }
        //    UIManager.Instance.CloseWindow(UIName.FlowerShareAlertWindow);
        //});
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //Alertdata = data as FlowerShareAlert;
        //InitView();
    }

    //private void InitView()
    //{
    //    _view.page.selectedIndex = Alertdata.type;
    //    switch (Alertdata.type)
    //    {
    //        case 0:
    //            _view.lb_title.text = Lang.GetValue("Share_txt5");
    //            _view.lb_info.text = Lang.GetValue("Share_txt22");
    //            int num = (int)Alertdata.data;
    //            _view.lb_count.text = num.ToString();
    //            break;
    //        case 1:
    //            _view.lb_title.text = Lang.GetValue("Share_txt19");
    //            _view.lb_info.text = Lang.GetValue("Share_txt19");
    //            _view.img_icon.url = ImageDataModel.CASH_ICON_URL;
    //            int count = (int)Alertdata.data;
    //            _view.lb_count.text = count.ToString();
    //            break;
    //        case 2:
    //            _view.lb_title.text = Lang.GetValue("Share_txt35");
    //            break;
    //        case 3:
    //            _view.lb_title.text = Lang.GetValue("Share_txt25");
    //            _view.lb_info.text = Lang.GetValue("Share_txt27");
    //            var seedData = Alertdata.data as SeedCropVO;
    //            _view.flower.img_flower.url = ImageDataModel.Instance.GetIconUrl(seedData.item);
    //            _view.lb_info.text = Lang.GetValue("Share_txt26", (seedData.level * 10).ToString(), Lang.GetValue(seedData.item.Name));
    //            break;
    //        case 4:
    //            _view.lb_title.text = Lang.GetValue("Share_txt23");
    //            var info = Alertdata.data as I_FLOWER_SHARE_VO;
    //            var item = ItemModel.Instance.GetItemByEntityID(info.flowerId);

    //            _view.lb_info.text = Lang.GetValue("Share_txt24",info.count.ToString(),Lang.GetValue(item.Name));
    //            _view.flower.img_flower.url = ImageDataModel.Instance.GetIconUrl(item);
    //            break;
    //    }
    //}

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

public class FlowerShareAlert
{
    public int type;
    public object data;
    public Action CancelCallback;
    public Action SureCallback;
    public FlowerShareAlert(int type,object data, Action SureCallback, Action CancelCallback = null)
    {
        this.type = type;
        this.data = data;
        this.CancelCallback = CancelCallback;
        this.SureCallback = SureCallback;
    }
}
