using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;

public class Notice
{
    private static List<common_New.TipText> cache;

    private common_New.TipText notice;

    public Notice(string info,string color = "",float x = 0,float y = 0)
    {
        CreateNotice();
        notice.content.notice_txt.text = info;
        notice.content.alpha = 0;
        notice.y = y;
        notice.x = x;
        notice.content.x = 0;
        notice.content.y = 0;
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => notice.content.alpha, x => notice.content.alpha = x, 1f, 0.25f).SetEase(Ease.OutCubic))
                .Join(DOTween.To(() => notice.content.scale, x => notice.content.scale = x, new Vector2(1f, 1f), 0.25f).SetEase(Ease.OutCubic));
        sequence.AppendInterval(0.75f);
        sequence.Append(DOTween.To(() => notice.content.xy, x => notice.content.xy = x, new Vector2(0, -180), 0.4f).SetEase(Ease.OutCubic))
               .Join(DOTween.To(() => notice.content.alpha, x => notice.content.alpha = x, 0f, 0.4f).SetEase(Ease.OutCubic));
        sequence.OnComplete(() =>
        {
            sequence.Kill();
            sequence = null;
            notice.parent.RemoveChild(notice);
            if (cache.Count < 10) cache.Add(notice);
            else notice.Dispose();
        });
        sequence.Play();

    }

    public void SetParent(GComponent parent)
    {
        parent.AddChild(notice);
    }

    private void CreateNotice()
    {
        if (cache == null) cache = new List<common_New.TipText>();
        if(cache.Count > 0)
        {
            notice = cache[0];
            cache.RemoveAt(0);
        }
        else
        {
            notice = common_New.TipText.CreateInstance();
        }
    }
}
