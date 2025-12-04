using System.Collections;
using System.Collections.Generic;
using protobuf.common;
using UnityEngine;

public class GameNoticeModel : Singleton<GameNoticeModel>
{
    public List<I_NOTICE_VO>  noticeData;

    public I_NOTICE_VO GetNoticeData(int index)
    {
        if(noticeData == null || noticeData.Count <= index)
        {
            return null;
        }
        return noticeData[index];
    }
}


