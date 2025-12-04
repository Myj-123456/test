/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_members : GComponent
    {
        public GImage n3;
        public GLoader bg;
        public GImage n6;
        public GList list_players;
        public GButton close_btn;
        public const string URL = "ui://qz6135j3j8rp1ayr89b";

        public static guild_members CreateInstance()
        {
            return (guild_members)UIPackage.CreateObject("fun_Guild_New", "guild_members");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            list_players = (GList)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
        }
    }
}