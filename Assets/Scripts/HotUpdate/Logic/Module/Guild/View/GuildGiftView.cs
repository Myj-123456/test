
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class GuildGiftView : BaseView
{
   private fun_Guild_Gift.guild_gift_view view;

    private int type = 0;

    private List<GiftSmallData> listData;

    private Dictionary<int, CountDownTimer> timerMap;
   public GuildGiftView()
    {
        packageName = "fun_Guild_Gift";
        // 设置委托
        BindAllDelegate = fun_Guild_Gift.fun_Guild_GiftBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_Gift.guild_gift_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_Gift.guild_gift_view;
        SetBg(view.bg, "Guild/ELIDA_huameng_hdjs_bg.jpg");
        view.title_txt.text = Lang.GetValue("guild_gift_1");
        StringUtil.SetBtnTab(view.nomal_btn, Lang.GetValue("rob_3"));
        StringUtil.SetBtnTab(view.rare_btn, Lang.GetValue("rare_lab"));

        StringUtil.SetBtnTab3(view.nomal_btn, Lang.GetValue("rob_3"));
        StringUtil.SetBtnTab3(view.rare_btn, Lang.GetValue("rare_lab"));
        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();
        timerMap = new Dictionary<int, CountDownTimer>();

        EventManager.Instance.AddEventListener(GuildGiftEvent.GuildGiftList, InitData);
        EventManager.Instance.AddEventListener(GuildGiftEvent.GuildGiftInfo, UpdateList);
        EventManager.Instance.AddEventListener(GuildGiftEvent.GuildGiftDraw, InitData);
        EventManager.Instance.AddEventListener(GuildGiftEvent.GuildGiftGradient, UpdateBigGift);

        view.icon.onClick.Add(GetBigGiftReward);
        view.nomal_btn.onClick.Add(() =>
        {
            if(type != 0)
            {
                type = 0;
                view.list.numItems = 0;
                UpdateList();
            }
        });
        view.rare_btn.onClick.Add(() =>
        {
            if (type != 1)
            {
                type = 1;
                view.list.numItems = 0;
                UpdateList();
            }
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        view.list.numItems = 0;
        GuildGiftController.Instance.ClearNum();
        GuildGiftController.Instance.ReqGuildGiftList();
    }

    private void InitData()
    {
        UpdateList();
        UpdateBigGift();
    }

    private void UpdateList()
    {
        if(type == 0)
        {
            listData = GuildGiftModel.Instance.nomalGiftList;
        }
        else
        {
            listData = GuildGiftModel.Instance.rareGiftList;
        }
        view.list.numItems = listData.Count;
        
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_Gift.guild_small_gift;
        var itemData = listData[index];
        cell.titleLab.text = Lang.GetValue(itemData.giftConfig.Name);
        StringUtil.SetBtnTab(cell.getBtn, Lang.GetValue("common_claim_button"));
        //如果没有信息请求信息接口
        CountDownTimer timeDown;
        if (timerMap.ContainsKey(cell.GetHashCode())){
            timeDown = timerMap[cell.GetHashCode()];
            timeDown.Clear();
            timeDown = null;
            timerMap.Remove(cell.GetHashCode());
        }
        int endTime = (int)itemData.gifoVo.sendTime - (int)ServerTime.Time + itemData.giftConfig.Time;
        if (endTime > 0)
        {
            timeDown = new CountDownTimer(cell.timeLab, endTime, true, 2);
            timerMap.Add(cell.GetHashCode(), timeDown);
            timeDown.CompleteCallBacker = () =>
            {
                timeDown.Clear();
                timeDown = null;
                timerMap.Remove(cell.GetHashCode());
                UpdateList();
            };
        }
        else
        {
            cell.timeLab.text = "00:00:00";
        }
       
        if (itemData.giftInfo == null)
        {
            cell.getBtn.enabled = false;
            GuildGiftController.Instance.ReqGiftInfo(index, type);
        }
        else
        {
            if (itemData.gifoVo.draw)
            {
                cell.getBtn.enabled = false;
            }
            else
            {
                cell.getBtn.enabled = itemData.giftInfo.drawCnt < itemData.giftConfig.Limit && endTime > 0;
                //cell.nameLab.text = Lang.GetValue(itemData.giftConfig.Source, itemData.giftInfo.userInfo.townName);
                
            }
            cell.nameLab.text = itemData.giftInfo.userInfo.townName;
            cell.limitLab.text = itemData.giftInfo.drawCnt + "/" + itemData.giftConfig.Limit;
        }
        cell.getBtn.data = itemData.gifoVo.id;
        cell.getBtn.onClick.Add(CetGiftSmallGift);
    }

    private void CetGiftSmallGift(EventContext context)
    {
        var giftId = (uint)(context.sender as GComponent).data;
        GuildGiftController.Instance.ReqGuildGiftDraw(giftId);
    }

    private void UpdateBigGift()
    {
        var id = (int)GuildGiftModel.Instance.gradientCnt + 1;
        if (id > GuildGiftModel.Instance.giftBigMap.Count)
        {
            id = GuildGiftModel.Instance.giftBigMap.Count;
        }
        var bigGiftInfo = GuildGiftModel.Instance.GetGiftBigConfig(id);
        view.big_gift_name.text = Lang.GetValue(bigGiftInfo.Name);
        view.pro.max = bigGiftInfo.GiftPoint;
        view.pro.value = GuildModel.Instance.guild.giftScore;
        view.icon.touchable = GuildModel.Instance.guild.giftScore >= bigGiftInfo.GiftPoint;
        view.proLab.text = GuildModel.Instance.guild.giftScore + "/" + bigGiftInfo.GiftPoint;
    }

    private void GetBigGiftReward()
    {
        GuildGiftController.Instance.ReqGuildGiftGradient();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

