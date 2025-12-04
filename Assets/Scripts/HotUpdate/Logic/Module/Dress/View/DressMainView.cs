using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DressMainView
{
   private fun_Dress.dress_mian_book_view view;
    private int tabType;
    private DressBookView dressView;
    private SuitBookView suitView;
   public DressMainView(fun_Dress.dress_mian_book_view ui)
    {
        view = ui;
        tabType = 0;
        StringUtil.SetBtnTab(view.suit_btn, Lang.GetValue("dress_6"));
        StringUtil.SetBtnTab(view.dress_btn, Lang.GetValue("dress_8"));
        dressView = new DressBookView(view.dress_view);
        suitView = new SuitBookView(view.suit_view);
        tabType = 0;
        view.suit_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.dress_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.detail_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<DressNatureWindow>(UIName.DressNatureWindow);
        });
        EventManager.Instance.AddEventListener(SystemEvent.UpdateDressCharm, UpdateCharm);
    }


    public void OnShown()
    {
        ChangeTab(tabType);
        UpdateCharm();
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            suitView.OnShown();
        }
        else
        {
            dressView.OnShown();
        }
    }

    private void UpdateCharm()
    {
        view.powerNum.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.dressCharm);
    }

    public void OnHide()
    {
        
    }
}

