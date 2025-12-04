
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;

//public class FettersWindow : BaseWindow
//{
//   private fun_Pet.fetters_view view;
//    private List<Ft_pet_relationConfig> listData;

//   public FettersWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.fetters_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.fetters_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
//        view.titleLab.text = Lang.GetValue("pet_7") + Lang.GetValue("pet_3");
//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        listData = PetModel.Instance.GetPetRelationList();
//        view.list.numItems = listData.Count;
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Pet.fetters_item;
//        var relationInfo = listData[index];
//        cell.nameLab.text = Lang.GetValue(relationInfo.RelationName);
//        var petArr = relationInfo.PetCombinations;
//        cell.active.selectedIndex = PetModel.Instance.FettersActive(relationInfo.Id) ? 1 : 0;
//        cell.petList.itemRenderer = (int index, GObject item) =>
//        {
//            var petItem = item as fun_Pet.fetters_cell;
//            var petInfo = PetModel.Instance.GetPetInfo(petArr[index]);
//            petItem.unlock.selectedIndex = PetModel.Instance.GetPetServerData((uint)petInfo.Id) == null ? 1 : 0;
//            if(petInfo != null)
//            {
//                petItem.unlock.selectedIndex = petInfo.Unlock ? 0 : 1;
//                petItem.bg.url = "MyInfo/show_flower_bg" + petInfo.Quality + ".png";
//                var itemVo = ItemModel.Instance.GetItemById(petInfo.Id);
//                petItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            }
            
//        };
//        cell.petList.numItems = petArr.Length;
//        var attr = relationInfo.RelationAtts.Split(",");
//        string str = "";
//        foreach(var value in attr)
//        {
//            var nature = value.Split("#");
//            var attrInfo = PlayerModel.Instance.GetPlayerArr(int.Parse(nature[0]));
//            str += (str == ""?"":"，") + Lang.GetValue(attrInfo.AttributeName) + "+" + nature[1] + (int.Parse(nature[0]) > 4?"%":"");
//        }
//        cell.attrLab.text = str;
//    }


//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

