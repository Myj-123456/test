/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookVaseTipView : GComponent
    {
        public Controller unLockStatus;
        public Controller pageStatus;
        public GLoader bgImg;
        public GImage n70;
        public ike ike;
        public GLoader nameBg;
        public GTextField name_txt;
        public GButton btn_left;
        public GButton btn_right;
        public btn_tip make_btn;
        public GGroup n100;
        public GButton close_btn;
        public GImage n102;
        public GImage n103;
        public GTextField lockLab;
        public GTextField makeLab;
        public GGraph goto_btn;
        public GGroup n106;
        public vase_com vase_com;
        public GImage n98;
        public GImage n81;
        public GImage n82;
        public GButton tabBtn_0;
        public GButton tabBtn_1;
        public GButton tabBtn_2;
        public GList list;
        public GGroup n99;
        public show_play effect;
        public const string URL = "ui://ekoic0wrjfk51yjp7xt";

        public static handbookVaseTipView CreateInstance()
        {
            return (handbookVaseTipView)UIPackage.CreateObject("fun_CultivationManual_new", "handbookVaseTipView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unLockStatus = GetControllerAt(0);
            pageStatus = GetControllerAt(1);
            bgImg = (GLoader)GetChildAt(0);
            n70 = (GImage)GetChildAt(1);
            ike = (ike)GetChildAt(2);
            nameBg = (GLoader)GetChildAt(3);
            name_txt = (GTextField)GetChildAt(4);
            btn_left = (GButton)GetChildAt(5);
            btn_right = (GButton)GetChildAt(6);
            make_btn = (btn_tip)GetChildAt(7);
            n100 = (GGroup)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
            n102 = (GImage)GetChildAt(10);
            n103 = (GImage)GetChildAt(11);
            lockLab = (GTextField)GetChildAt(12);
            makeLab = (GTextField)GetChildAt(13);
            goto_btn = (GGraph)GetChildAt(14);
            n106 = (GGroup)GetChildAt(15);
            vase_com = (vase_com)GetChildAt(16);
            n98 = (GImage)GetChildAt(17);
            n81 = (GImage)GetChildAt(18);
            n82 = (GImage)GetChildAt(19);
            tabBtn_0 = (GButton)GetChildAt(20);
            tabBtn_1 = (GButton)GetChildAt(21);
            tabBtn_2 = (GButton)GetChildAt(22);
            list = (GList)GetChildAt(23);
            n99 = (GGroup)GetChildAt(24);
            effect = (show_play)GetChildAt(25);
        }
    }
}