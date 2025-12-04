/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class tour_gift_item : GComponent
    {
        public tour_gift_cell item1;
        public tour_gift_cell item2;
        public tour_gift_cell item3;
        public const string URL = "ui://w3ox9yltv01m1ayr83p";

        public static tour_gift_item CreateInstance()
        {
            return (tour_gift_item)UIPackage.CreateObject("fun_Recharge", "tour_gift_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            item1 = (tour_gift_cell)GetChildAt(0);
            item2 = (tour_gift_cell)GetChildAt(1);
            item3 = (tour_gift_cell)GetChildAt(2);
        }
    }
}