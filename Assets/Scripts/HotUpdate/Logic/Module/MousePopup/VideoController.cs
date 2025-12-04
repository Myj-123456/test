using System.Collections;
using System.Collections.Generic;
using ADK;
using protobuf.messagecode;
using protobuf.misc;
using protobuf.order;
using UnityEngine;

public class VideoController : BaseController<VideoController>
{
    public I_ORDER_VO orderData;
    protected override void InitListeners()
    {
        // ”∆µ–≈œ¢
        AddNetListener<S_MSG_VIDEO_WATCH>((int)MessageCode.S_MSG_VIDEO_WATCH, VideoWatch);
    }

    public void VideoWatch(S_MSG_VIDEO_WATCH data)
    {
        var videoData = VideoModel.Instance.GetVideo((int)data.videoId);
        VideoModel.Instance.UpdateWatchVideoCount(data);
        if (videoData.Sp_id == (int)VideoSeeType.common_video_id)
        {
            var videoDoubleTime = ServerTime.Time + uint.Parse(videoData.Sp_rewards[0].EntityID);
            MyselfModel.Instance.UpdateUserInfo(UserInfoType.INFO_VIDEO_BUFF, videoDoubleTime.ToString());
            EventManager.Instance.DispatchEvent(VideoEvent.videoDoubleTime);
            UIManager.Instance.CloseWindow(UIName.VideoPopupWindow);
        }else if(videoData.Sp_id == (int)VideoSeeType.guild_video_id)
        {
            var dropData = new List<StorageItemVO>();
            foreach(var reward in videoData.Sp_rewards)
            {
                var drop = new StorageItemVO();
                drop.itemDefId = IDUtil.GetEntityValue(reward.EntityID);
                drop.count = reward.Value;
                dropData.Add(drop);
            }
            DropManager.ShowDrop(dropData);
            DropManager.ShowDropItem2(ImageDataModel.Instance.GuildMoneyIconUrl(), videoData.Peraga);
            EventManager.Instance.DispatchEvent(VideoEvent.videoGuildDonate);
            GuildController.Instance.ReqGuildInfo();
        }else if (videoData.Sp_id == (int)VideoSeeType.Diamond_Order_Video)
        {
            
        }

    }

    public void ReqVideoWatch(uint videoId)
    {
        C_MSG_VIDEO_WATCH c_MSG_VIDEO_WATCH = new C_MSG_VIDEO_WATCH();
        c_MSG_VIDEO_WATCH.videoId = videoId;
        SendCmd((int)MessageCode.C_MSG_VIDEO_WATCH, c_MSG_VIDEO_WATCH);
    }
}
