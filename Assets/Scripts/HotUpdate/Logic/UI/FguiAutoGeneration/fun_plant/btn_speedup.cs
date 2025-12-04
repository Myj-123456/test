/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_plant
{
    public partial class btn_speedup : GButton
    {
        public Controller state;
        public GImage n4;
        public GImage n9;
        public GTextField lb_count;
        public GTextField titleLab;
        public const string URL = "ui://4905g7p7nwd51e";

        public static btn_speedup CreateInstance()
        {
            return (btn_speedup)UIPackage.CreateObject("fun_plant", "btn_speedup");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            lb_count = (GTextField)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}