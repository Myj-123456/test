
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//using DG.Tweening;
//using ADK;

//public class ScientificPlantingWindow : BaseWindow
//{
//    private fun_ResearchPlanting.ScientificPlanting view;

//    private List<GLoader> picPool;

//    private CountDownTimer timer;

//    private List<int> itemSelected;
//    public ScientificPlantingWindow()
//    {
//        packageName = "fun_ResearchPlanting";
//        // 设置委托
//        BindAllDelegate = fun_ResearchPlanting.fun_ResearchPlantingBinder.BindAll;
//        CreateInstanceDelegate = fun_ResearchPlanting.ScientificPlanting.CreateInstance;
//        fairyBatching = false;
//    }

//    public override void OnInit()
//    {
//        base.OnInit();
//        view = ui as fun_ResearchPlanting.ScientificPlanting;
//        StringUtil.SetBtnUrl(view.btn_clearTime, ImageDataModel.CASH_ICON_URL);
//        picPool = new List<GLoader>();
//        itemSelected = new List<int> { 0, 0, 0, 0 };
//        view.ls_item.itemRenderer = RenderList;
//        view.btn_submit.onClick.Add(() =>
//        {
//            var tempCount = itemSelected.FindAll((a) => a > 0).Count;
//            ScientificPlantingContorller.Instance.ReqCultivationResearchStart((uint)tempCount);
//        });
//        view.btn_clearTime.onClick.Add(() =>
//        {
//            var cost = GetSpeedCost();
//            if (MyselfModel.Instance.diamond < cost)
//            {
//                UILogicUtils.ShowNotice("玉石不足");
//                return;
//            }
//            ScientificPlantingContorller.Instance.ReqCultivationResearchCooltime();
//        });
//        EventManager.Instance.AddEventListener(ScientificPlantingEvent.CultivationResearchStart, Close);
//        EventManager.Instance.AddEventListener(ScientificPlantingEvent.CultivationResearchCooltime, UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        itemSelected = new List<int> { 0, 0, 0, 0 };
//        UpdateView();
//        UpdateBar();
//    }

//    public void UpdateData()
//    {
//        itemSelected = new List<int> { 0, 0, 0, 0 };
//        UpdateView();
//        UpdateBar();
//    }

//    private void UpdateView()
//    {

//        var coolTimer = (int)ScientificPlantingModel.Instance.cultivateSearch.coolingTime - (int)ServerTime.Time;
//        if (ScientificPlantingModel.Instance.cultivateSearch.needItemId > 0)
//        {
//            var item = ItemModel.Instance.GetItemById((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//            view.img_item.url = ImageDataModel.Instance.GetIconUrl(item);
//            view.lb_itemName.text = Lang.GetValue(item.Name);
//            view.lb_hasCount.text = StorageModel.Instance.GetItemCount(item.ItemDefId).ToString();

//            coolTimer = (int)ScientificPlantingModel.Instance.cultivateSearch.changeTime - (int)ServerTime.Time;
//            if (timer != null)
//            {
//                timer.Clear();
//                timer = null;
//            }
//            timer = new CountDownTimer(view.lb_reflushTime, coolTimer, false);
//            timer.prefixString = Lang.GetValue("Cultivating_lottery_06") + "\n";
//            view.status.selectedIndex = 0;

//        }
//        else
//        {
//            view.status.selectedIndex = 1;
//            if (timer != null)
//            {
//                timer.Clear();
//                timer = null;
//            }
//            timer = new CountDownTimer(view.lb_reflushTime, coolTimer, false);
//            timer.suffixString = Lang.GetValue("Cultivating_lottery_09") + "\n";
//            view.lb_itemName.text = Lang.GetValue("Cultivating_lottery_08");
//            var cost = GetSpeedCost();
//            StringUtil.SetBtnTab(view.btn_clearTime, cost.ToString());
//            timer.UpdateCallBacker = (() =>
//            {
//                var cost = GetSpeedCost();
//                StringUtil.SetBtnTab(view.btn_clearTime, cost.ToString());
//            });
//        }
//        timer.hour = true;
//        timer.Run();
//        view.ls_item.numItems = 4;
//        UpdateStatus();
//    }

//    private float GetSpeedCost()
//    {
//        return Mathf.Ceil((ScientificPlantingModel.Instance.cultivateSearch.coolingTime - ServerTime.Time) / ScientificPlantingModel.Instance.costMinTime / 60) * ScientificPlantingModel.Instance.costMinRate;
//    }

//    private void UpdateStatus()
//    {
//        var tempCount = itemSelected.FindAll((a) => a > 0).Count;
//        view.btn_submit.enabled = tempCount > 0;
//        if (tempCount > 0)
//        {
//            var lottery = ScientificPlantingModel.Instance.lotteryQuantityConfig[tempCount];
//            view.lb_cultivationCount.text = lottery.Quantitys[0] + "~" + lottery.Quantitys[1];
//        }
//        else
//        {
//            view.lb_cultivationCount.text = "0";
//        }
//        var count = StorageModel.Instance.GetItemCount((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//        view.lb_hasCount.text = (count > tempCount ? count - tempCount : 0) + "";
//    }

//    private void RenderList(int index, GObject item)
//    {
//        var ui = item as fun_ResearchPlanting.ScientificPlantingItem;
//        ui.status.selectedIndex = itemSelected[index];
//        if (itemSelected[index] != 0)
//        {
//            ui.img_item.url = ImageDataModel.Instance.GetIconUrlByEntityId((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//        }
//        else
//        {
//            ui.img_item.url = "";
//        }
//        ui.btn_item_add.data = index;
//        ui.btn_item_odd.data = index;
//        ui.btn_item_add.onClick.Add(AddItemClickHander);
//        ui.btn_item_odd.onClick.Add(OddItemClickHander);
//    }

//    private void AddItemClickHander(EventContext context)
//    {
//        var count = StorageModel.Instance.GetItemCount((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//        var tempCount = itemSelected.FindAll((a) => a > 0).Count;
//        if ((count - tempCount) <= 0)
//        {
//            UILogicUtils.ShowNotice(Lang.GetValue("slang_128", ItemModel.Instance.GetNameByEntityID((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId)));
//            return;
//        }
//        var target = (context.sender as GComponent).parent as fun_ResearchPlanting.ScientificPlantingItem;
//        var targetPos = target.img_item.LocalToGlobal(Vector2.zero);
//        target.btn_item_odd.touchable = false;
//        var index = (int)(context.sender as GComponent).data;
//        itemSelected[index] = 1;
//        UpdateStatus();
//        target.status.selectedIndex = 1;
//        Fly(view.img_item.xy, view.GlobalToLocal(targetPos), target.btn_item_odd, target.img_item);
//    }

//    private void Fly(Vector2 from, Vector2 to, GComponent btn, GLoader image = null)
//    {
//        GLoader img;
//        if (picPool.Count > 0)
//        {
//            img = picPool[0];
//            picPool.RemoveAt(0);
//        }
//        else
//        {
//            img = (GLoader)UIObjectFactory.NewObject(ObjectType.Loader);

//            img.SetSize(80, 80);
//            img.pivotX = 0.5f;
//            img.pivotY = 0.5f;
//            img.pivotAsAnchor = true;
//            img.autoSize = false;
//            img.fill = FillType.Scale;
//        }
//        img.url = ImageDataModel.Instance.GetIconUrlByEntityId((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//        view.AddChild(img);
//        img.xy = from;

//        var sequence = DOTween.Sequence();
//        sequence.Append(DOTween.To(() => img.xy, x => img.xy = x, to, 0.5f).SetEase(Ease.OutCubic)).OnComplete(() =>
//        {
//            view.RemoveChild(img);
//            picPool.Add(img);
//            btn.touchable = true;
//            if (image != null)
//            {
//                image.url = ImageDataModel.Instance.GetIconUrlByEntityId((int)ScientificPlantingModel.Instance.cultivateSearch.needItemId);
//            }
//            //view.ls_item.numItems = 4;

//        }).Play();
//    }

//    private void OddItemClickHander(EventContext context)
//    {
//        var target = (context.sender as GComponent).parent as fun_ResearchPlanting.ScientificPlantingItem;
//        var targetPos = target.img_item.LocalToGlobal(Vector2.zero);
//        target.btn_item_add.touchable = false;
//        var index = (int)(context.sender as GComponent).data;
//        itemSelected[index] = 0;
//        target.status.selectedIndex = 0;
//        UpdateStatus();
//        target.img_item.url = "";
//        Fly(view.GlobalToLocal(targetPos), view.img_item.xy, target.btn_item_add);
//    }

//    private void UpdateBar()
//    {
//        view.valueBar.value = ScientificPlantingModel.Instance.cultivateSearch.luckNum;
//        view.valueBar.max = ScientificPlantingModel.Instance.lotteryCultivateConfig.LuckyValue;
//        view.lb_progress.text = ScientificPlantingModel.Instance.cultivateSearch.luckNum + "/" + ScientificPlantingModel.Instance.lotteryCultivateConfig.LuckyValue;
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

