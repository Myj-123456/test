using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacthTimeManger
{
    public CountDownTimer timer;

    private Dictionary<uint, CountDownTimer> timerMap;

    public MacthTimeManger()
    {
        timerMap = new Dictionary<uint, CountDownTimer>();
    }

    public void MatchTimer()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        if (!GuildMatchModel.Instance.GetIsOpenMatchTask())
        {
            return;
        }
        int endTime = GuildMatchModel.Instance.GetMarchUpdateTime();
        if (endTime > 0)
        {
            timer = new CountDownTimer(null, endTime);
            timer.CompleteCallBacker = () =>
            {
                GuildMatchController.Instance.ReqGuildPosTask(0);
                MatchTimer();
            };
        }
    }

    public void UpdateTimer()
    {
        if (!GuildMatchModel.Instance.GetIsOpenMatchTask())
        {
            return;
        }
        foreach (var value in GuildMatchModel.Instance.taskList)
        {
            
            if (timerMap.ContainsKey(value.pos) && timerMap[value.pos] != null)
            {
                timerMap[value.pos].Clear();
                timerMap[value.pos] = null;
                timerMap.Remove(value.pos);
            }
            int endTime = (int)value.limitedTime - (int)ServerTime.Time;
            if(endTime > 0)
            {
                var time = new CountDownTimer(null, endTime);
                time.CompleteCallBacker = () =>
                {
                    GuildMatchController.Instance.ReqGuildPosTask(value.pos);
                };
            }
            
        }
    }

    public void Clear()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        foreach(var value in timerMap)
        {
            if(value.Value != null)
            {
                value.Value.Clear();
                timerMap[value.Key] = null;
            }
        }
    }
}
