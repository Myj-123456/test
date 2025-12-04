using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using Elida.Config;
using DG.Tweening;

public class GetRewardWindow : BaseWindow
{
   private fun_GetReward.getReward _view;
    private List<StorageItemVO> _items;
    private bool _considerVip;
    private bool inited = false;

    public GetRewardWindow()
    {
        packageName = "fun_GetReward";
        // 设置委托
        BindAllDelegate = fun_GetReward.fun_GetRewardBinder.BindAll;
        CreateInstanceDelegate = fun_GetReward.getReward.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        _view = ui as fun_GetReward.getReward;
        //StringUtil.SetBtnTab(_view.btn_confirm, Lang.GetValue("gui_btn_sure"));
        _view.close_btn.text = Lang.GetValue("common_tip_1");
        _view.content.list.itemRenderer = ItemRenderer;
        _view.content.list.SetVirtual();
        ClickBlankClose = true;
        fairyBatching = false;
        PlaySpine();
    }

    private void PlaySpine()
    {
        if (!inited)
        {
            _view.spine.url = "gongxihuode";
            _view.spine.Complete = OnAnimationEventHandler;
            _view.spine.forcePlay = true;
            inited = true;
        }

        _view.anim.Play();
        _view.spine.loop = false;
        _view.spine.animationName = "open";
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "open")
        {
            _view.spine.loop = true;
            _view.spine.animationName = "loop";
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        if (inited)
        {
            PlaySpine();
        }
        var param = data as object[];
        _items = param[0] as List<StorageItemVO>;
        _considerVip = (bool)param[3];
        _view.status.selectedIndex = (bool)param[4] ? 1 : 0;
        _view.content.list.numItems = _items.Count;
        _view.content.list.ScrollToView(0);
        PlayList();
        _view.anim.Play();
    }

    private void PlayList()
    {

        for(var i = 0;i < _view.content.list._children.Count;i++)
        {
            var target = _view.content.list._children[i];
            Sequence sequence = DOTween.Sequence();
            target.pivotX = 0.5f;
            target.pivotY = 0.5f;
            target.SetScale(0, 0);
            var time = 0.01f + i * 0.15f;
            sequence.AppendInterval(time);
            
            sequence.Append(DOTween.To(() => target.scale, x => target.scale = x, new Vector2(1,1), 0.2f).SetEase(Ease.OutBack));
            
            sequence.Play();
            var ui_ = target as fun_GetReward.getReward_item;
            if (ui_.spine.url == null || ui_.spine.url == "")
            {
                ui_.spine.url = "daojushanguang";
            }
            ui_.spine.loop = false;
            ui_.spine.animationName = "animation";
            //AnimationHelper.CreateSpine("daojushanguang", ui_.displayObject.gameObject.transform, "animation", true);
        }
    }

    private void ItemRenderer(int index,GObject item)
    {
        var ui_ = item as fun_GetReward.getReward_item;
        var info = _items[index];
        var itemVo = ItemModel.Instance.GetItemById(info.itemDefId);
        if(itemVo.Type == 4001)
        {
            var plant = FlowerHandbookModel.Instance.GetStaticSeedCondition(info.itemDefId);

            
            ui_.bg.url = "MyInfo/show_flower_bg" + plant.FlowerQuality + ".png";
        }
        else
        {
            ui_.bg.url = "MyInfo/show_flower_bg1.png";
        }
        ui_.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        ui_.txt_name.text = Lang.GetValue(itemVo.Name);
        if(info.itemDefId == (int)BaseType.EXP && MyselfModel.Instance.IsVip() && _considerVip)
        {
            ui_.txt_num.text = (info.count + Mathf.Floor(info.count * MyselfModel.Instance.CurrVipExp()/100)) + "";
        }
        else
        {
            ui_.txt_num.text = info.count.ToString();
        }
        
    }

    public override void OnHide()
    {
        base.OnHide();
        MyselfModel.Instance.isShowReward = false;
        // 其他关闭面板的逻辑
        var param = data as object[];
        if (param[1] != null)
        {
            var fun = param[1] as Action;
            fun();
        }
    }
}

