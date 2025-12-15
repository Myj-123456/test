/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_btn2 : GButton
    {
        public GImage n3;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://mjiw43v9dhbs1yjp85j";

        public static common_btn2 CreateInstance()
        {
            return (common_btn2)UIPackage.CreateObject("common_New", "common_btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}