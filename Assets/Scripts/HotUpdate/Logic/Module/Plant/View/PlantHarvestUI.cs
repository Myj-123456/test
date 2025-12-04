using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 收获ui
/// </summary>
public class PlantHarvestUI
{
    public fun_Scene.harvest harvestUi;
    private bool IsShowHarvest = false;
    public void Init()
    {
        harvestUi = (fun_Scene.harvest)fun_Scene.harvest.CreateInstance().asCom;
        harvestUi.pivotX = 0.5f;
        harvestUi.pivotY = 0.5f;
        harvestUi.pivotAsAnchor = true;
    }

    public void SetData(PlantVO landData)
    {
        harvestUi.data = landData;
    }

    public void Show(Vector3 position)
    {
        GRoot.inst.AddChildAt(harvestUi, 0);
        harvestUi.visible = true;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        //原点位置转换
        screenPos.y = Screen.height - screenPos.y;
        Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
        harvestUi.x = pt.x;
        harvestUi.y = pt.y - 120;

        harvestUi.scale = Vector2.zero;
        harvestUi.TweenScale(new Vector2(1, 1), 0.3f);
        IsShowHarvest = true;
        harvestUi.onClick.Add(OnHarvest);
        harvestUi.scissor.draggable = true;
        harvestUi.scissor.onDragStart.Add(OnDragStart);
        harvestUi.scissor.onDragEnd.Add(OnDragEnd);
        Stage.inst.onTouchBegin.Add(HandleInput);
    }

    private void HandleInput(EventContext context)
    {
        if (IsShowHarvest)
        {
            GObject obj = GRoot.inst.touchTarget;
            if (CheckIsTouchUI())
            {
                return;
            }
            else
            {
                if (!GuideModel.Instance.IsGuiding)
                {
                    Hide();
                }

            }
        }
    }

    private bool CheckIsTouchUI()
    {
        GObject obj = GRoot.inst.touchTarget;
        if (obj == null) return false;
        while (obj.parent != null && obj.parent.name != "componentLayer" && obj.parent != GRoot.inst)
        {
            obj = obj.parent;
        }
        if (obj != null && obj is fun_Scene.harvest)
        {
            return true;
        }
        return false;
    }

    public void Hide()
    {
        if (IsShowHarvest)
        {
            IsShowHarvest = false;
            if (harvestUi != null)
            {
                harvestUi.visible = false;
                harvestUi.onClick.Remove(OnHarvest);
                Stage.inst.onTouchBegin.Remove(HandleInput);
            }
            dragObject = null;
        }
        if (GuideModel.Instance.IsGuide)
        {
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        }
    }

    private void OnHarvest(EventContext context)
    {
        OnHarvest(context.sender as fun_Scene.harvest);
    }

    private void OnHarvest(fun_Scene.harvest harvest)
    {
        Hide();
        if (MyselfModel.Instance.fastHarvest)//搜索所有已经成熟的花发给服务器 收到之后表现收花效果
        {
            var harvestLandIds = SceneManager.Instance.GetHarvestLandIds();
            if (harvestLandIds.Count > 0)
            {
                PlantController.Instance.ReqHarvest(harvestLandIds.ToArray());
            }
        }
        else//只收当前选择的花，可以拖动花盆移动收花
        {
            PlantController.Instance.ReqHarvest(new uint[1] { (harvest.data as PlantVO).landId });
        }
    }

    private float _sourceX = 0;
    private float _sourceY = 0;
    private GComponent _sourceParent = null;
    private int _sourceLayer = 0;
    public GObject dragObject;
    private void OnDragStart(EventContext context)
    {
        //Debug.Log("onDragStart");
        Hide();
        var image_loader = context.sender as GLoader;
        dragObject = image_loader;
        _sourceX = image_loader.x;
        _sourceY = image_loader.y;
        _sourceParent = image_loader.parent;
        _sourceLayer = image_loader.parent.GetChildIndex(image_loader);
        image_loader.touchable = false;
        Vector2 pos = image_loader.LocalToRoot(new Vector2(image_loader.x, image_loader.y), GRoot.inst);
        GRoot.inst.AddChild(image_loader);
        image_loader.x = pos.x;
        image_loader.y = pos.y;
        SceneManager.Instance.IsDragging = true;
        harvestUi.visible = false;
    }

    private void OnDragEnd(EventContext context)
    {
        Debug.Log("OnDragEnd");
        var image_loader = context.sender as GLoader;
        image_loader.x = _sourceX;
        image_loader.y = _sourceY;
        _sourceParent.AddChildAt(image_loader, _sourceLayer);
        image_loader.touchable = true;
        SceneManager.Instance.IsDragging = false;
        DragEndReqHarvest();
        dragObject = null;
        harvestUi.scissor.onDragStart.Remove(OnDragStart);
        harvestUi.scissor.onDragEnd.Remove(OnDragEnd);
    }

    ///// <summary>
    ///// 拖拽完毕请求收花
    ///// </summary>
    private void DragEndReqHarvest()
    {
        var dragHarvestLandIds = PlantModel.Instance.dragHarvestLandIds;
        if (dragHarvestLandIds.Count > 0)
        {
            dragHarvestLandIds.Sort(); // 默认是升序排序
            PlantController.Instance.ReqHarvest(dragHarvestLandIds.ToArray());
            dragHarvestLandIds.Clear();
        }
        else
        {
            if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 26)//引导的是收获
            {
                Debug.Log("跳到引导种地第一步");
                GuideController.Instance.GuideStep(25,true);
            }
        }

    }
}
