using Elida.Config;
using protobuf.adventure;
using protobuf.login;
using protobuf.messagecode;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using YooAsset;

public class AdventureController : BaseController<AdventureController>
{
    protected override void InitListeners()
    {
        AddNetListener<S_MSG_ADVENTURE_CLEAR_OBSTACLE>((int)MessageCode.S_MSG_ADVENTURE_CLEAR_OBSTACLE, ResClearObstacle);
        AddNetListener<S_MSG_CRYSTALN_COLLECT>((int)MessageCode.S_MSG_CRYSTALN_COLLECT, ResCrystalnCollect);

        //探险信息
        AddNetListener<S_MSG_ADVENTURE_INFO>((int)MessageCode.S_MSG_ADVENTURE_INFO, AdventureInfo);
        //领取挂机奖励
        AddNetListener<S_MSG_ADVENTURE_SETTLE_REWARD>((int)MessageCode.S_MSG_ADVENTURE_SETTLE_REWARD, AdventureSettleReward);
        //领取事件奖励
        AddNetListener<S_MSG_ADVENTURE_EVENT>((int)MessageCode.S_MSG_ADVENTURE_EVENT, AdventureEventReward);
        //领取进度奖励
        AddNetListener<S_MSG_ADVENTURE_PROGRESS_REWARD>((int)MessageCode.S_MSG_ADVENTURE_PROGRESS_REWARD, AdventureProReward);
    }

    public void GoAdventure()
    {
        if (!GlobalModel.Instance.GetUnlocked(SysId.guildLeague, true))
        {
            return;
        }

        UIManager.Instance.CloseAll();
        SceneManager.Instance.SwitchSceneClearAll();
        UIManager.Instance.OpenPanel<ExploreTransitionsView>(UIName.ExploreTransitionsView, UILayer.Loading);
        //SkillManager.Instance.PaseSkillConfig();//预解析技能
        var package = YooAssets.GetPackage("DefaultPackage");
        var sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single;
        var physicsMode = LocalPhysicsMode.None;
        bool suspendLoad = false;
        SceneHandle handle = package.LoadSceneAsync(ResPath.GetScenePath("Adventure"), sceneMode, physicsMode, suspendLoad);
        handle.Completed += (SceneHandle handle) =>
        {
            MyselfModel.Instance.isInAdventure = true;
        };
    }

    public void QuitAdventure()
    {
        UIManager.Instance.CloseAll();
        var package = YooAssets.GetPackage("DefaultPackage");
        var sceneMode = UnityEngine.SceneManagement.LoadSceneMode.Single;
        var physicsMode = LocalPhysicsMode.None;
        bool suspendLoad = false;
        SceneHandle handle = package.LoadSceneAsync(ResPath.GetScenePath("Game"), sceneMode, physicsMode, suspendLoad);
        handle.Completed += (SceneHandle handle) =>
        {
            MyselfModel.Instance.isInAdventure = false;
        };
    }

    /// <summary>
    ///清除障碍物
    /// </summary>
    public void ReqClearObstacle(ulong objectId)
    {
        C_MSG_ADVENTURE_CLEAR_OBSTACLE c_MSG_ADVENTURE_CLEAR_OBSTACLE = new C_MSG_ADVENTURE_CLEAR_OBSTACLE();
        c_MSG_ADVENTURE_CLEAR_OBSTACLE.objectId = objectId;
        SendCmd((ushort)MessageCode.C_MSG_ADVENTURE_CLEAR_OBSTACLE, c_MSG_ADVENTURE_CLEAR_OBSTACLE);
    }

    private void ResClearObstacle(S_MSG_ADVENTURE_CLEAR_OBSTACLE s_MSG_ADVENTURE_GRID_LOCK)
    {
        AdventureModel.Instance.ClearObstacleUdpdateData(s_MSG_ADVENTURE_GRID_LOCK);
        //更新物品消耗
        var gridConfig = AdventureModel.Instance.GetGridConfig((int)s_MSG_ADVENTURE_GRID_LOCK.objectId);
        if (gridConfig != null)
        {
            var clearCosts = gridConfig.ClearCosts;
            foreach (var clearCost in clearCosts)
            {
                if (!string.IsNullOrEmpty(clearCost.EntityID))
                {
                    var itemId = ADK.IDUtil.GetEntityValue(clearCost.EntityID);
                    StorageModel.Instance.AddToStorageByItemId(itemId, -clearCost.Value);
                }
            }
        }
        DispatchEvent(AdventureEvent.ResClearObstacle, s_MSG_ADVENTURE_GRID_LOCK.objectId);
        if (s_MSG_ADVENTURE_GRID_LOCK.items.Count > 0)
        {
            var curObstacle = AdventureModel.Instance.curObstacle;
            if (curObstacle != null)
            {
                //飘物品奖励
                Vector2 pt = ADK.UILogicUtils.TransformPos(curObstacle.transform.position);
                DropManager.ShowDropFromPoint(ItemModel.Instance.GetDropData(s_MSG_ADVENTURE_GRID_LOCK.items), pt);
            }
        }
    }

    /// <summary>
    /// 请求领取玲珑球挂机奖励
    /// </summary>
    public void ReqCrystalnCollect()
    {
        C_MSG_CRYSTALN_COLLECT c_MSG_CRYSTALN_COLLECT = new C_MSG_CRYSTALN_COLLECT();
        SendCmd((ushort)MessageCode.C_MSG_CRYSTALN_COLLECT, c_MSG_CRYSTALN_COLLECT);
    }

    private void ResCrystalnCollect(S_MSG_CRYSTALN_COLLECT s_MSG_CRYSTALN_COLLECT)
    {
        DropManager.ShowDrop(ItemModel.Instance.GetDropData(s_MSG_CRYSTALN_COLLECT.items));
        AdventureModel.Instance.ClearCrystalnItemList();
        DispatchEvent(AdventureEvent.UpdateCrystalnItem);
    }
    //探险信息
    public void AdventureInfo(S_MSG_ADVENTURE_INFO data)
    {
        AdventureModel.Instance.adventureIsland = data.adventureIsland;
        AdventureModel.Instance.adventureTour = data.adventureTour;
        if(data.adventureTour.events == null)
        {
            AdventureModel.Instance.events = new List<uint>();
        }
        else
        {
            AdventureModel.Instance.events = data.adventureTour.events.ToList();
        }
        DispatchEvent(AdventureEvent.AdventureInfo);
    }

    public void ReqAdventureInfo()
    {
        C_MSG_ADVENTURE_INFO c_MSG_ADVENTURE_INFO = new C_MSG_ADVENTURE_INFO();
        SendCmd((ushort)MessageCode.C_MSG_ADVENTURE_INFO, c_MSG_ADVENTURE_INFO);
    }
    //领取挂机奖励
    public void AdventureSettleReward(S_MSG_ADVENTURE_SETTLE_REWARD data)
    {
        var dropList = ItemModel.Instance.GetDropData(AdventureModel.Instance.adventureTour.waitSettleRewards);
        DropManager.ShowDrop(dropList);
        AdventureModel.Instance.adventureTour = data.adventureTour;
        
        DispatchEvent(AdventureEvent.AdventureSettleReward);
    }

    public void ReqAdventureSettleReward()
    {
        C_MSG_ADVENTURE_SETTLE_REWARD c_MSG_ADVENTURE_SETTLE_REWARD = new C_MSG_ADVENTURE_SETTLE_REWARD();
        SendCmd((ushort)MessageCode.C_MSG_ADVENTURE_SETTLE_REWARD, c_MSG_ADVENTURE_SETTLE_REWARD);
    }
    //领取事件奖励
    public void AdventureEventReward(S_MSG_ADVENTURE_EVENT data)
    {
        if(AdventureModel.Instance.events.Count > data.index){
            AdventureModel.Instance.events.RemoveAt(data.index);
        }
        //var dropList = ItemModel.Instance.GetDropData(data.reward);
        //DropManager.ShowDrop(dropList);
        AdventureModel.Instance.adventureTour.waitSettleRewards = data.waitSettleRewards;
        DispatchEvent(AdventureEvent.AdventureEventReward);
    }

    public void ReqAdventureEventReward(int index,uint option)
    {
        C_MSG_ADVENTURE_EVENT c_MSG_ADVENTURE_EVENT = new C_MSG_ADVENTURE_EVENT();
        c_MSG_ADVENTURE_EVENT.index = index;
        c_MSG_ADVENTURE_EVENT.option = option;
        SendCmd((ushort)MessageCode.C_MSG_ADVENTURE_EVENT, c_MSG_ADVENTURE_EVENT);
    }
    //领取进度奖励
    public void AdventureProReward(S_MSG_ADVENTURE_PROGRESS_REWARD data)
    {
        var mapData = AdventureModel.Instance.GetIslandData(data.mapId);
        mapData.progressRewards = data.progressRewards;
        var mapInfo = AdventureModel.Instance.GetLandFromId((int)data.mapId);
        var dropList = new List<StorageItemVO>();
        foreach(var value in mapInfo.ProgressRewards)
        {
            var drop = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(value.EntityID);
            drop.itemDefId = itemVo.ItemDefId;
            drop.count = value.Value;
            dropList.Add(drop);
        }
        DropManager.ShowDrop(dropList);
        DispatchEvent(AdventureEvent.AdventureProReward);
    }

    public void ReqAdventureProReward(uint mapId,int index)
    {
        C_MSG_ADVENTURE_PROGRESS_REWARD c_MSG_ADVENTURE_PROGRESS_REWARD = new C_MSG_ADVENTURE_PROGRESS_REWARD();
        c_MSG_ADVENTURE_PROGRESS_REWARD.mapId = mapId;
        c_MSG_ADVENTURE_PROGRESS_REWARD.index = index;
        SendCmd((ushort)MessageCode.C_MSG_ADVENTURE_PROGRESS_REWARD, c_MSG_ADVENTURE_PROGRESS_REWARD);
    }
}
