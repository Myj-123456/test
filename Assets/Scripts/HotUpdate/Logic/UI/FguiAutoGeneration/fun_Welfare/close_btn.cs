/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class close_btn : GButton
    {
        public GImage n0;
        public const string URL = "ui://awswhm01g0s05";

        public static close_btn CreateInstance()
        {
            return (close_btn)UIPackage.CreateObject("fun_Welfare", "close_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}