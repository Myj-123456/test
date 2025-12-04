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
        
        // 设置标题
        view.titleLab.text = "申请列表"; 
        
        // 设置背景
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        
        // 初始化列表渲染器
        view.list.itemRenderer = ListRendererApply;
        view.list.SetVirtual();
        
        view.close_btn.onClick.Add(CloseView);
        // 设置空数据提示并默认隐藏
        StringUtil.SetBtnTab(view.nullTip, "暂无新的密友申请");
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
        // 监听蜜友同意和拒绝事件，以便更新列表
        EventManager.Instance.AddEventListener(FriendEvent.CronyAgree, UpdateApplyList);
        EventManager.Instance.AddEventListener(FriendEvent.CronyReject, UpdateApplyList);
    }
    
    public override void OnHide()
    {
        base.OnHide();
        
        // 移除事件监听
        EventManager.Instance.RemoveEventListener(FriendEvent.CronyBeApply, UpdateApplyList);
        EventManager.Instance.RemoveEventListener(FriendEvent.CronyAgree, UpdateApplyList);
        EventManager.Instance.RemoveEventListener(FriendEvent.CronyReject, UpdateApplyList);
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
        // 从模型中获取密友申请用户ID列表
        if (FriendModel.Instance.applyUserIds != null && FriendModel.Instance.applyUserIds.Count > 0)
        {
            foreach (uint userId in FriendModel.Instance.applyUserIds)
            {
                I_USER_PROFILE userInfo = null;
                if (FriendModel.Instance.friendList != null)
                {
                    var friendData = FriendModel.Instance.friendList.Find(f => f.userId == userId);
                    if (friendData != null)
                    {
                        // 将好友信息转换为用户信息格式
                        userInfo = new I_USER_PROFILE();
                        userInfo.userId = friendData.userId;
                        userInfo.userLevel = friendData.userLevel;
                        userInfo.townName = friendData.townName;
                        userInfo.headImgId = friendData.headImgId;
                        userInfo.headFrame = friendData.headFrame;
                        userInfo.lastLoginTime = friendData.lastLoginTime;
                    }
                }
                
                // 如果找不到完整信息，创建一个基本信息对象
                if (userInfo == null)
                {
                    userInfo = new I_USER_PROFILE();
                    userInfo.userId = userId;
                    userInfo.townName = "用户" + userId;
                    // 其他字段可以设置默认值
                }
                applyUserInfos[userId] = userInfo;
            }
        }
        else
        {
            // 记录空列表日志
            Debug.Log("没有密友申请数据");
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
            if (applyUserInfos.TryGetValue(userId, out I_USER_PROFILE userInfo))
            {
                if (ui_ != null)
                {
                    StringUtil.SetBtnUrl(ui_.heead, "Avatar/ELIDA_common_touxiangdi01.png");
                    ui_.txt_name.text = userInfo.townName;
                    ui_.txt_lv.text = userInfo.userLevel.ToString();
                    
                    // 设置按钮文本和点击事件
                    StringUtil.SetBtnTab(ui_.btn_Agree, "同意");
                    ui_.btn_Agree.onClick.Clear();
                    ui_.btn_Agree.onClick.Add(() => OnAddFriend(userId, ui_));
                    
                    StringUtil.SetBtnTab(ui_.btn_refuse, "拒绝");
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
