using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.item;
using ADK;

public class DressCallResultWindow : BaseWindow
{
   private fun_Dress.dress_call_result view;
    private List<StorageItemVO> dropList;
   public DressCallResultWindow()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_call_result.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_call_result;
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var itemList = data as List<I_ITEM_VO>;
        var len = itemList.Count;
        view.status.selectedIndex = len == 1 ? 0 : 1;
        dropList = new List<StorageItemVO>();
        for (int i = 0;i < len; i++)
        {
            var cell = view.GetChild("item" + i) as fun_Dress.dress_call_result_item;
            var itemVo = ItemModel.Instance.GetItemById(IDUtil.GetEntityValue(itemList[i].itemDefId));
            if (itemVo.Category == (int)CategoryType.Dress)
            {
                var dress = DressModel.Instance.GetDressConfig(IDUtil.GetEntityValue(itemList[i].itemDefId));
            }
            else
            {

            }
            cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            cell.nameLab.text = Lang.GetValue(itemVo.Name);
            var drop = new StorageItemVO();
            drop.itemDefId = itemVo.ItemDefId;
            drop.count = (int)itemList[i].count;
            dropList.Add(drop);
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        DropManager.ShowDrop(dropList,false);
    }
}

