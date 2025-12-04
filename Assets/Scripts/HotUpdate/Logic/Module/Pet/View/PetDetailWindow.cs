
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class PetDetailWindow : BaseWindow
//{
//   private fun_Pet.pet_detail_view view;

//   public PetDetailWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_detail_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_detail_view;
//        SetBg(view.bg, "Pet/ELIDA_xhshengji_hyhs_bg.png");
//        SetBg(view.bg1, "Pet/ELIDA_xhshengji_hyhs_bg_guang.png");
//        view.natureLab.text = Lang.GetValue("pet_10");
//        view.skillLab.text = Lang.GetValue("pet_11");
//        view.haveLab.text = Lang.GetValue("Vip_store_txt5");
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        var id = (int)data;
//        var petInfo = PetModel.Instance.GetPetInfo(id);
//        var starInfo = PetModel.Instance.GetStarInfo(petInfo.Id, 1);
//        var skillInfo = BattleModel.Instance.GetSkillConfig(starInfo.SkillId);
//        var ItemVo = ItemModel.Instance.GetItemById(petInfo.Id);
//        view.nameLab.text = Lang.GetValue(ItemVo.Name);
//        view.skillDec.text = Lang.GetValue(skillInfo.Desc);
//        view.icon.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        view.attackLab.text = Lang.GetValue("player_attack") + "：+" + petInfo.BaseAtts + "%";
//        view.defenLab.text = Lang.GetValue("player_defense") + "：+" + petInfo.BaseAtts + "%";
//        view.hpLab.text = Lang.GetValue("player_hp") + "：+" + petInfo.BaseAtts + "%";
//        view.comboLab.text = Lang.GetValue("combo_name") + "：+" + petInfo.BaseAtts + "%";

//        view.rare_img.url = "HandBookNew/rare_icon_" + petInfo.Quality + ".png";
//        view.have.selectedIndex = petInfo.Unlock ? 1 : 0;

//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

