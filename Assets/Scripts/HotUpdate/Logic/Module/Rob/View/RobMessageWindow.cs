
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class RobMessageWindow : BaseWindow
{
    private fun_Rob.RobMessage _view;
    private Dictionary<int, CountDownTimer> timerMap;
    public RobMessageWindow()
    {
        packageName = "fun_Rob";
        // 设置委托
        BindAllDelegate = fun_Rob.fun_RobBinder.BindAll;
        CreateInstanceDelegate = fun_Rob.RobMessage.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Rob.RobMessage;
        StringUtil.SetBtnTab(_view.btn_robList, Lang.GetValue("slang_107"));
        _view.msgTitle.text = Lang.GetValue("setting_txt9");//信息
        _view.retainTxt.text = Lang.GetValue("text_message1");
        _view.txt_empty.text = Lang.GetValue("text_warning5");
        timerMap = new Dictionary<int, CountDownTimer>();
        _view.list.itemRenderer = ItemRenderer;
        _view.list.SetVirtual();
        _view.btn_rob_plus.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RobShieldWindow>(UIName.RobShieldWindow, 1);
        });

        _view.btn_robList.onClick.Add(() =>
        {
            CloseView();
            UIManager.Instance.OpenWindow<RobPlayerListWindow>(UIName.RobPlayerListWindow);
        });
        _view.close_btn.onClick.Add(CloseView);
        EventManager.Instance.AddEventListener(RobEvent.RobMessage, UpdateList);
        EventManager.Instance.AddEventListener(RobEvent.RobBuy, UpdateSnatch);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        RobController.Instance.ReqRobMessage();
        UpdateSnatch();
    }

    private void UpdateList()
    {
        _view.list.numItems = RobModel.Instance.messageList.Count;
        _view.txt_empty.visible = (RobModel.Instance.messageList.Count < 1 ? true : false);
    }

    private void UpdateSnatch()
    {
        _view.c_item.lb_itemCount.text = StorageModel.Instance.GetItemCount(RobModel.item_snatch_id).ToString();
        _view.c_item.icon_item.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_snatch_id);
    }

    private void ItemRenderer(int index, GObject item)
    {
        fun_Rob.RobMessageCell cell = item as fun_Rob.RobMessageCell;
        var player = RobModel.Instance.messageList[index];
        var userInfo = player.userInfo;
        var robinfo = player.robInfo;
        cell.txt_date.text = TimeUtil.GenerateTimeDesc((int)player.operateTime);

        cell.btn_rob.data = userInfo.userId;
        var master_head = cell.master_head as common.robbedHead_big;
        cell.data = userInfo;
        cell.txt_userName.text = userInfo.townName;
        master_head.txt_lv.text = userInfo.userLevel.ToString();
        master_head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";

        cell.ableSteal.selectedIndex = 0;
        if (player.arrestResult)
        {
            cell.txt_info_0.text = Lang.GetValue("rob_27");
        }
        else
        {
            if (player.isShield)
            {
                cell.txt_info_0.text = Lang.GetValue("rob_32", "1");
            }
            else
            {
                cell.txt_info_0.text = Lang.GetValue("rob_33");
            }
        }

        if (RobModel.Instance.robInfo.robMasterUserId == userInfo.userId && RobModel.Instance.robInfo.robAcquittalTime > ServerTime.Time)
        {
            cell.txt_info_1.text = Lang.GetValue("rob_28");
            cell.txt_info_2.text = "";
        }
        else
        {
            if (robinfo.robAcquittalTime > ServerTime.Time)
            {
                cell.txt_info_1.text = Lang.GetValue("rob_29");
                CountDownTimer timeDown;
                if (timerMap.ContainsKey(cell.GetHashCode()))
                {
                    timeDown = timerMap[cell.GetHashCode()];
                    timeDown.Clear();
                    timeDown = null;
                    timerMap.Remove(cell.GetHashCode());
                }

                int time = (int)robinfo.robAcquittalTime - (int)ServerTime.Time;
                timeDown = new CountDownTimer(cell.txt_date, time);
                timerMap.Add(cell.GetHashCode(), timeDown);
                timeDown.CompleteCallBacker = () =>
                {
                    _view.list.RefreshVirtualList();
                };
            }
            else if (robinfo.robGuardTime > ServerTime.Time)
            {
                cell.txt_info_1.text = Lang.GetValue("rob_30");
                CountDownTimer timeDown;
                if (timerMap.ContainsKey(cell.GetHashCode()))
                {
                    timeDown = timerMap[cell.GetHashCode()];
                    timeDown.Clear();
                    timeDown = null;
                    timerMap.Remove(cell.GetHashCode());
                }

                int time = (int)robinfo.robGuardTime - (int)ServerTime.Time;
                timeDown = new CountDownTimer(cell.txt_date, time);
                timerMap.Add(cell.GetHashCode(), timeDown);
                timeDown.CompleteCallBacker = () =>
                {
                    _view.list.RefreshVirtualList();
                };
            }
            else
            {
                cell.ableSteal.selectedIndex = 1;
                cell.txt_info_1.text = Lang.GetValue("rob_31");
                cell.txt_info_2.text = "";
                var robItem = RobModel.Instance.robOtherConfig.SnatchOrders[0];
                StringUtil.SetBtnTab(cell.btn_rob, Lang.GetValue("rob_20"));
                StringUtil.SetBtnUrl(cell.btn_rob, ImageDataModel.Instance.GetIconUrlByEntityId(robItem.EntityID));
            }
        }

        cell.btn_rob.onClick.Add(RobHander);
    }

    private void RobHander(EventContext context)
    {
        var robItem = RobModel.Instance.robOtherConfig.SnatchOrders[0];
        int count = StorageModel.Instance.GetItemCount(IDUtil.GetEntityValue(robItem.EntityID));
        Module_item_defConfig item = ItemModel.Instance.GetItemByEntityID(robItem.EntityID);
        if (count < robItem.Value)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("guild_planting_004", Lang.GetValue(item.Name), robItem.Value.ToString()));
            return;
        }
        uint pos = 0;
        foreach (var cageData in RobModel.Instance.arrestList)
        {
            if (cageData.acquittalTime <= ServerTime.Time && (cageData.userInfo == null || cageData.userInfo.userId == 0))
            {
                pos = cageData.position;
                break;
            }
        }
        if (pos == 0)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("rob_54"));
            return;
        }
        uint id = (uint)(context.sender as GComponent).data;
        RobController.Instance.ReqRobArrest(id, pos);
        CloseView();
    }


    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.RobMessageWindow);
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

