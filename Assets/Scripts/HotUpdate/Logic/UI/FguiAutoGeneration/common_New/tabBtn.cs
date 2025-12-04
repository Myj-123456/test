/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage n5;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9pj271yjp7rw";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("common_New", "tabBtn");
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