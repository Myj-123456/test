/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class match_flower_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n4;
        public GImage n3;
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

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            tipLab = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            list = (GList)GetChildAt(6);
        }
    }
}