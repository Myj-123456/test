using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FloristDetailWindow : BaseWindow
{
   private fun_Florist.florist_detail_view view;
    private int id;
   public FloristDetailWindow()
    {
        packageName = "fun_Florist";
        // 设置委托
        BindAllDelegate = fun_Florist.fun_FloristBinder.BindAll;
        CreateInstanceDelegate = fun_Florist.florist_detail_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Florist.florist_detail_view;
        SetBg(view.bg, "Pet/ELIDA_xhshengji_hyhs_bg.png");
        SetBg(view.bg1, "Pet/ELIDA_xhshengji_hyhs_bg_guang.png");
        view.floristLab.text = Lang.GetValue("florist_1");
        view.btn.onClick.Add(() =>
        {
            var floristInfo = FlowerShopModel.Instance.GetFurniture(id);
            var count = FlowerShopModel.Instance.GetFurnitureCount(floristInfo.Id);
            if(count > 0)
            {

            }else
            {
                FlowerShopController.Instance.ReqFloristForge((ulong)id);
            }
            Close();
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        id = (int)data;
        var floristInfo = FlowerShopModel.Instance.GetFurniture(id);
        view.rare_img.url = "HandBookNew/rare_icon_" + floristInfo.Quality + ".png";
        var itemVo = ItemModel.Instance.GetItemById(floristInfo.Id);
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        view.icon.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        var count = FlowerShopModel.Instance.GetFurnitureCount(floristInfo.Id);
        view.decLab.text = Lang.GetValue(itemVo.Description);
        if (count > 0)
        {
            view.have.selectedIndex = 1;
            StringUtil.SetBtnTab(view.btn, Lang.GetValue("florist_2"));
        }
        else
        {
            view.have.selectedIndex = 0;
            view.status.selectedIndex = floristInfo.CreateCosts.Length - 1;
            for(int i = 0;i < floristInfo.CreateCosts.Length; i++)
            {
                var cost = floristInfo.CreateCosts[i];
                var cell = view.GetChild("item" + i) as fun_Florist.florist_detail_item;
                var itemVo1 = ItemModel.Instance.GetItemByEntityID(cost.EntityID);
                cell.nameLab.text = Lang.GetValue(itemVo1.Name);
                cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo1);
                var num = StorageModel.Instance.GetItemCount(cost.EntityID);
                cell.numLab.text = (num < cost.Value ? "<font color='#ff8c3f'>" : "<font color = '#FFFFFF'>") + num + "/</font>" + cost.Value;
            }
            StringUtil.SetBtnTab(view.btn, Lang.GetValue("florist_3"));
            view.btn.enabled = FlowerShopModel.Instance.IsCanCreateFlorist(floristInfo.Id);
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

