
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
        PlaySpine();

        view.share_btn.onClick.Add(() =>
        {
            ShareController.Instance.ReqShareLevelReward();
        });
        EventManager.Instance.AddEventListener(ShareEvent.ShareLevelReward, UpdateShare);
    }

    private void UpdateShare()
    {
        view.share_btn.visible = false;
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
        if (inited)
        {
            PlaySpine();
        }
        view.share_btn.visible = false;
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



    }

    //private void RenderRewardListItem(int index,GObject item)
    //{
    //    var cell = item as fun_LevelUp.levelup_cell_simple;
    //    var levelData = listData[index];
    //    cell.img_loader.url = ImageDataModel.Instance.GetIconUrl(levelData.item);
    //    cell.count_txt.text = levelData.count.ToString();
    //}

    public override void OnHide()
    {
        base.OnHide();
        MyselfModel.Instance.isShowUpLevel = false;
        // 其他关闭面板的逻辑
        UILogicUtils.ShowGetReward(listData, () =>
        {
            DropManager.ShowDrop(listData);
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
        }, "", true, true);
    }
}

