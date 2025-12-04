/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class pro : GProgressBar
    {
        public GImage n4;
        public GImage bar;
        public const string URL = "ui://qefze8qitewh2";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_Guild_Match", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}