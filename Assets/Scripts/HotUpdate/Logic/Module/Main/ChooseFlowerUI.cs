
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using ADK;
using System.Collections.Generic;
using System;
using System.Collections;

public class ChooseFlowerUI : BaseUI
{

    private fun_Scene.ChooseFlowerUI chooseFlowerUI;
    private int spotMaxPage = 0;
    private int SPOT_PER_PAGE = 10;
    private int curPage = 1;
    private List<SeedCropVO> seedCropVOList;
    private int curSortType = 1;//排序类型 0：bookIs排序 1:库存数量

    private int lastSpotPage = 0;
    private bool isOneKeyPlantChecked = false;

    public void Init(fun_Scene.ChooseFlowerUI chooseFlowerUI)
    {
        this.chooseFlowerUI = chooseFlowerUI;
        InitFlowerList(chooseFlowerUI.list_flower);
        chooseFlowerUI.toggleOneKeyPlant.select.selectedIndex = 1;
        AddEvent();
    }

    private void AddEvent()
    {
        chooseFlowerUI.btn_sort_1.onClick.Add(OnStoreSort);
        chooseFlowerUI.btn_sort_2.onClick.Add(OnTimeSort);
        chooseFlowerUI.btn_left.onClick.Add(OnLeft);
        chooseFlowerUI.btn_right.onClick.Add(OnRight);
        chooseFlowerUI.toggleOneKeyPlant.onClick.Add(OnToggleOneKeyPlant);
        chooseFlowerUI.searchFlower.btn_search.onClick.Add(OnSearch);
    }

    private void InitFlowerList(GList list_flower)
    {
        list_flower.itemRenderer = ItemRender;
        list_flower.SetVirtual();
        list_flower.onClickItem.Add(OnItemClick);
        list_flower.scrollPane.onScroll.Add(OnScroll);
    }

    private GObject dragObject;
    private Vector2 startPos;
    private void OnDragStart(EventContext context)
    {
        dragObject = context.sender as GObject;
        context.PreventDefault();
        if (dragObject != null)
        {
            startPos = context.inputEvent.position;
            var dragAgent = DragDropManager.inst.dragAgent;
            dragAgent.SetScale(0.5f, 0.5f);
            dragAgent.onDragEnd.Add(OnDragEnd);
            DragDropManager.inst.StartDrag(dragObject, dragObject.icon, dragObject.text);
            var flowerId = (dragObject.parent.data as SeedCropVO).flowerId;
            PlantModel.Instance.dragFlowerId = flowerId;
            SceneManager.Instance.IsDragging = true;
            EventManager.Instance.DispatchEvent(SystemEvent.HidePlantUI);
            if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 19)//引导的是种植
            {
                EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
            }
        }
    }

    private void OnDragEnd(EventContext context)
    {
        SceneManager.Instance.IsDragging = false;
        if (startPos == null) return;
        var dif = Vector2.Distance(startPos, context.inputEvent.position);
        if (dif <= 20)
        {
            PlantModel.Instance.dragFlowerId = 0;
            if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 19)//引导的是种植
            {
                Debug.Log("跳到引导种地第一步");
                GuideController.Instance.GuideStep(17, true);
            }
            return;
        }
        DragEndReqPlant();
        PlantModel.Instance.dragFlowerId = 0;
        UIManager.Instance.ShowOrHideMainUI(true, true, true);
        dragObject = null;
        DragDropManager.inst.dragAgent.onDragStart.Remove(OnDragStart);
        DragDropManager.inst.dragAgent.onDragEnd.Remove(OnDragEnd);
    }

    public void Update()
    {
        this.curSortType = Saver.GetInt(Saver.Plantsortvalue);
        SelectBtn();
        this.UpdateSpeeds();
    }

    /// <summary>
    /// 显示缓动完毕回调
    /// </summary>
    public void OnShowTweenCom()
    {
        ShowTargetWeakGuide();
    }

    /// <summary>
    /// 检测弱引导
    /// </summary>
    /// <returns></returns>
    private void ShowTargetWeakGuide()
    {
        if (GuideModel.Instance.IsCancelGuide) return;
        if (chooseFlowerUI.list_flower.numItems <= 0) return;
        var taskData = TaskModel.Instance.mainTask;
        if (taskData != null)
        {
            var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
            if (taskInfo != null && taskInfo.TaskType == 1)//如果是类型1：收获XX花XX次
            {
                var flowerId = taskInfo.TypeParam;
                if (flowerId <= 0)//不指定花id，默认选中第一个即可
                {
                    GuideController.Instance.ShowTargetWeakGuide(chooseFlowerUI.list_flower.GetChildAt(0), Vector2.zero);
                    return;
                }
                var list_flowerInd = flowerId <= 0 ? 0 : seedCropVOList.FindIndex(0, (v => { return v.flowerId == flowerId; }));
                if (list_flowerInd >= 0)
                {
                    chooseFlowerUI.list_flower.ScrollToView(list_flowerInd);
                    int index = chooseFlowerUI.list_flower.ItemIndexToChildIndex(list_flowerInd);
                    var target = chooseFlowerUI.list_flower.GetChildAt(index);
                    GuideController.Instance.ShowTargetWeakGuide(target, Vector2.zero);
                }
            }
        }
    }

    private void ItemRender(int index, GObject item)
    {
        fun_Scene.plant_grid cell = item as fun_Scene.plant_grid;
        var seedCropVO = seedCropVOList[index];
        cell.data = seedCropVO;
        cell.image_loader.url = ImageDataModel.Instance.GetIconUrl(seedCropVO.item);
        cell.name_txt.text = Lang.GetValue(seedCropVO.item.Name);
        cell.level_txt.text = seedCropVO.level.ToString();
        var color = FlowerHandbookModel.Instance.GetStaticSeedCondition(seedCropVO.flowerId).FlowerQuality;
        cell.quality.selectedIndex = color;
        var count = StorageModel.Instance.GetItemCount(seedCropVO.item.ItemDefId);
        cell.count_txt.visible = count > 0;
        cell.count_txt.text = "x" + count;

        //子项拖拽
        cell.image_loader.draggable = true;
        cell.image_loader.onDragStart.Add(OnDragStart);
    }

    ///// <summary>
    ///// 拖拽完毕请求种植
    ///// </summary>
    private void DragEndReqPlant()
    {
        var dragPlantLandIds = PlantModel.Instance.dragPlantLandIds;
        var dragFlowerId = PlantModel.Instance.dragFlowerId;
        if (dragPlantLandIds.Count > 0 && dragFlowerId > 0)
        {
            dragPlantLandIds.Sort(); // 默认是升序排序
            PlantController.Instance.ReqPlantLand(dragPlantLandIds.ToArray(), dragFlowerId);
            dragPlantLandIds.Clear();
        }
        else
        {
            if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 19)//引导的是种植
            {
                Debug.Log("跳到引导种地第一步");
                GuideController.Instance.GuideStep(17, true);
            }
        }
    }


    private void OnItemClick(EventContext context)
    {
        if (SceneManager.Instance.IsDragging) return;
        UIManager.Instance.ShowOrHideMainUI(true, true, true);
        SceneManager.Instance.IsDragging = false;
        var cell = context.data as fun_Scene.plant_grid;
        if (!isOneKeyPlantChecked)
        {
            var plantVO = PlantModel.Instance.plantVO;
            if (plantVO != null)
            {
                PlantController.Instance.ReqPlantLand(new uint[1] { plantVO.landId }, (cell.data as SeedCropVO).flowerId);
            }
        }
        else
        {
            var lands = PlantModel.Instance.GetCanPlantLands();
            if (lands.Count > 0)
            {
                PlantController.Instance.ReqPlantLand(lands.ToArray(), (cell.data as SeedCropVO).flowerId);
            }
        }

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
        SelectBtn();
        Saver.SaveAsString(Saver.Plantsortvalue, curSortType);
        UpdateSpeeds();
    }

    private void OnTimeSort()
    {
        curSortType = 0;
        SelectBtn();
        Saver.SaveAsString(Saver.Plantsortvalue, curSortType);
        UpdateSpeeds();
    }

    private void SelectBtn()
    {
        if (curSortType == 0)
        {
            chooseFlowerUI.btn_sort_1.c1.selectedIndex = 0;
            chooseFlowerUI.btn_sort_2.c1.selectedIndex = 1;
        }
        else if (curSortType == 1)
        {
            chooseFlowerUI.btn_sort_1.c1.selectedIndex = 1;
            chooseFlowerUI.btn_sort_2.c1.selectedIndex = 0;
        }
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

    private void OnToggleOneKeyPlant()
    {
        if (!MyselfModel.Instance.IsVip())
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
            return;
        }
        isOneKeyPlantChecked = !isOneKeyPlantChecked;
        chooseFlowerUI.toggleOneKeyPlant.select.selectedIndex = isOneKeyPlantChecked ? 0 : 1;
    }

    private void OnSearch()
    {
        UpdateSpeeds(chooseFlowerUI.searchFlower.input_search.text);
    }

    /**更新种子 */
    private void UpdateSpeeds(string filter = "")
    {
        var str = chooseFlowerUI.searchFlower.input_search.text.Trim();
        seedCropVOList = StorageModel.Instance.GetSortedSeedList(this.curSortType, str);
        chooseFlowerUI.list_flower.numItems = seedCropVOList.Count;
        spotMaxPage = (int)Mathf.Ceil(seedCropVOList.Count / (float)SPOT_PER_PAGE);
        UpdatePageInfo();
    }

    private void UpdatePageInfo()
    {
        chooseFlowerUI.txt_pageNum.text = curPage + "/" + spotMaxPage;
    }

}
