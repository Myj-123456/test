/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class clickVideoBtn1 : GButton
    {
        public GImage n6;
        public GImage n9;
        public GTextField titleLab;
        public const string URL = "ui://mjiw43v9v01m1yjp83x";

        public static clickVideoBtn1 CreateInstance()
        {
            return (clickVideoBtn1)UIPackage.CreateObject("common_New", "clickVideoBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}