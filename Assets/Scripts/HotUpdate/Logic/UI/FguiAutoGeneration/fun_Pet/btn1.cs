/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class btn1 : GButton
    {
        public GImage n1;
        public GTextField titleLab;
        public const string URL = "ui://o7kmyysdx92m1j";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_Pet", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}