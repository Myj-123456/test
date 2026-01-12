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
        public GList exhibitList;
        public btn_tip btn_info;
        public btn_tip btn_vase;
        public GLoader nameBg;
        public GImage notGet;
        public GImage n147;
        public GLoader rareImg;
        public GTextField name_txt;
        public GButton leftBtn;
        public GButton rightBtn;
        public GGroup n198;
        public GLoader3D spine;
        public GImage n191;
        public GTextField titleLab;
        public GGroup n192;
        public GLoader bg;
        public GImage n200;
        public GImage n201;
        public GTextField sub_title;
        public GList list_1;
        public GButton go_btn;
        public GButton lv_btn;
        public GButton go_get_btn;
        public GImage n210;
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
        public btn1 btn_detail;
        public pro pro;
        public GImage n207;
        public GLoader seed_img;
        public GTextField proLab;
        public GGroup proGrp;
        public GGroup n211;
        public GImage n213;
        public GLoader cost_img;
        public GTextField costLab;
        public GGroup n216;
        public GGroup n212;
        public GButton close_btn;
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
            exhibitList = (GList)GetChildAt(1);
            btn_info = (btn_tip)GetChildAt(2);
            btn_vase = (btn_tip)GetChildAt(3);
            nameBg = (GLoader)GetChildAt(4);
            notGet = (GImage)GetChildAt(5);
            n147 = (GImage)GetChildAt(6);
            rareImg = (GLoader)GetChildAt(7);
            name_txt = (GTextField)GetChildAt(8);
            leftBtn = (GButton)GetChildAt(9);
            rightBtn = (GButton)GetChildAt(10);
            n198 = (GGroup)GetChildAt(11);
            spine = (GLoader3D)GetChildAt(12);
            n191 = (GImage)GetChildAt(13);
            titleLab = (GTextField)GetChildAt(14);
            n192 = (GGroup)GetChildAt(15);
            bg = (GLoader)GetChildAt(16);
            n200 = (GImage)GetChildAt(17);
            n201 = (GImage)GetChildAt(18);
            sub_title = (GTextField)GetChildAt(19);
            list_1 = (GList)GetChildAt(20);
            go_btn = (GButton)GetChildAt(21);
            lv_btn = (GButton)GetChildAt(22);
            go_get_btn = (GButton)GetChildAt(23);
            n210 = (GImage)GetChildAt(24);
            n171 = (GImage)GetChildAt(25);
            n172 = (GImage)GetChildAt(26);
            n173 = (GImage)GetChildAt(27);
            n174 = (GImage)GetChildAt(28);
            n175 = (GImage)GetChildAt(29);
            up_1 = (GImage)GetChildAt(30);
            up_2 = (GImage)GetChildAt(31);
            up_3 = (GImage)GetChildAt(32);
            up_4 = (GImage)GetChildAt(33);
            up_5 = (GImage)GetChildAt(34);
            n39 = (GImage)GetChildAt(35);
            n40 = (GImage)GetChildAt(36);
            txt_curlv = (GTextField)GetChildAt(37);
            lb_curExp = (GTextField)GetChildAt(38);
            lb_curGold = (GTextField)GetChildAt(39);
            txt_title_3 = (GTextField)GetChildAt(40);
            txt_title_4 = (GTextField)GetChildAt(41);
            txt_title_5 = (GTextField)GetChildAt(42);
            txt_title_1 = (GTextField)GetChildAt(43);
            txt_title_2 = (GTextField)GetChildAt(44);
            times_txt_1 = (GTextField)GetChildAt(45);
            onecount_txt_1 = (GTextField)GetChildAt(46);
            time_txt_1 = (GTextField)GetChildAt(47);
            count_txt_1 = (GTextField)GetChildAt(48);
            baodicount_txt_1 = (GTextField)GetChildAt(49);
            txt_next = (GTextField)GetChildAt(50);
            count_txt_2 = (GTextField)GetChildAt(51);
            time_txt_2 = (GTextField)GetChildAt(52);
            times_txt_2 = (GTextField)GetChildAt(53);
            onecount_txt_2 = (GTextField)GetChildAt(54);
            baodicount_txt_2 = (GTextField)GetChildAt(55);
            btn_detail = (btn1)GetChildAt(56);
            pro = (pro)GetChildAt(57);
            n207 = (GImage)GetChildAt(58);
            seed_img = (GLoader)GetChildAt(59);
            proLab = (GTextField)GetChildAt(60);
            proGrp = (GGroup)GetChildAt(61);
            n211 = (GGroup)GetChildAt(62);
            n213 = (GImage)GetChildAt(63);
            cost_img = (GLoader)GetChildAt(64);
            costLab = (GTextField)GetChildAt(65);
            n216 = (GGroup)GetChildAt(66);
            n212 = (GGroup)GetChildAt(67);
            close_btn = (GButton)GetChildAt(68);
            effect = (show_play)GetChildAt(69);
            anim = GetTransitionAt(0);
        }
    }
}