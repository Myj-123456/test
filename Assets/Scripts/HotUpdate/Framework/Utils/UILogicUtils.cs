using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Elida.Config;
using FairyGUI;
using UnityEngine;


namespace ADK
{
    public class UILogicUtils
    {

        public static common_New.ItemGridTip _nameTipHome;
        public static Sequence sequence;

        public static Dictionary<int, common_New.ItemGridTip> _nameTipMap = new Dictionary<int, common_New.ItemGridTip>();
        public static void ShowNotice(string value, string color = "")
        {
            new Notice(value, color, GRoot.inst.width / 2, GRoot.inst.height / 2).SetParent(GRoot.inst);
        }
        public static void ItemUnder(int id)
        {
            var itemVo = ItemModel.Instance.GetItemById(id);
            ShowNotice(Lang.GetValue(itemVo.Name) + Lang.GetValue("text_grandma14"));
        }
        public static string GetUBBSting(int total, int need, string totalColor, string needColor)
        {
            if (total >= need)
                return "[color=" + needColor + "]" + total + "[/color]/" + need;
            else
                return "[color=" + totalColor + "]" + total + "[/color]/" + need;
        }
        public static void ChangeOthersFrameDisplay(uint flowerLv, uint endTime = 0, common_New.PictureFrame frame = null, uint headFrame = 0, GTextField title = null)
        {
            if (headFrame != 0)
            {
                var itemVo = ItemModel.Instance.GetItemById((int)headFrame);
                if (itemVo != null && frame != null)
                {
                    frame.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                }
                if (title != null && itemVo != null)
                {
                    var lan = Lang.GetValue(itemVo.Name);
                    title.text = Lang.GetValue("flower_rank3") + lan;
                }
                else
                {
                    title.text = Lang.GetValue("flower_rank3") + Lang.GetValue("flower_rank9");
                }

            }
            else
            {
                //var data = FlowerRankModel.Instance.GetFlowerConfigById((int)flowerLv);
                //if (endTime == 0 || endTime < ServerTime.Time || data == null)
                //{
                //    if (frame != null)
                //    {
                //        frame.pic.url = "";
                //    }
                //    if (title != null)
                //    {
                //        title.text = Lang.GetValue("flower_rank3") + Lang.GetValue("flower_rank9");
                //    }
                //    return;
                //}
                //var itemVo = ItemModel.Instance.GetItemByEntityID(data.Rewards[0].EntityID);
                //if (frame != null)
                //{
                //    frame.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                //}
                //if (title != null)
                //{
                //    title.text = Lang.GetValue("flower_rank3") + Lang.GetValue(itemVo.Name);
                //}
            }
        }

        public static void ShowConfirm(string value, Action callBack, Action cencel = null, bool isShowCancelBtn = true, bool isShowAntiAddiction = false, UILayer layer = UILayer.Window)
        {
            object[] param = new object[] { value, callBack, cencel, isShowCancelBtn, isShowAntiAddiction };
            UIManager.Instance.OpenWindow<ConfirmWindow>(UIName.ConfirmWindow, param, layer);
        }


        public static bool NeedShowGetFlowerVas = false;//是否需要弹出获取花/花瓶弹窗
        public static void ShowGetReward(List<StorageItemVO> items, Action callBack, string tip = "", bool considerVip = true, bool levelUp = false)
        {
            MyselfModel.Instance.isShowReward = true;
            NeedShowGetFlowerVas = false;
            foreach (var data in items)
            {
                var itemConfig = ItemModel.Instance.GetItemById(data.itemDefId);
                if ((itemConfig.Type == 4402 || itemConfig.Type == 4401 || itemConfig.Type == 4105))
                {
                    NeedShowGetFlowerVas = true;
                    break;
                }
            }
            object[] param = new object[] { items, callBack, tip, considerVip, levelUp };
            UIManager.Instance.OpenWindow<GetRewardWindow>(UIName.GetRewardWindow, param);
        }


        public static void ShowGetFlowerVase(Module_item_defConfig itemData, Action callFun = null)
        {
            var param = new object[] { itemData, callFun };
            UIManager.Instance.OpenWindow<NewlyGotFlowerShowWindow>(UIName.NewlyGotFlowerShowWindow, param);
        }
        public static void ShowNameTip(GLoader pic, int id)
        {
            Module_item_defConfig item = ItemModel.Instance.GetItemById(id);
            var name = Lang.GetValue(item.Name);
            bool isSentreX = pic.pivotAsAnchor && pic.pivotX == 0.5f;
            bool isSentreY = pic.pivotAsAnchor && pic.pivotY == 0.5f;
            var diffX = isSentreX ? 0 : (pic.width / 2);
            var diffY = isSentreY ? -(pic.height / 2) : 0;
            pic.url = ImageDataModel.Instance.GetIconUrl(item);
            RegisterNameTip(pic, diffX, diffY, name);
        }

        public static void RegisterNameTip(GObject comp, float diffX, float diffY, string name)
        {
            comp.touchable = true;
            comp.data = new object[] { diffX, diffY, name, comp.GetHashCode() };

            comp.onTouchBegin.Add(TouchIn);
            comp.onTouchEnd.Add(TouchOut);
        }

        public static void ClearNameTip(GLoader pic)
        {
            pic.url = "";
            pic.onTouchBegin.Remove(TouchIn);
            pic.onTouchEnd.Remove(TouchOut);
        }

        private static void TouchIn(EventContext context)
        {
            var comp = (context.sender as GObject);
            comp.onRollOut.Add(TouchOut);
            object[] data = comp.data as object[];
            if (_nameTipHome == null)
            {
                _nameTipHome = common_New.ItemGridTip.CreateInstance();
            }
            var ntc = _nameTipHome;

            if (ntc.parent == null)
            {
                GRoot.inst.AddChild(ntc);
            }

            ntc.name = "nameTipComp";
            ntc.txt_name.text = (string)data[2];
            Vector2 postion = comp.LocalToRoot(new Vector2((float)data[0], (float)data[1]), GRoot.inst);
            ntc.x = postion.x;
            ntc.y = postion.y + 50;
            ntc.alpha = 0;

            GTween.Kill(ntc);
            GTween.To(ntc.alpha, 1, 0.25f).SetTarget(ntc, TweenPropType.Alpha).SetEase(EaseType.CircInOut);
            GTween.To(new Vector2(ntc.x, ntc.y), postion, 0.25f).SetTarget(ntc, TweenPropType.Position)
                  .SetEase(EaseType.CircInOut);

        }

        private static void TouchOut(EventContext context)
        {
            var comp = (context.sender as GObject);
            comp.onRollOut.Remove(TouchOut);

            if (_nameTipHome == null) return;
            var ntc = _nameTipHome;

            GTween.Kill(ntc);
            GTween.To(ntc.alpha, 0, 0.25f).SetTarget(ntc, TweenPropType.Alpha).SetEase(EaseType.CircInOut);
            GTween.To(new Vector2(ntc.x, ntc.y), new Vector2(ntc.x, ntc.y + 50), 0.25f).SetTarget(ntc, TweenPropType.Position)
                  .SetEase(EaseType.CircInOut).OnComplete(() =>
                  {
                      if (ntc.parent != null)
                      {
                          ntc.parent.RemoveChild(ntc);
                      }
                      GTween.Kill(ntc);
                  });
        }


        public static void ShowHeadFrames(common_New.PictureFrame picFrame, Module_item_defConfig itemVo, int scale = 1)
        {
            if (picFrame != null)
            {
                if (itemVo != null)
                {
                    if (itemVo.Alter_avatar == 1)
                    {
                        //picFrame.type.selectedIndex = 1;
                        picFrame.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                        picFrame.anim.scaleX = scale;
                        picFrame.anim.scaleY = scale;
                    }
                    else
                    {
                        //picFrame.type.selectedIndex = 0;
                        picFrame.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                    }

                }
            }

        }
        public static void ShowHeadFrames(common_New.PictureFrame picFrame, int id)
        {
            var itemVo = ItemModel.Instance.GetItemById(id);
            if (picFrame != null)
            {
                if (itemVo != null)
                {
                    if (itemVo.Alter_avatar == 1)
                    {
                        picFrame.type.selectedIndex = 1;
                    }
                    else
                    {
                        picFrame.type.selectedIndex = 0;
                        picFrame.pic.url = ImageDataModel.Instance.GetIconUrl(itemVo);
                    }

                }
            }

        }

        public static void RemoveHeadFrames(common_New.PictureFrame picFrame)
        {
            if (picFrame != null)
            {
                picFrame.pic.url = "";
            }
        }

        public static void AddTweenOfViewList(GList vList)
        {
            float i = 0;
            foreach (var go in vList._children)
            {
                // 首先将 GObject 的 x 坐标设置为其宽度
                go.x = go.width;
                // 等待一段时间，时间为 10 + i * 50
                Sequence sequence = DOTween.Sequence();
                var time = 0.01f + i * 0.05f;
                sequence.AppendInterval(time);
                // 然后将 x 坐标移动到 -go.width / 10，动画时长为 300，缓动曲线为 Ease.InSine
                sequence.Append(DOTween.To(() => go.x, x => go.x = x, -go.width / 10, 0.3f).SetEase(Ease.InSine));
                // 再等待 50 
                sequence.AppendInterval(0.05f);
                // 最后将 x 坐标移动到 0，动画时长为 300，缓动曲线为 Ease.OutBack
                sequence.Append(DOTween.To(() => go.x, x => go.x = x, 0, 0.3f).SetEase(Ease.OutBack));
                sequence.Play();
                i++;
            }
        }

        public static void ClearTweenOfViewList(GList vList)
        {
            foreach (var go in vList._children)
            {
                DOTween.Kill(go.displayObject.gameObject);
            }
        }

        public static Vector2 TransformPos(Vector3 pos)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(pos);
            //原点位置转换
            screenPos.y = Screen.height - screenPos.y;
            Vector2 pt = GRoot.inst.GlobalToLocal(screenPos);
            return pt;
        }



        public static void SetItemShow(GObject item, int itemId)
        {
            item.data = itemId;
            item.onClick.Add(ItemShowClick);
        }

        public static void ItemShowClick(EventContext context)
        {
            var itemId = (int)(context.sender as GObject).data;
            ShowItemGainTips(itemId);
        }
        public static void ShowItemGainTips(int itemId)
        {
            var item = ItemModel.Instance.GetItemById(itemId);
            if (item != null)
            {
                if (item.ActionIds.Length <= 0 || item.ActionIds[0] == -1)
                {
                    UIManager.Instance.OpenWindow<ItemTips>(UIName.ItemTips, item);
                }
                else
                {
                    if (item.Type == 4001 || item.Type == 4105)
                    {
                        var flowerInfo = item.Type == 4001 ? FlowerHandbookModel.Instance.GetStaticSeedCondition(item.ItemDefId) : FlowerHandbookModel.Instance.GetStaticSeedCondition1(item.ItemDefId);
                        if (flowerInfo.AlreadyCulitivated)
                        {
                            UIManager.Instance.OpenWindow<ItemTips>(UIName.ItemTips, item);
                        }
                        else if (flowerInfo.UnlockAccessible)
                        {
                            ShowFlowerTips(itemId);
                        }
                        else
                        {
                            UIManager.Instance.OpenWindow<ItemGainTips>(UIName.ItemGainTips, item);
                        }
                    }
                    else if (item.Type == 4401)
                    {
                        var vaseInfo = IkeModel.Instance.GetStaticFlowerPoint(item.ItemDefId);
                        if (IkeModel.Instance.IsUnlockVase(vaseInfo.VaseId))
                        {
                            UIManager.Instance.OpenWindow<ItemTips>(UIName.ItemTips, item);
                        }
                        else
                        {
                            UIManager.Instance.OpenWindow<ItemGainTips>(UIName.ItemGainTips, item);
                        }
                    }
                    else
                    {
                        UIManager.Instance.OpenWindow<ItemGainTips>(UIName.ItemGainTips, item);
                    }
                }
            }
        }

        public static void ShowVaseTips(int itemId)
        {
            var item = ItemModel.Instance.GetItemById(itemId);
            if (item != null)
            {
                UIManager.Instance.OpenWindow<VaseTips>(UIName.VaseTips, item);
            }
        }

        public static void ShowFlowerTips(int itemId)
        {
            var item = ItemModel.Instance.GetItemById(itemId);
            if (item != null)
            {
                UIManager.Instance.OpenWindow<FlowerTips>(UIName.FlowerTips, item);
            }
        }

        public static void SetUserShow(GObject item, uint userId)
        {
            item.data = userId;
            item.onClick.Add(UserInfoShow);
        }

        private static void UserInfoShow(EventContext context)
        {
            var id = (uint)(context.sender as GObject).data;
            MyselfController.Instance.ReqOtherUserInfo(id);
        }

        public static void RemoveUserShow(GObject item)
        {
            item.onClick.Remove(UserInfoShow);
        }
    }




}

