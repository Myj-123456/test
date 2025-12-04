
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.rob;

public class RobWindow : BaseWindow
{
   private fun_Rob.rob _view;
    private CountDownTimer timer;
    private fun_Rob.robbedCell[] cages;
    private Dictionary<uint, CountDownTimer> timerMap;

   public RobWindow()
    {
        packageName = "fun_Rob";
        // 设置委托
        BindAllDelegate = fun_Rob.fun_RobBinder.BindAll;
        CreateInstanceDelegate = fun_Rob.rob.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_Rob.rob;
        _view.title_txt.text = Lang.GetValue("wanba_title10");
        _view.haveLab.text = Lang.GetValue("bee_7");

        timerMap = new Dictionary<uint, CountDownTimer>();

        cages = new fun_Rob.robbedCell[] { _view.cage_0, _view.cage_1, _view.cage_2 , _view.cage_3 };

        _view.img_shield.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_shield_id);

        _view.close_btn.onClick.Add(CloseView);
        _view.farm.btn_open.onClick.Add(() =>
        {
            var petalItem = RobModel.Instance.robOtherConfig.PetalConsumes[0];
            int count = StorageModel.Instance.GetItemCount(petalItem.EntityID);
            if(count < petalItem.Value)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("rob_9"));
                return;
            }
            RobController.Instance.ReqRobExchange();
        });

        _view.btn_shield_plus.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RobShieldWindow>(UIName.RobShieldWindow, 0);
        });
        _view.btn_logs.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RobMessageWindow>(UIName.RobMessageWindow);
        });
        EventManager.Instance.AddEventListener(RobEvent.RobInfo, UpdateData);
        EventManager.Instance.AddEventListener(RobEvent.RobUnlock, UpdateCages);
        EventManager.Instance.AddEventListener(RobEvent.RobReward, UpdateItemCount);
        EventManager.Instance.AddEventListener(RobEvent.RobBuy, UpdateShield);
        EventManager.Instance.AddEventListener(RobEvent.RobSetshield, UpdateShieldStatus);
    }

    private void UpdateData()
    {
        UpdateSelfStatus();
        UpdateShield();
        UpdateItemCount();
        UpdateCages();
        UpdateShieldStatus();
    }

    private void UpdateSelfStatus()
    {
        if(RobModel.Instance.robInfo.robAcquittalTime > ServerTime.Time)
        {
            _view.self_status.selectedIndex = 2;
            _view.lb_master_userName.text = Lang.GetValue("rob_5");
            _view.lb_rob_status.text = RobModel.Instance.targetUserInfo.townName;

            var master_head = _view.master_head as common.robbedHead_big;
            master_head.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
            master_head.txt_lv.text = RobModel.Instance.targetUserInfo.userLevel.ToString();
            
            _view.lb_robInfo.text = Lang.GetValue("rob_8");
            if(timer != null)
            {
                timer.Clear();
            }
            uint time = RobModel.Instance.robInfo.robAcquittalTime - ServerTime.Time;
            timer = new CountDownTimer(_view.lb_robTime, (int)time);
            timer.CompleteCallBacker = UpdateSelfStatus;
        }
        else if(RobModel.Instance.robInfo.robGuardTime > ServerTime.Time)
        {
            _view.self_status.selectedIndex = 1;
            _view.lb_protect.text = Lang.GetValue("rob_7");
            if (timer != null)
            {
                timer.Clear();
            }
            uint time = RobModel.Instance.robInfo.robAcquittalTime - ServerTime.Time;
            timer = new CountDownTimer(_view.lb_protect_date , (int)time);
            timer.CompleteCallBacker = UpdateSelfStatus;
        }
        else
        {
            _view.self_status.selectedIndex = 0;
            _view.lb_freedom.text = Lang.GetValue("rob_6");
        }
        
    }

    private void UpdateShield()
    {
        _view.lb_shield_count.text = StorageModel.Instance.GetItemCount(RobModel.item_shield_id).ToString();
    }

    private void UpdateItemCount()
    {
        _view.countLab.text = StorageModel.Instance.GetItemCount(RobModel.item_petal_id).ToString();
        _view.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_petal_id);
        var petalItem = RobModel.Instance.robOtherConfig.PetalConsumes[0];
        _view.farm.btn_open.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(petalItem.EntityID);
        StringUtil.SetBtnTab(_view.farm.btn_open, petalItem.Value.ToString());
    }

    private void UpdateCages()
    {
        int len = cages.Length;
        for(int i = 0;i < len; i++)
        {
            UpdateCage(i);
        }
    }

    private void UpdateCage(int index)
    {
        var cage = cages[index];

        var robHead = cage.robHead as common.robbedHead_big;
        robHead.g_evel.visible = false;
        robHead.img_head.url = "";
        (robHead.picFrame as common_New.PictureFrame).pic.url = "";
        var cageData = RobModel.Instance.GetArrestInfo((uint)(index + 1));

        bool hasPlayer = false;
        if (cageData != null)
        {
            
            cage.data = cageData;
            if (cageData.acquittalTime > ServerTime.Time)
            {
                hasPlayer = true;
                cage.status.selectedIndex = 0;
                robHead.g_evel.visible = true;
                robHead.txt_lv.text = cageData.userInfo.userLevel.ToString();
                cage.lb_title.text = cageData.userInfo.townName;
                robHead.img_head.url = "Avatar/ELIDA_common_touxiangdi01.png";
                if (timerMap.ContainsKey(cageData.position))
                {
                    timerMap[cageData.position].Clear();
                }
                else
                {
                    timerMap.Add(cageData.position, null);
                }
                uint time = cageData.acquittalTime - ServerTime.Time;
                timerMap[cageData.position] = new CountDownTimer(cage.lb_timeDown, (int)time);
                timerMap[cageData.position].CompleteCallBacker = ()=> { UpdateCage(index); };
                robHead.onTouchBegin.Add(HeadTouchBegin);
                robHead.onTouchEnd.Add(HeadTouchEnd);
                robHead.onRollOut.Add(HeadTouchEnd);
            }
            else
            {
                if(cageData.userInfo != null && cageData.userInfo.userId != 0)
                {
                    cage.status.selectedIndex = 3;
                    cage.img_reward.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_petal_id);
                }
                else
                {
                    cage.status.selectedIndex = 1;
                    robHead.img_head.url = "";
                    StringUtil.SetBtnTab(cage.catchBtn, Lang.GetValue("rob_20"));

                }
            }
        }
        else
        {
            cage.status.selectedIndex = index == 3 ? 3 : 2 ;
            robHead.g_evel.visible = false;
            int value = 0;
            if (index == 1)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume1s[0].Value;
            }
            else if(index == 2)
            {
                value = RobModel.Instance.robOtherConfig.UnlockConsume2s[0].Value;
            }
            StringUtil.SetBtnTab(cage.btn_unlock, value.ToString());
            cage.btn_unlock.data = index;
            cage.btn_unlock.onClick.Add(UnlockCage);
        }
        cage.onClick.Add(CageClickHander);
    }

    private void CageClickHander(EventContext context)
    {
        fun_Rob.robbedCell cage = context.sender as fun_Rob.robbedCell;
        if(cage.status.selectedIndex == 0)
        {

        }else if(cage.status.selectedIndex == 3)
        {
            RobController.Instance.ReqRobReward((cage.data as I_ROB_ARREST_VO).position);
        }
        else if(cage.status.selectedIndex == 1)
        {
            UIManager.Instance.OpenWindow<RobPlayerListWindow>(UIName.RobPlayerListWindow, (cage.data as I_ROB_ARREST_VO).position);
        }
    }

    private void UnlockCage(EventContext context)
    {
        
        int index = (int)(context.sender as GComponent).data;
        if (RobModel.Instance.GetArrestListIndex((uint)index) == -1)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("rob_52"));
            return;
        }
        int cost = 0;
        if (index == 1)
        {
            cost = RobModel.Instance.robOtherConfig.UnlockConsume1s[0].Value;
        }
        else if (index == 2)
        {
            cost = RobModel.Instance.robOtherConfig.UnlockConsume2s[0].Value;
        }
        if(MyselfModel.Instance.diamond < cost)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_txt3"));
            return;
        }
        RobController.Instance.ReqRobUnlock((uint)(index + 1));
    }

    private void HeadTouchBegin(EventContext context)
    {
        var cell = (context.sender as GComponent).parent as fun_Rob.robbedCell;
        I_ROB_ARREST_VO cageData = cell.data as I_ROB_ARREST_VO;
        if(cageData != null)
        {
            _view.robedTips.lb_info.text = Lang.GetValue("rob_10");
            _view.robedTips.x = cell.x + cell.width / 2;
            _view.robedTips.y = cell.y;
            _view.robedTips.visible = true;
        }
    }

    private void HeadTouchEnd(EventContext context)
    {
        _view.robedTips.visible = false;
    }

    private void UpdateShieldStatus()
    {
        _view.shieldSwitch.status.selectedIndex = (int)RobModel.Instance.info.openShield;
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.RobWindow);
    }

    public override void OnShown()
    {
        base.OnShown();
        RobController.Instance.ReqRobInfo();
        // 其他打开面板的逻辑
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

