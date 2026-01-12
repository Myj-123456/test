
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Elida.Config;
using Spine;

public class LevelupWindow : BaseWindow
{
    private fun_LevelUp.levelup view;
    private List<StorageItemVO> listData;
    private List<StorageItemVO> shareRewardData;
    private Ft_player_levelConfig levelData;
    private bool inited = false;
    public LevelupWindow()
    {
        packageName = "fun_LevelUp";
        // 设置委托
        BindAllDelegate = fun_LevelUp.fun_LevelUpBinder.BindAll;
        CreateInstanceDelegate = fun_LevelUp.levelup.CreateInstance;
        ClickBlankClose = true;
        openWithTween = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_LevelUp.levelup;
        StringUtil.SetBtnTab(view.share_btn, Lang.GetValue("text_breed36"));
        //PlaySpine();

        view.share_btn.onClick.Add(() =>
        {
            ShareController.Instance.ReqShareLevelReward();
        });
        EventManager.Instance.AddEventListener<List<StorageItemVO>>(ShareEvent.ShareLevelReward, UpdateShare);
        
        view.list.itemRenderer = RenderLevelItem;
        view.list2.itemRenderer = RenderShareItem;
    }

    private void UpdateShare(List<StorageItemVO> data)
    {
        view.share_btn.visible = false;

        shareRewardData = data;
        view.list2.numItems = shareRewardData.Count;
    }
    private void PlaySpine()
    {
        if (!inited)
        {
            view.spine.url = "dengji";
            view.spine.Complete = OnAnimationEventHandler;
            view.spine.forcePlay = true;
            inited = true;
        }

        view.anim.Play();
        view.spine.loop = false;
        view.spine.animationName = "open";
    }
    private void OnAnimationEventHandler(string name)
    {
        if (name == "open")
        {
            view.spine.loop = true;
            view.spine.animationName = "loop";
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //if (inited)
        //{
        //    PlaySpine();
        //}
        view.share_btn.visible = true;
        view.level_txt.text = MyselfModel.Instance.level.ToString();
        levelData = PlayerModel.Instance.GetLevelupBonus((int)MyselfModel.Instance.level);
        listData = new List<StorageItemVO>();
        var stepLevel = (uint)data;
        var minLevel = (int)MyselfModel.Instance.level - stepLevel;
        for (int i = (int)MyselfModel.Instance.level; i > minLevel; i--)
        {
            var levelConfig = PlayerModel.Instance.GetLevelupBonus(i);
            if (levelConfig != null)
            {
                var rewards = levelConfig.Rewards;
                foreach (var reward in rewards)
                {
                    var item = new StorageItemVO();
                    var itemConfig = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
                    item.itemDefId = itemConfig.ItemDefId;
                    item.count = reward.Value;
                    item.item = itemConfig;
                    listData.Add(item);
                }
            }
        }
        view.list.numItems = listData.Count;
        LoadShareRewards();
    }

    private void RenderLevelItem(int index,GObject item)
    {
        var ui_ = item as fun_LevelUp.level_item;
        var info = listData[index];
        var itemVo = ItemModel.Instance.GetItemById(info.itemDefId);
        if(itemVo.Type == 4001)
        {
            var plant = FlowerHandbookModel.Instance.GetStaticSeedCondition(info.itemDefId);
            ui_.bg.url = "MyInfo/show_flower_bg" + plant.FlowerQuality + ".png";
        }
        else
        {
            ui_.bg.url = "MyInfo/show_flower_bg1.png";
        }
        ui_.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        ui_.number.text = info.count.ToString();
    }

    private void RenderShareItem(int index,GObject item)
    {
        var ui_ = item as fun_LevelUp.share_item;
        var info = shareRewardData[index];
        var itemVo = ItemModel.Instance.GetItemById(info.itemDefId);
        ui_.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        ui_.number.text = info.count.ToString();
    }

    private void LoadShareRewards()
    {
        var shareConfig = ShareModel.Instance.GetShareInfo(11201);
        if (shareConfig != null && shareConfig.Fx_success1s != null)
        {
            shareRewardData = new List<StorageItemVO>();
            foreach (var reward in shareConfig.Fx_success1s)
            {
                var item = new StorageItemVO();
                var itemConfig = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
                if (itemConfig != null)
                {
                    item.itemDefId = itemConfig.ItemDefId;
                    item.count = reward.Value;
                    item.item = itemConfig;
                    shareRewardData.Add(item);
                }
            }
            view.list2.numItems = shareRewardData.Count;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        MyselfModel.Instance.isShowUpLevel = false;
        // 其他关闭面板的逻辑
        //UILogicUtils.ShowGetReward(listData, () =>
        //{
            //DropManager.ShowDrop(listData,false);
            //if (levelData != null)
            //{
            //    if (levelData.UnlockResources == null || levelData.UnlockResources.Length <= 0)
            //    {
            //        return;
            //    }
            //    var itemData = ItemModel.Instance.GetItemByEntityID(levelData.UnlockResources[0]);
            //    Action callFun = () =>
            //    {
            //    };
            //    if (itemData == null)
            //    {
            //        return;
            //    }
            //    var param = new object[] { itemData, callFun };
            //    UIManager.Instance.OpenWindow<NewlyGotFlowerShowWindow>(UIName.NewlyGotFlowerShowWindow, param);
            //}
        //}, "", true, true);
    }
}

