using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.messagecode;
using protobuf.misc;
using UnityEngine;

/// <summary>
/// 剧情管理器
/// </summary>
public class PlotController : BaseController<PlotController>
{

    protected override void InitListeners()
    {
        //观看剧情
        AddNetListener<S_MSG_CHAPTER_PLOT_WATCH>((int)MessageCode.S_MSG_CHAPTER_PLOT_WATCH, PlotWatch);
    }
    /// <summary>
    /// 播放一个剧情
    /// </summary>
    /// <param name="plotId">剧情id</param>
    /// <param name="playFinishCall">播放剧情完毕回调</param>
    public void PlayPlot(int plotId, Action playFinishCall)
    {
        var data = (plotId, playFinishCall);
        UIManager.Instance.OpenWindow<PlotWindow>(UIName.PlotWindow, data);
    }
    //观看剧情
    public void PlotWatch(S_MSG_CHAPTER_PLOT_WATCH data)
    {
        MyselfModel.Instance.UpdateUserInfo(UserInfoType.PLOT,data.chapterPlot);
        var items = ItemModel.Instance.GetDropData(data.items);
        if (items != null && items.Count > 0)
        {
            UILogicUtils.ShowGetReward(items, () =>
            {
                DropManager.ShowDrop(items);
            });
        }
        StorageModel.Instance.OddToStorageItems(data.costItems);
        EventManager.Instance.DispatchEvent(PlotEvent.PlotWatch);
    }

    public void ReqPlotWatch()
    {
        C_MSG_CHAPTER_PLOT_WATCH c_MSG_CHAPTER_PLOT_WATCH = new C_MSG_CHAPTER_PLOT_WATCH();
        SendCmd((int)MessageCode.C_MSG_CHAPTER_PLOT_WATCH, c_MSG_CHAPTER_PLOT_WATCH);
    }
}
