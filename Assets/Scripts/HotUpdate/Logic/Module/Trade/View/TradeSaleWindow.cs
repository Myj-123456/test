
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.friend;
using System;
using Elida.Config;

public class TradeSaleWindow : BaseWindow
{
    private fun_FriendsTrade_New.tradeSaleView _view;

    private StorageItemVO _saleItem;
    private I_GRID_VO _stallPostion;
    private Ft_friends_deal_itemsConfig _curItemInfo;

    private int _curPrice;
    private int _curCount;

    private string password = "";

    private int curPage = 0;
    private float maxPage;
    private List<StorageItemVO> storageListData;
    private float spotMaxPage;
    private string filterName = "";

    public TradeSaleWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeSaleView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeSaleView;

        SetBg(_view.bg, "Common/ELIDA_common_bigdi01.png");
        _view.title_0.text = Lang.GetValue("Cultivating_lottery_03");//"数量";
        _view.title_1.text = Lang.GetValue("FriendsDeal_12");//"单价";
        _view.title_2.text = Lang.GetValue("FriendsDeal_13");//"总价";

        StringUtil.SetBtnTab(_view.btn_submit, Lang.GetValue("FriendsDeal_101"));
        StringUtil.SetBtnTab(_view.btn_password, Lang.GetValue("FriendsDeal_102"));
        StringUtil.SetBtnTab(_view.btn_min, Lang.GetValue("FriendsDeal_15"));
        StringUtil.SetBtnTab(_view.btn_max, Lang.GetValue("FriendsDeal_16"));

        StringUtil.SetBtnTab(_view.findBtn, Lang.GetValue("pray_8"));

        _view.title_3.text = Lang.GetValue("trade_1");
        _view.img_gold_sum.url = ImageDataModel.GOLD_ICON_URL;
        _view.ls_ItemList.itemRenderer = StorageItemRenderer;
        _view.ls_ItemList.SetVirtual();
        _view.ls_ItemList.scrollPane.onScroll.Add(UpdatePage);

        _view.page_list.itemRenderer = PageNumItemRenderer;
        _view.page_list.onClickItem.Add(ChangePage);

        _view.findBtn.onClick.Add(ClickFindBtnHandler);

        _view.leftBtn.onClick.Add(() =>
        {
            ListLeft();
        });

        _view.rightBtn.onClick.Add(() =>
        {
            ListRight();
        });
        _view.btn_add.onClick.Add(() =>
        {
            int macCount = Math.Min(_curItemInfo.ItemAmounts[1], _saleItem.count);
            if (_curCount < macCount)
            {
                _curCount++;
                UpdateTotalPrice();
            }
        });

        _view.btn_sub.onClick.Add(() =>
        {
            if (_curCount > _curItemInfo.ItemAmounts[0])
            {
                _curCount--;
                UpdateTotalPrice();
            }
        });

        _view.btn_min.onClick.Add(() =>
        {
            _curPrice = _curItemInfo.UnitPrices[0];
            UpdateTotalPrice();
        });

        _view.btn_max.onClick.Add(() =>
        {
            _curPrice = _curItemInfo.UnitPrices[2];
            UpdateTotalPrice();
        });

        _view.touch_Count.onClick.Add(() =>
        {
            string title = Lang.GetValue("slang_133");//请输入数量
            string eventName = TradeEvent.TradeUpdateCount;
            object[] param = new object[] { title, eventName };
            UIManager.Instance.OpenWindow<GuildInputWindow>(UIName.GuildInputWindow, param);
        });

        _view.touch_price.onClick.Add(() =>
        {
            string title = Lang.GetValue("FriendsDeal_25");//请输入数量
            string eventName = TradeEvent.TradeUpdatePrice;
            object[] param = new object[] { title, eventName };
            UIManager.Instance.OpenWindow<GuildInputWindow>(UIName.GuildInputWindow, param);
        });

        _view.btn_submit.onClick.Add(() =>
        {
            TradeController.Instance.ReqTradeUpperShelf(_stallPostion.position, (uint)_saleItem.itemDefId, (uint)_curCount, (uint)_curPrice, "");
            UIManager.Instance.CloseWindow(UIName.TradeSaleWindow);
        });
        _view.btn_password.onClick.Add(() =>
        {
            uint[] param = new uint[] { _stallPostion.position, (uint)_saleItem.itemDefId, (uint)_curCount, (uint)_curPrice };
            UIManager.Instance.OpenWindow<TradeSetPasswordWindow>(UIName.TradeSetPasswordWindow, param);
        });
        AddEventListener<string>(TradeEvent.TradeUpdateCount, ChangeCount);
        AddEventListener<string>(TradeEvent.TradeUpdatePrice, ChangePrice);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        _stallPostion = data as I_GRID_VO;
        password = "";
        _view.ls_ItemList.scrollPane.currentPageX = 0;
        UpdateStorageList();
        _saleItem = storageListData[0];
        InitView();
    }

    private void InitView()
    {
        _view.img_item.url = ImageDataModel.Instance.GetIconUrl(_saleItem.item);
        _view.lb_title.text = Lang.GetValue(_saleItem.item.Name);
        _view.lb_storageCount.text = Lang.GetValue("FriendsDeal_24", _saleItem.count.ToString());

        _curItemInfo = TradeModel.Instance.GetDealItemsData(_saleItem.itemDefId);
        _curPrice = _curItemInfo.UnitPrices[1];
        _curCount = Math.Min(_curItemInfo.ItemAmounts[1], _saleItem.count);
        //_view.lb_CountRange.text = _curItemInfo.ItemAmounts[0] + "~" + _curItemInfo.ItemAmounts[1];
        //_view.lb_priceRange.text = _curItemInfo.UnitPrices[0] + "~" + _curItemInfo.UnitPrices[2];
        UpdateTotalPrice();
    }

    private void UpdateTotalPrice()
    {
        _view.lb_Count.text = _curCount.ToString();
        _view.lb_price.text = _curPrice.ToString();
        _view.lb_goldSum.text = (_curCount * _curPrice).ToString();
    }

    private void ChangeCount(string data)
    {
        int count = int.Parse(data);
        int maxCount = Math.Min(_curItemInfo.ItemAmounts[1], _saleItem.count);
        if (count < _curItemInfo.ItemAmounts[0])
        {
            _curCount = _curItemInfo.ItemAmounts[0];
        }
        else if (count > maxCount)
        {
            _curCount = maxCount;
        }
        else
        {
            _curCount = count;
        }
        UpdateTotalPrice();
    }

    private void ChangePrice(string data)
    {
        int price = int.Parse(data);
        if (price < _curItemInfo.UnitPrices[0])
        {
            _curPrice = _curItemInfo.UnitPrices[0];
        }
        else if (price > _curItemInfo.UnitPrices[2])
        {
            _curPrice = _curItemInfo.UnitPrices[2];
        }
        else
        {
            _curPrice = price;
        }
        UpdateTotalPrice();
    }

    private void SpotCurrent()
    {
        for (int i = 0; i < _view.page_list.numItems; i++)
        {
            common_New.PageListItem_new2 cell = _view.page_list.GetChildAt(_view.page_list.ItemIndexToChildIndex(i)) as common_New.PageListItem_new2;
            cell.status.selectedIndex = i == _view.ls_ItemList.scrollPane.currentPageX ? 1 : 0;
        }
    }

    private void UpdatePage()
    {

        SpotCurrent();
        ScrollToPage(_view.ls_ItemList.scrollPane.currentPageX, true);
        SetLeftRightStatus();
    }

    private void ScrollToPage(int page, bool tipSound = false)
    {
        float curPage = Mathf.Floor((float)page / 10);
        _view.page_list.scrollPane.SetCurrentPageX((int)curPage, false);
    }

    private void PageNumItemRenderer(int index, GObject item)
    {
        item.data = index;
    }

    private void ChangePage(EventContext context)
    {
        int numIndex = (int)(context.data as GComponent).data;
        _view.ls_ItemList.scrollPane.SetCurrentPageX(numIndex, false);
        SetLeftRightStatus();
    }

    private void StorageItemRenderer(int index, GObject item)
    {
        fun_FriendsTrade_New.tradeItemCell itemCell = item as fun_FriendsTrade_New.tradeItemCell;
        var data = storageListData[index];
        itemCell.data = data;
        UILogicUtils.ShowNameTip(itemCell.img_Item, data.item.ItemDefId);
        var plant = FlowerHandbookModel.Instance.GetStaticSeedCondition(data.itemDefId);
        itemCell.bg.url = "MyInfo/show_flower_bg" + plant.FlowerQuality + ".png";
        itemCell.lb_num.text = data.count.ToString();
        itemCell.onClick.Add(OnClickHander);
    }

    private void OnClickHander(EventContext context)
    {
        StorageItemVO item = (context.sender as GComponent).data as StorageItemVO;
        _saleItem = item;
        password = "";
        InitView();
    }

    private void UpdateStorageList(string filterName = "")
    {
        var flowerList = StorageModel.Instance.GetStorageListByType_1(4001);
        storageListData = flowerList.FindAll((value) =>
        {
            if (filterName == "")
            {
                return true;
            }
            else
            {
                string name = Lang.GetValue(value.item.Name);
                if (name.Contains(filterName))
                {
                    return true;
                }
            }
            return false;
        });
        storageListData.Sort(FlowerSort);
        maxPage = Mathf.Floor((float)storageListData.Count / 12);
        if(storageListData.Count % 12 == 0)
        {
            maxPage -= 1; 
        }
        spotMaxPage = Mathf.Floor((maxPage + 1) / 11);

        _view.ls_ItemList.numItems = storageListData.Count;
        _view.page_list.numItems = (int)(maxPage + 1);
        if ((int)(maxPage + 1) > 11)
        {
            _view.page_list.layout = FairyGUI.ListLayoutType.Pagination;
        }
        else
        {
            _view.page_list.layout = FairyGUI.ListLayoutType.FlowHorizontal;
        }
        SpotCurrent();
    }

    private int FlowerSort(StorageItemVO a, StorageItemVO b)
    {
        var plantCropa = FlowerHandbookModel.Instance.GetStaticSeedCondition(a.itemDefId);
        var plantCropb = FlowerHandbookModel.Instance.GetStaticSeedCondition(b.itemDefId);
        if(plantCropa.FlowerQuality != plantCropb.FlowerQuality)
        {
            return plantCropb.FlowerQuality - plantCropa.FlowerQuality;
        }
        return 0;
    }

    private void ClickFindBtnHandler()
    {
        UpdateStorageList(_view.inputLab.text);
    }

    private void SpotLeft()
    {
        if (_view.page_list.scrollPane.currentPageX <= 0)
        {
            return;
        }
        _view.page_list.scrollPane.SetCurrentPageX(_view.page_list.scrollPane.currentPageX - 1, true);
    }

    private void SpotRight()
    {

        if (_view.page_list.scrollPane.currentPageX >= spotMaxPage - 1)
        {
            return;
        }
        _view.page_list.scrollPane.SetCurrentPageX(_view.page_list.scrollPane.currentPageX + 1, true);
    }

    private void ListLeft()
    {
        if (_view.ls_ItemList.scrollPane.currentPageX <= 0)
        {
            return;
        }
        _view.ls_ItemList.scrollPane.SetCurrentPageX(_view.ls_ItemList.scrollPane.currentPageX - 1, true);
    }

    private void ListRight()
    {
        if (_view.ls_ItemList.scrollPane.currentPageX >= maxPage)
        {
            return;
        }
        _view.ls_ItemList.scrollPane.SetCurrentPageX(_view.ls_ItemList.scrollPane.currentPageX + 1, true);
    }

    private void SetLeftRightStatus()
    {
        _view.leftBtn.enabled = _view.ls_ItemList.scrollPane.currentPageX <= 0 ? false : true;
        _view.rightBtn.enabled = _view.ls_ItemList.scrollPane.currentPageX >= maxPage ? false : true;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

