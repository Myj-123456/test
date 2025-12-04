using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatData
{
    public BaseFightUnit target;
    public TriggerCombatAttribute triggerCombatAttribute;
    public string damage = "";
}

/// <summary>
/// 飘字辅助类
/// </summary>
public class FloatHelper
{

    private static Queue<fun_Battle.FloatHurt> floatHurtPool = new Queue<fun_Battle.FloatHurt>();

    private static GComponent floatLayer;

    /// <summary>
    /// 设置飘字层级
    /// </summary>
    /// <param name="gComponent"></param>
    public static void SetPlayLayer(GComponent layer)
    {
        floatLayer = layer;
    }

    public static FloatData CreatFloatData(BaseFightUnit target, TriggerCombatAttribute triggerCombatAttribute, string damage = "")
    {
        return new FloatData() { target = target, triggerCombatAttribute = triggerCombatAttribute, damage = damage };
    }

    /// <summary>
    /// 伤害飘字
    /// </summary>
    /// <param name="target">目标位置</param>
    /// <param name="damage">伤害值</param>
    public static void ShowFloatHurt(BaseFightUnit target, TriggerCombatAttribute triggerCombatAttribute, string damage = "")
    {
        var floatHurt = GetFloatHurtFromPool();
        if (floatHurt == null) return;

        target.unitSkin.AddChild(floatHurt);//添加到战斗单元身上
        var pos = target.GetHeadBarPos2();
        // 设置初始位置（目标位置上方一点）
        Vector2 startPos = pos + new Vector2(0, -60f);
        floatHurt.SetXY(startPos.x, startPos.y);

        floatHurt.visible = true;

        var ind = (int)triggerCombatAttribute;
        floatHurt.c1.selectedIndex = ind > 0 ? ind : 0;
        floatHurt.txt_damage.visible = floatHurt.txt_critDamage.visible = floatHurt.txt_cure.visible = !string.IsNullOrEmpty(damage) && (damage != "-0" || damage != "+0");
        floatHurt.txt_damage.text = damage.ToString();
        floatHurt.txt_critDamage.text = damage.ToString();
        floatHurt.txt_cure.text = damage.ToString();

        float duration = 1f / BattleModel.Instance.TimeScale;
        float moveDistance = -50f;

        // 使用 FairyGUI 的 GTween 实现上飘效果
        GTween.To(startPos.y, startPos.y + moveDistance, duration)
            .SetTarget(floatHurt) // 关联目标
            .SetEase(EaseType.QuadOut)
            .OnUpdate((GTweener tweener) =>
            {
                floatHurt.y = tweener.value.x; // 更新 Y 位置
            })
            .OnComplete(() =>
            {
                ReturnEffectToPool(floatHurt);
            });

        // 淡出效果
        GTween.To(1f, 0f, duration * 0.5f)
            .SetDelay(duration * 0.5f)
            .OnUpdate((GTweener tweener) =>
            {
                floatHurt.alpha = tweener.value.x;
            });
    }


    private static fun_Battle.FloatHurt GetFloatHurtFromPool()
    {
        // 池中有可用对象
        if (floatHurtPool.Count > 0)
        {
            var floatHurt = floatHurtPool.Dequeue();
            // 重置状态（特别是如果之前有淡出效果）
            floatHurt.alpha = 1f;
            return floatHurt;
        }
        else
        {
            var floatHurt = (fun_Battle.FloatHurt)fun_Battle.FloatHurt.CreateInstance().asCom;
            floatHurt.pivotX = 0.5f;
            floatHurt.pivotY = 0.5f;
            floatHurt.pivotAsAnchor = true;
            //GRoot.inst.AddChild(floatHurt);
            //floatLayer.AddChild(floatHurt);
            return floatHurt;
        }
    }

    private static void ReturnEffectToPool(fun_Battle.FloatHurt floatHurt)
    {
        floatHurt.visible = false;
        floatHurtPool.Enqueue(floatHurt);
    }
}
