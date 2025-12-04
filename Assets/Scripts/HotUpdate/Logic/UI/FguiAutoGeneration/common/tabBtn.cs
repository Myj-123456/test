/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage n5;
        public GTextField titleLab;
        public const string URL = "ui://6bdpq80knwgi1yjp7qx";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("common", "tabBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}