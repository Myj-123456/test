/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeMessageCell : GComponent
    {
        public GImage n21;
        public GTextField txt_userName;
        public GTextField txt_date;
        public GRichTextField txt_info_0;
        public GComponent head;
        public const string URL = "ui://tx86642v8xrstwpxs";

        public static tradeMessageCell CreateInstance()
        {
            return (tradeMessageCell)UIPackage.CreateObject("fun_FriendsTrade", "tradeMessageCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n21 = (GImage)GetChildAt(0);
            txt_userName = (GTextField)GetChildAt(1);
            txt_date = (GTextField)GetChildAt(2);
            txt_info_0 = (GRichTextField)GetChildAt(3);
            head = (GComponent)GetChildAt(4);
        }
    }
}