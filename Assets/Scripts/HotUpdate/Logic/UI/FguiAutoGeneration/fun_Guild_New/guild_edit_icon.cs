/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_edit_icon : GComponent
    {
        public GImage n3;
        public GLoader bg;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public guild_icon guild_icon;
        public GTextField icon_title;
        public GTextField bg_title;
        public GList icon_list;
        public GList bg_list;
        public GButton close_btn;
        public GButton btn_left;
        public GButton btn_right;
        public GButton btn_sure;
        public const string URL = "ui://qz6135j3s62s1yjp7z1";

        public static guild_edit_icon CreateInstance()
        {
            return (guild_edit_icon)UIPackage.CreateObject("fun_Guild_New", "guild_edit_icon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            guild_icon = (guild_icon)GetChildAt(5);
            icon_title = (GTextField)GetChildAt(6);
            bg_title = (GTextField)GetChildAt(7);
            icon_list = (GList)GetChildAt(8);
            bg_list = (GList)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            btn_left = (GButton)GetChildAt(11);
            btn_right = (GButton)GetChildAt(12);
            btn_sure = (GButton)GetChildAt(13);
        }
    }
}