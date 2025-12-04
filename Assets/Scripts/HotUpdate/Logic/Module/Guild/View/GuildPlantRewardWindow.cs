
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuildPlantRewardWindow : BaseWindow
{
   private fun_Guild_plant.reward_show_view view;

    private List<StorageItemVO> preData;
    private List<StorageItemVO> extraData;

    public GuildPlantRewardWindow()
    {
        packageName = "fun_Guild_plant";
        // 设置委托
        BindAllDelegate = fun_Guild_plant.fun_Guild_plantBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_plant.reward_show_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_plant.reward_show_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        
        view.preLab.text = Lang.GetValue("guild_plant_7");
        view.extraLab.text = Lang.GetValue("guild_plant_8");

        view.pre_list.itemRenderer = RenderPreList;

        view.extra_list.itemRenderer = RenderExtraList;
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        preData = ItemModel.Instance.GetDropData(GuildPlantModel.Instance.plantInfo.flowerItems);
        extraData = ItemModel.Instance.GetDropData(GuildPlantModel.Instance.plantInfo.extraReward);
        view.pre_list.numItems = preData.Count;
        view.extra_list.numItems = extraData.Count;
        if(preData.Count == 0 && extraData.Count == 0)
        {
            view.empty.selectedIndex = 1;
        }
        else
        {
            if (extraData.Count == 0)
            {
                view.empty.selectedIndex = 2;
            }
            else
            {
                view.empty.selectedIndex = 0;
            }
            
        }
    }

    private void RenderPreList(int index,GObject item)
    {
        var rewardCell = item as fun_Guild_plant.reward_item;
        var rewardVo = preData[index];
        var itemInfo = ItemModel.Instance.GetItemById(rewardVo.itemDefId);
        rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo);
        rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardVo.count);
    }

    private void RenderExtraList(int index, GObject item)
    {
        var rewardCell = item as fun_Guild_plant.reward_item;
        var rewardVo = extraData[index];
        var itemInfo = ItemModel.Instance.GetItemById(rewardVo.itemDefId);
        rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo);
        rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardVo.count);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

