using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FairyDetailWindow : BaseWindow
{
   private fun_FlowerGold.fairy_detail_view view;

   public FairyDetailWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.fairy_detail_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.fairy_detail_view;
        SetBg(view.bg, "Pet/ELIDA_xhshengji_hyhs_bg.png");
        SetBg(view.bg1, "Pet/ELIDA_xhshengji_hyhs_bg_guang.png");
        view.natureLab.text = Lang.GetValue("fairy_10");
        view.skillLab.text = Lang.GetValue("pet_11");
        
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        var fairyInfo = FlowerGoldModel.Instance.GetFairyInfo(id);
        view.rare_img.url = "HandBookNew/rare_icon_" + fairyInfo.Quality + ".png";
        var itemVo = ItemModel.Instance.GetItemById(fairyInfo.Id);
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        var lvInfo = FlowerGoldModel.Instance.GetFairyLvInfo(fairyInfo.Id, fairyInfo.Level);
        var skillInfo = BattleModel.Instance.GetSkillConfig(lvInfo.SkillId);
        view.skillDec.text = Lang.GetValue(skillInfo.Desc);

        var attrs = FlowerGoldModel.Instance.GetFairyAttr(fairyInfo.Id, fairyInfo.Level);
        var attrList = FlowerGoldModel.Instance.GetFairyAttrList(attrs);
        view.list.itemRenderer = (int index, GObject item) =>
        {
            var cell = item as fun_FlowerGold.nature_txt;
            var attrInfo = PlayerModel.Instance.GetPlayerArr(attrList[index].type);
            if (attrInfo.ID > 4)
            {
                cell.attrLab.text = Lang.GetValue(attrInfo.AttributeName) + "：" + attrList[index].value + "%";
            }
            else
            {
                cell.attrLab.text = Lang.GetValue(attrInfo.AttributeName) + "：" + attrList[index].value;
            }
        };
        view.list.numItems = attrList.Count;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

