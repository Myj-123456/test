/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class trade_saleItem : GComponent
    {
        public Controller status;
        public GImage n30;
        public GImage n1;
        public GLoader img_item;
        public GTextField lb_price;
        public GLoader img_gold;
        public GTextField lb_count;
        public GGroup sale;
        public add n7;
        public GTextField lb_saleCount;
        public GImage selectStatus;
        public GGroup empty;
        public GRichTextField lb_inviteInfo;
        public btn_invite btn_invite;
        public GGroup invite;
        public GButton btn_unlock;
        public GImage n23;
        public GImage password;
        public const string URL = "ui://tx86642vkg4atwpw7";

        public static trade_saleItem CreateInstance()
        {
            return (trade_saleItem)UIPackage.CreateObject("fun_FriendsTrade", "trade_saleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n30 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            img_item = (GLoader)GetChildAt(2);
            lb_price = (GTextField)GetChildAt(3);
            img_gold = (GLoader)GetChildAt(4);
            lb_count = (GTextField)GetChildAt(5);
            sale = (GGroup)GetChildAt(6);
            n7 = (add)GetChildAt(7);
            lb_saleCount = (GTextField)GetChildAt(8);
            selectStatus = (GImage)GetChildAt(9);
            empty = (GGroup)GetChildAt(10);
            lb_inviteInfo = (GRichTextField)GetChildAt(11);
            btn_invite = (btn_invite)GetChildAt(12);
            invite = (GGroup)GetChildAt(13);
            btn_unlock = (GButton)GetChildAt(14);
            n23 = (GImage)GetChildAt(15);
            password = (GImage)GetChildAt(16);
        }
    }
}