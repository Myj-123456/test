/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class btn_close : GButton
    {
        public GImage n3;
        public const string URL = "ui://awswhm017m131yjp85j";

        public static btn_close CreateInstance()
        {
            return (btn_close)UIPackage.CreateObject("fun_Welfare", "btn_close");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}