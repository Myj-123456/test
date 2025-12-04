/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class guild_leave : GComponent
    {
        public GImage n10;
        public GImage n5;
        public GButton btn_sure;
        public GButton btn_cancel;
        public GButton closeBtn;
        public GTextField title_txt;
        public GTextField explain_txt;
        public GTextField title_tip;
        public const string URL = "ui://6wv667guxvu71ayr7x7";

        public static guild_leave CreateInstance()
        {
            return (guild_leave)UIPackage.CreateObject("fun_Guild", "guild_leave");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n10 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            btn_sure = (GButton)GetChildAt(2);
            btn_cancel = (GButton)GetChildAt(3);
            closeBtn = (GButton)GetChildAt(4);
            title_txt = (GTextField)GetChildAt(5);
            explain_txt = (GTextField)GetChildAt(6);
            title_tip = (GTextField)GetChildAt(7);
        }
    }
}