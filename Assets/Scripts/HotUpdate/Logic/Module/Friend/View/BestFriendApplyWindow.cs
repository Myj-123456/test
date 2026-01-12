using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using protobuf.common;
using protobuf.friend;
using protobuf.messagecode;
using FairyGUI;
using ADK;

public class BestFriendApplyWindow : BaseWindow
{
    private fun_Friends.newBestFriendView view;
    
    // 存储用户信息的字典，键为用户ID
    private Dictionary<uint, I_USER_PROFILE> applyUserInfos = new Dictionary<uint, I_USER_PROFILE>();
    
    public BestFriendApplyWindow()
    {
        packageName = "fun_Friends";
        // 设置委托
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.newBestFriendView.CreateInstance;
    }
    
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.newBestFriendView;
        
        view.best_Title.text = Lang.GetValue("guild.tab_title_applicant"); //申请列表

        SetBg(view.bg, "Common/common_big_tip_bg.png");
        
        // 初始化列表渲染器
        view.list.itemRenderer = ListRendererApply;
        view.list.SetVirtual();
        
        view.close_btn.onClick.Add(CloseView);
        // 设置空数据提示并默认隐藏
        StringUtil.SetBtnTab(view.nullTip, Lang.GetValue("notfriendinv_txt"));
        view.nullTip.visible = false;
        view.nullTip.touchable = false;
    }
    
    public override void OnShown()
    {
        base.OnShown();
        
        // 请求蜜友申请列表数据
        FriendController.Instance.ReqCronyBeApply();
        // 监听蜜友申请列表数据更新事件
        EventManager.Instance.AddEventListener(FriendEvent.CronyBeApply, UpdateApplyList);
        // 监听蜜友同意和拒绝事件
        EventManager.Instance.AddEventListener(FriendEvent.CronyAgree, UpdateApplyList);
        EventManager.Instance.AddEventListener(FriendEvent.CronyReject, UpdateApplyList);
    }
    
    public override void OnHide()
    {
        base.OnHide();
        applyUserInfos.Clear();
    }
    
    /// <summary>
    /// 更新申请列表
    /// </summary>
    private void UpdateApplyList()
    {
        if (view == null || FriendModel.Instance == null) return;
        // 清空现有数据
        applyUserInfos.Clear();
        // 获取密友申请用户ID列表
        if (FriendModel.Instance.applyUserIds != null && FriendModel.Instance.applyUserIds.Count > 0)
        {
            foreach (uint userId in FriendModel.Instance.applyUserIds)
            {
                I_USER_PROFILE userInfo = null;
                if (FriendModel.Instance.friendList != null)
                {
                    var friendData = FriendModel.Instance.friendList.Find(f => f.userInfo.userId == userId);
                    if (friendData != null)
                    {
                        // 将好友信息转换为用户信息格式
                        userInfo = new I_USER_PROFILE();
                        userInfo.userId = friendData.userInfo.userId;
                        userInfo.userLevel = friendData.userInfo.userLevel;
                        userInfo.townName = friendData.userInfo.townName;
                        userInfo.headImgId = friendData.userInfo.headImgId;
                        userInfo.headFrame = friendData.userInfo.headFrame;
                        userInfo.lastLoginTime = friendData.userInfo.lastLoginTime;
                        
                        // 只添加有效的用户信息到字典
                        applyUserInfos[userId] = userInfo;
                    }
                }
            }
        }
        // 更新列表数据源
        view.list.numItems = applyUserInfos.Count;
        // 处理空列表情况
        if (applyUserInfos.Count == 0)
        {
            view.nullTip.visible = true;
            view.list.visible = false;
        }
        else
        {
            // 强制隐藏空提示，确保有数据时不显示
            view.nullTip.visible = false;
            view.nullTip.touchable = false;
            view.list.visible = true;
            
            // 刷新列表显示
            view.list.RefreshVirtualList();
        }
    }
    
    /// <summary>
    /// 渲染申请列表项
    /// </summary>
    private void ListRendererApply(int index, GObject item)
    {
        fun_Friends.BestListItem ui_ = item as fun_Friends.BestListItem;
        var userIds = applyUserInfos.Keys.ToArray();
        if (index >= 0 && index < userIds.Length)
        {
            uint userId = userIds[index];
            // 从applyUserInfos字典中获取用户信息
            if (applyUserInfos.TryGetValue(userId, out I_USER_PROFILE userInfo) && userInfo != null)
            {
                if (ui_ != null)
                {
                    StringUtil.SetBtnUrl(ui_.heead, "Avatar/ELIDA_common_touxiangdi01.png");
                    
                    ui_.txt_lv.text = userInfo.userLevel.ToString();

                    ui_.txt_name.text = TextUtil.GetServerName(userInfo.serverId, userInfo.townName);
                    var headVo = ItemModel.Instance.GetItemById(int.Parse(userInfo.headImgId));
                    var frameVo = ItemModel.Instance.GetItemById((int)(userInfo.headFrame));
                    UILogicUtils.ShowHeadFrames(ui_.picFrame as common_New.PictureFrame, frameVo);
                    (ui_.heead as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);

                    if (userInfo.title == 0)
                    {
                        ui_.titleTxt.text = Lang.GetValue("player_info_12");
                    }
                    else
                    {
                        var titleId = (int)userInfo.title;
                        var titleVo = ItemModel.Instance.GetItemById(titleId);
                        ui_.titleTxt.text = Lang.GetValue(titleVo.Name);
                    }
                    // 设置按钮文本和点击事件
                    StringUtil.SetBtnTab(ui_.btn_Agree, Lang.GetValue("best_27")); //同意
                    ui_.btn_Agree.onClick.Clear();
                    ui_.btn_Agree.onClick.Add(() => OnAddFriend(userId, ui_));
                    
                    StringUtil.SetBtnTab(ui_.btn_refuse, Lang.GetValue("Friend_16")); //拒绝
                    ui_.btn_refuse.onClick.Clear();
                    ui_.btn_refuse.onClick.Add(() => OnDenyFriend(userId, ui_));
                }
            }
        }
    }
    
    /// <summary>
    /// 同意申请
    /// </summary>
    private void OnAddFriend(uint userId,fun_Friends.BestListItem ui_)
    {
        // 调用控制器同意申请
        FriendController.Instance.ReqCronyAgree(userId);
        if (ui_.txtcontroller != null)
        {
            ui_.txtcontroller.selectedIndex = 1;
        }
    }
    
    /// <summary>
    /// 拒绝申请
    /// </summary>
    private void OnDenyFriend(uint userId,fun_Friends.BestListItem ui_)
    {
        // 调用控制器拒绝申请
        FriendController.Instance.ReqCronyReject(userId);
        if (ui_.txtcontroller != null)
        {
            ui_.txtcontroller.selectedIndex = 2;
        }
    }
    
    // 关闭窗口
    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.BestFriendApplyWindow);
    }
}
