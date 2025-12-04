/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Gift
{
    public partial class guild_gift_view : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n9;
        public GImage n10;
        public order_progress pro;
        public GImage n17;
        public GImage n18;
        public GImage n14;
        public GButton help_btn;
        public GLoader icon;
        public GTextField big_gift_name;
        public GTextField title_txt;
        public GTextField proLab;
        public GGroup n22;
        public GImage n21;
        public GImage n20;
        public GButton nomal_btn;
        public GButton rare_btn;
        public GGroup n23;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://qca8xihatewh0";

        public static guild_gift_view CreateInstance()
        {
            return (guild_gift_view)UIPackage.CreateObject("fun_Guild_Gift", "guild_gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
            pro = (order_progress)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            n18 = (GImage)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            help_btn = (GButton)GetChildAt(7);
            icon = (GLoader)GetChildAt(8);
            big_gift_name = (GTextField)GetChildAt(9);
            title_txt = (GTextField)GetChildAt(10);
            proLab = (GTextField)GetChildAt(11);
            n22 = (GGroup)GetChildAt(12);
            n21 = (GImage)GetChildAt(13);
            n20 = (GImage)GetChildAt(14);
            nomal_btn = (GButton)GetChildAt(15);
            rare_btn = (GButton)GetChildAt(16);
            n23 = (GGroup)GetChildAt(17);
            list = (GList)GetChildAt(18);
            close_btn = (GButton)GetChildAt(19);
        }
    }
}