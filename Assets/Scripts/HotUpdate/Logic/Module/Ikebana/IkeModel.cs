using Elida.Config;
using protobuf.ikebana;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkeModel : Singleton<IkeModel>
{
    /**
    * 花瓶表
    */
    public List<StaticFlowerPoint> staticFlowerPoint;

    public Dictionary<int, StaticFlowerPoint> staticFlowerPointMap;

    public List<StaticFlowerPoint> _vaseConfigList;
    /**
    * 插花材料表
    */
    public List<StaticFlower> staticFlower;
    /**
    * 插花组合配方表
    */
    public List<StaticFormula> staticFormula;
    ///**
    //* 多肉插花表
    //*/
    //public List<StaticSucculentIke> staticSucculentIke;
    //已制作的花艺品
    public Dictionary<uint, I_VASE_REWARD_STATUS> vaseRewardInfo = new Dictionary<uint, I_VASE_REWARD_STATUS>();
    public StaticFlowerPoint GetStaticFlowerPoint(int vaseid)
    {
        if (staticFlowerPointMap.TryGetValue(vaseid, out StaticFlowerPoint staticFlowerPoint))
        {
            return staticFlowerPoint;
        }
        return null;
    }

    public StaticFlowerPoint GetStaticFlowerPoint1(int vaseid)
    {
        foreach(var value in staticFlowerPointMap)
        {
            if(value.Value.UnlockProps == vaseid)
            {
                return value.Value;
            }
        }
        return null;
    }

    public List<StaticFlowerPoint> vaseConfigList
    {
        get
        {
            if (_vaseConfigList == null)
            {
                _vaseConfigList = new List<StaticFlowerPoint>();
                _vaseConfigList.AddRange(staticFlowerPoint);
            }
            if (FlowerHandbookModel.Instance.vaseRewardInfo != null)
            {
                _vaseConfigList.Sort(SortVaseConfigList);
            }
            return _vaseConfigList;
        }
    }

    public int GetVaseListIndex(int vaseId)
    {
        for (int i = 0; i < vaseConfigList.Count; i++)
        {
            if (vaseConfigList[i].VaseId == vaseId)
            {
                return i;
            }
        }
        return -1;
    }

    public int SortVaseConfigList(StaticFlowerPoint a, StaticFlowerPoint b)
    {
        if (IsCanGetVaseReward(a.VaseId) && !IsCanGetVaseReward(b.VaseId))
        {
            return -1;
        }
        if (!IsCanGetVaseReward(a.VaseId) && IsCanGetVaseReward(b.VaseId))
        {
            return 1;
        }
        if (IsUnlockVase(a.VaseId) && !IsUnlockVase(b.VaseId))
        {
            return -1;
        }
        if (!IsUnlockVase(a.VaseId) && IsUnlockVase(b.VaseId))
        {
            return 1;
        }
        return a.VaseId > b.VaseId ? 1 : -1;
    }

    public bool IsCanGetVaseReward(int vaseId)
    {
        //bool count = IsUnlockVase(vaseId);
        //if (!FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)vaseId))
        //{
        //    return count;
        //}
        //var svr = FlowerHandbookModel.Instance.vaseRewardInfo[(uint)vaseId];

        //var gettedReward = FlowerHandbookModel.Instance.rewardFlowersStatus;
        //if (count && svr.lockStatus == 0)
        //{
        //    return true;
        //}
        //bool isHave = false;
        //for (int i = 0; i < 3; i++)
        //{
        //    var flowerData = GetFlowerBySlot((i + 1), vaseId);

        //    foreach (var item in flowerData)
        //    {
        //        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[item.FlowersDI];
        //        if (!FlowerHandbookModel.Instance.IsGetted((uint)vaseId, (uint)item.FlowersDI) && condition.UnlockAccessible)
        //        {
        //            return true;
        //        }
        //        if (!FlowerHandbookModel.Instance.IsGetted((uint)vaseId, (uint)item.FlowersDI))
        //        {
        //            isHave = true;
        //        }

        //    }
        //}
        //if (svr.lockStatus == 1 && !isHave && svr.gathStatus == 0)
        //{
        //    return true;
        //}
        return false;
    }
    //更新已制作的花艺品
    public void UpdateMakeIke(uint id)
    {
        if (!vaseRewardInfo.ContainsKey(id))
        {
            var vase = new I_VASE_REWARD_STATUS();
            vase.status = 1;
            vase.shareStatus = 1;
            vaseRewardInfo.Add(id, vase);
        }
    }
    public void UpdateShareIke(uint id)
    {
        if (vaseRewardInfo.ContainsKey(id))
        {
            vaseRewardInfo[id].shareStatus = 2;
        }
    }
    public int GetIkeStatus(uint id)
    {
        if (vaseRewardInfo.ContainsKey(id))
        {
            return (int)vaseRewardInfo[id].status;
        }
        return 0;
    }
    public int GetIkeShareStatus(uint id)
    {
        if (vaseRewardInfo.ContainsKey(id))
        {
            return (int)vaseRewardInfo[id].shareStatus;
        }
        return 0;
    }
    public List<ArtData> GetVaseList()
    {
        var vaseList = new List<ArtData>();
        foreach (var value in vaseRewardInfo)
        {
            var vase = new ArtData();
            vase.FormulaId = (int)value.Key;
            var itemVo = ItemModel.Instance.GetItemById((int)value.Key);
            vase.item = itemVo;
            vaseList.Add(vase);
        }
        vaseList.Sort((a, b) => b.item.Quality - a.item.Quality);
        return vaseList;
    }
    public int IsCanGetGathReward(int vaseId)
    {
        bool unlock = IsUnlockVase(vaseId);
        int status = 0;
        if (unlock)
        {
            var gettedReward = FlowerHandbookModel.Instance.rewardFlowersStatus;
            bool isHas = true;
            for (int i = 0; i < 3; i++)
            {
                var flowerData = GetFlowerBySlot((i + 1), vaseId);

                foreach (var item in flowerData)
                {
                    StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[item.FlowersDI];
                    if (!condition.UnlockAccessible)
                    {
                        isHas = false;
                    }
                }
            }

            //if (FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)vaseId))
            //{
            //    if (isHas && FlowerHandbookModel.Instance.vaseRewardInfo[(uint)vaseId].gathStatus == 0)
            //    {
            //        status = 1;
            //        return status;
            //    }
            //    else if (FlowerHandbookModel.Instance.vaseRewardInfo[(uint)vaseId].gathStatus == 1)
            //    {
            //        status = 2;
            //        return status;
            //    }
            //}
            //else
            //{
            //    if (isHas)
            //    {
            //        status = 1;
            //        return status;
            //    }
            //}

        }

        return status;
    }
    public bool IsAllGetted(int vaseId)
    {
        //if (!FlowerHandbookModel.Instance.vaseRewardInfo.ContainsKey((uint)vaseId))
        //{
        //    return false;
        //}
        //var svr = FlowerHandbookModel.Instance.vaseRewardInfo[(uint)vaseId];
        //var gettedReward = FlowerHandbookModel.Instance.rewardFlowersStatus;
        //if (svr.lockStatus == 0 || svr.gathStatus == 0)
        //{
        //    return false;
        //}
        //for (int i = 0; i < 3; i++)
        //{
        //    var flowerData = GetFlowerBySlot((i + 1), vaseId);

        //    foreach (var item in flowerData)
        //    {
        //        if (!FlowerHandbookModel.Instance.IsGetted((uint)vaseId, (uint)item.FlowersDI))
        //        {
        //            return false;
        //        }

        //    }
        //}
        return true;
    }

    public string HasFlowerDesc(int vaseId)
    {
        int currNum = 0;
        int max = 0;
        for (int i = 0; i < 3; i++)
        {
            var flowerData = GetFlowerBySlot((i + 1), vaseId);
            max += flowerData.Count;
            foreach (var item in flowerData)
            {

                StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[item.FlowersDI];
                if (condition.UnlockAccessible)
                {
                    currNum++;
                }

            }
        }
        return currNum + "/" + max;
    }

    public List<StaticFlowerPoint> staticSucculentPoint
    {
        get
        {
            return staticFlowerPoint;
        }
    }

    public void initData()
    {
        Ft_ikebana_vaseConfigData staticFlowerPointData = ConfigManager.Instance.GetConfig<Ft_ikebana_vaseConfigData>("ft_ikebana_vasesConfig");
        Ft_ikebana_flowerConfigData ikebanaConfigData = ConfigManager.Instance.GetConfig<Ft_ikebana_flowerConfigData>("ft_ikebana_flowersConfig");
        Ft_ikebana_artConfigData arrangementtwoConfigData = ConfigManager.Instance.GetConfig<Ft_ikebana_artConfigData>("ft_ikebana_artsConfig");
        //Arrange_succulentConfigData succulentConfigData = ConfigManager.Instance.GetConfig<Arrange_succulentConfigData>("ft_arrange_succulentConfig");

        staticFlower = new List<StaticFlower>();
        staticFlowerPoint = new List<StaticFlowerPoint>();
        staticFlowerPointMap = new Dictionary<int, StaticFlowerPoint>();
        staticFormula = new List<StaticFormula>();
        ////staticSucculentIke = new List<StaticSucculentIke>();

        foreach (Ft_ikebana_vaseConfig item in staticFlowerPointData.DataList)
        {
            StaticFlowerPoint flowerPointData = new StaticFlowerPoint(item);
            staticFlowerPoint.Add(flowerPointData);
            staticFlowerPointMap.Add(flowerPointData.VaseId, flowerPointData);
        }

        foreach (Ft_ikebana_flowerConfig item in ikebanaConfigData.DataList)
        {
            StaticFlower staticFlowerData = new StaticFlower(item);
            staticFlower.Add(staticFlowerData);
        }

        foreach (Ft_ikebana_artConfig item in arrangementtwoConfigData.DataList)
        {
            StaticFormula staticFormulaData = new StaticFormula(item);
            staticFormula.Add(staticFormulaData);
        }

        //foreach(Arrange_succulentConfig item in succulentConfigData.DataList)
        //{
        //    StaticSucculentIke succulentIke = new StaticSucculentIke(item);
        //    staticSucculentIke.Add(succulentIke);
        //}
    }
    public List<StaticFlowerPoint> bookDatHome;
    public void vaseFilterList(int had, string name, int color)
    {
        if (bookDatHome == null)
        {
            bookDatHome = new List<StaticFlowerPoint>();
        }
        else
        {
            bookDatHome.Clear();
        }
        

        foreach (StaticFlowerPoint value in vaseConfigList)
        {
            if (color > 0 && value.VaseQuality != color)
            {
                continue;
            }

            if (had > 0)
            {
                //bool flag = StorageModel.Instance.GetItemCount(value.VaseId) > 0;
                bool flag = IsUnlockVase(value.VaseId);
                if (had == 2 && flag)
                {
                    continue;
                }
                else if (had == 1 && !flag)
                {
                    continue;
                }
            }



            if (name != "")
            {
                bool bol = false;
                for (int i = 0; i < 3; i++)
                {
                    var flowerData = GetFlowerBySlot((i + 1), value.VaseId);
                    bool isHave = false;
                    foreach (var item in flowerData)
                    {
                        string flowerName = ItemModel.Instance.GetNameByEntityID(item.FlowersDI);
                        if (flowerName.Contains(name))
                        {
                            isHave = true;
                            break;
                        }

                    }
                    if (isHave)
                    {
                        bol = true;
                        break;
                    }
                }
                if (!bol)
                {
                    continue;
                }
            }
            bookDatHome.Add(value);
        }
        bookDatHome.Sort(BookSort);
    }
    public int BookSort(StaticFlowerPoint a, StaticFlowerPoint b)
    {
        return b.VaseQuality - a.VaseQuality;
    }
    //根据插槽类型获取花朵数据
    public List<StaticFlower> GetFlowerBySlot(int slot, int vaseId)
    {
        List<StaticFlower> ary = new List<StaticFlower>();
        foreach (StaticFlower item in staticFlower)
        {
            for (int j = 0; j < item.Slots.Count; j++)
            {
                if (item.Slots[j].Limit == slot && item.Slots[j].CounterCount == vaseId.ToString())
                {
                    ary.Add(item);
                }
            }

        }
        return ary;
    }

    public List<StaticFlowerPoint> GetVaseByFowerId(int flowerId)
    {
        List<StaticFlowerPoint> data = new List<StaticFlowerPoint>();

        foreach (StaticFlowerPoint value in vaseConfigList)
        {
            for (int i = 0; i < 3; i++)
            {
                var flowerData = GetFlowerBySlot((i + 1), value.VaseId);
                bool isHave = false;

                foreach (var item in flowerData)
                {
                    if (item.FlowersDI == flowerId)
                    {
                        isHave = true;
                        break;
                    }

                }

                if (isHave)
                {
                    break;
                }
            }
            data.Add(value);
        }
        return data;
    }

    public List<StaticFlowerPoint> staticFlowerPointList
    {
        get
        {
            return staticFlowerPoint.FindAll((value) =>
{
    return (value.UnlockProps == 0 || StorageModel.Instance.GetItemCount(value.UnlockProps) > 0);
});
            //list.Sort((a, b) => a.SortNum - b.SortNum);
            //return list;
        }
    }

    public bool GetIsExitSlot()
    {
        return false;
    }

    public StaticFormula GetFormulaData(int a, int b, int c, int vaseId)
    {
        StaticFormula data = null;
        bool a_, b_, c_;
        foreach (StaticFormula vo in staticFormula)
        {
            List<FlowerCombinationIdObject> s = vo.FlowerCombinationIds;
            a_ = b_ = c_ = false;
            foreach (FlowerCombinationIdObject val in s)
            {
                if (val.CounterCount == a.ToString())
                {
                    a_ = true;
                }
                if (val.CounterCount == b.ToString())
                {
                    b_ = true;
                }
                if (val.CounterCount == c.ToString())
                {
                    c_ = true;
                }
            }
            if (a_ && b_ && c_)
            {
                if (vo.VaseId == vaseId)
                {
                    data = vo;
                }
            }
        }
        return data;
    }

    public int GetFormulaPriceByCombinationId(int combinationId)
    {
        int getGold = 0;
        StaticFormula formula = GetFormula(combinationId);
        if (formula != null)
        {
            foreach (FlowerCombinationIdObject item in formula.FlowerCombinationIds)
            {
                getGold += OrderModel.Instance.GetFlowerAdditionGold(item.CounterCount) * item.Limit;
            }
        }
        return getGold;
    }

    public StaticFormula GetFormula(int id)
    {
        StaticFormula data = null;
        for (int i = 0; i < staticFormula.Count; i++)
        {
            if (staticFormula[i].CombinationId == id)
            {
                data = staticFormula[i];
                break;
            }
        }
        return data;
    }
    public StaticFormula GetFormula1(int id)
    {
        return staticFormula.Find(value => value.IkebanaId == id);
    }
    public bool CheckStorageVase(int vaseId)
    {
        List<StaticFlowerPoint> vases = staticFlowerPoint.FindAll((v) =>
        {
            return (v.VaseId == vaseId && v.UnlockProps != 0);
        });

        if (vases != null && vases.Count > 0)
        {
            return true;
        }
        return false;
    }

    //public List<StaticSucculentIke> GetSucculentFormula(int vaseId)
    //{
    //    return staticSucculentIke.FindAll((v) =>
    //    {
    //        return v.VaseId == vaseId;
    //    });
    //}

    public StaticFormula GetFormulaByItemId(int itemId)
    {
        return staticFormula.Find(v => v.MatChFloralArt(itemId));
    }
    public List<StaticFormula> GetFormulaByVaseID(int vaseId)
    {
        var listData = staticFormula.FindAll(v => v.VaseId == vaseId);
        listData.Sort((a, b) => a.Status - b.Status);
        return listData;
    }
    public int GetFormulaPrice(int itemId)
    {
        int getGold = 0;
        var formula = GetFormulaByItemId(itemId);
        foreach (var cfg in formula.FlowerCombinationIds)
        {
            int value = BuffManager.Instance.GetAddCount(BuffType.Npc_Glod_Type, int.Parse(cfg.CounterCount)) * cfg.Limit;
            getGold += value;
        }
        return getGold;
    }

    public int GetFormulaPrice1(int itemId)
    {
        int getGold = 0;
        var formula = GetFormulaByItemId(itemId);
        foreach (var cfg in formula.FlowerCombinationIds)
        {
            int value = BuffManager.Instance.GetAddCount(BuffType.Desk_Gold_Type, int.Parse(cfg.CounterCount)) * cfg.Limit;
            getGold += value;
        }
        return getGold;
    }

    /// <summary>
    /// 获取单个插花经验
    /// </summary>
    /// <param name="itemId"></param>
    /// <returns></returns>
    public int GetFormulaExp(int itemId)
    {
        int getExp = 0;
        var formula = GetFormulaByItemId(itemId);
        foreach (var cfg in formula.FlowerCombinationIds)
        {
            int value = BuffManager.Instance.GetAddCount(BuffType.Npc_Exp_Type, int.Parse(cfg.CounterCount)) * cfg.Limit;
            getExp += value;

        }
        return getExp;
    }

    public int[] GetFlowerListByDemandItem(int demandItemId)
    {
        var dat = GetFormulaByItemId(demandItemId);
        return new int[] { int.Parse(dat.FlowerCombinationIds[0].CounterCount), int.Parse(dat.FlowerCombinationIds[1].CounterCount), int.Parse(dat.FlowerCombinationIds[2].CounterCount) };
    }

    public StaticFlower GetFlower(int id)
    {
        return staticFlower.Find(v => v.FlowersDI == id);
    }

    public bool IsUnlockVase(int vaseId)
    {
        var value = staticFlowerPointMap[vaseId];
        if ((value.UnlockProps == 0 || StorageModel.Instance.GetItemCount(value.UnlockProps) > 0))
        {
            if (int.Parse(value.Leve) > MyselfModel.Instance.level)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    public int GetVaseCount()
    {
        var count = 0;
        foreach (StaticFlowerPoint value in vaseConfigList)
        {
            if (IsUnlockVase(value.VaseId))
            {
                count++;
            }
        }
        return count;
    }

    public bool GetCanMake(int count, int id)
    {
        var formula = GetFormula(id);
        foreach(var value in formula.FlowerCombinationIds)
        {
            var num = StorageModel.Instance.GetItemCount(int.Parse(formula.FlowerCombinationIds[2].CounterCount));
            if(count > num)
            {
                return false;
            }
        }
        return true;
    }
}

public class StaticFlowerPoint
{
    //花瓶ID
    public int VaseId { get; set; }
    //在类型  [1,2]
    public List<int> Typess { get; set; }
    //花瓶解锁等级
    public string Leve { get; set; }
    //前置条件, 解锁此物品后才能使用    0 || 44020006
    public int UnlockProps { get; set; }
    //分享id, 关联ft_shareConfig.json中的 fx_id
    public int ShareId { get; set; }
    //花瓶手册里解锁时可领取的奖励
    public UnlockRewardObject[] UnlockRewards { get; set; }
    /**花瓶在花瓶手册里集齐所有插花可领取的奖励 */
    public GatherRewardObject[] GatherRewards { get; set; }

    public int VaseQuality { get; set; }


    public StaticFlowerPoint(Ft_ikebana_vaseConfig data)
    {
        VaseId = data.VaseId;
        Leve = data.Leve;
        UnlockProps = data.UnlockProps;
        ShareId = data.ShareId;
        UnlockRewards = data.UnlockRewards;
        GatherRewards = data.GatherRewards;
        VaseQuality = data.VaseQuality;
    }
    public bool MatchVaseId(int id)
    {
        return VaseId == id;
    }

    public int SortNum
    {
        get
        {

            if (IkeModel.Instance.IsUnlockVase(VaseId))
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}

public class StaticFlower
{
    /**
    * 插花材料ID
    */
    public int FlowersDI { get; set; }
    /**
    * 对应不同花瓶的槽位
    */
    public List<SlotObject> Slots { get; set; }
    /**该花在花瓶手册里解锁时可领取的奖励 */
    public List<UnlockRewardObject> UnlockRewards { get; set; }

    public StaticFlower(Ft_ikebana_flowerConfig obj)
    {
        FlowersDI = obj.FlowersDI;
        Slots = new List<SlotObject>(obj.Slots);
        UnlockRewards = new List<UnlockRewardObject>(obj.UnlockRewards);
    }
}


public class StaticFormula
{
    /**
    * 插花组合ID
    */
    public int CombinationId { get; set; }
    /**
    * 插花材料集合
    */
    public List<FlowerCombinationIdObject> FlowerCombinationIds { get; set; }

    public int IsEntry { get; set; }
    //花瓶id
    public int VaseId { get; set; }
    //花艺id
    public int IkebanaId { get; set; }
   
    //随机代币
    public List<TokenObject> Tokens { get; set; }
    //概率
    public int Probability { get; set; }
    //订单数量
    public List<int> Ratios { get; set; }
    //订单等级
    public int Level { get; set; }
    //是否需要先解锁花
    public int Vase { get; set; }

    // 花艺经验
    public int ArtExp;
    // 出售的金币
    public int SellPrice;
    // 顾客订单单个奖励
    public CustomPriceObject[] CustomPrices;
    public int Status { get
        {
            var status = IkeModel.Instance.GetIkeStatus((uint)CombinationId);
            if (status == 0)
            {
                return 2;
            }
            else if(status == 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        } }

    public StaticFormula(Ft_ikebana_artConfig obj)
    {
        CombinationId = obj.CombinationId;
        FlowerCombinationIds = new List<FlowerCombinationIdObject>(obj.FlowerCombinationIds);
        VaseId = obj.VaseId;
        IkebanaId = obj.IkebanaId;

        SellPrice = obj.SellPrice;
        CustomPrices = obj.CustomPrices;
        Probability = obj.Probability;
        Ratios = new List<int>(obj.Ratios);
        Level = obj.Level;
        Vase = obj.Vase;
        IsEntry = obj.IsEntry;
        ArtExp = obj.ArtExp;
    }

    public bool MatChFloralArt(int artId)
    {
        return IkebanaId == artId;
    }

    
}

public class ArtData
{
    public int FormulaId;
    public Module_item_defConfig item;
}

//public class StaticSucculentIke
//{
//    public int FormulaId { get; set; }
//    public int ArrangeId { get; set; }
//    public int VaseId { get; set; }
//    public List<SucculentItemConfig> SucculentItems { get; set; }
//    public string Tips { get; set; }

//    public StaticSucculentIke(Arrange_succulentConfig obj)
//    {
//        FormulaId = obj.FormulaId;
//        ArrangeId = obj.ArrangeId;
//        VaseId = obj.VaseId;
//        SucculentItems = obj.SucculentItems;
//        Tips = obj.Tips;
//    }

//}