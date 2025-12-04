/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class chose_quality_item : GButton
    {
        public Controller button;
        public GImage n5;
        public GImage n6;
        public GTextField titileLab;
        public const string URL = "ui://pcr735xhcs1m1yjp7wl";

        public static chose_quality_item CreateInstance()
        {
            return (chose_quality_item)UIPackage.CreateObject("fun_Customer", "chose_quality_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            titileLab = (GTextField)GetChildAt(2);
        }
    }
}