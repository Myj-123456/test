//
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using protobuf.guild;
//using ADK;

//public class FlowerShareLogsWindow : BaseWindow
//{
//   private fun_GuildFlowerShare.flowerShareLogs _view;
//    public List<I_FLOWER_SHARE_LOG_VO> logs;

//    public FlowerShareLogsWindow()
//    {
//        packageName = "fun_GuildFlowerShare";
//        // 设置委托
//        BindAllDelegate = fun_GuildFlowerShare.fun_GuildFlowerShareBinder.BindAll;
//        CreateInstanceDelegate = fun_GuildFlowerShare.flowerShareLogs.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        _view = ui as fun_GuildFlowerShare.flowerShareLogs;
//        _view.lb_title.text = Lang.GetValue("Share_txt17");
//        _view.lb_tip.text = Lang.GetValue("Share_txt18");
//        _view.list.itemRenderer = LogItemRenderer;

//        _view.list.SetVirtual();
//        EventManager.Instance.AddEventListener(FlowerShareEvent.GuildShareFlowerLog, UpdateList);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        FlowerShareController.Instance.ReqGuildShareFlowerLog();
//    }

//    private void UpdateList()
//    {
//        logs = FlowerShareModel.Instance.messageList;
//        logs.Sort((a, b) => (int)b.operateTime - (int)a.operateTime);
//        _view.list.numItems = logs.Count;
//        _view.list.ScrollToView(0);
//    }
    
//    private void LogItemRenderer(int index,GObject item)
//    {
//        var cell = item as fun_GuildFlowerShare.flowerShare_logSell;
//        var log = logs[index];
//        var crop = StorageModel.Instance.seedList.Find((value) => value.flowerId == (int)log.flowerId);

//        string name = log.townName;
//        var info = Lang.GetValue("Share_txt31", log.count.ToString(), Lang.GetValue(crop.item.Name), name, log.goldNum.ToString(), log.expNum.ToString(), (FlowerShareModel.Instance.shareConfig.RewardNum / 5).ToString());
//        var data = TimeUtil.DateToStr((long)log.operateTime * 1000, "MM/dd hh:mm");
//        cell.lb_info.text = data + " " + info;
//        cell.height = cell.lb_info.height + 10;
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

