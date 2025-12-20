/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob : GComponent
    {
        public Controller self_status;
        public GLoader n113;
        public GLoader n114;
        public GImage n101;
        public GImage n126;
        public GImage n117;
        public GImage n116;
        public GImage n95;
        public farm farm;
        public robbedCell cage_0;
        public robbedCell cage_1;
        public robbedCell cage_2;
        public robbedCell cage_3;
        public GComponent master_head;
        public GRichTextField lb_freedom;
        public GTextField title_txt;
        public GRichTextField lb_protect_date;
        public GRichTextField lb_protect;
        public GTextField lb_master_userName;
        public GTextField lb_robTime;
        public GTextField lb_rob_status;
        public GTextField countLab;
        public GImage n118;
        public btn_logs btn_logs;
        public btn_shield_plus btn_shield_plus;
        public btn_shield_switch shieldSwitch;
        public btn_close close_btn;
        public GButton btn_help;
        public btn_open btn_open;
        public btn_openTen btn_openTen;
        public GImage n127;
        public btn_videos n128;
        public const string URL = "ui://z1on8kwday7kpin";

        public static rob CreateInstance()
        {
            return (rob)UIPackage.CreateObject("fun_Rob", "rob");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            self_status = GetControllerAt(0);
            n113 = (GLoader)GetChildAt(0);
            n114 = (GLoader)GetChildAt(1);
            n101 = (GImage)GetChildAt(2);
            n126 = (GImage)GetChildAt(3);
            n117 = (GImage)GetChildAt(4);
            n116 = (GImage)GetChildAt(5);
            n95 = (GImage)GetChildAt(6);
            farm = (farm)GetChildAt(7);
            cage_0 = (robbedCell)GetChildAt(8);
            cage_1 = (robbedCell)GetChildAt(9);
            cage_2 = (robbedCell)GetChildAt(10);
            cage_3 = (robbedCell)GetChildAt(11);
            master_head = (GComponent)GetChildAt(12);
            lb_freedom = (GRichTextField)GetChildAt(13);
            title_txt = (GTextField)GetChildAt(14);
            lb_protect_date = (GRichTextField)GetChildAt(15);
            lb_protect = (GRichTextField)GetChildAt(16);
            lb_master_userName = (GTextField)GetChildAt(17);
            lb_robTime = (GTextField)GetChildAt(18);
            lb_rob_status = (GTextField)GetChildAt(19);
            countLab = (GTextField)GetChildAt(20);
            n118 = (GImage)GetChildAt(21);
            btn_logs = (btn_logs)GetChildAt(22);
            btn_shield_plus = (btn_shield_plus)GetChildAt(23);
            shieldSwitch = (btn_shield_switch)GetChildAt(24);
            close_btn = (btn_close)GetChildAt(25);
            btn_help = (GButton)GetChildAt(26);
            btn_open = (btn_open)GetChildAt(27);
            btn_openTen = (btn_openTen)GetChildAt(28);
            n127 = (GImage)GetChildAt(29);
            n128 = (btn_videos)GetChildAt(30);
        }
    }
}