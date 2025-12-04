/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeFriendCell : GComponent
    {
        public GImage n1;
        public GImage n2;
        public GComponent head;
        public GComponent frame;
        public GImage n5;
        public GTextField txt_lv;
        public GTextField lb_userName;
        public GButton btn_comeIn;
        public GList ls_items;
        public const string URL = "ui://jugv3wv4q9bj1a";

        public static tradeFriendCell CreateInstance()
        {
            return (tradeFriendCell)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeFriendCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            head = (GComponent)GetChildAt(2);
            frame = (GComponent)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            txt_lv = (GTextField)GetChildAt(5);
            lb_userName = (GTextField)GetChildAt(6);
            btn_comeIn = (GButton)GetChildAt(7);
            ls_items = (GList)GetChildAt(8);
        }
    }
}