/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeMessageCell : GComponent
    {
        public GImage n1;
        public GImage n6;
        public GImage n7;
        public GComponent head;
        public GComponent frame;
        public GImage n11;
        public GTextField txt_userName;
        public GTextField txt_date;
        public GTextField txt_lv;
        public GRichTextField txt_info_0;
        public const string URL = "ui://jugv3wv4q9bj12";

        public static tradeMessageCell CreateInstance()
        {
            return (tradeMessageCell)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeMessageCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            head = (GComponent)GetChildAt(3);
            frame = (GComponent)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            txt_userName = (GTextField)GetChildAt(6);
            txt_date = (GTextField)GetChildAt(7);
            txt_lv = (GTextField)GetChildAt(8);
            txt_info_0 = (GRichTextField)GetChildAt(9);
        }
    }
}