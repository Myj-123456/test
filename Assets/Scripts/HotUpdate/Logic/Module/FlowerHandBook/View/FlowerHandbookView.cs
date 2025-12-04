using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Elida.Config;
using DG.Tweening;
public class FlowerHandbookView : BaseView
{
    private fun_CultivationManual_new.handbook_brandNew view;
    private fun_CultivationManual_new.bgAnim viewSkin;

    private fun_CultivationManual_new.FlowerHandBookView UIView;

    private int curGroup;

    private List<int> tabData;

    private List<fun_CultivationManual_new.filter_item> filterItemArr;

    private List<fun_CultivationManual_new.filter_item> filterStyleArr;
    /**筛选item的文本 */
    private string[] itemTxtStr = new string[] { "handBook_4", "handBook_5", "handBook_6", "handBook_3", "handBook_7", "handBook_8" };

    private string[] txtColorArr = new string[] { "#209323",  "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };

    private int spotMaxPage = 0;

    private float SPOT_PER_PAGE = 10;

    private BookType typeValue;

    private int maxPage;
    private int lastSpotPage = 0;

    private VaseHandbookView vaseView;

    private Dictionary<BookType, int> lastPageHome;
    public FlowerHandbookView()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.FlowerHandBookView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        UIView = ui as fun_CultivationManual_new.FlowerHandBookView;
        view = UIView.ui;

        viewSkin = view.context;
        SetBg(view.fullScreenBg,"HandBookNew/ELIDA_xhshouce_bg03.jpg");
        SetBg(viewSkin.bg, "HandBookNew/ELIDA_xhshouce_juanzhou01.png");
        vaseView = new VaseHandbookView(viewSkin.vasePanel);
        StringUtil.SetBtnTab(viewSkin.panel_filter.btn_search, Lang.GetValue("pray_8"));
        StringUtil.SetBtnTab(view.close_btn, Lang.GetValue("mail_button_return"));

        StringUtil.SetBtnTab(viewSkin.btn_filter, Lang.GetValue("pray_8"));
        filterItemArr = new List<fun_CultivationManual_new.filter_item>();
        filterStyleArr = new List<fun_CultivationManual_new.filter_item>();
        int type = 1;
        lastPageHome = new Dictionary<BookType, int>();
        fun_CultivationManual_new.filter_item item;
        while (viewSkin.panel_filter.GetChild("filter_type_" + type) != null)
        {
            item = viewSkin.panel_filter.GetChild("filter_type_" + type) as fun_CultivationManual_new.filter_item;
            if (item != null)
            {
                filterItemArr.Add(item);
                item.titleLab.text = Lang.GetValue(itemTxtStr[type - 1]);
                item.onClick.Add(ClickColFilterBtn);
                item.data = type;

            }
            var item1 = viewSkin.panel_filter.GetChild("filter_style_" + type) as fun_CultivationManual_new.filter_item;
            if (item1 != null)
            {
                filterStyleArr.Add(item1);
                item1.titleLab.text = Lang.GetValue("style_" + type);
                item1.onClick.Add(ClickStyleFilterBtn);
                item1.data = type;

            }
            type++;
        }

        SyncLastPage(0);
        SyncLastPage(0, BookType.FLOWER);

        viewSkin.list.itemRenderer = ItemRender;
        viewSkin.list.SetVirtual();
        viewSkin.list.onClickItem.Add(OnItemClick);

        viewSkin.page_list.itemRenderer = PageNumItemRenderer;
        //viewSkin.page_list.onClickItem.Add(ChangePage);

        view.help_btn.onClick.Add(() =>
        {
            HideFilterPanel();
        });
        InitFilterPanel(true);

        viewSkin.leftBtn.onClick.Add(SpotLeft);
        viewSkin.rightBtn.onClick.Add(SpotRight);

        viewSkin.flowerTab.onClick.Add(() =>
        {
            if (typeValue == BookType.FLOWER) return;
            typeValue = BookType.FLOWER;
            OnBookTypeChange();
        });
        
        viewSkin.vaseTab.onClick.Add(() =>
        {
            if (typeValue == BookType.VASE) return;
            typeValue = BookType.VASE;
            OnBookTypeChange();
        });

        StringUtil.SetBtnTab(viewSkin.flowerTab, Lang.GetValue("flowerType"));
        StringUtil.SetBtnTab3(viewSkin.flowerTab, Lang.GetValue("flowerType"));
        //StringUtil.SetBtnTab(viewSkin.succulentTab, Lang.GetValue("succulentType"));
        StringUtil.SetBtnTab(viewSkin.vaseTab, Lang.GetValue("text_grandma1"));
        StringUtil.SetBtnTab3(viewSkin.vaseTab, Lang.GetValue("text_grandma1"));

        viewSkin.flowerTab.selected = true;
        //viewSkin.succulentTab.selected = false;
        viewSkin.vaseTab.selected = false;

        viewSkin.list.scrollPane.onScroll.Add(ChecktoUpdate);



        viewSkin.page_list.scrollPane.onScroll.Add(() =>
        {
            if(lastSpotPage != viewSkin.page_list.scrollPane.currentPageX)
            {
                lastSpotPage = viewSkin.page_list.scrollPane.currentPageX;
                RenderSpotList();
            }
        });

        view.close_btn.onClick.Add(() =>{
            UIManager.Instance.ClosePanel(UIName.FlowerHandbookView);
        });

        typeValue = BookType.FLOWER;
        viewSkin.panel_filter.status.selectedIndex = 0;
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpgrade, UpdateSelectInfo);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpGradeBreakLv, UpdateSelectInfo);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.SeedUpGradeGrade, UpdateSelectInfo);
        EventManager.Instance.AddEventListener(FlowerHandBookEvent.ExchangeFlowerCard, UpdateSelectInfo);
    }

    public override void OnShown()
    {
        base.OnShown();
        viewSkin.page.Play();
        view.left.moveLeft.Play();
        UIView.animView.Play();
        // 其他打开面板的逻辑
        InitFilterPanel(false);
        //FlowerHandbookModel.Instance.SortBookDataAgain();
        UpdateHandbookByFilter();
        //viewSkin.lb_starnum.text = FlowerStarModel.Instance.GetStarCount() + "";
    }

    private void UpdateFlowerSum()
    {
        viewSkin.myFlowerLvSumTxt.text = StorageModel.Instance.GetSeedTotalCount().ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void ChecktoUpdate()
    {
        if (!CheckInSamePage(viewSkin.list.scrollPane.currentPageX))
        {
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        if (!CheckInSamePage(viewSkin.list.scrollPane.currentPageX))
        {
            SpotCurrent();
            //viewSkin.pageTxt.text = (viewSkin.list.scrollPane.currentPageX + 1) + "/" + maxPage;
            ScrollToPage(viewSkin.list.scrollPane.currentPageX, true);


        }
       
    }

    private void ScrollToPage(int page,bool tipSound = false)
    {
        if (!CheckInSamePage(page))
        {
            SyncLastPage(page, typeValue);
            float curPage = Mathf.Floor(page / SPOT_PER_PAGE);
            viewSkin.page_list.scrollPane.SetCurrentPageX((int)curPage, false);
            RenderSpotList();
            if (tipSound)
            {

            }
        }
    }

    private void RenderSpotList()
    {
        viewSkin.leftBtn.alpha = viewSkin.page_list.scrollPane.currentPageX > 0 ? 1f : 0.5f;
        viewSkin.rightBtn.alpha = viewSkin.page_list.scrollPane.currentPageX < spotMaxPage - 1 ? 1f : 0.5f;
    }

    private void SpotCurrent()
    {
        for(int i = 0;i < viewSkin.page_list.numItems;i++)
        {
            common_New.PageListItem_new1 cell = viewSkin.page_list.GetChildAt(viewSkin.page_list.ItemIndexToChildIndex(i)) as common_New.PageListItem_new1;
            cell.status.selectedIndex = i == viewSkin.list.scrollPane.currentPageX ? 1 : 0;
        }
    }

    private bool CheckInSamePage(int target)
    {
        if (lastPageHome.ContainsKey(typeValue))
        {
            return lastPageHome[typeValue] == target; 
        }
        return false;
    }

    private int GetLastPage(BookType type = BookType.FLOWER)
    {
        return lastPageHome[type];
    }

    private void SyncLastPage(int value,BookType type = BookType.FLOWER)
    {
        if (lastPageHome.ContainsKey(type))
        {
            lastPageHome[type] = value;

        }
        else
        {
            lastPageHome.Add(type, value);
        }
        
    }

    private void SpotLeft()
    {
        HideFilterPanel();
        if (viewSkin.page_list.scrollPane.currentPageX <= 0)
        {
            return;
        }
        viewSkin.page_list.scrollPane.SetCurrentPageX(viewSkin.page_list.scrollPane.currentPageX - 1, true);
    }

    private void SpotRight()
    {
        HideFilterPanel();
        if (viewSkin.page_list.scrollPane.currentPageX >= spotMaxPage - 1)
        {
            return;
        }
        viewSkin.page_list.scrollPane.SetCurrentPageX(viewSkin.page_list.scrollPane.currentPageX + 1, true);
    }

    private void ItemRender(int index, GObject item)
    {
        fun_CultivationManual_new.handbook_brandNew_item cell = item as fun_CultivationManual_new.handbook_brandNew_item;
        StaticHandbook data = FlowerHandbookModel.Instance.RetrievePageData()[index];
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(data.FlowerId);
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(data.FlowerId);
        StaticSeedCondition condition = FlowerHandbookModel.Instance.GetStaticSeedCondition(data.FlowerId);
        var plantCrop = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null?1: exp.level));

        object[] param = new object[] { data, itemData, exp, plantCrop, condition,index };
        cell.data = param;
        cell.img1.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemData);
        cell.img1.visible = true;
        //cell.img1.scaleY = 1;
        cell.name_txt.visible = true;

        //cell.spine.url = "langyahua";
        //cell.spine.loop = true;
        //cell.spine.animationName = "step_3_idle";

        int cardId = condition.TaskId;
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        //bool seedLock = true;
        
        cell.decLab.text = Lang.GetValue("rare_lab");
        Color lvColor = StringUtil.HexToColor(txtColorArr[condition.FlowerQuality - 1]);
        cell.decLab.strokeColor = lvColor;
        cell.name_txt.color = lvColor;
        cell.style_img.url = "HandBookNew/style_icon_" + condition.StyleType + ".png";

        int count = StorageModel.Instance.GetItemCount(condition.SeedId);
        if (condition.UnlockAccessible)
        {
            cell.img1.grayed = false;
            if (condition.AlreadyCulitivated)
            {
                
                cell.statius.selectedIndex = 0;
                cell.seed_img.url = ImageDataModel.Instance.GetIconUrlByItemId(condition.SeedId);
                if (exp != null)
                {
                    
                    cell.level_txt.text = (exp.level).ToString();
                    var gradeInfo = FLowerModel.Instance.GetFlowerGradeConfig(condition.FlowerQuality, exp.gradeLv);
                    if (PlantModel.Instance.GetPlantCropMax(condition.LevelMould + "#" + (exp.level + 1)))
                    {
                        cell.level_up.visible = false;
                        
                    }
                    else
                    {
                        var nextPlantCrop = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" +  (exp.level + 1));
                        var haveCount = StorageModel.Instance.GetItemCount(condition.SeedId);
                        cell.seedPro.max = nextPlantCrop.SeedCost;
                        cell.seedPro.value = haveCount;

                        var leveUp = true;
                        
                        leveUp = (count >= nextPlantCrop.SeedCost && MyselfModel.Instance.gold >= nextPlantCrop.GoldCost);
                        
                        cell.level_up.visible = leveUp;
                    }
           
                }
            }
            else
            {
               
                cell.statius.selectedIndex = 2;
                cell.noitem_txt.text = Lang.GetValue("text_book9");
                cell.haveLab.text = Lang.GetValue("Vip_store_txt5");
                cell.level_up.visible = false;
            }
        }
        else
        {
            cell.statius.selectedIndex = 1;
            cell.img1.grayed = true;
            cell.lockLv_txt.text = Lang.GetValue(data.Curtips);
            cell.level_up.visible = false;
        }
        cell.bg_1.url = "HandBookNew/bg_new_" + condition.FlowerQuality + ".png";
       
    }

    private void PageNumItemRenderer(int index, GObject item)
    {
        item.data = index;
        var cell = item as common_New.PageListItem_new1;
        cell.n5.onClick.Add(ChangePage);
    }

    private void ChangePage(EventContext context)
    {
        HideFilterPanel();
        int numIndex = (int)(context.sender as GLoader).parent.data;
        viewSkin.list.scrollPane.SetCurrentPageX(numIndex, false);
    }

    //private void ChangePage(EventContext context)
    //{
    //    HideFilterPanel();
    //    int numIndex = (int)(context.data as common.PageListItem_new1).data;
    //    viewSkin.list.scrollPane.SetCurrentPageX(numIndex, false);
    //}

    private void InitFilterPanel(bool init)
    {
        fun_CultivationManual_new.handbook_filter filter = viewSkin.panel_filter;
        filter.visible = false;
        filter.filter_had.img_selected.visible = false;
        filter.filter_unhaved.img_selected.visible = false;
        filter.search_input_text.text = "";
        ChangeFilterSel(null);

        if (!init)
        {
            return;
        }
        filter.filter_had.titleLab.text = Lang.GetValue("handBook_1");
        filter.filter_unhaved.titleLab.text = Lang.GetValue("handBook_2");
        viewSkin.btn_filter.onClick.Add(() => {
            filter.visible = !filter.visible;
        });
        filter.btn_search.onClick.Add(() => {
            UpdateHandbookByFilter();
        });
        filter.filter_had.onClick.Add(() => {
            filter.filter_had.img_selected.visible = !filter.filter_had.img_selected.visible;
            filter.filter_unhaved.img_selected.visible = false;
            UpdateHandbookByFilter();
        });
        filter.filter_unhaved.onClick.Add(() => {
            filter.filter_unhaved.img_selected.visible = !filter.filter_unhaved.img_selected.visible;
            filter.filter_had.img_selected.visible = false;
            UpdateHandbookByFilter();
        });

    }

    private void UpdateHandbookByFilter()
    {
        fun_CultivationManual_new.handbook_filter filter = viewSkin.panel_filter;
        int had = 0,color = 0,style = 0;
        string name = "";
        if (filter.filter_had.img_selected.visible)
        {
            had = 1;
        }else if (filter.filter_unhaved.img_selected.visible)
        {
            had = 2;
        }
        fun_CultivationManual_new.filter_item item = filterItemArr.Find((fun_CultivationManual_new.filter_item ele) =>
        {
            return ele.img_selected.visible;
        });
        fun_CultivationManual_new.filter_item item1 = filterStyleArr.Find((fun_CultivationManual_new.filter_item ele) =>
        {
            return ele.img_selected.visible;
        });
        if (item != null) color = (int)item.data;

        if (item1 != null) style = (int)item1.data;

        if (filter.search_input_text.text != "")
        {
            name = filter.search_input_text.text;
        }

        if(typeValue == BookType.VASE)
        {
            vaseView.UpdateHandbookByFilter(had, name, color);
            return;
        }

        FlowerHandbookModel.Instance.FilterBookData( had, color, name, style);

        UpdateContentAndPage();
    }

    private void UpdateContentAndPage()
    {
        UpdateSelectInfo();
        SpotCurrent();
        viewSkin.list.scrollPane.currentPageX = 0;
    }

    private void UpdateSelectInfo()
    {
        if (typeValue != BookType.FLOWER)
        {
            return;
        }
        List<StaticHandbook> datList = FlowerHandbookModel.Instance.RetrievePageData();
        maxPage = (int)Mathf.Ceil(datList.Count / FlowerHandbookModel.ITEM_COUNT_PER_SPOT);
        viewSkin.list.numItems = datList.Count;
        spotMaxPage = (int)Mathf.Ceil(datList.Count / SPOT_PER_PAGE);
        viewSkin.page_list.numItems = maxPage;
        
        RenderSpotList();
        UpdateFlowerSum();
    }

    private void HideFilterPanel()
    {
        viewSkin.panel_filter.visible = false;
    }

    private void ClickColFilterBtn(EventContext context)
    {
        fun_CultivationManual_new.filter_item clickTarget = context.sender as fun_CultivationManual_new.filter_item;
        bool isSel = clickTarget.img_selected.visible;
        ChangeFilterSel(isSel ? null : clickTarget);
        UpdateHandbookByFilter();
    }

    private void ChangeFilterSel(fun_CultivationManual_new.filter_item sel)
    {
        foreach (fun_CultivationManual_new.filter_item item in filterItemArr)
        {
            if (item == sel)
            {
                item.img_selected.visible = true;
            }
            else
            {
                item.img_selected.visible = false;
            }
        }
    }

    private void ClickStyleFilterBtn(EventContext context)
    {
        fun_CultivationManual_new.filter_item clickTarget = context.sender as fun_CultivationManual_new.filter_item;
        bool isSel = clickTarget.img_selected.visible;
        ChangeFilterStyle(isSel ? null : clickTarget);
        UpdateHandbookByFilter();
    }

    private void ChangeFilterStyle(fun_CultivationManual_new.filter_item sel)
    {
        foreach (fun_CultivationManual_new.filter_item item in filterStyleArr)
        {
            if (item == sel)
            {
                item.img_selected.visible = true;
            }
            else
            {
                item.img_selected.visible = false;
            }
        }
    }

    private void OnBookTypeChange()
    {
        HideFilterPanel();
        int currType = (int)typeValue;
        viewSkin.pageStatus.selectedIndex = currType;
        viewSkin.flowerTab.selected = typeValue == BookType.FLOWER;
        
        viewSkin.vaseTab.selected = typeValue == BookType.VASE;
        if(typeValue == BookType.VASE)
        {
            vaseView.UpdateHandbookByFilter();
        }
        else
        {
            FlowerHandbookModel.Instance.FilterBookData( 0, 0, "");
            UpdateContentAndPage();
        }
    }

    private void OnItemClick(EventContext context)
    {
        int index = (int)((context.data as fun_CultivationManual_new.handbook_brandNew_item).data as object[])[5];
        object[] obj = new object[] { index, typeValue };
        UIManager.Instance.OpenPanel<FlowerHandbookTipView>(UIName.FlowerHandbookTipView,UILayer.SecondUI, obj);
    }
}

public enum BookType
{
    FLOWER,
    SUCCULENT,
    VASE
}

