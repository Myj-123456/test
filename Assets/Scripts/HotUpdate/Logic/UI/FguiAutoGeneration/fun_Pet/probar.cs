/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class probar : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://o7kmyysdx92m1yjp7xr";

        public static probar CreateInstance()
        {
            return (probar)UIPackage.CreateObject("fun_Pet", "probar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}