/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class bloodbar : GProgressBar
    {
        public Controller c1;
        public GImage n2;
        public GImage bar;
        public const string URL = "ui://z1b78orpf3otd";

        public static bloodbar CreateInstance()
        {
            return (bloodbar)UIPackage.CreateObject("fun_Battle", "bloodbar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}