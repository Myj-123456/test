/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class probar2 : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://argzn455m3gh4x";

        public static probar2 CreateInstance()
        {
            return (probar2)UIPackage.CreateObject("fun_Dress", "probar2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}