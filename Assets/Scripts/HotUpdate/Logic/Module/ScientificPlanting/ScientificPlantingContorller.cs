//using System.Collections;
//using System.Collections.Generic;
//using protobuf.cultivateresearch;
//using protobuf.messagecode;
//using UnityEngine;
//using ADK;

//public class ScientificPlantingContorller : BaseController<ScientificPlantingContorller>
//{
//    protected override void InitListeners()
//    {
//        //培育研究信息
//        AddNetListener<S_CULTIVATION_RESEARCH_INFO>((int)MessageCode.S_CULTIVATION_RESEARCH_INFO, CultivationResearchInfo);
//        //培育研究开始
//        AddNetListener<S_CULTIVATION_RESEARCH_START>((int)MessageCode.S_CULTIVATION_RESEARCH_START, CultivationResearchStart);
//        //培育研究奖励
//        AddNetListener<S_CULTIVATION_RESEARCH_REWARD>((int)MessageCode.S_CULTIVATION_RESEARCH_REWARD, CultivationResearchReward);
//        //培育研究冷却时间购买
//        AddNetListener<S_CULTIVATION_RESEARCH_COOLTIME_CLEAR>((int)MessageCode.S_CULTIVATION_RESEARCH_COOLTIME_CLEAR, CultivationResearchCooltime);
//    }

//    //培育研究信息
//    public void CultivationResearchInfo(S_CULTIVATION_RESEARCH_INFO data)
//    {
//        ScientificPlantingModel.Instance.cultivateSearch = data.cultivateSearch;
//    }

//    public void ReqCultivationResearchInfo()
//    {
//        C_CULTIVATION_RESEARCH_INFO c_CULTIVATION_RESEARCH_INFO = new C_CULTIVATION_RESEARCH_INFO();
//        SendCmd((int)MessageCode.C_CULTIVATION_RESEARCH_INFO, c_CULTIVATION_RESEARCH_INFO);
//    }
//    //培育研究开始
//    public void CultivationResearchStart(S_CULTIVATION_RESEARCH_START data)
//    {
//        StorageModel.Instance.AddToStorageByItemId((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId, -(int)data.itemNum);
//        ScientificPlantingModel.Instance.cultivateSearch.luckNum = data.luckNum;
//        ScientificPlantingModel.Instance.cultivateSearch.coolingTime = data.coolingTime;
//        ScientificPlantingModel.Instance.cultivateSearch.flowerId = data.flowerId;
//        ScientificPlantingModel.Instance.cultivateSearch.flowerNum = data.flowerNum;
//        ScientificPlantingModel.Instance.cultivateSearch.needItemId = data.needItemId;
//        EventManager.Instance.DispatchEvent(ScientificPlantingEvent.CultivationResearchStart);
//    }

//    public void ReqCultivationResearchStart(uint itemNum)
//    {
//        C_CULTIVATION_RESEARCH_START c_CULTIVATION_RESEARCH_START = new C_CULTIVATION_RESEARCH_START();
//        c_CULTIVATION_RESEARCH_START.itemNum = itemNum;
//        SendCmd((int)MessageCode.C_CULTIVATION_RESEARCH_START, c_CULTIVATION_RESEARCH_START);
//    }
//    //培育研究奖励
//    public void CultivationResearchReward(S_CULTIVATION_RESEARCH_REWARD data)
//    {
//        var dropList = new List<StorageItemVO>();
//        var drop = new StorageItemVO();
//        drop.itemDefId = (int)ScientificPlantingModel.Instance.cultivateSearch.flowerId;
//        drop.count = (int)ScientificPlantingModel.Instance.cultivateSearch.flowerNum;
//        dropList.Add(drop);
//        UILogicUtils.ShowGetReward(dropList,()=> { DropManager.ShowDrop(dropList); });

//        ScientificPlantingModel.Instance.cultivateSearch.changeTime = data.changeTime;
//        ScientificPlantingModel.Instance.cultivateSearch.coolingTime = data.coolingTime;
//        ScientificPlantingModel.Instance.cultivateSearch.flowerId = data.flowerId;
//        ScientificPlantingModel.Instance.cultivateSearch.flowerNum = data.flowerNum;
//        ScientificPlantingModel.Instance.cultivateSearch.needItemId = data.needItemId;
//    }

//    public void ReqCultivationResearchReward()
//    {
//        C_CULTIVATION_RESEARCH_REWARD c_CULTIVATION_RESEARCH_REWARD = new C_CULTIVATION_RESEARCH_REWARD();
//        SendCmd((int)MessageCode.C_CULTIVATION_RESEARCH_REWARD, c_CULTIVATION_RESEARCH_REWARD);
//    }
//    //培育研究冷却时间购买
//    public void CultivationResearchCooltime(S_CULTIVATION_RESEARCH_COOLTIME_CLEAR data)
//    {
//        ScientificPlantingModel.Instance.cultivateSearch.changeTime = data.changeTime;
//        ScientificPlantingModel.Instance.cultivateSearch.coolingTime = data.coolingTime;
//        ScientificPlantingModel.Instance.cultivateSearch.needItemId = data.needItemId;
//        EventManager.Instance.DispatchEvent(ScientificPlantingEvent.CultivationResearchCooltime);
//    }

//    public void ReqCultivationResearchCooltime()
//    {
//        C_CULTIVATION_RESEARCH_COOLTIME_CLEAR c_CULTIVATION_RESEARCH_COOLTIME_CLEAR = new C_CULTIVATION_RESEARCH_COOLTIME_CLEAR();
//        SendCmd((int)MessageCode.C_CULTIVATION_RESEARCH_COOLTIME_CLEAR, c_CULTIVATION_RESEARCH_COOLTIME_CLEAR);
//    }
//}
