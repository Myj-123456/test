using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DressInfoWindow : BaseView
{
   private fun_Dress.dress_info_view view;
    private SuitConfig curInfo;
    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    private Dictionary<int, int> attrMap;
    private Dictionary<int, int> suitAttrMap;

    private UIHeroAvatar heroAvatar;
    public DressInfoWindow()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_info_view.CreateInstance;
        fairyBatching = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_info_view;
        SetBg(view.bg, "FlowerGold/ELIDA_huaxian_tcxiangqing_hxbg01.jpg");
        view.up_title.text = Lang.GetValue("dress_9");
        
        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(view.role);

        view.list.itemRenderer = RenderList;
        view.dress_list.itemRenderer = RenderDressList;
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var index = (int)data;
        curInfo = DressModel.Instance.dressHome[index];
        heroAvatar.UpdateDress(curInfo.ContainDress);
        view.list.numItems = curInfo.CollectNums.Length;
        view.skillShow.selectedIndex = curInfo.suitSkill > 0 ? 1 : 0;
        view.skillLab.text = view.nameLab.text = Lang.GetValue(curInfo.Name);
        view.nameLab.color = StringUtil.HexToColor(txtColorArr[curInfo.Quality - 1]);
        view.rare_img.url = "HandBookNew/rare_icon_" + curInfo.Quality + ".png";
        view.dress_list.numItems = curInfo.ContainDress.Length;
        if (curInfo.suitSkill > 0)
        {
            var skillInfo = DressModel.Instance.GetSuitSkillInfo(curInfo.suitSkill);
            view.skill.unlock.selectedIndex = curInfo.HaveCount < curInfo.CollectNums.Length ? 0 : 1;
            if(skillInfo.SkillType == 9 || skillInfo.SkillType == 11)
            {
                view.skillLab.text = Lang.GetValue("skill_dec_" + skillInfo.SkillType, skillInfo.SkillProb.ToString(), skillInfo.SkillConfigs[0].ToString());
            }
            else if(skillInfo.SkillType == 10)
            {
                view.skillLab.text = Lang.GetValue("skill_dec_" + skillInfo.SkillType, skillInfo.SkillProb.ToString(), skillInfo.SkillConfigs[0] + "-" + skillInfo.SkillConfigs[1]);
            }
            else
            {
                view.skillLab.text = Lang.GetValue("skill_dec_" + skillInfo.SkillType, skillInfo.SkillProb.ToString());
            }
            
        }
    }

    private void RenderDressList(int index, GObject item)
    {
        var cell = item as fun_Dress.DressPartItem1;
        var info = DressModel.Instance.GetDressInfo(curInfo.ContainDress[index]);
        var itemVo = ItemModel.Instance.GetItemById(info.ClothesId);
        cell.img_quality.url = "Dress/QualityIcon/ELIDA_huanzhuang_djd0" + info.Quality + ".png";
        cell.img_icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.unlock.selectedIndex = info.Unlock ? 0 : 1;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Dress.nature_item;
        int num = curInfo.CollectNums[index];
        var value = curInfo.CollectAdds[index];
        cell.natureLab.text = Lang.GetValue("dress_10", num.ToString(), value.ToString());
        cell.unlock.selectedIndex = num > curInfo.HaveCount ? 0 : 1;
    }

    /// <summary>
    ///随机播放主角idle动画
    /// </summary>
    private void heroPlayIdeAni()
    {
        string[] aniNames = new string[3] { "idle", "idle1", "idle3" };
        var idleIndex = Random.Range(0, aniNames.Length);
        heroAvatar.PlayAnimation(aniNames[idleIndex], true);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        BattleController.Instance.ReqModulePower(4);
    }
}

