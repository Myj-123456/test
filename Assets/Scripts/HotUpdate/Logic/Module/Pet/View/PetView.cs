
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class PetView : BaseView
//{
//   private fun_Pet.pet_view view;

//   public PetView()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_view;
//        SetBg(view.main.content.bg, "Pet/ELIDA_lingshou_wenquan_BG01.png");
//        view.titleLab.text = Lang.GetValue("pet_1");
//        view.main.content.tipLab.text = Lang.GetValue("pet_2");
//        StringUtil.SetBtnTab(view.fetters_btn, Lang.GetValue("pet_3"));
//        StringUtil.SetBtnTab(view.book_btn, Lang.GetValue("pet_4"));

//        view.main.scrollPane.posX = (view.main.content.width - view.main.width) / 2;
//        view.main.scrollPane.posY = (view.main.content.height - view.main.height) / 2;

//        view.main.content.spine1.url = "lingswq_c";
//        view.main.content.spine1.loop = true;
//        view.main.content.spine1.animationName = "idle";

//        view.main.content.spine2.url = "lingswq_b";
//        view.main.content.spine2.loop = true;
//        view.main.content.spine2.animationName = "idle";

//        view.main.content.spine3.url = "lingswq_a";
//        view.main.content.spine3.loop = true;
//        view.main.content.spine3.animationName = "idle";


//        view.book_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenPanel<PetbookView>(UIName.PetbookView);
//        });

//        view.fetters_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<FettersWindow>(UIName.FettersWindow);
//        });
//        view.main.content.call_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<ChoseTreasureWindow>(UIName.ChoseTreasureWindow);
//        });
//        view.help_btn.onClick.Add(() =>
//        {
            
//        });
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        //PetController.Instance.ReqPetInfo();
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

