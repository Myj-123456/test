/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_shop_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GImage n5;
        public GImage n6;
        public GImage n12;
        public GImage n7;
        public GImage n9;
        public GImage n13;
        public GImage n8;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://qz6135j3tewh1yjp7zy";

        public static guild_shop_view CreateInstance()
        {
            return (guild_shop_view)UIPackage.CreateObject("fun_Guild_New", "guild_shop_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n12 = (GImage)GetChildAt(4);
            n7 = (GImage)GetChildAt(5);
            n9 = (GImage)GetChildAt(6);
            n13 = (GImage)GetChildAt(7);
            n8 = (GImage)GetChildAt(8);
            list = (GList)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
        }
    }
}