using ADK;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantWateringUI
{
    private bool IsShowPlantWatering = false;
    public fun_Scene.plant_OneKeyWatering plantOneKeyWateringUi;
    private PlantVO plantVO;
    private bool isTriggerClick = false;
    public void Init()
    {
        plantOneKeyWateringUi = (fun_Scene.plant_OneKeyWatering)fun_Scene.plant_OneKeyWatering.CreateInstance().asCom;
        plantOneKeyWateringUi.pivotX = 0.5f;
        plantOneKeyWateringUi.pivotY = 0.5f;
        plantOneKeyWateringUi.pivotAsAnchor = true;
        plantOneKeyWateringUi.btn_watering.image_loader.name = "wateringDrag";
        AddEvent();
    }

    private void AddEvent()
    {
        plantOneKeyWateringUi.btn_watering.onTouchBegin.Add(OnWateringBegin);
        plantOneKeyWateringUi.btn_watering.onClick.Add(OnWatering);
        plantOneKeyWateringUi.btn_oneKeyWatering.onClick.Add(OnOneKeyWatering);
        AddDrag();
    }

    public GLoader dragObject;
    private void AddDrag()
    {
        var image_loader = plantOneKeyWateringUi.btn_watering.image_loader;
        image_loader.draggable = true;
        image_loader.onDragStart.Add(OnDragStart);
    }

    private void OnDragStart(EventContext context)
    {
        context.PreventDefault();
        Hide();
        dragObject = plantOneKeyWateringUi.btn_watering.image_loader;
        startPos = context.inputEvent.position;
        var dragAgent = DragDropManager.inst.dragAgent;
        dragAgent.SetScale(0.4f, 0.4f);
        dragAgent.onDragEnd.Add(OnDragEnd);
        DragDropManager.inst.StartDrag(dragObject, dragObject.icon, dragObject.text);
        SceneManager.Instance.IsDragging = true;
        if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 23)//引导的是浇水
        {
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        }
    }

    private Vector2 startPos;
    private void OnDragEnd(EventContext context)
    {
        SceneManager.Instance.IsDragging = false;
        dragObject = null;
        if (startPos == null) return;
        var dif = Vector2.Distance(startPos, context.inputEvent.position);
        if (dif <= 20)
        {
            Coroutiner.StartCoroutine(GuideCheck());
            return;
        }
        DragEndReqWatering();
        DragDropManager.inst.dragAgent.onDragStart.Remove(OnDragStart);
        DragDropManager.inst.dragAgent.onDragEnd.Remove(OnDragEnd);
    }

    private IEnumerator GuideCheck()
    {
        if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 23)//引导的是浇水
        {
            yield return new WaitForSeconds(0.1f);
            if (isTriggerClick)
            {
                Debug.Log("GuideCheck isTriggerClick不引导");
                yield break;
            }
            Debug.Log("dif<=20重新引导浇水21");
            GuideController.Instance.GuideStep(21, true);
            isTriggerClick = false;
        }
    }

    private void DragEndReqWatering()
    {
        var dragWateingLandIds = PlantModel.Instance.dragWateingLandIds;
        if (dragWateingLandIds.Count > 0)
        {
            dragWateingLandIds.Sort(); // 默认是升序排序
            PlantController.Instance.ReqWater(dragWateingLandIds.ToArray(), false, false);
            dragWateingLandIds.Clear();
        }
        else
        {
            if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 23)//引导的是浇水
            {
                Debug.Log("DragEndReqWatering重新引导浇水21");
                GuideController.Instance.GuideStep(21, true);
            }
        }

    }


    private void OnWateringBegin()
    {
        isTriggerClick = false;
    }

    private void OnWatering()
    {
        isTriggerClick = true;
        Hide();
        if (plantVO != null)
        {
            PlantController.Instance.ReqWater(new uint[1] { plantVO.landId });
        }
        if (GuideModel.Instance.IsGuide && GuideModel.Instance.curGuideStep == 23)//引导的是浇水
        {
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        }
    }

    private void OnOneKeyWatering()
    {
        Hide();
        if (!MyselfModel.Instance.IsVip())
        {
            UIManager.Instance.OpenWindow<RechargeMainView>(UIName.RechargeMainView, 1);
            return;
        }
        var lands = PlantModel.Instance.GetUnWateringLands();
        lands.Sort();
        PlantController.Instance.ReqWater(lands.ToArray());
    }
    public void Show(Vector3 position, PlantVO plantVO)
    {
        this.plantVO = plantVO;
        UIManager.Instance.GetLayer(UILayer.SceneUI).AddChild(plantOneKeyWateringUi);
        plantOneKeyWateringUi.visible = true;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        //原点位置转换
        screenPos.y = Screen.height - screenPos.y;
        Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
        plantOneKeyWateringUi.x = pt.x;
        plantOneKeyWateringUi.y = pt.y - 120;
        plantOneKeyWateringUi.scale = Vector2.zero;
        plantOneKeyWateringUi.TweenScale(new Vector2(1, 1), 0.3f);

        IsShowPlantWatering = true;
        Stage.inst.onTouchBegin.Add(HandleInput);
        plantOneKeyWateringUi.btn_oneKeyWatering.grayed = !MyselfModel.Instance.IsVip();
    }

    private void HandleInput(EventContext context)
    {
        if (GuideModel.Instance.IsGuiding) return;
        if (IsShowPlantWatering)
        {
            if (CheckIsTouchUI())
            {
                return;
            }
            else
            {
                Hide();
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
        if (obj != null && obj is fun_Scene.plant_OneKeyWatering)
        {
            return true;
        }
        return false;
    }

    public void Hide()
    {
        if (IsShowPlantWatering)
        {
            IsShowPlantWatering = false;
            if (plantOneKeyWateringUi != null)
            {
                plantOneKeyWateringUi.visible = false;
                Stage.inst.onTouchBegin.Remove(HandleInput);
            }
            dragObject = null;
        }
    }
}
