using ADK;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 宠物战斗单元
/// </summary>
public class FightPetUnit : BaseFightUnit
{
    private fun_Battle.FightPetUnit fightPetUnitSkin;
    

    public void Init(fun_Battle.FightPetUnit fightPetUnit, bool isMyCamp, ulong petId)
    {
        unitSkin = fightPetUnit;
        fightPetUnitSkin = fightPetUnit;
        fightPetUnit.petModel.url = "pet/wenyy";
        fightPetUnit.petModel.animationName = "idle";
        fightPetUnit.petModel.loop = true;
        fightPetUnit.petModel.scaleX = 0.5f;
        this.isMyCamp = isMyCamp;
        if (!isMyCamp)
            fightPetUnit.petModel.scaleX *= -1;
        ChangeTimeScale(BattleModel.Instance.TimeScale);
    }

    public override void Attack()
    {
        if (fightPetUnitSkin.petModel.spineAnimation != null)
        {
            fightPetUnitSkin.petModel.spineAnimation.AnimationState.Complete += OnAnimationEventHandler;
            fightPetUnitSkin.petModel.spineAnimation.AnimationState.SetAnimation(0, "attack", false);
            Coroutiner.StartCoroutine(DelayAttackCall());
            fightPetUnitSkin.petModel.spineAnimation.AnimationState.AddAnimation(0, "idle", true, 0);
        }
    }

    /// <summary>
    /// 统一延迟0.2s回调攻击
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayAttackCall()
    {
        yield return new WaitForSeconds(0.2f / BattleModel.Instance.TimeScale);
        AttackCall();
    }

    private void OnAnimationEventHandler(Spine.TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "attack")//表示攻击完毕
        {
            fightPetUnitSkin.petModel.spineAnimation.AnimationState.Complete -= OnAnimationEventHandler;
            AttackFinishCall();//回调下一个流程
        }
    }

    public override void Resume()
    {
        if (fightPetUnitSkin.petModel.spineAnimation != null)
        {
            fightPetUnitSkin.petModel.spineAnimation.timeScale = lastTimeScale;
        }
    }

    private float lastTimeScale;
    

    public override void Stop()
    {
        if (fightPetUnitSkin.petModel.spineAnimation != null)
        {
            lastTimeScale = fightPetUnitSkin.petModel.spineAnimation.timeScale;
            fightPetUnitSkin.petModel.spineAnimation.timeScale = 0;
        }
    }

    public override void ChangeTimeScale(uint timeScale)
    {
        if (fightPetUnitSkin.petModel.spineAnimation != null)
        {
            fightPetUnitSkin.petModel.spineAnimation.timeScale = timeScale;
        }
    }
}
