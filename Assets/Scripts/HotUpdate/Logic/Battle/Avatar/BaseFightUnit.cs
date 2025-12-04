using ADK;
using FairyGUI;
using protobuf.login;
using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 战斗单元基类
/// </summary>
public class BaseFightUnit
{
    public ulong fightUnitId;//战斗单元id
    public SkeletonAnimation skeletonAnimation;
    public GComponent unitSkin;
    public bool isDie = false;//是否死亡
    public bool isShowDie = false;//是否死亡表现中
    public bool isShowRevive = false;//是否复活表现中
    public bool isMyCamp;//是否是我方 我方在左边 敌方在右边
    public bool isCril = false;//是否暴击
    public BaseFightUnit target;//攻击目标(受击者)
    private System.Action onAttack; // 触发攻击回调
    private System.Action onAttackFinishCall; // 攻击流程完毕回调
    private System.Action onDieFinishCall; // 死亡完毕回调
    private System.Action onReviveviFinishCall; // 复活完毕回调
    private Queue<FloatData> floatQueue = new Queue<FloatData>();

    /// <summary>
    /// 触发攻击回调
    /// </summary>
    protected void AttackCall()
    {
        onAttack?.Invoke();
        onAttack = null;
    }

    /// <summary>
    /// 攻击流程完毕回调
    /// </summary>
    protected void AttackFinishCall()
    {
        onAttackFinishCall?.Invoke();
        onAttackFinishCall = null;
    }

    public void SetAttack(System.Action callback)
    {
        onAttack = callback;
    }
    public void SetAttackFinishCall(System.Action callback)
    {
        onAttackFinishCall = callback;
    }

    public void SetDieFinishCall(System.Action callback)
    {
        onDieFinishCall = callback;
    }

    public void SetReviveviFinishCall(System.Action callback)
    {
        onReviveviFinishCall = callback;
    }

    protected void DieFinishCall()
    {
        onDieFinishCall?.Invoke();
        onDieFinishCall = null;
    }

    /// <summary>
    /// 攻击流程完毕回调
    /// </summary>
    protected void ReviveviFinishCall()
    {
        onReviveviFinishCall?.Invoke();
        onReviveviFinishCall = null;
    }

    /// <summary>
    /// 恢复动画
    /// </summary>
    public virtual void Resume()
    {

    }

    /// <summary>
    /// 暂停动画
    /// </summary>
    public virtual void Stop()
    {

    }

    public virtual void AddEffect(GLoader3D effect, EffectPos effectPos = EffectPos.Center, EffectOrientation effectOrientation = EffectOrientation.Default, float offY = -100)
    {

    }

    /// <summary>
    /// 改变动画速度
    /// </summary>
    /// <param name="timeScale"></param>
    public virtual void ChangeTimeScale(uint timeScale)
    {

    }


    /// <summary>
    /// 播放动作
    /// </summary>
    /// <param name="animation"></param>
    public void PlayAnimation(string animation)
    {

    }

    public virtual Vector2 GetHeroModelPos()
    {
        return Vector2.zero;
    }

    public virtual Vector2 GetHeroModelPos2()
    {
        return Vector2.zero;
    }

    /// <summary>
    /// 播放特效
    /// </summary>
    /// <param name="effectName"></param>
    public void PlayEffect(string effectName)
    {

    }

    /// <summary>
    /// 播放攻击动画
    /// </summary>
    public virtual void Attack()
    {
        if (skeletonAnimation != null)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, "walk", false);
        }
    }

    /// <summary>
    /// 受击
    /// </summary>
    public virtual void Hit()
    {
        if (skeletonAnimation != null)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, "Hit", false);
            skeletonAnimation.AnimationState.AddAnimation(0, "idle", true, 0);
        }
    }

    public virtual void UpdateHp(ulong enemyHealth)
    {

    }

    public virtual Vector2 GetHeadBarPos()
    {
        return Vector2.zero;
    }

    public virtual Vector2 GetHeadBarPos2()
    {
        return Vector2.zero;
    }

    public virtual bool CheckHaveBuff(ulong buffId)
    {
        return false;
    }

    public virtual void AddBuff(BuffSeqVo action)
    {

    }

    private Vector2 orginPos;//缓存原位置坐标


    /// <summary>
    /// 模拟近战单元移动到攻击目标位置
    /// </summary>
    /// <param name="target"></param>
    public void MoveToTarget(BaseFightUnit target, System.Action callback = null)
    {
        orginPos = unitSkin.position;
        var modelPos = target.GetHeroModelPos();
        unitSkin.TweenMove(new Vector2(modelPos.x, modelPos.y), 0.5f / BattleModel.Instance.TimeScale).OnComplete(() =>
          {
              callback?.Invoke();
          });
    }

    /// <summary>
    /// 复位
    /// </summary>
    /// <param name="callback"></param>
    public void MoveBack(System.Action callback = null)
    {
        if (orginPos != null)
        {
            unitSkin.TweenMove(orginPos, 0.5f / BattleModel.Instance.TimeScale).OnComplete(() =>
            {
                callback?.Invoke();
            });
        }
    }


    /// <summary>
    /// 死亡
    /// </summary>
    public virtual void Die()
    {
        isDie = true;
        isShowDie = true;
        isShowRevive = false;
    }

    /// <summary>
    /// 复活
    /// </summary>
    public virtual void Revive()
    {
        isDie = false;
        isShowDie = false;
        isShowRevive = true;
    }


    private bool isProcessing = false;//队列是否播放中
    /// <summary>
    /// 添加飘字进队列
    /// </summary>
    public void AddFloatInQueen(TriggerCombatAttribute triggerCombatAttribute, string damage = "")
    {
        var floatData = FloatHelper.CreatFloatData(this, triggerCombatAttribute, damage);
        floatQueue.Enqueue(floatData);
        // 如果当前没有在处理队列，就开始处理
        if (!isProcessing)
        {
            Coroutiner.StartCoroutine(ProcessFloatQueue());
        }
    }

    /// <summary>
    /// 处理飘字队列的协程
    /// </summary>
    private IEnumerator ProcessFloatQueue()
    {
        isProcessing = true;
        // 当队列不为空时，持续处理
        while (floatQueue.Count > 0)
        {
            // 取出队列中的第一个元素
            FloatData currentData = floatQueue.Dequeue();
            // 播放飘字
            PlayFloatHurt(currentData);
            // 等待0.3秒再处理下一个
            yield return new WaitForSeconds(0.3f / BattleModel.Instance.TimeScale);
        }
        isProcessing = false;
    }

    private void PlayFloatHurt(FloatData currentData)
    {
        if (currentData != null)
        {
            FloatHelper.ShowFloatHurt(currentData.target, currentData.triggerCombatAttribute, currentData.damage);
        }
    }
}
