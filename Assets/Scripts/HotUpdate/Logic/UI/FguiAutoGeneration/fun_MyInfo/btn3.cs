/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class btn3 : GButton
    {
        public Controller type;
        public GImage n6;
        public GTextField titleLab;
        public GImage n14;
        public GImage n15;
        public GImage n16;
        public const string URL = "ui://ehkqmfbpiust14";

        public static btn3 CreateInstance()
        {
            return (btn3)UIPackage.CreateObject("fun_MyInfo", "btn3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            n15 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
        }
    }
}