//
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class CultivationNewTipWindow : BaseWindow
//{
//   private fun_CultivateSeeds.cultivation_new_tips _view;

//   public CultivationNewTipWindow()
//    {
//        packageName = "fun_CultivateSeeds";
//        // 设置委托
//        BindAllDelegate = fun_CultivateSeeds.fun_CultivateSeedsBinder.BindAll;
//        CreateInstanceDelegate = fun_CultivateSeeds.cultivation_new_tips.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        _view = ui as fun_CultivateSeeds.cultivation_new_tips;
//        StringUtil.SetBtnTab(_view.ok_btn, Lang.GetValue("common_button_ok"));
//        _view.ok_btn.onClick.Add(CloseView);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        var param = data as object[];
//        int flowerId = (int)data;
//        _view.title_txt.text = Lang.GetValue("text_breed6");
//        var item = ItemModel.Instance.GetItemById(flowerId);
//        if(item != null)
//        {
//            _view.nameLab.text = Lang.GetValue(item.Name);
//            _view.desc.text = Lang.GetValue("text_breed41");
//            _view.desc1.text = Lang.GetValue("text_breed40");
//            _view.img.url = ImageDataModel.Instance.GetIconUrl(item);
//        }
//    }

//    private void CloseView()
//    {
//        UIManager.Instance.CloseWindow(UIName.CultivationNewTipWindow);
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

