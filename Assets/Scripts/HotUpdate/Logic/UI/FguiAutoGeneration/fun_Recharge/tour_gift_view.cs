/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class tour_gift_view : GComponent
    {
        public GLoader bg;
        public tour_gift_list list_com;
        public GTextField pageLab;
        public GButton left_btn;
        public GButton right_btn;
        public const string URL = "ui://w3ox9yltv01m1ayr83m";

        public static tour_gift_view CreateInstance()
        {
            return (tour_gift_view)UIPackage.CreateObject("fun_Recharge", "tour_gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            list_com = (tour_gift_list)GetChildAt(1);
            pageLab = (GTextField)GetChildAt(2);
            left_btn = (GButton)GetChildAt(3);
            right_btn = (GButton)GetChildAt(4);
        }
    }
}