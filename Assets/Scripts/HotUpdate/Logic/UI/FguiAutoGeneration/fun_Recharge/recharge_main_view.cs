/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class recharge_main_view : GComponent
    {
        public Controller tab;
        public card_view card_view;
        public newRecharge recharge_view;
        public gift_view gift_view;
        public cumulative_view cumulative_view;
        public tour_gift_view tour_gift_view;
        public GImage n16;
        public GImage n3;
        public GButton close_btn;
        public GList list;
        public GTextField tipLab;
        public GGroup n18;
        public const string URL = "ui://w3ox9yltdidl14";

        public static recharge_main_view CreateInstance()
        {
            return (recharge_main_view)UIPackage.CreateObject("fun_Recharge", "recharge_main_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            card_view = (card_view)GetChildAt(0);
            recharge_view = (newRecharge)GetChildAt(1);
            gift_view = (gift_view)GetChildAt(2);
            cumulative_view = (cumulative_view)GetChildAt(3);
            tour_gift_view = (tour_gift_view)GetChildAt(4);
            n16 = (GImage)GetChildAt(5);
            n3 = (GImage)GetChildAt(6);
            close_btn = (GButton)GetChildAt(7);
            list = (GList)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
            n18 = (GGroup)GetChildAt(10);
        }
    }
}