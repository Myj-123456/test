using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;

public class FairyFettersWindow : BaseWindow
{
   private fun_FlowerGold.fetters_view view;
    private List<Ft_fairy_relationConfig> listData;

    public FairyFettersWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.fetters_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.fetters_view;

        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.titleLab.text = Lang.GetValue("into_battle_3") + Lang.GetValue("pet_3");
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        listData = FlowerGoldModel.Instance.fairyRelatMap;
        view.list.numItems = listData.Count;
    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_FlowerGold.fetters_item;
        var relationInfo = listData[index];
        cell.nameLab.text = Lang.GetValue(relationInfo.RelationName);
        var fairyArr = relationInfo.FairyCombinations;
        cell.active.selectedIndex = FlowerGoldModel.Instance.FettersActive(relationInfo.Id) ? 1 : 0;
        cell.petList.itemRenderer = (int index, GObject item) =>
        {
            var petItem = item as fun_FlowerGold.fetters_cell;
            var fairyInfo = FlowerGoldModel.Instance.GetFairyInfo(fairyArr[index]);
            petItem.unlock.selectedIndex = FlowerGoldModel.Instance.GetFairyServerData((uint)fairyInfo.Id) == null ? 1 : 0;
            if (fairyInfo != null)
            {
                petItem.bg.url = "MyInfo/show_flower_bg" + fairyInfo.Quality + ".png";
                var itemVo = ItemModel.Instance.GetItemById(fairyInfo.Id);
                petItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            }

        };
        cell.petList.numItems = fairyArr.Length;
        var attr = relationInfo.RelationAtts.Split(",");
        string str = "";
        var add = (float)FlowerGoldModel.Instance.GetRelationLevel(relationInfo.Id) * (float)relationInfo.LevelAtts / 10f;
        foreach (var value in attr)
        {
            var nature = value.Split("#");
            var attrInfo = PlayerModel.Instance.GetPlayerArr(int.Parse(nature[0]));
            str += (str == "" ? "" : "，") + Lang.GetValue(attrInfo.AttributeName) + "+" + (float.Parse(nature[1]) + add) + (int.Parse(nature[0]) > 4?"%":"");
        }
        cell.attrLab.text = str;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

