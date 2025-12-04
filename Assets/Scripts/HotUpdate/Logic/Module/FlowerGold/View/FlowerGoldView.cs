using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;

public class FlowerGoldView : BaseView
{
   private fun_FlowerGold.flower_gold_view view;
    private int multi = 1;
    private CountDownTimer timer;
   public FlowerGoldView()
    {
        packageName = "fun_FlowerGold";
        // 设置委托
        BindAllDelegate = fun_FlowerGold.fun_FlowerGoldBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerGold.flower_gold_view.CreateInstance;
        fairyBatching = false;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_FlowerGold.flower_gold_view;
        SetBg(view.bg, "FlowerGold/ELIDA_huaxian_bg01.jpg");
        SetBg(view.bg1, "FlowerGold/ELIDA_huaxian_bg_qjhua02.png");
        //SetBg(view.bg2, "FlowerGold/ELIDA_huaxian_bg_tengman.png");
        //SetBg(view.bg3, "FlowerGold/ELIDA_huaxian_bg_yanwu02.png");
        //SetBg(view.bg4, "FlowerGold/ELIDA_huaxian_bg_yanwu01.jpg");

        view.titleLab.text = Lang.GetValue("into_battle_3");
        var itemVo = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.fairySummonItem);
        view.sum_img.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        StringUtil.SetBtnTab(view.book_btn, Lang.GetValue("fairy_14"));
        
        AddEventListener<uint>(SystemEvent.UpdateProfile, UpdateProfile);
        AddEventListener(FlowerGoldEvent.FairyInfo, UpdateData);
        AddEventListener(FlowerGoldEvent.FairyRefresh, UpdateData);
        AddEventListener(FlowerGoldEvent.FairyDraw, UpdateRefesh);
        AddEventListener<int>(FlowerGoldEvent.FairyDrawItem, UpdateItem);

        view.spine.url = "huaxzjm";
        view.spine.loop = true;
        view.spine.animationName = "idle";

        view.book_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenPanel<FlowerGoldBookView>(UIName.FlowerGoldBookView);
        });
        view.muli_btn.onClick.Add(() =>
        {
            if(multi == 3)
            {
                multi = 1;
            }
            else
            {
                multi++;
            }
            UpdateData();
            MuliAnmi();
        });
        view.call_btn.onClick.Add(() =>
        {
            var altar = FlowerGoldModel.Instance.altar;
            var drawTime = altar.drawIndex != null ? altar.drawIndex.Length : 0;
            var costNum = 0;
            var have = 0;
            var tip = "";
            var costItem = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.fairySummonItem);
            if (drawTime == 0)
            {
                have = StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.fairySummonItem);
                costNum = GlobalModel.Instance.module_profileConfig.fairySumCost1[multi - 1];
                tip = Lang.GetValue("guildMatch_87", Lang.GetValue(costItem.Name));
            }
            else if (drawTime == 1)
            {
                have = (int)MyselfModel.Instance.diamond;
               costNum = GlobalModel.Instance.module_profileConfig.fairySumCost2[multi - 1];
                tip = Lang.GetValue("guildMatch_87", Lang.GetValue("gem"));
            }
            else
            {
                have = (int)MyselfModel.Instance.diamond;
                costNum = GlobalModel.Instance.module_profileConfig.fairySumCost3[multi - 1];
                tip = Lang.GetValue("guildMatch_87", Lang.GetValue("gem"));
            }
            if(have < costNum)
            {
                UILogicUtils.ShowNotice(tip);
                return;
            }
            FlowerGoldController.Instance.ReqFairyDraw((uint)multi, altar.refreshTime);
        });

        view.refesh_btn.onClick.Add(() =>
        {
            var altar = FlowerGoldModel.Instance.altar;
            if(altar.drawIndex == null || altar.drawIndex.Length < 1)
            {
                UILogicUtils.ShowNotice(Lang.GetValue("fairy_19"));
                return;
            }
            FlowerGoldController.Instance.ReqFairyRefresh();
        });

        view.fetters_btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<FairyFettersWindow>(UIName.FairyFettersWindow);
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        UpdateDiamond();
        FlowerGoldController.Instance.ReqFairyInfo();
    }

    private void MuliAnmi()
    {
        var altar = FlowerGoldModel.Instance.altar;
        for (int i = 0; i < altar.fairyShardIds.Length; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_FlowerGold.flower_gold_item;
            cell.ball.Play();
        }
    }
    private void UpdateItem(int index)
    {
        var cell = view.GetChild("item" + (index + 1)) as fun_FlowerGold.flower_gold_item;
        if (cell.spine.url == null || cell.spine.url == "")
        {
            cell.spine.url = "xianhuashengji";
            cell.spine.loop = false;
            cell.spine.forcePlay = true;
        }
        cell.spine.animationName = "animation";
        UpdateData();
    }

    private void UpdateRefesh()
    {
        var altar = FlowerGoldModel.Instance.altar;
        for (int i = 0; i < altar.fairyShardIds.Length; i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_FlowerGold.flower_gold_item;
            cell.fadeIn.Play(()=> {
                UpdateData();
                cell.fadeOut.Play();
            });
        }
    }

    private void UpdateData()
    {
        var altar = FlowerGoldModel.Instance.altar;
        for (int i = 0;i < altar.fairyShardIds.Length;i++)
        {
            var cell = view.GetChild("item" + (i + 1)) as fun_FlowerGold.flower_gold_item;
            var fairyInfo = FlowerGoldModel.Instance.GetFairyInfo1((int)altar.fairyShardIds[i]);
            var itemVo = ItemModel.Instance.GetItemById(fairyInfo.Id);
            //cell.quality_img.url = "Pet/pet_qulity_" + fairyInfo.Quality + ".png";
            cell.bg.url = "FlowerGold/fairy_name_bg" + fairyInfo.Quality + ".png";
            cell.rare_img.url = "HandBookNew/rare_icon_" + fairyInfo.Quality + ".png";
            cell.nameLab.text = Lang.GetValue(itemVo.Name);
            cell.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
            var count = StorageModel.Instance.GetItemCount(fairyInfo.ShardId);
            cell.haveNum.text = Lang.GetValue("fairy_16") + count + "/"+fairyInfo.ComposeNum;
            var ShardVo = ItemModel.Instance.GetItemById(fairyInfo.ShardId);
            cell.com.shard_img.url = ImageDataModel.Instance.GetIconUrl(ShardVo);
            cell.haveLab.text = Lang.GetValue("Vip_store_txt5");
            cell.com.shardNum.text = "x" + multi;
            cell.have.selectedIndex = 0;
            if (altar.drawIndex != null)
            {
                if(Array.IndexOf(altar.drawIndex,i) != -1)
                {
                    cell.have.selectedIndex = 1;
                }
            }
            cell.detail_btn.data = fairyInfo.Id;
            cell.detail_btn.onClick.Add(ClickDetail);
        }
        UpdateCost();
        UpdateTime();
        UpdateLucky();
        UpdateSummon();
    }

    private void ClickDetail(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        UIManager.Instance.OpenWindow<FairyDetailWindow>(UIName.FairyDetailWindow, id);
        
    }

    private void UpdateCost()
    {
        var altar = FlowerGoldModel.Instance.altar;
        var drawTime = altar.drawIndex != null ? altar.drawIndex.Length : 0;
        var costItem = ItemModel.Instance.GetItemById(GlobalModel.Instance.module_profileConfig.fairySummonItem);
        if (drawTime > 0)
        {
            StringUtil.SetBtnUrl(view.call_btn, ImageDataModel.CASH_ICON_URL);
        }
        else
        {
            StringUtil.SetBtnUrl(view.call_btn, ImageDataModel.Instance.GetIconUrl(costItem));
        }
        var costNum = 0;
        if (drawTime == 0)
        {
            costNum = GlobalModel.Instance.module_profileConfig.fairySumCost1[multi - 1];
        }
        else if (drawTime == 1)
        {
            costNum = GlobalModel.Instance.module_profileConfig.fairySumCost2[multi - 1];
        }
        else
        {
            costNum = GlobalModel.Instance.module_profileConfig.fairySumCost3[multi - 1];
        }
        costNum = costNum * multi;
        StringUtil.SetBtnTab(view.call_btn, costNum.ToString());
        StringUtil.SetBtnTab(view.muli_btn, Lang.GetValue("fairy_18", multi.ToString()));
    }

    public void UpdateTime()
    {
        if(timer != null)
        {
            timer.Clear();
            timer = null;
        }
        var altar = FlowerGoldModel.Instance.altar;
        int endTime = (int)altar.refreshTime - (int)ServerTime.Time + 30*60;
        timer = new CountDownTimer(view.timeLab, endTime,false,2);
        timer.prefixString = Lang.GetValue("fairy_15");
        timer.Run();
        timer.CompleteCallBacker = () =>
        {
            FlowerGoldController.Instance.ReqFairyInfo();
        };
    }

    private void UpdateLucky()
    {
        var altar = FlowerGoldModel.Instance.altar;
        var luckyInfo = FlowerGoldModel.Instance.GetFairyLuckInfo((int)altar.luckyId);
        view.pro.max = luckyInfo.LuckyNum;
        view.pro.value = altar.lucky;
        view.proLab.text = altar.lucky + "/" + luckyInfo.LuckyNum;
        view.qualiyLab.text = Lang.GetValue("fairy_17",Lang.GetValue("pet_quality_" + luckyInfo.LuckyQuality));
    }

    private void UpdateProfile(uint itemId)
    {
        if (itemId == (uint)BaseType.CASH)
        {
            UpdateDiamond();
        }
        //else if (itemId == (uint)BaseType.GOLD)
        //{
        //    UpdateGold();
        //}
        //else if (itemId == (uint)BaseType.EXP)
        //{
        //    UpdateLevelAndExp();
        //}
    }

    private void UpdateDiamond()
    {
        view.cashLab.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
    }

    private void UpdateSummon()
    {
        view.sumLab.text = TextUtil.ChangeCoinShow(StorageModel.Instance.GetItemCount(GlobalModel.Instance.module_profileConfig.fairySummonItem));
    }


    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        if (timer != null)
        {
            timer.Clear();
            timer = null;
        }
    }
}

