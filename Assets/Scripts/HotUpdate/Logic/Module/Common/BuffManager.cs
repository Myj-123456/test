using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : Singleton<BuffManager>
{
   public int GetAddCount(BuffType type,System.Object param = null)
    {
        var count = 0;
        if(type == BuffType.Order_Glod_Type || type == BuffType.Order_Exp_Type)
        {
            
            if (param is Dictionary<ulong, ulong> needItem)
            {
                foreach(var item in needItem)
                {
                    var flowerId = item.Key;
                    var flowerNum = item.Value;
                    var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)flowerId);
                    SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook((int)flowerId);
                    var plantVo = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null ? 1 : exp.level));
                    var orderVo = OrderModel.Instance.GetOrderInfo((int)flowerId);
                    var rate = 1f + (type == BuffType.Order_Glod_Type ? DressModel.Instance.GetGoldRate(): DressModel.Instance.GetExpRate());
                    var num = (type == BuffType.Order_Glod_Type ? orderVo.Gold : orderVo.Experience) * (int)flowerNum;
                    count += (int)MathF.Ceiling(num * rate);
                } 
            }
        }else if(type == BuffType.Flower_Glod_Type || type == BuffType.Flower_Exp_Type)
        {
            var flowerId = (int)param;
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)flowerId);
            SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook((int)flowerId);
            var plantVo = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null ? 1 : exp.level));
            var buffType = type == BuffType.Flower_Glod_Type ? 1 : 2;
            var orderVo = OrderModel.Instance.GetOrderInfo((int)flowerId);

            var num = (type == BuffType.Flower_Glod_Type ? orderVo.Gold : orderVo.Experience);
            var rate = 1f+ (buffType == 1 ? DressModel.Instance.GetGoldRate() : DressModel.Instance.GetExpRate());
            var rate1 = buffType == 1 ? (GlobalModel.Instance.module_profileConfig.flowerMarketgold / 100f) : (GlobalModel.Instance.module_profileConfig.flowerMarketexperience / 100f);
            count += (int)MathF.Ceiling(num * rate * rate1);
        }else if(type == BuffType.Npc_Glod_Type || type == BuffType.Npc_Exp_Type)
        {
            var flowerId = (int)param;
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)flowerId);
            SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook((int)flowerId);
            var plantVo = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null?1:exp.level));
            var orderVo = OrderModel.Instance.GetOrderInfo((int)flowerId);

            var buffType = type == BuffType.Npc_Glod_Type ? 1 : 2;
            var rate = 1f + (buffType == 1 ? DressModel.Instance.GetGoldRate() : DressModel.Instance.GetExpRate());
            var rate1 = buffType == 1 ? (GlobalModel.Instance.module_profileConfig.npcGoldAddition / 100f) : (GlobalModel.Instance.module_profileConfig.npcExpAddition / 100f);
            var num = (buffType == 1 ? orderVo.Gold : orderVo.Experience);
            
            count += (int)MathF.Ceiling(num * rate * rate1);
        }
        else if (type == BuffType.Desk_Gold_Type)
        {
            var flowerId = (int)param;
            var condition = FlowerHandbookModel.Instance.GetStaticSeedCondition((int)flowerId);
            SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook((int)flowerId);
            var plantVo = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null ? 1 : exp.level));
            var orderVo = OrderModel.Instance.GetOrderInfo((int)flowerId);

            var rate = 1f + DressModel.Instance.GetGoldRate();
            var num = orderVo.Gold;

            count += (int)MathF.Ceiling(num * rate);
        }
        return count;
    }

    public float GetAddRate(BuffType type, System.Object param = null)
    {
        var rate = 1f;

        if (type == BuffType.Order_Glod_Type || type == BuffType.Flower_Glod_Type || type == BuffType.Npc_Glod_Type)
        {
            if (param != null)
            {
                rate += (float)param;
            }
            rate += (MyselfModel.Instance.IsVideoDouble() ? 1 : 0);
        }
        if(type == BuffType.Order_Exp_Type || type == BuffType.Flower_Exp_Type || type == BuffType.Npc_Exp_Type)
        {
            if(param != null)
            {
                rate += (float)param;
            }
            rate = rate * ((MyselfModel.Instance.CurrVipExp() / 100f) + 1);
        }
        return rate;
    }
}

public enum BuffType
{
    Order_Glod_Type = 1,//订单金币概率
    Order_Exp_Type = 2,//订单经验概率
    Flower_Glod_Type = 3,//花市订单金币
    Flower_Exp_Type = 4,//花市订单经验
    Npc_Glod_Type = 5,//顾客订单金币
    Npc_Exp_Type = 6,//顾客订单经验
    Desk_Gold_Type = 7,//摆台经验
}

