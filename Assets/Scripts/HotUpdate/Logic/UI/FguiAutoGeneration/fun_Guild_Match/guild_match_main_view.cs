/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class guild_match_main_view : GComponent
    {
        public Controller status;
        public Controller showChose;
        public Controller showBtn;
        public GLoader bg;
        public GLoader3D spine;
        public GImage n8;
        public GImage n13;
        public GImage n19;
        public GButton help_btn;
        public GTextField title_txt;
        public GTextField rankLab;
        public GTextField rankNum;
        public GTextField unlockLab;
        public GGroup n39;
        public GList list;
        public GImage n25;
        public GImage n26;
        public GTextField showLab;
        public GTextField timeLab;
        public GGroup n30;
        public match_btn task_btn;
        public match_btn score_btn;
        public match_btn rank_btn;
        public match_btn flower_btn;
        public GGroup n38;
        public GButton close_btn;
        public GImage n16;
        public GImage n17;
        public GImage n22;
        public pro_content proGrp;
        public GTextField scoreNum;
        public GTextField limitLab;
        public chose_quailty_btn chose_btn;
        public chose_qualirt chose_grp;
        public GGroup n41;
        public const string URL = "ui://qefze8qitewh0";

        public static guild_match_main_view CreateInstance()
        {
            return (guild_match_main_view)UIPackage.CreateObject("fun_Guild_Match", "guild_match_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            showChose = GetControllerAt(1);
            showBtn = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            spine = (GLoader3D)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
            n13 = (GImage)GetChildAt(3);
            n19 = (GImage)GetChildAt(4);
            help_btn = (GButton)GetChildAt(5);
            title_txt = (GTextField)GetChildAt(6);
            rankLab = (GTextField)GetChildAt(7);
            rankNum = (GTextField)GetChildAt(8);
            unlockLab = (GTextField)GetChildAt(9);
            n39 = (GGroup)GetChildAt(10);
            list = (GList)GetChildAt(11);
            n25 = (GImage)GetChildAt(12);
            n26 = (GImage)GetChildAt(13);
            showLab = (GTextField)GetChildAt(14);
            timeLab = (GTextField)GetChildAt(15);
            n30 = (GGroup)GetChildAt(16);
            task_btn = (match_btn)GetChildAt(17);
            score_btn = (match_btn)GetChildAt(18);
            rank_btn = (match_btn)GetChildAt(19);
            flower_btn = (match_btn)GetChildAt(20);
            n38 = (GGroup)GetChildAt(21);
            close_btn = (GButton)GetChildAt(22);
            n16 = (GImage)GetChildAt(23);
            n17 = (GImage)GetChildAt(24);
            n22 = (GImage)GetChildAt(25);
            proGrp = (pro_content)GetChildAt(26);
            scoreNum = (GTextField)GetChildAt(27);
            limitLab = (GTextField)GetChildAt(28);
            chose_btn = (chose_quailty_btn)GetChildAt(29);
            chose_grp = (chose_qualirt)GetChildAt(30);
            n41 = (GGroup)GetChildAt(31);
        }
    }
}