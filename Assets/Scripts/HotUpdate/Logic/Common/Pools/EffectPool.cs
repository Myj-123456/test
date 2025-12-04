using System.Collections.Generic;
using FairyGUI;

/// <summary>
/// 特效对象池
/// </summary>
public class EffectPool
{
    private static EffectPool _instance;
    public static EffectPool Instance => _instance ?? (_instance = new EffectPool());

    private Dictionary<string, Queue<GLoader3D>> _effectPools = new Dictionary<string, Queue<GLoader3D>>();

    public GLoader3D GetEffect(string effectUrl)
    {
        // 如果池中没有该类型的特效或者池为空，则创建新的
        if (!_effectPools.ContainsKey(effectUrl) || _effectPools[effectUrl].Count == 0)
        {
            GLoader3D newEffect = (GLoader3D)UIObjectFactory.NewObject(ObjectType.Loader3D);
            newEffect.url = effectUrl;
            return newEffect;
        }

        // 从池中取出一个特效
        GLoader3D effect = _effectPools[effectUrl].Dequeue();
        effect.visible = true; // 确保特效可见
        return effect;
    }

    public void ReturnEffect(GLoader3D effect)
    {
        if (effect == null) return;

        string effectUrl = effect.url;

        // 初始化池如果不存在
        if (!_effectPools.ContainsKey(effectUrl))
        {
            _effectPools[effectUrl] = new Queue<GLoader3D>();
        }

        // 重置特效状态
        effect.visible = false;
        effect.RemoveFromParent();

        // 回收到池中
        _effectPools[effectUrl].Enqueue(effect);
    }
}