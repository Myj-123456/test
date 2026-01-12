using Elida.Config;
using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;
using fun_Rob;

public class RobBedCom : Singleton<RobBedCom>
{
    public UIPanel panel;
    private fun_Rob.robbedCell2[] cages;
    private Dictionary<uint, CountDownTimer> timerMap;

    public void Init(Transform parent)
    {
        panel = GetUIPanel();
        panel.gameObject.transform.parent = parent;
        parent.transform.localPosition = new Vector3(-30.4f, 1.2f, 0f);
        panel.gameObject.transform.localPosition = new Vector3(-3.4f, 3.1f, 0f);
        panel.ui.visible = false;
        timerMap = new Dictionary<uint, CountDownTimer>();
        UpdateData();
        AddEventListeners();
    }

    private void UpdateData()
    {
        var view = panel.ui as fun_Rob.robbedList;
        if (view == null) return;
        // 显示界面
        panel.ui.visible = true;
        cages = new fun_Rob.robbedCell2[] { view.cage_0, view.cage_1, view.cage_2, view.cage_3 };
        UpdateCages();
    }

    public void AddEventListeners()
    {
        EventManager.Instance.AddEventListener(RobEvent.RobInfo, UpdateCages);
        EventManager.Instance.AddEventListener(RobEvent.RobUnlock, UpdateCages);
        
        // 添加UI点击事件监听
        var view = panel.ui as fun_Rob.robbedList;
        if (view != null)
        {
            view.onClick.Add(OnRobBedClick);
        }
    }

    public void RemoveEventListeners()
    {
        EventManager.Instance.RemoveEventListener(RobEvent.RobInfo, UpdateCages);
        EventManager.Instance.RemoveEventListener(RobEvent.RobUnlock, UpdateCages);
        
        // 移除UI点击事件监听
        var view = panel.ui as fun_Rob.robbedList;
        if (view != null)
        {
            view.onClick.Remove(OnRobBedClick);
        }
    }

    private void UpdateCages()
    {
        int len = cages.Length;
        for (int i= 0; i < len; i++)
        {
            UpdateCage(i);
        }
    }

    private void UpdateCage(int index)
    {
        var cage = cages[index];

        // 清除旧数据
        cage.img_head.url = "";
        var cageData = RobModel.Instance.GetArrestInfo((uint)(index + 1));

        if (cageData != null)
        {
            cage.data = cageData;
            if (cageData.acquittalTime > ServerTime.Time)
            {
                cage.status.selectedIndex = 0;
                
                // 显示玩家信息
                if (cageData.userInfo != null)
                {
                    var frameVo = ItemModel.Instance.GetItemById((int)cageData.userInfo.headFrame);
                    var headVo = ItemModel.Instance.GetItemById(int.Parse(cageData.userInfo.headImgId));
                    cage.img_head.url = ImageDataModel.Instance.GetIconUrl(headVo);
                }
                
                // 设置倒计时
                if (timerMap.ContainsKey(cageData.position))
                {
                    timerMap[cageData.position].Clear();
                }
                else
                {
                    timerMap.Add(cageData.position, null);
                }
                uint time = cageData.acquittalTime - ServerTime.Time;
                int totalTime = RobModel.Instance.robOtherConfig.PrisonTime;
                timerMap[cageData.position] = new CountDownTimer(cage.jindu, (int)time, totalTime);
                timerMap[cageData.position].CompleteCallBacker = () => { UpdateCage(index); };
            }
            else
            {
                cage.status.selectedIndex = 1;
                cage.img_head.url = "";
            }
        }
        else
        {
            if(index == 3 && !MyselfModel.Instance.IsVip())
            {
                cage.status.selectedIndex = 4;
            }
            else
            {
                cage.status.selectedIndex = 2;
            }
            int value = 0;
            if (index == 1)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume1s[0].Value;
            }
            else if(index == 2)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume2s[0].Value;
            }
        }
    }

    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("RobBed");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Rob";
        panel.componentName = "robbedList";
        panel.container.touchable = true;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }
    
    /// <summary>
    /// 点击RobBed UI时打开RobWindow面板
    /// </summary>
    private void OnRobBedClick()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.Rob, true))
        {
            return;
        }
        UIManager.Instance.OpenWindow<RobWindow>(UIName.RobWindow);
    }
}