//using System.Collections;
//using System.Collections.Generic;
//using protobuf.illustrated;
//using protobuf.messagecode;
//using UnityEngine;

//public class IllustratedController : BaseController<IllustratedController>
//{
//    protected override void InitListeners()
//    {
//        //图鉴 - 获取收集值
//        AddNetListener<S_MSG_ILLUSTRATED_GETCOLLECT>((int)MessageCode.S_MSG_ILLUSTRATED_GETCOLLECT, IllCetCollect);
//        //升级
//        AddNetListener<S_MSG_ILLUSTRATED_UPGRADELEVEL>((int)MessageCode.S_MSG_ILLUSTRATED_UPGRADELEVEL, IllUpgradeLevel);
//    }
//    //图鉴 - 获取收集值
//    public void IllCetCollect(S_MSG_ILLUSTRATED_GETCOLLECT data)
//    {
//        IllustratedModel.Instance.illustratedInfo.collectValue = data.collectValue;
//        IllustratedModel.Instance.UpdateIllItem(data.illustratedVo);
//        DispatchEvent(IllEvent.IllCetCollect);
//    }

//    public void ReqIllCetCollect(uint itemId,uint itemType,uint collectType)
//    {
//        C_MSG_ILLUSTRATED_GETCOLLECT c_MSG_ILLUSTRATED_GETCOLLECT = new C_MSG_ILLUSTRATED_GETCOLLECT();
//        c_MSG_ILLUSTRATED_GETCOLLECT.itemId = itemId;
//        c_MSG_ILLUSTRATED_GETCOLLECT.itemType = itemType;
//        c_MSG_ILLUSTRATED_GETCOLLECT.collectType = collectType;
//        SendCmd((int)MessageCode.C_MSG_ILLUSTRATED_GETCOLLECT, c_MSG_ILLUSTRATED_GETCOLLECT);

//    }
//    //升级
//    public void IllUpgradeLevel(S_MSG_ILLUSTRATED_UPGRADELEVEL data)
//    {
//        IllustratedModel.Instance.illustratedInfo.collectLevel = data.collectLevel;
//        DispatchEvent(IllEvent.IllUpgradeLevel);
//    }

//    public void ReqIllUpgradeLevel()
//    {
//        C_MSG_ILLUSTRATED_UPGRADELEVEL c_MSG_ILLUSTRATED_UPGRADELEVEL = new C_MSG_ILLUSTRATED_UPGRADELEVEL();
//        SendCmd((int)MessageCode.C_MSG_ILLUSTRATED_UPGRADELEVEL, c_MSG_ILLUSTRATED_UPGRADELEVEL);
//    }
//}
