using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class VaseTipView : BaseView
{
   private fun_CultivationManual_new.handbookVaseTipView view;
    private StaticFlowerPoint configData;
    private int currentVaseIndex;
    private int currTabIndex;
    private List<StaticFlower> currFlowerListData;
    private List<StaticFormula> vaseData;
    private int lastIndex;
    private int curIndex;
    public VaseTipView()
    {
        packageName = "fun_CultivationManual_new";
        // 设置委托
        BindAllDelegate = fun_CultivationManual_new.fun_CultivationManual_newBinder.BindAll;
        CreateInstanceDelegate = fun_CultivationManual_new.handbookVaseTipView.CreateInstance;
        
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivationManual_new.handbookVaseTipView;
        SetBg(view.bgImg, "HandBookNew/ELIDA_xhshengji_bg02.jpg");
        StringUtil.SetBtnTab(view.tabBtn_0, Lang.GetValue("vase_1"));
        StringUtil.SetBtnTab(view.tabBtn_1, Lang.GetValue("vase_2"));
        StringUtil.SetBtnTab(view.tabBtn_2, Lang.GetValue("vase_3"));
        StringUtil.SetBtnTab(view.make_btn, Lang.GetValue("vase_4"));
        view.makeLab.text = Lang.GetValue("vase_6");
        view.vase_com.list.itemRenderer = RenderVaseList;
        view.list.itemRenderer = RenderList;

        view.tabBtn_0.onClick.Add(() =>
        {
            if(currTabIndex != 0)
            {
                currTabIndex = 0;
                UpdateFlowerList();
            }
        });
        view.tabBtn_1.onClick.Add(() =>
        {
            if (currTabIndex != 1)
            {
                currTabIndex = 1;
                UpdateFlowerList();
            }
        });
        view.tabBtn_2.onClick.Add(() =>
        {
            if (currTabIndex != 2)
            {
                currTabIndex = 2;
                UpdateFlowerList();
            }
        });
        view.goto_btn.onClick.Add(() =>
        {
            Module_item_defConfig item = ItemModel.Instance.GetItemById(configData.VaseId);
            if (item.ActionIds.Length > 0 && item.ActionIds[0] != -1)
            {
                UILogicUtils.ShowItemGainTips(item.ItemDefId);
            }
        });
        view.btn_left.onClick.Add(() =>
        {
            currentVaseIndex--;
            UpdataVase();
        });
        view.btn_right.onClick.Add(() =>
        {
            currentVaseIndex++;
            UpdataVase();
        });
        view.make_btn.onClick.Add(() =>
        {
            var orderVo = new NpcOrderVO();
            orderVo.ratio = 1;
            OpenIkeParam openIkeParam = new OpenIkeParam() { vaseId = configData.VaseId, formulaId = vaseData[curIndex].IkebanaId, npcOrderVO = orderVo };
            UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView, UILayer.UI, openIkeParam);
        });
        EventManager.Instance.AddEventListener(IkebanaEvent.IkebanaReward, UpdateIkeList);
        EventManager.Instance.AddEventListener(IkebanaEvent.IkebanaMake, UpdateIkeList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.effect.anim.Play();
        currentVaseIndex = (int)data;
        UpdataVase();
    }

    private void UpdateLeftRightBtn()
    {
        view.btn_left.visible = currentVaseIndex > 0;
        view.btn_right.visible = currentVaseIndex < (IkeModel.Instance.bookDatHome.Count - 1);
    }
    private void UpdateIkeList()
    {
        view.vase_com.list.numItems = vaseData.Count;
    }
    private void UpdataVase()
    {
        configData = IkeModel.Instance.bookDatHome[currentVaseIndex];
        Module_item_defConfig item = ItemModel.Instance.GetItemById(configData.VaseId);
        view.ike.vase.url = ImageDataModel.Instance.GetVaseUrl(item.ItemDefId);
        view.name_txt.text = Lang.GetValue(item.Name);
        view.nameBg.url = "HandBookNew/name_bg_color_" + configData.VaseQuality + ".png";

        bool unlock = IkeModel.Instance.IsUnlockVase(configData.VaseId);
        view.unLockStatus.selectedIndex = unlock ? 0 : 1;
        var str = "来源";
        if (item.ActionIds.Length > 0 && item.ActionIds[0] != -1)
        {
            var ft_jumpConfig = GlobalModel.Instance.GetFt_jumpConfig(item.ActionIds[0]);
            if (ft_jumpConfig != null)
            {
                str = Lang.GetValue(ft_jumpConfig.JumpName);
            }
        }
        view.lockLab.text = configData.UnlockProps == 0 ? Lang.GetValue("vase_5", configData.Leve.ToString()) : str;
        vaseData = IkeModel.Instance.GetFormulaByVaseID(configData.VaseId);
        view.vase_com.list.numItems = vaseData.Count;
        view.vase_com.list.selectedIndex = 0;
        lastIndex = 0;
        curIndex = 0;
        view.pageStatus.selectedIndex = 0;
        currTabIndex = 0;
        ChangeVase();
        UpdateFlowerList();
        UpdateLeftRightBtn();
    }
    private void UpdateFlowerList()
    {
        currFlowerListData = IkeModel.Instance.GetFlowerBySlot((currTabIndex + 1), configData.VaseId);
        var idx = -1;
        for(int i = 0; i< currFlowerListData.Count; i++)
        {
            foreach(var value in vaseData[curIndex].FlowerCombinationIds)
            {
                if(currFlowerListData[i].FlowersDI == int.Parse(value.CounterCount))
                {
                    idx = i;
                    break;
                }
            }
            if(idx != -1)
            {
                break;
            }
        }
        view.list.numItems = currFlowerListData.Count;
        view.list.selectedIndex = idx;

    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_CultivationManual_new.handbook_brandNew_item2;
        var flowerData = currFlowerListData[index];
        StaticHandbook data = FlowerHandbookModel.Instance.GetBookConfigByFlowerId(flowerData.FlowersDI);
        Module_item_defConfig itemData = ItemModel.Instance.GetItemById(data.FlowerId);
        SeedCropVO exp = FlowerHandbookModel.Instance.GetCropVoByBook(data.FlowerId);
        StaticSeedCondition condition = FlowerHandbookModel.Instance.GetStaticSeedCondition(data.FlowerId);
        var plantCrop = PlantModel.Instance.GetPlantCropConfigData(condition.LevelMould + "#" + (exp == null ? 1 : exp.level));
        cell.img1.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemData);
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        object[] param = new object[] { data, itemData, exp, plantCrop, condition, index };
        cell.rect.data = param;
        if (condition.AlreadyCulitivated)
        {
            cell.status.selectedIndex = 0;
        }
        else
        {
            cell.status.selectedIndex = 1;
            cell.limitLab.text = Lang.GetValue(data.Curtips);
        }
        cell.data = index;
        cell.rect.onClick.Add(OpenTipView);
        cell.onClick.Add(SelectFlower);
    }
    private void SelectFlower(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        var comb = new List<FlowerCombinationIdObject>(vaseData[curIndex].FlowerCombinationIds);
        var combItem = new FlowerCombinationIdObject();
        combItem.CounterCount = currFlowerListData[index].FlowersDI.ToString();
        combItem.Limit = 1;
        comb[currTabIndex] = combItem;
        for(var i = 0;i < vaseData.Count; i++)
        {

            if(IsSame(vaseData[i].FlowerCombinationIds,comb))
            {

                curIndex = i;
                lastIndex = i;
                view.vase_com.list.selectedIndex = i;
                break;
            }
        }
        ChangeFlower(currFlowerListData[index].FlowersDI, currTabIndex);

    }
    private bool IsSame(List<FlowerCombinationIdObject> ids, List<FlowerCombinationIdObject> comb)
    {
        var bol = true;
        for(int i = 0;i < ids.Count; i++)
        {
            if(ids[i].CounterCount != comb[i].CounterCount)
            {
                bol = false;
                break;
            }
        }
        return bol;
    }
    private void OpenTipView(EventContext context)
    {
        object[] param = (context.sender as GObject).data as object[];
        var flowerData = param[0] as StaticHandbook;
        FlowerHandbookModel.Instance.FilterBookData(0, 0, "");
        int index = FlowerHandbookModel.Instance.GetDataIndex(flowerData.FlowerId);
        object[] obj = new object[] { index, BookType.FLOWER };
        UIManager.Instance.OpenPanel<FlowerHandbookTipView>(UIName.FlowerHandbookTipView, UILayer.SecondUI, obj);
    }

    private void ChangeFlower(int flowerId,int index)
    {
        var item = ItemModel.Instance.GetItemById(flowerId);
        if (index == 0)
        {
            view.ike.flower_1.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
            view.ike.flower_1_effect.Play();
        }
        else if (index == 1)
        {
            view.ike.flower_2.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
            view.ike.flower_2_effect.Play();
        }
        else if (index == 2)
        {
            view.ike.flower_3.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
            view.ike.flower_3_effect.Play();
        }
    }
    public void ChangeVase()
    {
        
        for (int i = 0;i < vaseData[curIndex].FlowerCombinationIds.Count; i++)
        {
            int id = int.Parse(vaseData[curIndex].FlowerCombinationIds[i].CounterCount);
            var item = ItemModel.Instance.GetItemById(id);
            if (i == 0)
            {
                view.ike.flower_1.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_1_effect.Play();
            }
            else if (i == 1)
            {
                view.ike.flower_2.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_2_effect.Play();
            }
            else if (i == 2)
            {
                view.ike.flower_3.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_3_effect.Play();
            }
        }
    }
    public void RenderVaseList(int index,GObject item)
    {
        var cell = item as fun_CultivationManual_new.vase_item;
        var info = vaseData[index];
        cell.unlock.selectedIndex = IkeModel.Instance.IsUnlockVase(configData.VaseId)?0:1;
        UIExt_ikeImg.LoadIkeByItemId((cell.ike as common_New.ikeImg), info.IkebanaId, false);
        var status = IkeModel.Instance.GetIkeStatus((uint)info.CombinationId);
        cell.type.selectedIndex = status == 1?1:0;
        cell.unlock.selectedIndex = status == 0 ? 1 : 0;
        cell.get_btn.data = info.CombinationId;
        cell.data = index;
        cell.onClick.Add(SelectArt);
        cell.get_btn.onClick.Add(GetIkeReward);
    }
    private void GetIkeReward(EventContext context)
    {
        context.StopPropagation();
        var id = (int)(context.sender as GObject).data;
        IkeController.Instance.ReqIkebanaReward((uint)id);
    }
    public void ChangeArt()
    {
        for (int i = 0; i < vaseData[curIndex].FlowerCombinationIds.Count; i++)
        {
            int id = int.Parse(vaseData[curIndex].FlowerCombinationIds[i].CounterCount);
            var lastId = int.Parse(vaseData[lastIndex].FlowerCombinationIds[i].CounterCount);

            var item = ItemModel.Instance.GetItemById(id);
            var vo = IkeModel.Instance.GetFlower(id);
            if (i == 0 && id != lastId)
            {
                view.ike.flower_1.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_1_effect.Play();
            }
            else if (i == 1 && id != lastId)
            {
                view.ike.flower_2.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_2_effect.Play();
            }
            else if (i == 2 && id != lastId)
            {
                view.ike.flower_3.url = ImageDataModel.Instance.GetFormulaUrl(item.ItemDefId, configData.VaseId);
                view.ike.flower_3_effect.Play();
            }
        }
    }
    private void SelectArt(EventContext context)
    {
        var index = (int)(context.sender as GComponent).data;
        if (index == curIndex) return;
        curIndex = index;
        ChangeArt();
        UpdateFlowerList();
        lastIndex = curIndex;
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

