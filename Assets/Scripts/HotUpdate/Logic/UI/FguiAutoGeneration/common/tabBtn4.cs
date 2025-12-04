/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class tabBtn4 : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage n5;
        public GRichTextField titleLab;
        public const string URL = "ui://6bdpq80knwgi1yjp7rk";

        public static tabBtn4 CreateInstance()
        {
            return (tabBtn4)UIPackage.CreateObject("common", "tabBtn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GRichTextField)GetChildAt(2);
        }
    }
}