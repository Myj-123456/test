/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class ticketContainer : GComponent
    {
        public propEarningItem n4;
        public propEarningItem n7;
        public propEarningItem n6;
        public propEarningItem n5;
        public GImage n11;
        public GImage n10;
        public GImage n9;
        public GTextField ticketTitle;
        public const string URL = "ui://6vo132lqvag2jtwq9c";

        public static ticketContainer CreateInstance()
        {
            return (ticketContainer)UIPackage.CreateObject("fun_StoreRevenue", "ticketContainer");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (propEarningItem)GetChildAt(0);
            n7 = (propEarningItem)GetChildAt(1);
            n6 = (propEarningItem)GetChildAt(2);
            n5 = (propEarningItem)GetChildAt(3);
            n11 = (GImage)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n9 = (GImage)GetChildAt(6);
            ticketTitle = (GTextField)GetChildAt(7);
        }
    }
}