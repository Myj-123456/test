using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using UnityEngine;

public class CultivationModel : Singleton<CultivationModel>
{
    public int landId = 0;
    /**xx秒时可收获 */
    public int harvestTime = 0;
    public int flowerId = 0;
    public bool result = false;
    public int videoTime = 0;
    public int gapTime = 0;
    public int helpMaxCount = 0;
    public float costMinTime = 0;
    public float costMinRate = 0;
    public int frushTime = 30;
    public int helpCnt;

    public Module_fertilizerConfigData fertilizerConfigData = ConfigManager.Instance.GetConfig<Module_fertilizerConfigData>("module_fertilizersConfig");

    public void ParesCostInfo(string str)
    {
        string[] arr = str.Split(",");
        costMinTime = float.Parse(arr[0]);
        costMinRate = float.Parse(arr[1]);
    }

    public void ParseLandInfo(protobuf.plant.I_CULTIVATE_VO data)
    {
        harvestTime = (int)data.harvestTime;
        flowerId = (int)data.flowerId;
    }

    public Module_fertilizerConfig GetFertilizerConfigById(string id)
    {
        int _id = IDUtil.GetEntityValue(id);
        return fertilizerConfigData.Get(_id);
    }

    public Module_fertilizerConfig GetFertilizerConfigById(int id)
    {
        return fertilizerConfigData.Get(id);
    }

    public List<StaticSeedCondition> GetNoCultivationList()
    {
        return FlowerHandbookModel.Instance.GetNoCultivationList();

    }

    public bool CheckAllConditionItem()
    {
        bool bol = false;
        var list = GetNoCultivationList();
        foreach(var cell in list)
        {
            if (CheckConditionItem(cell))
            {
                bol = true;
                break;
            }
        }
        return bol;
    }

    public bool CheckConditionItem(StaticSeedCondition staticSeedCondition)
    {
        var bol = true;
        foreach (var item in staticSeedCondition.ItemIds)
        {
            var itemData = ItemModel.Instance.GetItemByEntityID(item.EntityID);
            if (itemData != null)
            {
                var num = StorageModel.Instance.GetItemCount(itemData.ItemDefId);
                if (num < item.Value)
                {
                    bol = false;
                    break;
                }
            }
        }
        return bol;
    }

}

