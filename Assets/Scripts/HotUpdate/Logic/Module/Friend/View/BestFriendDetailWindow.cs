using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using protobuf.common;
using protobuf.friend;
using protobuf.messagecode;
using FairyGUI;
using ADK;
using Elida.Config;

public class BestFriendDetailWindow : BaseWindow
{
    private fun_Friends.newBestFriendLevelView view;
    private Ft_mfriend_configConfigData _configData;
    
    public BestFriendDetailWindow()
    {
        packageName = "fun_Friends";
        BindAllDelegate=fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate=fun_Friends.newBestFriendLevelView.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.newBestFriendLevelView;
        view.titleLab.text = "密友等级";
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.title1.text = "密友等级";
        view.title2.text = "摸花+1概率";
        view.title3.text = "好友币兑换";
        view.title4.text = "额外星光花概率";

        // 获取配置表数据
        _configData = ConfigManager.Instance.GetConfig<Ft_mfriend_configConfigData>("ft_mfriend_configsConfig");
        
        view.list.itemRenderer = ListRendererLevel;
        view.list.SetVirtual();
        view.list.numItems = _configData?.DataList.Count ?? 40;
        view.close_btn.onClick.Add(CloseView);
    }
    private void ListRendererLevel(int index, object item)
    {
        fun_Friends.BestLevelListItem levelItem = item as fun_Friends.BestLevelListItem;
        if(levelItem == null)
        {
            return;
        }
        
        int level = index + 1;
        levelItem.txt_count.text = level.ToString();

        levelItem.level_bg.selectedIndex = level % 2 == 1 ? 0 : 1;
        
        // 从配置表获取数据
        if (_configData != null)
        {
            var config = _configData.Get(level);
            levelItem.txt_touch.text = $"{config.MoProb}%";
            levelItem.txt_exchange.text = $"+{config.ExtraTime}";
            levelItem.txt_additional.text = $"{config.FairyProb}%";
        }
    }
    
    public void CloseView()
    {
       UIManager.Instance.CloseWindow(UIName.BestFriendDetailWindow);
    }
}