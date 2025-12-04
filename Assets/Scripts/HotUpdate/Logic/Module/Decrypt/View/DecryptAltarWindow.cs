using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DecryptAltarWindow : BaseWindow
{
   private fun_Decrypt.decrypt_altar_view view;
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    private Dictionary<int, Rect> rects;
    private List<int> drags;
    public DecryptAltarWindow()
    {
        packageName = "fun_Decrypt";
        // 设置委托
        BindAllDelegate = fun_Decrypt.fun_DecryptBinder.BindAll;
        CreateInstanceDelegate = fun_Decrypt.decrypt_altar_view.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        view = ui as fun_Decrypt.decrypt_altar_view;
        pos1 = view.drag1.position;
        pos2 = view.drag2.position;
        pos3 = view.drag3.position;
        view.drag1.data = 1;
        view.drag2.data = 2;
        view.drag3.data = 3;

        rects = new Dictionary<int, Rect>();
        drags = new List<int>();
        for (int i = 1;i < 4; i++)
        {
            var item = view.GetChild("item" + i);
            Rect rect = new Rect(item.x, item.y, item.width, item.height);
            rects.Add(i, rect);
        }

        view.drag1.draggable = true;
        view.drag2.draggable = true;
        view.drag3.draggable = true;
        view.drag1.onDragEnd.Add(MoveEnd);
        view.drag2.onDragEnd.Add(MoveEnd);
        view.drag3.onDragEnd.Add(MoveEnd);
    }

    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        
    }

    private void MoveEnd(EventContext context)
    {
        var item = (context.sender as GObject);
        var type = (int)item.data;
        var bol = SetDragPos(item);
        if (!bol)
        {
            if(type == 1)
            {
                item.position = pos1;
            }
            else if(type == 2)
            {
                item.position = pos2;
            }
            else
            {
                item.position = pos3;
            }
        }
    }

    private bool SetDragPos(GObject item)
    {
        Rect rect = new Rect(item.x, item.y, item.width, item.height);
        foreach(var value in rects)
        {
            if (value.Value.Overlaps(rect) && drags.IndexOf(value.Key) == -1)
            {
                drags.Add(value.Key);
                item.position = new Vector3(value.Value.x, value.Value.y, 0);
                item.draggable = false;
                return true;
            }
        }
        return false;
    }

    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

