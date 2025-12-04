/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeMessage : GComponent
    {
        public GImage n19;
        public GImage n15;
        public GTextField lb_title;
        public GRichTextField lb_tip;
        public GList ls_message;
        public GButton close_btn;
        public const string URL = "ui://tx86642v8xrstwpxb";

        public static tradeMessage CreateInstance()
        {
            return (tradeMessage)UIPackage.CreateObject("fun_FriendsTrade", "tradeMessage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n19 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            lb_title = (GTextField)GetChildAt(2);
            lb_tip = (GRichTextField)GetChildAt(3);
            ls_message = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}