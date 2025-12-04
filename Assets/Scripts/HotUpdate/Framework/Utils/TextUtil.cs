using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public static class TextUtil
{
    private static readonly string[] ChineseNumbers = {
            "零", "一", "二", "三", "四", "五", "六", "七", "八", "九"
        };

    private static readonly string[] ChineseUnits = {
            "", "十", "百", "千", "万"
        };
    public static string ChangeCoinShow(float value)
    {
        string[] numberUnit = { "", "K", "M", "B", "T" };
        int len = 0;

        while (value > 99999)
        {
            value /= 1000;
            len++;
        }

        value = Mathf.Floor(value);
        return NumberFormat(value) + numberUnit[len];
    }

    public static string ChangeCoinShow1(float value)
    {
        // 处理负数和零值
        if (value == 0) return "0";
        if (value < 0) return "-" + ChangeCoinShow1(-value);

        string[] numberUnit = { "", "K", "M", "B", "T", "Q" };
        int len = 0;
        float originalValue = value;

        // 正确计算单位层级
        while (value >= 1000f && len < numberUnit.Length - 1)
        {
            value /= 1000f;
            len++;
        }

        // 处理单位转换后的值
        if (len > 0)
        {
            // 根据值大小选择格式化方式
            if (value >= 100f)
            {
                // 整数显示（无小数）
                return Mathf.RoundToInt(value).ToString() + numberUnit[len];
            }
            else if (value >= 10f)
            {
                // 一位小数（必要时显示）
                return FormatWithOptionalDecimal(value, 1) + numberUnit[len];
            }
            else
            {
                // 两位小数（必要时显示）
                return FormatWithOptionalDecimal(value, 2) + numberUnit[len];
            }
        }
        else
        {
            // 无单位转换时的格式化
            if (value >= 100f)
            {
                // 大数值整数显示
                return Mathf.RoundToInt(value).ToString();
            }
            else if (value >= 1f)
            {
                // 中值带可选小数
                return FormatWithOptionalDecimal(value, 2);
            }
            else
            {
                // 小数值带小数
                return value.ToString("0.##");
            }
        }
    }

    public static string ChangeCoinShow2(float value)
    {
        if(value < 1000000)
        {
            return value.ToString();
        }
        else
        {
            return ChangeCoinShow1(value);
        }
    }

    // 辅助方法：按需显示小数位
    private static string FormatWithOptionalDecimal(float value, int maxDecimals)
    {
        // 四舍五入到指定小数位
        float roundedValue = Mathf.Round(value * Mathf.Pow(10, maxDecimals)) / Mathf.Pow(10, maxDecimals);

        // 检查是否为整数
        if (Mathf.Approximately(roundedValue, Mathf.Round(roundedValue)))
        {
            return Mathf.RoundToInt(roundedValue).ToString();
        }

        // 格式化为字符串并移除末尾的零
        string format = "F" + maxDecimals;
        string formatted = roundedValue.ToString(format);

        // 移除不必要的零和小数点
        if (formatted.Contains("."))
        {
            formatted = formatted.TrimEnd('0').TrimEnd('.');
        }

        return formatted;
    }

    public static string NumberFormat(float value)
    {
        int remainder = (int)(value % 1);
        string num = Mathf.Floor(value).ToString();
        int len = num.Length;

        if (len > 3)
        {
            int totalDelim = len / 3;
            int totalRemain = len % 3;
            char[] numArray = num.ToCharArray();
            List<char> numList = new List<char>(numArray);

            for (int i = 0; i < totalDelim; i++)
            {
                numList.Insert(totalRemain + (4 * i), ',');
            }

            if (totalRemain == 0)
            {
                numList.RemoveAt(0);
            }

            num = new string(numList.ToArray());
        }

        if (remainder != 0)
        {
            num += (value % 1).ToString().Substring(1);
        }

        return num;
    }

    public static string ChangeNumberShow(int count)
    {
        if (count > 999)
        {
            if (Mathf.Floor(count / 1000f) >= 1)
            {
                return Mathf.Floor(count / 1000f) + "K";
            }
        }
        return count.ToString();
    }

    public static string ChangeTimeShow(int count)
    {
        if(count < 60)
        {
            return count + "秒";
        }
        else
        {
            var sed = count % 60;
            if (sed == 0)
            {
                return (count / 60).ToString() + "分";
            }
            else
            {
                var min = Mathf.Floor((float)count / 60);
                return min + "分" + sed + "秒";
            }
        }
        
    }
    public static string ToChineseNumber(int number)
    {
        if (number < 0) return "负" + ToChineseNumber(-number);
        if (number < 10) return ChineseNumbers[number];

        if (number < 20)
            return number == 10 ? "十" : "十" + ChineseNumbers[number % 10];

        StringBuilder result = new StringBuilder();
        int temp = number;
        int unitIndex = 0;

        while (temp > 0)
        {
            int digit = temp % 10;
            if (digit != 0)
            {
                string unit = unitIndex < ChineseUnits.Length ? ChineseUnits[unitIndex] : "";
                result.Insert(0, ChineseNumbers[digit] + unit);
            }
            temp /= 10;
            unitIndex++;
        }

        return result.ToString();
    }
    public static List<int> ToStringList(string str)
    {
        List<int> list = str.Select(c =>
        {
            if (char.IsDigit(c))
                return int.Parse(c.ToString());
            else
                throw new ArgumentException($"字符 '{c}' 不是数字。");
        }).ToList();
        return list;
    }
    public static string GetServerName(uint serverId,string name)
    {
        return "s" + serverId + "." + name;
    }
}
