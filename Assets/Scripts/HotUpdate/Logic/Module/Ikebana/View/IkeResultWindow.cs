
using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ADK;
using System;
using System.IO;

public class IkeResultWindow : BaseWindow
{
    private fun_FlowerArrangement.makeEffect view;
    private bool inited = false;
    private int combinationId;
    public IkeResultWindow()
    {
        packageName = "fun_FlowerArrangement";
        // 设置委托
        BindAllDelegate = fun_FlowerArrangement.fun_FlowerArrangementBinder.BindAll;
        CreateInstanceDelegate = fun_FlowerArrangement.makeEffect.CreateInstance;
        ClickBlankClose = true;
        fairyBatching = false;
    }

    public override void OnInit()
    {
        base.OnInit();
        view = ui as fun_FlowerArrangement.makeEffect;
        view.tipLab.text = Lang.GetValue("common_tip_1");
        StringUtil.SetBtnTab(view.btn_share, Lang.GetValue("levelup_button"));
        view.btn_share.onClick.Add(() =>
        {
            var status = IkeModel.Instance.GetIkeShareStatus((uint)combinationId);
            if(status != 2)
            {
                ShareController.Instance.ReqShareIkeReward((uint)combinationId);
            }
            else
            {
                UIManager.Instance.CloseWindow(UIName.IkeResultWindow);
            }
            
        });
        view.spine2.url = "caijian";
        view.spine2.loop = false;
        view.spine2.forcePlay = true;
        view.spine2.Complete = OnAnimationEventHandler1;


        view.spine3.url = "zzwc";
        view.spine3.loop = true;
        view.spine3.forcePlay = true;

        EventManager.Instance.AddEventListener(ShareEvent.ShareIkeReward,Close);
    }

    public void PlaySpine()
    {
        if (!inited)
        {
            view.spine1.url = "huodexianhua";
            view.spine1.Complete = OnAnimationEventHandler;
            view.spine1.forcePlay = true;
            inited = true;
        }
        view.spine1.loop = false;
        view.spine1.animationName = "open";
        view.spine2.animationName = "caijian";
        view.spine3.visible = false;
        
        view.btn_share.visible = false;
        view.tipLab.visible = false;
        view.title.visible = false;


        view.spine3.Complete = OnAnimationEventHandler2;
    }

    private void OnAnimationEventHandler(string name)
    {
        if (name == "open")
        {
            view.spine1.loop = true;
            view.spine1.animationName = "idle";
        }
    }

    private void OnAnimationEventHandler1(string name)
    {
        if (name == "caijian")
        {
            view.spine3.visible = true;
            view.spine3.loop = false;
            view.spine3.animationName = "open";
            view.anim.Play(()=> {
                view.hit.visible = false;
            });
            
            view.btn_share.visible = true;
            view.tipLab.visible = true;
            view.title.visible = true;

            
        }
    }

    private void OnAnimationEventHandler2(string name)
    {
        if (name == "open")
        {
            view.spine3.loop = true;
            view.spine3.animationName = "idle";
        }
        view.spine3.Complete = null;
    }

    public override void OnShown()
    {
        base.OnShown();
        PlaySpine();
        int id = (int)data;
        view.hit.visible = true;
        var ikeInfo = IkeModel.Instance.GetFormula1(id);
        combinationId = ikeInfo.CombinationId;
        var status = IkeModel.Instance.GetIkeShareStatus((uint)combinationId);
        
        StringUtil.SetBtnTab(view.btn_share, status != 2?Lang.GetValue("text_breed36") : Lang.GetValue("levelup_button"));
        // 其他打开面板的逻辑
        UIExt_ikeImg.LoadIkeByItemId((view.img_ike as common_New.ikeImg), id, false);
        
    }

    IEnumerator Jietu()
    {
        DisplayObject dObject = view.displayObject;
        dObject.EnterPaintingMode(1024, null);

        yield return null;
        RenderTexture tex = (RenderTexture)dObject.paintingGraphics.texture.nativeTexture;

        // 创建临时Texture2D
        Texture2D texture2D = new Texture2D(
            400,
            400,
            TextureFormat.RGB24, // 根据需求选择格式
            false
        );

        // 保存当前RenderTexture状态（重要！）
        RenderTexture prevActive = RenderTexture.active;

        // 设置目标RenderTexture为当前活动状态
        RenderTexture.active = tex;

        // 读取像素数据（坐标系原点在左下角）
        texture2D.ReadPixels(new Rect(170, 300, 400, 400), 0, 0);
        texture2D.Apply(); // 必须调用Apply使修改生效

        // 恢复之前的RenderTexture状态
        RenderTexture.active = prevActive;

        // 保存为PNG
        byte[] bytes = texture2D.EncodeToPNG();
        string base64 = Convert.ToBase64String(bytes);
        //string path = Path.Combine(Application.persistentDataPath, "screenshot.png");
        //File.WriteAllBytes(path, bytes);
        string path = Path.Combine(Application.persistentDataPath, "screenshot.png");
        File.WriteAllBytes(path, bytes);
        Debug.Log($"Saved to: {Application.persistentDataPath}");
        //// 清理临时资源
        //Destroy(texture2D);

        //处理结束后结束绘画模式。id要和Enter方法的对应。
        dObject.LeavePaintingMode(1024);
    }

    public override void OnHide()
    {
        base.OnHide();
    }
}

