
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class PetIntoWindow : BaseWindow
//{
//   private fun_Pet.pet_into_view view;
//    private int petId;
//    private int pos;
//   public PetIntoWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_into_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_into_view;
//        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
//        view.titleLab.text = Lang.GetValue("pet_23");
//        view.tipLab.text = Lang.GetValue("pet_22");
//        StringUtil.SetBtnTab(view.sure_btn, Lang.GetValue("levelup_button"));
//        view.item1.onClick.Add(() =>
//        {
//            if(pos != 0)
//            {
//                pos = 0;
//            }
//        });
//        view.item2.onClick.Add(() =>
//        {
//            if (pos != 1)
//            {
//                pos = 1;
//            }
//        });

//        view.sure_btn.onClick.Add(() =>
//        {
//            PetController.Instance.ReqBattlePet((uint)pos, (uint)petId);
//            Close();
//        });
//    }

//    public override void OnShown()
//    {
//        base.OnShown(); 
//        // 其他打开面板的逻辑
//        petId = (int)data;
//        pos = 0;
//        view.select.selectedIndex = 0;
//        var itemVo = ItemModel.Instance.GetItemById(petId);
//        view.item1.icon1.url = view.item2.icon1.url = "";
//        view.item1.icon.url = view.item2.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

