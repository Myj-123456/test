
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ADK;
using System;
using Spine;
using Elida.Config;
using static protobuf.guild.S_MSG_GUILD_HOUSE_INFO;

public class GuildPlantingView : BaseView
{
    private fun_Guild_plant.guild_planting _view;

    private int curPage = 0;
    private int totalPage = 0;

    private CountDownTimer timer;

    private Ft_club_plantConfig plantInfo;

    private I_HOUSE_VO plantData;

    private int curPos;

    private GuildPlantingOperateWindow selectFlowerView;

    private List<fun_Guild_plant.guild_flowerpot_item> list;

    public GuildPlantingView()
    {
        packageName = "fun_Guild_plant";
        // 设置委托
        BindAllDelegate = fun_Guild_plant.fun_Guild_plantBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_plant.guild_planting.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Guild_plant.guild_planting;
        selectFlowerView = new GuildPlantingOperateWindow(_view.chose_flower);
        SetBg(_view.bg, "Guild/ELIDA_huameng_peiyuhuapendi06.png");
        SetBg(_view.bg1, "Guild/ELIDA_huameng_peiyuhuapendi02.png");
        _view.moneyIcon.url = ImageDataModel.Instance.GuildMoneyIconUrl();
        _view.txt_time.text = Lang.GetValue("lshop_ui_label_duration");
        _view.txt_jia.text = Lang.GetValue("guild_plant_4");
        StringUtil.SetBtnTab(_view.getBtn, Lang.GetValue("slang_75"));
        StringUtil.SetBtnTab(_view.plantBtn, Lang.GetValue("guide_button2"));

        _view.list.height = _view.myInfo.y - _view.bg1.y - 428;

        _view.list.itemRenderer = RenderList;
        _view.list.SetVirtual();
        list = new List<fun_Guild_plant.guild_flowerpot_item> { _view.item0, _view.item1, _view.item2, _view.item3, _view.item4, _view.item5 };

       
        //_view.moneyIcon.url = ImageDataModel.Instance.GetIconUrlByEntityId(GlobalModel.Instance.module_profileConfig.guildFlowerpotConsumables.Keys.ToList()[0]);

        _view.getBtn.onClick.Add(GetReward);
        _view.plantBtn.onClick.Add(PlantFlower);
        _view.back_btn.onClick.Add(() =>
        {
            _view.chose.selectedIndex = 0;
            curPos = 0;
        });
        _view.leftBtn.onClick.Add(() =>
        {
            if(curPage > 0)
            {
                curPage--;
                UpdatePlant();
            }
        });

        _view.rightBtn.onClick.Add(() =>
        {
            if(curPage < totalPage)
            {
                curPage++;
                UpdatePlant();
            }
        });

        _view.btn_pre.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildPlantRewardWindow>(UIName.GuildPlantRewardWindow);
        });

        _view.helpBtn.onClick.Add(() =>
        {
            string[] str = new string[] { Lang.GetValue("train_help"), Lang.GetValue("guild_planting_026") };
            UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, str);
        });

        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseDetail, UpdateHouseDetail);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHousePlant, UpdatePlant);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseMembers, UpdateMembwersList);
        EventManager.Instance.AddEventListener(GuildPlantEvent.GuildHouseHarvest, UpdateHouseDetail);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        GuildPlantModel.Instance.ClearMembers();
        GuildPlantController.Instance.ReqGuildHouseDetail((uint)id);
        GuildPlantController.Instance.ReqGuildHouseMembers((uint)id,0);
        _view.title_img.url = "Guild/plant_title_" + id + ".png";
        plantInfo = GuildPlantModel.Instance.GetGuildPlantConfig(id);
        plantData = GuildPlantModel.Instance.GetHouseInfo((uint)id);
        totalPage = (int)Math.Floor((float)plantInfo.PlantNum / 6);
        curPage = 0;
        curPos = 0;
        _view.chose.selectedIndex = 0;
        _view.leftBtn.visible = _view.rightBtn.visible = plantInfo.PlantNum > 6;
        UpdateGuildMoney();
    }

    private void UpdateMembwersList()
    {
        _view.list.numItems = GuildPlantModel.Instance.memberPlantList.Count;
    }

    private void UpdateHouseDetail()
    {
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
        int endTime = (int)GuildPlantModel.Instance.plantInfo.endTime - (int)ServerTime.Time;
        timer = new CountDownTimer(_view.timeLab, endTime, true, 2);
        timer.CompleteCallBacker = () =>
        {
            timer.Clear();
            timer = null;
            Close();
        };
        UpdateMyInfo();
        UpdatePlant();
    }

    private void UpdateMyInfo()
    {
        _view.myInfo.nameLab.text = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
        _view.myInfo.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
        //UILogicUtils.ChangeOthersFrameDisplay(userInfo.flowerLevel, userInfo.flowerLevelExpireTime, (_view.myInfo.head.picFrame as common_New.PictureFrame), userInfo.headFrame);
        _view.myInfo.head.txt_lv.text = MyselfModel.Instance.level.ToString();
        _view.myInfo.txt_position.txt_position.text = GuildModel.Instance.GetPositionName(GuildModel.Instance.guildMember.powerId);
        _view.myInfo.txt_position.type.selectedIndex = GuildModel.Instance.guildMember.powerId < 3 ? (int)GuildModel.Instance.guildMember.powerId - 1 : 2;
        var rewardList = ItemModel.Instance.GetDropData(MergedDict(GuildPlantModel.Instance.plantInfo.flowerItems, GuildPlantModel.Instance.plantInfo.extraReward));
        _view.myInfo.reward_list.itemRenderer = (int index, GObject reward) =>
        {
            var rewardCell = reward as fun_Guild_plant.reward_item;
            var rewardVo = rewardList[index];
            var itemInfo = ItemModel.Instance.GetItemById(rewardVo.itemDefId);
            rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo);
            rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardVo.count);
        };
        _view.myInfo.reward_list.numItems = rewardList.Count;
    }

    public void UpdateGuildMoney()
    {
        _view.numLab.text = TextUtil.ChangeCoinShow(GuildModel.Instance.guild.gold);
    }

    private void UpdatePlant()
    {

        var min = plantInfo.PlantNum - curPage * 6;
        for (var i = 0; i < 6; i++)
        {
            if (i < min)
            {
                list[i].visible = true;
                ItemRender(i, list[i]);
            }
            else
            {
                list[i].visible = false;
            }
        }
        _view.jiaLab.text =  GuildPlantModel.Instance.plantInfo.plantList.Count + "/" + plantInfo.PlantNum;
        LeftAndRightStatus();
    }

    private void LeftAndRightStatus()
    {
        if(curPage == 0)
        {
            _view.leftBtn.enabled = false;
        }
        else
        {
            _view.leftBtn.enabled = true;
        }

        if(curPage >= totalPage)
        {
            _view.rightBtn.enabled = false;
        }
        else
        {
            _view.rightBtn.enabled = true;
        }
    }

    private void ItemRender(int index, fun_Guild_plant.guild_flowerpot_item item)
    {
        var pos = curPage * 6 + index + 1;
        var plantingData = GuildPlantModel.Instance.GetPalntingInfo((uint)pos);
        if(plantingData != null && plantingData.flowerId != 0)
        {
            item.status.selectedIndex = 1;
            item.img.url = ImageDataModel.Instance.GetFlowerStatusUrl((int)plantingData.flowerId, 2);
        }
        else
        {
            item.status.selectedIndex = 0;
        }
        item.data = pos;
        item.onClick.Add(ChoseFlowerClick);
    }

    private void ChoseFlowerClick(EventContext context)
    {
        var pos = (int)(context.sender as GComponent).data;
        _view.chose.selectedIndex = 1;
        curPos = pos;
        selectFlowerView.OnShown(pos);

    }

    private void RenderList(int index, GObject item)
    {
        var cell = item as fun_Guild_plant.guild_planting_item;
        var memberPlantData = GuildPlantModel.Instance.memberPlantList[index];
        var userInfo = memberPlantData.userInfo;
        cell.head.imgLoader.url = "Avatar/ELIDA_common_touxiangdi01.png";
       
        cell.head.txt_lv.text = userInfo.userLevel.ToString();
        cell.nameLab.text = userInfo.townName;
        cell.txt_position.txt_position.text = GuildModel.Instance.GetPositionName(memberPlantData.powerId);
        cell.txt_position.type.selectedIndex = memberPlantData.powerId < 3 ? (int)memberPlantData.powerId - 1 : 2;

        GuildPlantModel.Instance.GetMembersListNext(index);
        var rewardList = ItemModel.Instance.GetDropData(memberPlantData.reward);
        cell.reward_list.itemRenderer = (int index, GObject reward) =>
        {
            var rewardCell = reward as fun_Guild_plant.reward_item;
            var rewardVo = rewardList[index];
            var itemInfo = ItemModel.Instance.GetItemById(rewardVo.itemDefId);
            rewardCell.icon.url = ImageDataModel.Instance.GetIconUrl(itemInfo);
            rewardCell.numLab.text = TextUtil.ChangeCoinShow(rewardVo.count);
        };
        cell.reward_list.numItems = rewardList.Count;
    }

    private void GetReward()
    {
        UILogicUtils.ShowConfirm(Lang.GetValue("guild_plant_9"),() =>
        {
            GuildPlantController.Instance.ReqGuildHouseHarvest(plantData.id);
        });
    }


    private void PlantFlower()
    {
        var plantingData = GuildPlantModel.Instance.GetPalntingInfo((uint)curPos);
        if (selectFlowerView.flowerId != 0)
        {
            if (plantingData == null || (plantingData != null && plantingData.flowerId != selectFlowerView.flowerId))
            {
                GuildPlantController.Instance.ReqGuildHousePlant(plantData.id, (uint)selectFlowerView.flowerId, (uint)curPos);
            }
        }
        _view.chose.selectedIndex = 0;
        curPos = 0;
    }

    private Dictionary<ulong, ulong> MergedDict(Dictionary<ulong, ulong> dict1, Dictionary<ulong, ulong> dict2)
    {
        Dictionary<ulong, ulong> mergedDict = new(dict1); // 先复制 dict1

        foreach (var kvp in dict2)
        {
            if (mergedDict.ContainsKey(kvp.Key))
            {
                mergedDict[kvp.Key] += kvp.Value;
            }
            else
            {
                mergedDict.Add(kvp.Key, kvp.Value);
            }
        }
        return mergedDict;
    }



    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

