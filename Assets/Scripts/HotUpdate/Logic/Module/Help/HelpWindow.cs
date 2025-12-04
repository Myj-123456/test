using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using ADK;
using YooAsset;

public class HelpWindow : BaseWindow
{
   private fun_Help.help viewSkin;

   public HelpWindow()
    {
        packageName = "fun_Help";
        // 设置委托
        BindAllDelegate = fun_Help.fun_HelpBinder.BindAll;
        CreateInstanceDelegate = fun_Help.help.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Help.help;
        SetBg(viewSkin.bg,"Common/ELIDA_common_bigdi01.png");
        
        viewSkin.title.text = Lang.GetValue("train_help");
        //StringUtil.SetBtnTab(viewSkin.btn_sure, Lang.GetValue("gui_btn_confirm"));
        //viewSkin.btn_sure.onClick.Add(closeView);
        viewSkin.close_btn.onClick.Add(closeView);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var arr = data as string[];
        
        viewSkin.title.text = arr[0];
        viewSkin.txtCom.descTxt.text = arr[1];
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void closeView()
    {
        UIManager.Instance.CloseWindow(UIName.HelpWindow);
    }
}

