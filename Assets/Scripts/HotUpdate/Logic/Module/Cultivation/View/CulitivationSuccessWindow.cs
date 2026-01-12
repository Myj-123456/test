using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class CulitivationSuccessWindow : BaseWindow
{
   private fun_CultivateSeeds.cultivation_success_view view;
    private string[] txtColorArr = new string[] { "#f45bfc", "#2c93e5", "#209323", "#fb6eaa", "#f5b535", "#b579f5" };
    private Fx_success1Object[] listData;
    public CulitivationSuccessWindow()
    {
        packageName = "fun_CultivateSeeds";
        // 设置委托
        BindAllDelegate = fun_CultivateSeeds.fun_CultivateSeedsBinder.BindAll;
        CreateInstanceDelegate = fun_CultivateSeeds.cultivation_success_view.CreateInstance;
        ClickBlankClose = true;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_CultivateSeeds.cultivation_success_view;
        view.share.selectedIndex = 1;
        StringUtil.SetBtnTab(view.btn_back, Lang.GetValue("mail_button_return"));
        StringUtil.SetBtnTab(view.btn_plant, Lang.GetValue("cultivation_2"));
        view.shareLab.text = Lang.GetValue("text_breed36");
        //view.blankLab.text = Lang.GetValue("text_breed36");
        view.tipLab.text = Lang.GetValue("first_share_text");
        view.list.itemRenderer = RenderItem;
        view.btn_share.onClick.Add(() =>
        {
            ShareController.Instance.ReqShareFlowerReward();
            Close();
        });
        view.btn_back.onClick.Add(Close);
        view.btn_plant.onClick.Add(() =>
        {
            IkeModel.Instance.runHide = 1;
            if (GuideModel.Instance.IsGuiding)
            {
                UIManager.Instance.ClosePanel(UIName.CultivationView);
            }
            else
            {
                UIManager.Instance.CloseAllPannel(true);
            }
            Close();
            EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
            SceneManager.Instance.MoveToPantFlower(() =>
            {
                //CheckGuide11();
                if (GuideModel.Instance.IsGuiding)
                {
                    GuideController.Instance.NextGuide();
                }
            });
        });
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var flowerId = (int)data;
        var itemVo = ItemModel.Instance.GetItemById(flowerId);
        StaticSeedCondition condition = FlowerHandbookModel.Instance.staticSeedCondition[flowerId];
        var book = FlowerHandbookModel.Instance.GetBookConfigByFlowerId(flowerId);

        view.name_bg.url = "Cultivation/name_bg_" + condition.FlowerQuality.ToString() + ".png";
        view.nameLab.text = Lang.GetValue(itemVo.Name);
        view.name_bg.url = ImageDataModel.Instance.GetItemNameQuality(condition.FlowerQuality);
        view.rare_img.url = ImageDataModel.Instance.GetItemRareQuality(condition.FlowerQuality);
        view.nameLab.strokeColor = StringUtil.HexToColor(TextUtil.GetColorQuality(condition.FlowerQuality));

        view.spine.url = "flowers/" + itemVo.ItemDefId;
        view.spine.forcePlay = true;
        view.spine.loop = true;
        view.spine.animationName = "step_3_idle";

        var shareInfo = ShareModel.Instance.GetShareInfo(book.ShareId);
        listData = shareInfo.Fx_success1s;
        view.list.numItems = listData.Length;
    }
    private void RenderItem(int index,GObject item)
    {
        var cell = item as fun_CultivateSeeds.reward_item;
        var info = listData[index];
        var itemVo = ItemModel.Instance.GetItemByEntityID(info.EntityID);
        cell.bg.url = ImageDataModel.Instance.GetItemQuality(itemVo.Quality);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.numLab.text = info.Value.ToString();
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

