
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using Elida.Config;
//using ADK;

//public class TreasureInfoWindow : BaseWindow
//{
//   private fun_Pet.treasure_info_view view;
//    private Ft_pet_itemConfig curItem;

//    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
//    public TreasureInfoWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.treasure_info_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.treasure_info_view;
//        SetBg(view.bg, "Pet/ELIDA_xhshengji_hyhs_bg.png");
//        SetBg(view.bg1, "Pet/ELIDA_xhshengji_hyhs_bg_guang.png");
//        view.subtitleLab.text = Lang.GetValue("pet_8");

//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        var id = (int)data;
//        curItem = PetModel.Instance.GetPetItemInfo(id);
//        var itemVo = ItemModel.Instance.GetItemById(curItem.Id);
//        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        view.nameLab.text = Lang.GetValue(itemVo.Name);
//        view.list.numItems = curItem.SummonPets.Length;

//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Pet.treasure_info_item;
//        var petInfo = PetModel.Instance.GetPetInfo(curItem.SummonPets[index]);
//        cell.nameLab.text = Lang.GetValue(petInfo.Name);
//        var itemVo = ItemModel.Instance.GetItemById(petInfo.Id);
//        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[petInfo.Quality - 1]);
//        cell.bg.url = "MyInfo/show_flower_bg"+ petInfo.Quality + ".png";
//        cell.proLab.text = curItem.SummonPetProbs[index] + "%";


//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

