
using DG.Tweening;
using FairyGUI;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 订单NPC
/// </summary>
public class OrderNpc : SceneObject
{
    private LineVO[] lines;

    public bool isWalked;//是否走完全程
    private int step = 0;//是否立即行走
    private int mFace = 1;//朝向 0左 1右
    private string mDirection = "";//方向
    public Action<OrderNpc> walkComplete;//走完全程回调函数
    public uint indexId;
    public uint npc;
    private Sequence moveSequence;
    [SerializeField]
    private UIPanel bubble;
    [SerializeField]
    private SpriteRenderer face;

    public NpcOrderVO npcOrderVO;
    private bool isLeave = false;
    private bool isAddListener = false;
    //订单npc属性
    private SkeletonAnimation armatureComponent;
    private Vector3 scaleFlipx = new Vector3(-1, 1, 1);
    private float speedAdjust = 1f;//速度调节，默认都是1，越小npc走得越快 后续针对每个npc单独配置
    private UnityEngine.Rendering.SortingGroup sortingGroup;

    public void Init(uint indexId, uint npc, Transform npcLayer, LineVO[] lines)
    {
        sceneObjectType = SceneObjectType.OrderNpc;
        SetObjectUid(indexId);
        this.indexId = indexId;
        this.npc = npc;
        this.lines = lines;
        isWalked = false;
        isLeave = false;
        step = 0;
        _visible = true;
        lastAnimationName = "";
        ShowNpcDb(transform);
        if (!isAddListener)
        {
            isAddListener = true;
            EventManager.Instance.AddEventListener(SystemEvent.UpdateItemNum, UpdateBubbleData);
            //EventManager.Instance.AddEventListener(SceneEvent.FlowerHarvest, UpdateBubbleData);
        }
        
    }

    private void ShowNpcDb(Transform transform)
    {
        if (armatureComponent == null)//首次不存在创建
        {
            var npcConfig = NpcManager.Instance.GetNpcConfig((int)npcOrderVO.npc);
            AnimationHelper.CreateSpine(npcConfig.Resouce, transform, "", false, "ObjectLayer", (SkeletonAnimation armatureComponent) =>
            {
                this.armatureComponent = armatureComponent;
                sortingGroup = GetComponent<UnityEngine.Rendering.SortingGroup>();
                sortingGroup.sortingLayerName = "ObjectLayer";
                Walk();
            });
        }
        else
        {
            visible = true;
            Walk();
        }
    }

    private void Walk()
    {
        if (npcOrderVO != null && npcOrderVO.isOld)//如果是oldnpc刚生成就让他站在场景中
        {
            StandInStep();
        }
        SetPos(lines[step]);
        moveSequence = DOTween.Sequence();
        Move();
    }

    /// <summary>
    /// 直接跳到站立点
    /// </summary>
    private void StandInStep()
    {
        for (var i = 0; i < lines.Length; i++)
        {
            if (CheckIsStandPos(lines[i]))
            {
                step = i;
                break;
            }
        }
    }

    /// <summary>
    /// 是否是站立点
    /// </summary>
    /// <param name="lineVO"></param>
    /// <returns></returns>
    private bool CheckIsStandPos(LineVO lineVO)
    {
        if (lineVO.x == lineVO.standings[0] && lineVO.y == lineVO.standings[1])
        {
            npcOrderVO.isStandInScene = true;//设置站场状态
            return true;
        }
        return false;
    }

    private void SetPos(LineVO lineVO)
    {
        transform.localPosition = new Vector2(lineVO.x, lineVO.y);
    }

    private void ShowBubble()
    {
        if (!bubble.gameObject.activeSelf)
        {
            bubble.gameObject.SetActive(true);
            bubble.ui.onClick.Add(OnClickOrderPop);

            var npcConfig = NpcManager.Instance.GetNpcConfig((int)npcOrderVO.npc);
            var posX = -0.65f;
            var posY = 0f;
            var facePosX = face.transform.localPosition.x;
            var facePosY = 3.72f;

            if (npcConfig.Resouce == "laoshu")
            {
                posY = 4.3f;
            }
            else if (npcConfig.Resouce == "kongque")
            {
                posY = 4.5f;
                facePosY = 4f;
            }
            else if (npcConfig.Resouce == "yang")
            {
                posY = 4.8f;
                facePosY = 4.3f;
            }
            else if (npcConfig.Resouce == "lu")
            {
                posX = -1.08f;
                posY = 5f;
                facePosX = -0.34f;
                facePosY = 4.5f;
            }
            else if (npcConfig.Resouce == "long")
            {
                posX = -0.83f;
                posY = 5.09f;
                facePosX = 0.08f;
                facePosY = 4.42f;
            }
            else if (npcConfig.Resouce == "tuzi")
            {
                posX = -0.53f;
                posY = 4.41f;
                facePosX = 0.44f;
                facePosY = 3.76f;
            }
            bubble.gameObject.transform.localPosition = new Vector3(posX, posY);
            face.transform.localPosition = new Vector3(facePosX, facePosY);
        }
        UpdateBubbleData();
    }

    public void UpdateBubbleData()
    {
        if (bubble.gameObject.activeSelf)
        {
            (bubble.ui as common_New.roleBubble).doubleTab.selectedIndex = (int)npcOrderVO.isDouble;
            var npcorderCfg = IkeModel.Instance.GetFormula((int)npcOrderVO.orderId);
            if (npcorderCfg != null)
            {
                var make = IkeModel.Instance.GetCanMake((int)npcOrderVO.ratio, (int)npcOrderVO.orderId);
                var haveCount = StorageModel.Instance.GetItemCount(npcorderCfg.IkebanaId);
                var isEnabled = haveCount >= npcOrderVO.ratio || make ? true : false;
                (bubble.ui as common_New.roleBubble).status.selectedIndex = !isEnabled ? 2 : (int)npcOrderVO.isDouble;
                //UIExt_ikeImg.LoadIkeByItemId(((bubble.ui as common_New.roleBubble).img_loader as common_New.ikeImg), npcorderCfg.IkebanaId, true);
            }
        }
    }

    /// <summary>
    /// 获取气泡位置
    /// </summary>
    /// <returns></returns>
    public Vector3 GetBubblePos()
    {
        return bubble.transform.position;
    }

    /// <summary>
    /// 获取气泡位置
    /// </summary>
    /// <returns></returns>
    public Transform GetBubbleTransform()
    {
        return bubble.transform;
    }

    private void HideBubble()
    {
        if (bubble.gameObject.activeSelf)
        {
            bubble.gameObject.SetActive(false);
            bubble.ui.onClick.Remove(OnClickOrderPop);
        }
    }

    private void OnClickOrderPop()
    {
        if (bubble.gameObject.activeSelf)
        {
            Debug.Log("OnClickOrderPop");
            UIManager.Instance.OpenWindow<NpcOrderWindow>(UIName.NpcOrderWindow, npcOrderVO);
        }
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
        if (this.step + 1 >= this.lines.Length)//路线走完进入待机状态
        {
            this.Idle();
            return;
        }
        ChangeSortingLayer();
        var p1 = this.lines[this.step];
        var p2 = this.lines[this.step + 1];

        Face(p1, p2);
        Direction(p1, p2);

        if (!isLeave && CheckIsStandPos(lines[step]))//走到自己站立位停下来 再显示头上气泡
        {
            PlayAnimation("idle");
            ShowBubble();
        }
        else
        {

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
            moveSequence.Append(transform.DOMove(new Vector2(endPoint.x, endPoint.y), duration).SetEase(Ease.Linear));
            moveSequence.AppendCallback(() => { this.step++; Move(); });
        }
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
        this.step = 0;
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
            //armatureComponent = null;
        }
        if (moveSequence != null)
        {
            moveSequence.Kill(); // 先终止当前的 Sequence
            moveSequence = null;
        }
        walkComplete = null;
        HideBubble();
    }


    protected override void OnClick()
    {
        if (bubble.gameObject.activeSelf)
        {
            Debug.Log("点击npc");
            UIManager.Instance.OpenWindow<NpcOrderWindow>(UIName.NpcOrderWindow, npcOrderVO);
        }
    }

    public void Leave(uint type)
    {
        HideBubble();
        StartCoroutine(ShowFace(type));
        isLeave = true;
        Move();
    }

    IEnumerator ShowFace(uint type)
    {
        if (!face.gameObject.activeSelf) face.gameObject.SetActive(true);
        var faceName = type == 1 ? "smile" : "cry";
        var assetHandle = ResourceManager.Instance.LoadAssetAsync<Sprite>(ResPath.GetNpcPath(faceName));
        yield return assetHandle;
        face.sprite = assetHandle.AssetObject as Sprite;
        yield return new WaitForSeconds(2f);
        face.gameObject.SetActive(false);
    }

    private bool _visible = true;
    public bool visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            gameObject.SetActive(value);
        }
    }

}
