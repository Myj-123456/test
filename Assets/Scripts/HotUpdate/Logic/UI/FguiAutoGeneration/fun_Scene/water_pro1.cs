/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class water_pro1 : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://dpcxz2fiv01m2y";

        public static water_pro1 CreateInstance()
        {
            return (water_pro1)UIPackage.CreateObject("fun_Scene", "water_pro1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}