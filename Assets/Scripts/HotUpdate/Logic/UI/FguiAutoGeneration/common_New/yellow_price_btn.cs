/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class yellow_price_btn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GImage n9;
        public const string URL = "ui://mjiw43v9kelj1yjp84y";

        public static yellow_price_btn CreateInstance()
        {
            return (yellow_price_btn)UIPackage.CreateObject("common_New", "yellow_price_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
        }
    }
}