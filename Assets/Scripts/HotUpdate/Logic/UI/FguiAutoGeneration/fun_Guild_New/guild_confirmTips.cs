/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guild_confirmTips : GComponent
    {
        public GImage n32;
        public GLoader bg;
        public GImage n39;
        public GImage n31;
        public GButton btn_confirm;
        public GButton btn_cancel;
        public GTextField tip_title;
        public GRichTextField content;
        public GRichTextField content_info;
        public GImage n34;
        public GLoader pic;
        public const string URL = "ui://qz6135j3s62s1yjp7yz";

        public static guild_confirmTips CreateInstance()
        {
            return (guild_confirmTips)UIPackage.CreateObject("fun_Guild_New", "guild_confirmTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n32 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n39 = (GImage)GetChildAt(2);
            n31 = (GImage)GetChildAt(3);
            btn_confirm = (GButton)GetChildAt(4);
            btn_cancel = (GButton)GetChildAt(5);
            tip_title = (GTextField)GetChildAt(6);
            content = (GRichTextField)GetChildAt(7);
            content_info = (GRichTextField)GetChildAt(8);
            n34 = (GImage)GetChildAt(9);
            pic = (GLoader)GetChildAt(10);
        }
    }
}