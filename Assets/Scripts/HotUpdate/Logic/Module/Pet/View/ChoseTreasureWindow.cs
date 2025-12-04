
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;

//public class ChoseTreasureWindow : BaseWindow
//{
//   private fun_Pet.chose_treasure_view view;
//    private List<StorageItemVO> listData;
//    private StorageItemVO curItem;
//   public ChoseTreasureWindow()
//    {
//        packageName = "fun_Pet";
//        // 设置委托
//        BindAllDelegate = fun_Pet.fun_PetBinder.BindAll;
//        CreateInstanceDelegate = fun_Pet.chose_treasure_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Pet.chose_treasure_view;
//        StringUtil.SetBtnTab(view.close_btn, Lang.GetValue("common_button_cancel"));
//        StringUtil.SetBtnTab(view.sure_btn, Lang.GetValue("common_button_ok"));

//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        view.sure_btn.onClick.Add(CallPet);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        UpdateList();
//        UpdateBase();
        
//    }

//    private void UpdateList()
//    {
//        listData = PetModel.Instance.GetTreasureList();
        
//        view.list.numItems = listData.Count;
//        if (listData.Count > 0)
//        {
//            curItem = listData[0];
//            view.list.selectedIndex = 0;
//        }
//        else
//        {
//            curItem = null;
//            view.list.selectedIndex = -1;
//        }
//    }

//    private void UpdateBase()
//    {
//        if(curItem == null)
//        {
//            view.status.selectedIndex = 0;
//        }
//        else
//        {
//            view.status.selectedIndex = 1;
//            view.nameLab.text = Lang.GetValue(curItem.item.Name);
//            view.icon.url = ImageDataModel.Instance.GetIconUrl(curItem.item);
//        }
//    }

//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Pet.chose_treasure_item;
//        var itemData = listData[index];
//        cell.nameLab.text = Lang.GetValue(itemData.item.Name);
//        cell.numLab.text = TextUtil.ChangeCoinShow(itemData.count);
//        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemData.item);
//        cell.data = itemData;
//        cell.onClick.Add(ChoseTreasure);
//        LongPressGesture gesture = new LongPressGesture(cell);
//        gesture.trigger = 0.3f;
//        gesture.onAction.Add(OnGestureAction);
//    }

//    private void ChoseTreasure(EventContext context)
//    {
//        curItem = (context.sender as GComponent).data as StorageItemVO;
//        UpdateBase();
//    }

//    private void OnGestureAction(EventContext context)
//    {
//        var itemData = ((context.sender as LongPressGesture).host as GComponent).data as StorageItemVO;
//        UIManager.Instance.OpenWindow<TreasureInfoWindow>(UIName.TreasureInfoWindow,itemData.itemDefId);
//    }

//    private void CallPet()
//    {
//        if(curItem == null)
//        {
//            UILogicUtils.ShowNotice("请选择温泉宝物！");
//            return;
//        }
//        PetController.Instance.ReqPetDraw((uint)curItem.itemDefId);
//        Close();
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

