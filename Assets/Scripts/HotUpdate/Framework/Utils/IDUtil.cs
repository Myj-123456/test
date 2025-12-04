using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ADK
{
    /// <summary>
    ///  author 
    /// </summary>
    public class IDUtil
    {
        public static EntityID GetEntityId(string id)
        {
            long _id = long.Parse(id);
            double action = Math.Floor((double)(_id / 10000000000));
            _id -= (long)action * 10000000000;
            double module = Math.Floor((double)(_id / 100000000));
            long value = _id - (long)(module * 100000000);
            return new EntityID((long)action, (long)module, value);
        }

        public static EntityID GetEntityId(long _id)
        {
            //long _id = long.Parse(id);
            double action = Math.Floor((double)(_id / 10000000000));
            _id -= (long)action * 10000000000;
            double module = Math.Floor((double)(_id / 100000000));
            long value = _id - (long)(module * 100000000);
            return new EntityID((long)action, (long)module, value);
        }

        public static int GetEntityValue(string id)
        {
            long _id = long.Parse(id);
            long reslut = (long)(Math.Floor((double)(_id / 100000000)) * 100000000);
            return (int)(_id - reslut);

        }

        /// <summary>
        ///为了兼容旧的物品格式(12位)，保留后8位为道具id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetEntityValue(long id)
        {
            long reslut = (long)(Math.Floor((double)(id / 100000000)) * 100000000);
            return (int)(id - reslut);
        }

        /// <summary>
        ///为了兼容旧的物品格式(12位)，保留后8位为道具id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int GetEntityValue(ulong id)
        {
            ulong reslut = (ulong)(Math.Floor((double)(id / 100000000)) * 100000000);
            return (int)(id - reslut);
        }


        public static bool IsCommonItem(int id)
        {
            switch ((BaseType)id)
            {
                case BaseType.GOLD:
                    return true;
                case BaseType.EXP:
                    return true;
                case BaseType.CASH:
                    return true;
                case BaseType.FST_WATER:
                    return true;
                default:
                    return false;
            }
        }
    }
    public class EntityID
    {
        public long action;
        public long module;
        public long value;

        public EntityID(long act, long mod, long val)
        {
            action = act;
            module = mod;
            value = val;
        }

        public string MyToString()
        {
            return action.ToString() + "," + module.ToString() + "," + value.ToString();
        }

    }

    public enum BaseType
    {
        /**玉石*/
        CASH = 10000001,
        /**元宝*/
        GOLD = 11000001,
        GUILD = 18000001,
        GUILD_EXP = 16000001,
        COLLECTION = 18000002,
        EXP = 14000001,
        TICKET = 13000001,
        FSS_MONEY = 18000003,
        FSS_ID = 23030003,
        FST_WATER = 19000001,
        SPD_DRUG = 19000002,    //加速符
        IKE = 28910001,
        TURNTABLE_COIN = 19000003,//转盘币
        GRANDMA_TICKET = 19000004,//好评券
        GUILD_MEDAL = 19000005,//社团勋章
        PETAL = 19000008,//花瓣
        ROB_TOKEN = 19000006,//抢夺令
        ColorPower = 41013001,//颜色之力
        GUILDGOLD = 19000012//社团资金
    }

    public class BaseTypeEntity
    {
        public static string gold = "721111000001";
        public static string diamond = "721010000001";
        public static string exp = "721414000001";
        public static string WATER = "725119000001";
    }


    public enum PlayerAttr
    {

        Attack = 1,//攻击固定值
        Defense = 2,//防御固定值
        Hp = 3,//生命固定值
        Speed = 4,//速度固定值
        AttackRate = 5,//攻击百分比
        DefenseRate = 6,//防御百分比
        HpRate = 7,//生命百分比
        SpeedRate = 8,//速度百分比
        Crit = 9,//暴击百分比
        Dodge = 10,//闪避百分比
        Stun = 11,//击晕百分比
        LifeSteal = 12,//吸血百分比
        Counter = 13,//反弹百分比
        Combo = 14,//追击百分比
        AntiCrit = 15,//抗暴击百分比
        AntiStun = 16,//抗击晕百分比
        AntiLifeSteal = 17,//抗吸血百分比
        AntiCounter = 18,//抗反弹百分比
        AntiDodge = 19,//命中固百分比
        PetUp = 20,//强化宠物百分比
        PetDown = 21,//弱化宠物百分比
        CureUp = 22,//强化治疗百分比
        CureDown = 23,//弱化治疗百分比
        FinalUp = 24,//最终增伤百分比
        FinalDown = 25,//最终减伤百分比
        IgnoreAttributes = 26,//最终减伤百分比
        IgnoreResistance = 27,//最终减伤百分比
        
    }
}
