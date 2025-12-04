/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_help_view_new : GComponent
    {
        public GLoader bg;
        public GImage n29;
        public GLoader img;
        public GTextField txt_title;
        public GButton close_btn;
        public const string URL = "ui://6q8q1ai6kbinwprf";

        public static handbook_help_view_new CreateInstance()
        {
            return (handbook_help_view_new)UIPackage.CreateObject("fun_CultivationManual", "handbook_help_view_new");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n29 = (GImage)GetChildAt(1);
            img = (GLoader)GetChildAt(2);
            txt_title = (GTextField)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
        }
    }
}