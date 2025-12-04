/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_donate : GComponent
    {
        public Controller status_share;
        public GImage n43;
        public GButton close_btn;
        public GList list_donate;
        public GRichTextField tip;
        public GTextField txt_title_donate;
        public GRichTextField txt_num_title;
        public guild_donate_list_cell video_donate;
        public const string URL = "ui://6wv667guznnbpfd";

        public static guild_donate CreateInstance()
        {
            return (guild_donate)UIPackage.CreateObject("fun_Guild", "guild_donate");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status_share = GetControllerAt(0);
            n43 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            list_donate = (GList)GetChildAt(2);
            tip = (GRichTextField)GetChildAt(3);
            txt_title_donate = (GTextField)GetChildAt(4);
            txt_num_title = (GRichTextField)GetChildAt(5);
            video_donate = (guild_donate_list_cell)GetChildAt(6);
        }
    }
}