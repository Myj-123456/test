
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using ADK;
using Elida.Config;

public class NpcCollectWindow : BaseWindow
{
    private fun_NpcCollection.npc_collect_view viewSkin;

    private int itemId = 19000004;

    private int currSelect;

    private bool infoFeching;

    private List<GrandmaData> listData1;

    private List<Exchange_grandmaData> listData;
    public NpcCollectWindow()
    {
        packageName = "fun_NpcCollection";
        // 设置委托
        BindAllDelegate = fun_NpcCollection.fun_NpcCollectionBinder.BindAll;
        CreateInstanceDelegate = fun_NpcCollection.npc_collect_view.CreateInstance;
        FullScreen = true;
    }

    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_NpcCollection.npc_collect_view;

        SetBg(viewSkin.bg, "NpcCollect/ELIDA_zhengcanghuage_bg.png");

        //viewSkin.title_txt.text = Lang.GetValue("npc_collet_1");
        StringUtil.SetBtnTab(viewSkin.tabBtn_1, Lang.GetValue("text_grandma10"));
        StringUtil.SetBtnTab(viewSkin.tabBtn_2, Lang.GetValue("text_grandma11"));
        StringUtil.SetBtnTab(viewSkin.tabBtn_3, Lang.GetValue("COC_Tab_xuanshang"));
        NpcCollectModel.Instance.InitData();
        //viewSkin.spine.loop = true;
        //viewSkin.spine.url = "huli";
        //viewSkin.spine.animationName = "animation";
        GList list = viewSkin.list;
        list.itemRenderer = OnCellRender;
        list.SetVirtual();
        
        GList list2 = viewSkin.list2;
        list2.itemRenderer = OnItemRender2;
        list2.SetVirtual();

        viewSkin.tabBtn_1.onClick.Add(() =>
        {
            currSelect = 1;
            ResetFilter();
            viewSkin.tapCon.selectedIndex = currSelect - 1;
            UpdateInfo();
        });

        viewSkin.tabBtn_2.onClick.Add(() =>
        {
            currSelect = 2;
            ResetFilter();
            viewSkin.tapCon.selectedIndex = currSelect - 1;
            UpdateInfo();
        });

        viewSkin.tabBtn_3.onClick.Add(() =>
        {
            currSelect = 3;
            ResetFilter();
            viewSkin.tapCon.selectedIndex = currSelect - 1;
            UpdateInfo();
        });

        viewSkin.btn_search.onClick.Add(UpdateInfoByFilter);
        viewSkin.close_btn.onClick.Add(CloseView);


        viewSkin.list.height = viewSkin.btn_search.y - viewSkin.tabBtn_1.y - 90;
        viewSkin.list2.height = viewSkin.btn_search.y - viewSkin.tabBtn_1.y - 90;


        EventManager.Instance.AddEventListener(NpcCollectEvent.GrandmaReward, UpdateData);
        EventManager.Instance.AddEventListener(NpcCollectEvent.GrandmaExchange, UpdateData);
        EventManager.Instance.AddEventListener(NpcCollectEvent.GrandmaInfo, UpdateData);
    }

    private void UpdateInfoByFilter()
    {
        if (viewSkin.search_input_text.text != "")
        {
            UpdateInfo(viewSkin.search_input_text.text);
        }
    }

    private void OnCellRender(int index, GObject item)
    {
        var cell = item as fun_NpcCollection.npc_collect_cell;
        int total = currSelect != 3 ? listData.Count : listData1.Count;
        int max = (index + 1) * 3;
        int len = 3;
        if (max > total)
        {
            len = total % 3;
        }
        cell.list.itemRenderer = (int idx, GObject vo) =>
        {
            var curIndex = index * 3 + idx;
            OnItemRender(curIndex, vo);
        };
        cell.list.numItems = len;
    }

    private void OnItemRender(int index, GObject item)
    {
        fun_NpcCollection.npc_collect_item cell = item as fun_NpcCollection.npc_collect_item;
        cell.img.url = "";
        StringUtil.SetBtnTab(cell.reward_btn, Lang.GetValue("common_claim_button"));
        //StringUtil.SetBtnTab(cell.getted_btn, Lang.GetValue("invite_friends_11"));
        if (currSelect != 3)
        {
            Exchange_grandmaData data1 = listData[index];
            Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(data1.Rewards[0].EntityID);
            cell.name_txt.text = Lang.GetValue(itemData.Name);
            // 根据品质设置颜色
            SetQualityColor(cell.name_txt, itemData.Quality);
            if (data1.Type == 1)
            {
                cell.img.url = ImageDataModel.Instance.GetFlowerStatusUrl(int.Parse(itemData.ResourceId), 2);
                cell.type.selectedIndex = 0;
            }
            else
            {
                cell.img1.url = ImageDataModel.Instance.GetVaseItemUrl(int.Parse(itemData.ResourceId));
                cell.type.selectedIndex = 1;
            }
            StringUtil.SetBtnUrl(cell.exchange_btn, ImageDataModel.Instance.GetIconUrlByEntityId(data1.Expends[0].EntityID));
            StringUtil.SetBtnTab(cell.exchange_btn, data1.Expends[0].Value.ToString());
            if (StorageModel.Instance.GetItemById(data1.Rewards[0].EntityID) != null)
            {
                cell.status.selectedIndex = 2;
                cell.isNew.selectedIndex = 0;
            }
            else
            {
                cell.isNew.selectedIndex = data1.New;
                cell.exchange_btn.data = data1;
                cell.status.selectedIndex = 3;
                //cell.exchange_btn.onClick.Remove(this.exchangeHandle, this);
                cell.exchange_btn.onClick.Add(ExchangeHandle);
            }
        }
    }

    private void OnItemRender2(int index, GObject item)
    {
        fun_NpcCollection.npc_collect_item2 cell = item as fun_NpcCollection.npc_collect_item2;
        GrandmaData data = listData1[index];
        Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
        cell.name_txt.text = Lang.GetValue(itemData.Name);
        cell.Title.text = Lang.GetValue("COC_Tab_Task");
        cell.bg.url = "HandBookNew/collect_img_" + itemData.Quality + ".png";

        if (data.Type == 1)
        {
            cell.img.url = ImageDataModel.Instance.GetFlowerStatusUrl(int.Parse(itemData.ResourceId), 2);
            cell.type.selectedIndex = 0;
        }
        else
        {
            cell.img1.url = ImageDataModel.Instance.GetVaseItemUrl(int.Parse(itemData.ResourceId));
            cell.type.selectedIndex = 1;
        }
        var taskData = NpcCollectModel.Instance.GetTaskPro((uint)data.Id);
        int status = NpcCollectModel.Instance.CheckTaskStatus(data.Id);
        if (status == (int)NpcCollectTaskStatus.Unfinished)
        {
            cell.status.selectedIndex = 0; // 前往
        }
        else if (status == (int)NpcCollectTaskStatus.Available)
        {
            cell.status.selectedIndex = 1; // 可领取
        }
        else if (status == (int)NpcCollectTaskStatus.Finished)
        {
            cell.status.selectedIndex = 2; // 已领取
        }
        string taskDesc = TaskModel.Instance.GetTaskDec(data.TaskDesc, data.TaskType, data.TaskNum, data.TypeParam, data.Ishistory);
        cell.task_condition_1.text = taskDesc;

        int curCnt = taskData != null ? (int)taskData.curCnt : 0;
        int maxCnt = data.TaskNum > 0 ? data.TaskNum : 1;
        int displayCurCnt = Math.Min(curCnt, maxCnt);
        cell.pro.proLab.text = displayCurCnt + "/" + maxCnt;
        cell.pro.max = maxCnt;
        cell.pro.value = Math.Min(curCnt, maxCnt);

        if (status == (int)NpcCollectTaskStatus.Available)
        {
            StringUtil.SetBtnTab(cell.reward_btn,Lang.GetValue("invite_friends_10"));
            cell.reward_btn.data = data;
            cell.reward_btn.onClick.Add(GetReward);
        }
        if (status == (int)NpcCollectTaskStatus.Unfinished)
        {
            StringUtil.SetBtnTab(cell.Goto_btn, Lang.GetValue("guide_button1"));

        }
    }

    private void ExchangeHandle(EventContext context)
    {

        Exchange_grandmaData data = ((GObject)context.sender).data as Exchange_grandmaData;
        if (StorageModel.Instance.CheckEntityIDIsEnough(data.Expends[0].EntityID, data.Expends[0].Value))
        {
            var itemData = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);

            UILogicUtils.ShowConfirm((Lang.GetValue("slang_15") + Lang.GetValue(itemData.Name) + "?"), () =>
            {
                NpcCollectController.Instance.ReqGrandmaExchange((uint)data.Id);
            });


        }
        else
        {
            Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(data.Expends[0].EntityID);
            UILogicUtils.ShowNotice(Lang.GetValue(itemData.Name) + Lang.GetValue("text_grandma14"));
        }
    }

    private void GetReward(EventContext context)
    {
        Debug.Log(((GObject)context.sender).data);
        GrandmaData data = ((GObject)context.sender).data as GrandmaData;
        NpcCollectController.Instance.ReqGrandmaReward((uint)data.Id);
    }

    // 品质颜色
    private Color[] qualityColors = new Color[]
    {
        new Color(1f, 1f, 1f, 1f), // 默认颜色
        new Color(44/255f, 163/255f, 24/255f, 1f), // #2ca318 品质1
        new Color(30/255f, 152/255f, 224/255f, 1f), // #1e98e0 品质2
        new Color(181/255f, 61/255f, 217/255f, 1f), // #b53dd9 品质3
        new Color(217/255f, 51/255f, 73/255f, 1f), // #d93349 品质4
        new Color(227/255f, 123/255f, 0/255f, 1f)  // #e37b00 品质5
    };
    private void SetQualityColor(GTextField textField, int quality)
    {
        if (quality >= 1 && quality < qualityColors.Length)
        {
            textField.textFormat.color = qualityColors[quality];
        }
    }

    private void ResetFilter(string filter = "")
    {
        viewSkin.search_input_text.text = filter;
    }

    private void UpdateInfo(string filter = "")
    {
        if (infoFeching)
        {
            return;
        }
        int len;
        if (currSelect != 3)
        {
            listData = NpcCollectModel.Instance.GetItemData(currSelect);
            if (filter != "")
            {

                listData = listData.FindAll(value =>
                {
                    Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(value.Rewards[0].EntityID);
                    if (itemData != null)
                    {
                        string name = Lang.GetValue(itemData.Name);
                        if (name != null && name.Contains(filter))
                        {
                            return true;
                        }
                    }
                    return false;
                });

            }

            len = listData.Count;
        }
        else
        {
            listData1 = NpcCollectModel.Instance.GetItemData1(currSelect);
            if (filter != "")
            {

                listData1 = listData1.FindAll(value =>
                {
                    Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(value.Rewards[0].EntityID);
                    if (itemData != null)
                    {
                        string name = Lang.GetValue(itemData.Name);
                        if (name != null && name.Contains(filter))
                        {
                            return true;
                        }
                    }
                    return false;
                });
            }
        }
        len = currSelect != 3 ? listData.Count : listData1.Count;
        int maxCount = (int)Mathf.Ceil((float)len / 3);
        
        if (currSelect != 3)
        {
            viewSkin.list.visible = true;
            viewSkin.list2.visible = false;
            viewSkin.list.numItems = maxCount;
        }
        else
        {
            viewSkin.list.visible = false;
            viewSkin.list2.visible = true;
            viewSkin.list2.numItems = len;
        }
        //int index = 0;

        //index = (int)(viewSkin.tabBtn_1.data);

        //if (currSelect == 1)
        //{
        //    index = (int)viewSkin.tabBtn_1.data;
        //}
        //else if (currSelect == 2)
        //{
        //    index = (int)viewSkin.tabBtn_2.data;
        //}
        //else
        //{
        //    index = (int)viewSkin.tabBtn_3.data;
        //}

        //if (index == 1 || index == 3)
        //{

        //}

    }


    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        infoFeching = false;
        viewSkin.tapCon.selectedIndex = 0;
        currSelect = 1;
        string fliterStr = "";
        ResetFilter(fliterStr);
        
        viewSkin.list.visible = true;
        viewSkin.list2.visible = false;
        
        NpcCollectController.Instance.ReqGrandmaInfo();
        //UpdateData();
    }

    public void UpdateData()
    {
        UpdateInfo(viewSkin.search_input_text.text);
        UpdateCostItemCount();
        UpdateRedPoint();
    }

    private void UpdateCostItemCount()
    {
        viewSkin.txt_cost.text = StorageModel.Instance.GetItemCount(itemId).ToString();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }

    private void CloseView()
    {
        UIManager.Instance.CloseWindow(UIName.NpcCollectWindow);
    }

    private void UpdateRedPoint()
    {
        if (NpcCollectModel.Instance.GetRedPoint(1) || NpcCollectModel.Instance.GetRedPoint(2))
        {
            UILogicUtils.ShowRedPoint(viewSkin.tabBtn_3);
        }
        else
        {
            UILogicUtils.HideRedPoint(viewSkin.tabBtn_3);
        }
    }
}

