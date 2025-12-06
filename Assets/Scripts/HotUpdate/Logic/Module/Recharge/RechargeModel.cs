using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using protobuf.recharge;
using UnityEngine;
using static protobuf.login.S_MSG_GAMEINIT;
using static protobuf.recharge.S_MSG_RECHARGE_INFO;

public class RechargeModel : Singleton<RechargeModel>
{
    private Dictionary<string, Ft_game_payConfig> _gamePayHome;
    public Dictionary<string, Ft_game_payConfig> gamePayHome { get
        {
            if(_gamePayHome == null)
            {
                Ft_game_payConfigData payData = ConfigManager.Instance.GetConfig<Ft_game_payConfigData>("ft_game_paysConfig");
                _gamePayHome = payData.DataMap;
            }
            return _gamePayHome;
        } }

    private Dictionary<int, Ft_diamond_valueConfig> _diamondValueHome;
    public Dictionary<int, Ft_diamond_valueConfig> diamondValueHome { get
        {
            if(_diamondValueHome == null)
            {
                Ft_diamond_valueConfigData diamondData = ConfigManager.Instance.GetConfig<Ft_diamond_valueConfigData>("ft_diamond_valuesConfig");
                _diamondValueHome = diamondData.DataMap;
            }
            return _diamondValueHome;
        } }
    private List<Ft_recharge_giftConfig> _rechargeGiftList;
    public List<Ft_recharge_giftConfig> rechargeGiftList { get
        {
            if(_rechargeGiftList == null)
            {
                var rechargeGiftData = ConfigManager.Instance.GetConfig<Ft_recharge_giftConfigData>("ft_recharge_giftsConfig");
                _rechargeGiftList = rechargeGiftData.DataList;
            }
            return _rechargeGiftList;
        } }


    private List<Ft_game_payConfig> _gamePayList;
    public List<Ft_game_payConfig> gamePayList { get
        {
            if(_gamePayList == null)
            {
                _gamePayList = new List<Ft_game_payConfig>();
                foreach(var value in gamePayHome)
                {
                    if(value.Value.Type == 1)
                    {
                        _gamePayList.Add(value.Value);
                    }
                }
            }
            return _gamePayList;
        } }

    private List<Ft_game_payConfig> _firstPayList;
    public List<Ft_game_payConfig> firstPayList { get
        {
            if(_firstPayList == null)
            {
                _firstPayList = new List<Ft_game_payConfig>();
                foreach (var value in gamePayHome)
                {
                    if (value.Value.Type == 1 && value.Value.IsThree > 0)
                    {
                        _firstPayList.Add(value.Value);
                    }
                }
            }
            return _firstPayList;
        } }

    private List<Ft_tour_giftConfig> _tourGiftList;
    public List<Ft_tour_giftConfig> tourGiftList { get
        {
            if(_tourGiftList == null)
            {
                var tourGiftData = ConfigManager.Instance.GetConfig<Ft_tour_giftConfigData>("ft_tour_giftsConfig");
                _tourGiftList = tourGiftData.DataList;
            }
            return _tourGiftList;
        } }

    public List<Ft_diamond_valueConfig> goldValueList;

    public List<Ft_diamond_valueConfig> vipValueList;
    public List<Ft_diamond_valueConfig> giftValueList;

    public List<I_GIFTPACK_VO> giftPackList;//正在生效的礼包
    public List<uint> giftHaveBuy;//已购买的礼包

    public Dictionary<uint,uint> haveDiamondValue; //配置中已购买的特惠礼包

    public Dictionary<int, Dictionary<string, int>> firstRechargeReward = new Dictionary<int, Dictionary<string, int>>();

    public uint[] rechargeRewards;//已领取的累充奖励配置id

    public uint[] firstRechargeRewards;//已领取的首充奖励配置id

    public uint rechargeAmount;//已充值金额

    public GAME_PAY_VO gamePay;//game_pay 配置中已购买的项目

    public uint[] haveGiftPack;//ft_gift_pack已购买的礼包id

    public Dictionary<uint, uint> haveMall;//ft_mall已购买的商品id 配置中已购买的项目 下标是配置id 值是周期内已购买次数

    public uint firstRechargeTime;//首次充值时间

    public void UpdateRechargeInfo(S_MSG_RECHARGE_INFO data)
    {
        rechargeAmount = data.rechargeAmount;
        Instance.firstRechargeRewards = data.firstRechargeRewards;
        rechargeRewards = data.rechargeRwards;
        firstRechargeTime = data.firstRechargeTime;
        gamePay = data.gamePay;
        haveDiamondValue = data.haveDiamondValue;
        haveGiftPack = data.haveGiftPack;
        haveMall = data.haveMall;
    }

    public Ft_diamond_valueConfig GetDiamondVo(int type)
    {
       foreach(var value in diamondValueHome)
        {
            if(value.Value.Type == type)
            {
                return value.Value;
            }
        }
        return null;
    }
    public Ft_diamond_valueConfig GetDiamondVo1(int id)
    {
        if (diamondValueHome.ContainsKey(id))
        {
            return diamondValueHome[id];
        }
        return null;
    }
    public List<Ft_diamond_valueConfig> GetGiftList()
    {
        var dataList = new List<Ft_diamond_valueConfig>();
        foreach (var value in diamondValueHome)
        {
            if (value.Value.Type == (int)E_DIAMOND_VALUE_TYPE.DAILY)
            {
                dataList.Insert(0, value.Value);
            }else if(value.Value.Type == (int)E_DIAMOND_VALUE_TYPE.NORMAL)
            {
                dataList.Add(value.Value);
            }
        }
        return dataList;
    }

    public List<Ft_tour_giftConfig> GetTourList()
    {
        var listData = new List<Ft_tour_giftConfig>();
        foreach (var value in tourGiftList)
        {
            //if(TimeUtil.GetNumericTime(value.WeixinStartTime) > ServerTime.Time)
            //{
            //    continue;
            //}
            listData.Add(value);
        }
        return listData;
    }
    public bool IsFirstRecharge()
    {
        return firstRechargeTime != 0 && ServerTime.Time >= firstRechargeTime;
    }

    public bool IsFirstRechargeEnd()
    {
        for(int i = 0;i < 3; i++)
        {
            if (firstRechargeRewards == null || Array.IndexOf(firstRechargeRewards, (uint)(i + 1)) == -1)
            {
                return false;
            }
        }
        return true;
    }
}

public enum E_DIAMOND_VALUE_TYPE
{
    NONE,//不显示
    DAILY,//每日免费礼包
    NORMAL,//常规礼包
    VIP,//vip礼包
    VIDEO_PRIVILEGE,//视频特权
    CASH = 51,//钻石基金
    INTROD = 52,//入门培育
    STEP = 53,//进阶培育
    CONTRACT = 61,//高级合约
    CONTRACT_SUPER = 62,//至尊合约
    BUY_CONTRACT_LEVEL = 63,//购买合约等级
}

