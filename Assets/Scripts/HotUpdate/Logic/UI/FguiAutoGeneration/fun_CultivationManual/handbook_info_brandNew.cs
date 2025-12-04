/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_info_brandNew : GComponent
    {
        public Controller locked;
        public Controller type;
        public Controller rareUnlockStatus;
        public Controller quality;
        public Controller isRareStatus;
        public GLoader fullScreenBg;
        public GImage n506;
        public GImage n507;
        public GImage n508;
        public GImage n518;
        public GList exhibitList;
        public greenLongMoneyBtn level_btn;
        public GImage n513;
        public GImage n514;
        public GImage n515;
        public GImage n516;
        public GTextField txt_curlv;
        public GTextField txt_nextLv;
        public GImage n173;
        public GTextField txt_title_1;
        public GTextField txt_title_2;
        public GTextField txt_title_3;
        public GTextField txt_title_4;
        public GTextField txt_title_1_1;
        public GTextField txt_title_2_1;
        public GTextField txt_title_3_1;
        public GTextField txt_title_4_1;
        public GTextField count_txt_1;
        public GTextField time_txt_1;
        public GTextField times_txt_1;
        public GTextField onecount_txt_1;
        public GTextField count_txt_2;
        public GTextField time_txt_2;
        public GTextField times_txt_2;
        public GTextField onecount_txt_2;
        public GImage up_1;
        public GImage up_2;
        public GImage up_3;
        public GImage up_4;
        public GButton btn_detail;
        public GTextField txt_title_5;
        public GTextField txt_title_5_1;
        public GTextField tou_txt_1;
        public GTextField tou_txt_2;
        public GImage up_5;
        public GGroup lastProperty;
        public GTextField levelLab;
        public GGroup n318;
        public GButton go_btn;
        public GButton go_get_btn;
        public GTextField type_txt;
        public GList list_1;
        public GGroup n333;
        public GLoader nameBg;
        public handbookFlowerExhibit ehCell;
        public GTextField name_txt;
        public GGroup pendant;
        public GLoader rare_bg;
        public GTextField rare_Lab;
        public GGroup n522;
        public circle_share share_btn;
        public GRichTextField flower_txt;
        public GList ls_star;
        public GTextField lb_curExp;
        public GImage n451;
        public GGroup g_Exp;
        public GImage gold_icon;
        public GTextField lb_curGold;
        public GGroup g_Gold;
        public GButton close_btn;
        public GImage n494;
        public GTextField unlockTimeLab;
        public GTextField unlockDescLab;
        public GTextField playerNameLab;
        public GGroup n498;
        public GButton leftBtn;
        public GButton rightBtn;
        public GImage n524;
        public GTextField haveLab;
        public GGroup notGet;
        public const string URL = "ui://6q8q1ai6kbinwprg";

        public static handbook_info_brandNew CreateInstance()
        {
            return (handbook_info_brandNew)UIPackage.CreateObject("fun_CultivationManual", "handbook_info_brandNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            locked = GetControllerAt(0);
            type = GetControllerAt(1);
            rareUnlockStatus = GetControllerAt(2);
            quality = GetControllerAt(3);
            isRareStatus = GetControllerAt(4);
            fullScreenBg = (GLoader)GetChildAt(0);
            n506 = (GImage)GetChildAt(1);
            n507 = (GImage)GetChildAt(2);
            n508 = (GImage)GetChildAt(3);
            n518 = (GImage)GetChildAt(4);
            exhibitList = (GList)GetChildAt(5);
            level_btn = (greenLongMoneyBtn)GetChildAt(6);
            n513 = (GImage)GetChildAt(7);
            n514 = (GImage)GetChildAt(8);
            n515 = (GImage)GetChildAt(9);
            n516 = (GImage)GetChildAt(10);
            txt_curlv = (GTextField)GetChildAt(11);
            txt_nextLv = (GTextField)GetChildAt(12);
            n173 = (GImage)GetChildAt(13);
            txt_title_1 = (GTextField)GetChildAt(14);
            txt_title_2 = (GTextField)GetChildAt(15);
            txt_title_3 = (GTextField)GetChildAt(16);
            txt_title_4 = (GTextField)GetChildAt(17);
            txt_title_1_1 = (GTextField)GetChildAt(18);
            txt_title_2_1 = (GTextField)GetChildAt(19);
            txt_title_3_1 = (GTextField)GetChildAt(20);
            txt_title_4_1 = (GTextField)GetChildAt(21);
            count_txt_1 = (GTextField)GetChildAt(22);
            time_txt_1 = (GTextField)GetChildAt(23);
            times_txt_1 = (GTextField)GetChildAt(24);
            onecount_txt_1 = (GTextField)GetChildAt(25);
            count_txt_2 = (GTextField)GetChildAt(26);
            time_txt_2 = (GTextField)GetChildAt(27);
            times_txt_2 = (GTextField)GetChildAt(28);
            onecount_txt_2 = (GTextField)GetChildAt(29);
            up_1 = (GImage)GetChildAt(30);
            up_2 = (GImage)GetChildAt(31);
            up_3 = (GImage)GetChildAt(32);
            up_4 = (GImage)GetChildAt(33);
            btn_detail = (GButton)GetChildAt(34);
            txt_title_5 = (GTextField)GetChildAt(35);
            txt_title_5_1 = (GTextField)GetChildAt(36);
            tou_txt_1 = (GTextField)GetChildAt(37);
            tou_txt_2 = (GTextField)GetChildAt(38);
            up_5 = (GImage)GetChildAt(39);
            lastProperty = (GGroup)GetChildAt(40);
            levelLab = (GTextField)GetChildAt(41);
            n318 = (GGroup)GetChildAt(42);
            go_btn = (GButton)GetChildAt(43);
            go_get_btn = (GButton)GetChildAt(44);
            type_txt = (GTextField)GetChildAt(45);
            list_1 = (GList)GetChildAt(46);
            n333 = (GGroup)GetChildAt(47);
            nameBg = (GLoader)GetChildAt(48);
            ehCell = (handbookFlowerExhibit)GetChildAt(49);
            name_txt = (GTextField)GetChildAt(50);
            pendant = (GGroup)GetChildAt(51);
            rare_bg = (GLoader)GetChildAt(52);
            rare_Lab = (GTextField)GetChildAt(53);
            n522 = (GGroup)GetChildAt(54);
            share_btn = (circle_share)GetChildAt(55);
            flower_txt = (GRichTextField)GetChildAt(56);
            ls_star = (GList)GetChildAt(57);
            lb_curExp = (GTextField)GetChildAt(58);
            n451 = (GImage)GetChildAt(59);
            g_Exp = (GGroup)GetChildAt(60);
            gold_icon = (GImage)GetChildAt(61);
            lb_curGold = (GTextField)GetChildAt(62);
            g_Gold = (GGroup)GetChildAt(63);
            close_btn = (GButton)GetChildAt(64);
            n494 = (GImage)GetChildAt(65);
            unlockTimeLab = (GTextField)GetChildAt(66);
            unlockDescLab = (GTextField)GetChildAt(67);
            playerNameLab = (GTextField)GetChildAt(68);
            n498 = (GGroup)GetChildAt(69);
            leftBtn = (GButton)GetChildAt(70);
            rightBtn = (GButton)GetChildAt(71);
            n524 = (GImage)GetChildAt(72);
            haveLab = (GTextField)GetChildAt(73);
            notGet = (GGroup)GetChildAt(74);
        }
    }
}