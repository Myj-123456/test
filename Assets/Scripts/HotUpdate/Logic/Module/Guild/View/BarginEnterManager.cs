using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using ADK;

public class BarginEnterManager
{
    private CountDownTimer timer;
    private CountDownTimer walkTime;

    private GComponent btn;
    private GLoader3D spine;
    private int curIndex;
    private List<float> dec = new() {0f,6f,3f,3f };
    private List<Vector2> pos = new List<Vector2> { new Vector2(-227f,1038f), new Vector2(450f, 1080f), new Vector2(850f, 1130f), new Vector2(1235f, 1207f) };
    public BarginEnterManager(GComponent com)
    {
        btn = com;
        spine = (btn as fun_Guild_New.bargin_btn).spine;
        
        spine.url = "yunyoushangren";
        spine.forcePlay = true;
        spine.loop = true;
    }
         
    public void InitSpine()
    {
        UpdateTime();
        curIndex = 1;
        btn.position = pos[1];
        
        ControlPos();
    }

    public void ClearTime()
    {

        if (walkTime != null)
        {
            walkTime.Clear();
            walkTime = null;
        }

        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }

    public void ControlPos()
    {
        if (walkTime != null)
        {
            walkTime.Clear();
            walkTime = null;
        }
        if (!GetIsOpen()) return;
        spine.animationName = "idle_walk";
        walkTime = new CountDownTimer(null, 60);
        walkTime.CompleteCallBacker = () =>
        {
            curIndex++;
            spine.animationName = "walk";
            btn.TweenMove(pos[curIndex], 2.8f).OnComplete(()=> { 
                if(curIndex == 3)
                {
                    curIndex = 1;
                    btn.position = pos[0];
                    btn.TweenMove(pos[curIndex], 4.6f).OnComplete(() =>
                    {
                        ControlPos();
                    });
                }
                else
                {
                    ControlPos();
                }
            });
        };
    }

    private void UpdateTime()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        btn.visible = GetIsOpen();
        
        var endTime = GetIsOpen()? GetEndTime(): GetStartTime();
        timer = new CountDownTimer(null, endTime, true);
        timer.CompleteCallBacker = () =>
        {
            UpdateTime();
        };
    }

    private bool GetIsOpen()
    {
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        var curDay = curTime.Date.AddDays(0);
        var startTime = TimeUtil.GetTimestamp(curDay) + 8 * 60 * 60;
        var nextDay = curTime.Date.AddDays(1);
        var endTime = TimeUtil.GetTimestamp(nextDay);
        return ServerTime.Time >= startTime && ServerTime.Time < endTime;
    }

    private int GetStartTime()
    {
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        var curDay = curTime.Date.AddDays(0);
        var startTime = TimeUtil.GetTimestamp(curDay) + 8 * 60 * 60;
        return (int)startTime;
    }


    private int GetEndTime()
    {
        var curTime = TimeUtil.GetDateTime(ServerTime.Time);
        var nextDay = curTime.Date.AddDays(1);
        var endTime = TimeUtil.GetTimestamp(nextDay);
        return (int)endTime;
    }
}
