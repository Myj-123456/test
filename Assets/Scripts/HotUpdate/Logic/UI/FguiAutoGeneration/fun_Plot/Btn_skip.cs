/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Plot
{
    public partial class Btn_skip : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://vucpfjl8mybl1yjp82q";

        public static Btn_skip CreateInstance()
        {
            return (Btn_skip)UIPackage.CreateObject("fun_Plot", "Btn_skip");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}