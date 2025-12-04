
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using protobuf.pets;
//using protobuf.fairy;
//using System;

//public class IntoBattleView : BaseView
//{
//   private fun_Tour_Land.into_battle view;
//    private UIHeroAvatar heroAvatar;
//    private int tabType;

//    private FairyDataConfig curFairy;
//    private PetDataConfig curPet;
//    private int petSelect = 0;
//    private int fairySelect = 0;
//    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
//    public IntoBattleView()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.into_battle.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.into_battle;
//        SetBg(view.bg, "Player/ELIDA_huibi_bg.jpg");
//        view.titleLab.text = Lang.GetValue("into_battle_1");
//        view.power_name.text = Lang.GetValue("power_name");

//        StringUtil.SetBtnTab(view.pet_btn, Lang.GetValue("into_battle_2"));
//        StringUtil.SetBtnTab(view.flower_god_btn, Lang.GetValue("into_battle_3"));

//        StringUtil.SetBtnTab3(view.pet_btn, Lang.GetValue("into_battle_2"));
//        StringUtil.SetBtnTab3(view.flower_god_btn, Lang.GetValue("into_battle_3"));


//        view.list.itemRenderer = RenderLsit;
//        view.list.SetVirtual();

//        heroAvatar = new UIHeroAvatar();
//        heroAvatar.Init(view.player);

//        view.pet_btn.onClick.Add(() =>
//        {
//            if(tabType != 0)
//            {
//                ChangeTab(0);
//            }
//        });

//        view.flower_god_btn.onClick.Add(() =>
//        {
//            if (tabType != 1)
//            {
//                ChangeTab(1);
//            }
//        });

//        view.pet1.onClick.Add(() =>
//        {
//            if(petSelect != 0)
//            {
//                petSelect = 0;
//            }
//        });
//        view.pet2.onClick.Add(() =>
//        {
//            if (petSelect != 1)
//            {
//                petSelect = 1;
//            }
//        });

//        view.flower_god1.onClick.Add(() =>
//        {
//            if(fairySelect != 0)
//            {
//                fairySelect = 0;
//            }
//        });

//        view.flower_god2.onClick.Add(() =>
//        {
//            if (fairySelect != 1)
//            {
//                fairySelect = 1;
//            }
//        });

//        view.flower_god3.onClick.Add(() =>
//        {
//            if (fairySelect != 2)
//            {
//                fairySelect = 2;
//            }
//        });

//        view.btn.onClick.Add(() =>
//        {
//            if (tabType == 0)
//            {
//                if((PlayerModel.Instance.pen.battlePets == null || Array.IndexOf(PlayerModel.Instance.pen.battlePets, (uint)curPet.Id) == -1))
//                {
//                    PetController.Instance.ReqBattlePet((uint)petSelect, (uint)curPet.Id);
//                }
//                else
//                {
//                    var select = Array.IndexOf(PlayerModel.Instance.pen.battlePets, (uint)curPet.Id);
//                    PetController.Instance.ReqBattlePet((uint)select, 0);
//                }
//            }
//            else
//            {
//               if(PlayerModel.Instance.pen.battleFairys == null || Array.IndexOf(PlayerModel.Instance.pen.battleFairys, (uint)curFairy.Id) == -1)
//                {
//                    FlowerGoldController.Instance.ReqBattleFairy((uint)fairySelect, (uint)curFairy.Id);
//                }
//                else
//                {
//                    var select = Array.IndexOf(PlayerModel.Instance.pen.battleFairys, (uint)curFairy.Id);
//                    FlowerGoldController.Instance.ReqBattleFairy((uint)select, 0);
//                }
//            }
//        });

//        AddEventListener(PetEvent.BattlePet, UpdateData);
//        AddEventListener(FlowerGoldEvent.BattleFairy, UpdateData);
//        EventManager.Instance.AddEventListener(SystemEvent.UpdatePower, UpdatePower);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        ChangeTab(0);
        
//        heroAvatar.UpdateDress();
//        UpdatePower();
//    }

//    private void UpdateData()
//    {
//        if (tabType == 0)
//        {
//            view.list.numItems = PetModel.Instance.petHome.Count;
            
//            UpdatePet();
//        }
//        else
//        {
//            view.list.numItems = FlowerGoldModel.Instance.fairyHome.Count;
//            UpdateFlowerGold();
//        }
//        UpdateBtnStatus();

//    }

//    private void UpdatePetList()
//    {
//        view.list.numItems = PetModel.Instance.petHome.Count;
//        if (PetModel.Instance.petHome.Count > 0)
//        {
//            curPet = PetModel.Instance.petHome[0];
//            view.list.selectedIndex = 0;
//        }
//        else
//        {
//            curPet = null;
//            view.list.selectedIndex = -1;
//        }
//        UpdateBtnStatus();
//    }

//    private void UpdateFairyList()
//    {
//        view.list.numItems = FlowerGoldModel.Instance.fairyHome.Count;
//        if (FlowerGoldModel.Instance.fairyHome.Count > 0)
//        {
//            curFairy = FlowerGoldModel.Instance.fairyHome[0];
//            view.list.selectedIndex = 0;
//        }
//        else
//        {
//            curFairy = null;
//            view.list.selectedIndex = -1;
//        }
//        UpdateBtnStatus();
//    }

//    private void ChangeTab(int type)
//    {
//        tabType = type;
//        if(tabType == 0)
//        {
//            PetModel.Instance.ParseBattleData();
//            UpdatePetList();
//            view.petSelect.selectedIndex = petSelect;
//            view.fairySelect.selectedIndex = 3;
//        }
//        else
//        {
//            FlowerGoldModel.Instance.ParseBattleData();
//            UpdateFairyList();
//            view.petSelect.selectedIndex = 2;
//            view.fairySelect.selectedIndex = fairySelect;
//        }
//        UpdatePet();
//        UpdateFlowerGold();
//    }
//    private void UpdateBtnStatus()
//    {
//        if (tabType == 0)
//        {
//            if(curPet != null)
//            {
//                view.btn.enabled = true;
//                var str = PlayerModel.Instance.pen.battlePets == null || Array.IndexOf(PlayerModel.Instance.pen.battlePets, (uint)curPet.Id) == -1 ? Lang.GetValue("fairy_20") : Lang.GetValue("fairy_21");
//                StringUtil.SetBtnTab(view.btn, str);
//            }
//            else
//            {
//                StringUtil.SetBtnTab(view.btn, Lang.GetValue("fairy_20"));
//                view.btn.enabled = false;
//            }
//        }
//        else
//        {
//            if (curFairy != null)
//            {
//                view.btn.enabled = true;
//                var str = PlayerModel.Instance.pen.battleFairys == null || Array.IndexOf(PlayerModel.Instance.pen.battleFairys, (uint)curFairy.Id) == -1 ? Lang.GetValue("fairy_20") : Lang.GetValue("fairy_21");
//                StringUtil.SetBtnTab(view.btn, str);
//            }
//            else
//            {
//                StringUtil.SetBtnTab(view.btn, Lang.GetValue("fairy_20"));
//                view.btn.enabled = false;
//            }
//        }
//    }
//    private void UpdatePet()
//    {
//        for(int i = 0;i < 2; i++)
//        {
//            var petItem = view.GetChild("pet" + (i + 1)) as fun_Tour_Land.pet_item;
//            if(PlayerModel.Instance.pen.battlePets != null&& PlayerModel.Instance.pen.battlePets.Length > i && PlayerModel.Instance.pen.battlePets[i] != 0)
//            {
//                var itemVo = ItemModel.Instance.GetItemById((int)PlayerModel.Instance.pen.battlePets[i]);
//                petItem.pet_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            }
//            else
//            {
//                petItem.pet_img.url = "";
//            }
            
//        }
//    }

//    private void UpdateFlowerGold()
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            var fairyItem = view.GetChild("flower_god" + (i + 1)) as fun_Tour_Land.flower_god_item;
//            if (PlayerModel.Instance.pen.battleFairys != null && PlayerModel.Instance.pen.battleFairys.Length > i && PlayerModel.Instance.pen.battleFairys[i] != 0)
//            {
//                var itemVo = ItemModel.Instance.GetItemById((int)PlayerModel.Instance.pen.battleFairys[i]);
//                fairyItem.pic.url = ImageDataModel.Instance.GetIconUrl1(itemVo);
//            }
//            else
//            {
//                fairyItem.pic.url = "";
//            }
                
//        }
//    }

//    private void RenderLsit(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.into_battle_item;
//        if(tabType == 0)
//        {
//            cell.type.selectedIndex = 0;
//            var petInfo = PetModel.Instance.petHome[index];
//            var itemVo = ItemModel.Instance.GetItemById(petInfo.Id);
//            cell.levelLab.text = Lang.GetValue("invite_friends_16", petInfo.Level.ToString());
//            cell.pet_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            cell.nameLab.text = Lang.GetValue(itemVo.Name);
//            cell.quality_img.url = "HandBookNew/bg_new_" + petInfo.Quality + ".png";
//            cell.nameLab.color = StringUtil.HexToColor(txtColorArr[petInfo.Quality - 1]);
//            cell.into.selectedIndex = PlayerModel.Instance.pen.battlePets == null || Array.IndexOf(PlayerModel.Instance.pen.battlePets, (uint)petInfo.Id) == -1 ? 0 : 1;
//            cell.data = petInfo;
//        }
//        else
//        {
//            cell.type.selectedIndex = 1;
//            var fairyInfo = FlowerGoldModel.Instance.fairyHome[index];
//            var itemVo = ItemModel.Instance.GetItemById(fairyInfo.Id);
//            cell.levelLab.text = Lang.GetValue("invite_friends_16", fairyInfo.Level.ToString());
//            cell.flower_god_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            cell.nameLab.text = Lang.GetValue(itemVo.Name);
//            cell.nameLab.color = StringUtil.HexToColor(txtColorArr[fairyInfo.Quality - 1]);
//            cell.into.selectedIndex = PlayerModel.Instance.pen.battleFairys == null || Array.IndexOf(PlayerModel.Instance.pen.battleFairys, (uint)fairyInfo.Id) == -1 ? 0 : 1;
//            cell.quality_img.url = "HandBookNew/bg_new_" + fairyInfo.Quality + ".png";
//            cell.data = fairyInfo;
//        }
//        cell.onClick.Add(ClickItem);
//    }

//    private void ClickItem(EventContext context)
//    {  
//        if(tabType == 0)
//        {
//            curPet = (context.sender as GComponent).data as PetDataConfig;
//        }
//        else
//        {
//            curFairy = (context.sender as GComponent).data as FairyDataConfig;
//        }
//        UpdateBtnStatus();
//    }
//    private void UpdatePower()
//    {
//        view.power_num.text = PlayerModel.Instance.pen.drawingPower.ToString();
//    }
//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

