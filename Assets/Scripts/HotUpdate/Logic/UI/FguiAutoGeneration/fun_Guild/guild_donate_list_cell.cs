/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_donate_list_cell : GComponent
    {
        public Controller donateType;
        public GImage n35;
        public GImage n38;
        public GRichTextField txt_content;
        public GRichTextField txt_reward_title;
        public GList list;
        public GButton btn_donate;
        public GButton btn_video;
        public const string URL = "ui://6wv667guznnbpfe";

        public static guild_donate_list_cell CreateInstance()
        {
            return (guild_donate_list_cell)UIPackage.CreateObject("fun_Guild", "guild_donate_list_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            donateType = GetControllerAt(0);
            n35 = (GImage)GetChildAt(0);
            n38 = (GImage)GetChildAt(1);
            txt_content = (GRichTextField)GetChildAt(2);
            txt_reward_title = (GRichTextField)GetChildAt(3);
            list = (GList)GetChildAt(4);
            btn_donate = (GButton)GetChildAt(5);
            btn_video = (GButton)GetChildAt(6);
        }
    }
}