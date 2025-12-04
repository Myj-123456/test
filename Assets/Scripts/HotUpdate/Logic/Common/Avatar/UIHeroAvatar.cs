using FairyGUI;
using Spine.Unity;
using UnityEngine;

/// <summary>
/// UI����spineģ��
/// </summary>
public class UIHeroAvatar : HeroAvatar
{
    private GLoader3D uiSpineContainer;
    /// <summary>
    /// ����UI���ʼ��
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
