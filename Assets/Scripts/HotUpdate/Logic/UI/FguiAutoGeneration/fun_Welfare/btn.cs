/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class btn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://awswhm01g0s01yjp83p";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Welfare", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}