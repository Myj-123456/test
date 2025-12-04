using ADK;
using DG.Tweening;

using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class PopWaterWindow : BaseWindow
{
    public PopWaterWindow()
    {
        packageName = "fun_plant";
        // 设置委托
        BindAllDelegate = fun_Scene.fun_SceneBinder.BindAll;
        CreateInstanceDelegate = fun_Scene.plant.CreateInstance;
        openWithTween = false;
        showModal = false;
    }

    public override void OnInit()
    {
        base.OnInit();
     
    }

    public override void OnShown()
    {
      
    }

    public override void OnHide()
    {
        base.OnHide();
    }
}