//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class CustomerBattleWindow : BaseWindow
//{
//    private fun_Arena.arena_battle_view view;

//    public CustomerBattleWindow()
//    {
//        packageName = "fun_Arena";
//        // 设置委托
//        BindAllDelegate = fun_Arena.fun_ArenaBinder.BindAll;
//        CreateInstanceDelegate = fun_Arena.arena_battle_view.CreateInstance;
//    }

//    public override void OnInit()
//    {
//        base.OnInit();
//        view = ui as fun_Arena.arena_battle_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");

//        view.list.itemRenderer = RenderList;
//        view.list.SetVirtual();

//        AddEventListener(ArenaEvent.ArenaRankRival, UpdateList);
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        ArenaController.Instance.ReqArenaRankRival();
//    }

//    private void UpdateList()
//    {
//        view.list.numItems = ArenaModel.Instance.rivalUserInfos.Count;
//    }

//    private void RenderList(int index, GObject item)
//    {
//        var cell = item as fun_Arena.arena_rank_item;
//        var info = ArenaModel.Instance.rivalUserInfos[index];
//        (cell.head as common_New.MoonFestivalHead).pic.url = "Avatar/ELIDA_common_touxiangdi01.png";
//        //cell.txt_point.text = rankInfo.score.ToString();
//        if (info.role == 2)
//        {

//        }
//        else
//        {
//            var userInfo = info.userInfo;
//            cell.txt_name.text = userInfo.townName;
//        }
//        cell.data = index;
//        cell.onClick.Add(BattleClick);
//    }

//    private void BattleClick(EventContext context)
//    {
//        var index = (int)(context.sender as GComponent).data;
//        ArenaController.Instance.ReqArenaFight((uint)index);
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

