using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 花仙项扩展
/// </summary>
/// 
namespace fun_Battle
{
    public partial class FlowerFairiesItem
    {
        public int fairieId;//花仙id
        public ulong fightUnitId;//战斗单元id
        public bool isMyCamp;

        public void Attack()
        {
            PlayAttack(this, 20, 0.1f + 0.1f / BattleModel.Instance.TimeScale);
        }

        private float oldY = -1;
        /// <summary>
        /// 原地攻击动画
        /// </summary>
        /// <param name="target">目标显示对象</param>
        /// <param name="offY">Y轴偏移量(默认20)</param>
        /// <param name="time">动画时间(默认200ms)</param>
        private void PlayAttack(GObject target, float offY = 20f, float time = 0.2f)
        {
            // 移除现有的所有动画
            GTween.Kill(target);
            if (oldY == -1)
                oldY = target.y;
            target.y = oldY;
            float pos = oldY - offY;

            // 创建动画序列
            GTween.To(target.y, pos, time)
                .SetTarget(target)
                .SetEase(EaseType.QuintOut)
                .OnUpdate(tween =>
                {
                    target.y = tween.value.x;
                    target.scaleX = 1.1f;
                    target.scaleY = 1.1f;
                })
                .OnComplete(() =>
                {
                    // 返回原位的动画
                    GTween.To(pos, oldY, time * 1.5f)
                                .SetTarget(target)
                                .SetEase(EaseType.QuadOut)
                                .OnUpdate(returnTween =>
                                {
                                    target.y = returnTween.value.x;
                                    target.scaleX = 1f;
                                    target.scaleY = 1f;
                                });
                });
        }
    }
}
