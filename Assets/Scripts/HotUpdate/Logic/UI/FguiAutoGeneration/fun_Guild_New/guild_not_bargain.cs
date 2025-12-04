/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_not_bargain : GComponent
    {
        public GImage n5;
        public GLoader bg;
        public GImage n2;
        public GTextField name_title;
        public GTextField time_title;
        public GTextField txt_title;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://qz6135j3s62s1yjp7z4";

        public static guild_not_bargain CreateInstance()
        {
            return (guild_not_bargain)UIPackage.CreateObject("fun_Guild_New", "guild_not_bargain");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            name_title = (GTextField)GetChildAt(3);
            time_title = (GTextField)GetChildAt(4);
            txt_title = (GTextField)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            list = (GList)GetChildAt(7);
        }
    }
}