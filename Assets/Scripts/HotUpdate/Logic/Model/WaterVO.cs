using ADK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 水滴逻辑
/// 增加、消耗、回复
/// </summary>
public class WaterVO
{
    private uint _waterMax;//最大水
    private uint waterRenewCount;//每次回复数量
    private uint waterRenewInterval;//回复间隔
    private ulong lastRenewTime;//上次回复时间(时间戳s) //只有未满的时候才会更新为回复点的服务器时间戳 比如浇花变成了39 这时候小于最大水限制 就会产生一个lastRenewTime=serverTime

    private uint _waterCur;

    public WaterVO()
    {
        _waterMax = GlobalModel.Instance.module_profileConfig.waterLimit;
        waterRenewCount = GlobalModel.Instance.module_profileConfig.waterChargeAmount;
        waterRenewInterval = GlobalModel.Instance.module_profileConfig.waterChargeInterval;
    }

    /// <summary>
    /// 当前水
    /// </summary>
    public uint waterCur
    {
        get { return _waterCur; }
        set { _waterCur = value; }
    }

    public uint waterMax
    {
        get { return _waterMax; }
        set { _waterMax = value; }
    }

    //game_init 初始水量
    public void Init(uint curNum, ulong ts)
    {
        this.waterCur = curNum;
        var pastTime = ServerTime.Time - ts;
        if (this.waterCur < this._waterMax)
        {//离线时间自然恢复
            if (pastTime > this.waterRenewInterval)
            {
                uint num = (uint)Mathf.Floor(pastTime / this.waterRenewInterval);
                this.waterCur += num;
                if (this.waterCur >= this._waterMax)
                {
                    this.waterCur = this._waterMax;
                    this.lastRenewTime = ServerTime.Time;//这个地方其实给什么值都无用，反正数量是满的，根本不执行CD，并且下次水滴数值变化时，服务器会同步正确的更新水滴的时间
                }
                else
                {
                    this.lastRenewTime = ts + num * this.waterRenewInterval;
                }
            }
            else
            {
                this.lastRenewTime = ts;
            }
        }
        else
        {
            this.lastRenewTime = ServerTime.Time;
        }
    }

    public void Renew()
    {
        if (this.waterCur < this._waterMax)
        {
            var now = ServerTime.Time;
            if (now - this.lastRenewTime >= this.waterRenewInterval)
            {
                this.waterCur += this.waterRenewCount;
                this.lastRenewTime = now;
                if (this.waterCur > this._waterMax)
                {
                    this.waterCur = this._waterMax;
                }
                EventManager.Instance.DispatchEvent(SystemEvent.UpdateWater);
            }
        }
    }


    /// <summary>
    /// 更新水
    /// </summary>
    /// <param name="num"></param>
    /// <param name="ts"></param>
    public void UpdateWater(uint num, ulong ts)
    {
        this.waterCur = num;
        this.lastRenewTime = ts;
        EventManager.Instance.DispatchEvent(SystemEvent.UpdateWater);
    }

    /// <summary>
    /// 获得
    /// </summary>
    /// <param name="num"></param>
    public void Gain(uint num)
    {
        this.waterCur += num;
    }

    public bool Consume(uint num)
    {
        if (this.waterCur == this._waterMax)
        {
            this.waterCur -= num;
            this.lastRenewTime = ServerTime.Time;
            EventManager.Instance.DispatchEvent(SystemEvent.UpdateWater);
            return true;
        }
        if (num <= this.waterCur)
        {
            this.waterCur -= num;
            EventManager.Instance.DispatchEvent(SystemEvent.UpdateWater);
            return true;
        }
        return false;
    }

    //获取下次水恢复还需要多少时间(单位：s)
    public int GetNextRenewNeedTime()
    {
        return (int)(this.lastRenewTime + this.waterRenewInterval - ServerTime.Time);
    }

}
