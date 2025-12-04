
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using UnityTimer;
using System.Linq;
using protobuf.plant;

public class MailWindow : BaseWindow
{
    private fun_Email.MailView viewSkin;

    public MailWindow()
    {
        packageName = "fun_Email";
        // 设置委托
        BindAllDelegate = fun_Email.fun_EmailBinder.BindAll;
        CreateInstanceDelegate = fun_Email.MailView.CreateInstance;
        FullScreen = true;
    }



    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Email.MailView;
        StringUtil.SetBtnTab(viewSkin.btn_delete, Lang.GetValue("slang_38"));//快速删除
        StringUtil.SetBtnTab(viewSkin.btn_read, Lang.GetValue("slang_39"));//快速阅读

        viewSkin.title.text = Lang.GetValue("message_button_mail");
        StringUtil.SetBtnTab(viewSkin.no_item, Lang.GetValue("mail_14"));
        SetBg(viewSkin.bg, "Common/ELIDA_youxiang_bg.png");

        viewSkin.list.height = viewSkin.btn_delete.y - viewSkin.close_btn.y - 252;
        viewSkin.list.itemRenderer = OnItemRender;
        viewSkin.close_btn.onClick.Add(CloseView);

        viewSkin.btn_delete.onClick.Add(QuickDelete);
        viewSkin.btn_read.onClick.Add(QuickRead);

        EventManager.Instance.AddEventListener(MailEvent.MailListInfo, UpdateList);
        EventManager.Instance.AddEventListener(MailEvent.MailReward, UpdateList);
        EventManager.Instance.AddEventListener(MailEvent.MailDel, UpdateList);
    }

    private void OnItemRender(int index, GObject item)
    {
        fun_Email.MailItem cell = item as fun_Email.MailItem;
        var obj = MailModel.Instance.mailData[index];
        cell.delete_info.text = Lang.GetValue("slang_82");//15天后自动删除
        StringUtil.SetBtnTab(cell.readBtn, Lang.GetValue("mail_16"));
        StringUtil.SetBtnTab(cell.readEndBtn, "已阅读");

        if (obj != null)
        {
            cell.data = obj;
            uint temp = obj.status;
            cell.status.selectedIndex = (int)temp;
            cell.title1.text = obj.title1;
            cell.title2.text = obj.title1;
            cell.read.text = temp == 0 ? TimeUtil.GenerateTimeDesc((int)obj.createTime) : "";
            UpdateListData(obj, cell.content);

        }
        //if (!cell.onClick.isEmpty)
        //{
        //    cell.onClick.Remove(OnItemClick);
        //}
        cell.onClick.Add(OnItemClick);
    }
    private void UpdateListData(I_MAIL_VO mailData, fun_Email.MailInfoView cell)
    {
        var itemData = mailData.reward == null?null: mailData.reward.ToArray();
        bool hasReward = itemData == null?false: itemData.Length != 0;

        cell.title2.text = mailData.title2;//邮件的文字直接用中文，不走语言表 
        string str = Lang.GetValue1(mailData.title3,mailData.@params);//邮件的文字直接用中文，不走语言表 
        cell.mailCountCom.descLab.text = str;
        if (hasReward)
        {
            cell.type.selectedIndex = 1;
            cell.btn_sure.data = mailData.mailId;
            if (mailData.status == 0)
            {
                StringUtil.SetBtnTab(cell.btn_sure, Lang.GetValue("mail_button_confirm"));
                cell.btn_sure.enabled = true;
                //viewSkin.has_reward.visible = false;
            }
            else
            {
                cell.btn_sure.enabled = false;
                StringUtil.SetBtnTab(cell.btn_sure, Lang.GetValue("text_activity_3"));
                //viewSkin.has_reward.visible = true;
            }
            cell.list.itemRenderer = (int index, GObject item) =>
            {
                fun_Email.MailRewardItem cell = item as fun_Email.MailRewardItem;
                KeyValuePair<ulong, uint> data = itemData[index];
                cell.img.url = ImageDataModel.Instance.GetIconUrlByEntityId((long)data.Key);
                cell.count.text = data.Value.ToString();
                cell.img.grayed = mailData.status != 0;
                cell.bg.url = "MyInfo/show_flower_bg3.png";
            };
            cell.list.numItems = itemData.Length;
            //if (viewSkin.list.numItems > 3)
            //{
            //    viewSkin.list.touchable = true;
            //}
            //else
            //{
            //    viewSkin.list.touchable = false;
            //}
        }
        else
        {
            //viewSkin.has_reward.visible = false;
            cell.type.selectedIndex = 0;
            StringUtil.SetBtnTab(cell.btn_sure, Lang.GetValue("common_claim_button"));
        }
        cell.btn_sure.onClick.Add(OnSureClick);
    }

    private void OnSureClick(EventContext context)
    {
        context.StopPropagation();
        string id = (context.sender as GComponent).data.ToString();
        MailController.Instance.ReqMailReward(new List<string>{ id });

    }

    private void OnItemClick(EventContext context)
    {
        var item = context.sender as fun_Email.MailItem;
        var obj = item.data as I_MAIL_VO;
        if (obj != null)
        {
            var itemData = obj.reward.ToArray();
            if (itemData.Length == 0 && obj.status == 0)
            {
                MailController.Instance.ReqMailReward(new List<string>{ obj.mailId });
            }
            if (item.showStatus.selectedIndex == 0)
            {
                item.showStatus.selectedIndex = 1;
                item.show.Play();
            }
            else
            {
                item.showStatus.selectedIndex = 0;
                item.hide.Play();
            }
            //UIManager.Instance.OpenWindow<MailInfoWindow>(UIName.MailInfoWindow, obj);
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //viewSkin.no_item.visible = MailModel.Instance.mailCount == 0;
        viewSkin.no_item.visible = false;
        //viewSkin.list.numItems = 4;
        //Timer time = Timer.Regist(60f);
        MailController.Instance.ReqMailListInfo();

    }

    private void UpdateList()
    {
        viewSkin.no_item.visible = MailModel.Instance.mailData.Count == 0;
        viewSkin.list.numItems = MailModel.Instance.mailData.Count;
    }


    public void QuickDelete()
    {
        List<string> ids = new List<string>();
        foreach (var mail in MailModel.Instance.mailData)
        {
            if (mail.status == 1)
            {
                ids.Add(mail.mailId);
            }
        }

        if (ids.Count > 0)
        {
            UILogicUtils.ShowConfirm(Lang.GetValue("slang_134"), () =>
            {
                MailController.Instance.ReqMailDel(ids);
            });
        }
        else
        {
            UILogicUtils.ShowNotice("没有可删除的邮件");
        }
    }

    private void QuickRead()
    {
        List<string> ids = new List<string>();
        foreach (var mail in MailModel.Instance.mailData)
        {
            if (mail.status == 0)
            {
                ids.Add(mail.mailId);
            }
        }
        if (ids.Count > 0)
        {
            MailController.Instance.ReqMailReward(ids);
        }
        else
        {
            UILogicUtils.ShowNotice("邮件全部已读");
        }

    }



    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.MailWindow);
    }
}

