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
        public GImage n112;
        public GTextField titleLab;
        public GGroup n114;
        public ike ike;
        public GLoader nameBg;
        public GLoader rare_img;
        public GTextField name_txt;
        public GButton btn_left;
        public GButton btn_right;
        public btn_tip make_btn;
        public GGroup n123;
        public GImage n119;
        public GImage n118;
        public GImage n103;
        public GTextField lockLab;
        public GTextField makeLab;
        public GGraph goto_btn;
        public GGroup n120;
        public GLoader bg;
        public vase_com vase_com;
        public GImage n115;
        public page_btn tabBtn_0;
        public page_btn tabBtn_1;
        public page_btn tabBtn_2;
        public GList list;
        public GGroup n117;
        public GButton close_btn;
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
            n112 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            n114 = (GGroup)GetChildAt(3);
            ike = (ike)GetChildAt(4);
            nameBg = (GLoader)GetChildAt(5);
            rare_img = (GLoader)GetChildAt(6);
            name_txt = (GTextField)GetChildAt(7);
            btn_left = (GButton)GetChildAt(8);
            btn_right = (GButton)GetChildAt(9);
            make_btn = (btn_tip)GetChildAt(10);
            n123 = (GGroup)GetChildAt(11);
            n119 = (GImage)GetChildAt(12);
            n118 = (GImage)GetChildAt(13);
            n103 = (GImage)GetChildAt(14);
            lockLab = (GTextField)GetChildAt(15);
            makeLab = (GTextField)GetChildAt(16);
            goto_btn = (GGraph)GetChildAt(17);
            n120 = (GGroup)GetChildAt(18);
            bg = (GLoader)GetChildAt(19);
            vase_com = (vase_com)GetChildAt(20);
            n115 = (GImage)GetChildAt(21);
            tabBtn_0 = (page_btn)GetChildAt(22);
            tabBtn_1 = (page_btn)GetChildAt(23);
            tabBtn_2 = (page_btn)GetChildAt(24);
            list = (GList)GetChildAt(25);
            n117 = (GGroup)GetChildAt(26);
            close_btn = (GButton)GetChildAt(27);
            effect = (show_play)GetChildAt(28);
        }
    }
}