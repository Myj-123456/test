
/// <summary>
/// 跳转类型
/// </summary>
public enum JumpType
{
    UI = 1,//ui
    SceneObject//场景对象 需要细分下面SceneObjectSubType
}

/// <summary>
/// 场景对象跳转类型
/// 目前分为三大类，后面跳转也根据这个
/// </summary>
public enum SceneObjectSubType
{
    FlowerStand = 1,//花台 跳转参数为花台id,总共6个，比如第一个就是1
    Structure = 2,//建筑物 跳转参数为建筑id
    Furniture = 3//家具 跳转参数为家具id
}

