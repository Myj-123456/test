/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class pro1 : GProgressBar
    {
        public GImage n4;
        public GImage bar;
        public const string URL = "ui://awswhm01g0s019";

        public static pro1 CreateInstance()
        {
            return (pro1)UIPackage.CreateObject("fun_Welfare", "pro1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}