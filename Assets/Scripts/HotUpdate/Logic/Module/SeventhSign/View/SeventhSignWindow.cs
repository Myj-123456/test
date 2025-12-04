
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using ADK;

public class SeventhSignWindow : BaseWindow
{
    private fun_SignInSevenDays.SeventhSign viewSkin;
    /**第七天奖励数量 */
    private int servenDayNum;
    public SeventhSignWindow()
    {
        packageName = "fun_SignInSevenDays";
        // 设置委托
        BindAllDelegate = fun_SignInSevenDays.fun_SignInSevenDaysBinder.BindAll;
        CreateInstanceDelegate = fun_SignInSevenDays.SeventhSign.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_SignInSevenDays.SeventhSign;
        SetBg(viewSkin.bg, "SeventhSign/ELIDA_denglujiangli_BG.png");
        SeventhSignModel.Instance.isOpenView = false;
        servenDayNum = SeventhSignModel.Instance.seventhSignLsitData[6].Awards.Length;
        UpdateData();
        GList list1 = viewSkin.item6.list;
        list1.itemRenderer = OnList10ItemRender;
        list1.numItems = servenDayNum;

        viewSkin.item6.title.text = Lang.GetValue("activity_days", "7");
        viewSkin.item6.gettedLab.text = Lang.GetValue("text_activity_3");//已领取
        viewSkin.item6.getLab.text = Lang.GetValue("common_claim_button");
        //StringUtil.SetBtnTab(viewSkin.item6.getBtn, Lang.GetValue("common_claim_button"));
        viewSkin.desc_txt.text = Lang.GetValue("seventh_sign_1");//每日登入就可以领取奖励哦！
        viewSkin.desc_txt1.text = Lang.GetValue("seventh_sign_2");
        //StringUtil.SetBtnTab(viewSkin.btn_reward, Lang.GetValue("common_claim_button"));

        SetGroupGrayed(SeventhSignModel.Instance.signDay == 7);
        //viewSkin.btn_reward.enabled = !SeventhSignModel.Instance.todayHaveDraw;
        int todayIndex = SeventhSignModel.Instance.signDay;
        //if (SeventhSignModel.Instance.CheckTodayIsSign()) todayIndex = SeventhSignModel.Instance.signDay - 1;

        //AnimationHelper.CreateSpine("rabbit", viewSkin.spine.displayObject.gameObject.transform, "animation", true);
        viewSkin.anim.loop = true;
        viewSkin.anim.url = "rabbit";
        viewSkin.anim.animationName = "animation";

        EventManager.Instance.AddEventListener(SeventhSignEvent.DailyLoginAward, UpdateData);
    }



    private void UpdateData()
    {
        for (int i = 0; i < 6; i++)
        {
            var item = viewSkin.GetChild("item" + i) as fun_SignInSevenDays.SeventhSign_Item;
            OnList0ItemRender(i, item);
        }
        if (SeventhSignModel.Instance.signDay == 7)
        {
            if (SeventhSignModel.Instance.todayHaveDraw)
            {
                viewSkin.item6.isLock.selectedIndex = 1;
            }
            else
            {
                viewSkin.item6.isLock.selectedIndex = 0;
            }


        }
        else
        {
            viewSkin.item6.isLock.selectedIndex = 2;
        }
        viewSkin.item6.onClick.Add(OnRewardClick1);


    }


    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        viewSkin.animation.Play();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void OnList0ItemRender(int index, fun_SignInSevenDays.SeventhSign_Item cell)
    {
        List<AwardObject> info = new List<AwardObject>(SeventhSignModel.Instance.seventhSignLsitData[index].Awards);


        cell.reward.img_reward.url = ImageDataModel.Instance.GetIconUrlByEntityId(info[0].EntityID);
        cell.title.text = Lang.GetValue("activity_days", (index + 1).ToString());
        //StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("common_claim_button"));
        cell.getLab.text = Lang.GetValue("common_claim_button");
        cell.reward.num.text = "X" + info[0].Value;
        int todayIndex = SeventhSignModel.Instance.signDay;
        //if (SeventhSignModel.Instance.CheckTodayIsSign()) todayIndex = SeventhSignModel.Instance.signDay - 1;
        if ((index + 1) == todayIndex)
        {
            if (SeventhSignModel.Instance.todayHaveDraw)
            {
                cell.gettedLab.text = Lang.GetValue("text_activity_3");//已领取
                cell.isLock.selectedIndex = 1;
            }
            else
            {
                //cell.title.text = Lang.GetValue("slang_33");//今天
                cell.isLock.selectedIndex = 0;
            }
        }
        else
        {
            if (SeventhSignModel.Instance.signDay > (index + 1))
            {
                cell.gettedLab.text = Lang.GetValue("text_activity_3");//已领取
                cell.isLock.selectedIndex = 1;
            }
            else
            {

                cell.isLock.selectedIndex = 2;
            }
        }
        cell.onClick.Add(OnRewardClick);


    }

    private void OnList10ItemRender(int index, GObject item)
    {
        List<AwardObject> info = new List<AwardObject>(SeventhSignModel.Instance.seventhSignLsitData[6].Awards);
        fun_SignInSevenDays.SeventhSign_Item1 cell = item as fun_SignInSevenDays.SeventhSign_Item1;
        cell.img_reward.url = ImageDataModel.Instance.GetIconUrlByEntityId(info[index].EntityID);
        cell.num.text = "X" + info[index].Value;

    }

    private void OnRewardClick(EventContext context)
    {
        var item = context.sender as fun_SignInSevenDays.SeventhSign_Item;
        if (item.isLock.selectedIndex != 0)
        {
            return;
        }
        SeventhSignController.Instance.ReqDailyLoginAward();
    }

    private void OnRewardClick1(EventContext context)
    {
        var item = context.sender as fun_SignInSevenDays.SeventhSign_Item2;
        if (item.isLock.selectedIndex != 0)
        {
            return;
        }
        SeventhSignController.Instance.ReqDailyLoginAward();
    }

    private void SetGroupGrayed(bool b)
    {
        if (!b)
        {
            viewSkin.isLock.selectedIndex = 0;
        }
        else
        {
            viewSkin.isLock.selectedIndex = SeventhSignModel.Instance.todayHaveDraw ? 1 : 0;
        }

    }

    public void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.SeventhSignWindow);
    }
}

