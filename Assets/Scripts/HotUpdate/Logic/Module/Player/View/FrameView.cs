using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class FrameView
{
   private fun_MyInfo.frame_view view;
    private List<FrameTitleConfig> listData;
    private FrameTitleConfig curData;
    private int curIndex;
   public FrameView(fun_MyInfo.frame_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.wear_btn, Lang.GetValue("Headframe_button"));
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("guide_button1"));
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        listData = PlayerModel.Instance.GetFrameTileList(4201);
        view.goto_btn.onClick.Add(OnGo);
        view.wear_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqSetAvatarFrame((uint)curData.Id);
        });
        EventManager.Instance.AddEventListener(PlayerEvent.SetAvatarFrame, UpdateData);
    }


    public void OnShown()
    {
        var frame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var itemVo = ItemModel.Instance.GetItemById(int.Parse(head.info));
        view.head_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        curData = PlayerModel.Instance.GetFrameTitleInfo(int.Parse(frame.info));
        curIndex = GetIndex(int.Parse(frame.info));
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
        view.list.numItems = listData.Count;
    }
    private void UpdateInfo()
    {
        var itemVo = ItemModel.Instance.GetItemById(curData.Id);
        var actionIds = itemVo.ActionIds;
        var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(actionIds[0]);
        if (ft_jumpConfig != null)
        {
            view.tipLab.text = Lang.GetValue(ft_jumpConfig.JumpName);
        }
        
        UILogicUtils.ShowHeadFrames(view.ftame as common_New.PictureFrame, itemVo);
        view.goto_btn.data = ft_jumpConfig;
        view.unlock.selectedIndex = StorageModel.Instance.GetItemCount(curData.Id) > 0 ? 0 : 1;
        var frame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        view.wear_btn.enabled = int.Parse(frame.info) != curData.Id;
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_MyInfo.frame_item;
        var info = listData[index];
        var itemVo = ItemModel.Instance.GetItemById(info.Id);
        UILogicUtils.ShowHeadFrames(cell.frame as common_New.PictureFrame,itemVo);
        var frame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        cell.type.selectedIndex = int.Parse(frame.info) != info.Id?0:1;
        cell.unlock.selectedIndex = StorageModel.Instance.GetItemCount(info.Id) > 0 ? 0 : 1;

        cell.data = index;
        cell.onClick.Add(SelectHead);
    }
    private void SelectHead(EventContext context)
    {
        int index = (int)(context.sender as GComponent).data;
        if (curIndex != index)
        {
            curIndex = index;
            curData = listData[index];
            UpdateInfo();
        }
    }
    private int GetIndex(int id)
    {
        for(var i = 0;i < listData.Count; i++)
        {
            if(listData[i].Id == id)
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

