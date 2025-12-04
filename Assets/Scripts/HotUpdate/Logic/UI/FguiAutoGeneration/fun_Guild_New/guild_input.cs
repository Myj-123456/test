/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_input : GComponent
    {
        public Controller type;
        public GLoader bg;
        public GImage n35;
        public GImage n32;
        public GImage n33;
        public GImage n26;
        public guild_icon guild_icon;
        public btn_add1 btn_add;
        public GTextField title;
        public GTextInput txt_input;
        public GRichTextField tip;
        public GRichTextField cost_num;
        public GButton btn_sure;
        public GButton close_btn;
        public GLoader cost_img;
        public btn_change btn_change;
        public const string URL = "ui://qz6135j3r9vt1ayr89e";

        public static guild_input CreateInstance()
        {
            return (guild_input)UIPackage.CreateObject("fun_Guild_New", "guild_input");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n35 = (GImage)GetChildAt(1);
            n32 = (GImage)GetChildAt(2);
            n33 = (GImage)GetChildAt(3);
            n26 = (GImage)GetChildAt(4);
            guild_icon = (guild_icon)GetChildAt(5);
            btn_add = (btn_add1)GetChildAt(6);
            title = (GTextField)GetChildAt(7);
            txt_input = (GTextInput)GetChildAt(8);
            tip = (GRichTextField)GetChildAt(9);
            cost_num = (GRichTextField)GetChildAt(10);
            btn_sure = (GButton)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            cost_img = (GLoader)GetChildAt(13);
            btn_change = (btn_change)GetChildAt(14);
        }
    }
}