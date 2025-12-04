
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;

public class GuildBargainWindow : BaseWindow
{
   private fun_Guild_New.guild_bargain_view view;

    private Ft_club_kanConfig kanConfig;

    private List<StorageItemVO> rewardData;


   public GuildBargainWindow()
    {
        packageName = "fun_Guild_New";
        // 设置委托
        BindAllDelegate = fun_Guild_New.fun_Guild_NewBinder.BindAll;
        CreateInstanceDelegate = fun_Guild_New.guild_bargain_view.CreateInstance;
        fairyBatching = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Guild_New.guild_bargain_view;
        SetBg(view.bg, "Guild/ELIDA_huameng_yunyoushangren_di01.png");
        SetBg(view.bg3, "Guild/ELIDA_huameng_yunyoushangren_di05.png");
        //SetBg(view.bg2, "Guild/ELIDA_huameng_yunyoushangren_ren.png");


        view.decLab.text = Lang.GetValue("bargain_1");
        view.price_txt.text = Lang.GetValue("bargain_2");
        view.titile_txt.text = Lang.GetValue("bargain_10");
        StringUtil.SetBtnTab2(view.bargain_btn, Lang.GetValue("bargain_9"));

        view.list.itemRenderer = RenderList;
        view.list.SetVirtual();

        view.rewardList.itemRenderer = RenderRewardList;

        view.show_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GuildNotBargainWindow>(UIName.GuildNotBargainWindow);
        });

        view.bargain_btn.onClick.Add(BargainClick);

        view.spine.url = "yunyoushangren";
        view.spine.loop = true;
        view.spine.animationName = "idle";

        EventManager.Instance.AddEventListener(GuildEvent.GuildKanInfo, InitBarginInfo);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKanDetail, UppdateBarginList);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKanBuy, UpdateBarginInfo);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKan, UpdateBarginInfo);
        EventManager.Instance.AddEventListener(GuildEvent.GuildKan, UppdateBarginList);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        GuildModel.Instance.ClearKanList();
        GuildController.Instance.ReqGuildKanInfo();
        GuildController.Instance.ReqGuildKanDetail(0);
    }

    private void InitBarginInfo()
    {
        kanConfig = GuildModel.Instance.GetKanConfig((int)GuildModel.Instance.kanInfo.confId);
        rewardData = GetRewardInfo();
        view.original_num.text = Lang.GetValue("slang_119") + "：" + kanConfig.Price;
        view.rewardList.numItems = rewardData.Count;
        UpdateBarginInfo();
        
        
    }

    public void UppdateBarginList()
    {
        view.list.numItems = GuildModel.Instance.kanList.Count;
    }

    private void UpdateBarginInfo()
    {
        view.discount_num.text = kanConfig.Price - (int)GuildModel.Instance.kanInfo.kanPrice + "";
        view.bargainLab.text = Lang.GetValue("bargain_3", GuildModel.Instance.kanInfo.kanCnt + "/" + kanConfig.Times);
        view.bargin_num.text = GuildModel.Instance.kanInfo.kanPrice.ToString();
        view.bargain_btn.enabled = true;
        if (GuildModel.Instance.kanInfo.haveBuy)
        {
            view.bargain_btn.enabled = false;
            StringUtil.SetBtnTab2(view.bargain_btn, Lang.GetValue("Tour_gift_txt4"));
        }else if (GuildModel.Instance.kanInfo.haveKan)
        {
            StringUtil.SetBtnTab2(view.bargain_btn, Lang.GetValue("Tour_gift_txt4"));
        }
        else
        {
            StringUtil.SetBtnTab2(view.bargain_btn, Lang.GetValue("bargain_9"));
        }
    }

    private void RenderRewardList(int index,GObject cell)
    {
        var item = cell as fun_Guild_New.guild_bargain_item;
        item.pic.url = ImageDataModel.Instance.GetIconUrl(rewardData[index].item);
        item.num.text = rewardData[index].count.ToString();
        item.nameLab.text = Lang.GetValue(rewardData[index].item.Name);
    }

    private List<StorageItemVO> GetRewardInfo()
    {
        var rewardList = new List<StorageItemVO>();
        foreach (var vaule in kanConfig.ShopItems)
        {
            var reward = new StorageItemVO();
            var itemVo = ItemModel.Instance.GetItemByEntityID(vaule.EntityID);
            reward.itemDefId = itemVo.ItemDefId;
            reward.count = vaule.Value;
            reward.item = itemVo;
            rewardList.Add(reward);
        }
        return rewardList;
    }

    private void RenderList(int index,GObject item)
    {
        var cell = item as fun_Guild_New.guild_bargain_cell;
        var info = GuildModel.Instance.kanList[index];
        cell.status.selectedIndex = index % 2;
        cell.txt_id.text = (index + 1).ToString();
        cell.nameLab.text = info.userInfo.townName;
        cell.num.text = info.kanPrice.ToString();
        cell.txt_lab.text = Lang.GetValue("bargain_4");
        GuildModel.Instance.GetKanListNext(index);
    }

    private void BargainClick()
    {
        if (GuildModel.Instance.kanInfo.haveBuy)
        {
            
        }
        else if (GuildModel.Instance.kanInfo.haveKan)
        {
            var cost = kanConfig.Price - (int)GuildModel.Instance.kanInfo.kanPrice;
            if(MyselfModel.Instance.diamond < cost)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("guildMatch_87",Lang.GetValue("gem")));
                return;
            }
            GuildController.Instance.ReqGuildKanBuy();
        }
        else
        {
            GuildController.Instance.ReqGuildKan();
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

