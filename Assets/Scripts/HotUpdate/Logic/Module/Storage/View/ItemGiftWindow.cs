using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using ADK;

public class ItemGiftWindow : BaseWindow
{
   private fun_Warehouse.item_gift_view view;
    private Ft_gift_packConfig giftData;
    private int curNum;
    private int max;
   public ItemGiftWindow()
    {
        packageName = "fun_Warehouse";
        // 设置委托
        BindAllDelegate = fun_Warehouse.fun_WarehouseBinder.BindAll;
        CreateInstanceDelegate = fun_Warehouse.item_gift_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Warehouse.item_gift_view;
        SetBg(view.bg, "Common/ELIDA_xhshengji_hyhs_bg-zhong.png");
        StringUtil.SetBtnTab(view.min_btn, Lang.GetValue("FriendsDeal_15"));
        StringUtil.SetBtnTab(view.max_btn, Lang.GetValue("FriendsDeal_16"));
        StringUtil.SetBtnTab(view.get_btn, Lang.GetValue("guide_button2"));

        view.min_btn.onClick.Add(() =>
        {
            curNum = 1;
            UpdateStatusBtn();
        });
        view.max_btn.onClick.Add(() =>
        {
            curNum = max;
            UpdateStatusBtn();
        });
        view.odd_btn.onClick.Add(() =>
        {
            curNum--;
            UpdateStatusBtn();
        });
        view.add_btn.onClick.Add(() =>
        {
            curNum++;
            UpdateStatusBtn();
        });
        view.get_btn.onClick.Add(() =>
        {
            MyselfController.Instance.ReqOpenGiftPack((uint)giftData.GiftId,(uint)curNum);
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var id = (int)data;
        var itemVo = ItemModel.Instance.GetItemById(id);
        giftData = StorageModel.Instance.GetItemGiftInfo(id);
        view.rare_img.url = ImageDataModel.Instance.GetItemRareQuality(itemVo.Quality);
        view.txt_des.text = itemVo.Description == null ?"": Lang.GetValue(itemVo.Description);
        view.txt_name.text = Lang.GetValue(itemVo.Name);
        max = StorageModel.Instance.GetItemCount(id);
        view.txt_ownNum.text = max.ToString();
        curNum = 1;
        UpdateStatusBtn();
    }
    private void UpdateStatusBtn()
    {
        view.odd_btn.enabled = curNum > 1;
        view.add_btn.enabled = curNum < max;
        view.numLab.text = curNum.ToString();
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

