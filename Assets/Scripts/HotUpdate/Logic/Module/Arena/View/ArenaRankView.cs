//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class ArenaRankView : BaseView
//{
//   private fun_Arena.arena_rank_view view;
//    private Dictionary<int, UIHeroAvatar> heroAvatarMap;
//    public ArenaRankView()
//    {
//        packageName = "fun_Arena";
//        // 设置委托
//        BindAllDelegate = fun_Arena.fun_ArenaBinder.BindAll;
//        CreateInstanceDelegate = fun_Arena.arena_rank_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Arena.arena_rank_view;
//        SetBg(view.bg, "FlowerRank/ELIDA_common_paihangbang_bg.jpg");

//        view.rankList.itemRenderer = RandererListItem;
//        view.rankList.SetVirtual();

//        view.spine.loop = true;
//        view.spine.url = "shuye";
//        view.spine.animationName = "animation";

//        view.spine2.loop = true;
//        view.spine2.url = "no2";
//        view.spine2.animationName = "animation";

//        view.spine3.loop = true;
//        view.spine3.url = "no3";
//        view.spine3.animationName = "animation";

//        heroAvatarMap = new Dictionary<int, UIHeroAvatar>();

//        view.reward_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<ArenaRewardPreWindow>(UIName.ArenaRewardPreWindow);
//        });
//        view.battle_btn.onClick.Add(() =>
//        {
//            UIManager.Instance.OpenWindow<CustomerBattleWindow>(UIName.CustomerBattleWindow);
//        });
//        AddEventListener(ArenaEvent.ArenaRankInfo, UpdateData);
//        EventManager.Instance.AddEventListener(ArenaEvent.ArenaRefreshUser, UpdateData);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        ArenaController.Instance.ReqArenaRankInfo();
//    }

//    private void UpdateData()
//    {
//        view.rankList.numItems = ArenaModel.Instance.rankList.Count;
//        RenderTopListItem(0, view.rank0);
//        RenderTopListItem(1, view.rank0);
//        RenderTopListItem(2, view.rank0);
//        ShowMyRankInfo();
//    }
//    private void RandererListItem(int index,GObject item)
//    {
//        var cell = item as fun_Arena.arena_rank_item;
//        var rankInfo = ArenaModel.Instance.rankList[index];
//        cell.rankTxt.text = (index + 1).ToString();
//        (cell.head as common_New.MoonFestivalHead).pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
//        cell.txt_point.text = rankInfo.score.ToString();
//        if (rankInfo.role == 2)
//        {
//            var userInfo = ArenaModel.Instance.GetArenaRobot((int)rankInfo.targetId);
//        }
//        else
//        {
//            var userInfo = ArenaModel.Instance.GetUserInfo(rankInfo.targetId);
//            if(userInfo == null)
//            {
//                ArenaController.Instance.ReqUserInfo(index, rankInfo.targetId);
//            }
//            else
//            {
//                cell.txt_name.text = userInfo.userInfo.townName;
//            }
//        }
//    }

//    private void RenderTopListItem(int index,fun_Arena.arena_rank_top_item item)
//    {
//        item.rankStyle.selectedIndex = index;
//        var anim = view.GetChild("anim" + (index + 1)) as GLoader3D;
//        var spine = view.GetChild("spine" + (index + 1));
//        if (ArenaModel.Instance.rankList.Count < (index + 1))
//        {
//            item.txt_name.text = "";
//            //item.titleTxt.text = Lang.GetValue("guild_league_10");
//            item.txt_point.text = "0";
//            anim.visible = false;
//            spine.visible = false;
//            return;
//        }
//        var rankInfo = ArenaModel.Instance.rankList[index];


//        item.txt_point.text = rankInfo.score.ToString();
//        if (rankInfo.role == 2)
//        {
//            anim.visible = true;
//            spine.visible = true;
//            if (!heroAvatarMap.ContainsKey(index))
//            {
//                var heroAvatar = new UIHeroAvatar();

//                heroAvatar.Init(anim);
//                heroAvatarMap.Add(index, heroAvatar);
//            }
//            var dressIds = new List<uint>();
//            foreach(var value in DressModel.Instance.defaultDress)
//            {
//                dressIds.Add((uint)value.itemDefId);
//            }
//            var dressData = DressModel.Instance.GetDressData(dressIds.ToArray());
//            heroAvatarMap[index].UpdateDress(dressData);
            
//        }
//        else
//        {
//            var userInfo = ArenaModel.Instance.GetUserInfo(rankInfo.targetId);
//            if (userInfo == null)
//            {
//                ArenaController.Instance.ReqUserInfo(index, rankInfo.targetId);
//            }
//            else
//            {
//                item.txt_name.text = userInfo.userInfo.townName;
//                anim.visible = true;
//                spine.visible = true;
//                if (!heroAvatarMap.ContainsKey(index))
//                {
//                    var heroAvatar = new UIHeroAvatar();

//                    heroAvatar.Init(anim);
//                    heroAvatarMap.Add(index, heroAvatar);
//                }
//            }
//            var dressData = DressModel.Instance.GetDressData(userInfo.dress.ware);
//            heroAvatarMap[index].UpdateDress(dressData);
//        }
//    }

//    public void ShowMyRankInfo()
//    {
//        var myRank = ArenaModel.Instance.myRank;
        
//        //view.txt_name.text = MyselfModel.Instance.
//        if (myRank.rank > 0)
//        {
//            //var data = FlowerRankModel.Instance.GetRankConfigByRank((int)svrInfo.myRank.rank, currTabIndex);
//            //var itemVo = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
//            view.txt_info1.text = myRank.rank.ToString();
//            //view.txt_rankTitle.text = Lang.GetValue(itemVo.Name) + "x" + data.Rewards[0].Value;
//        }
//        else
//        {
//            view.txt_info1.text = Lang.GetValue("flower_rank9");
//            //view.txt_rankTitle.text = Lang.GetValue("flower_rank9");
//        }
//        //view.txt_info4.text = Lang.GetValue("flower_rank_2", ((int)myInfo.prevRank - (int)svrInfo.myRank.rank).ToString());
//        view.txt_point.text = myRank.score.ToString();
//        string avatar = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_AVATAR).info;
//        if (avatar == "1")
//        {
//            (view.head as common_New.MoonFestivalHead).pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
//        }
//        view.txt_name.text = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME).info;
//    }
//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

