/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class skip_btn : GButton
    {
        public Controller button;
        public GImage n14;
        public GImage n15;
        public GTextField n12;
        public const string URL = "ui://awswhm01ux711yjp84d";

        public static skip_btn CreateInstance()
        {
            return (skip_btn)UIPackage.CreateObject("fun_Welfare", "skip_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            n12 = (GTextField)GetChildAt(2);
        }
    }
}