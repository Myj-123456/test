using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using protobuf.common;
using protobuf.friend;
using protobuf.messagecode;
using FairyGUI;
using ADK;


public class BestFriendAddWindow : BaseWindow
{
    private fun_Friends.newBestListView view;
    private List<I_FRIEND_PROFILE> friendListData=new List<I_FRIEND_PROFILE>();
    private uint _currentFriendId = 0;
    private int _cronyBookCount = 0;
    public BestFriendAddWindow()
    {
        packageName = "fun_Friends";
        BindAllDelegate=fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate=fun_Friends.newBestListView.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.newBestListView;
        view.titleLab.text = "申请密友";
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.n25.text=0.ToString();
        view.list.itemRenderer = ListRendererAdd;
        view.list.SetVirtual();
        
        StringUtil.SetBtnTab(view.nullTip,"您还没有好友");
        view.nullTip.visible = false;
        view.nullTip.touchable = false;
        view.close_btn.onClick.Add(CloseView);
        view.bg_sign.onClick.Add(()=>
        {
            view.applybestTip.selectedIndex = 0;
        });
        view.n16.text = "";
        view.btn_lookup.onClick.Add(OnLookupFriend);
        
        // 添加输入框焦点事件
        view.n16.onFocusIn.Add(OnFindTxtFocusIn);
        view.n16.onFocusOut.Add(OnFindTxtFocusOut);

        EventManager.Instance.AddEventListener(FriendEvent.FriendList, () => OnFriendListUpdate());
        EventManager.Instance.AddEventListener(FriendEvent.CronyBookBuySuccess, OnCronyBookBuySuccess);
    }
    public override void OnShown()
    {
        base.OnShown();
        FriendController.Instance.ReqFriendList();
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    private void OnFriendListUpdate()
    {
        UpdateFriendList();
    }
    private void UpdateFriendList()
    {
        friendListData=FriendModel.Instance.friendList;
        friendListData.Sort(FriendSort);
        view.list.numItems = friendListData.Count;
        view.list.visible = friendListData.Count > 0;
        view.nullTip.visible = friendListData.Count <= 0;
    }
    private int FriendSort(I_FRIEND_PROFILE a, I_FRIEND_PROFILE b)
    {
       if(a.userLevel!=b.userLevel)
       {
           return b.userLevel.CompareTo(a.userLevel);
       }
       return a.townName.CompareTo(b.townName);
    }
    private void ListRendererAdd(int index, GObject item)
    {
        fun_Friends.BestApplyItem ui_=item as fun_Friends.BestApplyItem;
        if (ui_ == null || index < 0 || index >= friendListData.Count) return;
        var vo_ = friendListData[index];

        StringUtil.SetBtnUrl(ui_.heead, "Avatar/ELIDA_common_touxiangdi01.png");
        ui_.txt_lv.text = vo_.userLevel.ToString();
        ui_.txt_name.text = vo_.townName;
        
        // 显示在线状态或离线时间
        ui_.Text_time.text = TimeUtil.GenerateTimeDesc((int)vo_.lastLoginTime);
        
        // 检查对方是否已经是密友
        if (FriendModel.Instance.GetCronyData(vo_.userId) != null)
        {
            // 已成为密友，设置控制器索引为2并禁用申请按钮
            ui_.txtcontroller.selectedIndex = 2;
            ui_.btn_newApply.touchable = false;
        }
        // 检查对方等级是否达到20级
        else if (vo_.userLevel < 20)
        {
            ui_.txtcontroller.selectedIndex=1;
        }
        // 检查好友关系是否超过12小时
        else if (!FriendModel.Instance.IsFriendRelationOver12Hours(vo_.userId))
        {
            // 好友关系未满12小时，设置控制器索引为1并禁用申请按钮
            ui_.txtcontroller.selectedIndex=1;
            ui_.Text_unLevel.text="好友关系未满12小时";
        }
        else
        {
            // 检查是否处于申请中
            if (FriendModel.Instance.applyTimeDictionary.ContainsKey(vo_.userId) && !FriendModel.Instance.IsApplyExpired(vo_.userId))
            {
                ui_.txtcontroller.selectedIndex = 2;
                ui_.btn_newApply.touchable = false;
            }
            // 检查是否处于被申请中
            else if (FriendModel.Instance.applyUserIds.Contains(vo_.userId))
            {
                ui_.txtcontroller.selectedIndex = 2;
                ui_.btn_newApply.touchable = false;
            }
            else
            {
                // 默认状态，允许发起申请
                ui_.txtcontroller.selectedIndex = 0;
                ui_.btn_newApply.touchable = true;
            }
        }
        StringUtil.SetBtnTab(ui_.btn_newApply,"发起申请");
        ui_.btn_newApply.onClick.Clear();
        ui_.btn_newApply.onClick.Add(()=> OnApplyBestFrend(vo_.userId));
    }
    private void OnApplyBestFrend(uint friendId)
    {
            _currentFriendId = friendId;
            UpdateCronyBookCount();

            if (_cronyBookCount > 0)
            {
                ShowUseBookUI();
            }
            else
            {
                ShowBuyBookUI();
            }
    }

    private void UpdateCronyBookCount()
    {
        try
        {
            // 密友结书物品ID
            const int cronyBookItemId = 41013043;
            _cronyBookCount = StorageModel.Instance.GetItemCount(cronyBookItemId);
            view.n25.text = _cronyBookCount.ToString();
            view.text_best_buyBookCount.text = _cronyBookCount.ToString();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("获取结书数量失败: " + ex.Message);
            // 异常时不修改_cronyBookCount，保持原有值不变
            view.n25.text = _cronyBookCount.ToString();
            view.text_best_buyBookCount.text = _cronyBookCount.ToString();
        }
    }

    private void ShowUseBookUI()
    {
        view.applybestTip.selectedIndex = 1;
        StringUtil.SetBtnTab(view.btn_bestjieshu, "确定使用");
        view.btn_bestjieshu.onClick.Clear();
        view.btn_bestjieshu.onClick.Add(UseCronyBook);
    }

    private void ShowBuyBookUI()
    {
        view.applybestTip.selectedIndex = 2;
        StringUtil.SetBtnTab(view.btn_bestbuy, "购买结书");
        view.btn_bestbuy.onClick.Clear();
        view.btn_bestbuy.onClick.Add(BuyCronyBook);
    }

    private void UseCronyBook()
    {
        // 先检查结书数量是否大于0
        if (_cronyBookCount <= 0)
        {
            UILogicUtils.ShowNotice("结书数量不足");
            return;
        }
        
        // 防止重复点击
        if (_currentFriendId == 0) return;
        
        // 检查该好友是否已经是密友
        if (FriendModel.Instance.GetCronyData(_currentFriendId) != null)
        {
            UILogicUtils.ShowNotice("该好友已经是您的密友");
            view.applybestTip.selectedIndex = 0;
            return;
        }
        
        try
        {
            // 发送申请前再次检查
            FriendModel.Instance.SendApplyBestFriend(_currentFriendId);
            
            // 只在成功发送后减少结书数量
            _cronyBookCount--;
            // 更新显示
            view.applybestTip.selectedIndex = 0;
            UpdateCronyBookDisplay();
            
            // 找到对应的列表项并设置控制器索引为2
            UpdateFriendItemController(_currentFriendId, 2);
            
            // 显示成功提示
            UILogicUtils.ShowNotice("密友申请已发送");
        }
        catch (System.Exception ex)
        {
            // 失败时不减少结书数量
            UILogicUtils.ShowNotice("发送申请失败，请重试");
            Debug.LogError("发送密友申请失败: " + ex.Message);
            
            // 重新获取结书数量以确保准确性
            UpdateCronyBookCount();
        }
    }
    
    // 更新好友列表项的控制器索引
    private void UpdateFriendItemController(uint friendId, int index)
    {
        // 遍历列表找到对应好友ID的项
        for (int i = 0; i < view.list.numItems; i++)
        {
            GObject item = view.list.GetChildAt(i);
            if (item != null)
            {
                fun_Friends.BestApplyItem uiItem = item as fun_Friends.BestApplyItem;
                if (uiItem != null)
                {
                    // 找到对应ID的好友数据
                    int dataIndex = friendListData.FindIndex(f => f.userId == friendId);
                    if (dataIndex == i)
                    {
                        // 统一设置为索引2，表示已发送申请状态
                        uiItem.txtcontroller.selectedIndex = 2;
                        // 禁用申请按钮，防止重复点击
                        uiItem.btn_newApply.touchable = false;
                        break;
                    }
                }
            }
        }
    }

    private void BuyCronyBook()
    {
        const int requiredDiamonds = 100;
        if (MyselfModel.Instance.diamond < requiredDiamonds)
        {
            UILogicUtils.ShowNotice("玉石不足，无法购买结书");
            return;
        }

        try
        {
            FriendController.Instance.ReqCronyBookItem();
            // 移除立即重置UI状态的代码，让OnCronyBookBuySuccess回调来处理UI更新
        }
        catch (System.Exception ex)
        {
            UILogicUtils.ShowNotice("购买结书失败，请重试");
            Debug.LogError("购买结书失败: " + ex.Message);
        }
    }

    private void OnCronyBookBuySuccess()
    {
        UILogicUtils.ShowNotice("购买结书成功");
        UpdateCronyBookCount();
        ShowUseBookUI();
    }

    private void UpdateCronyBookDisplay()
    {
        view.n25.text = _cronyBookCount.ToString();
        view.text_best_buyBookCount.text = _cronyBookCount.ToString();
    }
    public void CloseView()
    {
       UIManager.Instance.CloseWindow(UIName.BestFriendAddWindow);
    }
    
    /// <summary>
    /// 查找好友按钮点击事件
    /// </summary>
    private void OnLookupFriend()
    {
        string str = view.n16.text.Trim();
        if (str != "")
        {
            var findFriendDataArr = FriendModel.Instance.FindFriendDataArr(str);
            if (findFriendDataArr.Count > 0)
            {
                friendListData = findFriendDataArr;
                // 更新列表显示
                view.list.numItems = friendListData.Count;
                view.list.visible = friendListData.Count > 0;
                view.nullTip.visible = friendListData.Count <= 0;
            }
            else
            {
                UILogicUtils.ShowNotice(Lang.GetValue("friend_not_found"));
            }
        }
        else
        {
            // 输入框为空时显示所有好友
            UpdateFriendList();
        }
    }
    
    /// <summary>
    /// 输入框获得焦点
    /// </summary>
    private void OnFindTxtFocusIn()
    {
        // 假设UI中有提示文本组件，需要隐藏
        // 这里根据实际UI组件名称调整
        if (view.n17 != null)
        {
            view.n17.visible = false;
        }
    }
    
    /// <summary>
    /// 输入框失去焦点
    /// </summary>
    private void OnFindTxtFocusOut()
    {
        // 假设UI中有提示文本组件，需要在输入框为空时显示
        if (view.n17 != null)
        {
            view.n17.visible = view.n16.text == "";
        }
    }
}