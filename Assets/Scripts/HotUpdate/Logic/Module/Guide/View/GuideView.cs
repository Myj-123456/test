using FairyGUI;
using UnityEngine;
using Elida.Config;
using YooAsset;
using UnityEngine.Video;

public class GuideView : BaseView
{
    private fun_Guide.GuideView viewSkin;
    private Color color1 = new Color(0, 0, 0, 0.36f);
    private Color color2 = new Color(0, 0, 0, 0);
    public GuideView()
    {
        packageName = "fun_Guide";
        // 设置委托
        BindAllDelegate = fun_Guide.fun_GuideBinder.BindAll;
        CreateInstanceDelegate = fun_Guide.GuideView.CreateInstance;
        IsShowOrHideMainUI = false;
        IsAddShowNum = false;
        fairyBatching = false;
    }
    public override void OnInit()
    {
        base.OnInit();
        viewSkin = ui as fun_Guide.GuideView;
        ADK.StringUtil.SetBtnTab(viewSkin.showImage.btn_next, "我去试试");
        AddEvent();
    }

    public override void OnShown()
    {
        base.OnShown();
        viewSkin.npcDialogue.visible = viewSkin.npcDialogue2.visible = viewSkin.showImage.visible = viewSkin.mask.visible = false;
        if (guideHand != null) guideHand.visible = false;
        if (GuideModel.Instance.curGuideStep == 16)
        {
            var guideTransform = SceneManager.Instance.GetLand(1).transform;
            viewSkin.bg.color = color2;
            SceneManager.Instance.MoveToPoint(guideTransform.position, 0, true, () =>
            {
                UpdateGuide();
            });
        }
        else
        {
            UpdateGuide();
        }

    }

    public void HideGuideUI()
    {
        viewSkin.mask.size = Vector2.zero;
        viewSkin.npcDialogue.visible = viewSkin.npcDialogue2.visible = viewSkin.showImage.visible = viewSkin.mask.visible = false;
        if (guideHand != null) guideHand.visible = false;
        viewSkin.bg.alpha = 0;
    }

    private void AddEvent()
    {
        viewSkin.npcDialogue.onClick.Add(ClickNextGuide);
        viewSkin.showImage.btn_next.onClick.Add(OnVideoClickNextGuide);
        EventManager.Instance.AddEventListener(GuideEvent.HideGuideHand, OnHandGuideHand);
        EventManager.Instance.AddEventListener(GuideEvent.HideGuideUI, HideGuideUI);
        EventManager.Instance.AddEventListener(GuideEvent.NextGuide, UpdateGuide);
    }

    private Ft_game_guideConfig curConfigData;

    private void UpdateGuide()
    {
        HideGuideUI();
        var curGuideStep = GuideModel.Instance.curGuideStep;
        curConfigData = GuideModel.Instance.GetGuideData((int)curGuideStep);
        //获取配置
        switch (curConfigData.GuideType)
        {
            case (int)GuideType.GUIDE_SPACE:
                viewSkin.mask.visible = true;
                viewSkin.mask.size = viewSkin.size;
                break;
            case (int)GuideType.NPC_DIALOGUE_Full:
                ShowNpcFullDialogue();
                break;
            case (int)GuideType.SCENE_OBJ:
                GuideSceneObj();
                break;
            case (int)GuideType.PANEL_UI:
                GuidePanelUI();
                break;
            case (int)GuideType.SHOW_VIDEO:
                ShowVideo();
                break;
        }
    }

    private void OnVideoClickNextGuide()
    {
        ClickNextGuide();
        if (GuideModel.Instance.curGuideStep == 23)
        {
            if (videoInstance != null)
            {
                GameObject.Destroy(videoInstance);
                videoInstance = null;
            }
        }
    }
    private void ClickNextGuide()
    {
        GuideController.Instance.NextGuide();
    }

    private void OnHandGuideHand()
    {
        viewSkin.mask.visible = false;
        if (guideHand != null) guideHand.visible = false;
    }

    private Vector2 tweenScale = new Vector2(1.02f, 1.02f);
    private void ShowNpcFullDialogue()
    {
        viewSkin.bg.alpha = 1;
        viewSkin.npcDialogue.state.selectedIndex = curConfigData.NpcSpineType;
        viewSkin.npcDialogue.visible = true;
        ShowNpcSpine(curConfigData.NpcSpineType == 0 ? "lu" : "huli");//读取配置
        viewSkin.npcDialogue.txt_name.text = curConfigData.NpcSpineType == 0 ? "鹿白" : "粉红小狐妖";//读取配置
        viewSkin.npcDialogue.txt_des.text = curConfigData.GuideStr;//读取配置
        viewSkin.npcDialogue.scale = new Vector2(0.8f, 0.8f);
        viewSkin.npcDialogue.TweenScale(new Vector2(1, 1), 0.3f).SetEase(EaseType.BackOut);
    }

    private void ShowNpcSpine(string aniName)
    {
        viewSkin.npcDialogue.loader_npc.loop = true;
        viewSkin.npcDialogue.loader_npc.url = aniName;
        if (aniName == "lu")
        {
            viewSkin.npcDialogue.loader_npc.animationName = "idle";
            viewSkin.npcDialogue.loader_npc.scaleX = -1;
            viewSkin.npcDialogue.loader_npc.position = new Vector3(183f, 407f, 0);
        }
        else if (aniName == "huli")
        {
            viewSkin.npcDialogue.loader_npc.animationName = "animation";
            viewSkin.npcDialogue.loader_npc.scaleX = 1;
            viewSkin.npcDialogue.loader_npc.position = new Vector3(540f, 215f, 0);
        }
    }

    //引导场景对象
    //静态会先移动过去 再开始引导对象
    private void GuideSceneObj()
    {
        SceneObject sceneObject = null;
        Transform guideTransform = null;
        if (curConfigData.IndexId == 2)//第二步改为引导扫帚动画
        {
            guideTransform = SceneManager.Instance.guide_ani_broom.transform;
        }
        else if (GuideModel.Instance.curGuideStep == 17)
        {
            sceneObject = SceneManager.Instance.GetLand(curConfigData.StructureId);
            guideTransform = sceneObject.transform;
        }
        else if (GuideModel.Instance.curGuideStep == 21)//种植浇水
        {
            var land = SceneManager.Instance.GetWaterLand();
            if (land != null)
            {
                sceneObject = land;
                guideTransform = sceneObject.transform;
                GuideModel.Instance.guideWaterLand = land;
            }
        }
        else if (GuideModel.Instance.curGuideStep == 25)//种植收获
        {
            var land = SceneManager.Instance.GetHarvestLand();
            if (land != null)
            {
                sceneObject = land;
                guideTransform = sceneObject.transform;
            }
        }
        else if (curConfigData.IndexId == 202)//引导插花
        {
            sceneObject = SceneManager.Instance.GetDecorationById(curConfigData.StructureId);
            guideTransform = sceneObject.transform;
        }
        else if (curConfigData.IndexId == 213)//引导第一个花台
        {
            sceneObject = SceneManager.Instance.GetFlowerStand((uint)curConfigData.StructureId);
            guideTransform = sceneObject.transform;
        }
        else if (curConfigData.IndexId == 252)//引导指定花艺品id的订单npc
        {
            var orderNpc = NpcManager.Instance.GetOrderNpcByFormulaId(1101);
            if (orderNpc != null)
            {
                sceneObject = orderNpc;
                guideTransform = orderNpc.GetBubbleTransform();
            }
        }
        else
        {
            sceneObject = SceneManager.Instance.GetStructure(curConfigData.StructureId);
            guideTransform = sceneObject.transform;
        }
        GuideModel.Instance.curStrongGuideSceneObject = sceneObject;
        SceneManager.Instance.MoveToPoint(guideTransform.position, 0, true, () =>
        {
            viewSkin.bg.TweenFade(1f, 0.2f);
            ShowHand(guideTransform);
        });
    }

    private void GuidePanelUI()
    {
        var target = GuideModel.Instance.guildTarget;
        if (target != null)
        {
            viewSkin.bg.TweenFade(1f, 0.2f);
            ShowHand(target);
        }
    }

    private fun_Guide.GuideHand guideHand;
    private void ShowHand(Transform transform)
    {
        if (transform == null) return;
        Vector2 pt = ADK.UILogicUtils.TransformPos(transform.position);
        viewSkin.mask.visible = true;
        var collider2d = transform.GetComponent<BoxCollider2D>();
        if (collider2d != null)
        {
            // 计算摄像机视口大小
            float cameraHeight = 2f * Camera.main.orthographicSize;
            float cameraWidth = cameraHeight * Camera.main.aspect;

            // 计算图片在摄像机视口中的宽高（世界单位）
            float imageWidthInCamera = collider2d.size.x;
            float imageHeightInCamera = collider2d.size.y;

            // 计算图片在屏幕中的像素宽高
            float imageWidthInPixels = imageWidthInCamera * (Screen.width / cameraWidth);
            float imageHeightInPixels = imageHeightInCamera * (Screen.height / cameraHeight);
            var realSize = new Vector2(imageWidthInPixels, imageHeightInPixels);
            viewSkin.mask.size = realSize * 2;
            viewSkin.mask.TweenResize(realSize, 0.2f);
        }
        else
        {
            var realSize = new Vector2(150, 150);
            viewSkin.mask.size = realSize * 2;
            viewSkin.mask.TweenResize(realSize, 0.2f);
        }

        pt += new Vector2(curConfigData.GuideOffsetX, curConfigData.GuideOffsetY);
        viewSkin.mask.position = pt;

        if (guideHand == null)
        {
            guideHand = (fun_Guide.GuideHand)fun_Guide.GuideHand.CreateInstance().asCom;
            guideHand.pivotX = 0.5f;
            guideHand.pivotY = 0.5f;
            guideHand.pivotAsAnchor = true;
            guideHand.touchable = false;
            GRoot.inst.AddChild(guideHand);
        }
        else
        {
            guideHand.visible = true;
        }
        guideHand.position = pt;
    }

    private void ShowHand(FairyGUI.GObject target)
    {
        if (target == null) return;
        viewSkin.mask.visible = true;
        var realSize = target.size;
        Debug.Log("realSize:" + realSize);
        viewSkin.mask.size = realSize * 2;
        viewSkin.mask.TweenResize(realSize, 0.2f);
        Debug.Log("position:" + target.position);
        var p = target.parent.LocalToGlobal(target.position);//转为全局坐标
        var p2 = viewSkin.GlobalToLocal(p);//再转为引导界面的本地坐标
        if (!target.pivotAsAnchor)//未勾选原点在左上角
        {
            p2.x += target.width / 2;//居中
            p2.y += target.height / 2;//居中
        }
        else//以轴心点为原点 后面再调整吧
        {

        }

        p2 += new Vector2(curConfigData.GuideOffsetX, curConfigData.GuideOffsetY);
        viewSkin.mask.position = p2;

        Debug.Log("p2:" + p2);

        if (guideHand == null)
        {
            guideHand = (fun_Guide.GuideHand)fun_Guide.GuideHand.CreateInstance().asCom;
            guideHand.pivotX = 0.5f;
            guideHand.pivotY = 0.5f;
            guideHand.pivotAsAnchor = true;
            guideHand.touchable = false;
            GRoot.inst.AddChild(guideHand);
        }
        else
        {
            guideHand.visible = true;
        }
        guideHand.position = p2;
    }

    private GameObject videoInstance;
    private void ShowVideo()
    {
        viewSkin.bg.alpha = 1;
        var url = curConfigData.GuideImage;
        viewSkin.showImage.visible = true;
        viewSkin.showImage.btn_next.visible = false;
        viewSkin.showImage.loader_title.url = $"Guide/{url}.png";
        viewSkin.showImage.loader_spine.Complete = (string aniName) =>
        {
            viewSkin.showImage.loader_spine.Complete = null;
            viewSkin.showImage.btn_next.visible = true;
        };
        viewSkin.showImage.loader_spine.forcePlay = true;
        viewSkin.showImage.loader_spine.url = "jiaoxue";
        if (url == "plant_guide_1")
        {
            viewSkin.showImage.loader_spine.animationName = "bozhong";
        }
        else if (url == "plant_guide_2")
        {
            viewSkin.showImage.loader_spine.animationName = "jiaoshui";
        }
    }

    public override void OnHide()
    {
        base.OnHide();
        if (guideHand != null) guideHand.visible = false;
    }
}
