/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_flowerLs : GComponent
    {
        public GImage n32;
        public GImage n37;
        public GImage n35;
        public GButton close_btn;
        public GRichTextField lb_tip;
        public GButton btn_edit;
        public GTextField lb_pageCount;
        public GList list;
        public GButton btn_turn_left;
        public GButton btn_turn_right;
        public GTextField titleLab;
        public const string URL = "ui://zuzhxc13s3bkpnr";

        public static flowerShare_flowerLs CreateInstance()
        {
            return (flowerShare_flowerLs)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_flowerLs");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n32 = (GImage)GetChildAt(0);
            n37 = (GImage)GetChildAt(1);
            n35 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            lb_tip = (GRichTextField)GetChildAt(4);
            btn_edit = (GButton)GetChildAt(5);
            lb_pageCount = (GTextField)GetChildAt(6);
            list = (GList)GetChildAt(7);
            btn_turn_left = (GButton)GetChildAt(8);
            btn_turn_right = (GButton)GetChildAt(9);
            titleLab = (GTextField)GetChildAt(10);
        }
    }
}