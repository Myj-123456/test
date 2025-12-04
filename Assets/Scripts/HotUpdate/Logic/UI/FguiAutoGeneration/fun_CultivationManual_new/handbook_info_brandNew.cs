/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_info_brandNew : GComponent
    {
        public Controller locked;
        public Controller type;
        public Controller rareUnlockStatus;
        public Controller quality;
        public Controller share;
        public GLoader fullScreenBg;
        public GImage n70;
        public GList exhibitList;
        public GButton close_btn;
        public GButton go_get_btn;
        public GButton go_btn;
        public btn_tip btn_info;
        public btn_tip btn_vase;
        public GButton lv_btn;
        public GLoader cost_img;
        public GTextField costLab;
        public GGroup n189;
        public GLoader nameBg;
        public GImage notGet;
        public GImage n147;
        public GLoader rareImg;
        public GTextField name_txt;
        public GButton leftBtn;
        public GButton rightBtn;
        public GGroup n85;
        public circle_share share_btn;
        public GImage n122;
        public GTextField shareLab;
        public GList shareList;
        public GGroup n125;
        public GImage n144;
        public GTextField titleLab;
        public GGroup n146;
        public GLoader3D spine;
        public GImage n55;
        public GImage n48;
        public GTextField sub_title;
        public GList list_1;
        public GImage n168;
        public GImage n171;
        public GImage n172;
        public GImage n173;
        public GImage n174;
        public GImage n175;
        public GImage up_1;
        public GImage up_2;
        public GImage up_3;
        public GImage up_4;
        public GImage up_5;
        public GImage n39;
        public GImage n40;
        public GTextField txt_curlv;
        public GTextField lb_curExp;
        public GTextField lb_curGold;
        public GTextField txt_title_3;
        public GTextField txt_title_4;
        public GTextField txt_title_5;
        public GTextField txt_title_1;
        public GTextField txt_title_2;
        public GTextField times_txt_1;
        public GTextField onecount_txt_1;
        public GTextField time_txt_1;
        public GTextField count_txt_1;
        public GTextField baodicount_txt_1;
        public GTextField txt_next;
        public GTextField count_txt_2;
        public GTextField time_txt_2;
        public GTextField times_txt_2;
        public GTextField onecount_txt_2;
        public GTextField baodicount_txt_2;
        public GButton btn_detail;
        public GGroup n187;
        public GGroup n188;
        public show_play effect;
        public Transition anim;
        public const string URL = "ui://ekoic0wri64u1yjp7sr";

        public static handbook_info_brandNew CreateInstance()
        {
            return (handbook_info_brandNew)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_info_brandNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            locked = GetControllerAt(0);
            type = GetControllerAt(1);
            rareUnlockStatus = GetControllerAt(2);
            quality = GetControllerAt(3);
            share = GetControllerAt(4);
            fullScreenBg = (GLoader)GetChildAt(0);
            n70 = (GImage)GetChildAt(1);
            exhibitList = (GList)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            go_get_btn = (GButton)GetChildAt(4);
            go_btn = (GButton)GetChildAt(5);
            btn_info = (btn_tip)GetChildAt(6);
            btn_vase = (btn_tip)GetChildAt(7);
            lv_btn = (GButton)GetChildAt(8);
            cost_img = (GLoader)GetChildAt(9);
            costLab = (GTextField)GetChildAt(10);
            n189 = (GGroup)GetChildAt(11);
            nameBg = (GLoader)GetChildAt(12);
            notGet = (GImage)GetChildAt(13);
            n147 = (GImage)GetChildAt(14);
            rareImg = (GLoader)GetChildAt(15);
            name_txt = (GTextField)GetChildAt(16);
            leftBtn = (GButton)GetChildAt(17);
            rightBtn = (GButton)GetChildAt(18);
            n85 = (GGroup)GetChildAt(19);
            share_btn = (circle_share)GetChildAt(20);
            n122 = (GImage)GetChildAt(21);
            shareLab = (GTextField)GetChildAt(22);
            shareList = (GList)GetChildAt(23);
            n125 = (GGroup)GetChildAt(24);
            n144 = (GImage)GetChildAt(25);
            titleLab = (GTextField)GetChildAt(26);
            n146 = (GGroup)GetChildAt(27);
            spine = (GLoader3D)GetChildAt(28);
            n55 = (GImage)GetChildAt(29);
            n48 = (GImage)GetChildAt(30);
            sub_title = (GTextField)GetChildAt(31);
            list_1 = (GList)GetChildAt(32);
            n168 = (GImage)GetChildAt(33);
            n171 = (GImage)GetChildAt(34);
            n172 = (GImage)GetChildAt(35);
            n173 = (GImage)GetChildAt(36);
            n174 = (GImage)GetChildAt(37);
            n175 = (GImage)GetChildAt(38);
            up_1 = (GImage)GetChildAt(39);
            up_2 = (GImage)GetChildAt(40);
            up_3 = (GImage)GetChildAt(41);
            up_4 = (GImage)GetChildAt(42);
            up_5 = (GImage)GetChildAt(43);
            n39 = (GImage)GetChildAt(44);
            n40 = (GImage)GetChildAt(45);
            txt_curlv = (GTextField)GetChildAt(46);
            lb_curExp = (GTextField)GetChildAt(47);
            lb_curGold = (GTextField)GetChildAt(48);
            txt_title_3 = (GTextField)GetChildAt(49);
            txt_title_4 = (GTextField)GetChildAt(50);
            txt_title_5 = (GTextField)GetChildAt(51);
            txt_title_1 = (GTextField)GetChildAt(52);
            txt_title_2 = (GTextField)GetChildAt(53);
            times_txt_1 = (GTextField)GetChildAt(54);
            onecount_txt_1 = (GTextField)GetChildAt(55);
            time_txt_1 = (GTextField)GetChildAt(56);
            count_txt_1 = (GTextField)GetChildAt(57);
            baodicount_txt_1 = (GTextField)GetChildAt(58);
            txt_next = (GTextField)GetChildAt(59);
            count_txt_2 = (GTextField)GetChildAt(60);
            time_txt_2 = (GTextField)GetChildAt(61);
            times_txt_2 = (GTextField)GetChildAt(62);
            onecount_txt_2 = (GTextField)GetChildAt(63);
            baodicount_txt_2 = (GTextField)GetChildAt(64);
            btn_detail = (GButton)GetChildAt(65);
            n187 = (GGroup)GetChildAt(66);
            n188 = (GGroup)GetChildAt(67);
            effect = (show_play)GetChildAt(68);
            anim = GetTransitionAt(0);
        }
    }
}