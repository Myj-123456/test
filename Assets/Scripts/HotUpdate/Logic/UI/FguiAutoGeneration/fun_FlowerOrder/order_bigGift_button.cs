/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class order_bigGift_button : GButton
    {
        public Controller open;
        public GImage n9;
        public GImage n7;
        public GImage n8;
        public const string URL = "ui://6euywhvrpxhsnsp";

        public static order_bigGift_button CreateInstance()
        {
            return (order_bigGift_button)UIPackage.CreateObject("fun_FlowerOrder", "order_bigGift_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            open = GetControllerAt(0);
            n9 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
        }
    }
}