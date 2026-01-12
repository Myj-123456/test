using System;
using System.Collections;
using System.Collections.Generic;
using ADK;
using Elida.Config;
using Newtonsoft.Json.Linq;
using protobuf.mail;
using protobuf.plant;
using UnityEngine;

public class MailModel : Singleton<MailModel>
{
    //主界面红点是否显示
    public int redPoint;
    public int mailCount;
    public List<I_MAIL_VO> mailData;

    private Dictionary<int, Ft_mail_systemConfig> _mailMap;
    public Dictionary<int, Ft_mail_systemConfig> mailMap
    {
        get
        {
            if(_mailMap == null)
            {
                var mailConfigData = ConfigManager.Instance.GetConfig<Ft_mail_systemConfigData>("ft_mail_systemsConfig");
                _mailMap = mailConfigData.DataMap;
            }
            return _mailMap;
        }
    }
    //public void InitData()
    //{
    //    mailData = new List<MailData>();
    //    for(int i = 0;i < 3; i++)
    //    {

    //    }
    //}
    public Ft_mail_systemConfig GetMailInfo(int id)
    {
        if (mailMap.ContainsKey(id))
        {
            return mailMap[id];
        }
        return null;
    }
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

    public bool IsGetMailRead()
    {
        if(mailData == null)
        {
            return false;
        }
        foreach(var value in mailData)
        {
            if(value.status == 0)
            {
                return true;
            }
        }
        return false;
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



