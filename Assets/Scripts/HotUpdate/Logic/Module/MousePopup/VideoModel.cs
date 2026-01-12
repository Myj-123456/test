using System.Collections;
using System.Collections.Generic;
using Elida.Config;
using protobuf.misc;
using protobuf.video;
using UnityEngine;

public class VideoModel : Singleton<VideoModel>
{
    private List<Ft_videoConfig> _staticVideo;
    public List<Ft_videoConfig> staticVideo { get
        {
            if(_staticVideo == null)
            {
                Ft_videoConfigData videoData = ConfigManager.Instance.GetConfig<Ft_videoConfigData>("ft_videosConfig");
                _staticVideo = videoData.DataList;
            }
            return _staticVideo;
        } }

    public List<protobuf.video.I_VIDEO_VO> videoWatch;

    public Ft_videoConfig GetVideo(int sp_id)
    {
        return staticVideo.Find(value => value.Sp_id == sp_id);
    }

    public int GetWatchVideoCount(int sp_id)
    {
        var num = 0;
        var videoData = videoWatch.Find(value => value.videoId == sp_id);
        if(videoData != null)
        {
            num = (int)videoData.wathCount;
        }
        return num;
    }

    public void UpdateWatchVideoCount(S_MSG_VIDEO_WATCH data)
    {
        var videoData = videoWatch.Find(value => value.videoId == data.videoId);
        if(videoData == null)
        {
            videoData = new protobuf.video.I_VIDEO_VO();
            videoData.videoId = data.videoId;
            videoData.wathCount = data.watchCount;
            videoWatch.Add(videoData);
        }
        else
        {
            videoData.wathCount = data.watchCount;
        }
        if(videoData.videoId == (int)VideoSeeType.guild_video_id)
        {
            RedPointModel.Instance.ClientUpadteRedPoint(RedPointType.Guild_Donate);
        }
    }

    public void AddWatchVideoCount(int sp_id)
    {
        var videoData = videoWatch.Find(value => value.videoId == sp_id);
        if (videoData != null)
        {
            videoData.wathCount ++;
        }
        else
        {
            var video = new I_VIDEO_VO();
            video.videoId = (uint)sp_id;
            video.wathCount = 1;
            video.lastWatchTime = ServerTime.Time;
            videoWatch.Add(video);
        }
    }
}

public enum VideoSeeType
{
    ID_CULTIVATION_SHORTEN_TIME = 13002,
    Diamond_Order_Video = 14001,//钻石订单
    npc_video_id = 14002,
    flower_sell_video_id = 14003,
    /**目前用于获取月饼 */
    moon_festival_video_id = 15001,
    mouse_video_id = 16001,//老鼠视频
    common_video_id = 17001,
    guild_video_id = 18001,
    rob_video_id = 19001,
    Order_Video_Id = 20001,//新订单视频
    upgrade_id = 30001,
    /** 目前未使用，暂无需求 */
    water_id = 30002, // 水滴补给
    goodTicket_id = 30003,//好票奖励
    bigTurn_video_id = 30004,//大转视频
    steal_flower_id = 30005,//偷花视频
    diamond_order_video_id = 30006,//钻石订单视频
    /** 目前未使用，暂无需求 */
    flower_cd_video_id = 30007,
    /*# tt关注投流，属于强制视频，非奖励视频*/
    focus_on_gift_bag_id = 30008,
    /*日常双倍浇水*/
    // daily_double_water = 30009,
    /*公会比赛刷新任务*/
    guild_match_refresh_task = 30010,
    /** 公会挑战 视频加油 */
    guild_challenge_video_cheer = 30011,
    /** 2024年新春活动-巡羊之路 */
    newYear24_road = 30012,
    /** 清理小游戏 */
    clearGame = 30013,
    /** 幸运花*/
    boonFlower = 30014,
    /** 七夕24*/
    qixi24_game = 30015,
}

public enum VideoCategory
{
    /**0.普通订单视频*/
    COMMON_ORDER_VIDEO,
    /**1.双倍BUFF订单视频*/
    DOUBLE_ORDER_VIDEO,
    /**2.场景宝箱礼包*/
    SCENE_CHEST_GIFT,
    /**3.花朵出售柜台*/
    FLOWER_SELLING_COUNTER,
    /**4. NPC订单视频*/
    NPC_ORDER,
    /**5. 升级视频*/
    CULTIVATION_SHORTEN_TIME,
    /**6. 大转视频*/
    /**目前用于获取月饼 */
    RABBIT_JUMP_TO_MOON,
    /**7. 公会捐献视频*/
    GUILD_DONATE,
    /**8. 钓锦鲤视频*/
    Rob_REWARD,
    /**升级视频 */
    UPGRADE,
    /**水滴补给 */
    WATER,
    /**好票奖励 */
    GOOD_TICKET,

    /**大转视频 */
    BIGTURN_VIDEO,
    /**偷花视频 */
    STEAL_FLOWER,
    /**钻石订单视频 */
    DIAMOND_ORDER_VIDEO,
    /** 花朵CD视频 */
    FLOWERE_CD,
    /**tt关注投流视频 */
    FOCUS_ON_GIFT_BAG,
    /**公会比赛刷新任务视频 */
    GUILD_MATCH_REFRESH_TASK,
    /**公会挑战 视频加油 */
    GUILD_CHALLENGE_VIDEO_CHEER,
    /**2024年新春活动-巡羊之路 */
    NEWYEAR24_ROAD,
    /** 清理小游戏 */
    CLEARGAME,
    /** 幸运花*/
    BOONFLOWER,
    /** 七夕24*/
    Qixi24_GAME,
}

/**视频奖励类型枚举格式*/
public enum VideoRewardType
{
    NONE,//无奖励
    NORMAL,//普通奖励
    CONFIRM//确认奖励
}

