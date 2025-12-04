/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_manager : GComponent
    {
        public Controller status;
        public GImage n41;
        public GButton close_btn;
        public GTextField titleLab;
        public GRichTextField lb_tip;
        public GList list;
        public GButton btn_turn_right;
        public GButton btn_turn_left;
        public flowerShare_manager_0 panel_flower;
        public flowerShare_manager_1 panel_desc;
        public GButton btn_logs;
        public const string URL = "ui://zuzhxc13s3bkpnx";

        public static flowerShare_manager CreateInstance()
        {
            return (flowerShare_manager)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_manager");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n41 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            lb_tip = (GRichTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            btn_turn_right = (GButton)GetChildAt(5);
            btn_turn_left = (GButton)GetChildAt(6);
            panel_flower = (flowerShare_manager_0)GetChildAt(7);
            panel_desc = (flowerShare_manager_1)GetChildAt(8);
            btn_logs = (GButton)GetChildAt(9);
        }
    }
}