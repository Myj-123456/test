/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_player_head : GComponent
    {
        public GLoader imgLoader;
        public GComponent picFrame;
        public GImage bg_lv;
        public GTextField txt_lv;
        public const string URL = "ui://qz6135j3r9vt1ayr89j";

        public static guild_player_head CreateInstance()
        {
            return (guild_player_head)UIPackage.CreateObject("fun_Guild_New", "guild_player_head");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            imgLoader = (GLoader)GetChildAt(0);
            picFrame = (GComponent)GetChildAt(1);
            bg_lv = (GImage)GetChildAt(2);
            txt_lv = (GTextField)GetChildAt(3);
        }
    }
}