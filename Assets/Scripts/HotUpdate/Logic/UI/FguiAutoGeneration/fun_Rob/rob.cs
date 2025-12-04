/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob : GComponent
    {
        public Controller self_status;
        public GImage n99;
        public GImage n108;
        public GImage n104;
        public GImage n110;
        public GImage n101;
        public GImage n103;
        public GImage n102;
        public GImage n95;
        public GImage n106;
        public farm farm;
        public robbedCell cage_0;
        public robbedCell cage_2;
        public robbedCell cage_1;
        public robbedCell cage_3;
        public GComponent master_head;
        public GRichTextField lb_freedom;
        public GTextField title_txt;
        public GRichTextField lb_protect_date;
        public GRichTextField lb_protect;
        public GTextField lb_master_userName;
        public GTextField lb_robInfo;
        public GTextField lb_robTime;
        public GTextField lb_rob_status;
        public GTextField lb_shield_count;
        public GTextField countLab;
        public GTextField haveLab;
        public GLoader img_shield;
        public robTips robedTips;
        public btn_shield_switch shieldSwitch;
        public btn_logs btn_logs;
        public GButton btn_shield_plus;
        public GButton close_btn;
        public GButton btn_help;
        public GLoader pic;
        public const string URL = "ui://z1on8kwday7kpin";

        public static rob CreateInstance()
        {
            return (rob)UIPackage.CreateObject("fun_Rob", "rob");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            self_status = GetControllerAt(0);
            n99 = (GImage)GetChildAt(0);
            n108 = (GImage)GetChildAt(1);
            n104 = (GImage)GetChildAt(2);
            n110 = (GImage)GetChildAt(3);
            n101 = (GImage)GetChildAt(4);
            n103 = (GImage)GetChildAt(5);
            n102 = (GImage)GetChildAt(6);
            n95 = (GImage)GetChildAt(7);
            n106 = (GImage)GetChildAt(8);
            farm = (farm)GetChildAt(9);
            cage_0 = (robbedCell)GetChildAt(10);
            cage_2 = (robbedCell)GetChildAt(11);
            cage_1 = (robbedCell)GetChildAt(12);
            cage_3 = (robbedCell)GetChildAt(13);
            master_head = (GComponent)GetChildAt(14);
            lb_freedom = (GRichTextField)GetChildAt(15);
            title_txt = (GTextField)GetChildAt(16);
            lb_protect_date = (GRichTextField)GetChildAt(17);
            lb_protect = (GRichTextField)GetChildAt(18);
            lb_master_userName = (GTextField)GetChildAt(19);
            lb_robInfo = (GTextField)GetChildAt(20);
            lb_robTime = (GTextField)GetChildAt(21);
            lb_rob_status = (GTextField)GetChildAt(22);
            lb_shield_count = (GTextField)GetChildAt(23);
            countLab = (GTextField)GetChildAt(24);
            haveLab = (GTextField)GetChildAt(25);
            img_shield = (GLoader)GetChildAt(26);
            robedTips = (robTips)GetChildAt(27);
            shieldSwitch = (btn_shield_switch)GetChildAt(28);
            btn_logs = (btn_logs)GetChildAt(29);
            btn_shield_plus = (GButton)GetChildAt(30);
            close_btn = (GButton)GetChildAt(31);
            btn_help = (GButton)GetChildAt(32);
            pic = (GLoader)GetChildAt(33);
        }
    }
}