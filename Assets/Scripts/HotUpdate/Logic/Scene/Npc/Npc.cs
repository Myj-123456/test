
using DG.Tweening;
using Spine.Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 普通NPC
/// </summary>
public class Npc
{
    private LineVO[] lines;

    public bool isWalked;//是否走完全程
    private int step = -1;//是否立即行走
    private int mFace = 1;//朝向 0左 1右
    private string mDirection = "";//方向
    public Action<Npc> walkComplete;//走完全程回调函数
    public uint npcId;
    public string npcResId;
    private Sequence moveSequence;
    private float speedAdjust = 1f;//速度调节，默认都是1，越小npc走得越快 后续针对每个npc单独配置
    private Vector3 scaleFlipx = new Vector3(-1, 1, 1);
    private UnityEngine.Rendering.SortingGroup sortingGroup;

    private SkeletonAnimation armatureComponent;
    public void Init(uint npcId, string npcResId, Transform npcLayer, LineVO[] lines)
    {
        this.npcId = npcId;
        this.npcResId = npcResId;
        this.lines = lines;
        isWalked = false;
        _visible = true;
        step = -1;
        lastAnimationName = "";
        if (npcResId == "laoshu")
        {
            speedAdjust = 0.6f;
        }
        //else if(npcResId== "kongque")
        //{
        //    speedAdjust = 0.9f;
        //}

        if (armatureComponent == null)//首次不存在创建
        {
            AnimationHelper.CreateSpine(npcResId, npcLayer, "", false, "ObjectLayer", (SkeletonAnimation armatureComponent) =>
            {
                this.armatureComponent = armatureComponent;
                sortingGroup = this.armatureComponent.gameObject.AddComponent<UnityEngine.Rendering.SortingGroup>();
                sortingGroup.sortingLayerName = "ObjectLayer";
                Walk();
            });
        }
        else//后面不销毁 走对象池
        {
            visible = true;
            Walk();
        }
    }

    /// <summary>
    /// 开始移动
    /// </summary>
    private void Walk()
    {
        Face(lines[0], lines[1]);
        SetPos(lines[0]);
        moveSequence = DOTween.Sequence();
        Move();
    }

    private void SetPos(LineVO lineVO)
    {
        armatureComponent.transform.localPosition = new Vector2(lineVO.x, lineVO.y);
    }

    public void Face(LineVO p1, LineVO p2)
    {
        if (p2.x < p1.x)
        {
            mFace = 0; // Facing left
            armatureComponent.transform.localScale = Vector3.one;
        }
        else if (p2.x > p1.x)
        {
            mFace = 1; // Facing right
            armatureComponent.transform.localScale = scaleFlipx;
        }
    }

    public void Direction(LineVO p1, LineVO p2)
    {
        if (p2.y > p1.y)
        {
            //this.mDirection = "back_";//后
            this.mDirection = "";//暂时没有后的 先用前的代替下
        }
        else if (p2.y < p1.y)
        {
            this.mDirection = "";//前
        }
    }
    private void Move()
    {
        this.step++;
        ChangeSortingLayer();
        if (this.step + 1 >= this.lines.Length)//路线走完进入待机状态
        {
            this.Idle();
            return;
        }

        if (this.step < 0)
            return;

        var p1 = this.lines[this.step];
        var p2 = this.lines[this.step + 1];

        Face(p1, p2);
        Direction(p1, p2);
        var startPoint = new Vector2(p1.x, p1.y);
        var endPoint = new Vector2(p2.x, p2.y);
        float distance = Vector2.Distance(startPoint, endPoint);
        float duration = distance * (1500 + 600 * UnityEngine.Random.value) * speedAdjust / 1000.0f;

        if (moveSequence != null)
        {
            moveSequence.Kill();// 先终止当前的 Sequence
            moveSequence = null;
        }
        moveSequence = DOTween.Sequence(); // 重新创建 Sequence

        if (p1.time > 0)
        {
            moveSequence.AppendCallback(() => PlayAnimation("idle"));
            moveSequence.AppendInterval(p1.time);
        }
        moveSequence.AppendCallback(() => PlayAnimation(mDirection + "walk"));
        moveSequence.Append(armatureComponent.transform.DOMove(new Vector2(endPoint.x, endPoint.y), duration).SetEase(Ease.Linear));
        moveSequence.AppendCallback(Move);
    }


    private List<Vector2> line4Points = new List<Vector2>() { new Vector2(-7.94f, 9.27f), new Vector2(4.82f, 16.9f), new Vector2(16.58f, 9.55f) };//4号线特殊点
    /// <summary>
    /// 一些特殊固定点需要动态更改玩家的渲染层级
    /// </summary>
    private bool CheckIsChangeSortingLayerPoint()
    {
        var p = this.lines[this.step];
        foreach (var point in line4Points)
        {
            if (p.x == point.x && p.y == point.y)
            {
                return true;
            }
        }
        return false;
    }

    private void ChangeSortingLayer()
    {
        if (CheckIsChangeSortingLayerPoint())
        {
            ChangeSortingLayer("Default");
        }
        else
        {
            ChangeSortingLayer("ObjectLayer");
        }
    }

    private void ChangeSortingLayer(string sortingLayerName)
    {
        if (sortingGroup.sortingLayerName != sortingLayerName)
        {
            sortingGroup.sortingLayerName = sortingLayerName;
        }
    }

    private string lastAnimationName = "";
    private void PlayAnimation(string aniName)
    {
        if (lastAnimationName == aniName) return;
        armatureComponent.AnimationState.SetAnimation(0, aniName, true);
        lastAnimationName = aniName;
    }

    //待机
    private void Idle()
    {
        this.step = -1;
        this.mFace = 0;
        armatureComponent.transform.localScale = Vector3.one;
        this.isWalked = true;
        PlayAnimation("idle");
        walkComplete?.Invoke(this);
    }

    public void Clear()
    {
        if (armatureComponent != null)
        {
            armatureComponent.AnimationState.SetEmptyAnimation(0, 0);
            visible = false;
        }
        if (moveSequence != null)
        {
            moveSequence.Kill(); // 先终止当前的 Sequence
            moveSequence = null;
        }
        walkComplete = null;
    }

    private bool _visible = true;
    public bool visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            if (armatureComponent != null)
            {
                armatureComponent.gameObject.SetActive(value);
            }
        }
    }

}
