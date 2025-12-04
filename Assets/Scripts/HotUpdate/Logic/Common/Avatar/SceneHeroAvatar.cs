using DG.Tweening;
using Spine.Unity;
using System;
using UnityEngine;

/// <summary>
/// 场景主角spine模型
/// 
/// </summary>
public class SceneHeroAvatar : HeroAvatar
{
    private Transform sceneSpineContainer;
    private Vector3 pos;
    private float initScale = 0.47f;

    /// <summary>
    /// 用于场景层初始化
    /// </summary>
    /// <param name="container"></param>
    public void Init(Transform container, Vector3 pos, float initScale = 0.47f)
    {
        sceneSpineContainer = container;
        this.pos = pos;
        this.initScale = initScale;
        InitBody();
    }

    protected override void InitBody()
    {
        base.InitBody();
        SkeletonAnimation skeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(skeletonDataAsset);
        skeletonAnimation.name = "heroAvatar";
        SetSkin(skeletonAnimation, "body");
        skeletonAnimation.transform.SetParent(sceneSpineContainer, false);
        skeletonAnimation.Initialize(false);
        var sortingGroup = skeletonAnimation.gameObject.AddComponent<UnityEngine.Rendering.SortingGroup>();
        sortingGroup.sortingLayerName = "ObjectLayer";
        skeletonAnimation.transform.localScale *= initScale;
        skeletonAnimation.transform.localPosition = pos;
        bodySkeletonAnimation = skeletonAnimation;
        PlayAnimation("idle", true);
    }

    /// <summary>
    /// 添加组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T AddComponent<T>() where T : Component
    {
        if (bodySkeletonAnimation != null)
        {
            return bodySkeletonAnimation.gameObject.AddComponent<T>();
        }
        return default(T);
    }

    public T GetComponent<T>() where T : Component
    {
        if (bodySkeletonAnimation != null)
        {
            return bodySkeletonAnimation.gameObject.GetComponent<T>();
        }
        return default(T);
    }

    /// <summary>
    /// 设置位置
    /// </summary>
    /// <param name="pos"></param>
    public void SetPos(Vector3 pos)
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.transform.localPosition = pos;
        }
    }
    public void SetScale(Vector3 scale)
    {
        if (bodySkeletonAnimation != null)
        {
            bodySkeletonAnimation.transform.localScale = scale * initScale;
        }
    }

    public void WalkToPoint(Vector2 endPoint, Action walkDestinationCall = null)
    {
        if (bodySkeletonAnimation != null)
        {
            PlayAnimation("walk", true);
            var startPoint = bodySkeletonAnimation.transform.position;
            float distance = Vector2.Distance(startPoint, endPoint);
            float duration = distance * 1500 * 0.5f / 1000.0f;
            Vector3[] path = new Vector3[1] { endPoint };
            bodySkeletonAnimation.transform.DOPath(path, duration, PathType.Linear, PathMode.TopDown2D)
           .OnUpdate(() =>
           {
               var dis = Vector3.Distance(bodySkeletonAnimation.transform.position, endPoint);
               if (dis < 0.15f)
               {
                   Debug.Log("到达坐标点");
                   PlayAnimation("idle", true);
                   bodySkeletonAnimation.transform.DOKill(true);
               }
           })
           .OnComplete(() =>
           {
               PlayAnimation("idle", true);
               walkDestinationCall?.Invoke();
           });
        }
    }
}
