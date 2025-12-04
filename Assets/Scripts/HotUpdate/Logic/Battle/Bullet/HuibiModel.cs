using FairyGUI;
using Spine.Unity;
using UnityEngine;

/// <summary>
/// 绘笔spine模型
/// </summary>
public class HuibiModel
{
    private GLoader3D uiSpineContainer;
    /// <summary>
    /// 用于UI层初始化
    /// </summary>
    /// <param name="container"></param>
    public void Init(GLoader3D container)
    {
        uiSpineContainer = container;
        InitBody();
    }

    protected void InitBody()
    {
        //base.InitBody();
        //uiSpineContainer.SetSpine(skeletonDataAsset, 0, 0, Vector2.zero);
        //bodySkeletonAnimation = uiSpineContainer.spineAnimation;
        //PlayAnimation("idle", true);
    }
}
