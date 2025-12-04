
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class MatchMyTaskWindow : BaseWindow
{
   private fun_Guild_Match.my_task_view view;

   public MatchMyTaskWindow()
    {
        packageName = "fun_Guild_Match";
        // 设置委托
        BindAllDelegate = fun_Guild_Match.fun_Guild_MatchBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Match.my_task_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Match.my_task_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        EventManager.Instance.AddEventListener(GuildMatchEvent.GuildSelfReward, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateList();
    }

    public void UpdateList()
    {
        view.list.numItems = GuildMatchModel.Instance.matchQuestMapList.Count;
    }

    public void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_Match.my_tsak_item;
        var itemData = GuildMatchModel.Instance.matchQuestMapList[index];
        var curScore = GuildMatchModel.Instance.score < itemData.Score ? (int)GuildMatchModel.Instance.score : itemData.Score;
        cell.score_txt.text = Lang.GetValue("guild_Match_1", itemData.Score.ToString());
        cell.scoreLab.text = "(" + curScore + "/" + itemData.Score + ")";
        
        if(GuildMatchModel.Instance.score < itemData.Score)
        {
            cell.status.selectedIndex = 1;
            StringUtil.SetBtnTab(cell.showBtn, Lang.GetValue("guild_Match_2"));
        }
        else
        {
            cell.status.selectedIndex = 0;
            if (GuildMatchModel.Instance.selfRewardIds.IndexOf((uint)itemData.Id) == -1)
            {
                cell.getBtn.enabled = true;
                StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("common_claim_button"));
            }
            else
            {
                cell.getBtn.enabled = false;
                StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("text_activity_3"));
            }
            
        }

        cell.rewardList.itemRenderer = ((int index, GObject item) =>
        {
            var rewardCell = item as fun_Guild_Match.reward_item;
            var rewardInfo = itemData.Rewards[index];
            var itemVo = ItemModel.Instance.GetItemByEntityID(rewardInfo.EntityID);
            rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            rewardCell.numLab.text = rewardInfo.Value.ToString();
        });
        cell.rewardList.numItems = itemData.Rewards.Length;
        cell.getBtn.data = itemData.Id;
        cell.getBtn.onClick.Add(GetMyTaskReward);
    }

    private void GetMyTaskReward(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        GuildMatchController.Instance.ReqGuildSelfReward((uint)id);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

