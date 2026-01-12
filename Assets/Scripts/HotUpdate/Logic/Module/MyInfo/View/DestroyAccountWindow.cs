using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DestroyAccountWindow : BaseWindow
{
   private fun_MyInfo.destroy_account_view view;

   public DestroyAccountWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.destroy_account_view.CreateInstance;
        
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.destroy_account_view;
        SetBg(view.bg, "Common/common_big_tip_bg.png");
        view.titileLab.text = Lang.GetValue("destroy_account_title");
        StringUtil.SetBtnTab(view.reject_btn, Lang.GetValue("not_agree_text"));
        view.agree_btn.xieyi_txt.text = Lang.GetValue("agree_text");
        view.reject_btn.onClick.Add(Close);
        view.agree_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqDeleteAccount();
        });
        EventManager.Instance.AddEventListener(PlayerEvent.DeleteAccount,Close);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.content.lb_content.text = Lang.GetValue("destroy_account_content");
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

