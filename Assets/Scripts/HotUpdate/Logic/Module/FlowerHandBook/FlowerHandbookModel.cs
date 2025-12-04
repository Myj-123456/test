using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ADK;
using Elida.Config;
using protobuf.ikebana;
using UnityEngine;

public class FlowerHandbookModel : Singleton<FlowerHandbookModel>
{
    //种子解锁静态数据表
    private List<StaticSeedCondition> _seedConditionList;

    public Dictionary<uint, I_VASE_REWARD_STATUS> vaseRewardInfo;

    public Dictionary<uint, List<uint>> rewardFlowersStatus;
    public List<StaticSeedCondition> seedConditionList
    {
        get
        {
            if (_seedConditionList == null)
            {
                Ft_hua_breedConfigData conditionConfigData = ConfigManager.Instance.GetConfig<Ft_hua_breedConfigData>("ft_hua_breedsConfig");
                _seedConditionList = new List<StaticSeedCondition>();
                foreach (Ft_hua_breedConfig item in conditionConfigData.DataList)
                {
                    StaticSeedCondition seedCondition = new StaticSeedCondition(item);
                    _seedConditionList.Add(seedCondition);
                }
            }
            return _seedConditionList;
        }
    }

    private Dictionary<int, StaticSeedCondition> _staticSeedCondition;
    public Dictionary<int, StaticSeedCondition> staticSeedCondition
    {
        get
        {
            if (_staticSeedCondition == null)
            {
                Ft_hua_breedConfigData conditionConfigData = ConfigManager.Instance.GetConfig<Ft_hua_breedConfigData>("ft_hua_breedsConfig");
                _staticSeedCondition = new Dictionary<int, StaticSeedCondition>();
                foreach (Ft_hua_breedConfig item in conditionConfigData.DataList)
                {
                    StaticSeedCondition seedCondition = new StaticSeedCondition(item);
                    _staticSeedCondition.Add(seedCondition.FlowerId, seedCondition);
                }
            }
            return _staticSeedCondition;
        }
    }

    public static float ITEM_COUNT_PER_SPOT = 9;

    private Dictionary<int, StaticHandbook> _staticHandbook;
    public Dictionary<int, StaticHandbook> staticHandbook
    {
        get
        {
            if (_staticHandbook == null)
            {
                Ft_booklistConfigData booklistConfigData = ConfigManager.Instance.GetConfig<Ft_booklistConfigData>("ft_booklistsConfig");
                _staticHandbook = new Dictionary<int, StaticHandbook>();
                foreach (Ft_booklistConfig item in booklistConfigData.DataList)
                {
                    StaticHandbook booklistConfig = new StaticHandbook(item);
                    _staticHandbook.Add(booklistConfig.FlowerId, booklistConfig);
                }
            }
            return _staticHandbook;
        }
    }

    public List<StaticHandbook> _staticHandbookList;
    public List<StaticHandbook> staticHandbookList
    {
        get
        {
            if (_staticHandbookList == null)
            {
                Ft_booklistConfigData booklistConfigData = ConfigManager.Instance.GetConfig<Ft_booklistConfigData>("ft_booklistsConfig");
                _staticHandbookList = new List<StaticHandbook>();
                foreach (Ft_booklistConfig item in booklistConfigData.DataList)
                {
                    StaticHandbook booklistConfig = new StaticHandbook(item);
                    _staticHandbookList.Add(booklistConfig);
                }
            }
            return _staticHandbookList;
        }
    }


    private List<StaticHandbook> bookDatHome;

    public void initData()
    {
        bookDatHome = new List<StaticHandbook>();
       
        ParseDataAgain();
    }

    public void parseData(Dictionary<uint, I_VASE_REWARD_STATUS> data)
    {
        vaseRewardInfo = data;
        if (rewardFlowersStatus == null)
        {
            rewardFlowersStatus = new Dictionary<uint, List<uint>>();
        }
        else
        {
            rewardFlowersStatus.Clear();
        }
        foreach (KeyValuePair<uint, I_VASE_REWARD_STATUS> item in data)
        {
            var arr = new List<uint>();
            //if (item.Value.rewardFlowers != null)
            //{
            //    arr = item.Value.rewardFlowers.ToList();
            //}
            rewardFlowersStatus.Add(item.Key, arr);
        }
    }

    public bool IsGetted(uint vaseId, uint flowerId)
    {
        //if (rewardFlowersStatus.ContainsKey(vaseId))
        //{
        //    bool bol = rewardFlowersStatus[vaseId].IndexOf(flowerId) != -1;
        //    return bol;
        //}
        //else
        //{
        //    return false;
        //}
        return false;
    }

    public void FilterBookData(int had, int color, string filter,int style = 0)
    {
        if (bookDatHome == null)
        {
            bookDatHome = new List<StaticHandbook>();
        }
        else
        {
            bookDatHome.Clear();
        }

        ParseDataAgain();
        
        if (had > 0)
        {
            bookDatHome = bookDatHome.FindAll((StaticHandbook value) =>
            {
                bool flag = CheckFlowerIsLock(value.FlowerId);
                if ((flag && had == 1) || (!flag && had == 2))
                {
                    return true;
                }
                return false;
            });
        }
        if (color > 0)
        {
            bookDatHome = bookDatHome.FindAll((StaticHandbook value) =>
            {
                var plant1 = GetStaticSeedCondition(value.FlowerId);
                if (plant1.FlowerQuality == color)
                {
                    return true;
                }
                return false;
            });
        }

        if(style > 0)
        {
            bookDatHome = bookDatHome.FindAll((StaticHandbook value) =>
            {
                var plant1 = GetStaticSeedCondition(value.FlowerId);
                if (plant1.StyleType == style)
                {
                    return true;
                }
                return false;
            });
        }

        if (filter != null && filter != "")
        {
            bookDatHome = bookDatHome.FindAll((StaticHandbook value) =>
            {
                Module_item_defConfig itemData = ItemModel.Instance.GetItemById(value.FlowerId);
                if (itemData != null)
                {
                    string name = Lang.GetValue(itemData.Name);
                    if (name.Contains(filter))
                    {
                        return true;
                    }
                }
                return false;
            });
        }
    }

    public List<StaticHandbook> RetrievePageData()
    {
        return bookDatHome;
    }

    public StaticHandbook GetBookConfigByFlowerId(int flowerId)
    {
        if (staticHandbook.ContainsKey(flowerId))
        {
            return staticHandbook[flowerId];
        }
        return null;
    }

    public StaticSeedCondition GetStaticSeedCondition(int flowerId)
    {
        if (staticSeedCondition.ContainsKey(flowerId))
        {
            return staticSeedCondition[flowerId];
        }
        else
        {
            return null;
        }
    }
    //通过花卡Id获取培育数据
    public StaticSeedCondition GetStaticSeedCondition1(int taskId)
    {
        foreach(var value in staticSeedCondition)
        {
            if(value.Value.TaskId == taskId)
            {
                return value.Value;
            }
        }
        return null;
    }

    public List<StaticSeedCondition> GetNoCultivationList()
    {
        List<StaticSeedCondition> arr = seedConditionList.FindAll((StaticSeedCondition value) =>
        {
            return !value.AlreadyCulitivated && value.UnlockAccessible;
        });
        return arr;
    }


    public void ParseDataAgain()
    {
        foreach (StaticHandbook value in staticHandbookList)
        {
            if (!value.WillCheckInFuture)
            {
                bookDatHome.Add(value);
            }
        }
       bookDatHome.Sort(SortBookDat);

    }

    public int SortBookDat(StaticHandbook a, StaticHandbook b)
    {
        if (CheckFlowerIsLock(a.FlowerId) && !CheckFlowerIsLock(b.FlowerId)) return -1;
        if (!CheckFlowerIsLock(a.FlowerId) && CheckFlowerIsLock(b.FlowerId)) return 1;

        if (CheckFlowerIsCanUp(a.FlowerId) && !CheckFlowerIsCanUp(b.FlowerId)) return -1;

        if (!CheckFlowerIsCanUp(a.FlowerId) && CheckFlowerIsCanUp(b.FlowerId)) return 1;

        if (CheckSeedCanCultivation(a.FlowerId) && !CheckSeedCanCultivation(b.FlowerId)) return -1;

        if (!CheckSeedCanCultivation(a.FlowerId) && CheckSeedCanCultivation(b.FlowerId)) return 1;
        
        if (a.Level != b.Level)
        {
            return b.Level - a.Level;
        }
        return a.BookId < b.BookId ? -1 : 1;
    }

    public bool CheckFlowerIsLock(int flowerId)
    {
        return StorageModel.Instance.AlreadyUnlockSeed(flowerId);
    }

    public StaticHandbook GetSortedPageItemData(int index)
    {
        
        if (bookDatHome.Count > index && index > -1)
        {
            return bookDatHome[index];
        }
        return null;
    }

    public int GetDataLength()
    {  
         return bookDatHome.Count;
    }

    public int GetDataIndex(int flowerId)
    {
        for(int i = 0;i < bookDatHome.Count; i++)
        {
            if(flowerId == bookDatHome[i].FlowerId)
            {
                return i;
            }
        }
        return 0;
    }

    public SeedCropVO GetCropVoByBook(int flowerId)
    {
        return StorageModel.Instance.GetSeedCropVO(flowerId);
    }

    public bool CheckFlowerIsCanUp(int flowerId)
    {
        var seedCondition = GetStaticSeedCondition(flowerId);
        if(seedCondition == null)
        {
            return false;
        }
        if (flowerId == 40011009)
        {
            var c = 4;
        }
        int count = StorageModel.Instance.GetItemCount(seedCondition.SeedId);
        if (count == 0) return false;
        SeedCropVO exp = GetCropVoByBook(flowerId);
        if (exp != null)
        {
            var plantCrop = PlantModel.Instance.GetPlantCropConfigData(seedCondition.LevelMould + "#" + (exp.level + 1));
            if (plantCrop == null) return false;
            return count >= plantCrop.SeedCost && MyselfModel.Instance.gold >= plantCrop.GoldCost;
        }
        else
        {
            return false;
        }
    }

    public bool CheckSeedCanCultivation(int flowerId)
    {
        StaticSeedCondition condition = staticSeedCondition[flowerId];
        return condition.UnlockAccessible && !condition.AlreadyCulitivated;
    }


    public void UpdateVaseReward(uint vaseId, Dictionary<ulong, ulong> items)
    {
        if (vaseRewardInfo.ContainsKey(vaseId))
        {
            //vaseRewardInfo[vaseId].lockStatus = 1;
        }
        else
        {
            I_VASE_REWARD_STATUS vaseRewardData = new I_VASE_REWARD_STATUS();
            //vaseRewardData.lockStatus = 1;
            vaseRewardInfo.Add(vaseId, vaseRewardData);
            if (!rewardFlowersStatus.ContainsKey(vaseId))
            {
                rewardFlowersStatus.Add(vaseId, new List<uint>());
            }
        }
    }

    public void UpdateVaseOnekeyReward(uint vaseId, Dictionary<uint, I_VASE_REWARD_STATUS> vaseInfo)
    {
        foreach (KeyValuePair<uint, I_VASE_REWARD_STATUS> data in vaseInfo)
        {
            if (vaseRewardInfo.ContainsKey(data.Key))
            {
                vaseRewardInfo[data.Key] = data.Value;
                //if (data.Value.rewardFlowers != null)
                //{
                //    if (!rewardFlowersStatus.ContainsKey(data.Key))
                //    {
                //        rewardFlowersStatus.Add(data.Key, new List<uint>());
                //    }
                //    foreach (uint id in data.Value.rewardFlowers)
                //    {
                //        if (rewardFlowersStatus[data.Key].IndexOf(id) == -1)
                //        {
                //            rewardFlowersStatus[data.Key].Add(id);
                //        }
                //    }
                //}

            }
            else
            {

                vaseRewardInfo.Add(data.Key, data.Value);

                var arr = new List<uint>();
                //if (data.Value.rewardFlowers != null)
                //{
                //    arr = data.Value.rewardFlowers.ToList();
                //}
                //if (rewardFlowersStatus.ContainsKey(data.Key))
                //{
                //    rewardFlowersStatus[data.Key] = arr;
                //}
                //else
                //{
                //    rewardFlowersStatus.Add(data.Key, arr);
                //}
            }

        }

    }

    public void UpdateFlowerStatus(uint vaseId, uint flowerId)
    {
        if (rewardFlowersStatus.ContainsKey(vaseId))
        {
            rewardFlowersStatus[vaseId].Add(flowerId);
        }
        else
        {
            var arr = new List<uint>();
            arr.Add(flowerId);
            rewardFlowersStatus.Add(vaseId, arr);
        }
    }
    /**是否已有这个花卡了  */
    public bool hasFlowerCard(int flowerId)
    {
        var data = seedConditionList.Find((value) =>
        {
            return value.FlowerId == flowerId && value.UnlockAccessible;
        });
        return data != null;
    }


    public void UpdateGatherStatus(uint vaseId)
    {
        if (vaseRewardInfo.ContainsKey(vaseId))
        {
            //vaseRewardInfo[vaseId].gathStatus = 1;
        }
        else
        {
            I_VASE_REWARD_STATUS vaseRewardData = new I_VASE_REWARD_STATUS();
            //vaseRewardData.gathStatus = 1;
            vaseRewardInfo.Add(vaseId, vaseRewardData);
            if (!rewardFlowersStatus.ContainsKey(vaseId))
            {
                rewardFlowersStatus.Add(vaseId, new List<uint>());
            }
        }
    }
}


public class StaticSeedCondition
{
    public int FlowerId { get; set; }
    public int TaskId { get; set; }
    public List<ItemIdObject> ItemIds { get; set; }
    public string FlowerLanguage { get; set; }
    public int WaitingTime { get; set; }

    public int FlowerQuality { get; set; }

    public int SeedId { get; set; }

    public int ShareId { get; set; }

    public int ShardNum { get; set; }
    public int StyleType { get; set; }
    public int ClubWeight { get; set; }
    public int LevelMould { get; set; }
    public bool AlreadyCulitivated { get { return StorageModel.Instance.AlreadyUnlockSeed(FlowerId); } }

    public bool UnlockAccessible
    {
        get
        {
            return ItemUnlockAvaliable;
        }
    }


    public bool ItemUnlockAvaliable { get { return StorageModel.Instance.GetItemById(TaskId) != null; } }
    public StaticSeedCondition(Ft_hua_breedConfig data)
    {
        FlowerId = data.FlowerId;
        TaskId =  data.TaskId ;
        ItemIds = new List<ItemIdObject>(data.ItemIds);
        FlowerLanguage = "";
        FlowerQuality = data.FlowerQuality;
        SeedId = data.SeedId;
        WaitingTime = data.WaitingTime;
        ShareId = data.ShardId;
        ShardNum = data.ShardNum;
        StyleType = data.StyleType;
        ClubWeight = data.ClubWeight;
        LevelMould = data.LevelMould;
    }
}

public class StaticHandbook
{
    public int BookId { get; set; }
    public int FlowerId { get; set; }
    public int ShareId { get; set; }
    public string Tips { get; set; }
    public string ChangedTips { get; set; }
    public string WeixinChangeTime { get; set; }
    public string SourceConfig { get; set; }
    public double Scale { get; set; }

    private int ChangeTime { get { return TimeUtil.GetNumericTime(WeixinChangeTime); } }
    /**是否是多肉 */
    public bool IsSucculent { get { 
            Module_item_defConfig sItem = ItemModel.Instance.GetItemById(FlowerId);
            if (sItem != null)
            {
                 return ItemModel.Instance.IsSucculent(sItem);
            }
            return false;
        } }
    public string Curtips { get { return ServerTime.Time >= ChangeTime ? ChangedTips : Tips; } }

    public int Level { get { return FlowerHandbookModel.Instance.GetStaticSeedCondition(FlowerId).FlowerQuality; } }
    /**是否未到显示时间 */
    public bool WillCheckInFuture
    {
        get { return ServerTime.Time < ChangeTime; }
    }
    public StaticHandbook(Ft_booklistConfig data)
    {
        BookId = data.BookId;
        FlowerId = data.FlowerId;
        ShareId = data.ShareId;
        Tips = data.Tips;
        ChangedTips = data.ChangedTips;
        WeixinChangeTime = data.WeixinChangeTime;
        SourceConfig = data.SourceConfig;
        Scale = data.Scale;
    }

   
}

