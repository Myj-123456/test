using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class WaterVideoWindow : BaseWindow
{
   private fun_Scene.water_video_view view;
    private int pos;
   public WaterVideoWindow()
    {
        packageName = "fun_Scene";
        // 设置委托
        BindAllDelegate = fun_Scene.fun_SceneBinder.BindAll;
        CreateInstanceDelegate = fun_Scene.water_video_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Scene.water_video_view;
        SetBg(view.bg, "Welfare/ELIDA_dlsd_bg.png");
        SetBg(view.bg1, "Welfare/ELIDA_dlsd_hudie.png");
        StringUtil.SetBtnTab(view.video_btn, Lang.GetValue("common_claim_button"));
        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("water_1"));
        view.videoLab.text = GlobalModel.Instance.module_profileConfig.bucketVideoReward[0] + "~" + GlobalModel.Instance.module_profileConfig.bucketVideoReward[1];
        view.numLab.text = GlobalModel.Instance.module_profileConfig.bucketRewardWater[0] + "~" + GlobalModel.Instance.module_profileConfig.bucketRewardWater[1];
        view.video_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqWaterBucketAward((uint)pos, 2);
            Close();
        });
        view.get_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqWaterBucketAward((uint)pos, 1);
            Close();
        });
        view.close_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqWaterBucketAward((uint)pos, 3);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        pos = (int)data;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    
}

