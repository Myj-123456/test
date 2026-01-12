/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerOrder
{
    public partial class order_close : GButton
    {
        public GImage n3;
        public const string URL = "ui://6euywhvrc1iu1ayr8g6";

        public static order_close CreateInstance()
        {
            return (order_close)UIPackage.CreateObject("fun_FlowerOrder", "order_close");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}