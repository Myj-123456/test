/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_enter_view : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage n5;
        public GTextField joinLab;
        public GTextField createLab;
        public btn join_btn;
        public btn create_btn;
        public GGroup n10;
        public GButton close_btn;
        public const string URL = "ui://qz6135j3v01m1yjp81d";

        public static guild_enter_view CreateInstance()
        {
            return (guild_enter_view)UIPackage.CreateObject("fun_Guild_New", "guild_enter_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            joinLab = (GTextField)GetChildAt(5);
            createLab = (GTextField)GetChildAt(6);
            join_btn = (btn)GetChildAt(7);
            create_btn = (btn)GetChildAt(8);
            n10 = (GGroup)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
        }
    }
}