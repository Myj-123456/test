/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_donate : GComponent
    {
        public Controller status_share;
        public GImage n46;
        public GLoader bg;
        public GImage n48;
        public GImage n53;
        public GList list_pro;
        public GImage n54;
        public GImage n47;
        public GImage n50;
        public GButton close_btn;
        public GRichTextField tip;
        public GRichTextField txt_num_title;
        public GTextField txt_num;
        public GTextField proLab;
        public guild_donate_list_cell video_donate;
        public GList list_donate;
        public const string URL = "ui://qz6135j3r9vt1ayr89f";

        public static guild_donate CreateInstance()
        {
            return (guild_donate)UIPackage.CreateObject("fun_Guild_New", "guild_donate");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status_share = GetControllerAt(0);
            n46 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n48 = (GImage)GetChildAt(2);
            n53 = (GImage)GetChildAt(3);
            list_pro = (GList)GetChildAt(4);
            n54 = (GImage)GetChildAt(5);
            n47 = (GImage)GetChildAt(6);
            n50 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            tip = (GRichTextField)GetChildAt(9);
            txt_num_title = (GRichTextField)GetChildAt(10);
            txt_num = (GTextField)GetChildAt(11);
            proLab = (GTextField)GetChildAt(12);
            video_donate = (guild_donate_list_cell)GetChildAt(13);
            list_donate = (GList)GetChildAt(14);
        }
    }
}