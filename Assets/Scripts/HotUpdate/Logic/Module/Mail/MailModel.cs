using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Newtonsoft.Json.Linq;
using protobuf.plant;
using UnityEngine;

public class MailModel : Singleton<MailModel>
{
    //主界面红点是否显示
    public int redPoint;
    public int mailCount;
    public List<I_MAIL_VO> mailData;

    //public void InitData()
    //{
    //    mailData = new List<MailData>();
    //    for(int i = 0;i < 3; i++)
    //    {

    //    }
    //}

    public void UpdateRewardStatus(List<string> mailIds)
    {
        foreach(var maildId in mailIds)
        {
            foreach (var maildData in mailData)
            {
                if(maildData.mailId == maildId)
                {
                    maildData.status = 1;
                }
            }
        }
    }

    public void DelMail(List<string> mailIds)
    {
        mailData.RemoveAll((value) =>
        {
            return mailIds.IndexOf(value.mailId) != -1;
        });
    }

    public void GetReward(List<string> mailIds)
    {
        foreach (var maildId in mailIds)
        {
            foreach (var maildData in mailData)
            {
                if (maildData.mailId == maildId)
                {
                    if (maildData.reward != null)
                    {

                        var dropData = new List<StorageItemVO>();
                        foreach (var item in maildData.reward)
                        {
                            var itemVo = new StorageItemVO();
                            itemVo.itemDefId = IDUtil.GetEntityValue((long)item.Key);
                            itemVo.count = (int)item.Value;
                            dropData.Add(itemVo);
                        }
                        DropManager.ShowDrop(dropData);
                    }

                }
            }
        }
    }
}

public class MailData
{
    public int UserId { get; set; }
    public int MailId { get; set; }
    public string Title1 { get; set; }
    public string Title2 { get; set; }
    public string Title3 { get; set; }
    public int Status { get; set; }
    public int CreateTime { get; set; }
    public int Type { get; set; }

    public List<Reward> Reward;

    public MailData()
    {

    }
}

public class Reward
{
    public string entityId { get; set; }
    public int Value { get; set; }
}



