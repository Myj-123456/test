/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class pro : GProgressBar
    {
        public GImage n1;
        public GImage bar;
        public const string URL = "ui://awswhm01g0s08";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_Welfare", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}