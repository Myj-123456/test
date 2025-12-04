
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.plant;
using System.Linq;

public class MailInfoWindow : BaseWindow
{
    private fun_Email.MailInfoView viewSkin;
    private KeyValuePair<ulong, uint>[] itemData;
    private I_MAIL_VO mailData;
    private int index;

    public MailInfoWindow()
    {
        packageName = "fun_Email";
        // 设置委托
        BindAllDelegate = fun_Email.fun_EmailBinder.BindAll;
        CreateInstanceDelegate = fun_Email.MailInfoView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        viewSkin = ui as fun_Email.MailInfoView;
        StringUtil.SetBtnTab(viewSkin.btn_sure, Lang.GetValue("gui_btn_confirm"));
        //viewSkin.title.text = Lang.GetValue("mail_08");
        viewSkin.list.itemRenderer = OnItemRender;
        EventManager.Instance.AddEventListener(MailEvent.MailReward,UpdateData);
    }

    private void OnItemRender(int index,GObject item)
    {
        fun_Email.MailRewardItem cell = item as fun_Email.MailRewardItem;
        KeyValuePair<ulong, uint> data = itemData[index];
        cell.img.url = ImageDataModel.Instance.GetIconUrlByEntityId(data.Key);
        cell.count.text = data.Value.ToString();
        cell.img.grayed = mailData.status != 0;

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        object[] param = data as object[];
        mailData = param[0] as I_MAIL_VO;
        index = (int)param[1];
        //viewSkin.title.text = mailData.title1;//邮件的文字直接用中文，不走语言表 
        viewSkin.title2.text = mailData.title2;//邮件的文字直接用中文，不走语言表 
        string str = "   " + mailData.title3;//邮件的文字直接用中文，不走语言表 
        viewSkin.mailCountCom.descLab.text = str;
        itemData = mailData.reward.ToArray();
        UpdateData();
    }

    private void UpdateData()
    {
        bool hasReward = itemData.Length != 0;
        viewSkin.btn_sure.enabled = true;
        if (hasReward)
        {
            viewSkin.type.selectedIndex = 1;
            if (mailData.status == 0)
            {
                StringUtil.SetBtnTab(viewSkin.btn_sure, Lang.GetValue("invite_friends_10"));
                //viewSkin.has_reward.visible = false;
            }
            else
            {
                StringUtil.SetBtnTab(viewSkin.btn_sure, Lang.GetValue("mail_button_confirm"));
                //viewSkin.has_reward.visible = true;
            }
            viewSkin.list.numItems = itemData.Length;
            if (viewSkin.list.numItems > 3)
            {
                viewSkin.list.touchable = true;
            }
            else
            {
                viewSkin.list.touchable = false;
            }
        }
        else
        {
            //viewSkin.has_reward.visible = false;
            viewSkin.type.selectedIndex = 0;
            StringUtil.SetBtnTab(viewSkin.btn_sure, Lang.GetValue("mail_button_confirm"));
        }
    }

    private void OnSureClick()
    {
        if(itemData.Length == 0)
        {
            CloseView();
        }
        else
        {
            if(mailData.status == 1)
            {
                CloseView();
                return;
            }
            viewSkin.btn_sure.enabled = false;
            MailController.Instance.ReqMailReward(new List<string>{ mailData.mailId });
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.MailInfoWindow);
    }
}

