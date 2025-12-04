/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class trade_friendSaleItem : GComponent
    {
        public Controller status;
        public Controller indexStatus;
        public GImage n1;
        public GLoader img_item;
        public GLoader img_gold;
        public GTextField lb_price;
        public GTextField lb_count;
        public GGroup sale;
        public GImage n23;
        public GImage password;
        public const string URL = "ui://tx86642vvfuq1ayr7t4";

        public static trade_friendSaleItem CreateInstance()
        {
            return (trade_friendSaleItem)UIPackage.CreateObject("fun_FriendsTrade", "trade_friendSaleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            indexStatus = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            img_item = (GLoader)GetChildAt(1);
            img_gold = (GLoader)GetChildAt(2);
            lb_price = (GTextField)GetChildAt(3);
            lb_count = (GTextField)GetChildAt(4);
            sale = (GGroup)GetChildAt(5);
            n23 = (GImage)GetChildAt(6);
            password = (GImage)GetChildAt(7);
        }
    }
}