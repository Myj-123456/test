/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class order : GComponent
    {
        public Controller need;
        public Controller type;
        public Controller doubledTab;
        public GLoader ornBg;
        public GImage n293;
        public GImage n279;
        public GImage n282;
        public GImage n283;
        public GImage n291;
        public GImage n284;
        public GImage n285;
        public GImage n297;
        public GImage n308;
        public GImage n311;
        public GImage n305;
        public GImage n314;
        public GImage n313;
        public GImage n298;
        public GImage n287;
        public GImage n286;
        public GImage n288;
        public GImage n289;
        public GImage n290;
        public GImage n292;
        public GImage n294;
        public GImage n295;
        public GImage n296;
        public GImage n301;
        public GImage n302;
        public GImage n303;
        public GImage n304;
        public GImage n306;
        public GImage n307;
        public GImage n310;
        public GImage n309;
        public GImage n299;
        public GImage n300;
        public GImage n251;
        public GImage n250;
        public GLoader3D anim;
        public GTextField order_title_txt;
        public orderNpc npc4;
        public orderNpc npc3;
        public orderNpc npc2;
        public orderNpc npc6;
        public orderNpc npc5;
        public orderNpc npc1;
        public orderNpc npc7;
        public GImage n333;
        public GTextField doubleLab;
        public GGroup n335;
        public GImage n256;
        public GImage n259;
        public GList need_list;
        public GButton submit_btn;
        public GButton close_btn;
        public GTextField doubledOrderRewardTxt;
        public GTextField timeTipLab;
        public GImage n323;
        public GTextField timeLab;
        public GGroup timeShow;
        public order_gift_button btn_smallGift;
        public order_middleGift_button btn_middleGift;
        public order_bigGift_button btn_bigGift;
        public txt_pro txt_smallGift;
        public txt_pro txt_middleGift;
        public txt_pro txt_bigGift;
        public cd_progress progress_completed;
        public reward_com exp_com;
        public reward_com gold_com;
        public reward_com cash_com;
        public reward_com dress_com;
        public GButton add_btn;
        public Transition ainimi_smaill;
        public Transition ainimi_big;
        public Transition ainimi_middle;
        public Transition open;
        public const string URL = "ui://6euywhvrgkun3b";

        public static order CreateInstance()
        {
            return (order)UIPackage.CreateObject("fun_FlowerOrder", "order");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            need = GetControllerAt(0);
            type = GetControllerAt(1);
            doubledTab = GetControllerAt(2);
            ornBg = (GLoader)GetChildAt(0);
            n293 = (GImage)GetChildAt(1);
            n279 = (GImage)GetChildAt(2);
            n282 = (GImage)GetChildAt(3);
            n283 = (GImage)GetChildAt(4);
            n291 = (GImage)GetChildAt(5);
            n284 = (GImage)GetChildAt(6);
            n285 = (GImage)GetChildAt(7);
            n297 = (GImage)GetChildAt(8);
            n308 = (GImage)GetChildAt(9);
            n311 = (GImage)GetChildAt(10);
            n305 = (GImage)GetChildAt(11);
            n314 = (GImage)GetChildAt(12);
            n313 = (GImage)GetChildAt(13);
            n298 = (GImage)GetChildAt(14);
            n287 = (GImage)GetChildAt(15);
            n286 = (GImage)GetChildAt(16);
            n288 = (GImage)GetChildAt(17);
            n289 = (GImage)GetChildAt(18);
            n290 = (GImage)GetChildAt(19);
            n292 = (GImage)GetChildAt(20);
            n294 = (GImage)GetChildAt(21);
            n295 = (GImage)GetChildAt(22);
            n296 = (GImage)GetChildAt(23);
            n301 = (GImage)GetChildAt(24);
            n302 = (GImage)GetChildAt(25);
            n303 = (GImage)GetChildAt(26);
            n304 = (GImage)GetChildAt(27);
            n306 = (GImage)GetChildAt(28);
            n307 = (GImage)GetChildAt(29);
            n310 = (GImage)GetChildAt(30);
            n309 = (GImage)GetChildAt(31);
            n299 = (GImage)GetChildAt(32);
            n300 = (GImage)GetChildAt(33);
            n251 = (GImage)GetChildAt(34);
            n250 = (GImage)GetChildAt(35);
            anim = (GLoader3D)GetChildAt(36);
            order_title_txt = (GTextField)GetChildAt(37);
            npc4 = (orderNpc)GetChildAt(38);
            npc3 = (orderNpc)GetChildAt(39);
            npc2 = (orderNpc)GetChildAt(40);
            npc6 = (orderNpc)GetChildAt(41);
            npc5 = (orderNpc)GetChildAt(42);
            npc1 = (orderNpc)GetChildAt(43);
            npc7 = (orderNpc)GetChildAt(44);
            n333 = (GImage)GetChildAt(45);
            doubleLab = (GTextField)GetChildAt(46);
            n335 = (GGroup)GetChildAt(47);
            n256 = (GImage)GetChildAt(48);
            n259 = (GImage)GetChildAt(49);
            need_list = (GList)GetChildAt(50);
            submit_btn = (GButton)GetChildAt(51);
            close_btn = (GButton)GetChildAt(52);
            doubledOrderRewardTxt = (GTextField)GetChildAt(53);
            timeTipLab = (GTextField)GetChildAt(54);
            n323 = (GImage)GetChildAt(55);
            timeLab = (GTextField)GetChildAt(56);
            timeShow = (GGroup)GetChildAt(57);
            btn_smallGift = (order_gift_button)GetChildAt(58);
            btn_middleGift = (order_middleGift_button)GetChildAt(59);
            btn_bigGift = (order_bigGift_button)GetChildAt(60);
            txt_smallGift = (txt_pro)GetChildAt(61);
            txt_middleGift = (txt_pro)GetChildAt(62);
            txt_bigGift = (txt_pro)GetChildAt(63);
            progress_completed = (cd_progress)GetChildAt(64);
            exp_com = (reward_com)GetChildAt(65);
            gold_com = (reward_com)GetChildAt(66);
            cash_com = (reward_com)GetChildAt(67);
            dress_com = (reward_com)GetChildAt(68);
            add_btn = (GButton)GetChildAt(69);
            ainimi_smaill = GetTransitionAt(0);
            ainimi_big = GetTransitionAt(1);
            ainimi_middle = GetTransitionAt(2);
            open = GetTransitionAt(3);
        }
    }
}