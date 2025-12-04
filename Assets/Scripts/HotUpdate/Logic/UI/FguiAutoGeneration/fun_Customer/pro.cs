/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class pro : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://pcr735xhcs1m3";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_Customer", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}