
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ADK;
using protobuf.friend;
using Spine;

public class TradeWindow : BaseView
{
    private fun_FriendsTrade_New.tradeView _view;

    private int curPage = 0;
    private float maxPage;
    private List<StorageItemVO> storageListData;
    private string filterName = "";

    private int curSelectStall = 0;

    private float spotMaxPage;

    private int page;
    //private fun_FriendsTrade.tradeSoldOut _soldOut;

    public TradeWindow()
    {
        packageName = "fun_FriendsTrade_New";
        // 设置委托
        BindAllDelegate = fun_FriendsTrade_New.fun_FriendsTrade_NewBinder.BindAll;
        CreateInstanceDelegate = fun_FriendsTrade_New.tradeView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_FriendsTrade_New.tradeView;

        SetBg(_view.bg, "Trade/ELIDA_haoyoujiaoyi_bigbg01.jpg");
        _view.title_txt.text = Lang.GetValue("trade_friends");
        //_view.lb_tradenName.text = Lang.GetValue("FriendsDeal_2");
        StringUtil.SetBtnTab(_view.btn_friendShop, Lang.GetValue("FriendsDeal_17"));//"好友店铺";
        StringUtil.SetBtnTab(_view.btn_message, Lang.GetValue("FriendsDeal_11"));
        StringUtil.SetBtnTab(_view.recycle_btn, Lang.GetValue("trade_6"));

        _view.ls_sale.height = _view.close_btn.y - _view.spine.y - 250;
        _view.recycle_btn.visible = false;
        _view.status.selectedIndex = 0;
        //_soldOut = fun_FriendsTrade.tradeSoldOut.CreateInstance();
        //_view.ls_ItemList.itemRenderer = StorageItemRenderer;
        //_soldOut.lb_info.text = Lang.GetValue("FriendsDeal_4");
        //StringUtil.SetBtnTab(_soldOut.btn_sure, Lang.GetValue("gui_btn_confirm"));

        //_view.ls_ItemList.SetVirtual();
        //_view.ls_ItemList.scrollPane.onScroll.Add(UpdatePage);

        //_view.page_list.itemRenderer = PageNumItemRenderer;
        //_view.page_list.onClickItem.Add(ChangePage);

        _view.ls_sale.itemRenderer = RenderList;

        _view.btn_help.onClick.Add(() =>
        {
            var param = new string[] { Lang.GetValue("train_help"), Lang.GetValue("FriendsDeal_20") };
            UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, param);
        });

        if(TradeModel.Instance.dealGrids.Count % 2 == 0)
        {
            page = TradeModel.Instance.dealGrids.Count / 2;
        }
        else
        {
            page = (TradeModel.Instance.dealGrids.Count + 1) / 2;
        }
        
        //_view.leftBtn.onClick.Add(SpotLeft);
        //_view.rightBtn.onClick.Add(SpotRight);
        //_view.findBtn.onClick.Add(ClickFindBtnHandler);

        //_view.onTouchEnd.Add(() =>
        //{
        //    if (_soldOut != null)
        //    {
        //        _soldOut.visible = false;
        //    }

        //});

        _view.btn_friendShop.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<TradeFriendsListWindow>(UIName.TradeFriendsListWindow);
        });

        _view.btn_message.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<TradeMessageWindow>(UIName.TradeMessageWindow);
        });

        _view.spine.url = "haoyoujiaoyi";
        _view.spine.loop = true;
        _view.spine.animationName = "idle";

        //if (_view.close_btn.y > 1162)
        //{
        //    float moveY = (_view.close_btn.y - 1162) / 2;
        //    float endY = moveY + moveY / 4;
        //    float space = (_view.close_btn.y - 1162) / 10;
        //    float height = space * 3;
        //    _view.ls_sale.y = _view.ls_sale.y + endY;
        //    _view.pos.y = _view.pos.y + endY;
        //    _view.ls_sale.height = _view.ls_sale.height + height;
        //    _view.pos.lineGap = 145 + (int)space;
        //    _view.ls_sale.lineGap = -7 + (int)space;
        //}

        AddEventListener(TradeEvent.TradeInfomation, UpdateStalls);
        AddEventListener<int>(TradeEvent.TradeUnlock, UnlockData);
        AddEventListener(TradeEvent.TradeUpperShelf, UpdateData);
        AddEventListener(TradeEvent.Trade, UpdateData);
        AddEventListener(TradeEvent.TradeHelp, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();

        // 其他打开面板的逻辑
        //_view.inputLab.text = "";
        curSelectStall = -1;
        TradeController.Instance.ReqTradeInfomation();
        //_view.ls_ItemList.scrollPane.currentPageX = 0;
        //UpdateStorageList();

    }

    private void UnlockData(int pos)
    {
        var index = 0;
        var idx = pos % 2;
        if (idx == 0)
        {
           index = pos / 2;
        }
        else
        {
            index = (pos + 1) / 2 - 1;
        }
        var list_item = _view.ls_sale.GetChildAt(index) as fun_FriendsTrade_New.trade_item;
        fun_FriendsTrade_New.trade_saleItem item = null;
        if (idx == 0)
        {
            item = list_item.item1;
        }
        else
        {
            item = list_item.item2;
        }
        //var item = _view.ls_sale.GetChildAt(index) as fun_FriendsTrade_New.trade_saleItem;
        item.lockSpine.loop = false;
        item.lockSpine.animationName = "unlock";
        item.lockSpine.forcePlay = true;
        item.lockSpine.Complete = OnAnimationEventHandler;
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "unlock")
        {
            UpdateStalls();
        }
    }

    private void UpdateData()
    {
        UpdateStalls();
    }
    private void UpdateStalls()
    {
        UpdateSelectIndex();
        _view.ls_sale.numItems = page;

    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_FriendsTrade_New.trade_item;
        var starIndex = (index + 1) * 2 - 2;

        SaleItemRenderer(starIndex, cell.item1);
        if(starIndex + 2 > TradeModel.Instance.dealGrids.Count)
        {
            cell.item2.visible = false;
        }
        else
        {
            cell.item2.visible = true;
            SaleItemRenderer(starIndex + 1, cell.item2);
        }

    }
    private void SaleItemRenderer(int index, GObject item)
    {
        fun_FriendsTrade_New.trade_saleItem itemCell = item as fun_FriendsTrade_New.trade_saleItem;
        var stall = TradeModel.Instance.GetGridData((uint)(index + 1));
        var conf = TradeModel.Instance.dealGrids[index + 1];
        itemCell.data = index;
        //itemCell.selectStatus.visible = false;
        itemCell.password.visible = false;
        if (stall == null)
        {
            //未解锁
            if (conf.Type == 2)
            {
                itemCell.status.selectedIndex = 2;
                itemCell.lb_inviteInfo.text = "出售鲜花金币" + TradeModel.Instance.tradeGoldCnt + "/" + conf.GoldUnlock;
            }
            else
            {
                itemCell.status.selectedIndex = 3;
                var consum = conf.UnlockConsumes[0];
                itemCell.img_cost.url = ImageDataModel.Instance.GetIconUrlByEntityId(consum.EntityID);
                itemCell.lb_cost.text = consum.Value.ToString();
                itemCell.lockSpine.url = "wudisuo";
                itemCell.lockSpine.loop = true;
                itemCell.lockSpine.animationName = "befor";
            }
        }
        else
        {
            if (stall.sellStatus == 0)
            {
                //可上架
                itemCell.status.selectedIndex = 1;
                itemCell.lb_saleCount.text = ((conf.PutawayTimes + stall.buyCnt) - stall.shelfCnt) + "/" + conf.PutawayTimes;
                //if(curSelectStall == index)
                //{
                //    itemCell.selectStatus.visible = true;
                //}
            }
            else if (stall.sellStatus == 1)
            {
                itemCell.status.selectedIndex = 0;
                itemCell.lb_count.text = stall.num.ToString();
                itemCell.lb_price.text = (stall.price * stall.num).ToString();
                itemCell.img_item.url = ImageDataModel.Instance.GetIconUrlByEntityId((long)stall.itemId);
                itemCell.password.visible = stall.password != "" ? true : false;
            }
        }
        //itemCell.btn_unlock.onClick.Add(UnlockCage);
        itemCell.onClick.Add(StallClickHander);
    }

    private void UnlockCage(int index)
    {
        //int index = (int)(context.sender as GComponent).parent.data;
        var conf = TradeModel.Instance.dealGrids[index + 1];
        if (conf.Type == 16001)
        {
            TradeController.Instance.ReqTradeUnlock((uint)index + 1);
            return;
        }
        if ((int)BaseType.GOLD == IDUtil.GetEntityValue(conf.UnlockConsumes[0].EntityID))
        {
            if (MyselfModel.Instance.gold < conf.UnlockConsumes[0].Value)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt2"));
                return;
            }
        }
        else
        {
            if (MyselfModel.Instance.diamond < conf.UnlockConsumes[0].Value)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                return;
            }
        }
        TradeController.Instance.ReqTradeUnlock((uint)index + 1);

    }

    private void StallClickHander(EventContext context)
    {
        fun_FriendsTrade_New.trade_saleItem cell = context.sender as fun_FriendsTrade_New.trade_saleItem;
        int index = (int)(context.sender as GComponent).data;
        var stall = TradeModel.Instance.GetGridData((uint)(index + 1));
        var conf = TradeModel.Instance.dealGrids[index + 1];
        if (stall != null)
        {
            if (stall.sellStatus != 1)
            {
                if ((conf.PutawayTimes + stall.buyCnt - stall.shelfCnt) > 0)
                {
                    //curSelectStall = index;
                    //_view.ls_sale.numItems = 8;
                    var flowerList = StorageModel.Instance.GetStorageListByType_1(4001);
                    if (flowerList.Count > 0)
                    {
                        UIManager.Instance.OpenWindow<TradeSaleWindow>(UIName.TradeSaleWindow, stall);
                    }
                    else
                    {
                        UILogicUtils.ShowNotice(Lang.GetValue("trade_5"));
                    }

                }
                else
                {
                    if (stall.buyCnt < conf.DiamondConsumes.Length)
                    {
                        UILogicUtils.ShowConfirm(Lang.GetValue("FriendsDeal_9", conf.DiamondConsumes[(int)stall.buyCnt].ToString()), () =>
                        {
                            if (MyselfModel.Instance.diamond < conf.DiamondConsumes[(int)stall.buyCnt])
                            {
                                UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
                                return;
                            }
                            TradeController.Instance.ReqTradeBuyShelftimes((uint)index + 1);
                        });
                    }
                    else
                    {
                        UILogicUtils.ShowNotice(Lang.GetValue("FriendsDeal_22"));
                    }
                }
            }
            else if (stall.sellStatus == 1)
            {
                UIManager.Instance.OpenWindow<RecycleWindow>(UIName.RecycleWindow, stall);
            }

        }
        else
        {
            if (conf.Type == 16001 && cell.status.selectedIndex != 4)
            {
                return;
            }
            UnlockCage(index);
        }
        
    }

    private void ReqHelp(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        TradeController.Instance.ReqTradeHelp((uint)(index + 1));
    }

    private void SoldItemHander(EventContext context)
    {
        I_GRID_VO stall = (context.sender as GComponent).data as I_GRID_VO;
        TradeController.Instance.ReqTradeDownShelf(stall.position);
        //_soldOut.visible = false;
    }


    private void UpdateSelectIndex()
    {
        TradeModel.Instance.grids.Sort((a, b) => (int)b.position - (int)a.position);
        curSelectStall = -1;
        foreach (var stall in TradeModel.Instance.grids)
        {
            var conf = TradeModel.Instance.dealGrids[(int)stall.position];
            if (stall.sellStatus == 0 && stall.shelfCnt < conf.PutawayTimes)
            {
                curSelectStall = (int)stall.position - 1;
            }
        }
    }

    private void OnClickHander(EventContext context)
    {
        if (curSelectStall >= 0)
        {
            StorageItemVO item = (context.sender as GComponent).data as StorageItemVO;
            var stall = TradeModel.Instance.GetGridData((uint)curSelectStall + 1);
            object[] param = new object[] { item, stall };
            UIManager.Instance.OpenWindow<TradeSaleWindow>(UIName.TradeSaleWindow, param);
        }
        else
        {
            UILogicUtils.ShowNotice(Lang.GetValue("FriendsDeal_21"));
        }

    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

