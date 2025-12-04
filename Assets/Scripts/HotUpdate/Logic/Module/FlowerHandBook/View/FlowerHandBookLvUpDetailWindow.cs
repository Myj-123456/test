using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;
using Elida.Config;

public class FlowerHandBookLvUpDetailWindow : BaseWindow
{
   private fun_CultivationManual_new.handbookLevelUpDetail view;
    private List<Ft_hua_levelConfig> _featureList;

   public FlowerHandBookLvUpDetailWindow()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.handbookLevelUpDetail.CreateInstance;
        _featureList = new List<Ft_hua_levelConfig>();
        //_originDescs = Lang.GetValue("text_handbook1").Split("|").ToList();
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivationManual_new.handbookLevelUpDetail;
        view.titleLab.text = Lang.GetValue("flower_info_18");
        SetBg(view.bg,"Common/ELIDA_common_bigdi01.png");
        view.levelLab.text = Lang.GetValue("slang_27");

        view.timeLab.text = Lang.GetValue("flower_info_19");
        view.seedLab.text = Lang.GetValue("flower_info_20");
        view.flowerLab.text = Lang.GetValue("flower_info_21");
        view.countLab.text = Lang.GetValue("flower_info_22");
        view.list.itemRenderer = RenderItem;
        view.list.SetVirtual();
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)data);
        var crop = PlantModel.Instance.GetPlantCropConfigList(condition.LevelMould);
        crop.Sort((a, b) => a.Level - b.Level);
        if (crop != null)
        {
            _featureList.Clear();
            _featureList = crop;



            view.list.numItems = _featureList.Count;
        }
    }

    private void RenderItem(int index,GObject cell)
    {
        var item = cell as fun_CultivationManual_new.NoticeScrollListItem;
        item.levelLab.text = (index + 1).ToString();
        item.timeLab.text = TextUtil.ChangeTimeShow(_featureList[index].Interval);

        item.seedLab.text = _featureList[index].SeedProp.ToString();
        item.flowerLab.text = _featureList[index].CropCount.ToString();
        item.countLab.text = _featureList[index].Frequency.ToString();
        if (index != 0)
        {
            item.timeLab.color = _featureList[index].Interval != _featureList[index - 1].Interval ? StringUtil.HexToColor("#5ACF60") : StringUtil.HexToColor("#777E70");
            item.seedLab.color = _featureList[index].SeedProp != _featureList[index - 1].SeedProp ? StringUtil.HexToColor("#5ACF60") : StringUtil.HexToColor("#777E70");
            item.flowerLab.color = _featureList[index].CropCount != _featureList[index - 1].CropCount ? StringUtil.HexToColor("#5ACF60") : StringUtil.HexToColor("#777E70");
            item.countLab.color = _featureList[index].Frequency != _featureList[index - 1].Frequency ? StringUtil.HexToColor("#5ACF60") : StringUtil.HexToColor("#777E70");
        }
        else
        {
            item.timeLab.color =  StringUtil.HexToColor("#777E70");
            item.seedLab.color = StringUtil.HexToColor("#777E70");
            item.flowerLab.color =  StringUtil.HexToColor("#777E70");
            item.countLab.color =  StringUtil.HexToColor("#777E70");
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}


