
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class PetCallView : BaseView
//{
//   private fun_Pet.pet_call_view view;
//    private int pos;
//   public PetCallView()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_call_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_call_view;
//        SetBg(view.bg, "Pet/ELIDA_lingshou_wenquan_xiyinjieguo_BG.jpg");
//        view.titleLab.text = Lang.GetValue("pet_9");
//        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("levelup_button"));
//        view.get_btn.onClick.Add(() => {
//            Close();
//        });
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        view.com.pos.selectedIndex = PetModel.Instance.petItems.Count - 1;

//        UpdateData();
//    }

//    private void UpdateData()
//    {
//        for(int i = 0;i < PetModel.Instance.petItems.Count; i++)
//        {
//            var cell = view.com.GetChild("item" + (i + 1)) as fun_Pet.pet_call_item;
//            var itemVo = ItemModel.Instance.GetItemById(IDUtil.GetEntityValue(PetModel.Instance.petItems[i].itemId));
//            PetDataConfig petInfo = null;
//            if(itemVo.Type == 5701)
//            {
//                petInfo = PetModel.Instance.GetPetInfo1(itemVo.ItemDefId);
//                cell.have.selectedIndex = 1;
//                cell.nameLab.text = Lang.GetValue(ItemModel.Instance.GetItemById(petInfo.Id).Name);
//                cell.haveLab.text = Lang.GetValue("Vip_store_txt5");
//                cell.icon.url = ImageDataModel.Instance.GetIconUrl(ItemModel.Instance.GetItemById(petInfo.Id));
//                cell.shardLab.text = Lang.GetValue("pet_23", "x" + petInfo.ConvertNum);
//            }
//            else
//            {
//                petInfo = PetModel.Instance.GetPetInfo(itemVo.ItemDefId);
//                cell.have.selectedIndex = 0;
//                cell.nameLab.text = Lang.GetValue(itemVo.Name);
//                cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            }
//            cell.quality_img.url = "Pet/pet_qulity_"+ petInfo.Quality + ".png";
//            cell.rare_img.url = "HandBookNew/rare_icon_" + petInfo.Quality + ".png";
            
//            cell.data = i;
//            cell.onClick.Add(ChosePet);
//            cell.detail_btn.data = i;
//            cell.detail_btn.onClick.Add(DetailClick);
//        }
//    }

//    private void DetailClick(EventContext context)
//    {
//        var index = (int)(context.sender as GComponent).data;
//        var itemVo = ItemModel.Instance.GetItemById(IDUtil.GetEntityValue(PetModel.Instance.petItems[index].itemId));
//        PetDataConfig petInfo = null;
//        if (itemVo.Type == 5701)
//        {
//            petInfo = PetModel.Instance.GetPetInfo1(itemVo.ItemDefId);
//        }
//        else
//        {
//            petInfo = PetModel.Instance.GetPetInfo(itemVo.ItemDefId);
//        }
//        UIManager.Instance.OpenWindow<PetDetailWindow>(UIName.PetDetailWindow, petInfo.Id);
//    }

//    private void ChosePet(EventContext context)
//    {
//        pos = (int)(context.sender as GComponent).data;
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

