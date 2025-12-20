using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using FairyGUI;
using UnityEngine;

public class FlowerTipCom : Singleton<FlowerTipCom>
{
    public UIPanel panel;
    public void Init(Transform parent)
    {
        panel = GetUIPanel();
        panel.gameObject.transform.parent = parent;
        panel.gameObject.transform.localPosition = new Vector3(-2.8f,3.95f,0f);
        panel.ui.visible = false;
        UpdateData();
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateItem, UpdateData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationPlant, UpdateData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationHarvest, UpdateData);
        EventManager.Instance.AddEventListener(RedPointEvent.FlowerCultivation, UpdateData);
        EventManager.Instance.AddEventListener(CultivationEvent.CultivationSpeed, UpdateData);
    }

    private void UpdateData()
    {
        Module_item_defConfig itemData = null;
        var view = panel.ui as fun_Scene.flower_top_com;
        if (CultivationModel.Instance.flowerId != 0 && CultivationModel.Instance.harvestTime != 0)
        {
            if((CultivationModel.Instance.harvestTime - (int)ServerTime.Time) <= 0)
            {
                itemData = ItemModel.Instance.GetItemById(CultivationModel.Instance.flowerId);
                view.com.tip_lab.text = Lang.GetValue("party_button_completed");
            }
            
        }
        else
        {
            var vo = StorageModel.Instance.GetCanCultivationFlower();
            if(vo != null)
            {
                itemData = ItemModel.Instance.GetItemById(vo.FlowerId);
                view.com.tip_lab.text = Lang.GetValue("Cultivation_5");
            }
            
        }
        if(itemData != null)
        {
            view.visible = true;
            view.com.pic.url = ImageDataModel.Instance.GetIconUrl(itemData);
        }
        else
        {
            view.visible = false;
        }
    }
    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("FlowerTip");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Scene";
        panel.componentName = "flower_top_com";
        panel.container.touchable = false;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }
}


public class NpcControllCom : Singleton<NpcControllCom>
{
    public UIPanel panel;
    public void Init(Transform parent)
    {
        panel = GetUIPanel();
        panel.gameObject.transform.parent = parent;
        panel.gameObject.transform.localPosition = new Vector3(-2.8f, 3.95f, 0f);
        panel.ui.visible = false;
        UpdateData();
        
    }

    
    private void UpdateData()
    {
        Module_item_defConfig itemData = null;
        var view = panel.ui as fun_Scene.flower_top_com;
        
    }
    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("NpcControllTip");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Scene";
        panel.componentName = "flower_top_com";
        panel.container.touchable = false;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }
}

public class TradeCom : Singleton<TradeCom>
{
    public UIPanel panel;
    public void Init(Transform parent)
    {
        panel = GetUIPanel();
        panel.gameObject.transform.parent = parent;
        panel.gameObject.transform.localPosition = new Vector3(-1.12f, 4.28f, 0f);
        panel.ui.visible = false;
        var view = panel.ui as fun_Scene.flower_top_com;
        view.com.pic.url = ImageDataModel.GOLD_ICON_URL;
        view.com.tip_lab.text = Lang.GetValue("slang_99");
        UpdateData();
        EventManager.Instance.AddEventListener(RedPointEvent.UpdateTradeMain, UpdateData);
        EventManager.Instance.AddEventListener<uint>(RedPointEvent.RedDotChange, UpdateRedPoint);
    }
    private void UpdateRedPoint(uint type)
    {
        if (type == (uint)RedPointType.Trade)
        {
            UpdateData();
        }
    }
    private void UpdateData()
    {
        panel.ui.visible = RedPointModel.Instance.IsRedPointShow(RedPointType.Trade);
    }
    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("TradeTip");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Scene";
        panel.componentName = "flower_top_com";
        panel.container.touchable = false;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }
}
