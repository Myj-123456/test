using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.common;

public class GameNoticeWindow : BaseWindow
{
    private fun_Notice.GameNotice viewSkin;

    private int curPage = 0;

    

    public GameNoticeWindow()
    {
        packageName = "fun_Notice";
        // 设置委托
        BindAllDelegate = fun_Notice.fun_NoticeBinder.BindAll;
        CreateInstanceDelegate = fun_Notice.GameNotice.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Notice.GameNotice;
        viewSkin.pageList.itemRenderer = PageRenderer;
        //viewSkin.status.selectedIndex = 1;
        viewSkin.close_btn.onClick.Add(CloseView);
        viewSkin.rightBtn.onClick.Add(RightClick);
        viewSkin.leftBtn.onClick.Add(LeftClick);
    }

    private void PageRenderer(int index,GObject item)
    {
        fun_Notice.UpdateContent ui = item as fun_Notice.UpdateContent;
        I_NOTICE_VO dat = GameNoticeModel.Instance.GetNoticeData(curPage);
        viewSkin.titleLab.text = dat.title;
        ui.list.itemRenderer = DrawEachRow;
        ui.list.numItems = 1;
    }

    private void DrawEachRow(int index,GObject item)
    {
        fun_Notice.GameNoticeListItem ui = item as fun_Notice.GameNoticeListItem;
        I_NOTICE_VO dat = GameNoticeModel.Instance.GetNoticeData(curPage);
        ui.lb_content.text = dat.content;
    }

    public override void OnShown()
    {
        base.OnShown();
        curPage = 0;
        viewSkin.have.selectedIndex = (GameNoticeModel.Instance.noticeData != null && GameNoticeModel.Instance.noticeData.Count > 0) ? 1 : 0;
        viewSkin.pageList.numItems = (GameNoticeModel.Instance.noticeData  != null && GameNoticeModel.Instance.noticeData.Count > 0)? 1:0;
        UpdateBtnStatus();
        // 其他打开面板的逻辑
    }

    private void LeftClick()
    {
        if(curPage >= GameNoticeModel.Instance.noticeData.Count - 1)
        {
            return;
        }
        curPage ++;
        viewSkin.pageList.numItems = 1;
        UpdateBtnStatus();
    }

    private void RightClick()
    {
        if(curPage == 0)
        {
            return;
        }
        curPage--;
        viewSkin.pageList.numItems = 1;
        UpdateBtnStatus();
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.GameNoticeWindow);
    }



    private void UpdateBtnStatus()
    {
        if(curPage == 0)
        {
            viewSkin.rightBtn.enabled = false;
        }
        else
        {
            viewSkin.rightBtn.enabled = true;
        }

        if(curPage >= (GameNoticeModel.Instance.noticeData.Count - 1))
        {
            viewSkin.leftBtn.enabled = false;
        }
        else
        {
            viewSkin.leftBtn.enabled = true;
        }
        viewSkin.pageTxt.text = (GameNoticeModel.Instance.noticeData.Count - curPage).ToString() + "/" + GameNoticeModel.Instance.noticeData.Count.ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

