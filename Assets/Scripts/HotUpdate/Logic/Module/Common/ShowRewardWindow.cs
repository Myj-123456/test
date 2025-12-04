using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowRewardWindow
{
   private static common.order_got _view;
    private static List<StorageItemVO> _itemVOList;

    public static void OnShown(object[] param)
    {
        if(_view == null)
        {
            _view = common.order_got.CreateInstance();
            _view.list.itemRenderer = ItemRenderer;
            _view.MakeFullScreen();
            _view.AddRelation(GRoot.inst, RelationType.Size);
        }
       
        _itemVOList = param[0] as List<StorageItemVO>;
        var pos = param[1] as float[];
        if(param.Length < 3)
        {
            _view.title.text = Lang.GetValue("slang_34");//可获得奖励：;
        }
        else
        {
            _view.title.text = param[2].ToString();
        }
        GRoot.inst.AddChild(_view);
        var posY = pos[1];
        if(posY + _view.pos.height > GRoot.inst.height)
        {
            _view.pos.y = GRoot.inst.height - _view.pos.height;
        }
        else
        {
            _view.pos.y = posY + 10;
        }

        _view.list.numItems = _itemVOList.Count;
    }

    private static void ItemRenderer(int index,GObject item)
    {
        var cell = item as common.order_got_item;
        var vo_ = _itemVOList[index];
        var itemVo = ItemModel.Instance.GetItemById(vo_.itemDefId);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);

        cell.txt_name.text = Lang.GetValue(itemVo.Name);
        if(vo_.count > 1)
        {
            cell.txt_num.text = vo_.count.ToString();
        }
        else
        {
            cell.txt_num.text = "";
        }
    }

    public static void HideShowReward()
    {
        if (_view.parent != null) _view.parent.RemoveChild(_view);
    }
}

