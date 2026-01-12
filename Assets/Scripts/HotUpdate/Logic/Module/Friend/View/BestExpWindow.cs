using protobuf.friend;
using ADK;
using Elida.Config;
using static protobuf.friend.S_MSG_FRIEND_LIST;

public class BestExpWindow : BaseWindow
{
    private fun_Friends.BestExpView view;
    public BestExpWindow()
    {
        packageName = "fun_Friends";
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.BestExpView.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Friends.BestExpView;
        SetBg(view.bg, "Common/common_three_tip_bg.png");

        view.title1.text =Lang.GetValue("best_01");
        view.title2.text = Lang.GetValue("best_36");
        view.title3.text = Lang.GetValue("best_37");
        view.txt_desc.text = Lang.GetValue("best_38");

        // 初始化列表
        view.list.itemRenderer = ListRenderer;
        view.list.SetVirtual();
        // 设置列表数据
        view.list.data = FriendModel.Instance.cronyList;
        // 设置列表数量并刷新
        view.list.numItems = FriendModel.Instance.cronyList?.Count ?? 0;
        view.list.RefreshVirtualList();
        
        // 监听密友列表更新事件
        EventManager.Instance.AddEventListener(FriendEvent.CronyList, OnCronyListUpdate);
    }
    private void ListRenderer(int index, object item)
    {
        fun_Friends.BestExpItem ui_ = item as fun_Friends.BestExpItem;
        // 通过索引从数据列表中获取密友数据
        if (FriendModel.Instance.cronyList == null || index >= FriendModel.Instance.cronyList.Count) return;
        S_MSG_CRONY_LIST.I_CRONY_VO cronyData = FriendModel.Instance.cronyList[index];
        if (cronyData == null) return;
        I_FRIEND_PROFILE_VO friendData = FriendModel.Instance.GetFriendData(cronyData.friendId);
        if (friendData != null)
        {
            // 设置头像
            if (ui_.n22.head != null)
            {
                var headVo = ItemModel.Instance.GetItemById(int.Parse(friendData.userInfo.headImgId));
                (ui_.n22.head as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
            }
            // 设置头像框
            if (ui_.n22.picFrame != null)
            {
                var frameVo = ItemModel.Instance.GetItemById((int)friendData.userInfo.headFrame);
                UILogicUtils.ShowHeadFrames(ui_.n22.picFrame as common_New.PictureFrame, frameVo);
            }
            // 设置等级
            if (ui_.n22.txt_lv != null)
            {
                ui_.n22.txt_lv.text = friendData.userInfo.userLevel.ToString();
            }
            // 设置名称
            if (ui_.n22.txt_name != null)
            {
                ui_.n22.txt_name.text = friendData.userInfo.townName;
            }
        }
        
        //今日经验
        int curlevel = FriendModel.Instance.CalculateCronyLevel((int)cronyData.exp);
        int displayExp = FriendModel.Instance.GetDisplayExpForLevel(curlevel);
        ui_.txt_dayExp.text = cronyData.exp.ToString() + "/" + displayExp.ToString();
        //历史经验
        ui_.txt_lastExp.text = cronyData.exp.ToString();
    }

    public void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.BestExpWindow);
    }
    
    // 密友列表更新事件处理
    private void OnCronyListUpdate()
    {
        // 更新列表数据
        view.list.data = FriendModel.Instance.cronyList;
        // 更新列表数量并刷新
        view.list.numItems = FriendModel.Instance.cronyList?.Count ?? 0;
        view.list.RefreshVirtualList();
    }
}