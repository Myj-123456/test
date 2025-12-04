using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FloristGotoWindow : BaseWindow
{
   private fun_Florist.florist_goto_view view;
    private int type;
   public FloristGotoWindow()
    {
        packageName = "fun_Florist";
        // 设置委托
        BindAllDelegate = fun_Florist.fun_FloristBinder.BindAll;
        CreateInstanceDelegate = fun_Florist.florist_goto_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Florist.florist_goto_view;
        SetBg(view.bg, "Common/ELIDA_common_littledi01.png");
        view.titleLab.text = Lang.GetValue("details_title");
        view.rewardLab.text = Lang.GetValue("Share_txt35");
        StringUtil.SetBtnTab(view.goto_btn, Lang.GetValue("florist_16"));
        view.goto_btn.onClick.Add(() =>
        {
            if(type == 1)
            {
                //UIManager.Instance.OpenPanel<PlayerInfoView>(UIName.PlayerInfoView);
            }else if(type == 2){
                
            }
            else if (type == 3)
            {
                UIManager.Instance.OpenPanel<CultivationView>(UIName.CultivationView);
            }
            else if (type == 4)
            {
                //UIManager.Instance.OpenPanel<CultivationView>(UIName.CultivationView);
            }
            else
            {
                UIManager.Instance.OpenPanel<DressView>(UIName.DressView);
            }
            UIManager.Instance.GetView(UIName.FloristView);
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var info = data as LimitData;
        type = info.type;
        if (info.type == 1)
        {
            var str = TextUtil.ChangeCoinShow(info.num) + "/" + TextUtil.ChangeCoinShow(PlayerModel.Instance.pen.drawingPower);
            view.proLab.text = Lang.GetValue("florist_17", TextUtil.ChangeCoinShow(PlayerModel.Instance.pen.drawingPower), str);
            view.nameLab.text = Lang.GetValue("power_name");
        }
        else if (info.type == 2)
        {
            
            var str = MyselfModel.Instance.level  + "/" + info.num;
            view.proLab.text = Lang.GetValue("florist_18", MyselfModel.Instance.level.ToString(), str);
            view.nameLab.text = Lang.GetValue("florist_12");
        }
        else if (info.type == 3)
        {
            
            var str = StorageModel.Instance.seedCount + "/" + info.num;
            view.proLab.text = Lang.GetValue("florist_19", StorageModel.Instance.seedCount.ToString(), str);
            view.nameLab.text = Lang.GetValue("florist_13");
        }
        else if (info.type == 4)
        {
            
            var str = IkeModel.Instance.GetVaseCount() + "/" + info.num;
            view.proLab.text = Lang.GetValue("florist_20", IkeModel.Instance.GetVaseCount().ToString(), str);
            view.nameLab.text = Lang.GetValue("florist_14");
        }
        else
        {
            var str = DressModel.Instance.GetDressCount() + "/" + info.num;
            view.proLab.text = Lang.GetValue("florist_21", DressModel.Instance.GetDressCount().ToString(), str);
            view.nameLab.text = Lang.GetValue("florist_15");
        }
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.itemId);
        view.item.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        view.item.numLab.text = info.value.ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

