
//using FairyGUI;
//using System.Threading.Tasks;
//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class PreRewardWindow : BaseWindow
//{
//   private fun_Tour_Land.pre_reward_view view;
//    private string[] listData;
//    private int total;
//   public PreRewardWindow()
//    {
//        packageName = "fun_Tour_Land";
//        // 设置委托
//        BindAllDelegate = fun_Tour_Land.fun_Tour_LandBinder.BindAll;
//        CreateInstanceDelegate = fun_Tour_Land.pre_reward_view.CreateInstance;
//    }
//    public override void OnInit()
//    {
//         base.OnInit();
//        view = ui as fun_Tour_Land.pre_reward_view;
//        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
//        view.tipLab.text = Lang.GetValue("tour_reward_5");
//        view.list.itemRenderer = RenderList;
//    }

//    public override void OnShown()
//    {
//        base.OnShown();
//        // 其他打开面板的逻辑
//        var tourInfo = TourModel.Instance.GetTourFromId((int)AdventureModel.Instance.adventureTour.level);
//        listData = tourInfo.ExtraRewardPool.Split(",");
//        IniTotal(listData);
//        view.list.numItems = listData.Length;
//    }

//    private void IniTotal(string[] rewards)
//    {
//        total = 0;
//        foreach(var value in rewards)
//        {
//            var arr = value.Split(":");
//            total += int.Parse(arr[2]);
//        }
//    }


//    private void RenderList(int index,GObject item)
//    {
//        var cell = item as fun_Tour_Land.pre_reward_item;
//        var arr = listData[index].Split(":");
//        var itemVo = ItemModel.Instance.GetItemByEntityID(arr[0]);
//        cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
//        cell.nameLab.text = Lang.GetValue(itemVo.Name);
//        var rate = float.Parse(arr[2]) / (float)total * 100;
//        cell.proLab.text = rate.ToString("0.0") + "%";
//    }

//    public override void OnHide()
//    {
//        base.OnHide();
//        // 其他关闭面板的逻辑
//    }
//}

