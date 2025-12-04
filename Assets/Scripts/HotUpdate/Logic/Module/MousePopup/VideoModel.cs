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
    Diamond_Order_Video = 14001,//黑板订单
    npc_video_id = 14002,
    flower_sell_video_id = 14003,
    /**目前用于获取金币 */
    moon_festival_video_id = 15001,
    mouse_video_id = 16001,//领水看视频
    common_video_id = 17001,
    guild_video_id = 18001,
    rob_video_id = 19001,
    Order_Video_Id = 20001,//新的视频
    upgrade_id = 30001,
    /**下面待修改，目前没有 */
    water_id = 30002, //水滴不足
    goodTicket_id = 30003,//好评券不足
    bigTurn_video_id = 30004,//大转盘
    steal_flower_id = 30005,//偷花
    diamond_order_video_id = 30006,//订单玉石
    //种花CD
    flower_cd_video_id = 30007,
    /*# tt关注礼包和抖音新需求强制弹出激励视频*/
    focus_on_gift_bag_id = 30008,
    // /*勤劳的回报 日常双倍领水*/
    // daily_double_water = 30009,
    /*社团竞赛，视频刷新任务*/
    guild_match_refresh_task = 30010,
    /**社团挑战赛 视频助威 */
    guild_challenge_video_cheer = 30011,
    /** 2024新春活动-巡礼之路*/
    newYear24_road = 30012,
    /** 锦上添花*/
    clearGame = 30013,
    /** 福利鲜花*/
    boonFlower = 30014,
    /** 七夕24*/
    qixi24_game = 30015,
}

public enum VideoCategory
{
    /**0.常规订单视频*/
    COMMON_ORDER_VIDEO,
    /**1.双倍BUFF收益视频*/
    DOUBLE_ORDER_VIDEO,
    /**2.地鼠，场景宝箱*/
    SCENE_CHEST_GIFT,
    /**3.卖花台*/
    FLOWER_SELLING_COUNTER,
    /**4.客户订单*/
    NPC_ORDER,
    /**5.培育*/
    CULTIVATION_SHORTEN_TIME,
    /**6.兔兔奔月，暂时不用*/
    /**目前用于获取金币 */
    RABBIT_JUMP_TO_MOON,
    /**7.公会捐献*/
    GUILD_DONATE,
    /**8.抢夺*/
    Rob_REWARD,
    /**升级视频 */
    UPGRADE,
    /**水滴不足 */
    WATER,
    /**好评券不足 */
    GOOD_TICKET,

    /**大转盘 */
    BIGTURN_VIDEO,
    /**偷花 */
    STEAL_FLOWER,
    /**订单玉石 */
    DIAMOND_ORDER_VIDEO,
    /** 种花CD */
    FLOWERE_CD,
    /**tt关注礼包领取*/
    FOCUS_ON_GIFT_BAG,
    /**社团竞赛，视频刷新任务*/
    GUILD_MATCH_REFRESH_TASK,
    /**社团挑战赛 视频助威 */
    GUILD_CHALLENGE_VIDEO_CHEER,
    /**2024新春活动-巡礼之路 */
    NEWYEAR24_ROAD,
    /** 锦上添花*/
    CLEARGAME,
    /** 福利鲜花*/
    BOONFLOWER,
    /** 七夕24*/
    Qixi24_GAME,
}

/**观看视频后获得奖励的形式*/
public enum VideoRewardType
{
    NONE,//无
    NORMAL,//获得奖励
    CONFIRM//弹出确认框后获得奖励
}

