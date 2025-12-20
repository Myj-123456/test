using Elida.Config;
using FairyGUI;
using System;
using UnityEngine;

public class RobBedCom : Singleton<RobBedCom>
{
    public UIPanel panel;
    private fun_Rob.robbedCell2[] cages;
    public void Init(Transform parent)
    {
        panel = GetUIPanel();
        panel.gameObject.transform.parent = parent;
        parent.transform.localPosition = new Vector3(-30.4f, 1.2f, 0f);
        panel.gameObject.transform.localPosition = new Vector3(-3.4f, 3.1f, 0f);
        panel.ui.visible = false;
        UpdateData();
    }

    private void UpdateData()
    {
        var view = panel.ui as fun_Rob.robbedList;
        if (view == null) return;
        // 显示界面
        panel.ui.visible = true;
        cages = new fun_Rob.robbedCell2[] { view.cage_0, view.cage_1, view.cage_2, view.cage_3 };
        UpdateCages();
    }

    private void UpdateCages()
    {
        int len = cages.Length;
        for (int i= 0; i < len; i++)
        {
            //UpdateCage(i);
        }
    }

    private void UpdateCage(int index)
    {
        var cage = cages[index];
        var cageData = RobModel.Instance.GetArrestInfo((uint)(index + 1));

        bool hasPlayer = false;
        if (cageData != null)
        {

            cage.data = cageData;
            if (cageData.acquittalTime > ServerTime.Time)
            {
                hasPlayer = true;
                cage.status.selectedIndex = 0;
                
            }
            else
            {
                if (cageData.userInfo != null && cageData.userInfo.userId != 0)
                {
                    cage.status.selectedIndex = 3;
                    cage.img_reward.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_petal_id);
                }
                else
                {
                    cage.status.selectedIndex = 1;
                }
            }
        }
        else
        {
            if (index == 3)
            {
                // 第四个位置需要检查VIP状态
                if (!MyselfModel.Instance.IsVip())
                {
                    cage.status.selectedIndex = 4;
                }
                else
                {
                    cage.status.selectedIndex = 3;
                }
            }
            else
            {
                cage.status.selectedIndex = 2;
            }
            int value = 0;
            if (index == 1)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume1s[0].Value;
            }
            else if (index == 2)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume2s[0].Value;
            }
        }
    }

    private UIPanel GetUIPanel()
    {
        GameObject emptyObject = new GameObject("RobBed");
        var panel = emptyObject.AddComponent<UIPanel>();
        panel.packageName = "fun_Rob";
        panel.componentName = "robbedList";
        panel.container.touchable = true;
        panel.container.renderMode = RenderMode.WorldSpace;
        panel.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        return panel;
    }
}