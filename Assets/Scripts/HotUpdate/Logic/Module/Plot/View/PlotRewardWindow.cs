using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class PlotRewardWindow : BaseWindow
{
   private fun_Plot.plot_reward_view view;
    private List<StorageItemVO> listData;
   public PlotRewardWindow()
    {
        packageName = "fun_Plot";
        // 设置委托
        BindAllDelegate = fun_Plot.fun_PlotBinder.BindAll;
        CreateInstanceDelegate = fun_Plot.plot_reward_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Plot.plot_reward_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        StringUtil.SetBtnTab(view.sure_btn, Lang.GetValue("levelup_button"));
        view.list.itemRenderer = RenderList;
        view.sure_btn.onClick.Add(() =>
        {
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        listData = data as List<StorageItemVO>;
        view.list.numItems = listData.Count;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Plot.reward_item;
        var info = listData[index];
        var itemVo = ItemModel.Instance.GetItemById(info.itemDefId);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.nameLab.text = Lang.GetValue(itemVo.Name);
        cell.numLab.text = TextUtil.ChangeCoinShow(info.count);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

