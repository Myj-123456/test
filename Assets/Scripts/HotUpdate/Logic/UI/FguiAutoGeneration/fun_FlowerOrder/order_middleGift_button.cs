/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class order_middleGift_button : GButton
    {
        public Controller open;
        public GImage n5;
        public GImage n1;
        public GImage n4;
        public const string URL = "ui://6euywhvrohazo94";

        public static order_middleGift_button CreateInstance()
        {
            return (order_middleGift_button)UIPackage.CreateObject("fun_FlowerOrder", "order_middleGift_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            open = GetControllerAt(0);
            n5 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
        }
    }
}