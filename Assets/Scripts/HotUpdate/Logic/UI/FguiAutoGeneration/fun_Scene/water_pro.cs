/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class water_pro : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://dpcxz2fikkb12n";

        public static water_pro CreateInstance()
        {
            return (water_pro)UIPackage.CreateObject("fun_Scene", "water_pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}