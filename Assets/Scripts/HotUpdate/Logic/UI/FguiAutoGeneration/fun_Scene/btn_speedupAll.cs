/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class btn_speedupAll : GButton
    {
        public GImage n4;
        public GImage n15;
        public GTextField lb_count;
        public GImage n10;
        public GTextField titleLab;
        public const string URL = "ui://dpcxz2finwd51f";

        public static btn_speedupAll CreateInstance()
        {
            return (btn_speedupAll)UIPackage.CreateObject("fun_Scene", "btn_speedupAll");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            lb_count = (GTextField)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
        }
    }
}