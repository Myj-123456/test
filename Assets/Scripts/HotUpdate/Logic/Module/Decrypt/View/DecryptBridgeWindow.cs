using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DecryptBridgeWindow : BaseWindow
{
   private fun_Decrypt.decrypt_bridge_view view;
    private List<Vector3> paths = new List<Vector3>();

    private List<GGraph> graphs = new List<GGraph>();
    private List<Vector3> points1;

    private GGraph graph;
    public DecryptBridgeWindow()
    {
        packageName = "fun_Decrypt";
        // 设置委托
        BindAllDelegate = fun_Decrypt.fun_DecryptBinder.BindAll;
        CreateInstanceDelegate = fun_Decrypt.decrypt_bridge_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Decrypt.decrypt_bridge_view;

        view.board.onTouchBegin.Add((EventContext context) =>
         {
             context.CaptureTouch();
             if(graph == null)
             {
                 var grap = new GGraph();
                 grap.SetSize(view.board.width, view.board.height);
                 view.board.AddChild(grap);
                 grap.SetPosition(0, 0, 0);
                 graphs.Add(grap);

                 graph = grap;
             }
             
             paths.Add(view.board.GlobalToLocal(new Vector3(context.inputEvent.x, context.inputEvent.y, 0)));
         });
        view.board.onTouchMove.Add((EventContext context) =>
        {
            paths.Add(view.board.GlobalToLocal(new Vector3(context.inputEvent.x, context.inputEvent.y, 0)));
            DragLine(graph, paths);
        });
        view.board.onTouchEnd.Add((EventContext context) =>
        {
            if(points1 == null)
            {
                points1 = new List<Vector3>(paths);
            }
            else
            {
               var reslut =  ComprehensiveShapeSimilarity.Instance.CompareShapes(points1, paths);
                reslut.ShowResult();

            }
            LineMesh line = graph.asGraph.shape.graphics.GetMeshFactory<LineMesh>();
            line.path.Clear();
            paths.Clear();
            graph.asGraph.shape.graphics.SetMeshDirty();

        });
        
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

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

