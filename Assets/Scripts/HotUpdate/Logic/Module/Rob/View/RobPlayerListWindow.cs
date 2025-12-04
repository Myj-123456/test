
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.rob;
using Elida.Config;

public class RobPlayerListWindow : BaseWindow
{
    private fun_Rob.robPlayerList _view;

    private int curSelectIndex;
    private List<I_FRIEND_VO> listData;

    private Dictionary<int, CountDownTimer> timerMap;

    private string[] tipInfos = new string[] { "rob_40", "rob_41", "rob_42" };

    private uint pos;
    public RobPlayerListWindow()
    {
        packageName = "fun_Help";
        // 设置委托
        BindAllDelegate = fun_Rob.fun_RobBinder.BindAll;
        CreateInstanceDelegate = fun_Rob.robPlayerList.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        _view = ui as fun_Rob.robPlayerList;
        StringUtil.SetBtnTab(_view.btn_Menu_0, Lang.GetValue("slang_40"));
        StringUtil.SetBtnTab(_view.btn_Menu_1, Lang.GetValue("slang_41"));
        StringUtil.SetBtnTab(_view.btn_Menu_2, Lang.GetValue("slang_42"));

        _view.lb_tip_bottom.text = Lang.GetValue("rob_38");

        _view.list.itemRenderer = ItemRenderer;
        _view.list.SetVirtual();

        _view.btn_Menu_0.onClick.Add(() =>
        {
            ChangeTab(0);
        });
        _view.btn_Menu_1.onClick.Add(() =>
        {
            ChangeTab(1);
        });
        _view.btn_Menu_2.onClick.Add(() =>
        {
            ChangeTab(2);
        });



        _view.close_btn.onClick.Add(CloseView);

        EventManager.Instance.AddEventListener(RobEvent.RobFriendList, UpdateListData);
        EventManager.Instance.AddEventListener(RobEvent.RobEnemyList, UpdateListData);
        EventManager.Instance.AddEventListener(RobEvent.RobRecommendList, UpdateListData);
        EventManager.Instance.AddEventListener(RobEvent.RobDailyReward, UpdateSnatch);

    }

    public override void OnShown()
    {
        base.OnShown();
        pos = 0;
        if (RobModel.Instance.info.dailyRewardStatus == 1)
        {
            RobController.Instance.ReqRobDailyReward();
        }
        // 其他打开面板的逻辑
        curSelectIndex = -1;
        if (data != null)
        {
            pos = (uint)data;
        }

        ChangeTab(0);
        UpdateSnatch();
    }

    private void ChangeTab(int index)
    {
        if (curSelectIndex == index)
        {
            return;
        }
        curSelectIndex = index;
        _view.tap.selectedIndex = curSelectIndex;
        if (curSelectIndex == 0)
        {
            RobController.Instance.ReqRobFriendList();
        }
        else if (curSelectIndex == 1)
        {
            RobController.Instance.ReqRobEnemyList();
        }
        else
        {
            RobController.Instance.ReqRobRecommendList();
        }
    }

    private void UpdateListData()
    {
        if (curSelectIndex == 0)
        {
            listData = RobModel.Instance.friendList;
        }
        else if (curSelectIndex == 1)
        {
            listData = RobModel.Instance.enemyList;
        }
        else
        {
            listData = RobModel.Instance.recommendList;
        }
        _view.list.numItems = listData.Count;
        if (listData.Count > 0)
        {
            _view.txt_empty.visible = false;
        }
        else
        {
            _view.txt_empty.visible = true;
            _view.txt_empty.text = Lang.GetValue(tipInfos[curSelectIndex]);
        }
    }

    private void ItemRenderer(int index, GObject item)
    {
        fun_Rob.playerItemRenderer cell = item as fun_Rob.playerItemRenderer;
        var player = listData[index].userInfo;
        var robinfo = listData[index].robInfo;
        cell.txt_userName.text = player.townName;

        var master_head = cell.master_head as common.robbedHead_big;
        master_head.txt_lv.text = player.userLevel.ToString();

        master_head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";

        cell.data = player;
        cell.btn_rob.data = player.userId;
        if (RobModel.Instance.robInfo.robMasterUserId == player.userId && RobModel.Instance.robInfo.robAcquittalTime > ServerTime.Time)
        {
            cell.playerStatus.selectedIndex = 0;
            cell.txt_master.text = Lang.GetValue("rob_37");
        }
        else
        {
            if (robinfo.robAcquittalTime > ServerTime.Time)
            {
                cell.playerStatus.selectedIndex = 1;
                cell.txt_status.text = Lang.GetValue("rob_35");
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
                    timeDown.Clear();
                    timeDown = null;
                    timerMap.Remove(cell.GetHashCode());
                    _view.list.RefreshVirtualList();
                };
            }

            else if (robinfo.robGuardTime > ServerTime.Time)
            {
                cell.playerStatus.selectedIndex = 2;
                cell.txt_status.text = Lang.GetValue("rob_36");
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
                cell.playerStatus.selectedIndex = 3;
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
        if (pos == 0)
        {
            foreach (var cageData in RobModel.Instance.arrestList)
            {
                if (cageData.acquittalTime <= ServerTime.Time && (cageData.userInfo == null || cageData.userInfo.userId == 0))
                {
                    pos = cageData.position;
                    break;
                }
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

    private void UpdateSnatch()
    {
        _view.c_item.lb_itemCount.text = StorageModel.Instance.GetItemCount(IDUtil.GetEntityValue(RobModel.item_snatch_id)).ToString();
        _view.c_item.icon_item.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_snatch_id);
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.RobPlayerListWindow);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

