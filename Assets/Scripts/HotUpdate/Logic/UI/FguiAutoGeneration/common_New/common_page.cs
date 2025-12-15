/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_page : GButton
    {
        public Controller button;
        public GImage n4;
        public GImage n5;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://mjiw43v9dhbs1yjp85l";

        public static common_page CreateInstance()
        {
            return (common_page)UIPackage.CreateObject("common_New", "common_page");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}