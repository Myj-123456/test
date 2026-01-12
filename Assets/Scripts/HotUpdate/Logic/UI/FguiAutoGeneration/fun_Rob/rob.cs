/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob : GComponent
    {
        public Controller self_status;
        public GLoader bg;
        public GLoader bg2;
        public GImage n127;
        public GTextField title_txt;
        public GImage n101;
        public GImage n126;
        public btn_shield_plus btn_shield_plus;
        public btn_shield_switch shieldSwitch;
        public GRichTextField lb_freedom;
        public GRichTextField lb_protect_date;
        public GRichTextField lb_protect;
        public GTextField lb_master_userName;
        public GTextField lb_robTime;
        public GTextField lb_rob_status;
        public GComponent master_head;
        public btn_videos btn_videos;
        public btn_logs btn_logs;
        public farm farm;
        public robbedCell cage_0;
        public robbedCell cage_1;
        public robbedCell cage_2;
        public robbedCell cage_3;
        public GImage n117;
        public GImage n116;
        public GButton btn_help;
        public GImage n95;
        public GTextField countLab;
        public GLoader pic;
        public btn_close close_btn;
        public btn_open btn_open;
        public btn_openTen btn_openTen;
        public const string URL = "ui://z1on8kwday7kpin";

        public static rob CreateInstance()
        {
            return (rob)UIPackage.CreateObject("fun_Rob", "rob");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            self_status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg2 = (GLoader)GetChildAt(1);
            n127 = (GImage)GetChildAt(2);
            title_txt = (GTextField)GetChildAt(3);
            n101 = (GImage)GetChildAt(4);
            n126 = (GImage)GetChildAt(5);
            btn_shield_plus = (btn_shield_plus)GetChildAt(6);
            shieldSwitch = (btn_shield_switch)GetChildAt(7);
            lb_freedom = (GRichTextField)GetChildAt(8);
            lb_protect_date = (GRichTextField)GetChildAt(9);
            lb_protect = (GRichTextField)GetChildAt(10);
            lb_master_userName = (GTextField)GetChildAt(11);
            lb_robTime = (GTextField)GetChildAt(12);
            lb_rob_status = (GTextField)GetChildAt(13);
            master_head = (GComponent)GetChildAt(14);
            btn_videos = (btn_videos)GetChildAt(15);
            btn_logs = (btn_logs)GetChildAt(16);
            farm = (farm)GetChildAt(17);
            cage_0 = (robbedCell)GetChildAt(18);
            cage_1 = (robbedCell)GetChildAt(19);
            cage_2 = (robbedCell)GetChildAt(20);
            cage_3 = (robbedCell)GetChildAt(21);
            n117 = (GImage)GetChildAt(22);
            n116 = (GImage)GetChildAt(23);
            btn_help = (GButton)GetChildAt(24);
            n95 = (GImage)GetChildAt(25);
            countLab = (GTextField)GetChildAt(26);
            pic = (GLoader)GetChildAt(27);
            close_btn = (btn_close)GetChildAt(28);
            btn_open = (btn_open)GetChildAt(29);
            btn_openTen = (btn_openTen)GetChildAt(30);
        }
    }
}