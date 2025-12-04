/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class order_gift_button : GButton
    {
        public Controller open;
        public GImage n4;
        public GImage n1;
        public GImage n3;
        public const string URL = "ui://6euywhvrfug4gs";

        public static order_gift_button CreateInstance()
        {
            return (order_gift_button)UIPackage.CreateObject("fun_FlowerOrder", "order_gift_button");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            open = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
        }
    }
}