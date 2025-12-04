using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Elida.Config;

public class FlowerGoldInfoWindow : BaseView
{
   private fun_FlowerGold.flower_gold_info_view view;
    private int curIndex;
    private FairyDataConfig curInfo;
    private List<Ft_fairy_levelConfig> lvListData;
   public FlowerGoldInfoWindow()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.flower_gold_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.flower_gold_info_view;
        SetBg(view.bg, "FlowerGold/ELIDA_huaxian_tcxiangqing_hxbg01.jpg");
        SetBg(view.bg1, "FlowerGold/ELIDA_huaxian_tcxiangqing_hxbg02.png");
        view.titileLab.text = Lang.GetValue("into_battle_3") + Lang.GetValue("details_title");
        view.skill_title.text = Lang.GetValue("fairy_9");
        view.nature_title.text = Lang.GetValue("fairy_10");
        view.level_nature.text = Lang.GetValue("fairy_6");
        view.haveLab.text = Lang.GetValue("fairy_7");
        view.love_add.text = Lang.GetValue("fairy_4");
        view.love_flower.text = Lang.GetValue("fairy_5");
        StringUtil.SetBtnTab(view.levelUp_btn, Lang.GetValue("text_book13"));
        StringUtil.SetBtnTab(view.level_btn, Lang.GetValue("text_book13"));
        StringUtil.SetBtnTab(view.info_btn, Lang.GetValue("setting_txt9"));
        StringUtil.SetBtnTab(view.love_btn, Lang.GetValue("fairy_8"));

        view.level_list.itemRenderer = RenderLevelList;
        view.level_list.SetVirtual();

        view.love_list.itemRenderer = RenderLoveList;
        view.love_list.SetVirtual();

        view.levelUp_btn.onClick.Add(() =>
        {
            FlowerGoldController.Instance.ReqFairyUpgrade((uint)curInfo.Id);
        });
        view.detail_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FairySkillWindow>(UIName.FairySkillWindow,curInfo.Id);
        });
        view.left_btn.onClick.Add(() =>
        {
            curIndex--;
            ChangeFairy();
        });
        view.right_btn.onClick.Add(() =>
        {
            curIndex++;
            ChangeFairy();
        });
        view.into_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FairyIntoWindow>(UIName.FairyIntoWindow, curInfo.Id);
        });
        AddEventListener(FlowerGoldEvent.FairyUpgrade, UpdateData);
        AddEventListener(FlowerGoldEvent.BattleFairy, UpdateStatus);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        curIndex = (int)data;
        ChangeFairy();
    }

    private void ChangeFairy()
    {
        curInfo = FlowerGoldModel.Instance.fairyHome[curIndex];
        UpdateStatus();
        view.left_btn.enabled = curIndex > 0;
        view.right_btn.enabled = curIndex < FlowerGoldModel.Instance.fairyHome.Count - 1;
    }

    private void RenderLevelList(int index,GObject item)
    {
        var cell = item as fun_FlowerGold.level_list_item;
        var lv = (index + 1);
        var lvInfo = lvListData[index];
        cell.lvlab.text = Lang.GetValue("levelup_explain", lvInfo.Level.ToString());
        cell.skill.selectedIndex = lvInfo.IsSkillUp;
        if (lvInfo.Level == curInfo.Level + 1)
        {
            cell.nature.natureLab.color = StringUtil.HexToColor("#D96619");
            cell.status.selectedIndex = 1;
        }else if(lvInfo.Level <= curInfo.Level){
            cell.status.selectedIndex = 0;
            cell.nature.natureLab.color = StringUtil.HexToColor("#6F8F64");
        }
        else
        {
            cell.status.selectedIndex = 2;
            cell.nature.natureLab.color = StringUtil.HexToColor("#D96619");
        }
        cell.nature.natureLab.text = GeyAttrTxt(lvInfo.LevelAtts);
    }

    private string GeyAttrTxt(string attrs)
    {
        var str = "";
        var attr = attrs.Split(",");
        for (int index = 0; index < attr.Length; index++)
        {
            var attrVo = attr[index].Split("#");
            var attrType = int.Parse(attrVo[0]);
            var sttrValue = float.Parse(attrVo[1]);
            var attrInfo = PlayerModel.Instance.GetPlayerArr(attrType);
            if(attrType < 5)
            {
                str += Lang.GetValue(attrInfo.AttributeName) + "+" + sttrValue + (index == attr.Length - 1?"":",");
            }
            else
            {
                str += Lang.GetValue(attrInfo.AttributeName) + "+" + sttrValue + "%" + (index == attr.Length - 1 ? "" : ",");
            }
        }
        return str;
    }
    private void RenderLoveList(int index, GObject item)
    {
        var cell = item as fun_FlowerGold.love_list_item;
        var flowerId = curInfo.FavorFlowers[index];
        var itemVo = ItemModel.Instance.GetItemById(flowerId);
        var con = FlowerHandbookModel.Instance.GetStaticSeedCondition(flowerId);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.nameLab.text = Lang.GetValue(itemVo.Name);
        cell.bg.url = "MyInfo/show_flower_bg" + con.FlowerQuality + ".png";

    }

    private void UpdateStatus()
    {
        var itemVo = ItemModel.Instance.GetItemById(curInfo.Id);
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.rare_img.url = "HandBookNew/rare_icon_" + curInfo.Quality + ".png";
        if (curInfo.Unlock)
        {
            //view.status.selectedIndex = 1;
            if (PlayerModel.Instance.pen.battleFairys != null && Array.IndexOf(PlayerModel.Instance.pen.battleFairys, (uint)curInfo.Id) != -1)
            {
                view.into.selectedIndex = 1;
                view.intoLab.text = Lang.GetValue("pet_20");
            }
            else
            {
                view.into.selectedIndex = 0;
                view.intoLab.text = Lang.GetValue("pet_19");
            }

            
            UpdateData();
        }
        else
        {
            view.intoLab.text = Lang.GetValue("rob_21");
            view.into.selectedIndex = 1;
            //view.status.selectedIndex = 0;
            //var shardInfo = ItemModel.Instance.GetItemById(CurPetData.ShardId);
            //view.shard_img.url = ImageDataModel.Instance.GetIconUrl(shardInfo);
            //var count = StorageModel.Instance.GetItemCount(CurPetData.ShardId);
            //view.shardLab.text = Lang.GetValue(shardInfo.Name);
            //view.proBar.max = CurPetData.ComposeNum;
            //view.proBar.value = count;
            //view.proLab.text = TextUtil.ChangeCoinShow(count) + "/" + CurPetData.ConvertNum;
            //view.get_btn.enabled = CurPetData.ConvertNum <= count;
        }
    }

    private void UpdateData()
    {
        var levelData = FlowerGoldModel.Instance.GetFairyLvInfo(curInfo.Id,curInfo.Level);
        var skillInfo = BattleModel.Instance.GetSkillConfig(levelData.SkillId);
        view.lvLab.text = Lang.GetValue("levelup_explain", curInfo.Level.ToString());
        view.skillLab.text = Lang.GetValue(skillInfo.Desc);
        var attrs = FlowerGoldModel.Instance.GetFairyAttr(curInfo.Id, curInfo.Level);
        var attrList = FlowerGoldModel.Instance.GetFairyAttrList(attrs);
        view.list.itemRenderer = (int index, GObject item) =>
        {
            var cell = item as fun_FlowerGold.nature_txt;
            var attrInfo = PlayerModel.Instance.GetPlayerArr(attrList[index].type);
            if (attrInfo.ID > 4)
            {
                cell.attrLab.text = Lang.GetValue(attrInfo.AttributeName) + "：" + attrList[index].value + "%";
            }
            else
            {
                cell.attrLab.text = Lang.GetValue(attrInfo.AttributeName) + "：" + attrList[index].value;
            }
        };
        view.list.numItems = attrList.Count;
        view.styleLab.text = Lang.GetValue("fairy_11") + "+"+ levelData.FavorStyleUp + "%";
        view.orderLab.text = Lang.GetValue("gold") + "+" + levelData.FavorGoldUp + "%";

        lvListData = FlowerGoldModel.Instance.GetFairyLvList(curInfo.Id);
        view.level_list.numItems = lvListData.Count;

        view.love_list.numItems = curInfo.FavorFlowers.Length;
        if (curInfo.IsMaxLeve)
        {
            view.max.selectedIndex = 1;
        }
        else
        {
            view.max.selectedIndex = 0;
            var nextLvData = FlowerGoldModel.Instance.GetFairyLvInfo(curInfo.Id, curInfo.Level + 1);
            view.needItem.bg.url = "MyInfo/show_flower_bg" + curInfo.Quality + ".png";
            var itemVo = ItemModel.Instance.GetItemById(curInfo.Id);
            view.needItem.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            var count = StorageModel.Instance.GetItemCount(curInfo.ShardId);
            view.levelUp_btn.enabled = nextLvData.CostNum <= count;
            view.needItem.proLab.text = "";

            view.pro.max = nextLvData.CostNum;
            view.pro.value = count;
            view.proLab.text = count +"/" + nextLvData.CostNum;
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

