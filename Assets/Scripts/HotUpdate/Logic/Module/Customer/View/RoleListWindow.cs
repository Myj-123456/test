using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoleListWindow
{
   private fun_Customer.role_list_view view;
    private List<NpcConfig> listData;
    public int curIndex = 0;
   public RoleListWindow(fun_Customer.role_list_view ui)
    {
        view = ui;
        
        view.proTitle.text = Lang.GetValue("customer_4");
        view.tipLab.text = Lang.GetValue("customer_5");

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.rect.onClick.Add(() =>
        {
            view.visible = false;
        });
    }
    public void OnShown()
    {
        
        var nextInfo = CustomerModel.Instance.GetNpcBuffInfo((int)CustomerModel.Instance.totalLevel + 1);
        if (nextInfo != null)
        {
            view.pro.max = nextInfo.Exp;
            view.pro.value = CustomerModel.Instance.totalExp;
            view.expLab.text = CustomerModel.Instance.totalExp + "/" + nextInfo.Exp;
        }
        else
        {
            var curInfo = CustomerModel.Instance.GetNpcBuffInfo((int)CustomerModel.Instance.totalLevel);
            view.pro.max = 1;
            view.pro.value = 1;
            view.expLab.text = CustomerModel.Instance.totalExp + "/" + curInfo.Exp;
        }
        view.proLab.text = CustomerModel.Instance.totalLevel.ToString();
        view.list.numItems = CustomerModel.Instance.npcHome.Count;
        view.list.selectedIndex = curIndex;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Customer.role_item;
        var info = CustomerModel.Instance.npcHome[index];
        cell.pic.url = "npc/head/" + info.Head + ".png";
        cell.data = index;
        cell.onClick.Add(ChoseNpc);

    }

    private void ChoseNpc(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(curIndex == index)
        {
            return;
        }
        curIndex = index;
        EventManager.Instance.DispatchEvent(NpcEvent.ChangeNpc);
        view.visible = false;
    }
}

