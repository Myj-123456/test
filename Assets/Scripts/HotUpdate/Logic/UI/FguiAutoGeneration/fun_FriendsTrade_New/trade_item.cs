/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class trade_item : GComponent
    {
        public GImage n0;
        public trade_saleItem item1;
        public trade_saleItem item2;
        public const string URL = "ui://jugv3wv4v01m1ayr7tf";

        public static trade_item CreateInstance()
        {
            return (trade_item)UIPackage.CreateObject("fun_FriendsTrade_New", "trade_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            item1 = (trade_saleItem)GetChildAt(1);
            item2 = (trade_saleItem)GetChildAt(2);
        }
    }
}