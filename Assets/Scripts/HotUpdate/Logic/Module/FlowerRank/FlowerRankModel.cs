using System.Collections;
using System.Collections.Generic;
using ADK;
using DG.Tweening;
using Elida.Config;
using FairyGUI;
using protobuf.misc;
using protobuf.plant;
using UnityEngine;
using static Elida.Config.Ft_rank_listConfig;

public class FlowerRankModel : Singleton<FlowerRankModel>
{

    public List<FlowerRankData> _flowerConfigList;
    public List<FlowerRankData> _cultivateConfigList;
    public List<FlowerRankData> _waterConfigList;
    public List<FlowerRankData>[] _configListArr;

    public S_MSG_RANK_LIST curRankList;

    public static string flowerRankOpenTime = "flowerRankUIOpenTime";
    public static string cultivateRankOpenTime = "cultivateRankOpenTime";
    public static string waterRankOpenTime = "waterRankOpenTime";

    public S_MSG_RANK_LIST prosperityRankList;//���а����� 1�����ٶ� 
    public S_MSG_RANK_LIST cultivateRankList;//���а�����  2������ 
    public S_MSG_RANK_LIST artRankList;//���а�����  3������Ʒ
    public S_MSG_RANK_LIST dressRankList;//���а�����  4��ʱװ����

    public List<I_USER_INFO_DRESS_GUILD> prosperityUserInfo = new List<I_USER_INFO_DRESS_GUILD>();
    public List<I_USER_INFO_DRESS_GUILD> cultivateUserInfo = new List<I_USER_INFO_DRESS_GUILD>();
    public List<I_USER_INFO_DRESS_GUILD> artUserInfo = new List<I_USER_INFO_DRESS_GUILD>();
    public List<I_USER_INFO_DRESS_GUILD> dressUserInfo = new List<I_USER_INFO_DRESS_GUILD>();
    public List<I_USER_INFO_DRESS_GUILD> bestUserInfo = new List<I_USER_INFO_DRESS_GUILD>();


    public I_USER_INFO_DRESS_GUILD GetUserInfo(int type,uint userId)
    {
        if(type == 1)
        {
            return prosperityUserInfo.Find(value => value.userInfo.userId == userId);
        }
        else if(type == 2)
        {
            return cultivateUserInfo.Find(value => value.userInfo.userId == userId);
        }
        else if (type == 3)
        {
            return artUserInfo.Find(value => value.userInfo.userId == userId);
        }
        else if (type == 4)
        {
            return dressUserInfo.Find(value => value.userInfo.userId == userId);
        }
        else
        {
            return bestUserInfo.Find(value => value.userInfo.userId == userId);
        }
    }
    public List<FlowerRankData>[] configListArr
    {
        get
        {
            if (_configListArr == null)
            {
                _configListArr = new List<FlowerRankData>[] { flowerConfigList, cultivateConfigList, waterConfigList };
            }
            return _configListArr;
        }
    }




    public List<FlowerRankData> flowerConfigList
    {
        get
        {
            if (_flowerConfigList == null)
            {
                Ft_rank_listConfigData rankListData = ConfigManager.Instance.GetConfig<Ft_rank_listConfigData>("ft_rank_listsConfig");
                _flowerConfigList = new List<FlowerRankData>();
                foreach (Ft_rank_listConfig item in rankListData.DataList)
                {
                    FlowerRankData rankList = new FlowerRankData(item);
                    rankList.Ranks.Sort((pre, next) => pre - next);
                    _flowerConfigList.Add(rankList);

                }
            }
            return _flowerConfigList;
        }
    }
    public List<FlowerRankData> cultivateConfigList
    {
        get
        {
            if (_cultivateConfigList == null)
            {
                Ft_rank_bookConfigData bookListData = ConfigManager.Instance.GetConfig<Ft_rank_bookConfigData>("ft_rank_booksConfig");
                _cultivateConfigList = new List<FlowerRankData>();
                foreach (Ft_rank_bookConfig item in bookListData.DataList)
                {
                    FlowerRankData book = new FlowerRankData(item);
                    book.Ranks.Sort((pre, next) => pre - next);
                    _cultivateConfigList.Add(book);
                }
            }
            return _cultivateConfigList;
        }
    }
    public List<FlowerRankData> waterConfigList
    {
        get
        {
            if (_waterConfigList == null)
            {
                Ft_rank_waterConfigData waterListData = ConfigManager.Instance.GetConfig<Ft_rank_waterConfigData>("ft_rank_watersConfig");
                _waterConfigList = new List<FlowerRankData>();
                foreach (Ft_rank_waterConfig item in waterListData.DataList)
                {
                    FlowerRankData water = new FlowerRankData(item);
                    water.Ranks.Sort((pre, next) => pre - next);
                    _waterConfigList.Add(water);
                }
            }
            return _waterConfigList;
        }
    }


    //public void initData()
    //{
    //    Rank_listConfigData rankListData = ConfigManager.Instance.GetConfig<Rank_listConfigData>("ft_rank_listConfig");
    //    Rank_bookConfigData bookListData = ConfigManager.Instance.GetConfig<Rank_bookConfigData>("ft_rank_bookConfig");
    //    Rank_waterConfigData waterListData = ConfigManager.Instance.GetConfig<Rank_waterConfigData>("ft_rank_waterConfig");

    //    flowerConfigList = new List<FlowerRankData>();
    //    cultivateConfigList = new List<FlowerRankData>();
    //    waterConfigList = new List<FlowerRankData>();

    //    foreach (Rank_listConfig item in rankListData.DataList)
    //    {
    //        FlowerRankData rankList = new FlowerRankData(item);
    //        rankList.Ranks.Sort((pre, next) =>  pre - next);
    //        flowerConfigList.Add(rankList);

    //    }

    //    foreach (Rank_bookConfig item in bookListData.DataList)
    //    {
    //        FlowerRankData book = new FlowerRankData(item);
    //        book.Ranks.Sort((pre, next) => pre - next);
    //        cultivateConfigList.Add(book);
    //    }

    //    foreach (Rank_waterConfig item in waterListData.DataList)
    //    {
    //        FlowerRankData water = new FlowerRankData(item);
    //        water.Ranks.Sort((pre, next) => pre - next);
    //        waterConfigList.Add(water);
    //    }
    //    configListArr = new List<FlowerRankData>[] { flowerConfigList, cultivateConfigList, waterConfigList };
    //}

    public FlowerRankData GetRankConfigByRank(int rank, int index = 0)
    {
        if (rank <= -1)
        {
            return null;
        }
        var confgList = configListArr[index];
        FlowerRankData data = confgList.Find((value) =>
        {
            if (value.Ranks.Count <= 0) return false;
            return value.Ranks[0] <= rank && value.Ranks[value.Ranks.Count - 1] >= rank;
        });
        return data;
    }

    public FlowerRankData GetFlowerConfigById(int id, int index = 0)
    {
        var confgList = configListArr[index];
        var vo = confgList.Find((value) => value.IndexId == id);
        return vo;
    }

    public int RetrieveOpenTime(uint type)
    {
        string prefix = "";
        switch (type)
        {
            case 1: prefix = flowerRankOpenTime; break;
            case 2: prefix = cultivateRankOpenTime; break;
            case 3: prefix = waterRankOpenTime; break;
        }
        return Saver.GetInt(prefix + MyselfModel.Instance.userId);
    }


    public void RecordOpenTime(uint type)
    {
        string prefix = "";
        switch (type)
        {
            case 1:prefix = flowerRankOpenTime;break;
            case 2: prefix = cultivateRankOpenTime; break;
            case 3: prefix = waterRankOpenTime; break;
        }
        Saver.SaveAsString<int>(prefix + MyselfModel.Instance.userId,(int)ServerTime.Time);
    }

    public void ShowRankFrameAnim(Module_item_defConfig itemVo)
    {
        var picFram = common_New.PictureFrame.CreateInstance();
        UILogicUtils.ShowHeadFrames(picFram, itemVo);
        GRoot.inst.AddChild(picFram);
        picFram.x = GRoot.inst.width / 2;
        picFram.y = GRoot.inst.height / 2;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 0f, 0.3f))
            .Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 1.1f, 0.3f))
            .Join(DOTween.To(() => picFram.scaleY, x => picFram.scaleY = x, 1.1f, 0.3f))
            .Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 0f, 0.3f))
            .Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 1.2f, 0.3f))
            .Join(DOTween.To(() => picFram.scaleY, x => picFram.scaleY = x, 1.2f, 0.3f))
            .Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 0f, 0.3f))
            .Append(DOTween.To(() => picFram.scaleX, x => picFram.scaleX = x, 1.2f, 0.3f))
            .Append(DOTween.To(() => picFram.xy, x => picFram.xy = x, new(picFram.height / 2, GRoot.inst.height / 2 - picFram.width / 2), 0.3f))
            .OnComplete(() => { picFram.Dispose(); }).Play();
    }
}

public class FlowerRankData
{
    public int IndexId { get; set; }
    public List<int> Ranks { get; set; }
    public List<RewardObject> Rewards { get; set; }

    public FlowerRankData(Ft_rank_listConfig obj)
    {
        IndexId = obj.IndexId;
        Ranks = new List<int>(obj.Ranks);
        Rewards = new List<RewardObject>(obj.Rewards);
    }

    public FlowerRankData(Ft_rank_bookConfig obj)
    {
        IndexId = obj.IndexId;
        Ranks = new List<int>(obj.Ranks);
        Rewards = new List<RewardObject>(obj.Rewards);
    }

    public FlowerRankData(Ft_rank_waterConfig obj)
    {
        IndexId = obj.IndexId;
        Ranks = new List<int>(obj.Ranks);
        Rewards = new List<RewardObject>(obj.Rewards);
    }

}


//public class UserInfo
//{
//    uint userId; //�û�id
//    uint userLevel; //�ȼ�
//    string townName ; //�ǳ�
//    string headImgId; //ͷ��
//    uint headFrame; //���
//    uint flowerLevel; //�ʻ����а�ȼ�
//    uint flowerLevelExpireTime; //�ʻ����а�ȼ���Ч��
//    uint lastLoginTime; //�����¼ʱ��
//}

//public class MyRank
//{
//    uint rank; //����
//    uint score;//����
//}
//public class RankUser
//{
//    UserInfo rankList;//�û���Ϣ
//    uint score;//����
//}

//public class RankList
//{
//    MyRank myRank;
//    List<RankUser> rankList;
//}

