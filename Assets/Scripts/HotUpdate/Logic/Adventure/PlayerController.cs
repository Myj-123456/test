using UnityEngine;
using PolyNav;
using Spine.Unity;
using System.Linq;
using System.Collections.Generic;
using DG.Tweening;
using FairyGUI;
using ADK;
using System;
using System.Text.RegularExpressions;
using System.Collections;

//example
//[RequireComponent(typeof(PolyNavAgent))]
public class PlayerController : MonoBehaviour
{
    public PolyNavMap map;//需要外部设置下
    private SkeletonAnimation armatureComponent;
    //private PolyNavAgent _agent;
    private bool closerPointOnInvalid = true;
    private bool checkPathBlocked = true;//需要检测路径是否被阻挡

    public bool isWalked;//是否走完全程
    private int step = -1;//是否立即行走
    private int mFace = 1;//朝向 0左 1右
    private string mDirection = "";//方向
    //public Action<Npc> walkComplete;//走完全程回调函数
    public uint npcId;
    public string npcResId;
    private Sequence moveSequence;
    private float speedAdjust = 0.5f;//速度调节，默认都是1，越小npc走得越快 后续针对每个npc单独配置
    private float initScale = 0.3f;
    private Vector3 scaleFlipx = new Vector3(-1, 1, 1);
    private UnityEngine.Rendering.SortingGroup sortingGroup;
    private List<Vector2> lines;
    private Vector3 targetPos;
    private Bounds bounds = new Bounds();
    private bool isWalking = false;
    private bool isPickingUp = false;//是否拾取中


    //private PolyNavAgent agent
    //{
    //    get { return _agent != null ? _agent : _agent = GetComponent<PolyNavAgent>(); }
    //}

    private void Awake()
    {
        armatureComponent = GetComponent<SkeletonAnimation>();
    }

    private void OnEnable()
    {
        EventManager.Instance.AddEventListener<ulong>(AdventureEvent.ResClearObstacle, OnResClearObstacle);
        EventManager.Instance.AddEventListener<Vector3>(SceneEvent.OrgPointReleaseTouch, OnOrgPointReleaseTouch);
    }

    private void OnDisable()
    {
        //_agent = null;
        EventManager.Instance.RemoveEventListener<Vector3>(SceneEvent.OrgPointReleaseTouch, OnOrgPointReleaseTouch);
        EventManager.Instance.RemoveEventListener<ulong>(AdventureEvent.ResClearObstacle, OnResClearObstacle);
    }

    /// <summary>
    /// 点击原点释放
    /// </summary>
    private void OnOrgPointReleaseTouch(Vector3 targetPos)
    {
        if (isPickingUp)//拾取中不再响应操作
        {
            return;
        }

        // 先检测TopLayer的雾
        RaycastHit2D[] fogHits = Physics2D.RaycastAll(
            targetPos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Fog")//只检测雾所在层
        );
        // 检查雾是否阻挡
        foreach (var hit in fogHits)
        {
            SpriteRenderer sr = hit.transform.GetComponent<SpriteRenderer>();
            if (sr.sprite == null) continue;

            float alpha = GetFogAlphaAtPosition(hit.transform.GetComponent<Fog>(), hit.point);
            if (alpha > 0.02f) // 透明度阈值
            {
                Debug.Log("雾阻挡点击");
                UILogicUtils.ShowNotice(Lang.GetValue("advantage_block_tips"));
                return;
            }
        }

        //雾不阻挡时检测ObjectLayer的清除物
        RaycastHit2D obstacleHit = Physics2D.Raycast(
            targetPos, Vector2.zero, Mathf.Infinity,
            LayerMask.GetMask("Obstacle") // 只检测障碍物层
        );
        if (obstacleHit.collider != null && obstacleHit.collider.TryGetComponent<Obstacle>(out var obstacle2))
        {
            var colliderSize = (obstacleHit.collider as BoxCollider2D).size;
            var scaleX = obstacleHit.transform.localScale.x;
            var scaleY = obstacleHit.transform.localScale.y;
            targetPos = obstacleHit.transform.position;
            var clickPos = targetPos;//存储对象的原始坐标
            var obstacle = obstacleHit.collider.gameObject.GetComponent<Obstacle>();
            AdventureModel.Instance.curObstacle = obstacle;
            obstacle.OnClickAction += () =>
            {
                obstacle.ShowHideBubble(false);
                if (!obstacle.CheckCanClick())
                {
                    return;
                }

                bool isLeft = false;//左边还是右边
                string pattern = @"^shu\d$";
                bool isTree = Regex.IsMatch(obstacle.objectShow, pattern);
                var tempTargetPos = targetPos;//缓存之前目标位置
                if (targetPos.x > transform.position.x)//如果目标在玩家右边，那么玩家停留到目标最左边
                {
                    if (!isTree)
                    {
                        targetPos = new Vector3((float)(targetPos.x - colliderSize.x / 2 * scaleX - 0.01), targetPos.y);
                    }
                    else
                    {
                        targetPos = new Vector3((float)(targetPos.x - colliderSize.x / 2 * scaleX - 0.01), (float)(targetPos.y + colliderSize.y / 2 * scaleY + 0.01));
                    }
                    isLeft = true;
                }
                else//否则停留在目标右边
                {
                    if (!isTree)
                    {
                        targetPos = new Vector3((float)(targetPos.x + colliderSize.x / 2 * scaleX + 0.01), targetPos.y);
                    }
                    else
                    {
                        targetPos = new Vector3((float)(targetPos.x + colliderSize.x / 2 * scaleX + 0.01), (float)(targetPos.y + colliderSize.y / 2 * scaleY + 0.01));
                    }
                    isLeft = false;
                }

                if (!map.PointIsValid(targetPos))//如果移动的点是无效 证明这个位置点不可走 取相反方向
                {
                    targetPos = tempTargetPos;//再重置回去
                    if (isLeft)//取右边
                    {
                        if (!isTree)
                        {
                            targetPos = new Vector3((float)(targetPos.x + colliderSize.x / 2 * scaleX + 0.01), targetPos.y);
                        }
                        else
                        {
                            targetPos = new Vector3((float)(targetPos.x + colliderSize.x / 2 * scaleX + 0.01), (float)(targetPos.y + colliderSize.y / 2 * scaleY + 0.01));
                        }
                        armatureComponent.transform.position = targetPos;
                    }
                    else//取左边
                    {
                        if (!isTree)
                        {
                            targetPos = new Vector3((float)(targetPos.x - colliderSize.x / 2 * scaleX - 0.01), targetPos.y);
                        }
                        else
                        {
                            targetPos = new Vector3((float)(targetPos.x - colliderSize.x / 2 * scaleX - 0.01), (float)(targetPos.y + colliderSize.y / 2 * scaleY + 0.01));
                        }
                        armatureComponent.transform.position = targetPos;
                    }
                }
                //直接瞬移过去
                Telesport(targetPos, clickPos);
                isPickingUp = true;//拾取中
                PlayAnimation("explore", false, () =>
                {
                    PlayAnimation("idle");
                    AdventureController.Instance.ReqClearObstacle((uint)obstacle.gridId);
                    isPickingUp = false;
                });
            };

            var gridConfig = AdventureModel.Instance.GetGridConfig(obstacle.gridId);
            if (gridConfig != null)
            {
                if (gridConfig.ObjectType == 4)//敌人挑战弹出敌人详情界面
                {
                    Debug.Log("弹出敌人详情界面");
                    //BattleController.Instance.ReqPveBattleStart(int.Parse(gridConfig.ClearReward));
                    //BattleController.Instance.ReqPvpBattleStart();
                    UIManager.Instance.OpenWindow<StartBattleWindow>(UIName.StartBattleWindow, obstacle.gridId);
                    //BattleController.Instance.ReqPveBattleStart(165);//写死165
                }
                else
                {
                    obstacle.ShowHideBubble(true);//障碍物弹出气泡框
                }
            }
            Debug.Log("点击的是障碍");
            return;
        }
        var curObstacle = AdventureModel.Instance.curObstacle;
        if (curObstacle != null)
        {
            curObstacle.ShowHideBubble(false);
            curObstacle = null;
        }
        var isBlocked = false;
        if (checkPathBlocked)//检测是否被阻挡
        {
            var checkObstacleIsBlock = map.CheckObstacleIsBlock(transform.position, targetPos);
            if (checkObstacleIsBlock)
            {
                Debug.LogWarning("前面有障碍物，路径被阻挡!");
                UILogicUtils.ShowNotice(Lang.GetValue("advantage_block_tips"));
                isBlocked = true;
            }
        }
        if (isBlocked) return;
        if (!map.PointIsValid(targetPos))//点击的点如果是无效的
        {
            if (closerPointOnInvalid)//开启寻路到离当前点最近的点
            {
                targetPos = map.GetCloserEdgePoint(targetPos);
                map.FindPath(transform.position, targetPos, (Vector2[] posList) =>
                {
                    if (posList != null && posList.Length > 0)
                    {
                        Debug.Log("posList:" + posList.Length);
                        var destination = posList[posList.Length - 1];
                        //if (posList.Length > 3)//有拐点直接瞬移
                        //{
                        //    Debug.Log("拐点瞬移");
                        //    //Telesport(targetPos, destination);
                        //    return;
                        //}
                        //if (CheckNeedTelesport(transform.position, destination))
                        //{
                        //    Debug.Log("距离过长瞬移");
                        //    //Telesport(targetPos, destination);
                        //}
                        //else
                        //{
                        lines = posList.ToList();
                        step = -1;
                        CancelInvoke("PlayRandomIdle");
                        Move();
                        //}
                    }
                    else
                    {
                        Debug.LogWarning("路径不可达!");
                        UILogicUtils.ShowNotice(Lang.GetValue("advantage_block_tips"));
                    }
                });
            }
            else
            {
                Debug.LogWarning("无效点路径范围不可达!");
                UILogicUtils.ShowNotice(Lang.GetValue("advantage_block_tips"));
            }
        }
        else
        {
            map.FindPath(transform.position, targetPos, (Vector2[] posList) =>
            {
                if (posList != null && posList.Length > 0)
                {
                    Debug.Log("posList:" + posList.Length);
                    var destination = posList[posList.Length - 1];
                    //if (posList.Length > 3)//有拐点直接瞬移
                    //{
                    //    Debug.Log("拐点瞬移");
                    //    Telesport(targetPos, destination);
                    //    return;
                    //}
                    //if (CheckNeedTelesport(transform.position, destination))
                    //{
                    //    Debug.Log("距离过长瞬移");
                    //    Telesport(targetPos, destination);
                    //}
                    //else
                    //{
                    lines = posList.ToList();
                    step = -1;
                    CancelInvoke("PlayRandomIdle");
                    Move();
                    //}
                }
                else
                {
                    Debug.LogWarning("路径不可达!");
                    UILogicUtils.ShowNotice(Lang.GetValue("advantage_block_tips"));
                }
            });
        }
    }

    /// <summary>
    /// 检测是否被雾阻挡
    /// </summary>
    /// <param name="worldPos"></param>
    /// <returns></returns>
    private bool CheckFogBlock(Vector2 worldPos)
    {
        // 获取所有重叠的雾对象（按渲染顺序从后到前）
        Fog[] overlappingFogs = GetOverlappingFogsAtPosition(worldPos);

        float combinedAlpha = 0f;
        float blockAlpha = 0.02f;//被阻挡阈值

        foreach (Fog fog in overlappingFogs)
        {
            // 获取当前雾在该位置的alpha值
            float fogAlpha = GetFogAlphaAtPosition(fog, worldPos);

            // 使用Alpha混合公式：resultAlpha = newAlpha + (1 - newAlpha) * oldAlpha
            combinedAlpha = fogAlpha + (1 - fogAlpha) * combinedAlpha;
            Debug.Log("combinedAlpha:" + combinedAlpha);
            // 如果累积alpha已经足够大，提前退出
            if (combinedAlpha > blockAlpha) return true;
        }

        Debug.Log("combinedAlpha:" + combinedAlpha);
        return combinedAlpha > blockAlpha;
    }

    // 获取某个位置所有重叠的雾对象
    Fog[] GetOverlappingFogsAtPosition(Vector2 worldPos)
    {
        // 使用OverlapPointAll获取所有碰撞体
        Collider2D[] colliders = Physics2D.OverlapPointAll(worldPos);

        // 筛选出Fog组件并按渲染顺序排序
        return colliders
            .Select(c => c.GetComponent<Fog>())
            .Where(f => f != null)
            .OrderBy(f => f.GetComponent<SpriteRenderer>().sortingOrder)
            .ToArray();
    }

    // 获取单个雾在指定位置的alpha值
    private float GetFogAlphaAtPosition(Fog fog, Vector2 worldPos)
    {
        if (fog == null) return 0f;
        SpriteRenderer renderer = fog.GetComponent<SpriteRenderer>();
        if (renderer == null || renderer.sprite == null) return 0f;

        // 1. 世界坐标 → 物体局部坐标
        Vector2 localPos = fog.transform.InverseTransformPoint(worldPos);

        // 2. 局部坐标 → 纹理UV坐标 (0-1范围)
        Sprite sprite = renderer.sprite;

        // 计算UV坐标（考虑sprite的pivot和像素密度）
        Vector2 uv = new Vector2(
            (localPos.x + sprite.pivot.x / sprite.pixelsPerUnit) / (sprite.rect.width / sprite.pixelsPerUnit),
            (localPos.y + sprite.pivot.y / sprite.pixelsPerUnit) / (sprite.rect.height / sprite.pixelsPerUnit)
        );

        // 3. 检查UV是否在有效范围内
        if (uv.x < 0 || uv.x > 1 || uv.y < 0 || uv.y > 1) return 0f;

        // 4. 获取纹理（确保可读）
        Texture2D texture = renderer.sprite.texture;
        if (!texture.isReadable)
        {
            Debug.LogError($"雾纹理不可读: {fog.name}，请在导入设置启用Read/Write Enabled");
            return 0f;
        }

        // 5. UV坐标 → 像素坐标（考虑sprite在图集中的偏移）
        int pixelX = (int)(uv.x * sprite.rect.width) + (int)sprite.rect.x;
        int pixelY = (int)(uv.y * sprite.rect.height) + (int)sprite.rect.y;

        // 6. 获取像素Alpha值
        return texture.GetPixel(pixelX, pixelY).a;
    }


    private bool CheckNeedTelesport(Vector3 fromPoint, Vector3 toPoint)
    {
        var dis = Vector3.Distance(fromPoint, toPoint);
        Debug.Log("CheckNeedTelesport dis:" + dis);
        if (dis > 10)//距离大于10 需要瞬移
        {
            return true;
        }
        return false;
    }

    private void OnResClearObstacle(ulong gridId)
    {
        OnPick((uint)gridId);
    }

    /// <summary>
    /// 开始拾取
    /// </summary>
    private void OnPick(uint gridId)
    {
        var pickObstacle = AdventureModel.Instance.GetObstacle((int)gridId);
        if (pickObstacle != null)
        {
            //请求服务器拾取 拾取完成飘奖励 
            Debug.Log("当前拾取Obstacle: " + pickObstacle.gridId);
            //隐藏迷雾
            foreach (var fog in pickObstacle.fogs)
            {
                FadeFog(fog.GetComponent<SpriteRenderer>());
            }
            pickObstacle.ShowHideBubble(false);
            pickObstacle.gameObject.SetActive(false);
        }
    }

    private void FadeFog(SpriteRenderer fogRender)
    {
        fogRender.DOFade(0, 0.5f).onComplete = () =>
        {
            fogRender.gameObject.SetActive(false);
        };
    }

    private void Move()
    {
        if (isPickingUp) return;//拾取中禁止移动
        this.step++;
        if (this.step + 1 >= this.lines.Count)//路线走完进入待机状态
        {
            var dis = Vector3.Distance(transform.position, targetPos);
            if (dis < 0.01f)
            {
                Debug.Log("到目标点");
                OnDestinationReached();
                this.Idle(true);
                return;
            }
            else
            {
                Debug.Log("没到目标点");
                OnDestinationReached();
                this.Idle(true);
                return;
                //this.lines.Add(targetPos);//添加目标点
            }
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
        float duration = distance * 1500 * speedAdjust / 1000.0f;

        if (moveSequence != null)
        {
            moveSequence.Kill();// 先终止当前的 Sequence
            moveSequence = null;
        }
        moveSequence = DOTween.Sequence(); // 重新创建 Sequence
        moveSequence.AppendCallback(() => PlayAnimation(mDirection + "walk"));
        moveSequence.Append(armatureComponent.transform.DOMove(new Vector2(endPoint.x, endPoint.y), duration).SetEase(Ease.Linear));
        moveSequence.AppendCallback(Move);
        isWalking = true;
    }

    /// <summary>
    /// 达到目的点
    /// </summary>
    private void OnDestinationReached()
    {
        //if (pickObstacle != null)
        //{
        //    OnPick();
        //}
    }

    /// <summary>
    /// 瞬移
    /// </summary>
    /// <param name="targetPos"></param>
    private void Telesport(Vector3 targetPos, Vector3 faceDirection)
    {
        if (isWalking)//如果移动中 那么停止移动
        {
            if (moveSequence != null)
            {
                moveSequence.Kill();// 先终止当前的 Sequence
                moveSequence = null;
            }
            Idle();
        }
        var p1 = armatureComponent.transform.position;
        var p2 = faceDirection;
        Face(p1, p2);
        Direction(p1, p2);
        armatureComponent.transform.position = targetPos;
    }

    public void Face(Vector3 p1, Vector3 p2)
    {
        if (p2.x < p1.x)
        {
            Debug.Log("向左...");
            mFace = 0; // Facing left
            armatureComponent.transform.localScale = Vector3.one * initScale;
        }
        else if (p2.x == p1.x)
        {
            Debug.Log("相等不改变方向...");
            //mFace = 0; // Facing left
            //armatureComponent.transform.localScale = Vector3.one * initScale;
        }
        else if (p2.x > p1.x)
        {
            Debug.Log("向右...");
            mFace = 1; // Facing right
            armatureComponent.transform.localScale = scaleFlipx * initScale; ;
        }
    }

    public void Direction(Vector3 p1, Vector3 p2)
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

    //待机
    private void Idle(bool playRandomIdle = false)
    {
        this.step = -1;
        this.mFace = 0;
        this.isWalked = true;
        PlayAnimation("idle");
        isWalking = false;
        //walkComplete?.Invoke(this);
        if (playRandomIdle)
        {
            CancelInvoke("PlayRandomIdle");
            Invoke("PlayRandomIdle", 5f);
        }
        else
        {
            CancelInvoke("PlayRandomIdle");
        }
    }

    private string[] randomIdles = { "idle", "idle1", "idle3" };
    private void PlayRandomIdle()
    {
        var ind = UnityEngine.Random.Range(0, randomIdles.Length);
        var idleAni = randomIdles[ind];
        PlayAnimation(idleAni);
    }

    private string lastAnimationName = "";
    private void PlayAnimation(string aniName, bool isLoop = true, Action aniFinishCall = null)
    {
        void OnAnimationEventHandler(Spine.TrackEntry trackEntry)
        {
            if (trackEntry.Animation.Name == lastAnimationName)
            {
                armatureComponent.AnimationState.Complete -= OnAnimationEventHandler;
                aniFinishCall?.Invoke();
            }
        }

        if (lastAnimationName == aniName) return;
        armatureComponent.AnimationState.SetAnimation(0, aniName, isLoop);
        lastAnimationName = aniName;
        if (aniFinishCall != null)
        {
            armatureComponent.AnimationState.Complete += OnAnimationEventHandler;
        }
    }


    // 判断点是否在 BoxCollider2D 范围内
    public bool IsPointInBoxCollider(BoxCollider2D boxCollider, Vector2 worldPoint)
    {
        // 自动处理旋转、缩放和偏移
        return boxCollider.OverlapPoint(worldPoint);
    }
}