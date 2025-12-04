/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild : GComponent
    {
        public guildScroll main;
        public GTextField title_txt;
        public GImage n1;
        public GButton help_btn;
        public GGroup n38;
        public guild_info info;
        public btn_turn btn_turn;
        public GGroup n62;
        public GButton close_btn;
        public chatUI ui_chat;
        public GGroup n67;
        public btn_common btn_manger;
        public btn_common btn_donate;
        public btn_common btn_home;
        public GGroup n69;
        public const string URL = "ui://qz6135j3j8rp1ayr89l";

        public static guild CreateInstance()
        {
            return (guild)UIPackage.CreateObject("fun_Guild_New", "guild");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            main = (guildScroll)GetChildAt(0);
            title_txt = (GTextField)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            n38 = (GGroup)GetChildAt(4);
            info = (guild_info)GetChildAt(5);
            btn_turn = (btn_turn)GetChildAt(6);
            n62 = (GGroup)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            ui_chat = (chatUI)GetChildAt(9);
            n67 = (GGroup)GetChildAt(10);
            btn_manger = (btn_common)GetChildAt(11);
            btn_donate = (btn_common)GetChildAt(12);
            btn_home = (btn_common)GetChildAt(13);
            n69 = (GGroup)GetChildAt(14);
        }
    }
}