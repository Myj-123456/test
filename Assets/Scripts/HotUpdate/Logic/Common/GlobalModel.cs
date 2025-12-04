using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using UnityTimer;
using System.Linq;
using Elida.Config;

public class GlobalModel : Singleton<GlobalModel>
{
    public Module_profileConfigData module_profileConfigData;//杂项设置表

    public ModuleProfileConfigVo module_profileConfig;

    public Dictionary<int, Ft_game_system_unlockConfig> gameSystemUnlock;

    public void InitModule_profileConfigData()
    {
        module_profileConfig = new ModuleProfileConfigVo();
        if (module_profileConfigData == null) module_profileConfigData = ConfigManager.Instance.GetConfig<Module_profileConfigData>("module_profilesConfig");

        gameSystemUnlock = ConfigManager.Instance.GetConfig<Ft_game_system_unlockConfigData>("ft_game_system_unlocksConfig").DataMap;
        //module_profileConfig.FuliFlowerLevel = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fuliFlowerLevel").Value);
        
        //module_profileConfig.FuliFlowerTime = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fuliFlowerTime").Value);

        //string str = "{\"12345\":1234}";
        //string test = module_profileConfigData.Get("newFlowerReward_Day1").Value.Replace("\\","");
        module_profileConfig.newFlowerReward_Day1 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("newFlowerReward_Day1").Value);
        module_profileConfig.newFlowerReward_Day2 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("newFlowerReward_Day2").Value);
        module_profileConfig.newFlowerReward_Day3 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("newFlowerReward_Day3").Value);
        CultivationModel.Instance.ParesCostInfo(module_profileConfigData.Get("CultivatingTime").Value);
        module_profileConfig.flowerStarPremise = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("flowerStarPremise").Value);

        module_profileConfig.waterInit = uint.Parse(module_profileConfigData.Get("waterInit").Value);
        module_profileConfig.waterLimit = uint.Parse(module_profileConfigData.Get("waterLimit").Value);
        module_profileConfig.waterLimitVip = uint.Parse(module_profileConfigData.Get("waterLimitVip").Value);
        module_profileConfig.waterChargeAmount = uint.Parse(module_profileConfigData.Get("waterChargeAmount").Value);
        module_profileConfig.waterChargeInterval = uint.Parse(module_profileConfigData.Get("waterChargeInterval").Value);
        module_profileConfig.friendCountMax = uint.Parse(module_profileConfigData.Get("upper_limit_of_friends").Value);
        module_profileConfig.friendFlushTime = module_profileConfigData.Get("recommend_friends_to_refresh").Value;
        module_profileConfig.npcLimit = uint.Parse(module_profileConfigData.Get("npcLimit").Value);
        module_profileConfig.npcFrequency = uint.Parse(module_profileConfigData.Get("npcFrequency").Value);
        module_profileConfig.npcRefreshTime = uint.Parse(module_profileConfigData.Get("npcRefreshTime").Value);
        module_profileConfig.mostTasksExist = uint.Parse(module_profileConfigData.Get("mostTasksExist").Value);
        module_profileConfig.flowerShelfCount = uint.Parse(module_profileConfigData.Get("flowerShelfCount").Value);

        CultivationShopModel.Instance.freeMaxTime = uint.Parse(module_profileConfigData.Get("shopFreeTime").Value);
        CultivationShopModel.Instance.refrushTimeGap = int.Parse(module_profileConfigData.Get("shopRefreshTime").Value);
        module_profileConfig.costItem = StringUtil.DeserializeObject<List<Dictionary<string, int>>>(module_profileConfigData.Get("costItem").Value);
        module_profileConfig.npcGoldAddition = uint.Parse(module_profileConfigData.Get("npcGoldAddition").Value);
        module_profileConfig.npcExpAddition = uint.Parse(module_profileConfigData.Get("npcExpAddition").Value);
        module_profileConfig.monsterFrequency = uint.Parse(module_profileConfigData.Get("monsterFrequency").Value);
        module_profileConfig.monsterLimit = uint.Parse(module_profileConfigData.Get("monsterLimit").Value);
        module_profileConfig.monsterReward = uint.Parse(module_profileConfigData.Get("monsterReward").Value);

        module_profileConfig.passwordCost = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("passwordCost").Value);
        //module_profileConfig.guildCreatecost = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("persekutuanBuat").Value);

        //module_profileConfig.guildChangeNameCost = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("persekutuanNama").Value);

        //module_profileConfig.guildDonateMax = uint.Parse(module_profileConfigData.Get("persekutuanjumlahDonasi").Value);
        //module_profileConfig.guildFlowerpotConsumables = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("persekutuanFlower").Value);

        module_profileConfig.persekutuanCharacter = int.Parse(module_profileConfigData.Get("persekutuanCharacter").Value);
        module_profileConfig.persekutuanSay = int.Parse(module_profileConfigData.Get("persekutuanSay").Value);

        module_profileConfig.dailyTaskBoxReward = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("dailyTaskBoxReward").Value);

        module_profileConfig.itemIncreaseRate = int.Parse(module_profileConfigData.Get("itemIncreaseRate").Value);
        module_profileConfig.sellTime = int.Parse(module_profileConfigData.Get("sellTime").Value);
        module_profileConfig.umberOfMutualaid = int.Parse(module_profileConfigData.Get("umberOfMutualaid").Value);

        module_profileConfig.flowerMarketRefresh = int.Parse(module_profileConfigData.Get("flowerMarketRefresh").Value);

        module_profileConfig.flowerMarketgold = int.Parse(module_profileConfigData.Get("flowerMarketgold").Value);

        module_profileConfig.flowerMarketexperience = int.Parse(module_profileConfigData.Get("flowerMarketexperience").Value);

        module_profileConfig.flowerMarkettime = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("flowerMarkettime").Value);

        MyselfModel.Instance.expVip = int.Parse(module_profileConfigData.Get("expVip").Value);

        CultivationModel.Instance.helpMaxCount = int.Parse(module_profileConfigData.Get("breedShareLimit").Value);

        module_profileConfig.firstRechargeValue = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("FirstRechargeValue").Value);

        for(int i = 0; i < 3; i++)
        {
            var reward = new Dictionary<string, int>();
            reward = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("FirstRechargeReward_Day" + (i + 1)).Value);
            RechargeModel.Instance.firstRechargeReward.Add(i, reward);
        }

        module_profileConfig.everyVipReward = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("everyVipReward").Value);

        //ScientificPlantingModel.Instance.ParseCostInfo(module_profileConfigData.Get("CultivatingTime").Value);

        module_profileConfig.flowerStarGetPrice = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("flowerStarGetPrice").Value);

        module_profileConfig.percentColor = StringUtil.DeserializeObject<List<string>>(module_profileConfigData.Get("percentColor").Value);

        module_profileConfig.numberColor = StringUtil.DeserializeObject<List<string>>(module_profileConfigData.Get("numberColor").Value);

        module_profileConfig.universalShardId = int.Parse(module_profileConfigData.Get("universalShardId").Value);
        
        module_profileConfig.breakItemId = int.Parse(module_profileConfigData.Get("breakItemId").Value);

        module_profileConfig.petExpItem = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("petExpItem").Value);
        module_profileConfig.petExpItemNum = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("petExpItemNum").Value);

        module_profileConfig.fairySummonItem = int.Parse(module_profileConfigData.Get("fairySummonItem").Value);
        module_profileConfig.fairySumCost1 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fairySumCost1").Value);
        module_profileConfig.fairySumCost2 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fairySumCost2").Value);
        module_profileConfig.fairySumCost3 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fairySumCost3").Value);
        module_profileConfig.fairySumQualityProb = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("fairySumQualityProb").Value);

        module_profileConfig.giftLimitCost = int.Parse(module_profileConfigData.Get("giftLimitCost").Value);
        module_profileConfig.ikebanaLimitCost = int.Parse(module_profileConfigData.Get("ikebanaLimitCost").Value);
        module_profileConfig.buyLimitCost = int.Parse(module_profileConfigData.Get("buyLimitCost").Value);

        module_profileConfig.arenaVictoryReward = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("arenaVictoryReward").Value);
        module_profileConfig.arenaTicketId = int.Parse(module_profileConfigData.Get("arenaTicketId").Value);
        module_profileConfig.arenaFreshCost = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("arenaFreshCost").Value);

        module_profileConfig.FirstRechargeReward_Day1 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("FirstRechargeReward_Day1").Value);
        module_profileConfig.FirstRechargeReward_Day2 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("FirstRechargeReward_Day2").Value);
        module_profileConfig.FirstRechargeReward_Day3 = StringUtil.DeserializeObject<Dictionary<string, int>>(module_profileConfigData.Get("FirstRechargeReward_Day3").Value);

        module_profileConfig.poltItemId = int.Parse(module_profileConfigData.Get("poltItemId").Value);
        module_profileConfig.poltItemGet = int.Parse(module_profileConfigData.Get("poltItemGet").Value);
        module_profileConfig.poltItemLimit = int.Parse(module_profileConfigData.Get("poltItemLimit").Value);
        module_profileConfig.chouItemId = int.Parse(module_profileConfigData.Get("chouItemId").Value);
        module_profileConfig.chouOrderNum = int.Parse(module_profileConfigData.Get("chouOrderNum").Value);

        module_profileConfig.signDayCost = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("signDayCost").Value);

        module_profileConfig.contractLevelup = int.Parse(module_profileConfigData.Get("contractLevelup").Value);

        module_profileConfig.dianWaterTime1 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("dianWaterTime1").Value);
        module_profileConfig.dianWaterTime2 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("dianWaterTime2").Value);
        module_profileConfig.dianWaterTime3 = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("dianWaterTime3").Value);
        module_profileConfig.dianWaterReward = int.Parse(module_profileConfigData.Get("dianWaterReward").Value);
        module_profileConfig.bucketRecoverCD = int.Parse(module_profileConfigData.Get("bucketRecoverCD").Value);
        module_profileConfig.bucketMax = int.Parse(module_profileConfigData.Get("bucketMax").Value);
        module_profileConfig.bucketMaxDay = int.Parse(module_profileConfigData.Get("bucketMaxDay").Value);
        module_profileConfig.bucketVideoProb = int.Parse(module_profileConfigData.Get("bucketVideoProb").Value);
        module_profileConfig.bucketRewardWater = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("bucketRewardWater").Value);
        module_profileConfig.bucketVideoReward = StringUtil.DeserializeObject<List<int>>(module_profileConfigData.Get("bucketVideoReward").Value);

        module_profileConfig.keHuifuCd = int.Parse(module_profileConfigData.Get("keHuiFuCd").Value);
        module_profileConfig.keMaxNum = int.Parse(module_profileConfigData.Get("keMaxNum").Value);
    }

    public uint startTickServerTime = 0;//记录开始Tick的服务器时间
    private Timer timer;
    /// <summary>
    /// 启动一个全局定时器
    /// 跨天暂时也在这里检测
    /// 其他任何业务上的Tick事务都不要在这里处理,避免负担过重
    /// </summary>
    public void StartTick()
    {
        startTickServerTime = ServerTime.Time;
        MyselfModel.Instance.lastServerTime = startTickServerTime;
        if (timer != null)
        {
            timer.Cancel();
            timer = null;
        }
        timer = Timer.RegistGlobal(1, OnTick, true);
    }

    private void OnTick()
    {
        MyselfModel.Instance.OnTick();
    }

    public bool GetUnlocked(SysId sysId,bool log = false)
    {
        int level = (int)MyselfModel.Instance.level;
        if (!gameSystemUnlock.ContainsKey((int)sysId))
        {
            return false;
        }
        var gameUnlock = gameSystemUnlock[(int)sysId];
        if(gameUnlock.IsTaskUnlock == 0)
        {
            int need_level = gameSystemUnlock[(int)sysId].Level;
            if (level < need_level && log)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_lvLimit_tip", need_level.ToString()));
            }
            return level >= need_level;
        }
        else
        {
            int need_level = gameSystemUnlock[(int)sysId].Level;
            if (TaskModel.Instance.mainTask.mainTaskId == 0 || TaskModel.Instance.mainTask.mainTaskId > need_level)
            { 
                return true;
            }
            else
            {
                if (log)
                {
                    UILogicUtils.ShowNotice("完成主线任务" + need_level + "解锁");
                }
                return false;
            }
        }
        
    }

    public int GetUnlockLevel(SysId sysId)
    {
        if (gameSystemUnlock.ContainsKey((int)sysId))
        {
            return gameSystemUnlock[(int)sysId].Level;
        }
        return -1;
    }

    /// <summary>
    /// 获取一个跳转配置
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Ft_jumpConfig GetFt_jumpConfig(int id)
    {
        return ConfigManager.Instance.GetConfig<Ft_jumpConfigData>("ft_jumpsConfig").Get(id);
    }
}

public class ModuleProfileConfigVo
{
    //public List<int> FuliFlowerLevel { get; set; }//福利鲜花的触发等级集合
    //public List<int> FuliFlowerTime { get; set; }//福利鲜花要求的观看广告次数集合
    /**用于配置第x天的奖励*/
    public Dictionary<string, int> newFlowerReward_Day1 { get; set; }
    public Dictionary<string, int> newFlowerReward_Day2 { get; set; }
    public Dictionary<string, int> newFlowerReward_Day3 { get; set; }
    /**鲜花升级开启等级 */
    public List<int> flowerStarPremise { get; set; }


    public uint waterInit;//初始化水
    public uint waterLimit;//水最大上限
    public uint waterChargeAmount;//水每间隔补充数量
    public uint waterChargeInterval;//水间隔时间(s)
    public uint waterLimitVip;//开启vip后最大水上线

    public uint friendCountMax;//好友最多上限
    public string friendFlushTime;//好友推荐刷新时间

    public uint npcLimit;//npc限制
    public uint npcFrequency;//npc出现频率(s)
    public uint npcRefreshTime;//订单npc刷新时间
    public uint mostTasksExist;//NPC订单可以同时接取的最大上限

    public uint flowerShelfCount;//出售花最大数量

    public List<Dictionary<string, int>> costItem;

    public float npcGoldAddition;//顾客订单奖励金币加成百分比
    public float npcExpAddition;//顾客订单奖励经验加成百分比

    public uint monsterFrequency;//地鼠生成间隔
    public uint monsterLimit;//出现地鼠数量限制
    public uint monsterReward;//打地鼠次数限制

    public List<int> passwordCost;//交易密码花费钻石

    //public Dictionary<string, int> guildCreatecost;//社团创建花费
    //public Dictionary<string, int> guildChangeNameCost;//社团改名花费
    //public Dictionary<string, int> guildFlowerpotConsumables;//公会种植 开花盆格子所需的消耗品
    //public uint guildDonateMax;//社区每日捐献次数
    public int persekutuanCharacter;//公会聊天字符
    public int persekutuanSay;//公会最高聊天保存

    public Dictionary<string, int> dailyTaskBoxReward;//日常任务全部完成奖励
    public int itemIncreaseRate;//商品上架后可生产的份数。eg:上架1个物品，则花架上有1*itemIncreaseRate个物品
    public int sellTime;//商品每个单份出售所需时间，单位秒s
    public int flowerMarketRefresh;//大订单刷新
    public int umberOfMutualaid;//最大偷花交互上限

    public int flowerMarketexperience;//花市订单经验加成
    public int flowerMarketgold;//花市订单金币加成
    public List<int> flowerMarkettime;//大订单刷新

    public List<int> firstRechargeValue;//首冲

    public Dictionary<string, int> everyVipReward; //vip每日奖励道具

    public List<int> flowerStarGetPrice;//激活星级锁消耗的玉石

    public List<string> percentColor;//数值颜色

    public List<string> numberColor;//数值颜色

    public int universalShardId;//通用碎片Id

    public int breakItemId;//突破消耗道具

    public List<int> petExpItem;//宠物升级用的三个道具id

    public List<int> petExpItemNum;//宠物升级用的三个道具对应增加的经验值

    public int fairySummonItem;//召唤花仙消耗的道具id

    public List<int> fairySumCost1;//1,2,3倍率下第一轮召唤花仙消耗道具的数量

    public List<int> fairySumCost2;//1,2,3倍率下第二轮召唤花仙消耗钻石的数量

    public List<int> fairySumCost3;//1,2,3倍率下第三轮召唤花仙消耗钻石的数量

    public List<int> fairySumQualityProb;//召唤花仙四种品质出现的概率

    public int giftLimitCost;//每日默认可赠送的礼物的次数上限

    public int ikebanaLimitCost;//每日默认可赠送花艺品的次数上限

    public int buyLimitCost;//购买好感送礼次数消耗钻石

    public Dictionary<string, int> arenaVictoryReward;//竞技场挑战成功奖励

    public int arenaTicketId;//竞技场挑战券道具id
    public List<int> arenaFreshCost;//竞技场每日刷新消耗钻石数，到达最后一个后都是该数值

    public Dictionary<string, int> FirstRechargeReward_Day1;//配置首充第1天可领取奖励
    public Dictionary<string, int> FirstRechargeReward_Day2;//配置首充第2天可领取奖励
    public Dictionary<string, int> FirstRechargeReward_Day3;//配置首充第3天可领取奖励

    public int poltItemId;//剧情贝壳道具id
    public int poltItemGet;//每播种1次获得的剧情贝壳数量
    public int poltItemLimit;//每日获得剧情贝壳的上限数量

    public int chouItemId;//绸缎道具id
    public int chouOrderNum;//订单绸缎数量
    public List<int> signDayCost;//每日签到补签消耗砖石数量
    public int contractLevelup;//合约每级经验

    public List<int> dianWaterTime1;//定点领水时间段1
    public List<int> dianWaterTime2;//定点领水时间段2
    public List<int> dianWaterTime3;//定点领水时间段3
    public int dianWaterReward;//每个时间段奖励水滴
    public int bucketRecoverCD;//每30秒集满一个水桶
    public int bucketMax;//最多集满8个就不继续集
    public int bucketMaxDay;//水桶每日最多领取60个
    public int bucketVideoProb;//水桶触发广告概率
    public List<int> bucketRewardWater;//每次领取水桶获得3-7滴
    public List<int> bucketVideoReward;//每次领取水桶获得30-70滴

    public int keHuifuCd;//贝壳恢复时间
    public int keMaxNum;//贝壳拥有最大上限
}


