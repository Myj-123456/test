using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 探索转场
/// </summary>
public class ExploreTransitionsView : BaseView
{
    private fun_Transitions.ExploreTransitionsView viewSkin;
    public ExploreTransitionsView()
    {
        packageName = "fun_Transitions";
        // 设置委托
        BindAllDelegate = fun_Transitions.fun_TransitionsBinder.BindAll;
        CreateInstanceDelegate = fun_Transitions.ExploreTransitionsView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Transitions.ExploreTransitionsView;
    }

    public override void OnShown()
    {
        base.OnShown();
        PlayTransitionsOpen(() =>
        {
            PlayTransitionsIdle();
            ShowLoading();
        });
    }

    private void PlayTransitionsOpen(Action playFinishCallBack = null)
    {
        viewSkin.gloup.visible = false;
        viewSkin.loader_spine.url = "zhuanchuang";
        viewSkin.loader_spine.forcePlay = true;
        viewSkin.loader_spine.animationName = "open";
        viewSkin.loader_spine.loop = false;
        viewSkin.loader_spine.Complete = (string aniName) =>
        {
            viewSkin.loader_spine.Complete = null;
            if (aniName == "open")
            {
                playFinishCallBack?.Invoke();
            }
        };
    }
    private void PlayTransitionsIdle()
    {
        viewSkin.loader_spine.loop = true;
        viewSkin.loader_spine.animationName = "idle";
    }

    private void ShowLoading()
    {
        viewSkin.gloup.visible = true;
        StartCoroutine(AnimateDots());
        StartCoroutine(RunProgress(3, 1));
    }

    private IEnumerator AnimateDots()
    {
        int dotCount = 0;
        while (true)
        {
            dotCount = (dotCount % 3) + 1;
            viewSkin.txt_des.text = Lang.GetValue("adventure_going_tips") + new string('.', dotCount);
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 进度条协程
    private IEnumerator RunProgress(float duration, float targetProgress)
    {
        float startValue = 0;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // 计算当前进度（使用线性插值）
            float t = elapsedTime / duration;
            var value = Mathf.Lerp(startValue, targetProgress, t);

            // 更新进度文本
            viewSkin.txt_progress.text = $"{value * 100:F0}%";

            elapsedTime += Time.deltaTime;
            yield return null;  // 每帧更新
        }

        // 确保最终值精确
        viewSkin.txt_progress.text = $"{targetProgress * 100}%";
        UIManager.Instance.ClosePanel(UIName.ExploreTransitionsView);

    }

    public override void OnHide()
    {
        base.OnHide();
        StopCoroutine(AnimateDots());
        StopCoroutine(RunProgress(0, 0));
    }
}
