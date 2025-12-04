//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class ArenaRewardPreWindow : BaseWindow
//{
//   private fun_Arena.arena_reward_pre_view view;

//   public ArenaRewardPreWindow()
//    {
//        packageName = "fun_Arena";
//        // 设置委托
//        BindAllDelegate = fun_Arena.fun_ArenaBinder.BindAll;
//        CreateInstanceDelegate = fun_Arena.arena_reward_pre_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Arena.arena_reward_pre_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
//        view.rewardTipTxt.text = Lang.GetValue("flower_rank7");

//        view.list.itemRenderer = RenderPreviewItem;
//        view.list.SetVirtual();
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        view.list.numItems = ArenaModel.Instance.arenaList.Count;
//    }

//    private void RenderPreviewItem(int index,GObject item)
//    {
//        var cell = item as fun_Arena.arena_reward_pre_item;
//        var rankInfo = ArenaModel.Instance.arenaList[index];
//        if (rankInfo.Ranks.Length > 1)
//        {
//            cell.rankNum.text = rankInfo.Ranks[0] + "-" + rankInfo.Ranks[1];
//        }
//        else
//        {
//            cell.rankNum.text = rankInfo.Ranks[0].ToString();
//        }
//        cell.rewardList.itemRenderer = (int idx, GObject rewardItem) =>
//        {
//            var rewardCell = rewardItem as fun_Arena.arena_reward_item;
//            var rewardInfo = rankInfo.Rewards[idx];
//            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
//            rewardCell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//            rewardCell.txt_num.text = rewardInfo.Value.ToString();
//        };
//        cell.rewardList.numItems = rankInfo.Rewards.Length;
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

