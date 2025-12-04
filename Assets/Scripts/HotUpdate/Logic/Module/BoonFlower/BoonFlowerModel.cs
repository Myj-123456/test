using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 这个功能这个版本不需要 暂时先屏蔽
/// </summary>
public class BoonFlowerModel : Singleton<BoonFlowerModel>
{
    //观看广告次数
    public int adCnt = 0;
    public List<int> fuliDrawState = new List<int>();
    //public Game_guide_seedData boonSeedData;

    public List<int> GetBoonFlowerData(int index)
    {
        //if (boonSeedData == null) boonSeedData = ConfigManager.Instance.GetConfig<Game_guide_seedData>("ft_game_guide_seed");
        //return boonSeedData.DataList[index].Content;
        return fuliDrawState;
    }
}
