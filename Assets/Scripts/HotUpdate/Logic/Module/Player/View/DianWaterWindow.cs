using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;

public class DianWaterWindow : BaseWindow
{
   private fun_Scene.dian_water_view view;
    private Dictionary<int, CountDownTimer> timeMap;
   public DianWaterWindow()
    {
        packageName = "fun_Scene";
        // 设置委托
        BindAllDelegate = fun_Scene.fun_SceneBinder.BindAll;
        CreateInstanceDelegate = fun_Scene.dian_water_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Scene.dian_water_view;
        SetBg(view.bg, "Welfare/ELIDA_lqsd_bg.png");
        timeMap = new Dictionary<int, CountDownTimer>();
        EventManager.Instance.AddEventListener(PlayerEvent.WaterStage, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateData();
    }
    private void UpdateData()
    {
        for(int i = 0;i < 3; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_Scene.dian_water_item;
            List<int> timeDis = null;
            if(i == 0)
            {
                timeDis = GlobalModel.Instance.module_profileConfig.dianWaterTime1;
            }
            else if(i == 1)
            {
                timeDis = GlobalModel.Instance.module_profileConfig.dianWaterTime2;
            }
            else
            {
                timeDis = GlobalModel.Instance.module_profileConfig.dianWaterTime3;
            }
            cell.tipLab.text = Lang.GetValue("dian_water_1",timeDis[0] + "-" + timeDis[1]);
            cell.pic.url = ImageDataModel.WATER_ICON_URL;
            cell.numLab.text = GlobalModel.Instance.module_profileConfig.dianWaterReward.ToString();

            var status = GetTime(timeDis);
            if(status > 0)
            {
                cell.status.selectedIndex = 2;
                if (timeMap.ContainsKey(i) && timeMap[i] != null)
                {
                    timeMap[i].Clear();
                    timeMap.Remove(i);
                }
                var timer = new CountDownTimer(cell.timeLab, status, true, 2);
                timer.prefixString = "(";
                timer.suffixString = ")";
                timer.CompleteCallBacker = () =>
                {
                    UpdateData();
                };
                timeMap.Add(i, timer);
                StringUtil.SetBtnTab(cell.get_btn, Lang.GetValue("dian_water_2"));
            }else
            {
                if(MyselfModel.Instance.welfareInfo.waterStage != null && Array.IndexOf(MyselfModel.Instance.welfareInfo.waterStage,(uint)(i+1)) != -1)
                {
                    cell.status.selectedIndex = 3;

                    cell.getLab.text = Lang.GetValue("Tour_gift_txt8");
                }
                else if (status == 0)
                {
                    cell.status.selectedIndex = 0;
                    StringUtil.SetBtnTab(cell.get_btn, Lang.GetValue("common_claim_button"));
                }
                else
                {
                   
                    cell.status.selectedIndex = 1;
                    StringUtil.SetBtnTab(cell.video_btn, Lang.GetValue("dian_water_3"));
                }
            }
            
            cell.get_btn.data = i + 1;
            cell.video_btn.data = i + 1;
            cell.get_btn.onClick.Add(GetWater);
            cell.video_btn.onClick.Add(GetVideoWater);
        }
    }
    private void GetWater(EventContext context)
    {
        var pos = (int)(context.sender as GComponent).data;
        MyselfController.Instance.ReqWaterStage((uint)pos, false);
    }
    private void GetVideoWater(EventContext context)
    {
        var pos = (int)(context.sender as GComponent).data;
        MyselfController.Instance.ReqWaterStage((uint)pos, true);
    }
    private int GetTime(List<int> hours)
    {
        var date = TimeUtil.GetDateTime(ServerTime.Time);
        var hour = date.Hour;
        if(hour < hours[0])
        {
            var time = TimeUtil.GetHourTime(date, hours[0]);
            var endTime = time - date;
            return (int)endTime.TotalSeconds;
        }
        else if(hour >= hours[1])
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        foreach (var time in timeMap.Values)
        {
            time.Clear();
        }
    }
}

