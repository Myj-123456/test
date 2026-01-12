using FairyGUI;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class ExchangeView : BaseView
{
    private fun_Draw.flower_exchange_view view;
    private List<Ft_event_exchangeConfig> exchangeList;
    private int selectedIndex = -1; // 选中状态变量
    //private CountDownTimer timer;
    private int activityId;
    public ExchangeView()
    {
        packageName = "fun_Draw";
        BindAllDelegate = fun_Draw.fun_DrawBinder.BindAll;
        CreateInstanceDelegate = fun_Draw.flower_exchange_view.CreateInstance;
    }
    public override void OnInit()
    {
        base.OnInit();
        view = (fun_Draw.flower_exchange_view)ui;
        SetBg(view.bg1, "Draw/ELIDA_chouka_duihuan_bg01.png");
        SetBg(view.bg2, "Draw/ELIDA_chouka_duihuan_bg02.png");
        view.list.itemRenderer = ExchangeItemRenderer;
        view.list.numItems = 0;
        view.list.SetVirtual();
        view.titleLab.text = Lang.GetValue("Target_txt6");
        view.backBtn.onClick.Add(() =>
        {
            Close();
        });
        EventManager.Instance.AddEventListener(ExhcangeEvent.MonthDraw, UpdateExchangeList);
        EventManager.Instance.AddEventListener(ExhcangeEvent.DiamondDraw, UpdateExchangeList);
        EventManager.Instance.AddEventListener(ExhcangeEvent.DressDraw, UpdateExchangeList);
        EventManager.Instance.AddEventListener(ExhcangeEvent.FurnitureShop, UpdateExchangeList);
    }

    //private int GetNextDayTime()
    //{
    //    var now = TimeUtil.GetDateTime(ServerTime.Time);
    //    var next = now.Date.AddDays(1);
    //    var timeUntilNextDay = next - now;
    //    return (int)timeUntilNextDay.TotalSeconds;
    //}

    //private int GetNextWeekTime()
    //{
    //    var now = TimeUtil.GetDateTime(ServerTime.Time);
    //    int daysUntilNextWeek = 7 - (int)now.DayOfWeek;
    //    if (daysUntilNextWeek == 7)
    //        daysUntilNextWeek = 0;
    //    var nextWeek = now.Date.AddDays(daysUntilNextWeek + 1);
    //    var timeUntilNextWeek = nextWeek - now;
    //    return (int)timeUntilNextWeek.TotalSeconds;
    //}

    public override void OnShown()
    {
        base.OnShown();
        if (data != null)
        {
            activityId = (int)data;
            // 请求活动信息以获取最新的兑换统计数据
            DrawController.Instance.ReqDrawInfo((uint)activityId);
            exchangeList = DrawModel.Instance.GetExchangeList(activityId);
            if (exchangeList != null && exchangeList.Count > 0)
            {
                view.list.numItems = exchangeList.Count;
                view.list.RefreshVirtualList();
            }
            else
            {
                view.list.numItems = 0;
            }
            UpdateData();
        }
    }
    private void UpdateData()
    {
        if (exchangeList != null && exchangeList.Count > 0 && selectedIndex == -1)
        {
            selectedIndex = 0;
            OnItemClick(selectedIndex);
        }
    }
    private void ExchangeItemRenderer(int index, GObject item)
    {
        if (exchangeList == null || index >= exchangeList.Count)
            return;
        var exchangeData = exchangeList[index];
        var cell = item as fun_Draw.exchange_Item;

        if (exchangeData.Rewards == null || exchangeData.Rewards.Length == 0)
            return;

        var dataInfo = exchangeData.Rewards[0];
        var itemVo = ItemModel.Instance.GetItemByEntityID(dataInfo.EntityID);
        if (itemVo == null)
            return;

        if (exchangeData.LimitConfigs != null && exchangeData.LimitConfigs.Length > 0 && exchangeData.LimitConfigs[0] != 0)
        {
            var totalLimit = exchangeData.LimitConfigs.Length > 1 ? exchangeData.LimitConfigs[1] : 0;
            var haveCount = DrawModel.Instance.GetExchangeCount((uint)exchangeData.Id);
            var remainCount = totalLimit - haveCount;

            if (exchangeData.LimitConfigs[0] == 1)
            {
                cell.Text_limit.text = Lang.GetValue("draw_limit_buy_0") + "（" + remainCount + "/" + totalLimit + "）";
                //if (remainCount <= 0)
                //{
                //    var endTime = GetNextDayTime();
                //    if (endTime > 0)
                //    {
                //        if (timer != null)
                //        {
                //            timer.Clear();
                //            timer = null;
                //        }
                //        timer = new CountDownTimer(cell.Text_limit, endTime);
                //        timer.CompleteCallBacker = () =>
                //        {
                //            cell.btn_exchange.status.selectedIndex = 0;
                //            if (timer != null)
                //            {
                //                timer.Clear();
                //                timer = null;
                //            }
                //        };
                //        cell.btn_exchange.status.selectedIndex = 1;
                //    }
                //    else
                //    {
                //        cell.btn_exchange.status.selectedIndex = 0;
                //    }
                //}
                //else
                //{
                //    cell.btn_exchange.status.selectedIndex = 0;
                //}
                cell.btn_exchange.status.selectedIndex = remainCount <= 0 ? 1 : 0;
            }
            else if (exchangeData.LimitConfigs[0] == 2)
            {
                cell.Text_limit.text = Lang.GetValue("draw_limit_buy_1") + "（" + remainCount + "/" + totalLimit + "）";
                //if (remainCount <= 0)
                //{
                //    var endTime = GetNextWeekTime();
                //    if (endTime > 0)
                //    {
                //        if (timer != null)
                //        {
                //            timer.Clear();
                //            timer = null;
                //        }
                //        timer = new CountDownTimer(cell.Text_limit, endTime);
                //        timer.CompleteCallBacker = () =>
                //        {
                //            cell.btn_exchange.status.selectedIndex = 0;
                //            if (timer != null)
                //            {
                //                timer.Clear();
                //                timer = null;
                //            }
                //        };
                //        cell.btn_exchange.status.selectedIndex = 1;
                //    }
                //    else
                //    {
                //        cell.btn_exchange.status.selectedIndex = 0;
                //    }
                //}
                //else
                //{
                //    cell.btn_exchange.status.selectedIndex = 0;
                //}
                cell.btn_exchange.status.selectedIndex = remainCount <= 0 ? 1 : 0;
            }
            else if (exchangeData.LimitConfigs[0] == 3)
            {
                cell.Text_limit.text = Lang.GetValue("fund_5") + "（" + remainCount + "/" + totalLimit + "）";
                cell.btn_exchange.enabled = remainCount > 0;
            }
        }
        else
        {
            cell.Text_limit.text = "";
            cell.btn_exchange.status.selectedIndex = 0;
        }
        cell.titleLab.text = Lang.GetValue(itemVo.Name);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);

        List<int> exchangeItems = null;
        if (activityId == 1001)
        {
            exchangeItems = GlobalModel.Instance.module_profileConfig.clotheDrawExchangeItem;
        }
        else
        {
            exchangeItems = GlobalModel.Instance.module_profileConfig.drawExchangeItem;
        }
        if (exchangeItems != null && exchangeItems.Count > 0)
        {
            var firstItemId = exchangeItems[0];
            var firstItemVo = ItemModel.Instance.GetItemByEntityID(firstItemId.ToString());
            if (firstItemVo != null)
            {
                view.pic.url = ImageDataModel.Instance.GetIconUrl(firstItemVo);
                var firstItemCount = StorageModel.Instance.GetItemCount(firstItemId);
                view.numLab.text = firstItemCount.ToString();
            }

            if (exchangeItems.Count > 1)
            {
                var secondItemId = exchangeItems[1];
                var secondItemVo = ItemModel.Instance.GetItemByEntityID(secondItemId.ToString());
                if (secondItemVo != null)
                {
                    view.pic2.url = ImageDataModel.Instance.GetIconUrl(secondItemVo);
                    var secondItemCount = StorageModel.Instance.GetItemCount(secondItemId);
                    view.numLab2.text = secondItemCount.ToString();
                }
            }
        }
        if (exchangeData.Expends != null && exchangeData.Expends.Length > 0)
        {
            var expendItem = exchangeData.Expends[0];
            var expendItemVo = ItemModel.Instance.GetItemByEntityID(expendItem.EntityID);
            if (expendItemVo != null)
            {
                cell.btn_exchange.pic.url = ImageDataModel.Instance.GetIconUrl(expendItemVo);
                cell.btn_exchange.titleLab.text = expendItem.Value.ToString();
            }
        }
        cell.AddEventListener("onClick", () => OnItemClick(index));
        cell.btn_exchange.onClick.Add(() => OnExchangeClick(index));
    }

    private void OnItemClick(int index)
    {
        if (exchangeList == null || index >= exchangeList.Count)
            return;
        selectedIndex = index;
        view.list.RefreshVirtualList();

        var exchangeData = exchangeList[index];
        var dataInfo = exchangeData.Rewards[0];
        var itemVo = ItemModel.Instance.GetItemByEntityID(dataInfo.EntityID);
        view.img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.rare_name.text = Lang.GetValue(itemVo.Name);
        view.rare.url = "HandBookNew/rare_icon_" + itemVo.Quality + ".png";
        view.rare_bg.url = "HandBookNew/name_bg_small_color_" + itemVo.Quality + ".png";

    }

    private void OnExchangeClick(int index)
    {
        if (exchangeList == null || index >= exchangeList.Count)
            return;
        var exchangeData = exchangeList[index];
        DrawController.Instance.ReqCommonExchange((uint)activityId, (uint)exchangeData.Id, (uint)activityId);
    }

    public override void OnHide()
    {
        //if (timer != null)
        //{
        //    timer.Clear();
        //    timer = null;
        //}
        EventManager.Instance.RemoveEventListener(ExhcangeEvent.MonthDraw, UpdateExchangeList);
        EventManager.Instance.RemoveEventListener(ExhcangeEvent.DiamondDraw, UpdateExchangeList);
        EventManager.Instance.RemoveEventListener(ExhcangeEvent.DressDraw, UpdateExchangeList);
        EventManager.Instance.RemoveEventListener(ExhcangeEvent.FurnitureShop, UpdateExchangeList);
    }

    private void UpdateExchangeList()
    {
        exchangeList = DrawModel.Instance.GetExchangeList(activityId);
        if (exchangeList != null && exchangeList.Count > 0)
        {
            view.list.numItems = exchangeList.Count;
            view.list.RefreshVirtualList();
        }
        else
        {
            view.list.numItems = 0;
        }
        UpdateData();
    }
}

