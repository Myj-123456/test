using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Spine;
using static protobuf.plant.S_MSG_RANK_LIST;

public class FlowerRankView : BaseView
{
    private fun_FlowerRankingList.FlowerRankView view;

    private GButton[] tabBtnArr;

    private GList rankList;

    private common_New.PictureFrame picFrame;

    private int currTabIndex = -1;

    private int[] tweenSign;

    private Dictionary<int,UIHeroAvatar> heroAvatarMap;

    private GGraph bottomMask;

    private bool inited = false;

    //private UIHeroAvatar heroAvatar1;
    //private UIHeroAvatar heroAvatar2;
    //private UIHeroAvatar heroAvatar3;
    public FlowerRankView()
    {
        packageName = "fun_FlowerRankingList";
        // 设置委托
        BindAllDelegate = fun_FlowerRankingList.fun_FlowerRankingListBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerRankingList.FlowerRankView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_FlowerRankingList.FlowerRankView;
        tabBtnArr = new GButton[] { view.pros_tabBtn, view.cultivate_tabBtn, view.art_tabBtn, view.dressBtn };
        rankList = view.rankList;
        rankList.itemRenderer = RandererListItem;
        rankList.SetVirtual();
        picFrame = view.picFrame as common_New.PictureFrame;
        heroAvatarMap = new Dictionary<int, UIHeroAvatar>();
        //rankList.clipSoftness = new Vector2(0,50)       heroAvatarMap = new Dictionary<int, UIHeroAvatar>();
        view.updateTxt.text = Lang.GetValue("flower_rank2");// 每周日23点，排行榜名次停止更新
        view.txt_info3.text = Lang.GetValue("flower_rank7");// 每周一0点，发放上周排行榜奖励
        //view.txt_info1.text = Lang.GetValue("flower_rank6");//当前排名
        //view.txt_info4.text = Lang.GetValue("flower_rank5");//上周排名：
        //view.titleLab.text = Lang.GetValue("flower_rank1");

        view.txt_info1_tip.text = Lang.GetValue("flower_rank_1");
    
        StringUtil.SetBtnTab(view.pros_tabBtn, Lang.GetValue("flower_rank_12"));
        StringUtil.SetBtnTab(view.cultivate_tabBtn, Lang.GetValue("name_flower_from1"));
        StringUtil.SetBtnTab(view.art_tabBtn, Lang.GetValue("flower_rank_13"));
        StringUtil.SetBtnTab(view.dressBtn, Lang.GetValue("flower_rank_14"));

        //StringUtil.SetBtnTab(view.btn_rewardView, Lang.GetValue("title_activity_3"));

        view.txt_info1.text = Lang.GetValue("flower_rank6");
        SetBg(view.bg, "FlowerRank/ELIDA_common_paihangbang_bg1.png");

        view.bg1.url = "FlowerRank/ELIDA_common_paihangbang_qiansanbg01.png";
        //view.show.visible = false;
        //heroAvatar1 = new UIHeroAvatar();
        //heroAvatar1.Init(view.anim1);

        //heroAvatar1.UpdateDress();

        //heroAvatar2 = new UIHeroAvatar();
        //heroAvatar2.Init(view.anim2);

        //heroAvatar2.UpdateDress();

        //heroAvatar3 = new UIHeroAvatar();
        //heroAvatar3.Init(view.anim3);

        //heroAvatar3.UpdateDress();

        foreach (GButton btn in tabBtnArr)
        {
            btn.onClick.Add(ClickTabBtn);
        }

        view.question_btn.onClick.Add(() =>
        {
            string[] str = new string[] { Lang.GetValue("flower_rank1"), Lang.GetValue("flower_rank10") };
            UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, str);
            //BlurFilter blur = new BlurFilter();
            //blur.blurSize = 0f;
            //view.filter = blur;

        });

        LongPressGesture gesture = new LongPressGesture(view.head);
        gesture.trigger = 0.3f;
        gesture.onAction.Add(OnGestureAction);
        gesture.onEnd.Add(OnGestureEnd);

        EventManager.Instance.AddEventListener(FlowerRankEvent.RankList, RefreshUI);
        EventManager.Instance.AddEventListener(FlowerRankEvent.prosperityUserInfo, RefreshUI);
        EventManager.Instance.AddEventListener(FlowerRankEvent.cultivateUserInfo, RefreshUI);
        EventManager.Instance.AddEventListener(FlowerRankEvent.artUserInfo, RefreshUI);
        EventManager.Instance.AddEventListener(FlowerRankEvent.dressUserInfo, RefreshUI);
        InitSpine();
    }

    private void InitSpine()
    {
        view.spine.loop = true;
        view.spine.url = "shuye";
        view.spine.animationName = "animation";

        view.spine2.loop = true;
        view.spine2.url = "no2";
        view.spine2.animationName = "animation";

        view.spine3.loop = true;
        view.spine3.url = "no3";
        view.spine3.animationName = "animation";

        PlaySpine();
    }

    private void PlaySpine()
    {
        if (!inited)
        {
            view.spine1.url = "no1";
            view.spine1.Complete = OnAnimationEventHandler;
            view.spine.forcePlay = true;
            inited = true;
        }
        view.spine1.loop = false;
        view.spine1.animationName = "open";
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "open")
        {
            view.spine1.loop = true;
            view.spine1.animationName = "idle";
        }
    }

    private void OnGestureAction(EventContext context)
    {

        //if (IsShowRank() && !view.show.visible)
        //{
        //    view.show.visible = true;
        //}
    }

    private void OnGestureEnd()
    {
        //if (view.show.visible)
        //{
        //    view.show.visible = false;
        //}
        
    }


    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        PlaySpine();
        currTabIndex = -1;
        tweenSign = new int[] { 0, 0, 0,0 };
        ChangeTab(0);
        HaveMoney();
        UpdateRabkBtn();
    }

    public IEnumerator ShowRank()
    {
        yield return new WaitForSeconds(5f);
        //view.show.visible = false;
    }

    private bool IsShowRank()
    {
        
        //var svrInfo = FlowerRankModel.Instance.curRankList;
        //var myInfo = FlowerRankModel.Instance.GetMyInfo((uint)(currTabIndex + 1));
        //if (myInfo.prevRank > 0 && svrInfo.myRank.rank > 0)
        //{
        //    return (int)myInfo.prevRank - (int)svrInfo.myRank.rank > 0;
        //}
        //else
        //{
        return false;
        //}
    }

    private void ClickTabBtn(EventContext context)
    {
        int index = Array.IndexOf(tabBtnArr, context.sender);
        if(currTabIndex != index)
        {
            ChangeTab(index);
        }
        
    }

    private void HaveMoney()
    {
        view.txt_cash.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
        view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
    }

    private void ChangeTab(int pageIndex)
    {
        currTabIndex = pageIndex;
        SetBg(view.bg, "FlowerRank/ELIDA_common_paihangbang_bg" + (currTabIndex + 1) +".png");
        view.pageStatus.selectedIndex = pageIndex;
        view.iconCom.status.selectedIndex = pageIndex;
        if(tweenSign[currTabIndex] == 0)
        {
            FlowerRankController.Instance.ReqRankList((uint)currTabIndex + 1);
            return;
        }
        RefreshUI();
        //FlowerRankController.Instance.ResRankList((uint)(currTabIndex + 1));
        //GetRankReward();
    }

    private void RefreshUI()
    {
        List<I_RANK_VO> rankList = null;
        if (currTabIndex == 0)
        {
            rankList = FlowerRankModel.Instance.prosperityRankList.rankList;
        }
        else if (currTabIndex == 1)
        {
            rankList = FlowerRankModel.Instance.cultivateRankList.rankList;
        }
        else if (currTabIndex == 2)
        {
            rankList = FlowerRankModel.Instance.artRankList.rankList;
        }
        else
        {
            rankList = FlowerRankModel.Instance.dressRankList.rankList;
        }
        int len = rankList.Count;
        RendererRankItems(0, view.rank0);
        RendererRankItems(1, view.rank1);
        RendererRankItems(2, view.rank2);
        ShowMyRankInfo();
        //view.show.visible = false;
        view.rankList.numItems = (len - 3) > 0 ? (len - 3) : 0;
        UILogicUtils.ClearTweenOfViewList(view.rankList);
        if (tweenSign[currTabIndex] == 0)
        {
            tweenSign[currTabIndex] = 1;
            UILogicUtils.AddTweenOfViewList(view.rankList);
            FlowerRankController.Instance.ReqRankUserInfo((uint)currTabIndex + 1);
            //if (IsShowRank())
            //{
            //    view.show.visible = true;
            //    StartCoroutine(ShowRank());
            //}
            //else
            //{
            //    view.show.visible = false;
            //}
        }
    }

    public void ShowMyRankInfo()
    {
        I_MY_RANK svrInfo = null;
        if (currTabIndex == 0)
        {
            svrInfo = FlowerRankModel.Instance.prosperityRankList.myRank;
        }
        else if (currTabIndex == 1)
        {
            svrInfo = FlowerRankModel.Instance.cultivateRankList.myRank;
        }
        else if (currTabIndex == 2)
        {
            svrInfo = FlowerRankModel.Instance.artRankList.myRank;
        }
        else
        {
            svrInfo = FlowerRankModel.Instance.dressRankList.myRank;
        }
        //view.txt_name.text = MyselfModel.Instance.
        if (svrInfo.rank > 0)
        {
            //var data = FlowerRankModel.Instance.GetRankConfigByRank((int)svrInfo.myRank.rank, currTabIndex);
            //var itemVo = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
            view.txt_info1.text = svrInfo.rank.ToString();
            //view.txt_rankTitle.text = Lang.GetValue(itemVo.Name) + "x" + data.Rewards[0].Value;
        }
        else
        {
            view.txt_info1.text = Lang.GetValue("flower_rank9");
            
        }
        //view.txt_info4.text = Lang.GetValue("flower_rank_2", ((int)myInfo.prevRank - (int)svrInfo.myRank.rank).ToString());
        view.txt_point.text = svrInfo.score.ToString();
        
        var head = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR);
        var frame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        var headVo = ItemModel.Instance.GetItemById(int.Parse(head.info));
        var frameVo = ItemModel.Instance.GetItemById(int.Parse(frame.info));

        UILogicUtils.ShowHeadFrames(view.picFrame as common_New.PictureFrame, frameVo);

        var title = MyselfModel.Instance.GetUserInfo(UserInfoType.TITLE);
        if (title == null)
        {
            view.txt_rankTitle.text = Lang.GetValue("player_info_12");
        }
        else
        {
            var titleId = int.Parse(title.info);
            var titleVo = ItemModel.Instance.GetItemById(titleId);
            view.txt_rankTitle.text = Lang.GetValue(titleVo.Name);
        }
        (view.head as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
        
        view.txt_name.text = "s" + MyselfModel.Instance.serverId + "." + MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
    }

    private void RandererListItem(int index,GObject cell)
    {
        fun_FlowerRankingList.FlowerRankListItem item = cell as fun_FlowerRankingList.FlowerRankListItem;

        List<I_RANK_VO> rankList = null;
        if (currTabIndex == 0)
        {
            rankList = FlowerRankModel.Instance.prosperityRankList.rankList;
        }
        else if (currTabIndex == 1)
        {
            rankList = FlowerRankModel.Instance.cultivateRankList.rankList;
        }
        else if (currTabIndex == 2)
        {
            rankList = FlowerRankModel.Instance.artRankList.rankList;
        }
        else
        {
            rankList = FlowerRankModel.Instance.dressRankList.rankList;
        }

        var rankInfo = rankList[index + 3];
        int rank = (int)rankInfo.rank;
        item.rankStyle.selectedIndex = rank == rankList.Count?4:3;
        item.rankTxt.text = rank.ToString();
        //item.txt_name.text = rankInfo.userInfo.townName;
        item.txt_point.text = rankInfo.score.ToString();
        var userInfo = FlowerRankModel.Instance.GetUserInfo(currTabIndex + 1, rankInfo.targetId);
        if(userInfo != null)
        {
            
            var headVo = ItemModel.Instance.GetItemById(int.Parse(userInfo.userInfo.headImgId));
            var frameVo = ItemModel.Instance.GetItemById((int)(userInfo.userInfo.headFrame));

            UILogicUtils.ShowHeadFrames(item.frame as common_New.PictureFrame, frameVo);
            (item.head as common_New.MoonFestivalHead).pic.url = ImageDataModel.Instance.GetIconUrl(headVo);
            item.txt_name.text = TextUtil.GetServerName(userInfo.userInfo.serverId,userInfo.userInfo.townName);
            if (userInfo.userInfo.title == 0)
            {
                item.titleTxt.text = Lang.GetValue("player_info_12");
            }
            else
            {
                var titleId = (int)userInfo.userInfo.title;
                var titleVo = ItemModel.Instance.GetItemById(titleId);
                item.titleTxt.text = Lang.GetValue(titleVo.Name);
            }

        }
        //var data = FlowerRankModel.Instance.GetRankConfigByRank(rank, currTabIndex);
        //if (data != null)
        //{
        //    var itemVo = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
        //    item.titleTxt.text = Lang.GetValue(itemVo.Name) + "x" + data.Rewards[0].Value;
        //    //(item.frame as common_New.PictureFrame).pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        //}
        //else
        //{
        //    item.titleTxt.text = "";
        //    (item.frame as common_New.PictureFrame).pic.url = "";
        //}
        
    }

    public void RendererRankItems(int index, fun_FlowerRankingList.FlowerRankTopItem1 item)
    {
        
        item.rankStyle.selectedIndex = index;
        var anim = view.GetChild("anim" + (index + 1)) as GLoader3D;
        var spine = view.GetChild("spine" + (index + 1));
        item.iconCom.status.selectedIndex = currTabIndex;
        List<I_RANK_VO> rankList = null;
        if (currTabIndex == 0)
        {
            rankList = FlowerRankModel.Instance.prosperityRankList.rankList;
        }
        else if (currTabIndex == 1)
        {
            rankList = FlowerRankModel.Instance.cultivateRankList.rankList;
        }
        else if (currTabIndex == 2)
        {
            rankList = FlowerRankModel.Instance.artRankList.rankList;
        }
        else
        {
            rankList = FlowerRankModel.Instance.dressRankList.rankList;
        }
        if (rankList.Count < (index + 1))
        {
            item.txt_name.text = Lang.GetValue("flower_rank9");
            item.titleTxt.text = Lang.GetValue("flower_rank9");
            item.txt_point.text = "0";
            anim.visible = false;
            spine.visible = false;
            //(item.head as common_New.MoonFestivalHead).pic.url = "";
            //(item.frame as common_New.PictureFrame).pic.url = "";
            return;
        }
        var rankInfo = rankList[index];
        item.txt_point.text = rankInfo.score.ToString();
        var userInfo = FlowerRankModel.Instance.GetUserInfo(currTabIndex + 1, rankInfo.targetId);
        if(userInfo != null)
        {
            anim.visible = true;
            spine.visible = true;
            if (!heroAvatarMap.ContainsKey(index))
            {
                var heroAvatar = new UIHeroAvatar();

                heroAvatar.Init(anim);
                heroAvatarMap.Add(index, heroAvatar);
            }
            var dressData = DressModel.Instance.GetDressData(userInfo.dress.ware);
            heroAvatarMap[index].UpdateDress(dressData);
            

            item.txt_name.text = TextUtil.GetServerName(userInfo.userInfo.serverId, userInfo.userInfo.townName);
            if (userInfo.userInfo.title == 0)
            {
                item.titleTxt.text = Lang.GetValue("player_info_12");
            }
            else
            {
                var titleId = (int)userInfo.userInfo.title;
                var titleVo = ItemModel.Instance.GetItemById(titleId);
                item.titleTxt.text = Lang.GetValue(titleVo.Name);
            }
        }
        //var dressData =  DressModel.Instance.GetDressData(rankInfo.dress.ware);
        //heroAvatarMap[index].UpdateDress(dressData);

        //if (data != null)
        //{
        //    var itemVo = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
        //    item.titleTxt.text = Lang.GetValue(itemVo.Name) + "x" + data.Rewards[0].Value;
        //    //(item.frame as common_New.PictureFrame).pic.url = ImageDataModel.Instance.GetIconUrl(itemVo); 
        //}
        //else
        //{
        //    item.titleTxt.text = "";
        //    //(item.frame as common_New.PictureFrame).pic.url = "";
        //}
        //(item.head as common_New.MoonFestivalHead).pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
    }

    private void UpdateRabkBtn()
    {
        //view.pros_tabBtn.visible = GlobalModel.Instance.GetUnlocked(SysId.Viballs);
        //view.dressBtn.visible = GlobalModel.Instance.GetUnlocked(SysId.waterRank);
        //view.art_tabBtn.visible = GlobalModel.Instance.GetUnlocked(SysId.cultivateRank);
        //view.cultivate_tabBtn.visible = GlobalModel.Instance.GetUnlocked(SysId.guildLeague);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

