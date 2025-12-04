using protobuf.messagecode;
using protobuf.fight;
using protobuf.adventure;
using protobuf.arena;
using protobuf.misc;

/// <summary>
/// 战斗控制器
/// </summary>
public class BattleController : BaseController<BattleController>
{
    protected override void InitListeners()
    {
        //AddNetListener<S_MSG_BATTLE_START>((int)MessageCode.S_MSG_BATTLE_START, ResPvpBattleStart);
        AddNetListener<S_MSG_ADVENTURE_STAGE>((int)MessageCode.S_MSG_ADVENTURE_STAGE, ResPveBattleStart);
    }

    ///// <summary>
    /////开始战斗pvp 
    ///// </summary>
    //public void ReqPvpBattleStart()
    //{
    //    C_MSG_BATTLE_START c_MSG_BATTLE = new C_MSG_BATTLE_START();
    //    SendCmd((int)MessageCode.C_MSG_BATTLE_START, c_MSG_BATTLE);
    //}

    /// <summary>
    /// 开始战斗pve
    /// </summary>
    /// <param name="islandStage"></param>
    public void ReqPveBattleStart(ulong islandStage = 0)
    {
        C_MSG_ADVENTURE_STAGE c_MSG_ADVENTURE_STAGE = new C_MSG_ADVENTURE_STAGE();
        c_MSG_ADVENTURE_STAGE.objectId = islandStage;
        SendCmd((int)MessageCode.C_MSG_ADVENTURE_STAGE, c_MSG_ADVENTURE_STAGE);
    }

    public void EnterPvpBattle(S_MSG_ARENA_FIGHT s_MSG_ARENA_FIGHT)
    {
        BattleModel.Instance.score = s_MSG_ARENA_FIGHT.score;
        BattleModel.Instance.items = s_MSG_ARENA_FIGHT.items;
        BattleModel.Instance.ParsePvpBattleData(s_MSG_ARENA_FIGHT.battleResult);
        EnterBattle();
    }

    //private void ResPvpBattleStart(S_MSG_BATTLE_START s_MSG_BATTLE_START)
    //{
    //    BattleModel.Instance.ParseBattleData(s_MSG_BATTLE_START);
    //    EnterBattle();
    //}

    private void ResPveBattleStart(S_MSG_ADVENTURE_STAGE s_MSG_ADVENTURE_STAGE)
    {
        BattleModel.Instance.ParsePveBattleData(s_MSG_ADVENTURE_STAGE);
        EnterBattle();
    }

    private void EnterBattle()
    {
        //SceneManager.Instance.ShowHideNpcLayer(false);
        UIManager.Instance.OpenWindow<BattleView>(UIName.BattleView);
    }

    public void CloseBattle()
    {
        //SceneManager.Instance.ShowHideNpcLayer(true);
        UIManager.Instance.CloseWindow(UIName.BattleView);
        var battleModel = BattleModel.Instance;//关闭界面再解锁
        if (battleModel.isPve && battleModel.isWin)//如果是pve并且赢了清除这个怪物障碍物
        {
            AdventureController.Instance.ReqClearObstacle((uint)battleModel.islandStage);
        }
        else if (!battleModel.isPve && battleModel.isWin)//关闭之后发奖励
        {
            var items = battleModel.items;
            if (items != null)
            {
                StorageModel.Instance.AddToStorage(items);
                battleModel.items = null;
            }
        }
    }

    public void ReqModulePower(uint type)
    {
        C_MSG_GET_MODULE_POWER c_MSG_GET_MODULE_POWER = new C_MSG_GET_MODULE_POWER();
        c_MSG_GET_MODULE_POWER.moduleId = type;
        SendCmd((int)MessageCode.C_MSG_GET_MODULE_POWER, c_MSG_GET_MODULE_POWER);
    }
}
