using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class PlotMainWindow : BaseWindow
{
   private fun_Plot.plot_main_View view;
    private List<fun_Plot.pro_item> proItemMap;
    private List<fun_Plot.pro_point> proPointMap;

    private int chapter = 1;
    private int plotIdx = 0;
    private fun_Plot.plot_item curItem;
   public PlotMainWindow()
    {
        packageName = "fun_Plot";
        // 设置委托
        BindAllDelegate = fun_Plot.fun_PlotBinder.BindAll;
        CreateInstanceDelegate = fun_Plot.plot_main_View.CreateInstance;
        fairyBatching = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Plot.plot_main_View;
        SetBg(view.main.bg, "Plot/ELIDA_juqing_juanzhou_bg.png");
        proItemMap = new List<fun_Plot.pro_item>();
        proPointMap = new List<fun_Plot.pro_point>();

        view.main.list.itemRenderer = RenderList;
        //view.main.list.SetVirtual();

        EventManager.Instance.AddEventListener(PlotEvent.PlotWatch, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateList();
        view.main.play_show.Play();
    }

    public void UpdateList()
    {
        var plotData = MyselfModel.Instance.GetUserInfo(UserInfoType.PLOT);
        if (plotData != null)
        {
            var plotChapter = plotData.info.Split(",");
            chapter = int.Parse(plotChapter[0]);
            plotIdx = int.Parse(plotChapter[1]);
            var chapterInfo = PlotModel.Instance.GetPlotChapterInfo(chapter);
            var isMax = PlotModel.Instance.GetPlotChapterInfo(chapter + 1) == null && chapterInfo.Plots.Length == plotIdx + 1;
            if (!isMax)
            {
                if (chapterInfo.Plots.Length == plotIdx + 1)
                {
                    chapter += 1;
                    plotIdx = 0;
                }
                else
                {
                    plotIdx += 1;
                }
            }
        }
        view.main.list.numItems = chapter;
        view.main.list.scrollPane.ScrollBottom();
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Plot.plot_item;
        var chapterInfo = PlotModel.Instance.GetPlotChapterInfo(index + 1);
        cell.titleLab.text = Lang.GetValue(chapterInfo.ChapterName);
        var isMax = PlotModel.Instance.GetPlotChapterInfo(chapter + 1) == null && chapterInfo.Plots.Length == plotIdx + 1;
        if (chapter == index + 1 && !isMax)
        {
            cell.type.selectedIndex = 0;
            cell.status.selectedIndex = 1;
            curItem = cell;
            cell.anim.height = 668;
            cell.content.height = 671;
            cell.content.btn.data = chapterInfo.Plots[plotIdx];
            var plotInfo = PlotModel.Instance.GetPlotInfo(chapterInfo.Plots[plotIdx]);
            var costVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.poltItemId);
            var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.poltItemId);
            var costNum = chapterInfo.PlotCosts[plotIdx];
            StringUtil.SetBtnTab(cell.content.btn, costNum.ToString());
            StringUtil.SetBtnUrl(cell.content.btn, ImageDataModel.Instance.GetIconUrl(costVo));
            cell.content.btn.grayed = costNum > count;
            cell.content.btn.red_point.visible = costNum <= count;
            cell.content.cost_img.url = ImageDataModel.Instance.GetIconUrl(costVo);
            cell.content.haveLab.text = Lang.GetValue("handBook_1");
            cell.content.titleLab.text = Lang.GetValue(plotInfo.PlotName);
            cell.content.haveNum.text = ":" + count;
            UILogicUtils.SetItemShow(cell.content.cost_img, costVo.ItemDefId);
            ClearProItem(cell.content.pro_com);
            var durX = 440 / chapterInfo.Plots.Length;
            for(int i = 0;i < chapterInfo.Plots.Length; i++)
            {
                var proItem = GetProItem();
                var proPoint = GetProPoint();
                cell.content.pro_com.AddChildAt(proItem, 0);
                cell.content.pro_com.AddChild(proPoint);
                proItem.data = 2;
                proPoint.data = 1;
                proItem.width = durX;
                proItem.x = i * durX;
                proItem.y = 0;
                proPoint.y = -8;
                proPoint.x = (i + 1) * durX - 13;
                proPoint.type.selectedIndex = i == chapterInfo.Plots.Length - 1?1:0;
                var plotConfig = PlotModel.Instance.GetPlotInfo(chapterInfo.Plots[i]);
                proPoint.show.selectedIndex = plotConfig.Rewards != null && plotConfig.Rewards.Length > 0 && plotConfig.Rewards[0].EntityID != null ? 1 : 0;
                proPoint.box.data = chapterInfo.Plots[i];
                if (plotIdx < i)
                {
                    proItem.type.selectedIndex = 0;
                }
                else if (plotIdx > i)
                {
                    proItem.type.selectedIndex = 1;
                    proPoint.type.selectedIndex = 2;
                }
                else
                {
                    proItem.type.selectedIndex = 2;
                }
                proPoint.box.onClick.Add(ShowRewards);
            }
        }
        else
        {
            cell.type.selectedIndex = 1;
            cell.anim.height = 0;
            cell.list.height = 0;
            cell.status.selectedIndex = 0;
            cell.list.data = (chapterInfo.Plots.Length - 1) * 103 + 80;
            cell.list.itemRenderer = (int idx, GObject plotItem) =>
            {
                var plotCell = plotItem as fun_Plot.list_item;
                var plotInfo = PlotModel.Instance.GetPlotInfo(chapterInfo.Plots[idx]);
                plotCell.titleLab.text = Lang.GetValue(plotInfo.PlotName);
                StringUtil.SetBtnTab(plotCell.play_btn, Lang.GetValue("plot_1"));
                plotCell.play_btn.data = chapterInfo.Plots[idx];
                plotCell.play_btn.onClick.Add(PlayPlot);
            };
            cell.list.numItems = chapterInfo.Plots.Length;
        }
        cell.show_btn.onClick.Add(PlayAnim);
        cell.content.btn.onClick.Add(PlayPlotWindow);
    }

    private void ShowRewards(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var plotConfig = PlotModel.Instance.GetPlotInfo(id);
        if(plotConfig.Rewards != null && plotConfig.Rewards.Length > 0 && plotConfig.Rewards[0].EntityID != null)
        {
            var rewards = new List<StorageItemVO>();
            foreach(var value in plotConfig.Rewards)
            {
                var reward = new StorageItemVO();
                var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
                reward.itemDefId = itemVo.ItemDefId;
                reward.count = value.Value;
                rewards.Add(reward);
            }
            UIManager.Instance.OpenWindow<PlotRewardWindow>(UIName.PlotRewardWindow, rewards);
        }

    }
    private void PlayPlot(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var plotConfig = PlotModel.Instance.GetPlotInfo(id);
        PlotController.Instance.PlayPlot(id, () =>
        {
            
        });
    }

    private void PlayPlotWindow(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        var chapterInfo = PlotModel.Instance.GetPlotChapterInfo(chapter);
        var costVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.poltItemId);
        var count = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.poltItemId);
        var costNum = chapterInfo.PlotCosts[plotIdx];
        if(count < costNum)
        {
            //UILogicUtils.ShowItemGainTips(GlobalModel.Instance.module_profileConfig.poltItemId);
            UILogicUtils.ShowNotice(Lang.GetValue(costVo.Name) + Lang.GetValue("text_grandma14"));
            return;
        }
        PlotController.Instance.PlayPlot(id, () =>
        {
            PlotController.Instance.ReqPlotWatch();
        });
    }

    private void PlayAnim(EventContext context)
    {
        var target = (context.sender as GObject).parent as fun_Plot.plot_item;
        if(target.status.selectedIndex == 1)
        {
            return;
        }
        if(curItem != null)
        {
            if (curItem.type.selectedIndex == 0)
            {
                curItem.content.TweenResize(new Vector2(554, 3), 0.2f);
                curItem.anim.TweenResize(new Vector2(572, 0), 0.2f);
                curItem.status.selectedIndex = 0;
            }
            else
            {

                curItem.list.TweenResize(new Vector2(554, 0), 0.2f);
                curItem.anim.TweenResize(new Vector2(572, 0), 0.2f);
                curItem.status.selectedIndex = 0;
            }
        }
        
        if(target.type.selectedIndex == 0)
        {
            target.content.TweenResize(new Vector2(554, 671), 0.2f);
            target.anim.TweenResize(new Vector2(572, 668), 0.2f);
            target.status.selectedIndex = 1;
        }
        else
        {
            var height = (int)target.list.data;
            target.list.TweenResize(new Vector2(554, height), 0.2f);
            target.anim.TweenResize(new Vector2(572, height + 56), 0.2f);
            target.status.selectedIndex = 1;
        }
        curItem = target;
        
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void ClearProItem(fun_Plot.pro_com pro)
    {
        for(var i = pro._children.Count - 1;i >= 0; i--)
        {
            var value = pro._children[i];
            if ((int)value.data == 2)
            {
                value.parent.RemoveChild(value);
                proItemMap.Add(value as fun_Plot.pro_item);
            }
            else
            {
                value.parent.RemoveChild(value);
                proPointMap.Add(value as fun_Plot.pro_point);
            }

        }
    }

    private fun_Plot.pro_item GetProItem()
    {
        if(proItemMap.Count > 0)
        {
            var proItem = proItemMap[0];
            proItemMap.RemoveAt(0);
            return proItem;
        }
        else
        {
            return fun_Plot.pro_item.CreateInstance();
        }
        
    }

    private fun_Plot.pro_point GetProPoint()
    {
        if (proPointMap.Count > 0)
        {
            var proPoint = proPointMap[0];
            proPointMap.RemoveAt(0);
            return proPoint;
        }
        else
        {
            return fun_Plot.pro_point.CreateInstance();
        }

    }
}

