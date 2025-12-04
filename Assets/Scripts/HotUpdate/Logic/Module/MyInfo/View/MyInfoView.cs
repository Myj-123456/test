
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using YooAsset;
using DG.Tweening;

public class MyInfoView : BaseView
{
    private fun_MyInfo.MyInfoView view;

    private List<SeedCropVO> listData;

    private List<Vector3> paths = new List<Vector3>();

    private List<GGraph> graphs = new List<GGraph>();

    private GGraph graph;
    private float time = 0;
    public MyInfoView()
    {
        packageName = "fun_MyInfo";
        // 设置委托
        BindAllDelegate = fun_MyInfo.fun_MyInfoBinder.BindAll;
        CreateInstanceDelegate = fun_MyInfo.MyInfoView.CreateInstance;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_MyInfo.MyInfoView;
        StringUtil.SetBtnTab(view.settingBtn, Lang.GetValue("setting_txt1"));
        StringUtil.SetBtnTab(view.drawBtn, Lang.GetValue("adornTree_2"));
        StringUtil.SetBtnTab(view.storeEarningBtn, Lang.GetValue("storeEarningTitle"));
        view.flowerNum.decLab.text = Lang.GetValue("my_info_1");
        view.flowerLv.decLab.text = Lang.GetValue("my_info_2");
        view.group.decLab.text = Lang.GetValue("my_info_3");
        if (view.posIMg.y > 1049)
        {
            view.posIMg.y = view.posIMg.y + (view.posIMg.y - 1049f) * 0.17f;
        }
        SetBg(view.bg, "MyInfo/ELIDA_gerenxinxi_bg_02.jpg");

        view.vip.visible = MyselfModel.Instance.IsVip();

        view.showTitle.text = Lang.GetValue("my_info_4");
        StringUtil.SetBtnTab(view.readBtn, Lang.GetValue("my_info_5"));
        StringUtil.SetBtnTab(view.changeBtn, Lang.GetValue("my_info_6"));
        StringUtil.SetBtnTab(view.noticeBtn, Lang.GetValue("announcement"));

        view.list.itemRenderer = RanderList;

        view.noticeBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<GameNoticeWindow>(UIName.GameNoticeWindow);
        });

        view.copyBtn.onClick.Add(() =>
        {
            UnityEngine.GUIUtility.systemCopyBuffer = MyselfModel.Instance.userId.ToString();
            UILogicUtils.ShowNotice(Lang.GetValue("common_hint_copysuccess"));
        });

        view.storeEarningBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<StoreEarningWindow>(UIName.StoreEarningWindow);
        });

        view.settingBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<UserInfoWindow>(UIName.UserInfoWindow);
        });

        view.drawBtn.onClick.Add(() =>
        {
            if (!GlobalModel.Instance.GetUnlocked(SysId.Dress, true))
            {
                return;
            }
            UIManager.Instance.OpenPanel<DressView>(UIName.DressView,UILayer.SecondUI);
        });

        view.readBtn.onClick.Add(() =>
        {
            //UIManager.Instance.OpenPanel<DressCallView>(UIName.DressCallView);
            UIManager.Instance.OpenWindow<PlayerInfoView>(UIName.PlayerInfoView);
            //UILogicUtils.ShowNotice(Lang.GetValue("guildStore_lock_tip"));
            //UIManager.Instance.OpenPanel<TourMapView>(UIName.TourMapView);
            //ScientificPlantingContorller.Instance.ReqCultivationResearchReward();
            //UIManager.Instance.OpenWindow<ScientificPlantingWindow>(UIName.ScientificPlantingWindow);

        });

        view.changeBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<PlotMainWindow>(UIName.PlotMainWindow);
            //UIManager.Instance.OpenWindow<DecryptBridgeWindow>(UIName.DecryptBridgeWindow);
            //UIManager.Instance.OpenWindow<FlowerStarWindow>(UIName.FlowerStarWindow);
            //UILogicUtils.ShowNotice(Lang.GetValue("guildStore_lock_tip"));
            //UIManager.Instance.OpenPanel<ShopMainView>(UIName.ShopMainView,UILayer.UI,0);
        });

        view.editBtn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<ChangeNameWindow>(UIName.ChangeNameWindow);
        });
        view.btn.onClick.Add(() =>
        {
            UIManager.Instance.OpenWindow<DecryptAltarWindow>(UIName.DecryptAltarWindow);
            AssetHandle assetHandle = ResourceManager.Instance.LoadAssetAsync<Texture2D>("Assets/ResAB/DynamicUI/HandBook/bg_0.png");
            assetHandle.Completed += (AssetHandle handle) =>
            {
                //Shape shape = view.pie.asGraph.shape;
                //EllipseMesh ellipse = shape.graphics.GetMeshFactory<EllipseMesh>();

                //var texture = new NTexture(assetHandle.AssetObject as Texture2D);
                ////// 计算中心锚点矩形
                ////Rect contentRect = new Rect(
                ////    0,
                ////    0,
                ////    texture.width,
                ////    texture.height
                ////);

                ////shape.graphics.contentRect = contentRect;
                //ellipse.startDegree = 0;
                //ellipse.endDegreee = 360;
                //shape.graphics.SetMeshDirty();
                //shape.graphics.texture = texture;
            };
        });
        EventManager.Instance.AddEventListener(SystemEvent.UpdateTownName, UpdateName);

        //view.onTouchBegin.Add((EventContext context) =>
        // {
        //     context.CaptureTouch();
        //     var grap = new GGraph();
        //     grap.SetSize(GRoot.inst.width, GRoot.inst.height - 300);
        //     view.AddChild(grap);
        //     grap.SetPosition(0, 0, 0);
        //     graphs.Add(grap);

        //     graph = grap;
        //     paths.Add(view.GlobalToLocal(new Vector3(context.inputEvent.x, context.inputEvent.y, 0)));
        // });
        //view.onTouchMove.Add((EventContext context) =>
        //{
        //    paths.Add(view.GlobalToLocal(new Vector3(context.inputEvent.x, context.inputEvent.y, 0)));
        //     DragLine(graph, paths);
        //});
        //view.onTouchEnd.Add((EventContext context) =>
        //{
        //    LineMesh line = graph.asGraph.shape.graphics.GetMeshFactory<LineMesh>();
        //    line.path.Clear();
        //    paths.Clear();
        //    graph.asGraph.shape.graphics.SetMeshDirty();
        //});
        //var sequence = DOTween.Sequence();
        //sequence.Append(DOTween.To(() => view.head.rotationY, x => view.head.rotationY = x, 360f, 2f))
        //    .Append(DOTween.To(() => view.head.rotationY, x => view.head.rotationY = x, 0f, 0f)).SetLoops(-1, LoopType.Restart).Play();
    }

    private void UpdateFrame()
    {
        //Debug.Log("每帧更新：" + Time.time);
        //Debug.Log("每帧更新时间：" + Time.deltaTime);
        //time += Time.deltaTime;
        //time = time > 1 ? 1 : time;
        //view.readBtn.position = Vector2.Lerp(new Vector2(180,1075), new Vector2(29,383), time);
    }

    public override void OnShown()
    {
        base.OnShown();
        time = 0;
        //Stage.inst.onUpdate += UpdateFrame;
        // 其他打开面板的逻辑
        InitMyInfo();
        UpdateList();
    }

    private void UpdateList()
    {
        view.list.numItems = 8;
    }

    private void RanderList(int index, GObject item)
    {
        var cell = item as fun_MyInfo.showInfoItem;
    }

    private void UpdateName()
    {
        var name = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_NICKNAME);
        view.nameLab.text = name != null ? name.info : "";
    }

    private void InitMyInfo()
    {
        UpdateName();
        var headFrame = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_HEAD_FRAME);
        if (headFrame != null)
        {
            var item = ItemModel.Instance.GetItemById(int.Parse(headFrame.info));
            if (item != null)
            {
                UILogicUtils.ShowHeadFrames(view.frame as common_New.PictureFrame, item);
                view.poslab.text = Lang.GetValue(item.Name);
            }
            else
            {
                UILogicUtils.RemoveHeadFrames(view.frame as common_New.PictureFrame);
                view.poslab.text = Lang.GetValue("flower_rank9");
            }

        }
        else
        {
            view.poslab.text = Lang.GetValue("flower_rank9");
            StringUtil.SetBtnUrl(view.head, "Avatar/ELIDA_common_touxiangdi01.png");
        }
        view.idLab.text = "ID:" + MyselfModel.Instance.userId;
        view.lvLab.text = "LV." + MyselfModel.Instance.level;
        view.flowerNum.num.text = StorageModel.Instance.seedList.Count.ToString();
        view.flowerLv.num.text = StorageModel.Instance.GetSeedTotalCount().ToString();
        view.group.num.text = "0";
        view.guildLab.text = Lang.GetValue("my_info_7") + (GuildModel.Instance.guildName == "" ? Lang.GetValue("flower_rank9") : GuildModel.Instance.guildName);
        UpdateExpBar();


    }


    private void UpdateExpBar()
    {
        var level = MyselfModel.Instance.level;
        var currentNeedExp = level == 1 ? 0 : MyselfModel.Instance.GetLevelInfo((int)level).Exp;
        var nextLevelData = MyselfModel.Instance.GetLevelInfo((int)(level + 1));
        if (nextLevelData != null)
        {
            var max = nextLevelData.Exp - currentNeedExp;
            var baseValue = MyselfModel.Instance.exp;
            double e = 0;
            if ((baseValue - currentNeedExp) > max)
            {
                e = max;
            }
            else
            {
                e = (baseValue - currentNeedExp);
            }
            view.expLab.text = e + "/" + max;
            view.pro.max = max;
            view.pro.value = e;
        }
    }

    public void DragLine(GGraph go, List<Vector3> vector3s)
    {
        // 参数校验
        if (go == null) throw new ArgumentNullException(nameof(go));
        if (vector3s == null) throw new ArgumentNullException(nameof(vector3s));

        // 显隐控制
        go.visible = vector3s.Count > 0;
        if (!go.visible) return;

        // 图形配置
        go.color = Color.black;
        LineMesh line = go.asGraph.shape.graphics.GetMeshFactory<LineMesh>();

        // 避免重复设置静态属性（根据实际框架特性调整）
        if (line.lineWidth != 3) line.lineWidth = 3;
        line.roundEdge = true;

        // 路径点优化
        GPathPoint[] points = new GPathPoint[vector3s.Count];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new GPathPoint(
                vector3s[i],
                GPathPoint.CurveType.Straight // 如果框架支持默认值可省略
            );
        }

        // 路径更新
        line.path.Create(points);
        go.asGraph.shape.graphics.SetMeshDirty();
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
        //Stage.inst.onUpdate -= UpdateFrame;
    }
}

