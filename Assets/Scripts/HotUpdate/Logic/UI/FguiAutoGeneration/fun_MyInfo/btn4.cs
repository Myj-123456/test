/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class btn4 : GButton
    {
        public Controller type;
        public GImage n6;
        public GImage n14;
        public GTextField titleLab;
        public const string URL = "ui://ehkqmfbpj9p61yjp7xl";

        public static btn4 CreateInstance()
        {
            return (btn4)UIPackage.CreateObject("fun_MyInfo", "btn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}