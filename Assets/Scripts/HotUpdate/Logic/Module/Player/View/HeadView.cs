using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class HeadView
{
   private fun_MyInfo.head_view view;
    private Ft_player_iconConfig curData;
    private int curIndex;
   public HeadView(fun_MyInfo.head_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.wear_btn, Lang.GetValue("Headframe_button"));
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("guide_button1"));
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
        view.goto_btn.onClick.Add(OnGo);
        view.wear_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqSetHead((uint)curData.IconId);
        });
        EventManager.Instance.AddEventListener(PlayerEvent.SetHead, UpdateData);
    }


    public void OnShown()
    {
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var frame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var itemVo = ItemModel.Instance.GetItemById(int.Parse(frame.info));
        UILogicUtils.ShowHeadFrames(view.ftame as common_New.PictureFrame, itemVo);
        curData = PlayerModel.Instance.GetHeadInfo1(int.Parse(head.info));
        curIndex = GetHeadIndex(int.Parse(head.info));
        UpdateList();
        UpdateInfo();
        view.list.selectedIndex = curIndex;
    }
    private void UpdateData()
    {
        UpdateList();
        UpdateInfo();
    }
    private void UpdateList()
    {
        view.list.numItems = PlayerModel.Instance.headList.Count;
    }
    private void UpdateInfo()
    {
        var itemVo = ItemModel.Instance.GetItemById(curData.IconId);
        var actionIds = itemVo.ActionIds;
        var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(actionIds[0]);
        if (ft_jumpConfig != null)
        {
            view.tipLab.text = Lang.GetValue(ft_jumpConfig.JumpName);
        }
        view.head_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.goto_btn.data = ft_jumpConfig;
        view.status.selectedIndex = (StorageModel.Instance.GetItemCount(curData.IconId) > 0 || curData.IsOwn == 1)  ? 0 : 1;
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        view.wear_btn.enabled = int.Parse(head.info) != curData.IconId;
    }
    public void RenderList(int index,GObject item)
    {
        var cell = item as fun_MyInfo.head_item;
        var info = PlayerModel.Instance.headList[index];
        var itemVo = ItemModel.Instance.GetItemById(info.IconId);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.unlock.selectedIndex = (StorageModel.Instance.GetItemCount(info.IconId) > 0 || info.IsOwn == 1) ? 0 : 1;
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        cell.type.selectedIndex = int.Parse(head.info) != info.IconId ? 0 : 1;
        cell.data = index;
        cell.onClick.Add(SelectHead);
    }
    private void SelectHead(EventContext context)
    {
        int index = (int)(context.sender as GComponent).data;
        if(curIndex != index)
        {
            curIndex = index;
            curData = PlayerModel.Instance.headList[index];
            UpdateInfo();
        }
    }
    private int GetHeadIndex(int headId)
    {
        for(var i = 0;i < PlayerModel.Instance.headList.Count; i++)
        {
            if(PlayerModel.Instance.headList[i].IconId == headId)
            {
                return i;
            }
        }
        return -1;
    }
    private void OnGo(EventContext context)
    {
        var data = (context.sender as GComponent).data as Ft_jumpConfig;
        UIManager.Instance.CloseAllWindown();
        if (data.JumpType == 1)
        {
            UIManager.Instance.OpenPanelByName(data.JumpParam);
        }
    }
    public void OnHide()
    {
       
    }
}

