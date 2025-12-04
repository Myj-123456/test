
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;

public class GuildPlantingOperateWindow
{

  
    
    private int position;
    public int flowerId;
    //private bool tweening;

    private fun_Guild_plant.ChooseFlowerUI chooseFlowerUI;
    private int spotMaxPage = 0;
    private int SPOT_PER_PAGE = 10;
    private int curPage = 1;
    private List<SeedCropVO> seedCropVOList;
    private int curSortType = 1;//排序类型 0：bookIs排序 1:库存数量
   
    private int lastSpotPage = 0;
    private bool isOneKeyPlantChecked = false;

    public GuildPlantingOperateWindow(fun_Guild_plant.ChooseFlowerUI view)
    {
        chooseFlowerUI = view;
       
        InitFlowerList(chooseFlowerUI.list_flower);
        AddEvent();
    }

    private void AddEvent()
    {
        chooseFlowerUI.btn_sort_1.onClick.Add(OnStoreSort);
        chooseFlowerUI.btn_sort_2.onClick.Add(OnTimeSort);
        chooseFlowerUI.btn_left.onClick.Add(OnLeft);
        chooseFlowerUI.btn_right.onClick.Add(OnRight);
        (chooseFlowerUI.searchFlower as fun_Scene.searchFlower).btn_search.onClick.Add(OnSearch);
    }




    public void OnShown(int data)
    {
        position = data;
        flowerId = 0;
        (chooseFlowerUI.searchFlower as fun_Scene.searchFlower).input_search.text = "";
        Update();
    }

    private void InitFlowerList(GList list_flower)
    {
        list_flower.itemRenderer = ItemRender;
        list_flower.SetVirtual();
        list_flower.onClickItem.Add(OnItemClick);
        list_flower.scrollPane.onScroll.Add(OnScroll);

        //LongPressGesture gesture = new LongPressGesture(list_flower);
        //gesture.once = true;
        //gesture.trigger = 0.05f;
        //gesture.onAction.Add(OnLongPress);
    }

    private void ItemRender(int index, GObject item)
    {
        var cell = item as fun_Guild_plant.planting_ope_item;
        var seedCropVO = seedCropVOList[index];
        cell.data = seedCropVO;
        cell.image_loader.url = ImageDataModel.Instance.GetIconUrl(seedCropVO.item);
        cell.name_txt.text = Lang.GetValue(seedCropVO.item.Name);
        var color = FlowerHandbookModel.Instance.GetStaticSeedCondition(seedCropVO.flowerId).FlowerQuality;
        cell.quality.selectedIndex = color;
        var count = StorageModel.Instance.GetItemCount(seedCropVO.item.ItemDefId);
        //cell.count_txt.visible = count > 0;
        //cell.count_txt.text = "x" + count;
    }

    private void ShowPlantChooseFlowerUI(bool isShow, Action action = null)
    {
        //var animTime = 0.3f;
        //if (isShow)
        //{
        //    if (viewSkin.ui_chooseFlower.visible) return;
        //    viewSkin.ui_chooseFlower.visible = true;
        //    Update();
        //    viewSkin.ui_chooseFlower.TweenMoveY(GRoot.inst.height - viewSkin.ui_chooseFlower.height, animTime).SetEase(EaseType.BackOut);
            
        //}
        //else
        //{
        //    if (!viewSkin.ui_chooseFlower.visible) return;
        //    tweening = true;
        //    viewSkin.ui_chooseFlower.TweenMoveY(GRoot.inst.height, animTime).SetEase(EaseType.CubicOut).OnComplete(() =>
        //    {
        //        tweening = false;
        //        viewSkin.ui_chooseFlower.visible = false;
        //        UIManager.Instance.CloseWindow(UIName.GuildPlantingOperateWindow);
        //        action?.Invoke();
        //    });
        //}
    }

    public void Update()
    {
        this.curSortType = Saver.GetInt(Saver.Plantsortvalue);
        this.UpdateSpeeds();
        chooseFlowerUI.list_flower.selectedIndex = -1;
    }

    private void OnItemClick(EventContext context)
    {
        var cell = context.data as fun_Guild_plant.planting_ope_item;
        var seedCropVO = cell.data as SeedCropVO;
        flowerId = seedCropVO.flowerId;
        //ShowPlantChooseFlowerUI(false);
    }

    private void OnScroll()
    {
        if (lastSpotPage != chooseFlowerUI.list_flower.scrollPane.currentPageX)
        {
            lastSpotPage = chooseFlowerUI.list_flower.scrollPane.currentPageX;
            curPage = lastSpotPage + 1;
            UpdatePageInfo();
        }
    }

    private void OnStoreSort()
    {
        curSortType = 1;
        Saver.SaveAsString(Saver.Plantsortvalue, curSortType);
        UpdateSpeeds();
    }

    private void OnTimeSort()
    {
        curSortType = 0;
        Saver.SaveAsString(Saver.Plantsortvalue, curSortType);
        UpdateSpeeds();
    }

    private void OnLeft()
    {
        if (curPage <= 1) return;
        curPage -= 1;
        chooseFlowerUI.list_flower.scrollPane.SetCurrentPageX(curPage - 1, true);
    }

    private void OnRight()
    {
        if (curPage >= spotMaxPage) return;
        curPage += 1;
        chooseFlowerUI.list_flower.scrollPane.SetCurrentPageX(curPage - 1, true);
    }

    private void UpdatePageInfo()
    {
        chooseFlowerUI.txt_pageNum.text = curPage + "/" + spotMaxPage;
    }

    /**更新种子 */
    private void UpdateSpeeds(string filter = "")
    {
        var str = (chooseFlowerUI.searchFlower as fun_Scene.searchFlower).input_search.text.Trim();
        seedCropVOList = StorageModel.Instance.GetSortedSeedList(this.curSortType, str);
        chooseFlowerUI.list_flower.numItems = seedCropVOList.Count;
        spotMaxPage = (int)Mathf.Ceil(seedCropVOList.Count / (float)SPOT_PER_PAGE);
        UpdatePageInfo();
    }

    private void CloseView()
    {
        ShowPlantChooseFlowerUI(false);
    }

    private void OnSearch()
    {
        UpdateSpeeds((chooseFlowerUI.searchFlower as fun_Scene.searchFlower).input_search.text);
    }
}

