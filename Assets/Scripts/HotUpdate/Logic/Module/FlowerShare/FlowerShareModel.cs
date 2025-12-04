//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Elida.Config;
//using protobuf.common;
//using protobuf.guild;
//using UnityEngine;
//using static protobuf.guild.S_MSG_GUILD_SHARE_FLOWER_INFO;

//public class FlowerShareModel : Singleton<FlowerShareModel>
//{
//    public List<S_MEMBER_SHARE> guildMemberShareFlowers;//社团成员分享信息
//    public List<I_FLOWER_SHARE_VO> flowerShareInfos;//我的鲜花分享信息
//    public uint surplusTakeCnt;//剩余取花次数
//    public uint[] shareFlowersCollect;//收藏的花id
//    public List<I_FLOWER_SHARE_LOG_VO> messageList;// 分享鲜花日志

//    public static uint getFlowerMaxCount = 5;

//    public static int maxDefaultFlowerCount = 12;

//    private Ft_club_shareConfig _shareConfig;
//    public Ft_club_shareConfig shareConfig { get
//        {
//            if(_shareConfig == null)
//            {
//                Ft_club_shareConfigData shareConfigData = ConfigManager.Instance.GetConfig<Ft_club_shareConfigData>("ft_club_sharesConfig");
//                _shareConfig = shareConfigData.DataList[0];
//            }
//            return _shareConfig;
//        } }

//    public void UpdateGuildMember(I_FLOWER_SHARE_VO data)
//    {
//        int index = GetGuildMemberIndex(data.userId);
//        if(index != -1)
//        {
//            var flowerShares = guildMemberShareFlowers[index].shareFlowers;

//            for (int i = 0; i < flowerShares.Count; i++)
//            {
//                if(flowerShares[i].position == data.position)
//                {
//                    flowerShares[i] = data;
//                    return;
//                }
//            }
//            flowerShares.Add(data);
//        }
        
//    }

//    public void UpdateStorageCount(I_FLOWER_SHARE_VO data)
//    {
//        var shareInfo = guildMemberShareFlowers.Find((value) => value.userInfo.userId == data.userId);
//        if(shareInfo != null)
//        {
//            var shareFlower = shareInfo.shareFlowers.Find((value) => value.position == data.position);
//            if(shareFlower != null)
//            {
//                StorageModel.Instance.AddToStorageByItemId(shareFlower.flowerId, (int)(data.times - shareFlower.times)*int.Parse(data.count));
//            }
//        }
//    }

//    public void UpdateFlowerShareInfos(I_FLOWER_SHARE_VO data)
//    {
//        int index = GetFlowerShareIndex(data.position);
//        if(index == -1)
//        {
//            flowerShareInfos.Add(data);
//        }
//        else
//        {
//            flowerShareInfos[index] = data;
//        }
//    }

//    public int GetGuildMemberIndex(uint userId)
//    {
//        for(int i = 0;i < guildMemberShareFlowers.Count; i++)
//        {
//            if(guildMemberShareFlowers[i].userInfo.userId == userId)
//            {
//                return i;
//            }
//        }
//        return -1;
//    }

//    public int GetFlowerShareIndex(uint position)
//    {
//        for (int i = 0; i < flowerShareInfos.Count; i++)
//        {
//            if (flowerShareInfos[i].position == position)
//            {
//                return i;
//            }
//        }
//        return -1;
//    }

//    public I_FLOWER_SHARE_VO GetFlowerShareInfo(uint pos)
//    {
//        return flowerShareInfos.Find((value) => value.position == pos);
//    }

//    public List<SeedCropVO> GetDefaultFlowerList()
//    {
//        var flowers = new List<SeedCropVO>();
//        if(shareFlowersCollect != null && shareFlowersCollect.Length > 0)
//        {
//            foreach(var id in shareFlowersCollect)
//            {
//                flowers.Add(StorageModel.Instance.GetSeedCropVO((int)id));
//            }
//        }
//        else
//        {
//            flowers = GetFlowersList();
//        }
//        return flowers;
//    }

//    public List<SeedCropVO> GetFlowersList()
//    {
//        if (StorageModel.Instance.seedList.Count > maxDefaultFlowerCount)
//        {
//            return StorageModel.Instance.seedList.GetRange(0, maxDefaultFlowerCount);
//        }
//        else
//        {
//            return StorageModel.Instance.seedList;
//        } 
//    }

//    public uint GetEmptyPostion()
//    {
//        foreach(var value in flowerShareInfos)
//        {
//            if(value.flowerId == "" || value.flowerId == "0")
//            {
//                return value.position;
//            }
//        }
//        return 0;
//    }
//}



