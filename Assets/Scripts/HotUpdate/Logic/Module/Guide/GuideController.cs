
using ADK;
using FairyGUI;
using protobuf.messagecode;
using protobuf.misc;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : BaseController<GuideController>
{
    private bool isInit = false;
    private bool needWaitOpenUI;//引导需要等待待打开ui界面
    private bool needWaitCloseUI;//引导需要等待相关ui关闭

    /// <summary>
    /// 初始化引导
    /// </summary>
    public void InitGuide()
    {
        if (isInit) return;
        AddEvent();
        var step = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_GUIDE);
        if (step == null)
        {
            Debug.Log("引导步骤为空，取消引导");
            GuideModel.Instance.IsNeedGuide = false;
            return;
        }
        GuideModel.Instance.SetGuideStep(uint.Parse(step.info));
        //种植为了防止卡引导，主要是针对一些协议未回包的引导做了如下兼容
        SkipGuide();
        Debug.Log("curGuideStep:" + GuideModel.Instance.curGuideStep);
        isInit = true;
    }

    private void SkipGuide()
    {
        var curConfigData = GuideModel.Instance.GetGuideData((int)GuideModel.Instance.curGuideStep);
        if (curConfigData != null)
        {
            //-1不需要继续引导了
            if (curConfigData.GuideGroup != -1 && curConfigData.GuideGroup != (int)GuideModel.Instance.curGuideStep)
            {
                if (GuideModel.Instance.curGuideStep == 13 || GuideModel.Instance.curGuideStep == 14)//如果是引导到培育加速或者培育去种植
                {
                    GuideModel.Instance.nextGuideStep = 14;//直接引导到培育收获按钮
                }
                GuideModel.Instance.curGuideStep = (uint)curConfigData.GuideGroup;
            }
        }
    }

    private void AddEvent()
    {
        EventManager.Instance.AddEventListener<bool, string>(SystemEvent.ShowHidePanel, OnShowHidePanel);
        EventManager.Instance.AddEventListener<SceneObject>(SceneEvent.SceneObjectClick, OnSceneObjectClick);
        EventManager.Instance.AddEventListener<uint>(TaskEvent.ResMainTaskReward, OnMainTaskReward);
        EventManager.Instance.AddEventListener<int>(NetEvent.TriggerNet, OnTriggerNet);
    }

    /// <summary>
    /// 场景物点击回调
    /// </summary>
    /// <param name="obj"></param>
    private void OnSceneObjectClick(SceneObject obj)
    {
        if (GuideModel.Instance.IsGuide)//强引导
        {
            var curConfigData = GuideModel.Instance.curConfigData;
            if (curConfigData.GuideType == 3 && GuideModel.Instance.curStrongGuideSceneObject == obj)
            {
                NextGuide();
            }
        }
        if (GuideModel.Instance.curGuideSceneObject != null)//弱引导
        {
            if (GuideModel.Instance.curGuideSceneObject == obj)
            {
                NextWeakGuide();
            }
            else//否则取消引导
            {
                CancelWeakGuide();
            }
        }

    }
    private void OnShowHidePanel(bool isShow, string name)
    {
        CheckMainTaskShowWeakGuide();//界面状态打开关闭都去检测一次弱引导
        PanelCheckGuide(name, isShow);
        if (isShow)
        {
            ShowPanelContinueGuide(name);
        }
    }

    private void OnTriggerNet(int messageId)
    {
        if (GuideModel.Instance.IsGuide)//强引导
        {
            if (GuideModel.Instance.curGuideStep == 12)
            {
                if (messageId == 1202)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 14)
            {
                if (messageId == 1204)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 19)//种植
            {
                if (messageId == 1206)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 23)//浇水
            {
                if (messageId == 1208)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 26)//收获
            {
                if (messageId == 1210)
                {
                    if (PlantModel.Instance.harvestPlantCount >= 4)//如果收获了4朵花会触发升级获得新花弹框，那么切换下一步
                    {
                        NextGuide();
                    }
                    else//不够升级弹出获得新花弹框，直接跳到27
                    {
                        GuideStep(27, true);
                    }
                }
            }
            if (GuideModel.Instance.curGuideStep == 104)
            {
                if (messageId == 1312)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 209)
            {
                if (messageId == 1302)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 215)
            {
                if (messageId == 1304)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 254)
            {
                if (messageId == 1302)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 257)
            {
                if (messageId == 1318)
                {
                    NextGuide();
                }
            }
            if (GuideModel.Instance.curGuideStep == 306)
            {
                if (messageId == 1214)
                {
                    NextGuide();
                }
            }
        }
    }


    /// <summary>
    /// 界面打开后继续引导
    /// </summary>
    private void ShowPanelContinueGuide(string name)
    {
        if (GuideModel.Instance.curConfigData != null && needWaitOpenUI)
        {
            if (GuideModel.Instance.curConfigData.GuideType == (int)GuideType.PANEL_UI)//如果引导是UI
            {
                if (GuideModel.Instance.curConfigData.OpenView == name)//如果是等待的界面，那么再启动引导
                {
                    Coroutiner.StartCoroutine(DelayGuide());
                }
            }
        }
    }

    /// <summary>
    /// 领取主线任务奖励后回调
    /// </summary>
    private void OnMainTaskReward(uint mainTaskId)
    {
        Debug.Log("mainTaskId:" + mainTaskId);
        if (mainTaskId == 2)//完成任务2引导小黑板订单
        {
            GuideStep(100);
        }
        else if (mainTaskId == 4)//完成任务4引导解锁土地
        {
            GuideStep(150);
        }
        else if (mainTaskId == 6)//完成任务6引导插花上架
        {
            GuideStep(200);
        }
        else if (mainTaskId == 9)//完成任务9引导npc顾客订单
        {
            var orderNpc = NpcManager.Instance.GetOrderNpcByFormulaId(1101);
            if (orderNpc != null)//这个npc存在才触发引导
            {
                GuideStep(250);
            }
        }
        else if (mainTaskId == 11)//完成任务11引导鲜花手册升级
        {
            GuideStep(300);
        }
        else if (mainTaskId == 29)//完成任务29引导加好友 
        {
            GuideStep(350);
        }
        else if (mainTaskId == 40)//完成任务40引导培育商城 
        {
            GuideStep(400);
        }
        else if (mainTaskId == 48)//完成任务48引导兑换花阁 
        {
            GuideStep(450);
        }
    }

    public void ShowGuide(bool banWeakGuide = false)
    {
        if (GuideModel.Instance.IsGuiding) return;
        //配置了skipStep=0的先在这里配置下
        var unCheckGuide = GuideModel.Instance.curGuideStep == 106 || GuideModel.Instance.curGuideStep == 152 || GuideModel.Instance.curGuideStep == 210 || GuideModel.Instance.curGuideStep == 216 || GuideModel.Instance.curGuideStep == 258 || GuideModel.Instance.curGuideStep == 307 || GuideModel.Instance.curGuideStep == 354 || GuideModel.Instance.curGuideStep == 403;//不检测
        if (unCheckGuide || GuideModel.Instance.IsGuide)
        {
            if (banWeakGuide && !GuideModel.Instance.IsStrongGuide())//禁止弱引导跳转
            {
                return;
            }
            var guideView = UIManager.Instance.GetView(UIName.GuideView);
            if (guideView != null && guideView.Visible)
            {
                guideView.OnShown();
            }
            else
            {
                UIManager.Instance.OpenPanel<GuideView>(UIName.GuideView, UILayer.Guide);
            }
            GuideModel.Instance.IsGuiding = true;
        }
    }
    /// <summary>
    /// 引导指定步骤
    /// </summary>
    /// <param name="curGuideStep"></param>
    public void GuideStep(uint curGuideStep, bool isSave = false)
    {
        Debug.Log("指定步骤引导,curGuideStep: " + curGuideStep);
        EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        GuideModel.Instance.guildTarget = null;
        GuideModel.Instance.SetGuideStep(curGuideStep);
        if (isSave)
        {
            SaveGuide(curGuideStep);
        }
        if (!GuideModel.Instance.IsGuide)
        {
            UIManager.Instance.ClosePanel(UIName.GuideView);
            GuideModel.Instance.IsGuiding = false;
            return;
        }
        Coroutiner.StartCoroutine(DelayGuide());
    }

    /// <summary>
    /// 执行下个引导
    /// </summary>
    public void NextGuide()
    {
        EventManager.Instance.DispatchEvent(GuideEvent.HideGuideUI);
        GuideModel.Instance.guildTarget = null;
        needWaitCloseUI = false;
        Coroutiner.StartCoroutine(GuidePreCheck());
    }

    /// <summary>
    /// 引导之前先检测下
    /// </summary>
    /// <returns></returns>
    private IEnumerator GuidePreCheck()
    {
        if (GuideModel.Instance.curGuideStep == 12 || GuideModel.Instance.curGuideStep == 26 || GuideModel.Instance.curGuideStep == 104 || GuideModel.Instance.curGuideStep == 209 || GuideModel.Instance.curGuideStep == 215 || GuideModel.Instance.curGuideStep == 254 || GuideModel.Instance.curGuideStep == 257 || GuideModel.Instance.curGuideStep == 306)
        {
            Debug.Log("GuidePreCheck延迟0.2");
            yield return new WaitForSeconds(0.2f);
        }
        else
        {
            yield return new WaitForSeconds(0f);
        }
        if (MyselfModel.Instance.isShowUpLevel)
        {
            Debug.Log("升级界面打开中,等待关闭之后再引导!!!");
            UIManager.Instance.ClosePanel(UIName.GuideView);
            GuideModel.Instance.IsGuiding = false;
            needWaitCloseUI = true;
            SaveGuide((uint)GuideModel.Instance.curConfigData.SkipStep);//优先保存引导步骤
            yield break;
        }
        if (MyselfModel.Instance.isShowReward)
        {
            Debug.Log("当前显示奖励弹框，等待关闭之后再引导");
            UIManager.Instance.ClosePanel(UIName.GuideView);
            GuideModel.Instance.IsGuiding = false;
            SaveGuide((uint)GuideModel.Instance.curConfigData.SkipStep);//优先保存引导步骤
            yield break;
        }
        if (GuideModel.Instance.nextGuideStep != 0)
        {
            GuideModel.Instance.curGuideStep = GuideModel.Instance.nextGuideStep;
            GuideModel.Instance.nextGuideStep = 0;
        }
        else
        {
            GuideModel.Instance.curGuideStep = (uint)GuideModel.Instance.curConfigData.SkipStep;
        }
        //配置了skipStep=0的先在这里配置下
        var unCheckGuide = GuideModel.Instance.curGuideStep == 106 || GuideModel.Instance.curGuideStep == 152 || GuideModel.Instance.curGuideStep == 210 || GuideModel.Instance.curGuideStep == 216 || GuideModel.Instance.curGuideStep == 258 || GuideModel.Instance.curGuideStep == 307 || GuideModel.Instance.curGuideStep == 354 || GuideModel.Instance.curGuideStep == 403;//不检测
        if (!unCheckGuide && !GuideModel.Instance.IsGuide)
        {
            UIManager.Instance.ClosePanel(UIName.GuideView);
            GuideModel.Instance.IsGuiding = false;
            yield break;
        }
        Coroutiner.StartCoroutine(DelayGuide());
    }

    private IEnumerator DelayGuide()
    {
        ShowGuide();//有可能之前引导已经关闭了 这时候再重启打开一次
        GuideModel.Instance.curStrongGuideSceneObject = null;
        var isGuidePlant = GuideModel.Instance.curGuideStep == 23 || GuideModel.Instance.curGuideStep == 26;//浇水和收获不需要等待检测ui
        if (!isGuidePlant && GuideModel.Instance.curConfigData.GuideType == (int)GuideType.PANEL_UI)//如果引导是UI
        {
            BasePanel view = GuideModel.Instance.curConfigData.PanelType == 1 ? UIManager.Instance.GetView(GuideModel.Instance.curConfigData.OpenView) : UIManager.Instance.GetWindow(GuideModel.Instance.curConfigData.OpenView); ;
            if (view != null && view.Visible)
            {
                needWaitOpenUI = false;
            }
            else
            {
                needWaitOpenUI = true;
                Debug.Log("需要引导的界面未打开，请等待viewName :" + GuideModel.Instance.curConfigData.OpenView);
                yield break;
            }
        }
        Debug.Log("引导 curGuideStep: " + GuideModel.Instance.curGuideStep);
        if (GuideModel.Instance.curGuideStep == 2)//第二步引导开始前显示扫帚动画
        {
            SceneManager.Instance.ShowGuideBroom();
        }
        else if (GuideModel.Instance.curGuideStep == 19)//第19步引导种植选花界面
        {
            UIManager.Instance.ShowOrHideMainUI(false, true, true);
        }
        else if (GuideModel.Instance.curGuideStep == 23)//第23步引导浇水
        {
            if (GuideModel.Instance.guideWaterLand != null)
            {
                GuideModel.Instance.guideWaterLand.PlantOneKeyWatering(GuideModel.Instance.guideWaterLand.plantVO);
                GuideModel.Instance.guideWaterLand = null;
            }
        }
        yield return new WaitForSeconds(GuideModel.Instance.curConfigData.Delay);
        if (GuideModel.Instance.curConfigData.GuideType == (int)GuideType.PANEL_UI)
        {
            if (GuideModel.Instance.curConfigData.IndexId == 23)//引导的是浇水ui
            {
                var target = SceneManager.Instance.plantWateringUI.plantOneKeyWateringUi.btn_watering;
                GuideModel.Instance.guildTarget = target;
                EventManager.Instance.DispatchEvent(GuideEvent.NextGuide);
            }
            else if (GuideModel.Instance.curConfigData.IndexId == 26)//收获ui
            {
                var target = SceneManager.Instance.harvestUI.harvestUi;
                GuideModel.Instance.guildTarget = target;
                EventManager.Instance.DispatchEvent(GuideEvent.NextGuide);
            }
            else
            {
                BasePanel view = GuideModel.Instance.curConfigData.PanelType == 1 ? UIManager.Instance.GetView(GuideModel.Instance.curConfigData.OpenView) : UIManager.Instance.GetWindow(GuideModel.Instance.curConfigData.OpenView);
                SetGuideTarget(view.ui);
            }
        }
        else
        {
            EventManager.Instance.DispatchEvent(GuideEvent.NextGuide);
        }

    }

    private void SetGuideTarget(GComponent view)
    {
        if (GuideModel.Instance.curGuideStep == 13) //步骤13是培育跳过按钮，代码写死禁止操作
        {
            return;
        }
        string[] paths = GuideModel.Instance.curConfigData.TargetPath.Split("/");
        GComponent target = view;
        foreach (var path in paths)
        {
            target = target == null ? null : target.GetChild(path) as GComponent;
        }
        if (target == null || !target.visible)
        {
            Debug.Log("SetGuideTarget=>target为空 禁止引导");
            NextGuide();
            return;
        }
        if (GuideModel.Instance.curConfigData.Index > -1)
        {
            target = target._children[GuideModel.Instance.curConfigData.Index] as GComponent;
        }
        GuideModel.Instance.guildTarget = target;
        if (GuideModel.Instance.curConfigData.IndexId != 16)//16去种植不在这里处理
        {
            if (GuideModel.Instance.curConfigData.GuideObject != "-1")
            {
                GuideModel.Instance.guildTarget = target.GetChild(GuideModel.Instance.curConfigData.GuideObject) as GObject;
                GuideModel.Instance.guildTarget.onClick.Add(GuideClick);
            }
            else
            {
                target.onClick.Add(GuideClick);
            }
        }
        EventManager.Instance.DispatchEvent(GuideEvent.NextGuide);
    }

    private void GuideClick(EventContext context)
    {
        (context.sender as GObject).RemoveEventListener("onClick", GuideClick);
        if (!GuideModel.Instance.IsGuiding)
        {
            return;
        }
        if (GuideModel.Instance.curGuideStep == 12 || GuideModel.Instance.curGuideStep == 14 || GuideModel.Instance.curGuideStep == 104 || GuideModel.Instance.curGuideStep == 209 || GuideModel.Instance.curGuideStep == 215 || GuideModel.Instance.curGuideStep == 254 || GuideModel.Instance.curGuideStep == 257 || GuideModel.Instance.curGuideStep == 306)
        {
            return;
        }
        NextGuide();
    }

    private void PanelCheckGuide(string uiName, bool isShow)
    {
        if (!GuideModel.Instance.IsGuide)
        {
            return;
        }

        var curConfigData = GuideModel.Instance.curConfigData;
        if (GuideModel.Instance.curGuideStep == 252 && curConfigData.GuideType == 3 && isShow)
        {
            NextGuide();
        }
        if (!isShow && needWaitCloseUI)
        {
            if (UILogicUtils.NeedShowGetFlowerVas)
            {
                if (uiName == "NewlyGotFlowerShowWindow")
                {
                    NextGuide();
                }
            }
            else
            {
                if (uiName == "GetRewardWindow")
                {
                    NextGuide();
                }
            }
        }
        //TODO:主要目前为了兼容主线任务领取奖励后的引导流程触发 后面删掉不要用这种 使用needWaitCloseUI统一就行
        if (!MyselfModel.Instance.isShowUpLevel && !needWaitCloseUI && curConfigData.GuideType == 0 && !isShow)
        {
            Debug.Log("NeedShowGetFlowerVas：" + UILogicUtils.NeedShowGetFlowerVas + " curConfigData.OpenView：" + curConfigData.OpenView);
            if (UILogicUtils.NeedShowGetFlowerVas)//需要等待花/花瓶弹窗关闭才能继续引导下一步
            {
                if (uiName == "NewlyGotFlowerShowWindow")
                {
                    NextGuide();
                }
            }
            else
            {
                if (curConfigData.OpenView == uiName)//界面一致才继续引导下一步
                {
                    NextGuide();
                }
            }
        }
    }


    public void SaveGuide(uint guideStep, bool lastStep = false)
    {
        if (lastStep)//最后一步直接保存
        {
            ReqSaveGuide(guideStep);
        }
        else
        {
            if (!GuideModel.Instance.IsGuide) return;
            ReqSaveGuide(guideStep);
        }
    }

    private void ReqSaveGuide(uint guideStep)
    {
        C_MSG_GUIDE c_MSG_GUIDE = new C_MSG_GUIDE();
        c_MSG_GUIDE.step = guideStep.ToString();
        SendCmd((int)MessageCode.C_MSG_GUIDE, c_MSG_GUIDE);
        Debug.Log("SaveGuide step:" + guideStep);
    }

    /// <summary>
    /// 执行弱引导组
    /// </summary>
    public void ExecuteWeakGuideGroup()
    {
        GuideModel.Instance.curGuideSceneObject = null;
        GuideModel.Instance.curGuideUI = null;
        var weakGuideGroupConfig = GuideModel.Instance.weakGuideGroupConfig;
        if (weakGuideGroupConfig != null && weakGuideGroupConfig.weakGuideStepConfigs.Count > 0)
        {
            if (weakGuideCoroutine != null)
            {
                ADK.Coroutiner.StopCoroutine(weakGuideCoroutine);
                weakGuideCoroutine = null;
            }
            Debug.Log("curWeakGuideStep:" + GuideModel.Instance.curWeakGuideStep);
            if (GuideModel.Instance.curWeakGuideStep == 0)//每个引导组第一个引导步骤设置IsCancelGuide = false;
            {
                GuideModel.Instance.IsCancelGuide = false;
            }
            Coroutiner.StartCoroutine(ExecuteWeakGuideStep(weakGuideGroupConfig.weakGuideStepConfigs[GuideModel.Instance.curWeakGuideStep]));
        }
        else
        {
            Debug.Log("没有弱引导步骤 不执行!!!");
            CancelWeakGuide();
        }
    }

    /// <summary>
    /// 执行一个弱引导步骤
    /// </summary>
    /// <param name="weakGuideStepConfig"></param>
    private IEnumerator ExecuteWeakGuideStep(WeakGuideStepConfig weakGuideStepConfig)
    {
        if (GuideModel.Instance.IsCancelGuide)
        {
            Debug.Log("引导取消不执行...");
            yield break;
        }
        yield return new WaitForSeconds(weakGuideStepConfig.Delay);

        if (weakGuideStepConfig.GuideType == 1)//引导界面UI
        {
            GuideViewUI(weakGuideStepConfig);
        }
        else if (weakGuideStepConfig.GuideType == 2)//引导场景对象
        {
            GuideSceneObject(weakGuideStepConfig);
        }
    }

    /// <summary>
    /// 引导界面ui
    /// </summary>
    /// <param name="weakGuideStepConfig"></param>
    private void GuideViewUI(WeakGuideStepConfig weakGuideStepConfig)
    {
        var viewName = weakGuideStepConfig.Param;
        BasePanel view = UIManager.Instance.GetView(viewName);
        if (view == null)//view获不到,再获取window
        {
            view = UIManager.Instance.GetWindow(viewName);
        }
        if (view == null)
        {
            Debug.Log("引导界面不存在，未打开");
            return;
        }
        var index = -1;
        GComponent target = view.ui;
        var targetPathParam = weakGuideStepConfig.TargetPath.Split("#");
        string[] paths = targetPathParam[0].Split("/");
        foreach (var path in paths)
        {
            target = target == null ? null : target.GetChild(path) as GComponent;
        }
        if (target == null || !target.visible)
        {
            Debug.Log("引导对象控件目标不存在，跳过...");
            return;
        }
        if (targetPathParam.Length == 2)//有index
        {
            index = int.Parse(targetPathParam[1]);
        }
        if (index > -1)//列表下标对象
        {
            var count = target._children.Count;
            if (count > 0 && index < count)
            {
                target = target._children[index] as GComponent;
            }
            else
            {
                target = null;
                Debug.Log("列表下标对象不存在");
            }
        }
        if (target == null || !target.visible)
        {
            Debug.Log("引导List item对象不存在，跳过...");
            return;
        }
        ShowTargetWeakGuide(target, Vector2.zero);
    }

    /// <summary>
    /// 引导场景对象
    /// </summary>
    /// <param name="weakGuideStepConfig"></param>
    private void GuideSceneObject(WeakGuideStepConfig weakGuideStepConfig)
    {
        SceneObject sceneObject = null;
        if (weakGuideStepConfig.SceneObjType == 1)//花台
        {
            var id = int.Parse(weakGuideStepConfig.Param);
            sceneObject = SceneManager.Instance.GetFlowerStand((uint)id);
        }
        else if (weakGuideStepConfig.SceneObjType == 2)//建筑物
        {
            var id = int.Parse(weakGuideStepConfig.Param);
            sceneObject = SceneManager.Instance.GetStructure(id);
        }
        else if (weakGuideStepConfig.SceneObjType == 3)//家具
        {
            sceneObject = SceneManager.Instance.GetDecoration(Enum.Parse<DecorationsType>(weakGuideStepConfig.Param));
        }
        else if (weakGuideStepConfig.SceneObjType == 4)//种植地块
        {
            var id = int.Parse(weakGuideStepConfig.Param);
            sceneObject = SceneManager.Instance.GetLand(id);
        }
        else if (weakGuideStepConfig.SceneObjType == 5)//npc
        {
            var id = int.Parse(weakGuideStepConfig.Param);
            sceneObject = NpcManager.Instance.GetOrderNpc((uint)id);
        }
        else if (weakGuideStepConfig.SceneObjType == 6)//场景水桶
        {
            var id = int.Parse(weakGuideStepConfig.Param);
            sceneObject = BucketManager.Instance.GetBucketByIndex((int)id);
        }
        if (sceneObject != null)
        {
            ShowTargetWeakGuide(sceneObject, weakGuideStepConfig.PosOffset);
        }
    }


    /// <summary>
    /// 切换下个弱引导
    /// </summary>
    public void NextWeakGuide()
    {
        var curWeakGuideLen = GuideModel.Instance.GetCurWeakGuideGroupCount();
        if (GuideModel.Instance.curWeakGuideStep < curWeakGuideLen - 1)
        {
            Debug.Log("切换下个弱引导");
            GuideModel.Instance.curWeakGuideStep += 1;
            ExecuteWeakGuideGroup();
        }
        else
        {
            Debug.Log("当前引导组引导结束");
        }
    }

    private common_New.GuideHand guideHand;
    /// <summary>
    /// 显示弱引导手指引导(FairyGUI对象专用)
    /// </summary>
    /// <param name="target"></param>
    public void ShowTargetWeakGuide(FairyGUI.GObject target, Vector2 offsetPos)
    {
        if (target == null) return;
        GuideModel.Instance.IsWeakGuiding = true;
        GuideModel.Instance.curGuideUI = target;
        var p = target.parent.container.LocalToGlobal(target.position);//转为全局坐标
        var p2 = GRoot.inst.GlobalToLocal(p);//再转为引导界面的本地坐标
        if (!target.pivotAsAnchor)//未勾选原点在左上角
        {
            p2.x += target.width / 2;//居中
            p2.y += target.height / 2;//居中
        }
        else//以轴心点为原点 后面再调整吧
        {

        }
        p2 += offsetPos;
        ShowGuideHand();
        guideHand.position = p2;
    }

    /// <summary>
    /// 显示弱引导手指引导(场景对象专用)
    /// </summary>
    /// <param name="transform"></param>
    public void ShowTargetWeakGuide(SceneObject sceneObject, Vector2 offsetPos)
    {
        if (sceneObject == null) return;
        GuideModel.Instance.IsWeakGuiding = true;
        GuideModel.Instance.curGuideSceneObject = sceneObject;
        var transform = sceneObject.transform;
        if (sceneObject is OrderNpc)
        {
            var pos = (sceneObject as OrderNpc).GetBubblePos();
            //镜头移动过去再引导
            SceneManager.Instance.MoveToPoint(pos, 0, true, () =>
            {
                Vector2 pt = UILogicUtils.TransformPos(pos);
                pt += offsetPos;
                ShowGuideHand();
                guideHand.position = pt;
            });
        }
        else
        {
            //镜头移动过去再引导
            SceneManager.Instance.MoveToPoint(transform.position, 0, true, () =>
            {
                Vector2 pt = UILogicUtils.TransformPos(transform.position);
                pt += offsetPos;
                ShowGuideHand();
                guideHand.position = pt;
            });
        }

    }

    private void ShowGuideHand()
    {
        if (guideHand == null)
        {
            guideHand = (common_New.GuideHand)common_New.GuideHand.CreateInstance().asCom;
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
    }

    public void HideTargetWeakGuide()
    {
        if (guideHand != null && guideHand.visible)
        {
            guideHand.visible = false;
            GuideModel.Instance.IsWeakGuiding = false;
        }
    }

    /// <summary>
    /// 取消弱引导
    /// </summary>
    public void CancelWeakGuide()
    {
        var guideModel = GuideModel.Instance;
        if (guideModel.IsWeakGuiding)
        {
            Debug.Log("取消弱引导");
            HideTargetWeakGuide();
            guideModel.curGuideSceneObject = null;
            guideModel.curGuideUI = null;
            guideModel.IsCancelGuide = true;
            Debug.Log("IsCancelGuide:" + GuideModel.Instance.IsCancelGuide);
        }
    }


    private Coroutine weakGuideCoroutine;

    /// <summary>
    /// 检测主线任务是否显示弱引导
    /// </summary>
    public void CheckMainTaskShowWeakGuide()
    {
        // 停止之前的协程
        if (weakGuideCoroutine != null)
        {
            ADK.Coroutiner.StopCoroutine(weakGuideCoroutine);
            weakGuideCoroutine = null;
        }
        if (GuideModel.Instance.IsGuide || GuideModel.Instance.IsWeakGuiding || UIManager.Instance.HasPanelShow || UIManager.Instance.HasWindowShow)//有界面打开
        {
            HideTargetWeakGuide();
            return;
        }
        weakGuideCoroutine = ADK.Coroutiner.StartCoroutine(StartTaskWeakGuide());
    }
    /// <summary>
    /// 5s去检测下是否需要显示主任务弱引导
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartTaskWeakGuide()
    {
        yield return new WaitForSeconds(5f);
        if (UIManager.Instance.HasPanelShow || UIManager.Instance.HasWindowShow)//有界面打开 不显示 
        {
            HideTargetWeakGuide();
            weakGuideCoroutine = null;
            yield break;
        }
        var mainView = UIManager.Instance.GetView(UIName.MainView);
        if (mainView != null && mainView.Visible)
        {
            GComponent target = (GComponent)mainView.ui.GetChild("task_btn");
            if (target == null || !target.visible)
            {
                Debug.Log("引导对象控件目标不存在，跳过...");
                HideTargetWeakGuide();
                weakGuideCoroutine = null;
                yield break;
            }
            ShowTargetWeakGuide(target, Vector2.zero);
        }
        weakGuideCoroutine = null;
    }

}
