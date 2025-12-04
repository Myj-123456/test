using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.common;
using ADK;

public class FriendBlackWindow : BaseWindow
{
   private fun_Friends.newFriendBlackView view;
    private List<I_USER_PROFILE> blackListData;

    public FriendBlackWindow()
    {
        packageName = "fun_Friends";
        // 设置委托
        BindAllDelegate = fun_Friends.fun_FriendsBinder.BindAll;
        CreateInstanceDelegate = fun_Friends.newFriendBlackView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Friends.newFriendBlackView;
        view.titleLab.text = Lang.GetValue("Friend_36");
        view.titleLab1.text = Lang.GetValue("Friend_36");
        StringUtil.SetBtnTab(view.nullTip, Lang.GetValue("storeEarningNoData"));

        SetBg(view.bg,"Common/ELIDA_common_bigdi01.png");
        view.list.itemRenderer = ItemRenderer;
        view.list.SetVirtual();

        view.close_btn.onClick.Add(CloseView);
        EventManager.Instance.AddEventListener(FriendEvent.FriendBlackList, UpdateBlackList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        FriendController.Instance.ReqFriendBlackList();
    }

    private void UpdateBlackList()
    {
        blackListData = FriendModel.Instance.blackList;
        view.status.selectedIndex = blackListData.Count > 0 ? 1 : 0;
        view.list.numItems = blackListData.Count;
    }

    private void ItemRenderer(int index,GObject cell)
    {
        fun_Friends.blackListItem item = cell as fun_Friends.blackListItem;
        var vo_ = blackListData[index];
        item.data = vo_;

        StringUtil.SetBtnTab(item.btn_remove, Lang.GetValue("cp_desc_16"));//解除
        item.idTxt.text = "ID:" + vo_.userId;
        StringUtil.SetBtnUrl(item.heead, "Avatar/ELIDA_common_touxiangdi01.png");
        item.txt_lv.text = vo_.userLevel.ToString();
        //item.head_img.url = "Avatar/ELIDA_common_touxiangdi01.png";
        item.txt_name.text = vo_.townName;
        
        //item.friend_vip_icon.visible = false;
        item.btn_remove.onClick.Add(ClickRemoveBtnHandler);
    }

    private void ClickRemoveBtnHandler(EventContext context)
    {
        var data = (context.sender as GComponent).parent.data as I_USER_PROFILE;
        FriendController.Instance.ReqFriendBlackDel(data.userId );
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.FriendBlackWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

