using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class ExpTreeTaskWindow : BaseWindow
{
   private fun_ExperienceTree.expTree _view;

   public ExpTreeTaskWindow()
    {
        packageName = "fun_Help";
        // 设置委托
        BindAllDelegate = fun_ExperienceTree.fun_ExperienceTreeBinder.BindAll;
        CreateInstanceDelegate = fun_ExperienceTree.expTree.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_ExperienceTree.expTree;
        _view.status.selectedIndex = 0;
        _view.txt_title.text = Lang.GetValue("slang_70");//树苗任务
        StringUtil.SetBtnTab(_view.btnSure, Lang.GetValue("slang_71"));//种植
        _view.list_task.itemRenderer = TaskCellRender;
        _view.btnSure.onClick.Add(() =>
        {

        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }

    private void TaskCellRender(int index,GObject item)
    {

    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

