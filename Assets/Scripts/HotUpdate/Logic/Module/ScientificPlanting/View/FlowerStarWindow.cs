
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using protobuf.flowerstar;
using ADK;

public class FlowerStarWindow : BaseWindow
{
   private fun_ResearchPlanting.FlowerStarView view;
    private SeedCropVO curSeed;
    private int curSelectPropertyIndex;

    private Dictionary<int, int> needItem;
   public FlowerStarWindow()
    {
        packageName = "fun_ResearchPlanting";
        // 设置委托
        BindAllDelegate = fun_ResearchPlanting.fun_ResearchPlantingBinder.BindAll;
        CreateInstanceDelegate = fun_ResearchPlanting.FlowerStarView.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_ResearchPlanting.FlowerStarView;
        //view.ls_property.itemRenderer = PropertyItemRenderer;
        //curSelectPropertyIndex = -1;
        //view.btn_addFlower.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<FlowerSelectWindow>(UIName.FlowerSelectWindow);
        //});
        //view.btn_change.onClick.Add(() =>
        //{
        //    UIManager.Instance.OpenWindow<FlowerSelectWindow>(UIName.FlowerSelectWindow);
        //});
        //view.btn_cancel.onClick.Add(() =>
        //{
        //    if(view.upgradeStatus.selectedIndex == 1)
        //    {
        //        curSelectPropertyIndex = -1;
        //        UpdateStarStatus(0);
        //    }else if(view.upgradeStatus.selectedIndex == 2)
        //    {
        //        var starData = FlowerStarModel.Instance.GetFlowerStarInfo(curSeed.flowerId);
        //        var additioConfig = FlowerStarModel.Instance.flowerStarAdditioConfig[(int)starData.upgradeBuff[(uint)curSelectPropertyIndex]];
        //        var index = FlowerStarModel.Instance.GetPropertyRangeIndex(additioConfig.ID, additioConfig.AdditionKind);
        //        var maxSize = FlowerStarModel.Instance.GetProperty(additioConfig.AdditionKind).Count;
        //        if((maxSize - index)<= 2)
        //        {
        //            UILogicUtils.ShowConfirm(Lang.GetValue("StarPremise_tips3"), () =>
        //            {
        //                UpdateStarStatus(1);
        //            });
        //        }
        //        else
        //        {
        //            UpdateStarStatus(1);
        //        }
        //    }
        //});

        //view.btn_sure.onClick.Add(() =>
        //{
        //    if(view.upgradeStatus.selectedIndex == 1)
        //    {
        //        foreach(var item in needItem)
        //        {
        //            if(item.Value > StorageModel.Instance.GetItemCount(item.Key))
        //            {
        //                var itemVo = ItemModel.Instance.GetItemById(item.Key);
        //                UILogicUtils.ShowNotice(Lang.GetValue(itemVo.Name)+Lang.GetValue("StarPremise_tips1"));
        //                return;
        //            }
        //        }
        //        FlowerStarController.Instance.ReqFlowerStarUpgrstar((uint)curSeed.flowerId, (uint)curSelectPropertyIndex);
        //    }else if(view.upgradeStatus.selectedIndex == 2)
        //    {
        //        UILogicUtils.ShowConfirm(Lang.GetValue("StarPremise_tips2"), () =>
        //        {
        //            FlowerStarController.Instance.ReqFlowerStarReplace((uint)curSeed.flowerId, (uint)curSelectPropertyIndex);
        //            curSelectPropertyIndex = -1;
        //        });
        //    }
        //});

        //EventManager.Instance.AddEventListener<SeedCropVO>(FlowerStarEvent.FlowerStarSelect, SelectFlower);
        //EventManager.Instance.AddEventListener<uint>(FlowerStarEvent.FlowerStarUnlock, UpdateUnlock);
        //EventManager.Instance.AddEventListener<uint>(FlowerStarEvent.FlowerStarUpgrstar, UpdateUpgrstar);
        //EventManager.Instance.AddEventListener<uint>(FlowerStarEvent.FlowerStarReplace, UpdateReplace);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateView();
    }

    private void UpdateView()
    {
        //if (curSeed == null)
        //{
        //    view.selectStatus.selectedIndex = 0;
        //    view.upgradeStatus.selectedIndex = 0;
        //}
        //else
        //{
        //    view.img_flower.url = "";
        //    view.selectStatus.selectedIndex = 1;
        //    view.img_flower.url = ImageDataModel.Instance.GetIconUrl(curSeed.item);
        //}
        //view.ls_property.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
        //view.lb_tip_2.text = Lang.GetValue("StarPremise_des1");
    }

    //private void UpdateUnlock(uint pos)
    //{
    //    view.ls_property.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
    //}

    //private void UpdateUpgrstar(uint pos)
    //{
    //    UpdateStarStatus(2);
    //}

    //private void UpdateReplace(uint pos)
    //{
    //    UpdateStarStatus(0);
    //    view.ls_property.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
    //}

    //private void SelectFlower(SeedCropVO crop)
    //{
    //    curSeed = crop;
    //    UpdateView();
    //}

    //private void UpdateFlowers()
    //{

    //}

    //public void UpdateStarStatus(int status)
    //{
    //    var starData = FlowerStarModel.Instance.GetFlowerStarInfo(curSeed.flowerId);
    //    view.upgradeStatus.selectedIndex = status;
    //    if(status == 1)
    //    {
    //        var costConfig = FlowerStarModel.Instance.flowerStarRefreshConfig[curSelectPropertyIndex + 1];
    //        var staticSeedCondition = FlowerHandbookModel.Instance.staticSeedCondition[curSeed.flowerId];
    //        var needItem = staticSeedCondition.ItemIds[curSelectPropertyIndex];
    //        var hasCount = StorageModel.Instance.GetItemCount(needItem.EntityID);
    //        var needCount = Mathf.Ceil((float)needItem.Value * (float)costConfig.PropPercent / 100f);
    //        view.awardItem_0.img_icon.url = ImageDataModel.Instance.GetIconUrlByEntityId(needItem.EntityID);
    //        view.awardItem_0.lb_count.text = "x" + needCount;
    //        view.awardItem_0.lb_count.color = hasCount < needCount ? StringUtil.HexToColor("#ff0000") : StringUtil.HexToColor("#ffffff");

    //        var staticCrop = PlantModel.Instance.GetPlantCropConfigData(curSeed.flowerId);
    //        var cost = staticCrop.Coins[costConfig.FlowerLevel];
    //        var neeNum = Mathf.Ceil((float)cost * (float)costConfig.ConsumePercent / 100f);
    //        var hasNum = (costConfig.CurrencyType == 1 ? MyselfModel.Instance.gold : MyselfModel.Instance.diamond);
    //        view.awardItem_1.img_icon.url = (costConfig.CurrencyType == 1 ? ImageDataModel.GOLD_ICON_URL : ImageDataModel.CASH_ICON_URL);
    //        view.awardItem_1.lb_count.text = "x" + TextUtil.ChangeCoinShow(neeNum);
    //        view.awardItem_1.lb_count.color = hasNum < neeNum ? StringUtil.HexToColor("#ff0000") : StringUtil.HexToColor("#ffffff");

    //        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("StarPremise_button4"));

    //        if(this.needItem == null)
    //        {
    //            this.needItem = new Dictionary<int, int>();
    //        }
    //        this.needItem.Clear();
    //        this.needItem.Add(IDUtil.GetEntityValue(needItem.EntityID), (int)needCount);
    //        this.needItem.Add(costConfig.CurrencyType == 1?(int)BaseType.GOLD:(int)BaseType.CASH, needItem.Value);

    //        StringUtil.SetBtnTab(view.btn_cancel, Lang.GetValue("mail_button_return"));
    //    }
    //    else if(status == 2)
    //    {
    //        view.lb_tip_3.text = GetPropertyString((int)starData.upgradeBuff[(uint)curSelectPropertyIndex], true);
    //        StringUtil.SetBtnTab(view.btn_sure, Lang.GetValue("StarPremise_button5"));//"替换";
    //        StringUtil.SetBtnTab(view.btn_cancel, Lang.GetValue("StarPremise_button6"));//"取消";
    //    }
    //    view.ls_property.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
    //}

    //private void PropertyItemRenderer(int index, GObject item)
    //{
    //    var cell = item as fun_ResearchPlanting.FlowerStarItem;
    //    var curLv = GlobalModel.Instance.module_profileConfig.flowerStarPremise[index];
    //    StringUtil.SetBtnTab(cell.btn_start, Lang.GetValue("StarPremise_button2"));
    //    if (curSeed != null && curSeed.level >= curLv)
    //    {
    //        var starData = FlowerStarModel.Instance.GetFlowerStarInfo(curSeed.flowerId);
    //        if (curSelectPropertyIndex != -1)
    //        {
    //            cell.change.selectedIndex = 1;
    //        }
    //        else
    //        {
    //            cell.change.selectedIndex = 0;
    //        }
    //        if (starData != null && starData.buff[(uint)index] != 0)
    //        {
    //            cell.status.selectedIndex = 0;
    //            cell.activateStatus.selectedIndex = 0;
    //            StringUtil.SetBtnTab(cell.btn_start, Lang.GetValue("StarPremise_button"));//更换
    //            cell.lb_info.text = GetPropertyString((int)starData.buff[(uint)index]);
    //        }
    //        else
    //        {
    //            cell.activateStatus.selectedIndex = 1;
    //            cell.status.selectedIndex = 1;
    //            cell.lb_info_1.text = Lang.GetValue("StarPremise_txt1");
    //            cell.img_icon.url = ImageDataModel.CASH_ICON_URL;
    //            var price = GlobalModel.Instance.module_profileConfig.flowerStarGetPrice[index];
    //            cell.lb_num.text = "x" + price;
    //        }
    //    }
    //    else
    //    {
            
    //        cell.lb_info.text = Lang.GetValue("StarPremise_txt2", curLv.ToString());
    //        cell.status.selectedIndex = 2;
    //        cell.change.selectedIndex = 1;
    //        cell.activateStatus.selectedIndex = 0;
    //    }
    //    cell.btn_start.data = index;
    //    cell.btn_start.onClick.Add(PropertyClickHander);
    //}

    //private void PropertyClickHander(EventContext context)
    //{
    //    var starData = FlowerStarModel.Instance.GetFlowerStarInfo(curSeed.flowerId);
    //    var index = (int)(context.sender as GComponent).data;
    //    if(starData == null || starData.buff[(uint)index] == 0)
    //    {
    //        var price = GlobalModel.Instance.module_profileConfig.flowerStarGetPrice[index];
    //        if(MyselfModel.Instance.diamond < price)
    //        {
    //            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
    //            return;
    //        }
    //        UILogicUtils.ShowConfirm(Lang.GetValue("text_grandma12", price.ToString()), () => {
    //            FlowerStarController.Instance.ReqFlowerStarUnlock((uint)curSeed.flowerId, (uint)index);
    //        });
    //    }
    //    else
    //    {
    //        curSelectPropertyIndex = index;
    //        UpdateStarStatus(1);
    //        view.ls_property.numItems = GlobalModel.Instance.module_profileConfig.flowerStarPremise.Count;
    //    }
    //}

    //private string GetPropertyString(int propertyId,bool range = false)
    //{
    //    var additioConfig = FlowerStarModel.Instance.flowerStarAdditioConfig[propertyId];
    //    var rangeindex = FlowerStarModel.Instance.GetPropertyRangeIndex(additioConfig.ID, additioConfig.AdditionKind);
    //    string pData;
    //    List<int> rangeData = null;
    //    if (range)
    //    {
    //        rangeData = FlowerStarModel.Instance.GetPropertyRange(additioConfig.AdditionKind);
    //    }
    //    if(additioConfig.NumKind == 1)
    //    {
    //        pData = "<font color=" + GlobalModel.Instance.module_profileConfig.percentColor[rangeindex] + ">" + additioConfig.AdditionPercent + "%</font>";
    //        if (range)
    //        {
    //            pData += "(" + rangeData[0] + "%～" + rangeData[1] + "%)";
    //        }
    //    }
    //    else
    //    {
    //        pData = "<font color=" + GlobalModel.Instance.module_profileConfig.numberColor[rangeindex] + ">" + additioConfig.AdditionNum + "%</font>";
    //        if (range)
    //        {
    //            pData += "(" + rangeData[0] + "～" + rangeData[1] + ")";
    //        }
    //    }
    //    return Lang.GetValue("StarPremise_addition" + additioConfig.AdditionKind, pData);

    //}


    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

