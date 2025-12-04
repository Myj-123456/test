using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class DressCallView : BaseView
{
   private fun_Dress.dress_call_view view;
    private int select = 0;
   public DressCallView()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.dress_call_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Dress.dress_call_view;
        SetBg(view.bg, "Pet/ELIDA_lingshou_wenquan_xiyinjieguo_BG.jpg");
        view.list.itemRenderer = RenderList;
        view.one_btn.onClick.Add(() =>
        {
            var ItemVo = ItemModel.Instance.GetItemById(DressModel.Instance.suitDrawList[select].Id);
            var count = StorageModel.Instance.GetItemCount(DressModel.Instance.suitDrawList[select].Id);
            if(count <= 0)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_90", Lang.GetValue(ItemVo.Name)));
                return;
            }
            DressController.Instance.ReqDressDraw((uint)DressModel.Instance.suitDrawList[select].Id, 1);
        });
        view.ten_btn.onClick.Add(() =>
        {
            var ItemVo = ItemModel.Instance.GetItemById(DressModel.Instance.suitDrawList[select].Id);
            var count = StorageModel.Instance.GetItemCount(DressModel.Instance.suitDrawList[select].Id);
            if (count < 10)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_90", Lang.GetValue(ItemVo.Name)));
                return;
            }
            DressController.Instance.ReqDressDraw((uint)DressModel.Instance.suitDrawList[select].Id, 10);
        });

        view.get_btn.onClick.Add(() =>
        {
            DressController.Instance.ReqDressScoreReward();
        });
        EventManager.Instance.AddEventListener(DressEvent.DressDraw, UpdateData);
        EventManager.Instance.AddEventListener(DressEvent.DressScoreReward, UpdateData);
    }

   

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        
        UpdateData();
        view.list.selectedIndex = select;
    }

    private void UpdateData()
    {
        var rewardInfo = DressModel.Instance.GetSuitRewardInfo((int)DressModel.Instance.rewardId);
        view.pro.max = int.Parse(rewardInfo.ScoreNum);
        view.pro.value = (int)DressModel.Instance.score;
        view.proLab.text = DressModel.Instance.score + "/" + rewardInfo.ScoreNum;
        view.list.numItems = DressModel.Instance.suitDrawList.Count;
        view.get_btn.enabled = DressModel.Instance.score >= uint.Parse(rewardInfo.ScoreNum);
    }
    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Dress.draw_item;
        var ItemVo = ItemModel.Instance.GetItemById(DressModel.Instance.suitDrawList[index].Id);
        var count = StorageModel.Instance.GetItemCount(DressModel.Instance.suitDrawList[index].Id);
        cell.nameLab.text = Lang.GetValue(ItemVo.Name);
        cell.numLab.text = "x" + count;
        cell.data = index;
        cell.onClick.Add(SelectItem);
    }

    private void SelectItem(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if(select != index)
        {
            select = index;
        }
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

