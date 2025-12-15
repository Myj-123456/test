/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class get_btn : GButton
    {
        public Controller button;
        public GImage n15;
        public GTextField n16;
        public const string URL = "ui://awswhm01r31c1yjp84q";

        public static get_btn CreateInstance()
        {
            return (get_btn)UIPackage.CreateObject("fun_Welfare", "get_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n15 = (GImage)GetChildAt(0);
            n16 = (GTextField)GetChildAt(1);
        }
    }
}