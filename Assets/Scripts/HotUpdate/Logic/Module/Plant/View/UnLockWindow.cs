using ADK;

using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// 打开解锁界面需要传递的数据
/// </summary>
public class OpenUnLockParam
{
    public int type;//0:土地解锁 1:花桌解锁
    public int id;
}

public class UnLockWindow : BaseWindow
{
    private fun_Scene.unlock_new_farmland skin;
    private int type;
    private int id;
    public UnLockWindow()
    {
        packageName = "fun_Scene";
        // 设置委托
        BindAllDelegate = fun_Scene.fun_SceneBinder.BindAll;
        CreateInstanceDelegate = fun_Scene.unlock_new_farmland.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        skin = (ui as fun_Scene.unlock_new_farmland);
        StringUtil.SetBtnTab(skin.btn_confirm, Lang.GetValue("Share_txt28"));
        SetBg(skin.bg, "Common/ELIDA_common_littledi01.png");
        skin.txt_cost.text = Lang.GetValue("slang_16");
        AddClickListener(skin.btn_confirm, btn_confirm);
    }
    public override void OnShown()
    {
        base.OnShown();
        var openUnLockParam = (OpenUnLockParam)data;
        type = openUnLockParam.type;
        id = openUnLockParam.id;
        var myGold = (int)MyselfModel.Instance.gold;
        var needIemsCount = 0;

        if (type == 0)
        {
            skin.txt_hint.text = Lang.GetValue("text_nulock_tudi");
            var tudi_configConfig = PlantModel.Instance.GetTudiConfig(id);
            if (tudi_configConfig != null)
            {
                needIemsCount = tudi_configConfig.UnlockCost;
            }
        }
        else if (type == 1)
        {
            skin.txt_hint.text = Lang.GetValue("text_nulock_hautai");
            var tabelConfig = FlowerSellModel.Instance.GetTabelConfig(id);
            if (tabelConfig != null)
            {
                needIemsCount = tabelConfig.UnlockCost;
            }
        }
        if (myGold < needIemsCount)//判断金币是否满足
        {
            skin.coin_num.text = "" + needIemsCount + "/[color=#ffa99e]" + TextUtil.ChangeCoinShow(myGold) + "[/color]";
            skin.btn_confirm.touchable = false;
            skin.btn_confirm.grayed = true;
        }
        else
        {
            skin.coin_num.text = "" + needIemsCount + "/" + TextUtil.ChangeNumberShow(myGold);
            skin.btn_confirm.touchable = true;
            skin.btn_confirm.grayed = false;
        }
    }

    private void btn_confirm()
    {
        UIManager.Instance.CloseWindow("UnLockWindow");
        if (type == 0)
        {
            PlantController.Instance.ReqUnLockLand(id);
        }
        else if (type == 1)
        {
            FlowerSellController.Instance.ReqTableUnLock((uint)id);
        }
    }

}