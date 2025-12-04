
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;
using static protobuf.guild.S_MSG_GUILD_HOUSE_INFO;

public class GuildPlantView : BaseView
{
   private fun_Guild_plant.guild_plant_view view;
    private List<I_HOUSE_VO> listData;

    private Dictionary<int, CountDownTimer> timerMap;

    public GuildPlantView()
    {
        packageName = "fun_Guild_plant";
        // 设置委托
        BindAllDelegate = fun_Guild_plant.fun_Guild_plantBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_plant.guild_plant_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_plant.guild_plant_view;
        SetBg(view.bg, "Recharge/ELIDA_chongzhi_bg01.png");
       

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        timerMap = new Dictionary<int, CountDownTimer>();
        view.numLab.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);

        AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateProfile);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseInfo, UpdateList);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseHarvest, UpdateList);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseEnable, UpdateList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        GuildPlantController.Instance.ReqGuildHouseInfo();
    }

    private void UpdateProfile(uint itemId)
    {
        if (itemId == (uint)BaseType.CASH)
        {
            view.numLab.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
        }
    }

    public void UpdateList()
    {
        listData = GuildPlantModel.Instance.houseList;
        view.list.numItems = listData.Count;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_plant.guild_plant_item;
        cell.status.selectedIndex = index % 2;
        var ui = cell.item;
        var plantData = listData[index];
        var plantInfo = GuildPlantModel.Instance.GetGuildPlantConfig((int)plantData.id);
        ui.indexLab.text = plantInfo.Id.ToString();
        ui.nameLab.text = Lang.GetValue(plantInfo.Name);
        
        
        if(plantData.unlockStatus == 1)
        {
            ui.status.selectedIndex = 0;
            ui.limitLab.text = Lang.GetValue("guild_plant_3", plantInfo.UnlockClubLv.ToString());
        }
        else
        {
            if (plantData.isPrevPeroid && plantData.haveReward)
            {
                ui.status.selectedIndex = 3;
                StringUtil.SetBtnTab(ui.btn, Lang.GetValue("common_claim_button"));
            }
            else if(plantData.unlockStatus == 3)
            {
                ui.status.selectedIndex = 2;
                StringUtil.SetBtnTab(ui.btn, Lang.GetValue("guild_plant_2"));
                var rewardList = ItemModel.Instance.GetDropData(plantData.extraReward);
                ui.reward_list.itemRenderer = (int index, GObject reward) =>
                {
                    var rewardCell = reward as fun_Guild_plant.reward_item;
                    var rewardVo = rewardList[index];
                    var itemInfo = ItemModel.Instance.GetItemById(rewardVo.itemDefId);
                    rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo);
                    rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardVo.count);
                };
                ui.reward_list.numItems = rewardList.Count;
                ui.extraGrp.visible = rewardList.Count > 0;
                CountDownTimer timeDown;
                if (timerMap.ContainsKey(cell.GetHashCode()))
                {
                    timeDown = timerMap[cell.GetHashCode()];
                    timeDown.Clear();
                    timeDown = null;
                    timerMap.Remove(cell.GetHashCode());
                }
                int endTime = (int)plantData.endTime - (int)ServerTime.Time;
                if(endTime > 0)
                {
                    timeDown = new CountDownTimer(ui.timeLab, endTime, true, 2);
                    timerMap.Add(cell.GetHashCode(), timeDown);
                    timeDown.CompleteCallBacker = () =>
                    {
                        timeDown.Clear();
                        timeDown = null;
                        timerMap.Remove(cell.GetHashCode());
                        UpdateList();
                    };
                }
            }
            else if(plantData.unlockStatus == 2)
            {
                ui.status.selectedIndex = 1;
                StringUtil.SetBtnTab(ui.btn, Lang.GetValue("guild_plant_1"));

            }
        }
        
        
        ui.btn.data = plantData;
        ui.btn.onClick.Add(ClickBtn);
    }

    private void ClickBtn(EventContext context)
    {
        var plantData = (context.sender as GComponent).data as I_HOUSE_VO;
        if (plantData.unlockStatus == 1)
        {
          
        }
        else
        {
            if (plantData.isPrevPeroid && plantData.haveReward)
            {
                GuildPlantController.Instance.ReqGuildHouseHarvest(plantData.id);
            }
            else if (plantData.unlockStatus == 3)
            {
                UIManager.Instance.OpenPanel<GuildPlantingView>(UIName.GuildPlantingView, UILayer.UI, (int)plantData.id);
            }
            else if (plantData.unlockStatus == 2)
            {
                UIManager.Instance.OpenWindow<BuyFlowerRackWindow>(UIName.BuyFlowerRackWindow, (int)plantData.id);
            }
        }
        
        
         
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

