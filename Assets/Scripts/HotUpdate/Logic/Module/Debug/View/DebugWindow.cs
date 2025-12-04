using FairyGUI;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityTimer;
using ADK;

public class DebugWindow : BaseWindow
{
   private fun_webDebug.debug viewSkin;
    private Timer timer;
   public DebugWindow()
    {
        packageName = "fun_webDebug";
        // 设置委托
        BindAllDelegate = fun_webDebug.fun_webDebugBinder.BindAll;
        CreateInstanceDelegate = fun_webDebug.debug.CreateInstance;
    }

    public override void OnInit()
    {
         base.OnInit();
        viewSkin = ui as fun_webDebug.debug;
        StringUtil.SetBtnTab(viewSkin.container.time_btn, "确定");
        StringUtil.SetBtnTab(viewSkin.container.task_btn, "确定");
        StringUtil.SetBtnTab(viewSkin.container.test_btn, "确定");

        viewSkin.container.cashBtn.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.cashTxt.text);
            long id = 10000001;
            DebugContorller.Instance.ResGmAddItem((uint)id, baseNum);
        });
        viewSkin.container.cashBtn_minus.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.cashTxt.text);
            long id = 10000001;
            DebugContorller.Instance.ResGmAddItem((uint)id, -baseNum);
        });

        viewSkin.container.expBtn.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.expTxt.text);
            long id = 14000001;
            DebugContorller.Instance.ResGmAddItem((uint)id, baseNum);
        });

        viewSkin.container.levelBtn.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.levelTxt.text);
            long id = 14000001;
             uint startLv = MyselfModel.Instance.level;
            var levelData  = MyselfModel.Instance.GetLevelInfo((int)MyselfModel.Instance.level + (int)baseNum);
            long addExp =levelData.Exp - MyselfModel.Instance.exp;
            DebugContorller.Instance.ResGmAddItem((uint)id, addExp + 1);
            //timer = Timer.Regist(0.05f, ()=> {
            //    var nextLevelData = MyselfModel.Instance.GetLevelInfo((int)MyselfModel.Instance.level + 1);
            //    if (MyselfModel.Instance.level >= startLv + baseNum || nextLevelData == null)
            //    {
            //        Timer.Cancel(timer);
            //    }
            //    else
            //    {
            //        int addExp = (int)nextLevelData.Exp - (int)MyselfModel.Instance.exp;
            //        DebugContorller.Instance.ResGmAddItem((uint)id, addExp + 1);
            //    }
            //}, true); 

        });

        viewSkin.container.goldBtn.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.goldTxt.text);
            long id = 11000001;
            DebugContorller.Instance.ResGmAddItem((uint)id, (int)baseNum);
        });

        viewSkin.container.goldBtn_minus.onClick.Add(() =>
        {
            uint baseNum = uint.Parse(viewSkin.container.goldTxt.text);
            long id = 11000001;
            DebugContorller.Instance.ResGmAddItem((uint)id, (int)-baseNum);
        });

        viewSkin.container.add_btn.onClick.Add(() =>
        {
            bool prefix_ = viewSkin.container.isDebris.selected ? true : false;
            

            uint id = uint.Parse(viewSkin.container.input_txt.text);
            if (prefix_)
            {
                DebugContorller.Instance.ResGmAddItem(id, -1);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), -1);
            }
            else
            {
                DebugContorller.Instance.ResGmAddItem(id, 1);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), 1);
            }
            
        });

        viewSkin.container.add10_btn.onClick.Add(() =>
        {
            bool prefix_ = viewSkin.container.isDebris.selected ? true : false;

            uint id = uint.Parse(viewSkin.container.input_txt.text);
            if (prefix_)
            {
                DebugContorller.Instance.ResGmAddItem(id, -100);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), -100);
            }
            else
            {
                DebugContorller.Instance.ResGmAddItem(id, 100);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), 100);
            }
                
            
        });

        viewSkin.container.add100_btn.onClick.Add(() =>
        {
            bool prefix_ = viewSkin.container.isDebris.selected ? true : false;

            uint id = uint.Parse(viewSkin.container.input_txt.text);
            if (prefix_)
            {
                DebugContorller.Instance.ResGmAddItem(id, -10000);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), -10000);
            }
            else
            {
                DebugContorller.Instance.ResGmAddItem(id, 10000);
                //StorageModel.Instance.AddToStorageByItemId(int.Parse(viewSkin.container.input_txt.text), 10000);
            }
            
        });
        viewSkin.container.input_txt.onFocusIn.Add(() =>
        {
            viewSkin.container.input_txt.text = "";
        });

        viewSkin.container.time_btn.onClick.Add(() =>
        {
            var str = viewSkin.container.timeLab.text.Trim();
            DebugContorller.Instance.ReqUpdateTimeOffset(str);
        });
        viewSkin.container.task_btn.onClick.Add(() =>
        {
            var id = uint.Parse(viewSkin.container.taskId.text.Trim());
            var num = uint.Parse(viewSkin.container.taskNum.text.Trim());
            DebugContorller.Instance.ReqMainTask(id, num);
        });
        viewSkin.container.test_btn.onClick.Add(() =>
        {
            GetEndTime();
        });
        InitText();
    }
    private void InitText()
    {
        viewSkin.container.taskId.text = "1";
        viewSkin.container.taskNum.text = "0";

        viewSkin.container.goldTxt.text = "10000";
        viewSkin.container.cashTxt.text = "10000";
        viewSkin.container.levelTxt.text = "10";

        viewSkin.container.expTxt.text = "1000";
    }
    public override void OnShown()
    {
        base.OnShown();
        // 其他打开面板的逻辑
        var dataTime = TimeUtil.GetDateTime(ServerTime.Time);
        string formatted1 = dataTime.ToString("yyyy-MM-dd HH:mm:ss");
        viewSkin.container.timeLab.text = formatted1;
    }

    private void GetEndTime()
    {
        var waterBucketTime = uint.Parse(viewSkin.container.test_time.text);
        var endTime = ServerTime.Time - waterBucketTime;
        if (endTime >= GlobalModel.Instance.module_profileConfig.bucketRecoverCD)
        {
            var num = endTime / GlobalModel.Instance.module_profileConfig.bucketRecoverCD;
            Debug.Log("水桶数据：" + endTime + " 数量：" + num);
            for (int i = 0; i < MyselfModel.Instance.waterBucketSeries.Count; i++)
            {
                if (MyselfModel.Instance.waterBucketSeries[i] == 0)
                {
                    MyselfModel.Instance.waterBucketSeries[i] = 1;
                    num--;
                }
                if (num <= 0)
                {
                    break;
                }
            }
            var time = (int)endTime % GlobalModel.Instance.module_profileConfig.bucketRecoverCD;
            waterBucketTime = ServerTime.Time - (uint)time;
            Debug.Log("水桶数据：" + "时间：" + time);
        }
        else
        {
            Debug.Log("水桶数据：" + "时间1：" + endTime);
        }

    }
    public override void OnHide()
    {
        base.OnHide();
        // 其他关闭面板的逻辑
    }
}

