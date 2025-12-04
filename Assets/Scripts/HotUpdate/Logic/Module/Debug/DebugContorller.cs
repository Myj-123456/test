using System.Collections;
using System.Collections.Generic;
using protobuf.common;
using protobuf.messagecode;
using UnityEngine;
using ADK;
using Elida.Config;

public class DebugContorller : BaseController<DebugContorller>
{
    private float reqStartTime;
    private float reqEndTime;
    protected override void InitListeners()
    {
        AddNetListener<S_GM_SEND_ITEM>((int)MessageCode.S_GM_SEND_ITEM, GmAddItem);

        AddNetListener<S_GM_UPDATE_TIMEOFFSET>((int)MessageCode.S_GM_UPDATE_TIMEOFFSET, UpdateTimeOffset);

        AddNetListener<S_MSG_MAINTASK>((int)MessageCode.S_MSG_MAINTASK, MainTask);
    }

    public void GmAddItem(S_GM_SEND_ITEM data)
    {
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById((int)data.itemId);
        if (itemData != null)
        {
            UILogicUtils.ShowNotice(Lang.GetValue(itemData.Name) + ": +" + data.count);
        }
        StorageModel.Instance.AddToStorageByItemId((int)data.itemId, (int)data.count);
    }

    public void ResGmAddItem(uint itemId,long count,bool isTrimming = false)
    {
        C_GM_SEND_ITEM c_GM_SEND_ITEM = new C_GM_SEND_ITEM();
        c_GM_SEND_ITEM.itemId = itemId;
        c_GM_SEND_ITEM.count = count;
        SendCmd((int)MessageCode.C_GM_SEND_ITEM, c_GM_SEND_ITEM);
    }

    public void UpdateTimeOffset(S_GM_UPDATE_TIMEOFFSET data)
    {
        reqEndTime = Time.realtimeSinceStartup;
        var halfRtt = (reqEndTime - reqStartTime) / 2;
        ServerTime.UpdateServerTime(data.serverTime, halfRtt);
    }

    public void ReqUpdateTimeOffset(string time)
    {
        reqStartTime = Time.realtimeSinceStartup;
        C_GM_UPDATE_TIMEOFFSET c_GM_UPDATE_TIMEOFFSET = new C_GM_UPDATE_TIMEOFFSET();
        c_GM_UPDATE_TIMEOFFSET.offsetTime = time;
        SendCmd((int)MessageCode.C_GM_UPDATE_TIMEOFFSET, c_GM_UPDATE_TIMEOFFSET);
    }

    public void MainTask(S_MSG_MAINTASK data)
    {
        TaskModel.Instance.mainTask.mainTaskCnt = data.mainTaskCnt;
        TaskModel.Instance.mainTask.mainTaskId = data.mainTaskId;
        DispatchEvent(TaskEvent.MainTaskReward);
    }

    public void ReqMainTask(uint mainTaskId, uint mainTaskCnt)
    {
        C_MSG_MAINTASK c_MSG_MAINTASK = new C_MSG_MAINTASK();
        c_MSG_MAINTASK.mainTaskId = mainTaskId;
        c_MSG_MAINTASK.mainTaskCnt = mainTaskCnt;
        SendCmd((int)MessageCode.C_MSG_MAINTASK, c_MSG_MAINTASK);
    }
}
