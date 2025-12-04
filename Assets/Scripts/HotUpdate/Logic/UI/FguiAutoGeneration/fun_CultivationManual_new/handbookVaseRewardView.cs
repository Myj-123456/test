/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookVaseRewardView : GComponent
    {
        public Controller unLockStatus;
        public Controller completeStatus;
        public Controller pageStatus;
        public Controller oneKeyStatus;
        public GLoader bgImg;
        public GImage n70;
        public GLoader vase;
        public GLoader nameBg;
        public GTextField name_txt;
        public GButton btn_left;
        public GButton btn_right;
        public lockBtn unlockBtn;
        public GTextField n88;
        public GImage n46;
        public GTextField flower_txt;
        public GButton completeBtn;
        public GImage n75;
        public GTextField getNum;
        public GGroup n85;
        public GGroup n69;
        public GButton close_btn;
        public GButton oneKeyBtn;
        public GImage n55;
        public GImage n81;
        public GImage n82;
        public GTextField unlockDescLab;
        public GButton tabBtn_0;
        public GButton tabBtn_1;
        public GButton tabBtn_2;
        public GList list;
        public GGroup n87;
        public show_play effect;
        public const string URL = "ui://ekoic0wrd9bk1yjp7tq";

        public static handbookVaseRewardView CreateInstance()
        {
            return (handbookVaseRewardView)UIPackage.CreateObject("fun_CultivationManual_new", "handbookVaseRewardView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unLockStatus = GetControllerAt(0);
            completeStatus = GetControllerAt(1);
            pageStatus = GetControllerAt(2);
            oneKeyStatus = GetControllerAt(3);
            bgImg = (GLoader)GetChildAt(0);
            n70 = (GImage)GetChildAt(1);
            vase = (GLoader)GetChildAt(2);
            nameBg = (GLoader)GetChildAt(3);
            name_txt = (GTextField)GetChildAt(4);
            btn_left = (GButton)GetChildAt(5);
            btn_right = (GButton)GetChildAt(6);
            unlockBtn = (lockBtn)GetChildAt(7);
            n88 = (GTextField)GetChildAt(8);
            n46 = (GImage)GetChildAt(9);
            flower_txt = (GTextField)GetChildAt(10);
            completeBtn = (GButton)GetChildAt(11);
            n75 = (GImage)GetChildAt(12);
            getNum = (GTextField)GetChildAt(13);
            n85 = (GGroup)GetChildAt(14);
            n69 = (GGroup)GetChildAt(15);
            close_btn = (GButton)GetChildAt(16);
            oneKeyBtn = (GButton)GetChildAt(17);
            n55 = (GImage)GetChildAt(18);
            n81 = (GImage)GetChildAt(19);
            n82 = (GImage)GetChildAt(20);
            unlockDescLab = (GTextField)GetChildAt(21);
            tabBtn_0 = (GButton)GetChildAt(22);
            tabBtn_1 = (GButton)GetChildAt(23);
            tabBtn_2 = (GButton)GetChildAt(24);
            list = (GList)GetChildAt(25);
            n87 = (GGroup)GetChildAt(26);
            effect = (show_play)GetChildAt(27);
        }
    }
}