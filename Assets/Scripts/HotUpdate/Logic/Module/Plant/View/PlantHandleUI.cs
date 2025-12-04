using ADK;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHandleUI
{
    private bool IsShowPlantHandle = false;
    private fun_Scene.plant_handle plantHandleUi;
    public void Init()
    {
        plantHandleUi = (fun_Scene.plant_handle)fun_Scene.plant_handle.CreateInstance().asCom;
        plantHandleUi.pivotX = 0.5f;
        plantHandleUi.pivotY = 0.5f;
        plantHandleUi.pivotAsAnchor = true;


        plantHandleUi.bt_js.onClick.Add(() =>
        {
            Hide();
            PlantController.Instance.ReqPlantSpeed(new uint[1] { (plantHandleUi.data as PlantVO).landId });
        });

        plantHandleUi.bt_cc.onClick.Add(() =>
        {
            Hide();
            PlantController.Instance.ReqPlantMove(new uint[1] { (plantHandleUi.data as PlantVO).landId });
        });

        plantHandleUi.free_speed.onClick.Add(() =>
        {
            Hide();
            UILogicUtils.ShowConfirm(Lang.GetValue("speed_flower"), OnFreeSpeedUp);
        });

        plantHandleUi.bt_js_all.onClick.Add(() =>
        {
            Hide();
            UILogicUtils.ShowConfirm(Lang.GetValue("accelerate_confirm"), OnOneKeySpeedUp);
        });

        plantHandleUi.bt_cc_all.onClick.Add(() =>
        {
            Hide();
            UILogicUtils.ShowConfirm(Lang.GetValue("Vip_function5"), OnOneKeyMove);
        });
    }

    private void OnFreeSpeedUp()
    {
        var lands = PlantModel.Instance.GetHarvestTimeLowerOneMinutePlants();
        if (lands.Count > 0)
        {
            PlantController.Instance.ReqPlantFreeSpeedUp(lands.ToArray());
        }
    }

    private void OnOneKeySpeedUp()
    {
        var haveSpeedUpPotionCount = StorageModel.Instance.GetItemCount((int)BaseType.SPD_DRUG);
        var lands = PlantModel.Instance.GetHarvestGrowUpPlants();
        if (haveSpeedUpPotionCount < lands.Count)
        {
            ADK.UILogicUtils.ShowNotice(Lang.GetValue("Vip_function4"));
            return;
        }
        if (lands.Count > 0)
        {
            PlantController.Instance.ReqPlantSpeed(lands.ToArray());
        }
    }

    private void OnOneKeyMove()
    {
        var lands = PlantModel.Instance.GetPlantedLandIds();
        if (lands.Count > 0)
        {
            PlantController.Instance.ReqPlantMove(lands.ToArray());
        }
    }

    public void SetData(PlantVO data)
    {
        plantHandleUi.data = data;
    }

    public void Show(Vector3 position)
    {
        GRoot.inst.AddChild(plantHandleUi);
        plantHandleUi.visible = true;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        //原点位置转换
        screenPos.y = Screen.height - screenPos.y;
        Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
        plantHandleUi.x = pt.x;
        plantHandleUi.y = pt.y - 120;
        plantHandleUi.t0.Play();

        IsShowPlantHandle = true;
        Stage.inst.onTouchBegin.Add(HandleInput);
        UpdatePlantHandleUi();
    }

    private CountDownTimer countDownTimer;
    private void UpdatePlantHandleUi()
    {
        var data = plantHandleUi.data as PlantVO;
        plantHandleUi.status.selectedIndex = 1;
        plantHandleUi.bt_js_all.grayed = plantHandleUi.bt_cc_all.grayed = !MyselfModel.Instance.IsVip();
        plantHandleUi.com_residue.times.text = Lang.GetValue("Harvesting_frequency", data.surplus.ToString());
        var leftTime = data.harvestTime - ServerTime.Time;
        if (countDownTimer != null)
        {
            countDownTimer.Clear();
            countDownTimer = null;
        }
        countDownTimer = new CountDownTimer(plantHandleUi.com_timeDown.pgs.time, (int)leftTime);
        countDownTimer.CompleteCallBacker = () =>
        {
            Hide();
        };

        var haveSpeedUpPotionCount = StorageModel.Instance.GetItemCount((int)BaseType.SPD_DRUG);
        plantHandleUi.bt_js.lb_count.text = "x" + haveSpeedUpPotionCount.ToString();
        plantHandleUi.bt_js_all.lb_count.text = "x" + haveSpeedUpPotionCount.ToString();
        plantHandleUi.bt_js.enabled = (haveSpeedUpPotionCount > 0);
        plantHandleUi.free_speed.enabled = leftTime <= 60;//成熟时间小于1分钟显示免费加速状态 否则显示视频加速状态
    }

    private void HandleInput(EventContext context)
    {
        if (IsShowPlantHandle)
        {
            GObject obj = GRoot.inst.touchTarget;
            if (obj != null && obj.parent != null && obj.parent is fun_Scene.plant_handle)
            {
                return;
            }
            else
            {
                Hide();
            }
        }
    }

    public void Hide()
    {
        IsShowPlantHandle = false;
        if (plantHandleUi != null)
        {
            plantHandleUi.visible = false;
            Stage.inst.onTouchBegin.Remove(HandleInput);
            if (countDownTimer != null)
            {
                countDownTimer.Clear();
                countDownTimer = null;
            }
        }
    }
}
