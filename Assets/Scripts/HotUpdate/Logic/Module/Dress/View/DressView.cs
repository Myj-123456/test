using ADK;
using FairyGUI;
using Spine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 换装界面
/// </summary>
public class DressView : BaseView
{
    private fun_Dress.DressView view;
    private int filterType = 0;
    private UIHeroAvatar heroAvatar;
    private bool playing;
    private int tabType;

    private DressMainView bookView;

    private List<Dictionary<int, DressData>> dressStepList;
    public DressView()
    {
        packageName = "fun_Dress";
        // 设置委托
        BindAllDelegate = fun_Dress.fun_DressBinder.BindAll;
        CreateInstanceDelegate = fun_Dress.DressView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_Dress.DressView;
        view.titleLab.text = Lang.GetValue("adornTree_2");
        StringUtil.SetBtnTab2(view.cloth_view.btn_confirm, Lang.GetValue("gui_btn_confirm"));
        StringUtil.SetBtnTab(view.cloth_view.photo_btn, Lang.GetValue("dress_3"));
        StringUtil.SetBtnTab(view.cloth_view.back_btn, Lang.GetValue("dress_4"));
        StringUtil.SetBtnTab(view.cloth_btn, Lang.GetValue("dress_5"));
        StringUtil.SetBtnTab(view.book_btn, Lang.GetValue("dress_7"));

        StringUtil.SetBtnTab3(view.cloth_btn, Lang.GetValue("dress_5"));
        StringUtil.SetBtnTab3(view.book_btn, Lang.GetValue("dress_7"));
        dressStepList = new List<Dictionary<int, DressData>>();
        bookView = new DressMainView(view.book_view);

        AddEvent();
        SetBg(view.cloth_view.bg, "Dress/ELIDA_huanzhuang_bg.jpg");
        SetBg(view.book_view.bg, "Player/ELIDA_huibi_bg.jpg");

        view.cloth_view.list_filter.itemRenderer = FilterItemRender;
        view.cloth_view.list_filter.onClickItem.Add(OnFilterItemClick);
        view.cloth_view.list_filter.numItems = 8;

        view.cloth_view.list_part.SetVirtual();
        view.cloth_view.list_part.itemRenderer = PartItemRender;
        view.cloth_view.list_part.onClickItem.Add(OnPartItemClick);

        heroAvatar = new UIHeroAvatar();
        heroAvatar.Init(view.cloth_view.loader_heroAvatar);

        view.cloth_view.spine.url = "mao";
        view.cloth_view.spine.loop = true;
        view.cloth_view.spine.animationName = "animation1";

        view.cloth_view.last_btn.onClick.Add(() =>
        {
            if (dressStepList.Count > 1)
            {
                var curDress = dressStepList[dressStepList.Count - 1];
                foreach (var value in dressStepList[dressStepList.Count - 2]){

                    if (curDress[value.Key].clothesId != value.Value.clothesId)
                    {
                        var ft_dress_config = DressModel.Instance.GetDressConfig(value.Value.clothesId);
                        if (ft_dress_config != null)
                        {
                            heroAvatar.PlayAnimation("idle2", false, heroPlayIdeAni);
                            ChangeHeroModel(ft_dress_config.Type, value.Value.clothesId);
                        }
                    }
                }

                if (!playing)
                {
                    PlayAnim();
                }
                DressModel.Instance.UpdateClientWearDic(dressStepList[dressStepList.Count - 2]);
                dressStepList.RemoveAt(dressStepList.Count - 1);
                UpdatePartList(view.cloth_view.list_filter.selectedIndex);
            }
        });

        view.cloth_view.init_btn.onClick.Add(() =>
        {
            var curDress = dressStepList[dressStepList.Count - 1];
            var def = DressModel.Instance.GetDefaultDress();
            if (def != curDress)
            {
                foreach (var value in def)
                {

                    if (curDress[value.Key].clothesId != value.Value.clothesId)
                    {
                        var ft_dress_config = DressModel.Instance.GetDressConfig(value.Value.clothesId);
                        if (ft_dress_config != null)
                        {
                            heroAvatar.PlayAnimation("idle2", false, heroPlayIdeAni);
                            ChangeHeroModel(ft_dress_config.Type, value.Value.clothesId);
                        }
                    }
                }

                if (!playing)
                {
                    PlayAnim();
                }
                DressModel.Instance.UpdateClientWearDic(def);
                dressStepList.Add(def);
                UpdatePartList(view.cloth_view.list_filter.selectedIndex);
            }
                
        });

        view.cloth_btn.onClick.Add(() =>
        {
            if(tabType != 0)
            {
                ChangeTab(0);
            }
        });

        view.book_btn.onClick.Add(() =>
        {
            if (tabType != 1)
            {
                ChangeTab(1);
            }
        });
    }

    private void PlayAnim()
    {
        playing = true;
        view.cloth_view.spine.loop = false;
        view.cloth_view.spine.animationName = "animation2";
        view.cloth_view.spine.spineAnimation.AnimationState.Complete += OnAnimationEventHandler;

    }

    private void OnAnimationEventHandler(TrackEntry trackEntry)
    {
        if (trackEntry.Animation.Name == "animation2")
        {
            trackEntry.Complete -= OnAnimationEventHandler;
            view.cloth_view.spine.loop = true;
            view.cloth_view.spine.animationName = "animation1";
            playing = false;
        }
    }

    private void AddEvent()
    {
        view.cloth_view.btn_confirm.onClick.Add(OnComfirm);
        view.help_btn.onClick.Add(OnHelp);
        EventManager.Instance.AddEventListener(DressEvent.WearPart, OnWearPart);
        EventManager.Instance.AddEventListener(DressEvent.ChangeSceneHeroModel, ClearSuitList);
    }
    private void OnHelp()
    {
        string[] str = new string[] { Lang.GetValue("dress_title"), Lang.GetValue("dress_help") };
        UIManager.Instance.OpenWindow<HelpWindow>(UIName.HelpWindow, str);
    }

    private void ClearSuitList()
    {
        dressStepList.Clear();
        dressStepList.Add(DressModel.Instance.GetClientWearData());
    }

    private void OnComfirm()
    {
        Close();
        var wearList = DressModel.Instance.GetClientWearList();
        if (wearList.Length > 0)
        {
            DressController.Instance.ReqSaveWearList(wearList);
        }
        //var str = IPlatform.Share(view.displayObject, new Rect(0, 0, view.width, view.height),"截图");
    }

    private void OnWearPart()
    {
        dressStepList.Add(DressModel.Instance.GetClientWearData());
        UpdatePartList(filterType);
    }

    public override void OnShown()
    {
        base.OnShown();
        UpdateCurrency();
        view.tab.selectedIndex = 0;
        ChangeTab(0);
    }

    private void ChangeTab(int type)
    {
        tabType = type;
        if(tabType == 0)
        {
            UpdateCloth();
        }
        else if(tabType == 1)
        {
            bookView.OnShown();
        }
    }

    private void UpdateCloth()
    {
        
        DressModel.Instance.UpdateClientWearData();
        playing = false;
        view.cloth_view.spine.loop = true;
        view.cloth_view.spine.animationName = "animation1";
        dressStepList.Clear();
        dressStepList.Add(DressModel.Instance.GetClientWearData());
        view.cloth_view.list_filter.selectedIndex = 0;
        UpdatePartList(view.cloth_view.list_filter.selectedIndex);
        heroAvatar.UpdateDress();
        heroPlayIdeAni();
    }

    /// <summary>
    ///随机播放主角idle动画
    /// </summary>
    private void heroPlayIdeAni()
    {
        string[] aniNames = new string[3] { "idle", "idle1", "idle3" };
        var idleIndex = Random.Range(0, aniNames.Length);
        heroAvatar.PlayAnimation(aniNames[idleIndex], true);
    }

    private void UpdateCurrency()
    {
        view.txt_gold.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.gold);
        view.txt_diamond.text = TextUtil.ChangeCoinShow(MyselfModel.Instance.diamond);
    }

    private void FilterItemRender(int index, GObject item)
    {
        fun_Dress.DressFilterBtn cell = item as fun_Dress.DressFilterBtn;
        cell.img_icon.url = "Dress/PartIcon/" + index + ".png";
    }
    private void PartItemRender(int index, GObject item)
    {
        fun_Dress.DressPartItem cell = item as fun_Dress.DressPartItem;
        var data = partItemList[index];
        if (data != null)
        {
            cell.data = data;
            cell.img_icon.url = ImageDataModel.Instance.GetIconUrlByItemId(data.itemDefId);
            var dressConfig = DressModel.Instance.GetDressConfig(data.itemDefId);
            cell.img_quality.url = $"Dress/QualityIcon/ELIDA_huanzhuang_djd0{dressConfig.Quality}.png";
            var isWeared = DressModel.Instance.CheckPartIsWeared((uint)data.itemDefId);
            cell.group_weared.visible = isWeared;
        }
    }

    private void OnFilterItemClick(EventContext context)
    {
        var index = view.cloth_view.list_filter.selectedIndex;
        filterType = index;
        UpdatePartList(index);
       
    }

    private void OnPartItemClick(EventContext context)
    {
        var item = (fun_Dress.DressPartItem)context.data;
        if (item.group_weared.visible) return;
        StorageItemVO data = item.data as StorageItemVO;
        if (data != null)
        {
            var ft_dress_config = DressModel.Instance.GetDressConfig(data.itemDefId);
            if (ft_dress_config != null)
            {
                if (filterType == 0)
                {
                    
                }
                heroAvatar.PlayAnimation("idle2", false, heroPlayIdeAni);
                ChangeHeroModel(ft_dress_config.Type, data.itemDefId);
            }
            if (!playing)
            {
                PlayAnim();
            }
            DressController.Instance.ReqWearPart((uint)data.itemDefId);
        }
    }

    /// <summary>
    /// 修改主角模型
    /// </summary>
    private void ChangeHeroModel(int part, int clotheId)
    {
        //修改界面主角模型(场景层的模型等到服务器返回之后再修改)
        if (heroAvatar != null)
        {
            heroAvatar.ChangePart((DressPartType)part, clotheId);
        }
    }

    private List<StorageItemVO> partItemList;
    /// <summary>
    /// 更新部件列表
    /// </summary>
    private void UpdatePartList(int part)
    {
        partItemList = DressModel.Instance.GetPartItemList(part);
        view.cloth_view.list_part.numItems = partItemList.Count;
        view.cloth_view.txt_noDress.visible = partItemList.Count <= 0;
    }
}
