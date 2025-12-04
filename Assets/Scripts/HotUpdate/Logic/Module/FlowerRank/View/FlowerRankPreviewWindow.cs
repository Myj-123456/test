using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;

public class FlowerRankPreviewWindow : BaseWindow
{
    private fun_FlowerRankingList.FlowerRankPreview view;

    private fun_FlowerRankingList.FlowerRankPreviewScrollPane panel;

    private List<FlowerRankData> configList;
    public FlowerRankPreviewWindow()
    {
        packageName = "fun_FlowerRankingList";
        // 设置委托
        BindAllDelegate = fun_FlowerRankingList.fun_FlowerRankingListBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerRankingList.FlowerRankPreview.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_FlowerRankingList.FlowerRankPreview;

        SetBg(view.bg,"Common/ELIDA_common_bigdi01.png");
        view.rewardTipTxt.text = Lang.GetValue("flower_rank7");
        panel = view.panel;
        panel.rankList.itemRenderer = RenderPreviewItem;
        view.close_btn.onClick.Add(CloseView);

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        int index = (int)data;
        configList = FlowerRankModel.Instance.configListArr[index];
        panel.rankList.numItems = configList.Count;
        panel.rankList.ScrollToView(0, false);
    }

    private void RenderPreviewItem(int index,GObject cell)
    {
        fun_FlowerRankingList.FlowerRankPreviewItem item = cell as fun_FlowerRankingList.FlowerRankPreviewItem;
        FlowerRankData rankObj = configList[index];
        common_New.PictureFrame iframe = item.grid as common_New.PictureFrame;
        Module_item_defConfig itemVo = ItemModel.Instance.GetItemByEntityID(rankObj.Rewards[0].EntityID);
        if(itemVo != null)
        {
            item.titleNameTxt.text = Lang.GetValue(itemVo.Name) + "x" + rankObj.Rewards[0].Value;
            iframe.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            //item.rewardList.data = rankObj.Rewards;
        }
        else
        {
            item.titleNameTxt.text = "";
            iframe.pic.url = "";
        }
        item.gradeTab.selectedIndex = index;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.FlowerRankPreviewWindow);
    }
}

