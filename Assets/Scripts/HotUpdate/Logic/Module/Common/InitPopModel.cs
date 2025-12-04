using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityEngine;

public class InitPopModel : Singleton<InitPopModel>
{
   public List<Action> needTipViews;

    public List<String> nameView = new List<string>() {
        "GameNoticeWindow","SeventhSignWindow"
    };
    public void RecheckInitPopup()
    {
        if (GuideModel.Instance.IsGuide) return;//引导不要弹出
        needTipViews = new List<Action>();
        if (GlobalModel.Instance.GetUnlocked(SysId.SignAndBulletin))
        {
            int time = Saver.GetInt("GameNoticeDaily" + MyselfModel.Instance.userId);
            if((time == 0 || !TimeUtil.IsSameDayInt(time)) && GameNoticeModel.Instance.noticeData.Count > 0)
            {
                Action callback = () =>
                {
                    Saver.SaveAsString<int>("GameNoticeDaily" + MyselfModel.Instance.userId, (int)ServerTime.Time);
                    UIManager.Instance.OpenWindow<GameNoticeWindow>(UIName.GameNoticeWindow);
                };

                needTipViews.Add(callback);
            }
        }
        if (GlobalModel.Instance.GetUnlocked(SysId.Newspaper)) 
        {
            var signTime = Saver.GetInt("DaySign" + MyselfModel.Instance.userId);
            if (signTime == 0 || !TimeUtil.IsSameDayInt(signTime))
            {
                Action callback = () =>
                {
                    UIManager.Instance.OpenWindow<DaySignWindow>(UIName.DaySignWindow);
                };
                needTipViews.Add(callback);
            }
        }
        


        if (PopGiftModel.Instance.giftPackList.Count > 0)
        {
            var bol = Saver.GetInt("GiftPackTip" + MyselfModel.Instance.userId);
            var time = Saver.GetInt("GiftPackTipTime" + MyselfModel.Instance.userId);
            if (bol == 0 || (time == 0 || !TimeUtil.IsSameDayInt(time)))
            {
                Action callback = () =>
                {
                    UIManager.Instance.OpenWindow<PopGiftWindow>(UIName.PopGiftWindow, PopGiftModel.Instance.giftPackList[0].id);
                };

                needTipViews.Add(callback);
            }
        }

        //if (GlobalModel.Instance.GetUnlocked(SysId.SeventhSign))
        //{
        //    if (!SeventhSignModel.Instance.todayHaveDraw)
        //    {
        //        Action callback = () =>
        //        {
        //            UIManager.Instance.OpenWindow<SeventhSignWindow>(UIName.SeventhSignWindow);
        //        };

        //        needTipViews.Add(callback);
        //    }
        //}

        Coroutiner.StartCoroutine(OnDelayInitData());
    }

    private IEnumerator OnDelayInitData()
    {
        yield return new WaitForSeconds(1f);
        Coroutiner.StopCoroutine(OnDelayInitData());
        AutoTipView();
    }

    public void AutoTipView()
    {
        if(needTipViews != null && needTipViews.Count > 0)
        {
            needTipViews[0]();
            needTipViews.RemoveAt(0);
        }
    }
}


