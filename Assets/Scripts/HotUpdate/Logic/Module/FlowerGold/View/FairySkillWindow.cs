using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;

public class FairySkillWindow : BaseWindow
{
   private fun_FlowerGold.fairy_level_info_view view;
    private List<Ft_fairy_levelConfig> lvListData;
    private FairyDataConfig curInfo;
    public FairySkillWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.fairy_level_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.fairy_level_info_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int id = (int)data;
        lvListData = FlowerGoldModel.Instance.GetFairyLvList(id);
        curInfo = FlowerGoldModel.Instance.GetFairyInfo(id);
        view.list.numItems = lvListData.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_FlowerGold.fairy_level_info_item;
        
        var lvInfo = lvListData[index];
        var skillInfo = BattleModel.Instance.GetSkillConfig(lvInfo.SkillId);
        cell.lvLab.text = Lang.GetValue("levelup_explain", lvInfo.Level.ToString());
        cell.status.selectedIndex = lvInfo.Level <= curInfo.Level?0:1;
        cell.skillLab.text = Lang.GetValue(skillInfo.Name);
        var lvLock = GetUnlockLv(lvInfo.SkillId);
        if (lvLock == 1)
        {
            cell.limitLab.text = Lang.GetValue("fairy_12");
        }
        else
        {
            cell.limitLab.text = Lang.GetValue("fairy_13", lvLock.ToString());
        }
    }

    private int GetUnlockLv(long skillId)
    {
        foreach(var value in lvListData)
        {
            if(value.SkillId == skillId)
            {
                return value.Level;
            }
        }
        return 1;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

