
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.login;

public class StoreEarningWindow : BaseWindow
{
    private fun_StoreRevenue.StoreEarning view;
    private List<I_USER_SHOP> listData;
    private int curIndex;

    public StoreEarningWindow()
    {
        packageName = "fun_StoreRevenue";
        // 设置委托
        BindAllDelegate = fun_StoreRevenue.fun_StoreRevenueBinder.BindAll;
        CreateInstanceDelegate = fun_StoreRevenue.StoreEarning.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_StoreRevenue.StoreEarning;
        //view.title.text = Lang.GetValue("storeEarningTitle");
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        view.tipLab.text = Lang.GetValue("storeEarning_7");
        view.content.remainTimeTxt1.text = Lang.GetValue("storeEarning_3");
        view.content.grandCont.ticketCont.ticketTitle.text = Lang.GetValue("storeEarning_5");
        view.content.grandCont.opeCont.opeTitle.text = Lang.GetValue("storeEarning_6");

        StringUtil.SetBtnTab(view.empty, Lang.GetValue("storeEarningNoData"));

        view.leftBtn.onClick.Add(LeftBtn);
        view.rightBtn.onClick.Add(RightBtn);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        curIndex = 0;
        InitData();
        setData();
        BtnStatus();
    }

    private void InitData()
    {
        if (listData == null)
        {
            listData = new List<I_USER_SHOP>();
        }
        else
        {
            listData.Clear();
        }
        var arr = new List<I_USER_SHOP>();
        foreach (var timeStr in MyselfModel.Instance.userShop)
        {
            if (!TimeUtil.IsSameDayInt((int)timeStr.date))
            {
                arr.Add(timeStr);
            }
        }
        arr.Sort((a, b) => (int)b.date - (int)a.date);
        for (int i = 0; i < arr.Count; i++)
        {
            if (i < 3)
            {
                listData.Add(arr[i]);
            }
        }
    }

    private void setData()
    {
        if (listData.Count == 0)
        {
            view.status.selectedIndex = 1;
            return;
        }
        view.status.selectedIndex = 0;
        var ui = view.content.grandCont;
        var shopData = listData[curIndex];

        view.content.remainTimeTxt.text = Lang.GetValue("storeEarning_4", TimeUtil.GetYearMonthDay((int)shopData.date));

        for (int i = 0; i < 4; i++)
        {
            var ticket = ui.ticketCont._children[i] as fun_StoreRevenue.propEarningItem;
            if (i == 0)
            {
                ticket.imgIcon.url = ImageDataModel.GOLD_ICON_URL;
                ticket.numTxt.text = shopData.gold.ToString();
                ticket.nameLab.text = Lang.GetValue("gold");
            }
            else if (i == 1)
            {
                ticket.imgIcon.url = ImageDataModel.EXP_ICON_URL;
                ticket.numTxt.text = shopData.exp.ToString();
                ticket.nameLab.text = Lang.GetValue("exp");
            }
            else if (i == 2)
            {
                ticket.imgIcon.url = ImageDataModel.CASH_ICON_URL;
                ticket.numTxt.text = shopData.diamond.ToString();
                ticket.nameLab.text = Lang.GetValue("gem");
            }
            else if (i == 3)
            {
                ticket.imgIcon.url = ImageDataModel.Instance.GetIconUrlByItemId((long)BaseType.GRANDMA_TICKET);
                ticket.numTxt.text = shopData.speedPlant.ToString();
                ticket.nameLab.text = Lang.GetValue("grandmother_currency");
            }
        }

        for (int j = 0; j < 3; j++)
        {
            var ope = ui.opeCont._children[j] as fun_StoreRevenue.operateCountEarningItem;
            ope.status.selectedIndex = j;
            ope.contentTxt.text = Lang.GetValue("storeEarningOpe_" + j);
            if (j == 0)
            {
                ope.numTxt.text = shopData.harvest.ToString();
            }
            else if (j == 1)
            {
                ope.numTxt.text = shopData.sellIkebana.ToString();
            }
            else if (j == 2)
            {
                ope.numTxt.text = shopData.flowerOrder.ToString();
            }
        }

    }

    private void RightBtn()
    {
        curIndex--;
        BtnStatus();
        setData();
    }

    private void LeftBtn()
    {
        curIndex++;
        BtnStatus();
        setData();
    }
    private void BtnStatus()
    {
        if (curIndex <= 0)
        {
            view.rightBtn.enabled = false;
        }
        else
        {
            view.rightBtn.enabled = true;
        }
        if (curIndex >= listData.Count - 1)
        {
            view.leftBtn.enabled = false;
        }
        else
        {
            view.leftBtn.enabled = true;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

