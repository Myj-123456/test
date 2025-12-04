using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using common_New;
using ADK;
using Elida.Config;

public class FlowerSellWindow : BaseView
{
    private fun_SellingFlowers.flowerSellNew _view;
    private List<StorageItemVO> dataList;

    private int curPage = 0;
    private int maxPage;
    private StorageItemVO curItem;
    //private StaticFlowerSell curSellCfg;
    private int currSelectCount;
    private int maxCount;
    private float spotMaxPage;
    private float orginY;


    public FlowerSellWindow()
    {
        packageName = "fun_SellingFlowers";
        // 设置委托
        BindAllDelegate = fun_SellingFlowers.fun_SellingFlowersBinder.BindAll;
        CreateInstanceDelegate = fun_SellingFlowers.flowerSellNew.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_SellingFlowers.flowerSellNew;
        orginY = _view.n300.y;
        //_view.bg.url = "Common/ELIDA_common_chushoudd_tcdi.png";

        StringUtil.SetBtnTab(_view.done_btn, Lang.GetValue("slang_31"));
        StringUtil.SetBtnTab(_view.oneKey_done_btn, Lang.GetValue("flowersell_1"));
        //StringUtil.SetBtnTab(_view.btn_max, Lang.GetValue("FriendsDeal_16"));
        _view.txt_price.text = Lang.GetValue("flower_sell_1");
        _view.txt_time.text = Lang.GetValue("flower_sell_2");
        //_view.noFlowerTips.text = Lang.GetValue("slang_30");

        _view.list.itemRenderer = FlowerItemRenderer;
        _view.list.SetVirtual();

        _view.list.scrollPane.onScroll.Add(UpdatePage);

        _view.list.onClickItem.Add(SelectFlowerSell);

        _view.page_list.itemRenderer = PageNumItemRenderer;
        _view.page_list.onClickItem.Add(ChangePage);

        //_view.close_btn.onClick.Add(CloseView);
        _view.right_btn.onClick.Add(RightBtn);
        _view.left_btn.onClick.Add(LeftBtn);

        _view.minus_btn.onClick.Add(OddBtn);
        _view.plus_btn.onClick.Add(AddBtn);
        _view.btn_max.onClick.Add(MaxBtn);
        _view.done_btn.onClick.Add(OnSell);
        _view.oneKey_done_btn.onClick.Add(OnOnekeySell);
        _view.hitArea.onClick.Add(CloseView);
        _view.txt_noFlower.onClickLink.Add(OnClickLink);
        AddEventListener(VideoEvent.videoDoubleEnd, UpdateButton);
    }

    private void OnClickLink(EventContext context)
    {
        if (context.data.ToString() == "arrangeFlowers")
        {
            HideView(() =>
            {
                UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView);
            });
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        _view.n300.y = GRoot.inst.height;
        _view.n300.TweenMoveY(orginY, 0.3f);
        // 其他打开面板的逻辑
        _view.vipStatus.selectedIndex = MyselfModel.Instance.IsVip() ? 1 : 0;
        dataList = StorageModel.Instance.GetStorageListByTypes(new int[] { 4501 });
        dataList.Sort((a, b) => b.count - a.count);
        maxPage = (int)Math.Ceiling((double)dataList.Count / 5);
        spotMaxPage = Mathf.Floor(maxPage + 1 / 15);
        _view.state.selectedIndex = 1;
        _view.done_btn.enabled = false;
        curPage = 0;
        //UIExt_ikeImg.ClearView(_view.preview_loader as common_New.ikeImg);
        //initView();
        _view.page_list.numItems = maxPage;
        UpdateList();
        SpotCurrent();
        StartCoroutine(ShowTargetWeakGuide());
    }

    /// <summary>
    /// 检测弱引导
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowTargetWeakGuide()
    {
        if (GuideModel.Instance.IsCancelGuide) yield break;
        yield return new WaitForSeconds(0.3f);
        if (_view.list.numItems <= 0) yield break;
        var taskData = TaskModel.Instance.mainTask;
        if (taskData != null)
        {
            var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
            if (taskInfo != null && taskInfo.TaskType == 23)//花台出售XXX插花作品n个
            {
                //var flowerId = 45010002;
                var flowerId = taskInfo.TypeParam;
                if (flowerId <= 0)//不存在
                {
                    GuideController.Instance.ShowTargetWeakGuide(_view.list.GetChildAt(0), Vector2.zero);
                    yield break;
                }
                var list_flowerInd = flowerId <= 0 ? 0 : dataList.FindIndex(0, (v => { return v.itemDefId == flowerId; }));
                if (list_flowerInd >= 0)
                {
                    _view.list.ScrollToView(list_flowerInd);
                    int index = _view.list.ItemIndexToChildIndex(list_flowerInd);
                    var target = _view.list.GetChildAt(index);
                    GuideController.Instance.ShowTargetWeakGuide(target, Vector2.zero);
                }
            }
        }
    }

    private void UpdateList()
    {
        _view.list.numItems = dataList.Count;
        _view.txt_noFlower.visible = dataList.Count <= 0;
    }
    private void LeftBtn()
    {
        EventManager.Instance.DispatchEvent(FloweSellEvent.SwitchFlowerStand, -1);
    }

    private void RightBtn()
    {
        EventManager.Instance.DispatchEvent(FloweSellEvent.SwitchFlowerStand, 1);
    }

    private void FlowerItemRenderer(int index, GObject item)
    {
        fun_SellingFlowers.storage_item_cellNew ui = item as fun_SellingFlowers.storage_item_cellNew;
        var storageVO = dataList[(curPage * 3) + index];
        ui.data = (curPage * 3) + index;
        ui.count_txt.text = storageVO.count.ToString();
        ui.status.selectedIndex = curItem != null && curItem.itemDefId == storageVO.itemDefId ? 1 : 0;
        UIExt_ikeImg.LoadIkeByItemId((ui.ikeImg as common_New.ikeImg), storageVO.itemDefId, true);
        var formula1 = IkeModel.Instance.GetFormulaByItemId(storageVO.itemDefId);
        var formula = IkeModel.Instance.GetFormula(formula1.CombinationId);
        int vaseId = formula.VaseId;
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(vaseId);
        ui.nameLab.text = Lang.GetValue(itemData.Name);
    }

    private void SelectFlowerSell(EventContext context)
    {
        int index = (int)(context.data as fun_SellingFlowers.storage_item_cellNew).data;
        curItem = dataList[index];
        //curSellCfg = FlowerShopModel.Instance.GetFlowerSellCfg(curItem.itemDefId);
        _view.state.selectedIndex = 0;
        if (!_view.done_btn.enabled) _view.done_btn.enabled = true;
        UpdateList();
        RefreshItem();
        if (FlowerSellModel.Instance.selectDeskId > 0)
        {
            FlowerSellController.Instance.ShowStandFlower((uint)FlowerSellModel.Instance.selectDeskId, curItem.itemDefId);
        }

        //Guide33();
    }



    private void initView()
    {
        if (dataList.Count > 0)
        {
            curItem = dataList[0];
            //curSellCfg = FlowerShopModel.Instance.GetFlowerSellCfg(curItem.itemDefId);
            _view.state.selectedIndex = 0;
            if (!_view.done_btn.enabled) _view.done_btn.enabled = true;
            RefreshItem();
        }
    }

    private void RefreshItem()
    {
        currSelectCount = 1;
        //UIExt_ikeImg.LoadIkeByItemId((_view.preview_loader as common_New.ikeImg), curItem.itemDefId, false);
        var formula1 = IkeModel.Instance.GetFormulaByItemId(curItem.itemDefId);
        var formula = IkeModel.Instance.GetFormula(formula1.CombinationId);
        int vaseId = formula.VaseId;
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(vaseId);
        _view.nameLab.text = Lang.GetValue(itemData.Name);
        UpdateButton();
    }

    private void AddBtn()
    {
        currSelectCount++;
        if (currSelectCount >= maxCount)
        {
            currSelectCount = maxCount;
        }
        UpdateButton();
    }

    private void OddBtn()
    {
        currSelectCount--;
        UpdateButton();
    }

    private void MaxBtn()
    {
        var max = (int)GlobalModel.Instance.module_profileConfig.flowerShelfCount;
        currSelectCount = curItem.count > max ? max : curItem.count;
        UpdateButton();
    }

    private void OnSell()
    {
        //GuideController.Instance.HideGuide();
        if (FlowerSellModel.Instance.selectDeskId > 0)
        {
            var deskId = (uint)FlowerSellModel.Instance.selectDeskId;
            FlowerSellController.Instance.ReqFlowerOnShelf(deskId, (uint)curItem.itemDefId, (uint)currSelectCount);
        }
        CloseView();
        //if (GuideModel.Instance.IsGuiding)
        //{

        //}
        //HideView(() =>
        //{
        //    GuideController.Instance.NextGuide();
        //});
    }

    private void OnOnekeySell()
    {
        FlowerSellController.Instance.ReqFlowerOneKeyOnShelf((uint)curItem.itemDefId);
        CloseView();
    }

    private void UpdateButton()
    {
        maxCount = (int)GlobalModel.Instance.module_profileConfig.flowerShelfCount;
        if (curItem.count < maxCount)
            maxCount = curItem.count;
        _view.info_txt.text = currSelectCount + "/" + maxCount;
        SetCoolDown(currSelectCount);
        _view.minus_btn.enabled = currSelectCount != 1;
        _view.plus_btn.enabled = currSelectCount != maxCount;
        var formula = IkeModel.Instance.GetFormulaByItemId(curItem.itemDefId);
        int rate = MyselfModel.Instance.IsVideoDouble() ? 2 : 1;
        double sunPrice = formula.SellPrice * rate;
        _view.gold_txt_1.text = sunPrice.ToString();
        SetAddOddStatus();
    }

    private void SetCoolDown(int num)
    {
        _view.reduceTime.visible = false;
        if (num == 0)
        {
            _view.coolDown.text = "00:00:00";
        }
        else
        {
            if (GlobalModel.Instance.module_profileConfig.sellTime != 0)
            {
                int selltime = GlobalModel.Instance.module_profileConfig.sellTime;
                _view.hasReduce.selectedIndex = 0;
                int time = selltime * num;
                double h = Math.Floor((double)time / 3600);
                double m = Math.Floor(((double)time - h * 3600) / 60);
                double s = (double)time - h * 3600 - m * 60;
                _view.coolDown.text = (h > 9 ? h : "0" + h) + ":" + (m > 9 ? m : "0" + m) + ":" + (s > 9 ? s : "0" + s);
            }
            else
            {
                this._view.coolDown.text = "00:00:00";
            }
        }
    }

    private void SetAddOddStatus()
    {
        if (currSelectCount == 1)
        {
            _view.minus_btn.enabled = false;
        }
        else
        {
            _view.minus_btn.enabled = true;
        }
        if (currSelectCount == 5)
        {
            _view.plus_btn.enabled = false;
        }
        else
        {
            _view.plus_btn.enabled = true;
        }
    }

    private void UpdatePage()
    {

        SpotCurrent();
        ScrollToPage(_view.list.scrollPane.currentPageX, true);
    }

    private void ScrollToPage(int page, bool tipSound = false)
    {
        float curPage = Mathf.Floor((float)page / 15);
        _view.page_list.scrollPane.SetCurrentPageX((int)curPage, false);
    }

    private void SpotCurrent()
    {
        for (int i = 0; i < _view.page_list.numItems; i++)
        {
            fun_SellingFlowers.PageListItem_new cell = _view.page_list.GetChildAt(_view.page_list.ItemIndexToChildIndex(i)) as fun_SellingFlowers.PageListItem_new;
            cell.status.selectedIndex = i == _view.list.scrollPane.currentPageX ? 1 : 0;
        }
    }

    private void PageNumItemRenderer(int index, GObject item)
    {
        item.data = index;
    }

    private void ChangePage(EventContext context)
    {
        int numIndex = (int)(context.data as GComponent).data;
        _view.list.scrollPane.SetCurrentPageX(numIndex, false);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (FlowerSellModel.Instance.selectDeskId > 0)
        {
            FlowerSellController.Instance.ShowStandFlower((uint)FlowerSellModel.Instance.selectDeskId, 0);
        }
        if (FlowerSellModel.Instance.isSelectFlowerShelfing)
        {
            SceneManager.Instance.HideAllDeskSelect();
        }
    }

    private void CloseView()
    {
        HideView();
    }
    private void HideView(Action callBack = null)
    {
        UIManager.Instance.ClosePanel(UIName.FlowerSellWindow);
        SceneManager.Instance.ShowHideHeroAvatar(true);
        //NpcManager.Instance.ShowAllNpc();

        if (FlowerSellModel.Instance.isSelectFlowerShelfing)
        {
            SceneManager.Instance.HideAllDeskSelect();
            FlowerSellModel.Instance.isSelectFlowerShelfing = false;
            SceneManager.Instance.ShowHideAllDeskAddFlower(true);
            FlowerSellModel.Instance.selectDeskId = 0;
            SceneManager.Instance.MoveToPoint(FlowerSellModel.Instance.cameraPos, 0.3f);
            SceneManager.Instance.TweenCameraOrthoSize(FlowerSellModel.Instance.orthoSize, 0.3f, callBack);
        }
    }
}

