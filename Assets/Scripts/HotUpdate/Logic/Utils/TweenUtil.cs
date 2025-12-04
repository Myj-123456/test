using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUtil
{
    /// <summary>
    /// ÉÏÏÂÆ¯¸¡¶¯»­
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="floatAmount"></param>
    /// <param name="duration"></param>
    public static void FloatAnimation(Transform transform, float floatAmount = 0.1f, float duration = 1.2f)
    {
        if (transform == null) return;
        transform.DOKill();
        Vector3 initialPosition = transform.localPosition;
        transform.localPosition = initialPosition;
        transform.DOLocalMoveY(initialPosition.y + floatAmount, duration)
            .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    public static void HideTween(Transform transform)
    {
        if (transform == null) return;
        transform.DOKill();
    }
}
