using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FairyGUI;
using PolyNav;
using System.Linq;

/// <summary>
/// 场景主角模型控制器
/// </summary>
public class SceneHeroAvatarController : MonoBehaviour
{
    private PolyNavMap map;
    public SceneHeroAvatar heroAvatar;
    public bool isWalked;//是否走完全程
    private int step = -1;//是否立即行走
    private int mFace = 1;//朝向 0左 1右
    private string mDirection = "";//方向
    private Vector3 targetPos;
    private Sequence moveSequence;
    private Vector2[] lines;
    private float speedAdjust = 0.5f;//速度调节，默认都是1，越小npc走得越快 后续针对每个npc单独配置
    private Vector3 scaleFlipx = new Vector3(-1, 1, 1);
    private bool closerPointOnInvalid = false;
    private bool isWalking = false;
    public bool isPlanting = false;//是否种植中

    public void InitPolyNavMap(PolyNavMap map)
    {
        this.map = map;
    }

    private void OnEnable()
    {
        EventManager.Instance.AddEventListener<Vector3>(SceneEvent.OrgPointReleaseTouch, OnOrgPointReleaseTouch);
    }

    void OnDisable()
    {
        EventManager.Instance.RemoveEventListener<Vector3>(SceneEvent.OrgPointReleaseTouch, OnOrgPointReleaseTouch);
    }

    public void StopWalking()
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
    }

    /// <summary>
    /// 点击原点释放
    /// </summary>
    private void OnOrgPointReleaseTouch(Vector3 targetPos)
    {
        if (GuideModel.Instance.IsPrequelPlotGuiding) return;
        if (heroAvatar == null || !heroAvatar.IsActive || isPlanting)
        {
            return;
        }
        this.targetPos = targetPos;

        if (!map.PointIsValid(targetPos))//点击的点如果是无效的
        {
            if (closerPointOnInvalid)//开启寻路到离当前点最近的点
            {
                targetPos = map.GetCloserEdgePoint(targetPos);
                map.FindPath(transform.position, targetPos, (Vector2[] posList) =>
                {
                    if (posList != null && posList.Length > 0)
                    {
                        SceneManager.Instance.ShowNavPointMark(targetPos, true);
                        lines = posList;
                        step = -1;
                        CancelInvoke("PlayRandomIdle");
                        Move();
                    }

                });
            }
        }
        else
        {
            map.FindPath(transform.position, targetPos, (Vector2[] posList) =>
            {
                if (posList != null && posList.Length > 0)
                {
                    SceneManager.Instance.ShowNavPointMark(targetPos, true);
                    lines = posList;
                    step = -1;
                    CancelInvoke("PlayRandomIdle");
                    Move();
                }

            });
        }

    }
    private void Move()
    {
        this.step++;
        if (this.step + 1 >= this.lines.Length)//路线走完进入待机状态
        {
            var dis = Vector3.Distance(transform.position, targetPos);
            if (dis < 0.01f)
            {
                Debug.Log("到目标点");
                this.Idle(true);
                SceneManager.Instance.ShowNavPointMark(targetPos, false);
                return;
            }
            else
            {
                Debug.Log("没到目标点");
                SceneManager.Instance.ShowNavPointMark(targetPos, false);
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
        //if (p1.time > 0)
        //{
        //    moveSequence.AppendCallback(() => PlayAnimation("idle"));
        //    moveSequence.AppendInterval(p1.time);
        //}
        moveSequence.AppendCallback(() => PlayAnimation(mDirection + "walk"));
        moveSequence.Append(heroAvatar.body.transform.DOMove(new Vector2(endPoint.x, endPoint.y), duration).SetEase(Ease.Linear));
        moveSequence.AppendCallback(Move);
        isWalking = true;
    }

    public void Face(Vector3 p1, Vector3 p2)
    {
        if (p2.x < p1.x)
        {
            mFace = 0; // Facing left
            heroAvatar.SetScale(Vector3.one);
        }
        else if (p2.x > p1.x)
        {
            mFace = 1; // Facing right
            heroAvatar.SetScale(scaleFlipx);
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
        //heroAvatar.SetScale(Vector3.one);
        this.isWalked = true;
        PlayAnimation("idle");
        isWalking = false;
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
        var ind = Random.Range(0, randomIdles.Length);
        var idleAni = randomIdles[ind];
        PlayAnimation(idleAni);
    }

    private string lastAnimationName = "";
    private void PlayAnimation(string aniName)
    {
        if (lastAnimationName == aniName) return;
        heroAvatar.PlayAnimation(aniName, true);
        lastAnimationName = aniName;
    }

}
