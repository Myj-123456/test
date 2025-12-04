using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ADK;
using protobuf.misc;
using Elida.Config;

public class SeventhSignModel : Singleton<SeventhSignModel>
{
    public static int SevethSignEevntId = 5;

    public Ft_days_loginConfigData seventhSignData = ConfigManager.Instance.GetConfig<Ft_days_loginConfigData>("ft_days_loginsConfig");
    public int signDay;
    /**0:不是新用户 1:新用户 */
    public int status;
    public int signLastTiem;
    //今日是否领取奖励
    public bool todayHaveDraw;

    public bool isOpenView = false;

    public List<Ft_days_loginConfig> seventhSignLsitData;

    private List<Ft_days_loginConfig> _sevenList;
    public  List<Ft_days_loginConfig> sevenList { get
        {
            if(_sevenList == null)
            {
                var seventhSignData = ConfigManager.Instance.GetConfig<Ft_days_loginConfigData>("ft_days_loginsConfig");
                _sevenList = seventhSignData.DataList;
            }
            return _sevenList;
        } }

    public void ParseData(I_DAILY_LOGIN data)
    {
        signDay = (int)data.currentDay;
        status = (int)data.status;
        todayHaveDraw = data.todayHaveDraw;
        InitDays_loginConfig();
        if (isOpenView)
        {
            UIManager.Instance.OpenWindow<SeventhSignWindow>(UIName.SeventhSignWindow);
        }
    }


   public void InitDays_loginConfig()
    {
        seventhSignLsitData = new List<Ft_days_loginConfig>();
        foreach (var item in seventhSignData.DataList)
        {
            var round = status == 0 ? "2" : "1";
            //if(item.Rounds[0].EntityID == round)
            //{
            //    seventhSignLsitData.Add(item);
            //}
        }
        //seventhSignLsitData.Sort((a, b) =>
        //{
        //    return a.DayNum - b.DayNum;
        //});
    }

}

