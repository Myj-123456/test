
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ADK;
using Elida.Config;
using DG.Tweening;

public class StorageWindow : BaseView
{
    private fun_Warehouse.wx_storage view;

    private Dictionary<int, List<StorageItemVO>> map;

    private int curTab;

    private float maxNum = 20;

    private int curPage = 0;

    private int maxPage;

    private List<StorageItemVO> listData;
    public StorageWindow()
    {
        packageName = "fun_Warehouse";
        // 设置委托
        BindAllDelegate = fun_Warehouse.fun_WarehouseBinder.BindAll;
        CreateInstanceDelegate = fun_Warehouse.wx_storage.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Warehouse.wx_storage;

        float scale = (float)Screen.height / (float)Screen.width;
        if (scale > 2.1)
        {
            view.type.selectedIndex = 1;
            view.list.lineCount = 5;
        }
        else
        {
            view.show.y = 1 + view.height - 1334 > 0 ? (view.height - 1334) / 2 : 0;
            view.type.selectedIndex = 0;
            view.list.lineCount = 4;
        }

        view.list.itemRenderer = ItemRenderer;

        StringUtil.SetBtnTab(view.btn_flower, Lang.GetValue("warehouse_02"));
        StringUtil.SetBtnTab(view.btn_flowerArt, Lang.GetValue("warehouse_04"));
        StringUtil.SetBtnTab(view.btn_item, Lang.GetValue("warehouse_03"));

        StringUtil.SetBtnTab3(view.btn_flower, Lang.GetValue("warehouse_02"));
        StringUtil.SetBtnTab3(view.btn_flowerArt, Lang.GetValue("warehouse_04"));
        StringUtil.SetBtnTab3(view.btn_item, Lang.GetValue("warehouse_03"));

        view.titleLab.text = Lang.GetValue("name_depot_1");

        SetBg(view.bg, "Storage/ELIDA_cangku_bg02.jpg");

        view.btn_flower.onClick.Add(() =>
        {
            ChangeTab(0);
        });

        view.btn_flowerArt.onClick.Add(() =>
        {
            ChangeTab(2);
        });

        view.btn_item.onClick.Add(() =>
        {
            ChangeTab(1);
        });

        //view.close_btn.onClick.Add(() =>
        //{
        //    UIManager.Instance.ClosePanel(UIName.StorageWindow);
        //});
        EventManager.Instance.AddEventListener(PlayerEvent.OpenGiftPack, UpdateData);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        if (map == null)
        {
            map = new Dictionary<int, List<StorageItemVO>>();
        }

        map.Clear();
        map.Add(4001, StorageModel.Instance.GetStorageListByType_1(4001));
        map.Add(4501, StorageModel.Instance.GetStorageListByType_1(4501));
        map.Add(4101, StorageModel.Instance.GetStorageList());

        curTab = -1;
        ChangeTab(0);
        OpenTween();
    }

    private void ChangeTab(int index)
    {
        if (curTab == index)
        {
            return;
        }
        curTab = index;
        view.status.selectedIndex = curTab;
        UpdateList();
    }
    private void UpdateData()
    {
        if(curTab == 2)
        {
            map[4101] = StorageModel.Instance.GetStorageList();
            listData = map[4101];
            view.list.numItems = listData.Count;
        }
    }
    private void UpdateList()
    {

        if (curTab == 0)
        {
            listData = map[4001];
        }
        else if (curTab == 1)
        {
            listData = map[4501];
        }
        else
        {
            listData = map[4101];
        }
        view.list.scrollPane.currentPageX = 0;
        view.list.numItems = listData.Count;
    }


    private void ItemRenderer(int index, GObject item)
    {
        fun_Warehouse.storage_item cell = item as fun_Warehouse.storage_item;
        int curIndex = index;
       
        if (curIndex > listData.Count - 1)
        {
            cell.img_loaderOld.url = "";
            UIExt_ikeImg.ClearView(cell.img_loader as common_New.ikeImg);
            cell.count_txt.text = "";
        }
        else
        {
            var storageVO = listData[curIndex];
            cell.count_txt.text = storageVO.count.ToString();
            Module_item_defConfig itemVo = ItemModel.Instance.GetItemById(storageVO.itemDefId);
            if (curTab == 1)
            {
                cell.bot.visible = false;
                cell.img_loaderOld.url = "";
                UIExt_ikeImg.LoadIkeByItemId((cell.img_loader as common_New.ikeImg), storageVO.itemDefId, true);
            }
            else
            {
                cell.bot.visible = true;
                if (curTab == 0)
                {
                    cell.img_loaderOld.height = 110f;
                    cell.img_loaderOld.width = 110f;
                    cell.img_loaderOld.y = 85f;
                }
                else
                {
                    cell.img_loaderOld.height = 110f;
                    cell.img_loaderOld.width = 110f;
                    cell.img_loaderOld.y = 80f;
                }
                UIExt_ikeImg.ClearView(cell.img_loader as common_New.ikeImg);
                
                cell.img_loaderOld.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                
            }
            cell.data = itemVo;
            cell.onClick.Add(OpenGift);
        }
        
    }
    private void OpenGift(EventContext context)
    {
        Module_item_defConfig itemVo = (context.sender as GComponent).data as Module_item_defConfig;
        if(itemVo.Type == 5201)
        {
            UIManager.Instance.OpenWindow<ItemGiftWindow>(UIName.ItemGiftWindow,itemVo.ItemDefId);
        }
        else
        {
            UILogicUtils.ShowItemGainTips(itemVo.ItemDefId);
        }
    }
    public void OpenTween()
    {
        var items = view.list._children;
        int len = items.Count > 15 ? 15 : items.Count;
        for (int i = 0; i < len; i++)
        {
            var item = items[i] as fun_Warehouse.storage_item;
            var endY = item.img_loaderOld.y;
            var startY = item.img_loaderOld.y - 40;
            item.img_loaderOld.y = startY;
            float col = Mathf.Floor(i / 3);
            float time = col * 0.1f;
            var sequence = DOTween.Sequence();

            item.img_loaderOld.alpha = 0;
            sequence.AppendInterval(time).Append(DOTween.To(() => item.img_loaderOld.alpha, x => item.img_loaderOld.alpha = x, 1, 0.3f).SetEase(Ease.OutCubic));

            sequence.Append(DOTween.To(() => item.img_loaderOld.y, x => item.img_loaderOld.y = x, endY, 0.5f).SetEase(Ease.OutSine));
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

