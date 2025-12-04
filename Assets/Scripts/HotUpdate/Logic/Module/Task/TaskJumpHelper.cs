using Elida.Config;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 主线任务跳转辅助类
/// </summary>
public class TaskJumpHelper
{
    public static void JumpTask(uint taskId)
    {
        Debug.Log("任务跳转,taskId：" + taskId);
        var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskId);
        GuideModel.Instance.weakGuideGroupConfig = CreatWeakGuideGroupConfig(taskInfo);
        GuideModel.Instance.curWeakGuideStep = 0;//每次从这里跳转都重置引导步骤为0
        GuideController.Instance.ExecuteWeakGuideGroup();
    }

    /// <summary>
    /// 根据主线任务创建弱引导组
    /// </summary>
    private static WeakGuideGroupConfig CreatWeakGuideGroupConfig(Ft_task_mainConfig taskInfo)
    {
        WeakGuideGroupConfig weakGuideGroupConfig = new WeakGuideGroupConfig();
        weakGuideGroupConfig.groupId = taskInfo.Id;
        weakGuideGroupConfig.weakGuideStepConfigs = new List<WeakGuideStepConfig>();
        if (taskInfo.TaskType == 1)//收获XX花XX次
        {
            var land = SceneManager.Instance.GetUnLockEmptyLandByFlowerId(taskInfo.TypeParam);
            if (land != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 4;//地块
                weakGuideStepConfig.Param = land.landId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);

                //weakGuideStepConfig = new WeakGuideStepConfig();
                //weakGuideStepConfig.id = 2;
                //weakGuideStepConfig.GuideType = 1;
                //weakGuideStepConfig.Param = "MainView";//主界面
                //weakGuideStepConfig.TargetPath = "ui_chooseFlower/list_flower#0";//选择第一个花
                //weakGuideStepConfig.Delay = 0.6f;
                //weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 2)//制作XXX花瓶的插花X个
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 2;
            weakGuideStepConfig.SceneObjType = 3;//家具
            weakGuideStepConfig.Param = DecorationsType.Counter.ToString();//收银台
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);

            weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 2;
            weakGuideStepConfig.GuideType = 1;
            weakGuideStepConfig.Param = "IkeView";
            weakGuideStepConfig.TargetPath = "btn_select_1";
            weakGuideStepConfig.Delay = 0.5f;
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 3)//升级n次花
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 1;
            weakGuideStepConfig.Param = "MainView";
            weakGuideStepConfig.TargetPath = "bottomBtns/btn_baihualu";
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 4)//培育出n种花
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 2;
            weakGuideStepConfig.SceneObjType = 2;
            weakGuideStepConfig.Param = "29000002";//培育屋
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 5)//完成n个顾客订单
        {
            var npc = NpcManager.Instance.GetStandOrderNpc();
            if (npc != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 5;//npc
                weakGuideStepConfig.Param = npc.npcOrderVO.indexId.ToString();//npc indexId
                weakGuideStepConfig.PosOffset = new Vector2(30f, 30f);
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 6)//完成n个花市订单
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 2;
            weakGuideStepConfig.SceneObjType = 2;
            weakGuideStepConfig.Param = "29000013";
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 7)//在vip商店购买n次
        {
            UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView, UILayer.UI, 2);
        }
        else if (taskInfo.TaskType == 8)//培育商店内购买n次
        {
            UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView, UILayer.UI, 0);
        }
        else if (taskInfo.TaskType == 9)//完成黑板订单n次
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 2;
            weakGuideStepConfig.SceneObjType = 2;
            weakGuideStepConfig.Param = "29000008";
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 16)//种植xxx次鲜花
        {
            var land = SceneManager.Instance.GetUnLockEmptyLand();
            if (land != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 4;//地块
                weakGuideStepConfig.Param = land.landId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 17)//拥有xx个好友
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 1;
            weakGuideStepConfig.Param = "MainView";
            weakGuideStepConfig.TargetPath = "bottomBtns/btn_friend";
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 19)//解锁土地xxx块
        {
            var land = SceneManager.Instance.GetLockLand();
            if (land != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 4;
                weakGuideStepConfig.Param = land.landId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 20)//解锁花台xx个
        {
            var flowerStand = SceneManager.Instance.GetLockFlowerStand();
            if (flowerStand != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 1;
                weakGuideStepConfig.Param = flowerStand.flowerStandData.deskId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 23)//花台出售XXX插花作品n个
        {
            var flowerStand = SceneManager.Instance.GetUnLockEmptyFlowerStand();
            if (flowerStand != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 1;
                weakGuideStepConfig.Param = flowerStand.flowerStandData.deskId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("没有空花台");
            }
        }
        else if (taskInfo.TaskType == 24)//成功培育XX花
        {
            WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
            weakGuideStepConfig.id = 1;
            weakGuideStepConfig.GuideType = 2;
            weakGuideStepConfig.SceneObjType = 2;
            weakGuideStepConfig.Param = "29000002";//培育屋
            weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
        }
        else if (taskInfo.TaskType == 25)//上架X件花艺品（上架就算）
        {
            var flowerStand = SceneManager.Instance.GetUnLockEmptyFlowerStand();
            if (flowerStand != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 1;
                weakGuideStepConfig.Param = flowerStand.flowerStandData.deskId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
            else
            {
                ADK.UILogicUtils.ShowNotice("没有空花台");
            }
        }
        else if (taskInfo.TaskType == 26)//收集X个水桶
        {
            var bucket = BucketManager.Instance.GetBucket();
            if (bucket != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 6;
                weakGuideStepConfig.Param = bucket.id.ToString();
                weakGuideStepConfig.PosOffset = new Vector2(15f, 25f);
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 27)//去浇水XX块地
        {
            var land = SceneManager.Instance.GetWaterLand();
            if (land != null)
            {
                WeakGuideStepConfig weakGuideStepConfig = new WeakGuideStepConfig();
                weakGuideStepConfig.id = 1;
                weakGuideStepConfig.GuideType = 2;
                weakGuideStepConfig.SceneObjType = 4;//地块
                weakGuideStepConfig.Param = land.landId.ToString();
                weakGuideGroupConfig.weakGuideStepConfigs.Add(weakGuideStepConfig);
            }
        }
        else if (taskInfo.TaskType == 28)//花阁兑换鲜花X次
        {
            UIManager.Instance.OpenWindow<NpcCollectWindow>(UIName.NpcCollectWindow);
        }
        else if (taskInfo.TaskType == 32)//本周获得x活跃度
        {
            UIManager.Instance.OpenPanel<DailyTaskWindow>(UIName.DailyTaskWindow, UILayer.UI, 0);
        }
        return weakGuideGroupConfig;
    }
}
