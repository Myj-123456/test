
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

        SetBg(viewSkin.bg, "NpcCollect/ELIDA_jiuweihuage_di01.png");

        viewSkin.title_txt.text = Lang.GetValue("npc_collet_1");
        StringUtil.SetBtnTab(viewSkin.tabBtn_1, Lang.GetValue("text_grandma10"));
        StringUtil.SetBtnTab(viewSkin.tabBtn_2, Lang.GetValue("text_grandma11"));
        StringUtil.SetBtnTab(viewSkin.tabBtn_3, Lang.GetValue("text_grandma13"));
        NpcCollectModel.Instance.InitData();
        viewSkin.spine.loop = true;
        viewSkin.spine.url = "huli";
        viewSkin.spine.animationName = "animation";
        GList list = viewSkin.list;
        list.itemRenderer = OnCellRender;
        list.SetVirtual();

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


        viewSkin.list.height = viewSkin.tabBtn_3.y - viewSkin.search_input_text.y - 67;


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
        int total = currSelect == 3 ? listData.Count : listData1.Count;
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
        StringUtil.SetBtnTab(cell.getted_btn, Lang.GetValue("invite_friends_11"));
        if (currSelect == 3)
        {
            Exchange_grandmaData data1 = listData[index];
            Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(data1.Rewards[0].EntityID);
            cell.name_txt.text = Lang.GetValue(itemData.Name);
            if (data1.Type == 1)
            {
                cell.img.url = ImageDataModel.Instance.GetFlowerStatusUrl(int.Parse(itemData.ResourceId), 2);
                cell.type.selectedIndex = 0;
            }
            else
            {
                cell.img1.url = ImageDataModel.Instance.GetVaseItemUrl(itemData.ItemDefId);
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
        else
        {
            GrandmaData data = listData1[index];
            Module_item_defConfig itemData = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
            cell.name_txt.text = Lang.GetValue(itemData.Name);
            if (data.Type == 1)
            {
                cell.img.url = ImageDataModel.Instance.GetFlowerStatusUrl(int.Parse(itemData.ResourceId), 2);
                cell.type.selectedIndex = 0;
            }
            else
            {
                cell.img1.url = ImageDataModel.Instance.GetVaseItemUrl(itemData.ItemDefId);
                cell.type.selectedIndex = 1;
            }
            int status = NpcCollectModel.Instance.CheckTaskStatus(data.Id);
            cell.status.selectedIndex = status;
            if (status == (int)NpcCollectTaskStatus.Unfinished)
            {
                //cell.task_condition_1.text = TaskModel.Instance.GetTaskDec(data.)
                
                cell.isNew.selectedIndex = data.New;
            }
            else if (status == (int)NpcCollectTaskStatus.Available)
            {
                cell.isNew.selectedIndex = data.New;
                cell.reward_btn.data = data;
                cell.reward_btn.onClick.Add(GetReward);
            }
            else if (status == (int)NpcCollectTaskStatus.Finished)
            {
                cell.isNew.selectedIndex = 0;
            }
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
        if (currSelect == 3)
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
        len = currSelect == 3 ? listData.Count : listData1.Count;
        int maxCount = (int)Mathf.Ceil((float)len / 3);
        viewSkin.list.numItems = maxCount;
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
        NpcCollectController.Instance.ReqGrandmaInfo();
        //UpdateData();
    }

    public void UpdateData()
    {
        UpdateInfo(viewSkin.search_input_text.text);
        UpdateCostItemCount();
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
}

