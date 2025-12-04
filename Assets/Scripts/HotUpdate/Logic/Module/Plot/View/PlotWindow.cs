using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 剧情弹窗
/// </summary>
public class PlotWindow : BaseWindow
{
    private fun_Plot.PlotWindow view;
    private int plotId;
    private Action playFinishCall;

    public PlotWindow()
    {
        packageName = "fun_Plot";
        // 设置委托
        BindAllDelegate = fun_Plot.fun_PlotBinder.BindAll;
        CreateInstanceDelegate = fun_Plot.PlotWindow.CreateInstance;
        openWithTween = false;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Plot.PlotWindow;
        ADK.StringUtil.SetBtnTab(view.btn_skip, "跳过");
        ADK.StringUtil.SetBtnTab(view.btn_end, "结束");
        AddEvent();
    }

    private void AddEvent()
    {
        view.plotScollPanel.onClick.Add(ShowPlot);
        view.btn_skip.onClick.Add(OnSkip);
        view.btn_end.onClick.Add(Close);
    }

    public override void OnShown()
    {
        base.OnShown();

        if (data is ValueTuple<int, Action> plotData)
        {
            plotId = plotData.Item1;
            playFinishCall = plotData.Item2;
        }

        view.btn_end.visible = false;
        view.txt_goOn.visible = true;
        view.plotScollPanel.scrollPane.ScrollTop();
        showDialogueCount = 0;
        lastItemY = 0;
        StartCoroutine(ShowFirstPlot());
    }

    //默认显示第一个
    private IEnumerator ShowFirstPlot()
    {
        yield return new WaitForSeconds(0.2f);
        ShowPlot();
    }

    private void OnSkip()
    {
        Debug.Log("直接完成剧情，跳过");
        Close();
    }

    private float startY = 80f;
    private int showDialogueCount = 0;
    private float perDialogueItemHeight = 175;
    private float perDialogueItemGap = 50;
    private List<PoltDialogueConfig> poltDialogues;
    private float lastItemY = 0f;

    private void ShowPlot()
    {
        if (poltDialogues == null)
        {
            poltDialogues = PlotModel.Instance.GetPlotDialogueConfigs(plotId);
        }
        if (poltDialogues == null || poltDialogues.Count <= 0) return;

        if (showDialogueCount >= poltDialogues.Count)
        {
            Debug.Log("剧情结束了，显示结束按钮");
            view.btn_end.visible = true;
            view.txt_goOn.visible = false;
            return;
        }

        GComponent creatDialogueItem;
        var poltDialogueConfig = poltDialogues[showDialogueCount];
        creatDialogueItem = poltDialogueConfig.type == 1 ? CreatDialogueItem() : CreatNarrationItem();
        creatDialogueItem.visible = true;
        view.plotScollPanel.AddChild(creatDialogueItem);
        if (showDialogueCount == 0)
        {
            lastItemY = startY;
        }
        else
        {
            lastItemY += perDialogueItemHeight + perDialogueItemGap;
        }
        creatDialogueItem.y = lastItemY;
        if (lastItemY >= view.plotScollPanel.height)
        {
            Debug.Log("超过了");
            view.plotScollPanel.scrollPane.ScrollBottom(true);
        }
        if (poltDialogueConfig.type == 1)//对话需要区分左边还是右边
        {
            var dialogueItem = (creatDialogueItem as fun_Plot.DialogueItem).item;
            dialogueItem.txt_name.text = Lang.GetValue(poltDialogueConfig.name);
            if (poltDialogueConfig.leftRight == 1)//左边
            {
                dialogueItem.c1.selectedIndex = 1;
                dialogueItem.pivotX = 0.25f;
                dialogueItem.pivotY = 0.4f;
                dialogueItem.txt_msg2.text = Lang.GetValue(poltDialogueConfig.dialogue);
                creatDialogueItem.x = 100;
                dialogueItem.scale = Vector2.zero;
                dialogueItem.TweenScale(Vector2.one, 0.2f).SetEase(EaseType.CircIn);

            }
            else if (poltDialogueConfig.leftRight == 2)//右边
            {
                dialogueItem.c1.selectedIndex = 0;
                dialogueItem.pivotX = 0.75f;
                dialogueItem.pivotY = 0.4f;
                dialogueItem.txt_msg1.text = Lang.GetValue(poltDialogueConfig.dialogue);
                creatDialogueItem.x = 140;
                dialogueItem.scale = Vector2.zero;
                dialogueItem.TweenScale(Vector2.one, 0.2f).SetEase(EaseType.CircIn);

            }
        }
        else if (poltDialogueConfig.type == 2)//旁白居中就行了
        {
            creatDialogueItem.x = 14;
            var narrationItem = (creatDialogueItem as fun_Plot.NarrationItem).item;
            narrationItem.scale = Vector2.zero;
            narrationItem.txt_msg.text = Lang.GetValue(poltDialogueConfig.dialogue);
            //直接从中间缓动出来
            narrationItem.TweenScale(Vector2.one, 0.2f).SetEase(EaseType.CircIn);
        }

        showDialogueCount += 1;
    }

    private static List<fun_Plot.DialogueItem> cache;
    private fun_Plot.DialogueItem CreatDialogueItem()
    {
        fun_Plot.DialogueItem notice;
        if (cache == null) cache = new List<fun_Plot.DialogueItem>();
        if (cache.Count > 0)
        {
            notice = cache[0];
            cache.RemoveAt(0);
        }
        else
        {
            notice = fun_Plot.DialogueItem.CreateInstance();
        }
        return notice;
    }

    private static List<fun_Plot.NarrationItem> cache2;
    private fun_Plot.NarrationItem CreatNarrationItem()
    {
        fun_Plot.NarrationItem notice;
        if (cache2 == null) cache2 = new List<fun_Plot.NarrationItem>();
        if (cache2.Count > 0)
        {
            notice = cache2[0];
            cache2.RemoveAt(0);
        }
        else
        {
            notice = fun_Plot.NarrationItem.CreateInstance();
        }
        return notice;
    }

    private void ClearAll()
    {
        var count = view.plotScollPanel.numChildren;
        for (var i = count - 1; i >= 0; i--)
        {
            var plotItem = view.plotScollPanel.GetChildAt(i);
            plotItem.visible = false;
            view.plotScollPanel.RemoveChild(plotItem);
            if (plotItem is fun_Plot.DialogueItem dialogueItem)
            {
                cache.Add(dialogueItem);
            }
            else if (plotItem is fun_Plot.NarrationItem narrationItem)
            {
                cache2.Add(narrationItem);
            }
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        ClearAll();
        playFinishCall?.Invoke();
    }
}
