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
        _view.title_txt.text = Lang.GetValue("jinli_01"); //灵鲤珍藏
        //_view.haveLab.text = Lang.GetValue("bee_7");

        SetBg(_view.bg, "Common/ELIDA_zhuajingli_bg.png");
        SetBg(_view.bg2, "Common/ELIDA_zhuajingli_diaoyudi.png");

        timerMap = new Dictionary<uint, CountDownTimer>();

        cages = new fun_Rob.robbedCell[] { _view.cage_0, _view.cage_1, _view.cage_2 , _view.cage_3 };

        _view.btn_shield_plus.img_shield.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_shield_id);

        _view.close_btn.onClick.Add(CloseView);
        StringUtil.SetBtnTab(_view.btn_openTen, Lang.GetValue("jinli_06")); //开启10次
        _view.btn_openTen.onClick.Add(() =>
        {
            _view.btn_openTen.button.selectedIndex = _view.btn_openTen.button.selectedIndex == 0 ? 1 : 0;
            UpdateItemCount();
        });
        _view.btn_open.onClick.Add(() =>
        {
            var petalItem = RobModel.Instance.robOtherConfig.PetalConsumes[0];
            int consumeValue = petalItem.Value;
            uint exchangeNum = 1;
            
            if (_view.btn_openTen.button.selectedIndex == 1)
            {
                consumeValue *= 10;
                exchangeNum = 10;
            }
            int count = StorageModel.Instance.GetItemCount(petalItem.EntityID);
            if(count < consumeValue)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("rob_9"));
                return;
            }
            RobController.Instance.ReqRobExchange(exchangeNum);
        });
        StringUtil.SetBtnTab(_view.btn_shield_plus, Lang.GetValue("jinli_09")); //空军符
        _view.btn_shield_plus.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RobShieldWindow>(UIName.RobShieldWindow, 1);
        });
        StringUtil.SetBtnTab(_view.btn_logs, Lang.GetValue("jinli_08")); //采集记录
        _view.btn_logs.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<RobMessageWindow>(UIName.RobMessageWindow);
        });
        StringUtil.SetBtnTab(_view.btn_videos, Lang.GetValue("jinli_07")); //免费锦鲤
        _view.btn_videos.onClick.Add(() => 
        {
            VideoController.Instance.ReqVideoWatch(19001);
        });

        EventManager.Instance.AddEventListener(RobEvent.RobInfo, UpdateData);
        EventManager.Instance.AddEventListener(RobEvent.RobUnlock, UpdateCages);
        EventManager.Instance.AddEventListener(RobEvent.RobReward, UpdateItemCount);
        //EventManager.Instance.AddEventListener(RobEvent.RobBuy, UpdateShield);
        EventManager.Instance.AddEventListener(RobEvent.RobSetshield, UpdateShieldStatus);
        EventManager.Instance.AddEventListener(RobEvent.RobReward, UpdateFarmStatus);

    }

    private void UpdateData()
    {
        UpdateSelfStatus();
        //UpdateShield();
        UpdateItemCount();
        UpdateCages();
        UpdateShieldStatus();
        
        // 设置广告观看次数和奖励
        int watchedCount = VideoModel.Instance.GetWatchVideoCount((int)VideoSeeType.rob_video_id);
        int maxCount = int.Parse(GlobalModel.Instance.module_profileConfigData.Get("robVideoTime").Value);
        int rewardCount = int.Parse(GlobalModel.Instance.module_profileConfigData.Get("robVideoReward").Value);
        _view.btn_videos.txt_number.text = "（"+watchedCount + "/" + maxCount+"）";
        _view.btn_videos.reward_num.text = rewardCount.ToString();
        
        if (watchedCount >= maxCount)
        {
            _view.btn_videos.grayed = true;
            _view.btn_videos.touchable = false;
        }
        else
        {
            _view.btn_videos.grayed = false;
            _view.btn_videos.touchable = true;
        }
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
            
            //_view.lb_robInfo.text = Lang.GetValue("rob_8");
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

    //private void UpdateShield()
    //{
    //    _view.lb_shield_count.text = StorageModel.Instance.GetItemCount(RobModel.item_shield_id).ToString();
    //}

    private void UpdateItemCount()
    {
        _view.countLab.text = StorageModel.Instance.GetItemCount(RobModel.item_petal_id).ToString();
        _view.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_petal_id);
        var petalItem = RobModel.Instance.robOtherConfig.PetalConsumes[0];
        _view.btn_open.pic.url = ImageDataModel.Instance.GetIconUrlByEntityId(petalItem.EntityID);
        int showValue = petalItem.Value;
        if (_view.btn_openTen.button.selectedIndex == 1)
        {
            showValue *= 10;
        }
        _view.btn_open.titleLab.text= showValue.ToString();
        _view.btn_open.titleLab1.text = Lang.GetValue("UserInfoOn"); //开启
    }

    private void UpdateCages()
    {
        int len = cages.Length;
        for(int i = 0;i < len; i++)
        {
            UpdateCage(i);
        }
        
        UpdateFarmStatus();
    }
    
    private void UpdateFarmStatus()
    {
        // 统计正在劳作的雇员数量
        int workingEmployeeCount = 0;
        foreach(fun_Rob.robbedCell cage in cages)
        {
            if(cage.status.selectedIndex == 0)
            {
                workingEmployeeCount++;
            }
        }
        // 如果有雇员劳作
        if(workingEmployeeCount > 0 || RobModel.Instance.info.harvestCnt > 0)
        {
            _view.farm.status.selectedIndex = 1;
            StringUtil.SetBtnTab(_view.farm.n5, Lang.GetValue("jinli_03")); //点击收获
            _view.farm.pic.url= ImageDataModel.Instance.GetIconUrlByEntityId(RobModel.item_petal_id);
           
            _view.farm.Count_text.text = RobModel.Instance.info.harvestCnt.ToString();
            _view.farm.n5.onClick.Add(() =>
            {
                //_view.farm.status.selectedIndex = 0;
                RobController.Instance.ReqRobReward();
            });

        }
        else
        {
            _view.farm.n10.text = Lang.GetValue("jinli_04"); //没有雇员劳作
            StringUtil.SetBtnTab(_view.farm.n8, Lang.GetValue("jinli_05")); //前往雇佣
            _view.farm.Count_text.text = "";
            _view.farm.n8.onClick.Add(() => 
            {
                if(RobModel.Instance.info.harvestCnt > 0)
                {
                    
                }
                else
                {
                    UIManager.Instance.OpenWindow<RobPlayerListWindow>(UIName.RobPlayerListWindow);
                }
            });
        }
    }

    private void UpdateCage(int index)
    {
        var cage = cages[index];

        var robHead = cage.robHead;
        robHead.g_evel.visible = false;
        robHead.img_head.url = "";
        
        var cageData = RobModel.Instance.GetArrestInfo((uint)(index + 1));
        if (cageData != null)
        {
            cage.data = cageData;
            if (cageData.acquittalTime > ServerTime.Time)
            {
                var frameVo = ItemModel.Instance.GetItemById((int)cageData.userInfo.headFrame);
                UILogicUtils.ShowHeadFrames(robHead.picFrame as common_New.PictureFrame, frameVo);
                var headVo = ItemModel.Instance.GetItemById(int.Parse(cageData.userInfo.headImgId));
                robHead.img_head.url = ImageDataModel.Instance.GetIconUrl(headVo);

                cage.status.selectedIndex = 0;
                robHead.g_evel.visible = true;
                robHead.txt_lv.text = cageData.userInfo.userLevel.ToString();
                cage.lb_title.text = TextUtil.GetServerName(cageData.userInfo.serverId,cageData.userInfo.townName);
                
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
                
            }
            else
            {
                cage.status.selectedIndex = 1;
                robHead.img_head.url = "";
                StringUtil.SetBtnTab(cage.catchBtn, Lang.GetValue("rob_20"));

            }
        }
        else
        {
            if(index == 3 && !MyselfModel.Instance.IsVip())
            {
                cage.status.selectedIndex = 4;
            }
            else
            {
                cage.status.selectedIndex = 2;
            }
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
        
        UpdateFarmStatus();
    }

    private void CageClickHander(EventContext context)
    {
        fun_Rob.robbedCell cage = context.sender as fun_Rob.robbedCell;
        var info = cage.data as I_ROB_ARREST_VO;
        if (cage.status.selectedIndex == 0 && info != null)
        {
            MyselfController.Instance.ReqOtherUserInfo(info.userInfo.userId);
        }
        else if (cage.status.selectedIndex == 3)
        {
            //RobController.Instance.ReqRobReward((cage.data as I_ROB_ARREST_VO).position);
        }
        else if(cage.status.selectedIndex == 1 && info != null)
        {
            UIManager.Instance.OpenWindow<RobPlayerListWindow>(UIName.RobPlayerListWindow, info.position);
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
        UILogicUtils.ShowConfirm(Lang.GetValue("trade_unlock_tip", cost + Lang.GetValue("gem")),()=>
        {
            RobController.Instance.ReqRobUnlock((uint)(index + 1));
        }
        );
        
    }

    private void HeadTouchBegin(EventContext context)
    {
        var cell = (context.sender as GComponent).parent as fun_Rob.robbedCell;
        I_ROB_ARREST_VO cageData = cell.data as I_ROB_ARREST_VO;
        if(cageData != null)
        {
            //_view.robedTips.lb_info.text = Lang.GetValue("rob_10");
           //_view.robedTips.x = cell.x + cell.width / 2;
            //_view.robedTips.y = cell.y;
            //_view.robedTips.visible = true;
        }
    }

    private void HeadTouchEnd(EventContext context)
    {
        //_view.robedTips.visible = false;
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