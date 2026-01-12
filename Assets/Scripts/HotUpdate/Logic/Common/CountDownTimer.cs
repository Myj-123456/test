using UnityEngine;
using FairyGUI;
using System;
using ADK;
using UnityTimer;
using System.Collections.Generic;
/// <summary>
/// 倒计时器
/// </summary>

public class CountDownTimer
{
    private GTextField textField;
    private GProgressBar progressBar;
    private bool isProcessing = false;
    private Timer timer;
    public float Interval = 1f;
    public Action UpdateCallBacker;
    public Action CompleteCallBacker;
    public int time;
    public int totalTime;
    public bool hour = false;
    //计时器校准
    public int starServeTime;
    public int starTime;

    /** 前缀字符串 */
    public string prefixString = "";
    /** 后缀字符串 */
    public string suffixString = "";
    public int type;

    public TimeFormat timeFormat = TimeFormat.DateWithTwoDigit;
    public CountDownTimer(GTextField textFile, int time, bool isRun = true, int type = 1)
    {
        textField = textFile;
        this.time = time;
        starTime = time;
        starServeTime = (int)ServerTime.Time;
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
    
    public CountDownTimer(GProgressBar progressBar, int time, int totalTime, bool isRun = true, int type = 1)
    {
        this.progressBar = progressBar;
        this.time = time;
        this.totalTime = totalTime;
        this.type = type;
        timer = Timer.Regist(Interval, OnTimerEvent, true);
        if (isRun)
        {
            if (progressBar != null)
            {
                UpdateProgress();
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
        else if (progressBar != null)
        {
            UpdateProgress();
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
            progressBar = null;
            prefixString = "";
            suffixString = "";
        }
    }

    private void OnTimerEvent()
    {
        if (!isProcessing) return;
        if (time > 0)
        {
            time = starTime - ((int)ServerTime.Time - starServeTime);
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
        else if (progressBar != null)
        {
            UpdateProgress();
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
    
    private void UpdateProgress()
    {
        if (totalTime <= 0)
        {
            progressBar.value = 100;
            return;
        }
        float progress = (float)(totalTime - time) / totalTime * 100;
        progress = Mathf.Clamp(progress, 0, 100);
        progressBar.value = progress;
    }
}


