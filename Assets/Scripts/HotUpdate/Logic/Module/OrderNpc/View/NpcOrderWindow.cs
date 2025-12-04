using ADK;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 打开插花界面需要传递的数据
/// </summary>
public class OpenIkeParam
{
    public int vaseId;
    public int formulaId;
    public NpcOrderVO npcOrderVO;
}

public class NpcOrderWindow : BaseWindow
{
    private fun_NpcOrder.npc_order viewSkin;
    private NpcOrderVO npcOrderVO;
    private int vaseId;
    private int formulaId;
    private List<NpcOrderVO> npcOrderList;
    private CustomPriceObject[] CustomPrices;
    public NpcOrderWindow()
    {
        packageName = "fun_NpcOrder";
        // 设置委托
        BindAllDelegate = fun_NpcOrder.fun_NpcOrderBinder.BindAll;
        CreateInstanceDelegate = fun_NpcOrder.npc_order.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_NpcOrder.npc_order;
        AddEvent();
        SetBg(viewSkin.bg, "NpcOrder/ELIDA_gukedingdan_tcdi.png");
        viewSkin.txt_OrderReward.text = Lang.GetValue("Treasure_headline4");
        StringUtil.SetBtnTab(viewSkin.btn_ike, Lang.GetValue("npc_order_button_03"));//点击制作
        StringUtil.SetBtnTab(viewSkin.btn_commit, Lang.GetValue("npc_order_button_02"));//提交
        StringUtil.SetBtnTab(viewSkin.btn_back, Lang.GetValue("npc_order_button_01"));//拒绝
        HideSelect();
        viewSkin.list_npcOrder.itemRenderer = ItemRender;
        viewSkin.list.itemRenderer = RenderList;
        viewSkin.list_npcOrder.onClickItem.Add(OnItemClick);
        AddEventListener(VideoEvent.videoDoubleEnd, UpdateVideoDouble);
    }

    public override void OnShown()
    {
        base.OnShown();
        npcOrderVO = data as NpcOrderVO;
        RefreshNpcOrderList();
    }

    private void RefreshNpcOrderList()
    {
        npcOrderList = NpcOrderModel.Instance.GetStandNpcOrderList();
        viewSkin.list_npcOrder.numItems = npcOrderList.Count;
        var selectIndex = npcOrderList.IndexOf(npcOrderVO);
        npcOrderVO = npcOrderList[selectIndex];
        SelectNpcOderItem(viewSkin.list_npcOrder.GetChildAt(selectIndex) as fun_NpcOrder.NpcOderSelectItem);
    }

    private void ItemRender(int index, GObject item)
    {
        fun_NpcOrder.NpcOderSelectItem cell = item as fun_NpcOrder.NpcOderSelectItem;
        var npcOrderVO = npcOrderList[index];
        var npcInfo = CustomerModel.Instance.GetNpcInfo((int)npcOrderVO.npc);
        if (npcInfo != null)
        {
            cell.loader_icon.url = $"OrderNpcIcon/{npcInfo.Head}.png";
        }
        cell.data = npcOrderVO;
    }
    private void OnItemClick(EventContext context)
    {
        var cell = context.data as fun_NpcOrder.NpcOderSelectItem;
        npcOrderVO = cell.data as NpcOrderVO;
        SelectNpcOderItem(cell);
    }

    private void SelectNpcOderItem(fun_NpcOrder.NpcOderSelectItem item)
    {
        HideSelect();
        SetSelect(item, true);
        OnSelectNpcOrder(npcOrderVO);
    }

    private void UpdateVideoDouble()
    {
        OnSelectNpcOrder(npcOrderVO);
    }

    private void OnSelectNpcOrder(NpcOrderVO npcOrderVO)
    {
        var formula = IkeModel.Instance.GetFormula((int)npcOrderVO.orderId);
        if (formula != null)
        {
            formulaId = formula.IkebanaId;
            var haveCount = StorageModel.Instance.GetItemCount(formulaId);
            var isEnabled = haveCount >= npcOrderVO.ratio ? true : false;
            viewSkin.btn_commit.visible = isEnabled;
            viewSkin.btn_ike.visible = !isEnabled;
            //npcOrderVO.ratio 为npc需要的花束数量
            viewSkin.txt_have.text = UILogicUtils.GetUBBSting(haveCount, (int)npcOrderVO.ratio, "#f3361c", "#6C6F75");

           
            CustomPrices = formula.CustomPrices;
            viewSkin.list.numItems = CustomPrices.Length;
            
            UIExt_ikeImg.LoadIkeByItemId((viewSkin.image_flower as common_New.ikeImg), formulaId, false);

            var formula1 = IkeModel.Instance.GetFormulaByItemId(formulaId);
            formula = IkeModel.Instance.GetFormula(formula1.CombinationId);
            vaseId = formula.VaseId;

            var npcConfig = NpcManager.Instance.GetNpcConfig((int)npcOrderVO.npc);
            if (npcConfig != null)
            {
                viewSkin.txt_name.text = Lang.GetValue(npcConfig.Name);
                ShowNpcAni(npcConfig.Resouce);
                ShowNpcPopupMsg(vaseId, npcConfig.Tags);
            }
        }
    }

    private void ShowNpcAni(string url)
    {
        viewSkin.anim.loop = true;
        viewSkin.anim.url = url;
        viewSkin.anim.animationName = "idle";
        var defaultPosX = 193f;
        var defaultPosY = 552f;
        if (url == "lu")
        {
            defaultPosX = 130f;
            defaultPosY = 614f;
        }
        else if (url == "yang")
        {
            defaultPosY = 594f;
        }
        else if (url == "laoshu")
        {
            defaultPosY = 521f;
        }
        else if (url == "kongque")
        {
            defaultPosY = 531f;
        }
        viewSkin.anim.x = defaultPosX;
        viewSkin.anim.y = defaultPosY;
    }
    private void ShowNpcPopupMsg(int vaseId, string[] showMsgs)
    {
        var itemData = ItemModel.Instance.GetItemById(vaseId);
        var showMsg = showMsgs[Random.Range(0, showMsgs.Length)];
        viewSkin.popUp.txt_popMsg.text = Lang.GetValue(showMsg, Lang.GetValue(itemData.Name));
        viewSkin.popUp.scale = Vector2.zero;
        viewSkin.popUp.TweenScale(Vector2.one, 0.25f).SetEase(EaseType.CircIn);
    }

    private void HideSelect()
    {
        for (var i = 0; i < viewSkin.list_npcOrder.numItems; i++)
        {
            var npcOderSelectItem = viewSkin.list_npcOrder.GetChildAt(i) as fun_NpcOrder.NpcOderSelectItem;
            SetSelect(npcOderSelectItem, false);
        }
    }

    private void SetSelect(fun_NpcOrder.NpcOderSelectItem npcOderSelectItem, bool isSelect)
    {
        npcOderSelectItem.img_select.visible = npcOderSelectItem.txt_select.visible = isSelect;
    }

    private void AddEvent()
    {
        viewSkin.btn_commit.onClick.Add(OnCommit);
        viewSkin.btn_back.onClick.Add(OnRefuse);
        viewSkin.btn_ike.onClick.Add(OnIke);
    }

    //如果有鲜花直接提交 否则需要制作插花完毕完再提交
    private void OnCommit()
    {
        CloseView();
       
        var formula = IkeModel.Instance.GetFormula((int)npcOrderVO.orderId);
        var dropList = new List<StorageItemVO>();
        
        for (int i = 0; i < formula.CustomPrices.Length; i++)
        {
            var info = formula.CustomPrices[i];
            var drop = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
            if (itemVo.ItemDefId == (int)BaseType.GOLD)
            {
                var goldRate = BuffManager.Instance.GetAddRate(BuffType.Npc_Glod_Type, (float)npcOrderVO.isDouble);
                drop.count = (int)Mathf.Ceil(info.Value * goldRate * npcOrderVO.ratio);
            }
            else if (itemVo.ItemDefId == (int)BaseType.EXP)
            {
                var expRate = BuffManager.Instance.GetAddRate(BuffType.Npc_Exp_Type, (float)npcOrderVO.isDouble);
                drop.count = (int)Mathf.Ceil(info.Value * expRate * npcOrderVO.ratio);
            }
            else
            {
                drop.count = (int)Mathf.Ceil(info.Value * npcOrderVO.ratio);
            }
            drop.itemDefId = itemVo.ItemDefId;
            dropList.Add(drop);
        }
        var item = new StorageItemVO();
        item.itemDefId = formula.IkebanaId;
        item.count = (int)npcOrderVO.ratio;
        NpcOrderModel.Instance.sumitOrderItem = item;
        NpcOrderModel.Instance.sumitOrderRewards = dropList;
        NpcOrderController.Instance.ReqSumitOrder(npcOrderVO.indexId, 1);
    }

    private void OnRefuse()
    {
        CloseView();
        NpcOrderController.Instance.ReqSumitOrder(npcOrderVO.indexId, 2);
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_NpcOrder.marketRewardGoldItem;
        var info = CustomPrices[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        if(itemVo.ItemDefId == (int)BaseType.GOLD)
        {
            var goldRate = BuffManager.Instance.GetAddRate(BuffType.Npc_Glod_Type, (float)npcOrderVO.isDouble);
            if(goldRate > 1)
            {
                cell.icon_up.visible = true;
                cell.txtRate.visible = true;
            }
            else
            {
                cell.icon_up.visible = false;
                cell.txtRate.visible = false;
            }
            cell.txtRate.text = goldRate.ToString();
            var num = Mathf.Ceil(info.Value * goldRate * npcOrderVO.ratio);
            cell.lb_value.text = num.ToString();
        }
        else if(itemVo.ItemDefId == (int)BaseType.EXP)
        {
            var expRate = BuffManager.Instance.GetAddRate(BuffType.Npc_Exp_Type, (float)npcOrderVO.isDouble);
            if (expRate > 1)
            {
                cell.icon_up.visible = true;
                cell.txtRate.visible = true;
            }
            else
            {
                cell.icon_up.visible = false;
                cell.txtRate.visible = false;
            }
            cell.txtRate.text = expRate.ToString();
            var num = Mathf.Ceil(info.Value * expRate * npcOrderVO.ratio);
            cell.lb_value.text = num.ToString();
        }
        else
        {
            cell.icon_up.visible = false;
            cell.txtRate.visible = false;
            var num = info.Value * npcOrderVO.ratio;
            cell.lb_value.text = num.ToString();

        }
    }

    private void OnIke()
    {
        CloseView();
        OpenIkeParam openIkeParam = new OpenIkeParam() { vaseId = vaseId, formulaId = formulaId, npcOrderVO = npcOrderVO };
        UIManager.Instance.OpenPanel<IkeView>(UIName.IkeView, UILayer.UI, openIkeParam);
    }

    private void CloseView()
    {
        Close();
    }
}
