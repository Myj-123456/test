//using ADK;
//using FairyGUI;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
///// <summary>
///// 战斗结算界面
///// </summary>
//public class SettlementWindow : BaseWindow
//{
//    private fun_Battle.SettlementWindow view;
//    private StageRewardObject[] listData;
//    private Dictionary<ulong, ulong> items;
//    public SettlementWindow()
//    {
//        packageName = "fun_Battle";
//        // 设置委托
//        BindAllDelegate = fun_Battle.fun_BattleBinder.BindAll;
//        CreateInstanceDelegate = fun_Battle.SettlementWindow.CreateInstance;
//        ClickBlankClose = true;
//    }

//    public override void OnInit()
//    {
//        base.OnInit();
//        view = ui as fun_Battle.SettlementWindow;
//        view.list_reward.itemRenderer = RenderList;
//        view.list_reward.SetVirtual();
//        AddEvent();
//    }

//    private void AddEvent()
//    {

//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        if (BattleModel.Instance.isPve)
//        {
//            view.c1.selectedIndex = BattleModel.Instance.isWin ? 0 : 1;
//            view.txt_prompt.text = BattleModel.Instance.isWin ? "您将获得以下奖励" : "您可以通过以下方式提升实力";
//        }
//        else//pvp
//        {
//            view.c1.selectedIndex = BattleModel.Instance.isWin ? 2 : 3;
//            UpdatePlayers();
//        }
//        ShowReward();
//    }

//    private void ShowReward()
//    {
//        if (BattleModel.Instance.isWin)
//        {
//            if (BattleModel.Instance.isPve)
//            {
//                var gridConfig = AdventureModel.Instance.GetGridConfig(BattleModel.Instance.islandStage);
//                var cidData = AdventureModel.Instance.GetIslandStageConfig(int.Parse(gridConfig.ClearReward));
//                listData = cidData.StageRewards;
//                view.list_reward.numItems = listData.Length;
//            }
//            else
//            {
//                items = BattleModel.Instance.items;
//                view.list_reward.numItems = items.Count;
//            }
//        }
//    }

//    private void RenderList(int index, GObject item)
//    {
//        var cell = item as fun_Battle.SettlementRewardItem;
//        if (BattleModel.Instance.isPve)
//        {
//            var reward = listData[index];
//            var itemVo = ItemModel.Instance.GetItemByEntityID(reward.EntityID);
//            cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            cell.numLab.text = TextUtil.ChangeCoinShow(reward.Value);
//            cell.txtName.text = Lang.GetValue(itemVo.Name);
//        }
//        else
//        {
//            // 将字典的值转换为列表
//            var rewardsList = items.Keys.ToList();
//            var rewardKey = rewardsList[index];
//            var itemDefId = IDUtil.GetEntityValue(rewardKey.ToString());
//            var itemVo = ItemModel.Instance.GetItemById(itemDefId);
//            cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            cell.numLab.text = TextUtil.ChangeCoinShow(items[rewardKey]);
//            cell.txtName.text = Lang.GetValue(itemVo.Name);
//        }

//    }

//    private void UpdatePlayers()
//    {
//        UpdatePlayer(view.player_me, true);
//        UpdatePlayer(view.player_other, false);
//    }

//    private void UpdatePlayer(fun_Battle.SettlementPlayerItem settlementPlayerItem, bool isMySelf)
//    {
//        if (isMySelf)
//        {
//            var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME);
//            settlementPlayerItem.txt_name.text = name != null ? name.info : "";
//            var nowScore = ArenaModel.Instance.myRank.score;
//            var score = BattleModel.Instance.score;
//            var newScore = nowScore + score;
//            var dt = Mathf.Abs(score);
//            if (BattleModel.Instance.isWin)//我方赢了
//            {
//                settlementPlayerItem.txt_score.text = newScore + $"(+{dt})";
//            }
//            else
//            {
//                settlementPlayerItem.txt_score.text = newScore + $"(-{dt})";
//            }
//        }
//        else
//        {
//            var info = ArenaModel.Instance.rivalUserInfos[(int)BattleModel.Instance.rivalIndex];
//            if (info != null)
//            {
//                settlementPlayerItem.txt_name.text = info.userInfo.townName;
//                var nowScore = info.score;
//                var score = BattleModel.Instance.score;
//                var dt = Mathf.Abs(score);
//                if (BattleModel.Instance.isWin)// 对方输了
//                {
//                    var newScore = nowScore - score;
//                    settlementPlayerItem.txt_score.text = newScore + $"(-{dt})";
//                }
//                else//对方赢了
//                {
//                    var newScore = nowScore + score;
//                    settlementPlayerItem.txt_score.text = newScore + $"(+{dt})";
//                }
//            }
//        }
//    }


//    public override void OnHide()
//    {
//        base.OnHide();
//        BattleController.Instance.CloseBattle();
//    }
//}
