using System.Collections;
using System.Collections.Generic;
using protobuf.messagecode;
using protobuf.notify;
using protobuf.rob;
using UnityEngine;

public class MarqueeContorller : BaseController<MarqueeContorller>
{
    protected override void InitListeners()
    {
        //ÅÜÂíµÆÍ¨Öª
        AddNetListener<S_SYSTEM_EVENT_MARQUEE>((int)MessageCode.S_SYSTEM_EVENT_MARQUEE, EventNotify);
    }

    public void EventNotify(S_SYSTEM_EVENT_MARQUEE data)
    {
        var info = MarqueeModel.Instance.GetMarqueeInfo((int)data.type);
        var str = "";
        if (data.ext3 != 0)
        {
            var itemVo = ItemModel.Instance.GetItemByEntityID(data.ext3.ToString());
            str = Lang.GetValue(info.Zh, data.ext2 + "." + data.ext1, Lang.GetValue(itemVo.Name));
        }
        else
        {
            str = Lang.GetValue(info.Zh, data.ext2 + "." + data.ext1);
        }
        MarqueeModel.Instance.marqueeList.Add(str);
        MarqueeNotice.Instance.RunMarquee();
    }
}
