/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_loading
{
    public partial class ProgressBar : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://t3mkt5pwoyy17";

        public static ProgressBar CreateInstance()
        {
            return (ProgressBar)UIPackage.CreateObject("fun_loading", "ProgressBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}