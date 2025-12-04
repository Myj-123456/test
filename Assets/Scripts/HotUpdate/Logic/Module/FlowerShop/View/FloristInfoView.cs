using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;

public class FloristInfoView : BaseView
{
   private fun_Florist.florisr_info_view view;
    private int curIndex;
    private int tabType = 0;
    private List<StorageItemVO> storageData;

    private string[] txtColorArr = new string[] { "#209323", "#2c93e5", "#f45bfc", "#fb6eaa", "#f5b535", "#b579f5" };
    public FloristInfoView()
    {
        packageName = "fun_Florist";
        // 设置委托
        BindAllDelegate = fun_Florist.fun_FloristBinder.BindAll;
        CreateInstanceDelegate = fun_Florist.florisr_info_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Florist.florisr_info_view;
        SetBg(view.bg, "FlowerGold/ELIDA_huaxian_tcxiangqing_hxbg01.jpg");
        view.titleLab.text = Lang.GetValue("florist_25");
        view.suitLab.text = Lang.GetValue("florist_28");
        view.addLab.text = Lang.GetValue("florist_29");
        view.houseLab.text = Lang.GetValue("florist_33");

        StringUtil.SetBtnTab(view.info_btn, Lang.GetValue("florist_30"));
        StringUtil.SetBtnTab(view.house_btn, Lang.GetValue("florist_31"));

        view.florist_list.itemRenderer = RenderFloristList;
        view.florist_list.SetVirtual();

        view.nature_list.itemRenderer = RenderNatureList;

        view.house_list.itemRenderer = RenderHouseList;
        view.house_list.SetVirtual();
        view.info_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.house_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });

        view.left_btn.onClick.Add(() =>
        {
            curIndex --;
             ChangeTab(tabType);
        });
        view.right_btn.onClick.Add(() =>
        {
            curIndex ++;
            ChangeTab(tabType);
        });

        AddEventListener(FloristEvent.FloristForge, UpdateInfo);

    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        curIndex = (int)data;
        view.tab.selectedIndex = 0;
        ChangeTab(0);
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            UpdateInfo();
        }
        else
        {
            UpdateStorage();
        }
        UpdateBtnStatus();
    }

    private void UpdateBtnStatus()
    {

        view.left_btn.enabled = curIndex <= 0 ? false : true;
        view.right_btn.enabled = curIndex >= FlowerShopModel.Instance.floristSuitHome.Count - 1 ? false : true;

    }
    private void UpdateInfo()
    {
        var cell = view.floristInfo;
        var info = FlowerShopModel.Instance.floristSuitHome[curIndex];
        cell.bg.url = "Florist/ELIDA_huadian_jjgl_taozhuang01.png";
        cell.nameLab.text = Lang.GetValue(info.Name);
        cell.rare_img.url = "HandBookNew/rare_icon_" + info.Quality + ".png";
        cell.quality_img.url = "Florist/florist_quality_" + info.Quality + ".png";
        cell.collectLab.text = Lang.GetValue("florist_26", info.HavecCount + "/" + info.Furnitures.Length);
        cell.quality.selectedIndex = info.Quality;
        if (info.IsDefault == 1 && MyselfModel.Instance.level < info.ExpandLv)
        {
            cell.limit.selectedIndex = 1;
            cell.limitLab.text = Lang.GetValue("florist_27", info.ExpandLv.ToString());
        }
        else
        {
            cell.limit.selectedIndex = 0;
        }

        view.florist_list.numItems = info.Furnitures.Length;
        view.nature_list.numItems = info.RequireNums.Length;
    }

    private void RenderFloristList(int index,GObject item)
    {
        var cell = item as fun_Florist.florist_item;
        var info = FlowerShopModel.Instance.floristSuitHome[curIndex];
        var id = info.Furnitures[index];
        var furniture = FlowerShopModel.Instance.GetFurniture(id);
        var itemVo = ItemModel.Instance.GetItemById(id);
        cell.nameLab.text = Lang.GetValue(itemVo.Name);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.nameLab.color = StringUtil.HexToColor(txtColorArr[furniture.Quality - 1]);
        cell.bg.url = "MyInfo/show_flower_bg" + furniture.Quality + ".png";
        if (FlowerShopModel.Instance.GetFurnitureCount(id) > 0)
        {
            cell.status.selectedIndex = 2;
        }
        else
        {
            cell.status.selectedIndex = FlowerShopModel.Instance.IsCanCreateFlorist(id) ? 1 : 0;
        }
        cell.data = id;
        cell.onClick.Add(FloristClick);
    }



    private void FloristClick(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;

        UIManager.Instance.OpenWindow<FloristDetailWindow>(UIName.FloristDetailWindow, id);
    }

    private void RenderNatureList(int index,GObject item)
    {
        var cell = item as fun_Florist.nature_item;
        var info = FlowerShopModel.Instance.floristSuitHome[curIndex];
        var num = info.RequireNums[index];
        cell.status.selectedIndex = info.HavecCount < num ? 0 : 1;
        var attr = info.AttrsAdd[index].Split("#");
        var attrInfo = PlayerModel.Instance.GetPlayerArr(int.Parse(attr[0]));
        cell.lab.text = Lang.GetValue("florist_32", num.ToString(), Lang.GetValue(attrInfo.AttributeName) + "+" + attr[1] + (int.Parse(attr[0]) > 4 ? "%" : ""));
    }


    private void UpdateStorage()
    {
        storageData = StorageModel.Instance.GetStorageListByType_1(5902);
        view.house_list.numItems = storageData.Count;
    }

    private void RenderHouseList(int index,GObject item)
    {
        var cell = item as fun_Florist.reward_item;
        var info = storageData[index];
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(info.item);
        cell.numLab.text = info.count.ToString();
        cell.nameLab.text = Lang.GetValue(info.item.Name);
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

