using FairyGUI;
using Spine.Unity;
using UnityEngine;

/// <summary>
/// <summary>
/// UI英雄spine模型
/// </summary>
/// </summary>
public class UIHeroAvatar : HeroAvatar
{
    private GLoader3D uiSpineContainer;
    /// <summary>
    /// UI模型初始化
    /// </summary>
    /// <param name="container"></param>
    public void Init(GLoader3D container)
    {
        uiSpineContainer = container;
        InitBody();
    }

    protected override void InitBody()
    {
        base.InitBody();
        uiSpineContainer.SetSpine(skeletonDataAsset, 0, 0, Vector2.zero);
        bodySkeletonAnimation = uiSpineContainer.spineAnimation;
        PlayAnimation("idle", true);
    }
}
