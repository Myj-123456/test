using UnityEngine;
using FairyGUI;
using System;
using ADK;
using UnityTimer;
using System.Collections.Generic;
/// <summary>
/// 倒计时器。
/// </summary>

public class CountDownTimer
{
    private GTextField textField;
    private bool isProcessing = false;
    private Timer timer;
    public float Interval = 1f;
    public Action UpdateCallBacker;
    public Action CompleteCallBacker;
    public int time;
    public bool hour = false;

    /**前缀 */
    public string prefixString = "";
    /**后缀 */
    public string suffixString = "";
    public int type;

    public TimeFormat timeFormat = TimeFormat.DateWithTwoDigit;
    public CountDownTimer(GTextField textFile, int time, bool isRun = true, int type = 1)
    {
        textField = textFile;
        this.time = time;
        this.type = type;
        timer = Timer.Regist(Interval, OnTimerEvent, true);
        if (isRun)
        {
            if (textFile != null)
            {
                if (type == 1)
                {
                    UpdateTime();
                }
                else
                {
                    UpdateTime1();
                }

            }
            isProcessing = true;
        }
        else
        {
            isProcessing = false;
        }
    }

    public void Run()
    {
        if (isProcessing) return;
        if (this.time <= 0)
        {
            return;
        }

        if (type == 1)
        {
            UpdateTime();
        }
        else
        {
            UpdateTime1();
        }
        isProcessing = true;
    }

    public void Clear()
    {
        if (isProcessing)
        {
            Timer.Cancel(timer);
            UpdateCallBacker = null;
            CompleteCallBacker = null;
            isProcessing = false;
            textField = null;
            prefixString = "";
            suffixString = "";
        }
    }

    private void OnTimerEvent()
    {
        if (!isProcessing) return;
        if (time > 0)
        {
            time--;
            UpdateCallBacker?.Invoke();
        }
        if (textField != null)
        {
            if (type == 1)
            {
                UpdateTime();
            }
            else
            {
                UpdateTime1();
            }
        }
        if (time <= 0)
        {
            CompleteCallBacker?.Invoke();
            Clear();
        }

    }

    private void UpdateTime()
    {
        if (time <= 0)
        {
            textField.text = hour ? "00:00:00" : "00:00";
        }
        else
        {
            textField.text = TimeUtil.GetTimeInDateHourMinuteSecond(time, timeFormat, hour);
        }
        textField.text += suffixString;
        textField.text = prefixString + textField.text;
    }

    private void UpdateTime1()
    {
        textField.text = TimeUtil.SecondTimeString(time);
        textField.text += suffixString;
        textField.text = prefixString + textField.text;
    }


}


