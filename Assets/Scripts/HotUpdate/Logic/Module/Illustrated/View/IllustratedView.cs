
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class IllustratedView : BaseView
//{
//   private fun_Ill.ill_view view;
//    private int tabType = 0;

//    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };

//    public IllustratedView()
//    {
//        packageName = "fun_Ill";
//        // 设置委托
//        BindAllDelegate = fun_Ill.fun_IllBinder.BindAll;
//        CreateInstanceDelegate = fun_Ill.ill_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Ill.ill_view;
//        StringUtil.SetBtnTab(view.flower_btn,Lang.GetValue("collection_suit_name_1"));
//        StringUtil.SetBtnTab(view.vase_btn, Lang.GetValue("text_grandma1"));
//        StringUtil.SetBtnTab(view.dress_btn, Lang.GetValue("adornTree_2"));
//        StringUtil.SetBtnTab(view.florist_btn, Lang.GetValue("room_titile"));
//        StringUtil.SetBtnTab(view.pet_btn, Lang.GetValue("pet_5"));
//        StringUtil.SetBtnTab(view.fairy_btn, Lang.GetValue("into_battle_3"));
//        view.list.SetVirtual();

//        view.flower_btn.onClick.Add(() =>
//        {
//            if (tabType != 0)
//            {
//                ChangeTab(0);
//            }
//        });
//        view.vase_btn.onClick.Add(() =>
//        {
//            if (tabType != 1)
//            {
//                ChangeTab(1);
//            }
//        });
//        view.dress_btn.onClick.Add(() =>
//        {
//            if (tabType != 2)
//            {
//                ChangeTab(2);
//            }
//        });
//        view.florist_btn.onClick.Add(() =>
//        {
//            if (tabType != 3)
//            {
//                ChangeTab(3);
//            }
//        });
//        view.pet_btn.onClick.Add(() =>
//        {
//            if (tabType != 4)
//            {
//                ChangeTab(4);
//            }
//        });
//        view.fairy_btn.onClick.Add(() =>
//        {
//            if (tabType != 5)
//            {
//                ChangeTab(5);
//            }
//        });
//        AddEventListener(IllEvent.IllCetCollect,UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        view.tab.selectedIndex = 0;
//        ChangeTab(0);
//    }

//    private void ChangeTab(int type)
//    {
//        tabType = type;
//        if (type == 0)
//        {
//            IllustratedModel.Instance.InitFlowerIllData();
//            view.list.itemRenderer = RenderFlowerList;
//            UpdateFlowerList();
//        }
//        else if(type == 1)
//        {
//            IllustratedModel.Instance.InitvaseIllData();
//            view.list.itemRenderer = RenderVaseList;
//            UpdateVaseList();
//        }
//        else if (type == 2)
//        {
//            IllustratedModel.Instance.InitDressIllData();
//            view.list.itemRenderer = RenderDressList;
//            UpdateDressList();
//        }
//        else if (type == 3)
//        {
//            IllustratedModel.Instance.InitFloristIllData();
//            view.list.itemRenderer = RenderFloristList;
//            UpdateFloristList();
//        }
//        else if (type == 4)
//        {
//            IllustratedModel.Instance.InitPetIllData();
//            view.list.itemRenderer = RenderPetList;
//            UpdatePetList();
//        }
//        else
//        {
//            IllustratedModel.Instance.InitFairyIllData();
//            view.list.itemRenderer = RenderFairyList;
//            UpdateFairyList();
//        }
       
//    }

//    private void UpdateData()
//    {
//        if (tabType == 0)
//        {
            
//            UpdateFlowerList();
//        }
//        else if (tabType == 1)
//        {
            
//            UpdateVaseList();
//        }
//        else if (tabType == 2)
//        {
            
//            UpdateDressList();
//        }
//        else if (tabType == 3)
//        {
            
//            UpdateFloristList();
//        }
//        else if (tabType == 4)
//        {
            
//            UpdatePetList();
//        }
//        else
//        {
            
//            UpdateFairyList();
//        }

//    }

//    private void UpdateFlowerList()
//    {
//        view.list.numItems = IllustratedModel.Instance.flowerIllData.Count;
//    }

//    private void UpdateVaseList()
//    {
//        view.list.numItems = IllustratedModel.Instance.vaseIllData.Count;
//    }
//    private void UpdateDressList()
//    {
//        view.list.numItems = IllustratedModel.Instance.dressIllData.Count;
//    }
//    private void UpdateFloristList()
//    {
//        view.list.numItems = IllustratedModel.Instance.floristIllData.Count;
//    }
//    private void UpdatePetList()
//    {
//        view.list.numItems = IllustratedModel.Instance.PetIllData.Count;
//    }
//    private void UpdateFairyList()
//    {
//        view.list.numItems = IllustratedModel.Instance.fairyIllData.Count;
//    }
//    private void RenderFlowerList(int index,GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;
//        cell.type.selectedIndex = 0;
//        var flowerData = IllustratedModel.Instance.flowerIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + flowerData.FlowerQuality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[flowerData.FlowerQuality - 1]);
//        var ItemVo = ItemModel.Instance.GetItemById(flowerData.FlowerId);
//        cell.flower_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(ItemVo.Name);

//        cell.redPoint.visible = flowerData.IllShowPoint || flowerData.UnLockReward;

//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }

//    private void RenderVaseList(int index, GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;
//        cell.type.selectedIndex = 1;
//        var vaseData = IllustratedModel.Instance.vaseIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + vaseData.VaseQuality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[vaseData.VaseQuality - 1]);
//        var ItemVo = ItemModel.Instance.GetItemById(vaseData.VaseId);
//        cell.vase_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(ItemVo.Name);

//        cell.redPoint.visible = vaseData.UnLockReward;

//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }

//    private void RenderDressList(int index, GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;
//        cell.type.selectedIndex = 2;
//        var dressData = IllustratedModel.Instance.dressIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + dressData.Quality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[dressData.Quality - 1]);
  
//        //cell.dress_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(dressData.Name);

//        cell.redPoint.visible = dressData.UnLockReward || dressData.IllShowPoint;

//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }
//    private void RenderFloristList(int index, GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;

//        cell.type.selectedIndex = 3;
//        var floristData = IllustratedModel.Instance.floristIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + floristData.Quality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[floristData.Quality - 1]);

//        //cell.dress_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(floristData.Name);

//        cell.redPoint.visible = floristData.UnLockReward;

//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }
//    private void RenderPetList(int index, GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;

//        cell.type.selectedIndex = 4;
//        var petData = IllustratedModel.Instance.PetIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + petData.Quality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[petData.Quality - 1]);
//        var ItemVo = ItemModel.Instance.GetItemById(petData.Id);
//        cell.pet_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(ItemVo.Name);

//        cell.redPoint.visible = petData.UnLockReward || petData.IllShowPoint;

//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }

//    private void RenderFairyList(int index, GObject item)
//    {
//        var cell = item as fun_Ill.ill_item;

//        cell.type.selectedIndex = 5;
//        var fairyData = IllustratedModel.Instance.fairyIllData[index];
//        cell.bg.url = "HandBookNew/bg_new_" + fairyData.Quality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[fairyData.Quality - 1]);
//        var ItemVo = ItemModel.Instance.GetItemById(fairyData.Id);
//        cell.fairy_img.url = ImageDataModel.Instance.GetIconUrl(ItemVo);
//        cell.nameLab.text = Lang.GetValue(ItemVo.Name);

//        cell.redPoint.visible = fairyData.UnLockReward || fairyData.LevelReward;
//        cell.data = index;
//        cell.onClick.Add(GetReward);
//    }
//    private void GetReward(EventContext context)
//    {
//        var item = context.sender as fun_Ill.ill_item;
//        var index = (int)item.data;
//        if(item.type.selectedIndex == 0)
//        {
//            var flowerData = IllustratedModel.Instance.flowerIllData[index];
//            if (flowerData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)flowerData.FlowerId,1,1);
//            }else if (flowerData.LevelReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)flowerData.FlowerId, 1, 2);
//            }
//            else if (flowerData.GradeReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)flowerData.FlowerId, 1, 3);
//            }
//        }
//        else if(item.type.selectedIndex == 1)
//        {
//            var vaseData = IllustratedModel.Instance.vaseIllData[index];
//            if (vaseData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)vaseData.VaseId, 2, 1);
//            }
//        }
//        else if (item.type.selectedIndex == 2)
//        {
//            var dressData = IllustratedModel.Instance.dressIllData[index];
//            if (dressData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)dressData.Id, 3, 1);
//            }else if (dressData.LevelReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)dressData.Id, 3, 2);
//            }
//            else if (dressData.GradeReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)dressData.Id, 3, 3);
//            }
//        }
//        else if (item.type.selectedIndex == 3)
//        {
//            var floristData = IllustratedModel.Instance.floristIllData[index];
//            if (floristData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)floristData.Id, 4, 1);
//            }
//        }
//        else if (item.type.selectedIndex == 4)
//        {
//            var petData = IllustratedModel.Instance.PetIllData[index];
//            if (petData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)petData.Id, 5, 1);
//            }else if (petData.LevelReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)petData.Id, 5, 2);
//            }else if (petData.GradeReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)petData.Id, 5, 3);
//            }
//        }
//        else
//        {
//            var fairyData = IllustratedModel.Instance.fairyIllData[index];
//            if (fairyData.UnLockReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)fairyData.Id, 6, 1);
//            }else if (fairyData.LevelReward)
//            {
//                IllustratedController.Instance.ReqIllCetCollect((uint)fairyData.Id, 6, 2);
//            }
//        }
//    }
//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

