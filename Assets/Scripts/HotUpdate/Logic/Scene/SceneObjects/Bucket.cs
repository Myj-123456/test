using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ³¡¾°Ë®Í°
/// </summary>
public class Bucket : SceneObject
{
    private bool _visible = false;
    public UIPanel panel;
    public int id;
    public void Init(int id, UIPanel panel, Transform parent, Vector3 pos)
    {
        this.id = id;
        this.panel = panel;
        panel.gameObject.transform.parent = parent;
        panel.gameObject.transform.position = pos;

        panel.ui.visible = false;

        var cell = panel.ui as fun_Scene.bucket_item;
        cell.pro.max = GlobalModel.Instance.module_profileConfig.bucketRecoverCD;

        panel.ui.data = id;
        panel.ui.onClick.Add(GetWater);
    }

    public bool visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            panel.ui.visible = value;
        }
    }


    private void GetWater(EventContext context)
    {
        var pos = (int)(context.sender as GComponent).data;
        int randomNumber = Random.Range(1, 101);
        var videoVo = VideoModel.Instance.GetVideo((int)VideoSeeType.mouse_video_id);
        var num = VideoModel.Instance.GetWatchVideoCount((int)VideoSeeType.mouse_video_id);
        if (randomNumber <= GlobalModel.Instance.module_profileConfig.bucketVideoProb && num < videoVo.Sp_limit)
        {
            UIManager.Instance.OpenWindow<WaterVideoWindow>(UIName.WaterVideoWindow, pos);
            
        }
        else
        {
            MyselfController.Instance.ReqWaterBucketAward((uint)pos, 1);
        }
    }
}
