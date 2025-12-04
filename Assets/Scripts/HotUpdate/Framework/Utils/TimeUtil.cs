using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Text.RegularExpressions;

namespace ADK
{
    /// <summary>
    ///  author 
    /// </summary>
    public class TimeUtil
    {
        /// <summary>
        /// 获取当前时间戳(单位秒)
        /// </summary>
        public static uint GetTimestamp()
        {
            return GetTimestamp(DateTime.Now);
        }
        /// <summary>
        /// 单位秒
        /// </summary>
        public static uint GetTimestamp(DateTime dateTime)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 8, 0, 0, 0);//默认为北京时间
            return (uint)((dateTime.Ticks - dt1970.Ticks) / 10000 / 1000);
        }

        /// <summary>
        /// 秒时间戳转DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(long timestamp)
        {
            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToLocalTime().DateTime;
            return dateTime;
        }

        /// <summary>
        /// 是否跨天了
        /// </summary>
        /// <param name="timestamp1"></param>
        /// <param name="timestamp2"></param>
        /// <returns></returns>
        public static bool IsCrossDay(long timestamp1, long timestamp2)
        {
            // 将时间戳转换为本地时间的 DateTime，并提取日期
            DateTime date1 = DateTimeOffset.FromUnixTimeSeconds(timestamp1).ToLocalTime().Date;
            DateTime date2 = DateTimeOffset.FromUnixTimeSeconds(timestamp2).ToLocalTime().Date;
            // 比较日期是否相同
            return date1 != date2;
        }

        public static uint ParseFullTimeStr(string str, bool log = false)
        {
            if (StringUtil.FullTimeStrReg.IsMatch(str))
            {
                string[] ary = Regex.Split(str, @"\s+");
                string left = ary[0];
                string right = ary[1];
                string[] leftArr = left.Split("-");

                int year = int.Parse(leftArr[0]);
                int month = int.Parse(leftArr[1]);
                int dat = int.Parse(leftArr[2]);
                if (log)
                {
                    Debug.Log("left：" + left + "解析后 年:" + year + " 月:" + (month + 1) + " 日:" + dat);
                }

                string[] rightArr = right.Split(":");
                int hour = int.Parse(rightArr[0]);
                int min = int.Parse(rightArr[1]);
                int sec = int.Parse(rightArr[2]);
                if (log)
                {
                    Debug.Log("right：" + right + "解析后 时:" + hour + " 分:" + min + " 秒:" + sec);
                }
                DateTime date = new DateTime(year, month, dat, hour, min, sec);
                uint timeTamp = GetTimestamp(date);
                if (log)
                {
                    Debug.Log("要解析的字符串:" + str);
                    Debug.Log("date[校对时区前]:" + date);
                    Debug.Log("解析得的时间戳[校对时区后]：" + timeTamp);
                }
                return timeTamp;
            }
            return 0;
        }
        /**比较两天是否是同一天*/
        public static bool IsSameDayInt(int timeSec, int compareTime = -1)
        {
            compareTime = compareTime == -1 ? (int)ServerTime.Time : compareTime;

            var cacheDat = GetDateTime((long)timeSec);
            var curDat = GetDateTime((long)compareTime);
            return cacheDat.Date == curDat.Date;
        }

        public static string GenerateTimeDesc(int occurTime)
        {
            int deltaTime = (int)GetTimestamp() - occurTime;
            double ONE_DAY_TIME = 24 * 60 * 60;
            double ONE_HOUR_TIME = 60 * 60;
            double ONE_MINUTE_TIME = 60;
            if (deltaTime >= ONE_DAY_TIME)
            {
                deltaTime = (int)Math.Floor((double)deltaTime / ONE_DAY_TIME);
                return Lang.GetValue("slang_120", deltaTime.ToString());//{0}天前
            }
            if (deltaTime >= ONE_HOUR_TIME)
            {
                deltaTime = (int)Math.Floor((double)deltaTime / ONE_HOUR_TIME);
                return Lang.GetValue("slang_121", deltaTime.ToString());//{0}小时前
            }
            if (deltaTime >= ONE_MINUTE_TIME)
            {
                deltaTime = (int)Math.Floor((double)deltaTime / ONE_MINUTE_TIME);
                return Lang.GetValue("slang_122", deltaTime.ToString());//{0}分钟前
            }
            return Lang.GetValue("slang_123", deltaTime.ToString());//{0}秒前
        }

        public static string GetTimeInDateHourMinuteSecond(int timeInSecond, TimeFormat format = TimeFormat.DateWithTwoDigit, bool showHours = false)
        {
            string str = "";
            Dictionary<string, double> date = GetTimeData(timeInSecond);

            double day = date["day"];
            double hour = date["hour"];
            double min = date["min"];
            double second = date["sec"];

            switch (format)
            {
                case TimeFormat.DateWidthSecondOnly:
                    str = timeInSecond.ToString() + "秒";
                    break;
                case TimeFormat.DateWithMinAndSecond:
                    if (hour > 0)
                    {
                        str = GetFixedStr((int)hour) + ":" + GetFixedStr((int)min);
                    }
                    else
                    {
                        str = GetFixedStr((int)min) + ":" + GetFixedStr((int)second);
                    }
                    break;
                case TimeFormat.DateWithTwoDigit:
                    if (day > 0)
                    {
                        str = day.ToString() + "天" + GetFixedStr((int)hour) + "时";
                    }
                    else
                    {
                        if (showHours)
                        {
                            if (hour > 0)
                            {
                                str += GetFixedStr((int)hour) + "时";
                            }
                            str += GetFixedStr((int)min) + "分";
                            str += GetFixedStr((int)second) + "秒";
                        }
                        else
                        {
                            if (hour > 0)
                            {
                                str = GetFixedStr((int)hour) + "时" + GetFixedStr((int)min) + "分";
                            }
                            else
                            {
                                str = GetFixedStr((int)min) + "分" + GetFixedStr((int)second) + "秒";
                            }
                        }
                    }
                    break;
            }
            return str;
        }

        public static Dictionary<string, double> GetTimeData(int coolDown)
        {
            double day = 0, hour = 0, min = 0, sec = 0;
            Dictionary<string, double> map = new Dictionary<string, double>();
            if (coolDown >= 0)
            {
                day = Math.Floor((double)coolDown / 60 / 60 / 24);
                hour = Math.Floor((double)coolDown / 60 / 60 % 24);
                min = Math.Floor((double)coolDown / 60 % 60);
                sec = Math.Floor((double)coolDown % 60);
            }
            map.Add("day", day);
            map.Add("hour", hour);
            map.Add("min", min);
            map.Add("sec", sec);
            return map;

        }

        public static Dictionary<string, double> GetTimeData1(int coolDown)
        {
            double hour = 0, min = 0, sec = 0;
            Dictionary<string, double> map = new Dictionary<string, double>();
            if (coolDown >= 0)
            {
                hour = Math.Floor((double)coolDown / 60 / 60);
                min = Math.Floor((double)coolDown / 60 % 60);
                sec = Math.Floor((double)coolDown % 60);
            }
            map.Add("hour", hour);
            map.Add("min", min);
            map.Add("sec", sec);
            return map;

        }

        public static string GetFixedStr(int num, double fixedLen = 2)
        {
            int fixNum = (int)Math.Pow(10, fixedLen);
            fixNum = fixNum + num;
            string str = fixNum.ToString();
            str = str.Substring(str.Length - (int)fixedLen);
            return str;
        }

        public static int GetNumericTime(string v)
        {
            if (v != null && v != "")
            {
                var bol = StringUtil.FullTimeStrReg.IsMatch(v);
                return StringUtil.FullTimeStrReg.IsMatch(v) ? (int)ParseFullTimeStr(v) : int.Parse(v);
            }
            return 0;
        }

        public static string FormatNumberToEnglishTxt(int t, bool isNeedSecond = true, bool isNeedMinute = true, string prefix = "")
        {
            Dictionary<string, double> data = GetTimeData(t);
            double d = data["day"];
            double h = data["hour"];
            double m = data["min"];
            double s = data["sec"];
            string txt = "", hs = h.ToString(), ms = m.ToString(), ss = s.ToString();
            if (isNeedSecond)
            {
                if (h < 10)
                {
                    if (h > 0) hs = "0" + h.ToString();
                    else hs = "00";
                }
                if (m < 10)
                {
                    if (m > 0) ms = "0" + m.ToString();
                    else ms = "00";
                }
                if (s < 10)
                {
                    if (s > 0) ss = "0" + s.ToString();
                    else ss = "00";
                }
            }
            if (d > 0)
            {
                if (isNeedMinute)
                {
                    if (!isNeedSecond || s == 0)
                    {
                        txt = d + "'" + hs + "'" + ms + "'";
                    }
                    else
                    {
                        txt = d + "'" + hs + "'" + ms + "'" + ss + "'";
                    }
                }
                else
                {
                    txt = d + "'" + hs + "'";
                }
            }
            else
            {
                if (h > 0)
                {
                    if (isNeedMinute)
                    {
                        if (!isNeedSecond || s == 0)
                        {
                            txt = hs + "'" + ms + "'";
                        }
                        else
                        {
                            txt = hs + "'" + ms + "'" + ss + "'";
                        }
                    }
                    else
                    {
                        txt = hs + "'";
                    }
                }
                else
                {
                    if (m > 0)
                    {
                        if (!isNeedSecond || s == 0)
                        {
                            txt = ms + "'";
                        }
                        else
                        {
                            txt = ms + "'" + ss + "'";
                        }
                    }
                    else
                    {
                        txt = ss + "''";
                    }
                }
            }
            return prefix + txt;
        }

        public static string SecondTimeString(int t, bool isNeedSecond = true, bool isNeedMinute = true)
        {
            Dictionary<string, double> data = GetTimeData1(t);
            double h = data["hour"];
            double m = data["min"];
            double s = data["sec"];
            string txt = "", hs = h.ToString(), ms = m.ToString(), ss = s.ToString();

            if (h < 10)
            {
                if (h > 0) hs = "0" + h.ToString();
                else hs = "00";
            }
            if (m < 10)
            {
                if (m > 0) ms = "0" + m.ToString();
                else ms = "00";
            }
            if (s < 10)
            {
                if (s > 0) ss = "0" + s.ToString();
                else ss = "00";
            }

            txt = hs + ":" + ms + ":" + ss;

            return txt;
        }

        public static string SecondTimeString1(int t, bool isNeedSecond = true, bool isNeedMinute = true)
        {
            Dictionary<string, double> data = GetTimeData1(t);
            double m = data["min"];
            double s = data["sec"];
            string txt = "", ms = m.ToString(), ss = s.ToString();

            if (m < 10)
            {
                if (m > 0) ms = "0" + m.ToString();
                else ms = "00";
            }
            if (s < 10)
            {
                if (s > 0) ss = "0" + s.ToString();
                else ss = "00";
            }

            txt = ms + ":" + ss;

            return txt;
        }

        public static string DateToStr(long t, string fmt = "yyyy-MM-dd hh:mm:ss")
        {
            DateTime date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t); // Convert from Unix timestamp to DateTime

            // Create a dictionary for date part mappings
            var o = new
            {
                M = date.Month,                    // 月份
                d = date.Day,                      // 日
                h = date.Hour,                     // 小时
                m = date.Minute,                   // 分
                s = date.Second,                   // 秒
                q = (date.Month - 1) / 3 + 1,      // 季度
                S = date.Millisecond               // 毫秒
            };

            // Process year format
            if (Regex.IsMatch(fmt, @"(y+)"))
            {
                string yearStr = date.Year.ToString();
                fmt = Regex.Replace(fmt, @"(y+)", match => yearStr.Substring(yearStr.Length - match.Length));
            }

            // Process other formats
            foreach (var prop in new[] { "M", "d", "h", "m", "s", "q", "S" })
            {
                string pattern = $"({prop}+)";
                if (Regex.IsMatch(fmt, pattern))
                {
                    string valueStr = prop switch
                    {
                        "M" => o.M.ToString(),
                        "d" => o.d.ToString(),
                        "h" => o.h.ToString(),
                        "m" => o.m.ToString(),
                        "s" => o.s.ToString(),
                        "q" => o.q.ToString(),
                        "S" => o.S.ToString(),
                        _ => throw new ArgumentException("Invalid property")
                    };

                    fmt = Regex.Replace(fmt, pattern, match =>
                    {
                        int length = match.Length;
                        return length == 1 ? valueStr : valueStr.PadLeft(2, '0').Substring(0, length);
                    });
                }
            }

            // Adjust for 12-hour clock if needed
            if (fmt.Contains("hh") && o.h > 12)
            {
                fmt = fmt.Replace("hh", (o.h - 12).ToString().PadLeft(2, '0'));
            }
            else if (fmt.Contains("hh"))
            {
                fmt = fmt.Replace("hh", o.h.ToString().PadLeft(2, '0'));
            }

            return fmt;
        }
        public static string GetYearMonthDay(int sec)
        {
            var d = GetDateTime((long)sec);
            var year = d.Year;
            var month = d.Month;
            var date = d.Day;
            return year + "/" + month + "/" + date;
        }

        static int dayMilSec = 86400;//一天的秒数

        //判断2个时间是否是同一周
        public static bool InSameWeek(int timeMilSec,int targetMilSec,bool sunFirst = false)
        {
            var time = GetDateTime(timeMilSec);
            var cur = new DateTime(time.Year, time.Month, time.Day,0,0,0);
            var curDay = cur.Day;
            if (!sunFirst)
            {
                if (curDay == 0) curDay = 7;
                curDay--;
            }
            var starTimedec = GetTimestamp(cur) - curDay * 86400;
            var endTimeDec = starTimedec + 7 * 86400;
            return targetMilSec >= starTimedec && targetMilSec < endTimeDec;
        }

        public static string GenerateTimeDesc1(int occurTime)
        {
            int deltaTime = occurTime;
            float ONE_DAY_TIME = 24 * 60 * 60;
            float ONE_HOUR_TIME = 60 * 60;
            float ONE_MINUTE_TIME = 60;

            string str = "";
            var day = Mathf.Floor(deltaTime / ONE_DAY_TIME);
            if (day > 0)
            {
                
                str += day.ToString() + Lang.GetValue("time.day");//{0}天后
            }
            var hour = Mathf.Floor((deltaTime % ONE_DAY_TIME)/ ONE_HOUR_TIME);
            if (hour > 0)
            {
                str += hour.ToString() + Lang.GetValue("time.hour");//{0}天后
                
            }
            var min = Mathf.Floor(((deltaTime % ONE_DAY_TIME) % ONE_HOUR_TIME)/ ONE_MINUTE_TIME);
            if (min > 0)
            {
                str += min.ToString() + Lang.GetValue("time.min");//{0}天后
                
            }
            var dec = ((deltaTime % ONE_DAY_TIME) % ONE_HOUR_TIME) % ONE_MINUTE_TIME;
            str += dec.ToString() + Lang.GetValue("time.dec");//{0}秒后
            return str;
        }

        public static DateTime GetHourTime(DateTime inputDate, int hour)
        {
            // 确保小时在有效范围内 (0-23)
            hour = Math.Clamp(hour, 0, 23);

            return new DateTime(inputDate.Year, inputDate.Month, inputDate.Day, hour, 0, 0);
        }

    }

    

}

public enum TimeFormat
{
    /**这个是从小时开始计算，有多少个小时就显示多少个小时，天数计入小时范围内 2122123:44:55(小时会超出24)*/
    DateFullHourMinuteSecond_GBK_To_Hour,
    /**这个是从小时开始计算，用它时需要省略天 22:44:55(小时会超出24)*/
    DateHourMinuteSecond_GBK_To_Hour,
    /**只显示天数和小时 */
    DateWithoutMinSec,
    /**时间只显示2位 */
    DateWithTwoDigit,
    /**仅仅秒数 */
    DateWidthSecondOnly,
    /**仅仅显示分钟和秒 */
    DateWithMinAndSecond
}
