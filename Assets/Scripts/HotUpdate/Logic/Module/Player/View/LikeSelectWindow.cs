using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using ADK;

public class LikeSelectWindow : BaseWindow
{
   private fun_MyInfo.like_select_view view;
    private List<string> likeData;
    private int tabType;
    private fun_MyInfo.flower_show_item curItem;
    private List<SeedCropVO> flowerData;
    private List<ArtData> vaseData;
    private UIHeroAvatar heroAvatar;
    private int curIndex = -1;
    public LikeSelectWindow()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.like_select_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_MyInfo.like_select_view;
        SetBg(view.bg, "Common/ELIDA_common_bigdi01.png");
        StringUtil.SetBtnTab(view.flower_btn, Lang.GetValue("collection_suit_name_1"));
        StringUtil.SetBtnTab(view.vase_btn, Lang.GetValue("warehouse_03"));
        StringUtil.SetBtnTab3(view.flower_btn, Lang.GetValue("collection_suit_name_1"));
        StringUtil.SetBtnTab3(view.vase_btn, Lang.GetValue("warehouse_03"));

        StringUtil.SetBtnTab(view.sure_btn, Lang.GetValue("levelup_button"));
        view.flower_list.itemRenderer = RenderFlowerList;
        view.flower_list.SetVirtual();

        view.vase_list.itemRenderer = RenderVaseList;
        view.vase_list.SetVirtual();

        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(view.spine);

        view.flower_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });
        view.vase_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
        view.sure_btn.onClick.Add(() =>
        {
            
            var str = "";
            for(var i = 0;i < likeData.Count; i++)
            {
                //if(curIndex == i)
                //{
                //    if (likeData[curIndex] != likeList[curIndex])
                //    {
                //        str += likeData[i] + (i == (likeList.Length - 1) ? "" : "#");
                //    }
                //    else
                //    {
                //        str += "0" + (i == (likeList.Length - 1) ? "" : "#");
                //    }
                //}
                //else
                //{
                //    str += likeList[i] + (i == (likeList.Length - 1)?"":"#");
                //}
                str += likeData[i] + (i == (likeData.Count - 1) ? "" : "#");
            }
            MyselfController.Instance.ReqLoveFlowerArt(str);
        });
        EventManager.Instance.AddEventListener(PlayerEvent.LoveFlowerArt, UpdateLikeData);
    }

    

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        //curIndex = (int)data;
        
        flowerData = StorageModel.Instance.GetFlowerList();
        vaseData = IkeModel.Instance.GetVaseList();
        var like = MyselfModel.Instance.GetUserInfo(UserInfoType.LIKE_SHOW);
        likeData = like == null ? new List<string> { "0", "0", "0", "0" } : like.info.Split("#").ToList();
        UpdateLike();
        heroAvatar.UpdateDress();
        
        view.tab.selectedIndex = 0;
        ChangeTab(0);
        
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        curIndex = -1;
       
        if (tabType == 0)
        {
            UpdateFlowerList();
        }
        else
        {
            UpdateVaseList();
        }
    }

    private void UpdateFlowerList()
    {
        view.flower_list.numItems = flowerData.Count;
        view.flower_list.selectedIndex = -1;
        
    }

    private void UpdateVaseList()
    {
        view.vase_list.numItems = vaseData.Count;
        view.vase_list.selectedIndex = -1;
    }

    private void UpdateLikeData()
    {
        ChangeTab(tabType);
        if (tabType == 0)
        {
            view.flower_list.numItems = flowerData.Count;
        }
        else
        {
            view.vase_list.numItems = vaseData.Count;
        }
        UpdateLike();
    }

    private void UpdateLike()
    {
       
        for (var i = 0; i < likeData.Count; i++)
        {
            var id = int.Parse(likeData[i]);
            var cell = view.GetChild("item" + (i + 1)) as fun_MyInfo.flower_show_item;
            if (id > 0)
            {
                cell.status.selectedIndex = 0;
                var itemVo = ItemModel.Instance.GetItemById(id);
                if (itemVo.Type == 4501)
                {
                    
                    cell.ike.visible = true;
                    cell.spine.visible = false;
                    UIExt_ikeImg.LoadIkeByItemId((cell.ike as common_New.ikeImg), itemVo.ItemDefId, false);
                }
                else
                {
                    
                    cell.ike.visible = false;
                    cell.spine.visible = true;
                    
                    if (cell.spine.url == "" || cell.spine.url != itemVo.ItemDefId.ToString())
                    {
                        cell.spine.url = "flowers/" + itemVo.ItemDefId;
                        cell.spine.loop = true;
                        cell.spine.forcePlay = true;
                        cell.spine.animationName = "step_3_idle";
                    }
                }
            }
            else
            {
                cell.status.selectedIndex = 1;
            }
        }
    }

    private void RenderFlowerList(int index,GObject item)
    {
        var cell = item as fun_MyInfo.like_item;
        cell.type.selectedIndex = 0;
        var info = flowerData[index];
        var itemVo = ItemModel.Instance.GetItemById(info.flowerId);
        cell.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
        cell.select.selectedIndex = likeData.IndexOf(info.flowerId.ToString()) != -1 ? 1 : 0;
        cell.data = info.flowerId;
        cell.onClick.Add(SelectClick);
    }
    private void RenderVaseList(int index, GObject item)
    {
        var cell = item as fun_MyInfo.like_item;
        cell.type.selectedIndex = 1;
        var info = vaseData[index];
        UIExt_ikeImg.LoadIkeByItemId((cell.ike as common_New.ikeImg), info.FormulaId, true);
        cell.select.selectedIndex = likeData.IndexOf(info.FormulaId.ToString()) != -1 ? 1 : 0;
        cell.data = info.FormulaId;
        cell.onClick.Add(SelectClick);
    }
    private void SelectClick(EventContext context)
    {
        var id = (int)(context.sender as GComponent).data;
        //likeData[curIndex] = id.ToString();
        var index = likeData.IndexOf(id.ToString());
        if (index != -1)
        {
            likeData[index] = "0";
            UpdateLikeData();
            return;
        }
        var nullIndex = likeData.IndexOf("0");
        if (nullIndex == -1)
        {
            UILogicUtils.ShowNotice(Lang.GetValue("player_info_17"));
            return;
        }
        likeData[nullIndex] = id.ToString();
        UpdateLikeData();
    }
    private bool IsSelected(int id)
    {
        var like = MyselfModel.Instance.GetUserInfo(UserInfoType.LIKE_SHOW);
        var likeList = like == null ? new string[] { "0", "0", "0", "0" } : like.info.Split("#");
        return Array.IndexOf(likeList, id.ToString()) != -1;
    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

