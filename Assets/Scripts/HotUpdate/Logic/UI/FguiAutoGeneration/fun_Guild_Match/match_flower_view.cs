/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_flower_view : GComponent
    {
        public GLoader bg;
        public GImage n8;
        public GTextField txt_Title;
        public GImage n10;
        public GImage n4;
        public GTextField tipLab;
        public GButton close_btn;
        public GList list;
        public const string URL = "ui://qefze8qir0nz3n";

        public static match_flower_view CreateInstance()
        {
            return (match_flower_view)UIPackage.CreateObject("fun_Guild_Match", "match_flower_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n8 = (GImage)GetChildAt(1);
            txt_Title = (GTextField)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            list = (GList)GetChildAt(7);
        }
    }
}