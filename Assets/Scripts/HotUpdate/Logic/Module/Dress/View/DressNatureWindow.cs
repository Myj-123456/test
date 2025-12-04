using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DressNatureWindow : BaseWindow
{
   private fun_Dress.dress_nature_view view;
    private Dictionary<int, int> skillMap;
    private List<int> skillList;
    public DressNatureWindow()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_nature_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_nature_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.tipLab1.text = Lang.GetValue("dress_11");
        view.tipLab2.text = Lang.GetValue("dress_12");
        view.tipLab3.text = Lang.GetValue("dress_13");
        view.dressLab.text = Lang.GetValue("dress_14");
        view.suitLab.text = Lang.GetValue("dress_15");

        view.list.itemRenderer = RenderList;

        view.nature_list.itemRenderer = RenderNatureLsit;
        view.nature_list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.charmNum.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.dressCharm);
        view.dressNum.text = TextUtil.ChangeCoinShow(DressModel.Instance.GetDressCharm());
        view.suitNum.text = TextUtil.ChangeCoinShow(DressModel.Instance.GetSuitCharm());
        view.list.numItems = 5;
        skillMap = DressModel.Instance.GetSkillBuff();
        skillList = skillMap.Keys.ToList();
        skillList.Sort();
        view.nature_list.numItems = skillList.Count;
        view.show.selectedIndex = skillList.Count > 0 ? 0 : 1;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Dress.nature_item3;
        cell.rare_img.url = "HandBookNew/rare_icon_" + (index + 1) + ".png";
        var proInfo = DressModel.Instance.GetDressCollectPro(index + 1);
        cell.pro.max = proInfo[1];
        cell.pro.value = proInfo[0];
        cell.proLab.text = proInfo[0] + "/" + proInfo[1];
    }
    private void RenderNatureLsit(int index,GObject item)
    {
        var cell = item as fun_Dress.nature_item4;
        var skill = skillMap[skillList[index]];
        if(skillList[index]  == 9 || skillList[index] == 11)
        {
            var skillInfo = DressModel.Instance.GetSuitSkillInfo1(skillList[index]);
            cell.decLab.text = Lang.GetValue("skill_dec_" + skillList[index], skill.ToString(), skillInfo.SkillConfigs[0].ToString());
        }
        else if(skillList[index] == 10)
        {
            var skillInfo = DressModel.Instance.GetSuitSkillInfo1(skillList[index]);
            cell.decLab.text = Lang.GetValue("skill_dec_" + skillList[index], skill.ToString(), skillInfo.SkillConfigs[0] + "-" + skillInfo.SkillConfigs[1]);
        }
        else
        {
            cell.decLab.text = Lang.GetValue("skill_dec_" + skillList[index], skill.ToString());
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

