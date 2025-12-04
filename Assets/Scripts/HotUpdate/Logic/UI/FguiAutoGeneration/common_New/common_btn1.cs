/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_btn1 : GButton
    {
        public GImage n0;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://mjiw43v9u25n1yjp843";

        public static common_btn1 CreateInstance()
        {
            return (common_btn1)UIPackage.CreateObject("common_New", "common_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}