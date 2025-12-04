using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class TitleView
{
   private fun_MyInfo.title_view view;
    private List<FrameTitleConfig> listData;
    private FrameTitleConfig curData;
    private int curIndex;

    public TitleView(fun_MyInfo.title_view ui)
    {
        view = ui;
        StringUtil.SetBtnTab(view.wear_btn, Lang.GetValue("Headframe_button"));
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("guide_button1"));
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();


        listData = PlayerModel.Instance.GetFrameTileList(4202);
        view.goto_btn.onClick.Add(OnGo);
        view.wear_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqSetTitle((uint)curData.Id);
        });
        view.remove_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqSetTitle(0);
        });
        EventManager.Instance.AddEventListener(PlayerEvent.SetTitle, UpdateData);
    }

    public void OnShown()
    {
        var title = MyselfModel.Instance.GetUserInfo(UserInfoType.TITLE);
        if(title == null)
        {
            curIndex = 0;
        }
        else
        {
            curIndex = GetIndex(int.Parse(title.info));
        }
        UpdateInfo();
        UpdateList();
        view.list.selectedIndex = curIndex;
    }
    private void UpdateData()
    {
        UpdateInfo();
        UpdateList();
    }
    private void UpdateList()
    {
        view.list.numItems = listData.Count;
    }
    private void UpdateInfo()
    {
        curData = listData[curIndex];
        var itemVo = ItemModel.Instance.GetItemById(curData.Id);
        var actionIds = itemVo.ActionIds;
        var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(actionIds[0]);
        if (ft_jumpConfig != null)
        {
            view.tipLab.text = Lang.GetValue(ft_jumpConfig.JumpName);
        }
        view.goto_btn.data = ft_jumpConfig;
        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        var title = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        if(title != null && int.Parse(title.info) == curData.Id)
        {
            view.status.selectedIndex = 1;
        }
        else
        {
            view.status.selectedIndex = StorageModel.Instance.GetItemCount(curData.Id) > 0 ? 0 : 2;
        }
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_MyInfo.title_item;
        var info = listData[index];
        var title = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var itemVo = ItemModel.Instance.GetItemById(info.Id);
        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.nameLab.text = Lang.GetValue(itemVo.Name);
        cell.timeLab.text = "";
        cell.type.selectedIndex = title != null && int.Parse(title.info) == info.Id?1:0;
       
        cell.unlock.selectedIndex = StorageModel.Instance.GetItemCount(curData.Id) > 0 ? 0 : 1;
        cell.data = index;
        cell.onClick.Add(SelectHead);
    }
    private void SelectHead(EventContext context)
    {
        int index = (int)(context.sender as GComponent).data;
        if (curIndex != index)
        {
            curIndex = index;
            UpdateInfo();
        }
    }
    private int GetIndex(int id)
    {
        for (var i = 0; i < listData.Count; i++)
        {
            if (listData[i].Id == id)
            {
                return i;
            }
        }
        return 0;
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

