
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using System;

//public class PetInfoView : BaseView
//{
//   private fun_Pet.pet_info_view view;
//    //private int curIndex;
//    private PetDataConfig CurPetData;

//    private int tabType = 0;

//   public PetInfoView()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_info_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_info_view;
//        SetBg(view.bg, "Pet/ELIDA_lingshou_wenquan_xiyinjieguo_BG.jpg");
//        view.titleLab.text = Lang.GetValue("pet_12");
//        view.titleLab.text = Lang.GetValue("pet_13");
//        view.natureLab.text = Lang.GetValue("pet_10");
//        view.skillLab.text = Lang.GetValue("pet_11");
        
//        view.needLab.text = Lang.GetValue("pet_16");
//        view.nature_lv.text = Lang.GetValue("pet_17");
//        view.item_cost.text = Lang.GetValue("pet_18");
//        StringUtil.SetBtnTab(view.info_btn, Lang.GetValue("setting_txt9"));
//        StringUtil.SetBtnTab(view.star_btn, Lang.GetValue("pet_14"));
//        StringUtil.SetBtnTab(view.lv_btn, Lang.GetValue("text_book13"));
//        StringUtil.SetBtnTab(view.pos_btn, Lang.GetValue("into_battle_1"));
//        StringUtil.SetBtnTab2(view.get_btn, Lang.GetValue("flower_info_30"));
//        StringUtil.SetBtnTab(view.starUp_btn, Lang.GetValue("pet_14"));
//        StringUtil.SetBtnTab(view.levelUp_btn, Lang.GetValue("text_book13"));

//        view.list.itemRenderer = RenderList;

//        view.info_btn.onClick.Add(() =>
//        {
//            if(tabType != 0)
//            {
//                ChangeTab(0);
//            }
//        });
//        view.star_btn.onClick.Add(() =>
//        {
//            if (tabType != 1)
//            {
//                ChangeTab(1);
//            }
//        });
//        view.lv_btn.onClick.Add(() =>
//        {
//            if (tabType != 2)
//            {
//                ChangeTab(2);
//            }
//        });

//        view.left_btn.onClick.Add(() =>
//        {
//            curIndex--;
//            ChangePet();
//        });

//        view.right_btn.onClick.Add(() =>
//        {
//            curIndex++;
//            ChangePet();
//        });

//        view.pos_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<PetIntoWindow>(UIName.PetIntoWindow, CurPetData.Id);
//        });

//        view.levelUp_btn.onClick.Add(() =>
//        {
//            PetController.Instance.ReqPetUpGradeLevel((uint)CurPetData.Id);
//        });
//        view.get_btn.onClick.Add(() =>
//        {
//            PetController.Instance.ReqPetExchange((uint)CurPetData.Id);
//        });
//        view.starUp_btn.onClick.Add(() =>
//        {
//            PetController.Instance.ReqPetStar((uint)CurPetData.Id, (uint)CurPetData.ShardId);
//        });

//        AddEventListener(PetEvent.PetUpGrade,UpdateLevel);
//        AddEventListener(PetEvent.PetStar,UpdateStar);
//        AddEventListener(PetEvent.PetExchange, UpdateStatus);
//        AddEventListener(PetEvent.BattlePet, UpdateStatus);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        curIndex = (int)data;
//        ChangePet();
//    }

//    private void ChangePet()
//    {
//        CurPetData = PetModel.Instance.petHome[curIndex];
//        UpdateStatus();
//        view.left_btn.enabled = curIndex > 0;
//        view.right_btn.enabled = curIndex < PetModel.Instance.petHome.Count - 1;
//    }

//    private void UpdateStatus()
//    {
//        var itemVo = ItemModel.Instance.GetItemById(CurPetData.Id);
//        view.nameLab.text = Lang.GetValue(itemVo.Name);
//        view.petImg.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        view.rare_img.url = "HandBookNew/rare_icon_" + CurPetData.Quality + ".png";
//        if (CurPetData.Unlock)
//        {
//            view.status.selectedIndex = 1;
//            if(PlayerModel.Instance.pen.battlePets != null && Array.IndexOf(PlayerModel.Instance.pen.battlePets,(uint)CurPetData.Id) != -1)
//            {
//                view.into.selectedIndex = 1;
//                view.intoLab.text = Lang.GetValue("pet_20");
//            }
//            else
//            {
//                view.into.selectedIndex = 0;
//                view.intoLab.text = Lang.GetValue("pet_19");
//            }
            
//            view.lvLab.text = Lang.GetValue("levelup_explain", "1");
//            ChangeTab(tabType);
//        }
//        else
//        {
//            view.intoLab.text = Lang.GetValue("rob_21");
//            view.into.selectedIndex = 1;
//            view.status.selectedIndex = 0;
//            var shardInfo = ItemModel.Instance.GetItemById(CurPetData.ShardId);
//            view.shard_img.url = ImageDataModel.Instance.GetIconUrl(shardInfo);
//            var count = StorageModel.Instance.GetItemCount(CurPetData.ShardId);
//            view.shardLab.text = Lang.GetValue(shardInfo.Name);
//            view.proBar.max = CurPetData.ComposeNum;
//            view.proBar.value = count;
//            view.proLab.text = TextUtil.ChangeCoinShow(count) + "/" + CurPetData.ConvertNum;
//            view.get_btn.enabled = CurPetData.ConvertNum <= count;
//        }
//    }

//    private void ChangeTab(int type)
//    {
//        tabType = type;
//        if(tabType == 0)
//        {
//            UpdateInfo();
//        }
//        else if(tabType == 1)
//        {
//            UpdateStar();
//        }
//        else
//        {
//            UpdateLevel();
//        }
//    }

//    private void UpdateInfo()
//    {
//        var petData = PetModel.Instance.GetPetServerData((uint)CurPetData.Id);
//        var starInfo = PetModel.Instance.GetStarInfo(CurPetData.Id, petData.starLevel);
//        var skillInfo = BattleModel.Instance.GetSkillConfig(starInfo.SkillId);
//        var curAtts = (double)CurPetData.BaseAtts + (CurPetData.LevelAtts * (petData.level - 1));
//        view.attackLab.text = Lang.GetValue("player_attack") + "：+" + curAtts + "%";
//        view.deffenLab.text = Lang.GetValue("player_defense") + "：+" + curAtts + "%";
//        view.hpLab.text = Lang.GetValue("player_hp") + "：+" + curAtts + "%";
//        view.comboLab.text = Lang.GetValue("combo_name") + "：+" + curAtts + "%";
//        view.skillDec.text = Lang.GetValue(skillInfo.Desc);
//    }

//    private void UpdateStar()
//    {
//        var petData = PetModel.Instance.GetPetServerData((uint)CurPetData.Id);
//        view.lvLab.text = Lang.GetValue("pet_21", petData.starLevel.ToString());
//        var curStarInfo = PetModel.Instance.GetStarInfo(CurPetData.Id, petData.starLevel);
        
//        if (CurPetData.IsStarMax)
//        {
//            view.max.selectedIndex = 1;
//            var skillInfo = BattleModel.Instance.GetSkillConfig(curStarInfo.SkillId);
//            view.skillTip.text = Lang.GetValue("pet_11");
//            view.skillDec.text = Lang.GetValue(skillInfo.Desc);
//        }
//        else
//        {
//            view.max.selectedIndex = 0;
//            view.skillTip.text = Lang.GetValue("pet_15");
//            var nextStarInfo = PetModel.Instance.GetStarInfo(CurPetData.Id, petData.starLevel + 1);
//            var skillInfo = BattleModel.Instance.GetSkillConfig(nextStarInfo.SkillId);
//            view.nextSkill.text = Lang.GetValue(skillInfo.Desc);
//            view.needItem.bg.url = "MyInfo/show_flower_bg" + CurPetData.Quality + ".png";

//            var itemVo = ItemModel.Instance.GetItemById(CurPetData.ShardId);
//            view.needItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            var count = StorageModel.Instance.GetItemCount(CurPetData.ShardId);
//            view.needItem.proLab.text = TextUtil.ChangeCoinShow(count) + "/" + curStarInfo.Cost;
//            view.starUp_btn.enabled = curStarInfo.Cost <= count;
//        }

//    }

//    private void UpdateLevel()
//    {
//        var petData = PetModel.Instance.GetPetServerData((uint)CurPetData.Id);
//        var curAtts = (double)CurPetData.BaseAtts + (CurPetData.LevelAtts * (petData.level - 1));
//        if (CurPetData.IsLevelMax)
//        {
//            view.max.selectedIndex = 1;
//            var curLevelInfo = PetModel.Instance.GetPetLevelInfo(petData.level);
//            int curLv = CurPetData.Quality == 5 ? curLevelInfo.Exps[3] : curLevelInfo.Exps[CurPetData.Quality - 1];
//            view.pro.max = curLv;
//            view.pro.value = petData.exp;
//            view.proLab1.text = petData.exp + "/" + curLv;
//        }
//        else
//        {
//            view.max.selectedIndex = 0;
//            var nextLevelInfo = PetModel.Instance.GetPetLevelInfo(petData.level + 1);
//            int nextLv = CurPetData.Quality == 5 ? nextLevelInfo.Exps[3] : nextLevelInfo.Exps[CurPetData.Quality - 1];
//            view.attackAdd.text = view.deffenAdd.text = view.hpAdd.text = view.comboAdd.text =  "+" + CurPetData.LevelAtts + "%";
//            view.pro.max = nextLv;
//            view.pro.value = petData.exp;
//            view.proLab1.text = petData.exp + "/" + nextLv;
//            view.nextLv.text = Lang.GetValue("levelup_explain", (petData.level + 1).ToString());
//            view.list.numItems = GlobalModel.Instance.module_profileConfig.petExpItem.Count;
//            view.levelUp_btn.enabled = GetTatolExp() >= (nextLv - petData.exp);
//        }
//        view.lvLab.text = Lang.GetValue("levelup_explain", petData.level.ToString());
//        view.curLv.text = Lang.GetValue("levelup_explain", petData.level.ToString());
//        view.attackLab1.text = Lang.GetValue("player_attack") + "：+" + curAtts + "%";
//        view.deffenLab1.text = Lang.GetValue("player_defense") + "：+" + curAtts + "%";
//        view.hpLab1.text = Lang.GetValue("player_hp") + "：+" + curAtts + "%";
//        view.comboLab1.text = Lang.GetValue("combo_name") + "：+" + curAtts + "%";

       
//    }

//    private int GetTatolExp()
//    {
//        int exp = 0;
//        for(int i = 0;i < GlobalModel.Instance.module_profileConfig.petExpItem.Count; i++)
//        {
//            var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.petExpItem[i]);
//            exp += count * GlobalModel.Instance.module_profileConfig.petExpItemNum[i];
//        }
//        return exp;
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Pet.level_cost_item;
//        var id = GlobalModel.Instance.module_profileConfig.petExpItem[index];
//        var itemVo = ItemModel.Instance.GetItemById(id);
//        var count = StorageModel.Instance.GetItemCount(id);
//        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.proLab.text = count.ToString();
//        cell.addLab.text = "+" + GlobalModel.Instance.module_profileConfig.petExpItemNum[index];
//        cell.data = index;
//        cell.onClick.Add(LevelUpItem);
//    }

//    private void LevelUpItem(EventContext context)
//    {
//        var index = (int)(context.sender as GComponent).data;
//        var id = GlobalModel.Instance.module_profileConfig.petExpItem[index];
//        var count = StorageModel.Instance.GetItemCount(id);
//        if(count > 0)
//        {
//            PetController.Instance.ReqPetUpGrade((uint)CurPetData.Id, (uint)id);
//        }
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

