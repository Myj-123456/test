//
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using ADK;
//using Elida.Config;

//public class BoonFlowerWindow : BaseWindow
//{
//    private fun_BoonFlower.boonNewFlowerView viewSkin;
//    private GList list;
//    private int currTabIndex = -1;
//    private List<int> listData;
//    private GButton[] tabBtnArr;
//    public BoonFlowerWindow()
//    {
//        packageName = "fun_BoonFlower";
//        // 设置委托
//        BindAllDelegate = fun_BoonFlower.fun_BoonFlowerBinder.BindAll;
//        CreateInstanceDelegate = fun_BoonFlower.boonNewFlowerView.CreateInstance;
//    }

//    public override void OnInit()
//    {
//        base.OnInit();
//        viewSkin = ui as fun_BoonFlower.boonNewFlowerView;
//        tabBtnArr = new GButton[] { viewSkin.tab1, viewSkin.tab2, viewSkin.tab3};
//        StringUtil.SetBtnTab(viewSkin.video_btn, Lang.GetValue("flower_order_05") + Lang.GetValue("market_button_3"));
//        for(int i = 0;i < tabBtnArr.Length; i++)
//        {
//            tabBtnArr[i].data = i;
//            tabBtnArr[i].onClick.Add(ClickTabBtn);
//        }
//        viewSkin.titleTxt.text = Lang.GetValue("fun_boon_1");                  //福利鲜花
//        viewSkin.congratulationsTxt.text = Lang.GetValue("boon_flower_tip");           //恭喜获得
//        StringUtil.SetBtnTab(viewSkin.tab1, Lang.GetValue("boon_flower_tab1"));
//        StringUtil.SetBtnTab(viewSkin.getBtn1, Lang.GetValue("guild_challenge_19"));
//        StringUtil.SetBtnTab(viewSkin.getBtn2, Lang.GetValue("guild_challenge_19"));
//        StringUtil.SetBtnTab(viewSkin.getBtn3, Lang.GetValue("guild_challenge_19"));
//        viewSkin.close_btn.onClick.Add(CloseView);
//        SetBg(viewSkin.bg,"BoonFlower/flxh_bg.png");
//    }

//    private void ClickTabBtn(EventContext context)
//    {
//        var cell = context.sender as GButton;
//        int index = (int)cell.data;
//        ChangeTab(index);
//    }

//    private void ChangeTab(int pageIndex)
//    {
//        if(currTabIndex == pageIndex)
//        {
//            return;
//        }
//        currTabIndex = pageIndex;
//        viewSkin.status.selectedIndex = pageIndex;
//        listData = BoonFlowerModel.Instance.GetBoonFlowerData(pageIndex);
//        ShowBtn();
//        SetItemList();
//    }

//    private void SetItemList()
//    {
//        for(int i = 0;i < 3; i++)
//        {
//            fun_BoonFlower.boonNewFlowerItem item = viewSkin.GetChild("item" + (i + 1)) as fun_BoonFlower.boonNewFlowerItem;
//            int seedId = listData[i];
//            Module_item_defConfig itemData = ItemModel.Instance.GetItemById(seedId);
//            if(itemData != null)
//            {
//                item.nameTxt.text = Lang.GetValue(itemData.Name);
//                item.flowerImg.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemData);
//            }
//            item.states.selectedIndex = 0;
//        }
//    }

//    private void InitTab()
//    {
//        for(int i = 0;i < 3; i++)
//        {
//            fun_BoonFlower.tabBtn btn = tabBtnArr[i] as fun_BoonFlower.tabBtn;
//            btn.touchable = true;
//            btn.status.selectedIndex = 0;
//            StringUtil.SetBtnTab(tabBtnArr[i], Lang.GetValue("boon_flower_tab" + (i + 1)));
//        }
//    }

//    private void ShowBtn()
//    {
//        int times = GlobalModel.Instance.module_profileConfig.FuliFlowerTime[this.currTabIndex];
//        viewSkin.getBtn1.visible = viewSkin.getBtn2.visible = viewSkin.getBtn3.visible = (BoonFlowerModel.Instance.adCnt >= times && BoonFlowerModel.Instance.fuliDrawState.IndexOf(this.currTabIndex + 1) == -1);
//        viewSkin.decLab.text = Lang.GetValue("boon_flower_dec", times.ToString());
//        viewSkin.adTimes.text = Lang.GetValue("boon_flower_ad_times", "<font color='#69c336'>" + BoonFlowerModel.Instance.adCnt + "</font>/" + times);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();

//        // 其他打开面板的逻辑
//        int pageIndex = 0;
//        if (data != null)
//        {

//        }
//        else
//        {
//            pageIndex = currTabIndex >= 0 ? currTabIndex : 0;
//        }
//        ChangeTab(pageIndex);
//        InitTab();
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
       
//    }

//    public void CloseView()
//    {
//        UIManager.Instance.CloseWindow(UIName.BoonFlowerWindow);
//    }


//    public void GetFlower(int index)
//    {
        
//    }
//}

