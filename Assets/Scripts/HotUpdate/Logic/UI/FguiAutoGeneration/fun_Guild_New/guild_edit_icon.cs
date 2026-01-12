/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_edit_icon : GComponent
    {
        public GLoader bg;
        public GImage n21;
        public GImage n22;
        public GImage n15;
        public GImage n16;
        public GImage n19;
        public GImage n20;
        public guild_icon guild_icon;
        public GTextField icon_title;
        public GTextField bg_title;
        public GList icon_list;
        public GList bg_list;
        public GButton close_btn;
        public GButton btn_right;
        public GButton btn_left;
        public GButton btn_sure;
        public GTextField txt_Title;
        public GImage n18;
        public const string URL = "ui://qz6135j3s62s1yjp7z1";

        public static guild_edit_icon CreateInstance()
        {
            return (guild_edit_icon)UIPackage.CreateObject("fun_Guild_New", "guild_edit_icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n21 = (GImage)GetChildAt(1);
            n22 = (GImage)GetChildAt(2);
            n15 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n19 = (GImage)GetChildAt(5);
            n20 = (GImage)GetChildAt(6);
            guild_icon = (guild_icon)GetChildAt(7);
            icon_title = (GTextField)GetChildAt(8);
            bg_title = (GTextField)GetChildAt(9);
            icon_list = (GList)GetChildAt(10);
            bg_list = (GList)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            btn_right = (GButton)GetChildAt(13);
            btn_left = (GButton)GetChildAt(14);
            btn_sure = (GButton)GetChildAt(15);
            txt_Title = (GTextField)GetChildAt(16);
            n18 = (GImage)GetChildAt(17);
        }
    }
}