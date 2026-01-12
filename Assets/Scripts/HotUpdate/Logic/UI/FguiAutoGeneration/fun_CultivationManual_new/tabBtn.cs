/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n24;
        public GImage n26;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://ekoic0wriust1yjp7sq";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("fun_CultivationManual_new", "tabBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n24 = (GImage)GetChildAt(0);
            n26 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}