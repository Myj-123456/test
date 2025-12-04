
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class LevelInfoWindow : BaseWindow
//{
//   private fun_Pet.level_info_view view;
//    private bool inited = false;

//    public LevelInfoWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.level_info_view.CreateInstance;
//        ClickBlankClose = true;
//        fairyBatching = false;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.level_info_view;
//        view.attackLab.text = Lang.GetValue("player_attack") + "：";
//        view.defenLab.text = Lang.GetValue("player_defense") + "：";
//        view.hpLab.text = Lang.GetValue("player_hp") + "：";
//        view.comboLab.text = Lang.GetValue("combo_name") + "：";
//        PlaySpine();

//    }

//    private void PlaySpine()
//    {
//        if (!inited)
//        {
//            view.spine.url = "gongxihuode";
//            view.spine.Complete = OnAnimationEventHandler;
//            view.spine.forcePlay = true;
//            inited = true;
//        }

//        //view.anim.Play();
//        view.spine.loop = false;
//        view.spine.animationName = "open";
//    }

//    private void OnAnimationEventHandler(string name)
//    {
//        if (name == "open")
//        {
//            view.spine.loop = true;
//            view.spine.animationName = "loop";
//        }
        
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        if (inited)
//        {
//            PlaySpine();
//        }
//        var levelInfo = data as LevelData;
//        var petInfo = PetModel.Instance.GetPetInfo(levelInfo.petId);
//        view.attackNum.text = view.defenNum.text = view.hpNum.text = view.comboNum.text = ((double)petInfo.BaseAtts + petInfo.LevelAtts * (levelInfo.lastLv - 1)).ToString() + "%";
//        view.attackNum1.text = view.defenNum1.text = view.hpNum1.text = view.comboNum1.text = ((double)petInfo.BaseAtts + petInfo.LevelAtts * (levelInfo.curLv - 1)).ToString() + "%"; ;
//        view.curLv.text = Lang.GetValue("levelup_explain", levelInfo.lastLv.ToString());
//        view.nextLv.text = Lang.GetValue("levelup_explain", levelInfo.curLv.ToString());

//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

