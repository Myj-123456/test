/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeMessage : GComponent
    {
        public GImage n5;
        public GLoader bg;
        public GImage n4;
        public GImage n2;
        public GTextField lb_tip;
        public GButton close_btn;
        public GList ls_message;
        public GComponent tip;
        public const string URL = "ui://jugv3wv4q9bjz";

        public static tradeMessage CreateInstance()
        {
            return (tradeMessage)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeMessage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n2 = (GImage)GetChildAt(3);
            lb_tip = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            ls_message = (GList)GetChildAt(6);
            tip = (GComponent)GetChildAt(7);
        }
    }
}