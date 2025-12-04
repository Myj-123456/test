using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShowManger : Singleton<MainShowManger>
{
    public fun_MainUI.leftBtns leftView;
    public fun_MainUI.rightBtns rightView;
    public float leftMax = 447;
    public float rightMax = 625;

    public float leftMin = 100f;
    public float right = 102f;

    private bool leftShow = true;
    private bool rightShow = true;
    public void Init(fun_MainUI.leftBtns leftUI, fun_MainUI.rightBtns rightUI)
    {
        leftView = leftUI;
        rightView = rightUI;

        leftView.show_btn.onClick.Add(PlayLeftTween);
        rightView.show_btn.onClick.Add(PlayerRightTween);

        leftView.btn.scroll.btn_grp.onSizeChanged.Add(UpdateLeftShow);
        rightView.btn_com.scroll.btn_grp.onSizeChanged.Add(UpdateLeftShow);
        UpdateLeftShow();
        UpdateRightShow();
    }
    public void UpdateLeftShow()
    {
        if (leftShow)
        {
            if(leftView.btn.scroll.btn_grp.height > leftMax)
            {
                leftView.btn.height = leftMax;
            }
            else
            {
                leftView.btn.height = leftView.btn.scroll.btn_grp.height;
            }
            leftView.show_btn.scaleY = -1;
        }
    }

    public void UpdateRightShow()
    {
        if (rightShow)
        {
            if (rightView.btn_com.scroll.btn_grp.height > rightMax)
            {
                rightView.btn_com.height = rightMax;
            }
            else
            {
                rightView.btn_com.height = rightView.btn_com.scroll.btn_grp.height;
            }
            rightView.show_btn.scaleY = -1;
        }
    }

    private void PlayLeftTween()
    {
        if (leftShow)
        {
            leftShow = false;
            leftView.show_btn.scaleY = 1;
            leftView.btn.TweenResize(new Vector2(leftView.btn.width, leftMin),0.2f);
        }
        else
        {
            leftShow = true;
            leftView.show_btn.scaleY = -1;
            leftView.btn.TweenResize(new Vector2(leftView.btn.width, leftView.btn.scroll.btn_grp.height), 0.2f);
        }
    }
    private void PlayerRightTween()
    {
        if (rightShow)
        {
            rightShow = false;
            rightView.show_btn.scaleY = 1;
            rightView.btn_com.TweenResize(new Vector2(rightView.btn_com.width, right), 0.2f);
        }
        else
        {
            rightShow = true;
            rightView.show_btn.scaleY = -1;
            rightView.btn_com.TweenResize(new Vector2(rightView.btn_com.width, rightView.btn_com.scroll.btn_grp.height), 0.2f);
        }
    }
}

