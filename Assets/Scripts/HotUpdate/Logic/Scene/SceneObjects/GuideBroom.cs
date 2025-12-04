using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBroom : SceneObject
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;

    protected override void OnClick()
    {
        Debug.Log("GuideBroom OnClick");
        EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        spriteRenderer.gameObject.SetActive(false);
        skeletonAnimation.gameObject.SetActive(true);
        skeletonAnimation.AnimationState.Complete += OnAnimationEventHandler;
        skeletonAnimation.AnimationState.SetAnimation(0, "animation", false);
        StartCoroutine(OnCleanDone());
    }
    private void OnAnimationEventHandler(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "animation")
        {
            skeletonAnimation.AnimationState.Complete -= OnAnimationEventHandler;
            gameObject.SetActive(false);
            UIManager.Instance.ShowOrHideMainUI(true, true, false);
            GuideController.Instance.NextGuide();
        }
    }
    private IEnumerator OnCleanDone()
    {
        yield return new WaitForSeconds(1.16f);
        SceneManager.Instance.ShowHideShabbyFlowerShop(false);
    }
}
