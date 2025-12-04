//
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using static protobuf.guild.S_MSG_GUILD_SHARE_FLOWER_INFO;
//using protobuf.guild;

//public class FlowerShareWindow : BaseWindow
//{
//   private fun_GuildFlowerShare.flowerShareView _view;
//    private List<S_MEMBER_SHARE> listData;
//   public FlowerShareWindow()
//    {
//        packageName = "fun_GuildFlowerShare";
//        // 设置委托
//        BindAllDelegate = fun_GuildFlowerShare.fun_GuildFlowerShareBinder.BindAll;
//        CreateInstanceDelegate = fun_GuildFlowerShare.flowerShareView.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        _view = ui as fun_GuildFlowerShare.flowerShareView;
//        _view.lb_tip.text = Lang.GetValue("Share_txt2");
//        _view.lb_tip_none.text = Lang.GetValue("Share_txt3");

//        StringUtil.SetBtnTab(_view.btn_addCount, Lang.GetValue("Share_txt5"));
//        StringUtil.SetBtnTab(_view.btn_share, Lang.GetValue("Share_txt6"));
//        _view.titleLab.text = Lang.GetValue("Share_txt25");

//        _view.list.itemRenderer = ShareItemRenderer;
//        _view.list.SetVirtual();

//        _view.btn_addCount.onClick.Add(() =>
//        {
//            int guildCoin = 0;
//            if (GuildModel.Instance.guild.addShareNum == 0)
//            {
//                guildCoin = FlowerShareModel.Instance.shareConfig.Add1;
//            }
//            else if(GuildModel.Instance.guild.addShareNum == 1)
//            {
//                guildCoin = FlowerShareModel.Instance.shareConfig.Add2;
//            }
//            var param = new FlowerShareAlert(0, guildCoin, () =>
//            {
//                if(GuildModel.Instance.guild.money < guildCoin)
//                {
//                    UILogicUtils.ShowNotice(Lang.GetValue("Share_txt37"));
//                    return;
//                }
//                FlowerShareController.Instance.ReqGuildAddShareNum();
//            });
//            UIManager.Instance.OpenWindow<FlowerShareAlertWindow>(UIName.FlowerShareAlertWindow, param);
//        });

//        _view.btn_share.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<FlowerShareManagerWindow>(UIName.FlowerShareManagerWindow);
//        });

//        EventManager.Instance.AddEventListener(FlowerShareEvent.GuildShareFlowerInfo, UdpateMemberList);
//        EventManager.Instance.AddEventListener(FlowerShareEvent.GuildAddShareNum, updateShareCount);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        FlowerShareController.Instance.ReqGuildShareFlowerInfo();
//    }

//    private void UdpateMemberList()
//    {
//        listData = FlowerShareModel.Instance.guildMemberShareFlowers;
//        _view.status.selectedIndex = listData.Count > 0 ? 0 : 1;
//        _view.power.selectedIndex = (GuildModel.Instance.guildMember.position == 1 || GuildModel.Instance.guildMember.position == 2) ? 0 : 1;
//        _view.list.numItems = listData.Count;
//        updateShareCount();

//    }

//    private void updateShareCount()
//    {
//        uint maxCount = GuildModel.Instance.guild.addShareNum + 1;

//        _view.lb_shareCount.text = Lang.GetValue("Share_txt4", FlowerShareModel.Instance.surplusTakeCnt.ToString(), maxCount.ToString());
//        _view.btn_addCount.enabled = maxCount < 3;
//    }

//    private void ShareItemRenderer(int index,GObject item)
//    {
//        var cell = item as fun_GuildFlowerShare.flowerShareItemRenderer;
//        var info = listData[index].userInfo;
//        cell.playerHead.img_head.url = "";
        
//        UILogicUtils.ChangeOthersFrameDisplay(info.flowerLevel, info.flowerLevelExpireTime, (cell.playerHead.picFrame as common_New.PictureFrame), info.headFrame);
//        cell.playerHead.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
//        cell.playerHead.lb_townName.text = info.townName;
//        cell.list.data = index;
//        cell.list.itemRenderer = FlowerListRenderer;
//        cell.list.numItems = 3;
//    }

//    private void FlowerListRenderer(int index,GObject item)
//    {
//        var cell = item as fun_GuildFlowerShare.flowerShare_cell_0;
//        int id = (int)cell.parent.data;
//        var data = listData[id];
//        var info = data.shareFlowers.Find((value) => (int)value.position == (index + 1));

        
//        if (info != null)
//        {
//            cell.data = info;
//            cell.sellstatus.selectedIndex = 0;
//            cell.img_flower.url = ImageDataModel.Instance.GetIconUrlByEntityId(info.flowerId); 
//            string txtCount = info.times == FlowerShareModel.getFlowerMaxCount? "<font color='#ff0000'>0</font>" : (FlowerShareModel.getFlowerMaxCount - info.times)*uint.Parse(info.count) + "";
//            cell.lb_flowerCount.text = txtCount + "/" + (uint.Parse(info.count) * FlowerShareModel.getFlowerMaxCount);
//            cell.touchable = !(info.times == FlowerShareModel.getFlowerMaxCount);
//        }
//        else
//        {
//            cell.data = null;
//            cell.sellstatus.selectedIndex = 1;
//            cell.lb_flowerCount.text = "";
//        }
//        cell.onClick.Add(GetShareHander);
//    }

//    public void GetShareHander(EventContext context)
//    {
//        var data = (context.sender as GComponent).data as I_FLOWER_SHARE_VO;
//        if(data == null )
//        {
//            return;
//        }
//        uint maxCount = GuildModel.Instance.guild.addShareNum + 1;
//        if (FlowerShareModel.Instance.surplusTakeCnt <= 0)
//        {
//            UILogicUtils.ShowNotice(Lang.GetValue("Share_txt36"));
//            return;
//        }
//        var param = new FlowerShareAlert(4, data, () =>
//        {
//            FlowerShareController.Instance.ReqGuildTaskShareFlower(data.userId, data.position);
//        });
//        UIManager.Instance.OpenWindow<FlowerShareAlertWindow>(UIName.FlowerShareAlertWindow, param);
        
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

