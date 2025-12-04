using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using UnityEngine;
using DG.Tweening;
using UnityTimer;

public class PowerNotice : Singleton<PowerNotice>
{
    private common_New.power_num_change view;
    private Timer timer;
    private Sequence sequence;

    
    private long power;

    private bool isPlay = false;

    private bool isInit = false;
    public void Init()
    {
        var parent = UIManager.Instance.GetLayer(UILayer.Notice);
        view = common_New.power_num_change.CreateInstance();
        view.power_title.text = Lang.GetValue("fighting_title");
        parent.AddChild(view);
        var x = GRoot.inst.width / 2;
        var y = GRoot.inst.width / 5 * 2;
        view.x = x;
        view.y = y;
        isInit = true;
        view.alpha = 0;
        view.visible = false;
        view.touchable = false;
        power = (long)MyselfModel.Instance.fighting;
    }

    public void PlayShow()
    {
        if (!isInit)
        {
            return;
        }
        if (isPlay)
        {
            if (timer != null)
            {
                Timer.Cancel(timer);
                timer = null;
            }
            ChangeNum();
            timer = Timer.Regist(1.5f, PlayHide, false);
            return;
        }
        if(sequence != null)
        {
            sequence.Kill();
            sequence = null;
            isPlay = false;
        }
        sequence = DOTween.Sequence();
        isPlay = true;
        view.visible = true;
        sequence.Append(DOTween.To(() => view.alpha, x => view.alpha = x, 1f, 0.1f));
        sequence.OnComplete(() =>
        {
            sequence.Kill();
            sequence = null;
            timer = Timer.Regist(1.5f, PlayHide, false);
            ChangeNum();
        });
    }

    private void ChangeNum()
    {
        view.powerLab.text = power.ToString();
        long durat = 0;
        if(power < (long)MyselfModel.Instance.fighting)
        {
            durat = (long)MyselfModel.Instance.fighting - power;
            view.status.selectedIndex = 0;
            view.addLab.text = "+" + durat.ToString();
        }
        else
        {
            durat = power - (long)MyselfModel.Instance.fighting;
            view.status.selectedIndex = 1;
            view.addLab.text = "-"+durat.ToString();
        }
       
        var countTween = DOTween.To(
            () => power, // 获取当前值
            x => {
                power = x;
                view.powerLab.text = power.ToString();
            }, // 设置当前值并更新文本
            (long)MyselfModel.Instance.fighting, // 目标值
            0.3f // 持续时间
        ).SetEase(Ease.OutCubic);
    }

    public void PlayHide()
    {
        Timer.Cancel(timer);
        timer = null;
        sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => view.alpha, x => view.alpha = x, 0f, 0.1f));
        sequence.OnComplete(() =>
        {
            sequence.Kill();
            sequence = null;
            isPlay = false;
            view.visible = false;
        });
    }
}


public class TaskNotice : Singleton<TaskNotice>
{
    private common_New.task_num_change view;
    private Sequence sequence;
    public void Init()
    {
        var parent = UIManager.Instance.GetLayer(UILayer.Notice);
        view = common_New.task_num_change.CreateInstance();
        parent.AddChild(view);
        var x = GRoot.inst.width / 2;
        var y = GRoot.inst.width / 5 * 2;
        view.x = x;
        view.y = y;
        view.visible = false;
        view.touchable = false;
        view.alpha = 0;
    }

    public void PlayShow()
    {
        if (sequence != null)
        {
            sequence.Kill();
            sequence = null;
            
        }
        var taskData = TaskModel.Instance.mainTask;
        var taskInfo = TaskModel.Instance.GetTaskMainInfo((int)taskData.mainTaskId);
        if (taskInfo.TaskType == 1 || taskInfo.TaskType == 2 || taskInfo.TaskType == 16 || taskInfo.TaskType == 23)
        {
            if (taskInfo.TypeParam == 0)
            {
                var str = "";
                if (taskInfo.TaskType == 1 || taskInfo.TaskType == 16)
                {
                    str = Lang.GetValue("main_task_1");
                }
                else if (taskInfo.TaskType == 2)
                {
                    str = Lang.GetValue("main_task_2");
                }
                else
                {
                    str = Lang.GetValue("flower_arrangement_01");
                }
                view.decLab.text = Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue("fund_6") + str, taskInfo.TaskNum.ToString());
            }
            else
            {
                var itemVo = ItemModel.Instance.GetItemById(taskInfo.TypeParam);
                view.decLab.text = Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue(itemVo.Name), taskInfo.TaskNum.ToString());
            }

        }
        else if (taskInfo.TaskType == 24)
        {
            var itemVo = ItemModel.Instance.GetItemById(taskInfo.TypeParam);
            view.decLab.text = Lang.GetValue(taskInfo.TaskDesc, Lang.GetValue(itemVo.Name));
        }
        else
        {
            view.decLab.text = Lang.GetValue(taskInfo.TaskDesc, taskInfo.TaskNum.ToString());
        }
        var y = view.y;
        view.alpha = 0.5f;
        view.y = view.y - 50;
        view.visible = true;
        sequence = DOTween.Sequence();
       
        sequence.Append(DOTween.To(() => view.alpha, x => view.alpha = x, 1f, 0.3f))
            .Join(DOTween.To(() => view.y, x => view.y = x, view.y + 50, 0.5f))
            .Append(DOTween.To(() => view.alpha, x => view.alpha = x, 1f, 0.3f))
            .Append(DOTween.To(() => view.alpha, x => view.alpha = x, 0f, 0.2f));
        sequence.OnComplete(() =>
        {
            sequence.Kill();
            sequence = null;
            view.visible = false;
        });
    }
}

public class MarqueeNotice : Singleton<MarqueeNotice>
{
    private common_New.marquee_com view;
    private bool running = false;
    public bool isInit = false;
    private Sequence sequence;
    public void Init()
    {
        var parent = UIManager.Instance.GetLayer(UILayer.Notice);
        view = common_New.marquee_com.CreateInstance();
        parent.AddChild(view);
        var x = GRoot.inst.width;
        var y = GRoot.inst.width / 5;
        view.x = x;
        view.y = y;
        view.visible = false;
        view.touchable = false;
        isInit = true;
    }

    public void PlayShow()
    {
        if(MarqueeModel.Instance.marqueeList.Count > 0)
        {
            var str = MarqueeModel.Instance.marqueeList[0];
            MarqueeModel.Instance.marqueeList.RemoveAt(0);
            view.decLab.text = str;
            view.x = GRoot.inst.width;
            view.visible = true;
            var targetX = GRoot.inst.width + view.width;
            var dec = targetX * 0.01f;
            Debug.Log("paomadeng:" + dec);
            sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => view.x, x => view.x = x, -view.width, dec).SetEase(Ease.Linear));
            sequence.AppendInterval(5f);
            sequence.OnComplete(() =>
            {
                sequence.Kill();
                sequence = null;
                PlayShow();
            });
            //view.TweenMoveX(-view.width, dec).SetEase(EaseType.Linear).OnComplete(()=> {
            //    GTween.DelayedCall(5f).OnComplete(PlayShow);
            //});
        }
        else
        {
            running = false;
        }
        
    }

    public void RunMarquee()
    {
        if (!running && isInit)
        {
            running = true;
            PlayShow();
        }
    }
}
