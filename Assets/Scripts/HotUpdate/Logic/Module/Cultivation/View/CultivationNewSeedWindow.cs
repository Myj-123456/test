//
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class CultivationNewSeedWindow : BaseWindow
//{
//   private fun_CultivateSeeds.cultivation_new_seed _view;
//    private int shareId;

//   public CultivationNewSeedWindow()
//    {
//        packageName = "fun_CultivateSeeds";
//        // 设置委托
//        BindAllDelegate = fun_CultivateSeeds.fun_CultivateSeedsBinder.BindAll;
//        CreateInstanceDelegate = fun_CultivateSeeds.cultivation_new_seed.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        _view = ui as fun_CultivateSeeds.cultivation_new_seed;

//        _view.share_btn.onClick.Add(ShareHandle);
//        StringUtil.SetBtnTab(_view.btn_ok, Lang.GetValue("gui_btn_sure"));
//        _view.reward_txt.text = Lang.GetValue("text_breed32");
//        _view.titleLab.text = Lang.GetValue("text_breed10");
//        _view.list.itemRenderer = ItemRender;

//        _view.btn_ok.onClick.Add(CloseView);
//    }

//    private void ShareHandle()
//    {

//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        int flowerdId = (int)data;
//        var staticItem = ItemModel.Instance.GetItemById(flowerdId);
//        shareId = FlowerHandbookModel.Instance.GetBookConfigByFlowerId(flowerdId).ShareId;
//        _view.img.url = ImageDataModel.Instance.GetIconUrl(staticItem);
//        _view.name_txt.text = Lang.GetValue(staticItem.Name);
//        _view.desc_txt.text = Lang.GetValue("text_breed11", Lang.GetValue(staticItem.Name));
//        _view.seed_img.url = ImageDataModel.Instance.GetIconUrlByItemId(PlantModel.Instance.GetPlantCropConfigData(flowerdId).Exp);
//        _view.shareStatus.selectedIndex = 1;
//    }

//    private void CloseView()
//    {
//        UIManager.Instance.CloseWindow(UIName.CultivationNewSeedWindow);
//    }

//    private void ItemRender(int index,GObject ItemRender)
//    {

//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

