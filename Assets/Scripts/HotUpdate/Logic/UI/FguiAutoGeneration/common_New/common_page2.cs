/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_page2 : GButton
    {
        public Controller button;
        public Controller type;
        public GImage n0;
        public GImage n1;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GTextField titleLab2;
        public const string URL = "ui://mjiw43v9rb3e1yjp86g";

        public static common_page2 CreateInstance()
        {
            return (common_page2)UIPackage.CreateObject("common_New", "common_page2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            type = GetControllerAt(1);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
            titleLab2 = (GTextField)GetChildAt(4);
        }
    }
}