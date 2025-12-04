using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Elida.Config;
using UnityEngine;

public class FLowerModel : Singleton<FLowerModel>
{
    //鲜花突破表
    private Dictionary<string, Ft_hua_breakConfig> _flowerBreakMap;
    public Dictionary<string, Ft_hua_breakConfig> flowerBreakMap { get
        {
            if(_flowerBreakMap == null)
            {
                var breakData = ConfigManager.Instance.GetConfig<Ft_hua_breakConfigData>("ft_hua_breaksConfig");
                _flowerBreakMap = breakData.DataMap;
            }
            return _flowerBreakMap;
        } }
    //鲜花品阶表
    private Dictionary<string, Ft_hua_gradeConfig> _flowerGradeMap;
    public Dictionary<string, Ft_hua_gradeConfig> flowerGradeMap { get {
            if (_flowerGradeMap == null)
            {
                Ft_hua_gradeConfigData gradeData = ConfigManager.Instance.GetConfig<Ft_hua_gradeConfigData>("ft_hua_gradesConfig");
                _flowerGradeMap = gradeData.DataMap;
            }
            return _flowerGradeMap;
        } }

    //鲜花品阶属性
    private Dictionary<int, Ft_hua_attributeConfig> _attrMap;
    public Dictionary<int, Ft_hua_attributeConfig> attrMap { get
        {
            if(_attrMap == null)
            {
                Ft_hua_attributeConfigData attrData = ConfigManager.Instance.GetConfig<Ft_hua_attributeConfigData>("ft_hua_attributesConfig");
                _attrMap = attrData.DataMap;
            }
            return _attrMap;
        } }
    //鲜花花事表
    private Dictionary<int, Ft_booklist_txtConfig> _bookTxtMap;
    public Dictionary<int, Ft_booklist_txtConfig> bookTxtMap { get
        {
            if(_bookTxtMap == null)
            {
                var bookTxtData = ConfigManager.Instance.GetConfig<Ft_booklist_txtConfigData>("ft_booklist_txtsConfig");
                _bookTxtMap = bookTxtData.DataMap;
            }
            return _bookTxtMap;
        } }

    //鲜花花事信息
    public Ft_booklist_txtConfig GetBookTxtInfo(int id)
    {
        foreach(var value in bookTxtMap)
        {
            if(value.Value.FlowerId == id)
            {
                return value.Value;
            }
        }
        return null;
    }
    //获取鲜花品阶属性信息

    public Ft_hua_attributeConfig GetAttribiteConfig(int id)
    {
        if (attrMap.ContainsKey(id))
        {
            return attrMap[id];
        }
        return null;
    }

    //获取鲜花突破信息
    public Ft_hua_breakConfig GetFlowerBreakConfig(int quality,int breakLv)
    {
        var str = quality + "#" + breakLv;
        if (flowerBreakMap.ContainsKey(str))
        {
            return flowerBreakMap[str];
        }
        return null;
    }
    //获取鲜花升阶表信息
    public Ft_hua_gradeConfig GetFlowerGradeConfig(int quality, int gradeLv)
    {
        var str = quality + "#" + gradeLv;
        if (flowerGradeMap.ContainsKey(str))
        {
            return flowerGradeMap[str];
        }
        return null;
    }

    public int GetGradeMaxNumber(int quality)
    {
        var gradeList = flowerGradeMap.Where(kv => kv.Value.QualityId == quality);
        return gradeList.Count();
    }

    public bool GetIsGradeMax(int quality, int gradeLv)
    {
        var str = quality + "#" + (gradeLv + 1);
        if (flowerGradeMap.ContainsKey(str))
        {
            return false;
        }
        return true;
    }
}

