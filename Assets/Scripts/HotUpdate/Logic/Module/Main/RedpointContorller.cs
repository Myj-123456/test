using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.reddot;
using UnityEngine;

public class RedpointContorller : BaseController<RedpointContorller>
{
    protected override void InitListeners()
    {
        AddNetListener<I_REDDOT_VO>((int)MessageCode.S_MSG_REDDOT_CHANGE, RedDotChange);
    }

    public void RedDotChange(I_REDDOT_VO data)
    {
        RedPointModel.Instance.UpdateRedPoint(data);
        EventManager.Instance.DispatchEvent(RedPointEvent.RedDotChange, data.type);
    }
}
