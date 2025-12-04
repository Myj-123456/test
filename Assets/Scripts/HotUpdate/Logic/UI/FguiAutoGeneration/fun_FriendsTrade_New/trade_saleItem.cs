/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class trade_saleItem : GComponent
    {
        public Controller status;
        public GImage n32;
        public GLoader3D lockSpine;
        public GLoader img_item;
        public GImage n33;
        public GTextField lb_price;
        public GLoader img_gold;
        public GTextField lb_count;
        public GGroup sale;
        public GImage n35;
        public GTextField lb_saleCount;
        public GGroup empty;
        public GRichTextField lb_inviteInfo;
        public GGroup invite;
        public GLoader img_cost;
        public GTextField lb_cost;
        public GGroup n41;
        public GImage password;
        public const string URL = "ui://jugv3wv4q9bj1ayr7t8";

        public static trade_saleItem CreateInstance()
        {
            return (trade_saleItem)UIPackage.CreateObject("fun_FriendsTrade_New", "trade_saleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n32 = (GImage)GetChildAt(0);
            lockSpine = (GLoader3D)GetChildAt(1);
            img_item = (GLoader)GetChildAt(2);
            n33 = (GImage)GetChildAt(3);
            lb_price = (GTextField)GetChildAt(4);
            img_gold = (GLoader)GetChildAt(5);
            lb_count = (GTextField)GetChildAt(6);
            sale = (GGroup)GetChildAt(7);
            n35 = (GImage)GetChildAt(8);
            lb_saleCount = (GTextField)GetChildAt(9);
            empty = (GGroup)GetChildAt(10);
            lb_inviteInfo = (GRichTextField)GetChildAt(11);
            invite = (GGroup)GetChildAt(12);
            img_cost = (GLoader)GetChildAt(13);
            lb_cost = (GTextField)GetChildAt(14);
            n41 = (GGroup)GetChildAt(15);
            password = (GImage)GetChildAt(16);
        }
    }
}