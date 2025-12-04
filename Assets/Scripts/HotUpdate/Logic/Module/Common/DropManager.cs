using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System;
using Random = System.Random;
using DG.Tweening;
using ADK;
using Elida.Config;

public class DropManager
{
    private static List<common_New.Drop> dropMap;
    private static Random random = new Random();
    private static Dictionary<int, Vector2> flyPos = new Dictionary<int, Vector2>();
    private static Dictionary<int, Vector2> adventureFlyPos = new Dictionary<int, Vector2>();//冒险玩法飞坐标点
    public static Vector2 seedPos = new Vector2();

    private static common_New.DropCom dropCom;
    private static List<common_New.DropImg> dropImgMap;
    private static List<common_New.DropNum> dropNumMap;
    private static Vector2 defaultVec = new Vector2(9999, 9999);

    public static void AddMainFlyPos(int itemId, Vector2 pos)
    {
        flyPos.Add(itemId, pos);
    }
    public static void AddAdventureFlyPos(int itemId, Vector2 pos)
    {
        adventureFlyPos.Add(itemId, pos);
    }

    /// <summary>
    /// 飘多个物品
    /// </summary>
    /// <param name="dropData"></param>
    /// <param name="IsAdd"></param>
    public static void ShowDrop(List<StorageItemVO> dropData, bool IsAdd = true,bool IsShow = true)
    {
        foreach (var data in dropData)
        {
            var itemConfig = ItemModel.Instance.GetItemById(data.itemDefId);
            if(itemConfig.Category == 53)
            {
                if (MyselfModel.Instance.vipTime > ServerTime.Time)
                {
                    MyselfModel.Instance.vipTime += (uint)(itemConfig.Indate * data.count);
                }
                else
                {
                    MyselfModel.Instance.vipTime = ServerTime.Time + (uint)(itemConfig.Indate * data.count);
                }
            }else if(itemConfig.Category == 55)
            {
                var video = MyselfModel.Instance.GetUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD);

                if (video == null)
                {
                    string info = (ServerTime.Time + 60 * 60 * 24 * 30).ToString();
                    MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD, info);
                }
                else
                {
                    if (int.Parse(video.info) > ServerTime.Time)
                    {
                        var info = int.Parse(video.info) + (60 * 60 * 24 * 30);
                        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD, info.ToString());
                    }
                    else
                    {
                        var info = ServerTime.Time + (60 * 60 * 24 * 30);
                        MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_TYPE_SKIP_VIDEO_CARD, info.ToString());
                    }
                }
            }
            else
            {
                ShowDropItem(data.itemDefId, data.count, IsAdd, null);
            }

            if(IsShow && (itemConfig.Type == 4402 || itemConfig.Type == 4401 || itemConfig.Type == 4105))
            {
                UILogicUtils.ShowGetFlowerVase(itemConfig);
            }
            if(itemConfig.Category == 41)
            {
                Debug.Log("获得Item：" + itemConfig.ItemDefId + "数量：" + data.count);
            }
            
        }
    }

    /// <summary>
    /// 飘多个物品(可以指定起点位置)
    /// </summary>
    /// <param name="dropData"></param>
    /// <param name="IsAdd"></param>
    /// <param name="fromPos">指定飘物品起点，不指定默认是屏幕中间</param>
    public static void ShowDropFromPoint(List<StorageItemVO> dropData, Vector2 fromPos, bool IsAdd = true)
    {
        foreach (var data in dropData)
        {
            ShowDropItem1(data.itemDefId, data.count, IsAdd, fromPos);
        }
    }

    /// <summary>
    /// 飘多个物品(可以指定终点位置)
    /// </summary>
    /// <param name="dropData"></param>
    /// <param name="IsAdd"></param>
    /// <param name="fromPos">指定飘物品起点，不指定默认是屏幕中间</param>
    public static void ShowDropToPoint(List<StorageItemVO> dropData, Vector2 toPos, bool IsAdd = true)
    {
        foreach (var data in dropData)
        {
            ShowDropItem1(data.itemDefId, data.count, IsAdd, null, toPos);
        }
    }

    /// <summary>
    /// 飘单个物品
    /// </summary>
    /// <param name="itemDefId"></param>
    /// <param name="count"></param>
    /// <param name="IsAdd"></param>
    /// <param name="isScene">是否是在场景层</param>
    public static void ShowDropItem1(int itemDefId, int count, bool IsAdd = true, Vector2? fromPos = null, Vector2? toPos = null)
    {
        Vector2 position = fromPos ?? defaultVec;
        var item = ItemModel.Instance.GetItemById(itemDefId);
        if (dropMap == null)
        {
            dropMap = new List<common_New.Drop>();
        }
        common_New.Drop dropUI;
        if (dropMap.Count > 0)
        {
            dropUI = dropMap[0];
            dropMap.RemoveAt(0);
        }
        else
        {
            dropUI = common_New.Drop.CreateInstance();
        }
        if (IsAdd)
        {
            StorageModel.Instance.AddToStorageByItemId(itemDefId, count);
        }
        if (itemDefId == (int)BaseType.EXP)
        {
            dropUI.num.text = Mathf.Ceil(count * (1 + MyselfModel.Instance.CurrVipExp() / 100f)).ToString();
        }
        else
        {
            dropUI.num.text = count.ToString();
        }
        dropUI.res.url = ImageDataModel.Instance.GetIconUrlByItemId((long)itemDefId);
        GRoot.inst.AddChild(dropUI);
        float dropX = 0f;
        float dropY = 0f;
        if (position == defaultVec)
        {
            dropX = (GRoot.inst.width / 2 - dropUI.width / 2) + random.Next(-30, 30);
            dropY = GRoot.inst.height / 2 + random.Next(-30, 30);
        }
        else
        {
            dropX = position.x - dropUI.width / 2;
            dropY = position.y - dropUI.height / 2;
        }
        dropUI.x = dropX;
        dropUI.y = dropY - 50;
        dropUI.alpha = 0.5f;
        dropUI.SetScale(1f, 1f);
        var sequence = DOTween.Sequence();
        Vector2 targetPos;
        if (toPos != null)
        {
            targetPos = (Vector2)toPos;
        }
        else
        {
            if (!MyselfModel.Instance.isInAdventure)
            {
                targetPos = IDUtil.IsCommonItem(itemDefId) ? flyPos[itemDefId] : (item.Type == 4005 ? seedPos : new Vector2(GRoot.inst.width - dropUI.width, 0));
            }
            else
            {
                targetPos = adventureFlyPos.ContainsKey(itemDefId) ? adventureFlyPos[itemDefId] : new Vector2(GRoot.inst.width - dropUI.width, 0);
            }
        }
        
        sequence.Append(DOTween.To(() => dropUI.alpha, x => dropUI.alpha = x, 1f, 0.3f))
            .Join(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY - 200, 0.3f))
            .Append(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY, 0.8f).SetEase(Ease.OutBounce))
            //.Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(1, 1), 0.8f).SetEase(Ease.OutBounce))
            .AppendInterval(0.5f)
            .Append(DOTween.To(() => dropUI.xy, x => dropUI.xy = x, targetPos, 1f).SetEase(Ease.InOutCubic))
            .Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(0.6f, 0.6f), 1f).SetEase(Ease.InOutCubic))
            .OnComplete(() =>
            {
                sequence.Kill();
                if (dropUI.parent != null) dropUI.parent.RemoveChild(dropUI);
                dropMap.Add(dropUI);
            }).Play();
    }
    public static void ShowDropItem(int itemDefId, int count, bool IsAdd = true, Vector2? fromPos = null)
    {
        Vector2 position = fromPos ?? defaultVec;
        if (IsAdd)
        {
            StorageModel.Instance.AddToStorageByItemId(itemDefId, count);
        }
        AddDropCom(position);
        if (dropImgMap == null) dropImgMap = new List<common_New.DropImg>();
        if (dropNumMap == null) dropNumMap = new List<common_New.DropNum>();
        var dropImg = dropImgMap.Count > 0 ? dropImgMap[0] : common_New.DropImg.CreateInstance();
        var dropNum = dropNumMap.Count > 0 ? dropNumMap[0] : common_New.DropNum.CreateInstance();
        if (dropImgMap.Count > 0) dropImgMap.RemoveAt(0);
        if (dropNumMap.Count > 0) dropNumMap.RemoveAt(0);
        dropImg.res.url = ImageDataModel.Instance.GetIconUrlByItemId((long)itemDefId);
        if(itemDefId == (int)BaseType.EXP)
        {
            dropNum.num.text = Mathf.Ceil(count * ( 1 + MyselfModel.Instance.CurrVipExp() / 100f)).ToString();
        }
        else
        {
            dropNum.num.text = count.ToString();
        }
        dropCom.ImgCom.AddChild(dropImg);
        dropCom.TextCom.AddChild(dropNum);

        //dropCom.AddChildAt(dropImg,0);
        //dropCom.AddChild(dropNum);

        float dropX =  random.Next(-30, 30) ;
        float dropY =  random.Next(-30, 30) ;
        if(position != defaultVec)
        {
            var pos = dropCom.RootToLocal(position, GRoot.inst);
            dropX = pos.x - dropImg.width/2;
            dropY = pos.y - dropImg.height / 2;
        }

        dropImg.fairyBatching = true;
        dropNum.fairyBatching = true;
        Play(dropImg, itemDefId, 1, dropX, dropY);
        Play(dropNum, itemDefId, 0, dropX, dropY);
    }

    private static void Play(GComponent dropUI, int itemDefId, int type, float dropX, float dropY)
    {
        dropUI.x = dropX;
        dropUI.y = dropY - 50;
        dropUI.alpha = 0.5f;
        dropUI.SetScale(1.0f, 1.0f);
        var item = ItemModel.Instance.GetItemById(itemDefId);
        Vector2 rootPos;
        if (!MyselfModel.Instance.isInAdventure)
        {
            rootPos = IDUtil.IsCommonItem(itemDefId) ? flyPos[itemDefId] : (item.Type == 4005 ? seedPos : new Vector2(GRoot.inst.width - dropUI.width, 0));
        }
        else
        {
            rootPos = adventureFlyPos.ContainsKey(itemDefId) ? adventureFlyPos[itemDefId] : new Vector2(GRoot.inst.width - dropUI.width, 0);
        }
        var targetPos = dropCom.RootToLocal(rootPos, GRoot.inst);
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => dropUI.alpha, x => dropUI.alpha = x, 1f, 0.3f))
            .Join(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY - 200, 0.3f))
            .Append(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY, 0.8f).SetEase(Ease.OutBounce))
            //.Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(1, 1), 0.8f).SetEase(Ease.OutBounce))
            .AppendInterval(0.5f)
            .Append(DOTween.To(() => dropUI.xy, x => dropUI.xy = x, targetPos, 1f).SetEase(Ease.InOutCubic))
            .Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(0.6f, 0.6f), 1f).SetEase(Ease.InOutCubic))
            .OnComplete(() =>
            {
                sequence.Kill();
                if (dropUI.parent != null) dropUI.parent.RemoveChild(dropUI);
                if (type == 1)
                {
                    dropImgMap.Add(dropUI as common_New.DropImg);
                }
                else
                {
                    dropNumMap.Add(dropUI as common_New.DropNum);
                }
                RemoveDropCom();
            }).Play();
    }

    public static void ShowDropItem2(string path, int count)
    {

        if (dropMap == null)
        {
            dropMap = new List<common_New.Drop>();
        }
        common_New.Drop dropUI;
        if (dropMap.Count > 0)
        {
            dropUI = dropMap[0];
            dropMap.RemoveAt(0);
        }
        else
        {
            dropUI = common_New.Drop.CreateInstance();
        }
        dropUI.num.text = count.ToString();
        dropUI.res.url = path;
        GRoot.inst.AddChild(dropUI);
        float dropX = 0f;
        float dropY = 0f;
        dropX = (GRoot.inst.width / 2 - dropUI.width / 2) + random.Next(-30, 30);
        dropY = GRoot.inst.height / 2 + random.Next(-30, 30);

        dropUI.x = dropX;
        dropUI.y = dropY - 50;
        dropUI.alpha = 0.5f;
        dropUI.SetScale(1.0f, 1.0f);

        var sequence = DOTween.Sequence();
        var targetPos = new Vector2(GRoot.inst.width - dropUI.width, 0);
        sequence.Append(DOTween.To(() => dropUI.alpha, x => dropUI.alpha = x, 1f, 0.3f))
            .Join(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY - 200, 0.3f))
            .Append(DOTween.To(() => dropUI.y, x => dropUI.y = x, dropY, 0.8f).SetEase(Ease.OutBounce))
            //.Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(1, 1), 0.8f).SetEase(Ease.OutBounce))
            .AppendInterval(0.5f)
            .Append(DOTween.To(() => dropUI.xy, x => dropUI.xy = x, targetPos, 1f).SetEase(Ease.InOutCubic))
            .Join(DOTween.To(() => dropUI.scale, x => dropUI.scale = x, new Vector2(0.6f, 0.6f), 1f).SetEase(Ease.InOutCubic))
            .OnComplete(() =>
            {
                sequence.Kill();
                if (dropUI.parent != null) dropUI.parent.RemoveChild(dropUI);
                dropMap.Add(dropUI);
            }).Play();
    }

    private static void AddDropCom(Vector2 fromPos)
    {
        if (dropCom == null)
        {
            dropCom = common_New.DropCom.CreateInstance();
            //dropCom.childrenRenderOrder = ChildrenRenderOrder.Ascent;
        }

        if (dropCom.parent == null)
        {
            GRoot.inst.root.AddChild(dropCom);
            dropCom.x = GRoot.inst.width / 2;
            dropCom.y = GRoot.inst.height / 2;
        }
    }

    private static void RemoveDropCom()
    {
        if (dropCom == null || dropCom.parent == null)
        {
            return;
        }
        if (dropCom.ImgCom._children.Count <= 0)
        {
            dropCom.parent.RemoveChild(dropCom);
        }
    }
}

public class DropItemData
{
    public int id;

    public int count;
}
