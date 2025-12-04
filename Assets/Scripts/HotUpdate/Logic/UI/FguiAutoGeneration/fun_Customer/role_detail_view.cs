/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class role_detail_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GImage n7;
        public GButton info_btn;
        public GButton like_btn;
        public GButton close_btn;
        public GLoader pic;
        public GImage n15;
        public GImage n17;
        public GImage n25;
        public GImage n26;
        public GImage n27;
        public GList style_list;
        public GTextField nameLab;
        public GTextField char_title;
        public GTextField like_title;
        public GTextField ident_title;
        public GTextField char_lab;
        public GTextField like_lab;
        public GTextField ident_lab;
        public GTextField decLab;
        public GTextField gift_title;
        public GList like_list;
        public GGroup n28;
        public GList list;
        public const string URL = "ui://pcr735xhcs1m15";

        public static role_detail_view CreateInstance()
        {
            return (role_detail_view)UIPackage.CreateObject("fun_Customer", "role_detail_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            info_btn = (GButton)GetChildAt(2);
            like_btn = (GButton)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            pic = (GLoader)GetChildAt(5);
            n15 = (GImage)GetChildAt(6);
            n17 = (GImage)GetChildAt(7);
            n25 = (GImage)GetChildAt(8);
            n26 = (GImage)GetChildAt(9);
            n27 = (GImage)GetChildAt(10);
            style_list = (GList)GetChildAt(11);
            nameLab = (GTextField)GetChildAt(12);
            char_title = (GTextField)GetChildAt(13);
            like_title = (GTextField)GetChildAt(14);
            ident_title = (GTextField)GetChildAt(15);
            char_lab = (GTextField)GetChildAt(16);
            like_lab = (GTextField)GetChildAt(17);
            ident_lab = (GTextField)GetChildAt(18);
            decLab = (GTextField)GetChildAt(19);
            gift_title = (GTextField)GetChildAt(20);
            like_list = (GList)GetChildAt(21);
            n28 = (GGroup)GetChildAt(22);
            list = (GList)GetChildAt(23);
        }
    }
}