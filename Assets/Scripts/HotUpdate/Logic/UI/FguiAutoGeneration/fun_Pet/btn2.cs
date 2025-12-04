/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class btn2 : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://o7kmyysdx92m2s";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_Pet", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}