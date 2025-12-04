

using Elida.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;
using YooAsset;

public class LineVO
{
    public float x;
    public float y;
    public float time;//在当前点位停留时间
    public List<float> standings;//订单npc站立的位置
}

/// <summary>
/// NPC管理器 负责npc生成 npc行走路线生成
/// </summary>
public class NpcManager : Singleton<NpcManager>
{
    private static Ft_ground_lineConfigData ground_LineConfigData;
    private static Ft_npcorder_walkConfigData npcorder_walkConfigData;
    private static Ft_npcConfigData game_npcConfigData;


    private Dictionary<int, LineVO[]> lineDic = new Dictionary<int, LineVO[]>();//普通npc路线
    private Dictionary<uint, Npc> npcDic;//当前场景存在的普通npc
    private Dictionary<string, Stack<Npc>> npcPools;//npc池子
    private Dictionary<uint, Stack<OrderNpc>> orderNpcPools;//订单npc池子
    private Dictionary<uint, OrderNpc> orderNpcDic;//当前场景存在的订单npc
    private Dictionary<int, LineVO[]> orderNpcLineDic = new Dictionary<int, LineVO[]>();//订单npc路线
    private bool isHideNpc = false;
    public bool npcOrderUnOpen = false;


    public NpcManager()
    {
        ground_LineConfigData = ConfigManager.Instance.GetConfig<Ft_ground_lineConfigData>("ft_ground_linesConfig");
        npcorder_walkConfigData = ConfigManager.Instance.GetConfig<Ft_npcorder_walkConfigData>("ft_npcorder_walksConfig");
        game_npcConfigData = ConfigManager.Instance.GetConfig<Ft_npcConfigData>("ft_npcsConfig");
    }

    public void ShowDebugNpcLine(GameObject circle, Transform transform)
    {
        var lines = GetNpcWalkLine(2);
        foreach (var line in lines)
        {
            var circleObj = GameObject.Instantiate(circle, transform);
            circleObj.transform.localPosition = new Vector2(line.x, line.y);
        }

    }


    /// <summary>
    /// 随机获取一个npc行走路径
    /// </summary>
    /// <returns></returns>
    private LineVO[] GetNpcWalkLine(int lineId = -1)
    {
        var lineCount = ground_LineConfigData.DataList.Count;
        var randomId = lineId >= 0 ? lineId : Random.Range(0, lineCount);

        if (lineDic.TryGetValue(randomId, out LineVO[] value))
        {
            return value;
        }
        var randomLine = ground_LineConfigData.DataList[randomId];
        var len = randomLine.Times.Length;
        var lineVos = new LineVO[len];

        for (var i = 0; i < len; i++)
        {
            lineVos[i] = new LineVO() { x = randomLine.Coordinate_xs[i], y = randomLine.Coordinate_ys[i], time = randomLine.Times[i] };
        }
        lineDic.Add(randomId, lineVos);
        return lineVos;
    }

    /// <summary>
    /// 随机获取一个订单npc行走路径
    /// </summary>
    /// <returns></returns>
    private LineVO[] GetOrderNpcWalkLine(int lineId = 0)
    {
        var lineCount = npcorder_walkConfigData.DataList.Count;
        var randomId = lineId > 0 ? lineId : Random.Range(0, lineCount);

        if (orderNpcLineDic.TryGetValue(randomId, out LineVO[] value))
        {
            return value;
        }
        var randomLine = npcorder_walkConfigData.DataMap[randomId];
        var len = randomLine.PcStation_Xs.Length;
        var lineVos = new LineVO[len];

        for (var i = 0; i < len; i++)
        {
            lineVos[i] = new LineVO() { x = randomLine.PcStation_Xs[i], y = randomLine.NpcStation_Ys[i], standings = new List<float>(randomLine.Standings) };
        }
        orderNpcLineDic.Add(randomId, lineVos);
        return lineVos;
    }


    private Timer npcTimer;
    private Timer orderNpcTimer;
    private Transform npcLayer;
    private uint npcId = 0;
    private uint orderNpcId = 0;
    private float waitCreateTime = 0f;
    private const float waitCreateTimeGap = 0.033f;
    private int startLandId = 0;
    /// <summary>
    /// 生成npc
    /// </summary>
    public void StartCreatNpc(Transform npcLayer)
    {
        npcPools = new Dictionary<string, Stack<Npc>>();
        orderNpcPools = new Dictionary<uint, Stack<OrderNpc>>();
        npcDic = new Dictionary<uint, Npc>();
        orderNpcDic = new Dictionary<uint, OrderNpc>();
        startLandId = 0;
        waitCreateTime = 0;
        this.npcLayer = npcLayer;
        StartNpc();
        StartOrderNpc(true);
    }

    //定时生成普通npc
    public void StartNpc()
    {
        if (npcTimer != null)
        {
            npcTimer.Cancel();
            npcTimer = null;
        }
        npcTimer = Timer.Regist(GlobalModel.Instance.module_profileConfig.npcFrequency, OnTimer, true);
    }

    private List<NpcOrderVO> npcOrderList;
    //开始生成订单npc
    public void StartOrderNpc(bool isWaitCreateTime)
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.NpcOrder))//功能未开启
        {
            npcOrderUnOpen = true;
            return;
        }
        npcOrderUnOpen = false;
        if (NpcOrderModel.Instance.npcOrderRefreshTime != 4070880000 && NpcOrderModel.Instance.npcOrderRefreshTime >= ServerTime.Time)
        {
            //刚上线 计算下订单npc刷新时间
            var delayTime = NpcOrderModel.Instance.npcOrderRefreshTime - ServerTime.Time;
            AutoAddOrderNpc(delayTime);
        }
        //清掉旧的
        ClearOrderNpcs();
        npcOrderList = NpcOrderModel.Instance.npcOrderList;
        if (npcOrderList.Count > 0)
        {
            //创建新的
            foreach (var npcOrder in npcOrderList)//直接创建出来
            {
                CreateNpcOrder(npcOrder, isWaitCreateTime);
            }
        }
    }

    private void OnTimer()
    {
        if (GuideModel.Instance.IsPrequelPlotGuiding) return;
        if (npcDic.Count < GlobalModel.Instance.module_profileConfig.npcLimit)
        {
            CreatNpc();
        }
    }

    private void OnOrderTimer()
    {
        NpcOrderController.Instance.ReqGetNpcOrder();
    }

    /// <summary>
    /// 停止生成普通npc
    /// </summary>
    public void StopAutoCreatNpc()
    {
        if (npcTimer != null)
        {
            npcTimer.Cancel();
            npcTimer = null;
        }
    }

    public void StopCreatOrderNpc()
    {
        if (orderNpcTimer != null)
        {
            orderNpcTimer.Cancel();
            orderNpcTimer = null;
        }
    }

    public void ClearAllNpcs()
    {
        StopAutoCreatNpc();
        StopCreatOrderNpc();
        ClearNpcs();
        ClearOrderNpcs();
    }


    private uint CreateNpcId => ++npcId;
    private uint CreateOrderNpcId => ++orderNpcId;
    public void CreatNpc(Transform npcLayer, uint id, int lineId)
    {
        this.npcLayer = npcLayer;
        var npcId = CreateNpcId;
        var lines = GetNpcWalkLine(lineId);
        AddNpc(npcId, "lu", lines);
    }

    /// <summary>
    /// 添加一个随机npc走随机线路
    /// </summary>
    public void CreatNpc()
    {
        if (isHideNpc) return;
        var npcId = CreateNpcId;
        var lines = GetNpcWalkLine();
        var ft_game_npcConfig = GetRandomNpcConfig();
        if (ft_game_npcConfig != null)
        {
            AddNpc(npcId, ft_game_npcConfig.Resouce, lines);
        }
    }

    /// <summary>
    /// 添加一个普通npc
    /// </summary>
    private void AddNpc(uint npcId, string npcResId, LineVO[] lines)
    {
        Npc npc = GetFromNpcPool(npcResId);
        if (npc == null)
        {
            npc = new Npc();
        }
        npc.Init(npcId, npcResId, npcLayer, lines);
        npc.walkComplete = OnNpcWalkComplete;
        npcDic.Add(npcId, npc);
    }

    /// <summary>
    /// 添加一个订单npc
    /// </summary>
    /// <param name="npcOrderVO"></param>
    public void CreateNpcOrder(NpcOrderVO npcOrderVO, bool isWaitCreateTime)
    {
        if (orderNpcDic.Count < GlobalModel.Instance.module_profileConfig.mostTasksExist)//判断NPC订单上限
        {
            CreatOrderNpc(npcOrderVO, isWaitCreateTime);
            if (orderNpcTimer != null && orderNpcTimer.isDone)
            {
                AutoAddOrderNpc();
            }
        }
        else
        {
            if (orderNpcTimer != null)
            {
                orderNpcTimer.Cancel();
            }
        }
    }

    private void AutoAddOrderNpc(float delayTime = 0)
    {
        float delay = 0;
        if (!TaskModel.Instance.CheckIsCompleteTask(10))//引导中需要让npc早点出现，不然会导致引导报错
        {
            delay = 1;
        }
        else
        {
            delay = delayTime > 0 ? delayTime : GlobalModel.Instance.module_profileConfig.npcRefreshTime;
        }

        if (orderNpcTimer != null)
        {
            orderNpcTimer.Cancel();
            orderNpcTimer = Timer.Regist(delay, OnOrderTimer);
        }
        else
        {
            orderNpcTimer = Timer.Regist(delay, OnOrderTimer);
        }
    }

    public void CreatOrderNpc(NpcOrderVO npcOrderVO, bool isWaitCreateTime)
    {
        var lines = GetOrderNpcWalkLine((int)npcOrderVO.indexId);
        //var npc = npcOrderVO.npc.Replace("_ske", "");
        //var npc = "npc_4";
        AddOrderNpc(npcOrderVO, npcOrderVO.npc, lines, isWaitCreateTime);
    }

    private void UnCoroutineAddOrderNpc(NpcOrderVO npcOrderVO, uint npcId, LineVO[] lines)
    {
        void OrderNpcInit(GameObject npc)
        {
            npc.transform.SetParent(npcLayer, false);
            var orderNpc = npc.GetComponent<OrderNpc>();
            orderNpc.npcOrderVO = npcOrderVO;
            orderNpc.Init(npcOrderVO.indexId, npcId, npcLayer, lines);
            if (isHideNpc) orderNpc.visible = false;//隐藏状态设置不可见
            else orderNpc.visible = true;
            orderNpc.walkComplete = OnOrderNpcWalkComplete;
            orderNpcDic.Add(npcOrderVO.indexId, orderNpc);
        }

        OrderNpc orderNpc = GetFromOrderNpcPool(npcOrderVO.npc);
        if (orderNpc != null)
        {
            orderNpc.npcOrderVO = npcOrderVO;
            orderNpc.Init(npcOrderVO.indexId, npcId, npcLayer, lines);
            if (isHideNpc) orderNpc.visible = false;//隐藏状态设置不可见
            else orderNpc.visible = true;
            orderNpc.walkComplete = OnOrderNpcWalkComplete;
            orderNpcDic.Add(npcOrderVO.indexId, orderNpc);
        }
        else
        {
            var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("Npc/Npc"));
            assetHandle.Completed += (AssetHandle handle) =>
            {
                var npcObject = assetHandle.InstantiateSync();
                OrderNpcInit(npcObject);
            };
        }
    }

    //private IEnumerator CoroutineAddOrderNpc(NpcOrderVO npcOrderVO, string npcResId, LineVO[] lines, float waitCreateTime)
    //{
    //    void OrderNpcInit(GameObject npc)
    //    {
    //        npc.transform.SetParent(npcLayer, false);
    //        var orderNpc = npc.GetComponent<OrderNpc>();
    //        orderNpc.npcOrderVO = npcOrderVO;
    //        orderNpc.Init(npcOrderVO.indexId, npcResId, npcLayer, lines);
    //        orderNpc.walkComplete = OnOrderNpcWalkComplete;
    //        orderNpcDic.Add(npcOrderVO.indexId, orderNpc);
    //    }

    //    yield return new WaitForSeconds(waitCreateTime);

    //    GameObject npc = null;
    //    if (orderNpcPools.Count > 0)
    //    {
    //        npc = GetFromOrderNpcPool();
    //        npc.SetActive(true);
    //        OrderNpcInit(npc);
    //    }
    //    if (npc == null)
    //    {
    //        var assetHandle = ResourceManager.Instance.LoadAssetAsync<GameObject>(ResPath.GetPrefabPath("Npc/Npc"));
    //        assetHandle.Completed += (AssetHandle handle) =>
    //        {
    //            var npcObject = assetHandle.InstantiateSync();
    //            OrderNpcInit(npcObject);
    //        };
    //    }
    //}


    /// <summary>
    /// 添加一个订单npc
    /// </summary>
    private void AddOrderNpc(NpcOrderVO npcOrderVO, uint npc, LineVO[] lines, bool isWaitCreateTime = false)
    {
        //if (isWaitCreateTime)
        //{
        //    waitCreateTime = waitCreateTimeGap * startLandId;
        //    startLandId += 1;
        //    ADK.Coroutiner.StartCoroutine(CoroutineAddOrderNpc(npcOrderVO, npcResId, lines, waitCreateTime));
        //}
        //else
        //{
        UnCoroutineAddOrderNpc(npcOrderVO, npc, lines);
        //}
    }

    private void OnOrderNpcWalkComplete(OrderNpc npc)
    {
        ClearOrderNpc(npc);
    }

    private void ClearNpcs()
    {
        foreach (var keyValue in npcDic)
        {
            var npc = keyValue.Value;
            npc.Clear();
            ReturnToNpcPool(npc);
        }
        npcDic.Clear();
    }

    private void ClearOrderNpcs()
    {
        foreach (var keyValue in orderNpcDic)
        {
            var orderNpc = keyValue.Value;
            orderNpc.Clear();
            ReturnToOrderNpcPool(orderNpc);
        }
        orderNpcDic.Clear();
    }

    private void ClearOrderNpc(OrderNpc npc)
    {
        if (npc == null) return;
        if (orderNpcDic.ContainsKey(npc.indexId))
        {
            orderNpcDic.Remove(npc.indexId);
            npc.Clear();
            ReturnToOrderNpcPool(npc);
        }
    }

    public OrderNpc GetOrderNpc(uint indexId)
    {
        if (orderNpcDic.TryGetValue(indexId, out OrderNpc orderNpc))
        {
            return orderNpc;
        }
        return null;
    }

    /// <summary>
    /// 获取待机等待订单的npc
    /// </summary>
    /// <returns></returns>
    public OrderNpc GetStandOrderNpc()
    {
        foreach (var npc in orderNpcDic)
        {
            if (npc.Value.visible && npc.Value.npcOrderVO != null && npc.Value.npcOrderVO.isStandInScene)
            {
                return npc.Value;
            }
        }
        return null;
    }


    /// <summary>
    /// 根据花艺品获取一个订单npc
    /// </summary>
    /// <returns></returns>
    public OrderNpc GetOrderNpcByFormulaId(int formulaId)
    {
        foreach (var npc in orderNpcDic)
        {
            if (npc.Value.visible && npc.Value.npcOrderVO != null && npc.Value.npcOrderVO.isStandInScene)
            {
                if (formulaId == (int)npc.Value.npcOrderVO.orderId)
                {
                    return npc.Value;
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnNpcWalkComplete(Npc npc)
    {
        ClearNpc(npc);
    }

    private void ClearNpc(Npc npc)
    {
        if (npcDic.ContainsKey(npc.npcId))
        {
            npc.Clear();
            npcDic.Remove(npc.npcId);
            ReturnToNpcPool(npc);
        }
    }

    private void ReturnToNpcPool(Npc npc)
    {
        Stack<Npc> stackNpc = null;
        if (!npcPools.TryGetValue(npc.npcResId, out stackNpc))
        {
            stackNpc = new Stack<Npc>();
            npcPools.Add(npc.npcResId, stackNpc);
        }
        stackNpc.Push(npc);
    }

    private Npc GetFromNpcPool(string npcResId)
    {
        Stack<Npc> stackNpc;
        if (npcPools.TryGetValue(npcResId, out stackNpc))
        {
            if (stackNpc.Count > 0)
            {
                return stackNpc.Pop();
            }
        }
        return null;
    }

    private void ReturnToOrderNpcPool(OrderNpc npc)
    {
        Stack<OrderNpc> stackNpc = null;
        if (!orderNpcPools.TryGetValue(npc.npc, out stackNpc))
        {
            stackNpc = new Stack<OrderNpc>();
            orderNpcPools.Add(npc.npc, stackNpc);
        }
        stackNpc.Push(npc);
    }

    private OrderNpc GetFromOrderNpcPool(uint npcId)
    {
        Stack<OrderNpc> stackNpc;
        if (orderNpcPools.TryGetValue(npcId, out stackNpc))
        {
            if (stackNpc.Count > 0)
            {
                return stackNpc.Pop();
            }
        }
        return null;
    }

    public void OrderNpcLeave(uint indexId, uint type)
    {
        var orderNpc = GetOrderNpc(indexId);
        if (orderNpc != null)
        {
            orderNpc.npcOrderVO = null;
            orderNpc.Leave(type);
        }
        AutoAddOrderNpc();//检测下个订单
    }

    /// <summary>
    /// 获取一个npc配置
    /// </summary>
    /// <param name="npcId"></param>
    /// <returns></returns>
    public Ft_npcConfig GetNpcConfig(int npcId)
    {
        return game_npcConfigData.Get(npcId);
    }
    /// <summary>
    /// 随机获取一个npc配置
    /// </summary>
    /// <returns></returns>
    public NpcConfig GetRandomNpcConfig()
    {
        var unLockNpcs = CustomerModel.Instance.GetAllUnLockNpc();
        if (unLockNpcs.Count <= 0) return null;
        return unLockNpcs[Random.Range(0, unLockNpcs.Count)];
    }

    public void HideAllNpc()
    {
        isHideNpc = true;
        foreach (var npc in npcDic)
        {
            npc.Value.visible = false;
        }

        foreach (var orderNpc in orderNpcDic)
        {
            orderNpc.Value.visible = false;
        }
    }

    public void ShowAllNpc()
    {
        isHideNpc = false;
        foreach (var npc in npcDic)
        {
            npc.Value.visible = true;
        }

        foreach (var orderNpc in orderNpcDic)
        {
            orderNpc.Value.visible = true;
        }
    }
}
