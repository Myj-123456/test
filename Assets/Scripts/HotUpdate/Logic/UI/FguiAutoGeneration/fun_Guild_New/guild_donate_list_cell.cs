/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_donate_list_cell : GComponent
    {
        public Controller donateType;
        public GImage n35;
        public GImage n37;
        public GImage n38;
        public GRichTextField txt_content;
        public GRichTextField txt_reward_title;
        public GList list;
        public GButton btn_donate;
        public GButton btn_video;
        public const string URL = "ui://qz6135j3r9vt1ayr89g";

        public static guild_donate_list_cell CreateInstance()
        {
            return (guild_donate_list_cell)UIPackage.CreateObject("fun_Guild_New", "guild_donate_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            donateType = GetControllerAt(0);
            n35 = (GImage)GetChildAt(0);
            n37 = (GImage)GetChildAt(1);
            n38 = (GImage)GetChildAt(2);
            txt_content = (GRichTextField)GetChildAt(3);
            txt_reward_title = (GRichTextField)GetChildAt(4);
            list = (GList)GetChildAt(5);
            btn_donate = (GButton)GetChildAt(6);
            btn_video = (GButton)GetChildAt(7);
        }
    }
}