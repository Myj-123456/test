using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using System;
using Spine;
using System.IO;

public class NewlyGotFlowerShowWindow : BaseWindow
{
    private fun_LevelUp.newly_get_flower view;
    private Action callFun;
    private int type;
    private bool inited = false;

    public NewlyGotFlowerShowWindow()
    {
        packageName = "fun_LevelUp";
        // 设置委托
        BindAllDelegate = fun_LevelUp.fun_LevelUpBinder.BindAll;
        CreateInstanceDelegate = fun_LevelUp.newly_get_flower.CreateInstance;
        ClickBlankClose = true;
        openWithTween = false;
        fairyBatching = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_LevelUp.newly_get_flower;
        view.goBreedBtn.onClick.Add(() =>
        {
            UIManager.Instance.CloseWindow(UIName.NewlyGotFlowerShowWindow);
            if (type == 2)
            {
                if (MyselfModel.Instance.level < 6)
                {
                    UIManager.Instance.CloseAllWindown();
                    UIManager.Instance.CloseAllPannel(true);
                    SceneManager.Instance.MoveToCultivateHourse(); //移动到培育屋
                }
                if(callFun != null)
                {
                    callFun();
                }
            }
        });
        PlaySpine();

    }

    public void PlaySpine()
    {
        if (!inited)
        {
            view.spine.url = "huodexianhua";
            view.spine.Complete = OnAnimationEventHandler;
            view.spine.forcePlay = true;
            inited = true;
        }
        view.spine.loop = false;
        view.spine.animationName = "open";
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "open")
        {
            view.spine.loop = true;
            view.spine.animationName = "idle";
        }
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        
        var parma = data as object[];
        PlaySpine();
        var itemData = parma[0] as Module_item_defConfig;
        callFun = parma[1] as Action;
        view.flowerNameTxt.text = Lang.GetValue(itemData.Name);
        
        if (itemData.Type == 4402 || itemData.Type == 4401)
        {
            view.c1.selectedIndex = 1; 
            view.pic.url = ImageDataModel.Instance.GetVaseItemUrl(itemData.ItemDefId);
        }
        else
        {
            view.c1.selectedIndex = 0;
            var flowerVo = FlowerHandbookModel.Instance.GetStaticSeedCondition1(itemData.ItemDefId);
            var itemVo = ItemModel.Instance.GetItemById(flowerVo.FlowerId);
            var bookTxtInfo = FLowerModel.Instance.GetBookTxtInfo(flowerVo.FlowerId);
            view.flowerLoader.url = ImageDataModel.Instance.GetIdentifiedFlowerUrl(itemVo);
            view.flowerSayText.text = Lang.GetValue(bookTxtInfo.FlowerLanguage);

        }
        if (GuideModel.Instance.IsGuide || (MyselfModel.Instance.level >= 6 || itemData.Type == 4402 || itemData.Type == 4401))
        {
            StringUtil.SetBtnTab(view.goBreedBtn, Lang.GetValue("common_button_ok"));//确定
            type = 1;
        }
        else
        {
            StringUtil.SetBtnTab(view.goBreedBtn, Lang.GetValue("slang_18"));//去培育
            type = 2;
        }

    }

    public override void OnHide()
    {
        base.OnHide();
        //UILogicUtils.NeedShowGetFlowerVas = false;
    }
}

