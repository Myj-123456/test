/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_page1 : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n1;
        public GTextField titleLab;
        public GTextField titleLab1;
        public const string URL = "ui://mjiw43v9dhbs1yjp863";

        public static common_page1 CreateInstance()
        {
            return (common_page1)UIPackage.CreateObject("common_New", "common_page1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
        }
    }
}