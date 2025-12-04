using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBoxManager : Singleton<TurnBoxManager>
{
    public int boxNum;
    public int time;

    public CountDownTimer timer;
    public void UpdateBoxData()
    {
        var endTime = GetEndTime();
        if (boxNum < GlobalModel.Instance.module_profileConfig.keMaxNum)
        {
            if (timer != null)
            {
                timer.Clear();
                timer = null;
            }
            timer = new(null, endTime);
            timer.CompleteCallBacker = UpdateBoxData;
        }
        EventManager.Instance.DispatchEvent(WelfareEvent.TurnTable);
    }

    private int GetEndTime()
    {
        var endTime = ServerTime.Time - time;
        if(endTime >= GlobalModel.Instance.module_profileConfig.keHuifuCd)
        {
            var num = Mathf.Floor((float)endTime / GlobalModel.Instance.module_profileConfig.keHuifuCd);
            boxNum += (int)num;
            if(boxNum > GlobalModel.Instance.module_profileConfig.keMaxNum)
            {
                boxNum = GlobalModel.Instance.module_profileConfig.keMaxNum;
            }
            var haveTime = (int)endTime % GlobalModel.Instance.module_profileConfig.keHuifuCd;
            time = (int)ServerTime.Time - haveTime;
            return GlobalModel.Instance.module_profileConfig.keHuifuCd - haveTime;
        }
        else
        {
            return GlobalModel.Instance.module_profileConfig.keHuifuCd - (int)endTime;
        }
        
    }
}
