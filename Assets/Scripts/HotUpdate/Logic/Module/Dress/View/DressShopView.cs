using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class DressShopView : BaseView
{
   private fun_Dress.dress_shop_view view;
    private int typeDress = 0;
    private List<Ft_shop_clothesConfig> listData;
    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };

    private int maxPage;
    private int curPage;
    public DressShopView()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_shop_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_shop_view;
        SetBg(view.bg, "Dress/ELIDA_huanzhuang_sd_bg01.png");
        SetBg(view.bg1, "Dress/ELIDA_huanzhuang_sd_bg02.png");
        view.titleLab.text = Lang.GetValue("dress_17");
        view.list_filter.height = view.close_btn.y - view.charmNum.y - 118;
        view.list.height = view.close_btn.y - view.charmNum.y - 151;
        view.list_filter.itemRenderer = FilterItemRender;
        view.list_filter.onClickItem.Add(OnFilterItemClick);
        view.list_filter.numItems = 8;

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
        //view.list.scrollPane.onScrollEnd.Add(SetLeftRightStatus);
        //view.left_btn.onClick.Add(ListLeft);
        //view.right_btn.onClick.Add(ListRight);

        EventManager.Instance.AddEventListener(DressEvent.DressClothesBuy, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        Filter(0);
        typeDress = 0;
        UpdateList();
        view.list.scrollPane.SetCurrentPageX(0,false);
        view.list.selectedIndex = 0;
        view.list_filter.selectedIndex = 0;
        SetLeftRightStatus();
        UpdateDressInfo();
        UpdateExp();
    }

    private void ListLeft()
    {
        if (view.list.scrollPane.currentPageX <= 0)
        {
            return;
        }
        view.list.scrollPane.SetCurrentPageX(view.list.scrollPane.currentPageX - 1, true);
    }

    private void ListRight()
    {
        if (view.list.scrollPane.currentPageX >= maxPage)
        {
            return;
        }
        view.list.scrollPane.SetCurrentPageX(view.list.scrollPane.currentPageX + 1, true);
    }
    private void SetLeftRightStatus()
    {
        //view.left_btn.enabled = view.list.scrollPane.currentPageX <= 0 ? false : true;
        //view.right_btn.enabled = view.list.scrollPane.currentPageX >= maxPage ? false : true;
        //view.pageLab.text = (view.list.scrollPane.currentPageX + 1) + "/" + (maxPage + 1);
    }
    private void Filter(int type = 0)
    {
        if(type == 0)
        {
            listData = DressModel.Instance.dressShopList;
        }
        else
        {
            listData = DressModel.Instance.dressShopList.FindAll(value =>
            {
                var itemVo = ItemModel.Instance.GetItemByEntityID(value.ItemIds[0].EntityID);
                var dressInfo = DressModel.Instance.GetDressConfig(itemVo.ItemDefId);
                return type == dressInfo.Type;
            });
        }
        //maxPage = (int)Mathf.Floor((float)listData.Count / 8);
    }
    private void UpdateData()
    {
        UpdateList();
        UpdateExp();
        UpdateDressInfo();
    }
    private void UpdateList()
    {
        view.list.numItems = listData.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Dress.dress_shop_item;
        var info = listData[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.ItemIds[0].EntityID);
        var costVo = ItemModel.Instance.GetItemByEntityID(info.Prices[0].EntityID);
        var dressInfo = DressModel.Instance.GetDressInfo(itemVo.ItemDefId);
        cell.bg.url = "Dress/QualityIcon/dress_shop_bg" + dressInfo.Quality + ".png";
        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.cost_num.text = info.Prices[0].Value.ToString();
        cell.cost_img.url = ImageDataModel.Instance.GetIconUrl(costVo);
        
        var count = StorageModel.Instance.GetItemCount(info.Prices[0].EntityID);
        //cell.buy_btn.enabled = count >= info.Prices[0].Value;
        var lv = DressModel.Instance.GetShopLv();
        if(info.UnlockLv > lv)
        {
            cell.unlock.selectedIndex = 1;
        }
        else
        {
            cell.unlock.selectedIndex = dressInfo.Unlock ? 2:0;
        }
        
        
        cell.buy_btn.data = info;
        cell.buy_btn.onClick.Add(BuyClick);
        cell.onClick.Add(SelectDress);

    }
    public void SelectDress(EventContext context)
    {
        UpdateDressInfo();
    }
    private void BuyClick(EventContext context)
    {
        var info = (context.sender as GObject).data as Ft_shop_clothesConfig;
        var costVo = ItemModel.Instance.GetItemByEntityID(info.Prices[0].EntityID);
        var count = StorageModel.Instance.GetItemCount(info.Prices[0].EntityID);
        if(info.Prices[0].Value > count)
        {
            UILogicUtils.ItemUnder(costVo.ItemDefId);
            return;
        }
        DressController.Instance.ReqDressClothesBuy((uint)info.Id);
    }
    private void FilterItemRender(int index, GObject item)
    {
        fun_Dress.DressFilterBtn1 cell = item as fun_Dress.DressFilterBtn1;
        cell.type.selectedIndex = index;
        if(index == 0)
        {
            cell.titleLab.text = Lang.GetValue("guild_Match_3");
        }
        else
        {
            cell.titleLab.text = Lang.GetValue("dress_type_" + index);
        }
    }
    private void OnFilterItemClick(EventContext context)
    {
        var index = view.list_filter.selectedIndex;
        if (index != typeDress)
        {
            typeDress = index;
            Filter(typeDress);
            UpdateList();
            view.list.scrollPane.SetCurrentPageX(0, false);
            if(listData.Count > 0)
            {
                view.list.selectedIndex = 0;
                UpdateDressInfo();
            }
        }
    }

    private void UpdateDressInfo()
    {
        var itemVo = ItemModel.Instance.GetItemByEntityID(listData[view.list.selectedIndex].ItemIds[0].EntityID);
        var dressInfo = DressModel.Instance.GetDressInfo(itemVo.ItemDefId);
        view.rare_img.url = "HandBookNew/rare_icon_" + dressInfo.Quality + ".png";
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        view.nameLab.color = StringUtil.HexToColor(txtColorArr[dressInfo.Quality - 1]);
        view.charmNum.text = "+" + dressInfo.CharmNum;
        view.typeLab.text = Lang.GetValue("dress_type_" + dressInfo.Type);
        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        var costVo = ItemModel.Instance.GetItemByEntityID(listData[view.list.selectedIndex].Prices[0].EntityID);
        view.img.url = ImageDataModel.Instance.GetIconUrl(costVo);
        var count = StorageModel.Instance.GetItemCount(costVo.ItemDefId);
        view.txt_num.text = TextUtil.ChangeCoinShow(count);
    }
    private void UpdateExp()
    {
        var lv = DressModel.Instance.GetShopLv();
        var curInfo = DressModel.Instance.GetShopLvInfo(lv);
        view.lvLab.text = lv.ToString();
        if (lv >= DressModel.Instance.shopLvList[DressModel.Instance.shopLvList.Count - 1].Id)
        {
            view.pro.max = 1;
            view.pro.value = 1;
            view.proLab.text = curInfo.Exp + "/" + curInfo.Exp;
        }
        else
        {
            var nextInfo = DressModel.Instance.GetShopLvInfo(lv + 1);
            var exp = DressModel.Instance.dressShopExp - curInfo.Exp;
            var max = nextInfo.Exp - curInfo.Exp;
            view.pro.max = max;
            view.pro.value = exp;
            view.proLab.text = exp + "/" + max;
        }
        
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

