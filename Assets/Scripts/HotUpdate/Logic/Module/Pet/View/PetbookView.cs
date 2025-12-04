
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class PetbookView : BaseView
//{
//   private fun_Pet.pet_book_view view;
//    private int curQuality = 0;

//    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
//    public PetbookView()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.pet_book_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.pet_book_view;
//        SetBg(view.bg, "Pet/ELIDA_lingshou_wenquan_tuce_BG.png");
//        view.titleLab.text = Lang.GetValue("pet_6");
//        StringUtil.SetBtnTab(view.chose_btn, Lang.GetValue("guild_Match_3"));

//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        view.chose_grp.list.itemRenderer = RenderQualityList;

//        view.chose_btn.onClick.Add(() =>
//        {
//            if (view.showChose.selectedIndex == 1)
//            {
//                view.showChose.selectedIndex = 0;
//            }
//            else
//            {
//                view.showChose.selectedIndex = 1;
//            }

//        });

//        AddEventListener(PetEvent.PetExchange, UpdataList);
//        AddEventListener(PetEvent.PetUpGrade, UpdataList);
//        AddEventListener(PetEvent.PetStar, UpdataList);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        InitUI();
//        PetModel.Instance.FilterBookData(curQuality);
//        UpdataList();
//    }


//    private void InitUI()
//    {
//        curQuality = 0;
//        view.chose_grp.quality.selectedIndex = curQuality;
//        InitQualityList();
//        view.showChose.selectedIndex = 0;
//    }

//    private void InitQualityList()
//    {
//        view.chose_grp.list.numItems = 5;
//        view.chose_grp.quality.selectedIndex = curQuality > 4 ? 4 : curQuality;
//        StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("pet_quality_" + curQuality));
//    }

//    private void UpdataList()
//    {
        
//        view.list.numItems = PetModel.Instance.petHome.Count;
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Pet.pet_book_item;
//        var petData = PetModel.Instance.petHome[index];
//        var itemVo = ItemModel.Instance.GetItemById(petData.Id);
//        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.nameLab.text = Lang.GetValue(itemVo.Name);
//        if (petData.Unlock)
//        {
//            cell.status.selectedIndex = 1;
//            var petServerData = PetModel.Instance.GetPetServerData((uint)petData.Id);
//            if (petData.IsLevelMax)
//            {
//                cell.levelLab.text = Lang.GetValue("guild.bt_manage_full");
                
//            }
//            else
//            {
//                cell.levelLab.text = Lang.GetValue("invite_friends_16", petServerData.level.ToString());
//            }
            
//            cell.stars.itemRenderer = (int index, GObject item) =>
//            {
//                var star = item as fun_Pet.star_item;
//                int num = petServerData.starLevel / 2;
//                star.status.selectedIndex = num >= (index + 1) ? 1 : 0;
//            };
//            cell.stars.numItems = 5;
//            cell.show_lv.visible = PetModel.Instance.IsCanLevelStar(petData.Id);
//        }
//        else
//        {
//            cell.show_lv.visible = false;
//            cell.status.selectedIndex = 0;
//            var shardInfo = ItemModel.Instance.GetItemById(petData.ShardId);
//            cell.shard_img.url = ImageDataModel.Instance.GetIconUrl(shardInfo);
//            var count = StorageModel.Instance.GetItemCount(petData.ShardId);
//            cell.pro.max = petData.ComposeNum;
//            cell.pro.value = count;
//            cell.proLab.text = TextUtil.ChangeCoinShow(count) + "/" + petData.ConvertNum;
//            if(petData.ConvertNum > count)
//            {
//                cell.tipLab.text = "";
//            }
//            else
//            {
//                cell.tipLab.text = Lang.GetValue("flower_info_27");
//            }
//        }
//        cell.bg.url = "HandBookNew/bg_new_" + petData.Quality + ".png";
//        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[petData.Quality - 1]);
//        cell.data = index;
//        cell.onClick.Add(OpenInfoView);
//    }

//    private void OpenInfoView(EventContext context)
//    {
//        var index = (int)(context.sender as GComponent).data;
//        UIManager.Instance.OpenPanel<PetInfoView>(UIName.PetInfoView,UILayer.UI,index);
//    }

//    private void RenderQualityList(int index, GObject item)
//    {
//        var cell = item as fun_Pet.chose_quality_item;
//        if (index == 0)
//        {
//            cell.quality_img.url = "";
//            cell.titileLab.text = Lang.GetValue("guild_Match_3");
//        }
//        else
//        {
//            cell.quality_img.url = "HandBookNew/rare_icon_" + (index == 4?5:index) + ".png";
//            cell.titileLab.text = Lang.GetValue("pet_quality_" + (index == 4 ? 5 : index));
//        }
//        cell.data = index == 4 ? 5 : index;
//        cell.onClick.Add(ChoseQualityClick);
//    }

//    private void ChoseQualityClick(EventContext context)
//    {
//        int type = (int)(context.sender as GComponent).data;
//        if (type != curQuality)
//        {
//            curQuality = type;
//            view.chose_grp.quality.selectedIndex = curQuality > 4?4: curQuality;
//            StringUtil.SetBtnTab(view.chose_btn, curQuality == 0 ? Lang.GetValue("guild_Match_3") : Lang.GetValue("pet_quality_" + curQuality));
//            view.showChose.selectedIndex = 0;
//            PetModel.Instance.FilterBookData(curQuality);
//            UpdataList();
//        }
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

