/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_tab_btn : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage bg;
        public GTextField title2;
        public GTextField title1;
        public GImage red_point;
        public const string URL = "ui://6wv667gutosm1ayr88t";

        public static guild_tab_btn CreateInstance()
        {
            return (guild_tab_btn)UIPackage.CreateObject("fun_Guild", "guild_tab_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            bg = (GImage)GetChildAt(1);
            title2 = (GTextField)GetChildAt(2);
            title1 = (GTextField)GetChildAt(3);
            red_point = (GImage)GetChildAt(4);
        }
    }
}