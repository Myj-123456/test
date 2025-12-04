/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbookVaseRewardView : GComponent
    {
        public Controller unLockStatus;
        public Controller completeStatus;
        public Controller pageStatus;
        public Controller oneKeyStatus;
        public GLoader bgImg;
        public GImage n498;
        public GLoader vase;
        public GLoader nameBg;
        public GImage n512;
        public GImage n513;
        public GImage n514;
        public GTextField name_txt;
        public GTextField unlockDescLab;
        public GList list;
        public lockBtn unlockBtn;
        public GButton close_btn;
        public GButton btn_right;
        public GButton btn_left;
        public completeBtn completeBtn;
        public GButton oneKeyBtn;
        public GButton tabBtn_2;
        public GButton tabBtn_1;
        public GButton tabBtn_0;
        public GTextField n515;
        public const string URL = "ui://6q8q1ai6ftbu1ayr851";

        public static handbookVaseRewardView CreateInstance()
        {
            return (handbookVaseRewardView)UIPackage.CreateObject("fun_CultivationManual", "handbookVaseRewardView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unLockStatus = GetControllerAt(0);
            completeStatus = GetControllerAt(1);
            pageStatus = GetControllerAt(2);
            oneKeyStatus = GetControllerAt(3);
            bgImg = (GLoader)GetChildAt(0);
            n498 = (GImage)GetChildAt(1);
            vase = (GLoader)GetChildAt(2);
            nameBg = (GLoader)GetChildAt(3);
            n512 = (GImage)GetChildAt(4);
            n513 = (GImage)GetChildAt(5);
            n514 = (GImage)GetChildAt(6);
            name_txt = (GTextField)GetChildAt(7);
            unlockDescLab = (GTextField)GetChildAt(8);
            list = (GList)GetChildAt(9);
            unlockBtn = (lockBtn)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
            btn_right = (GButton)GetChildAt(12);
            btn_left = (GButton)GetChildAt(13);
            completeBtn = (completeBtn)GetChildAt(14);
            oneKeyBtn = (GButton)GetChildAt(15);
            tabBtn_2 = (GButton)GetChildAt(16);
            tabBtn_1 = (GButton)GetChildAt(17);
            tabBtn_0 = (GButton)GetChildAt(18);
            n515 = (GTextField)GetChildAt(19);
        }
    }
}