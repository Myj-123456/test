/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class customer_view : GComponent
    {
        public Controller showChose;
        public Controller tab;
        public GLoader bg;
        public GLoader pic;
        public GImage n1;
        public GButton help_btn;
        public GTextField titleLab;
        public GGroup n36;
        public GLoader bg1;
        public GImage n21;
        public page gift_btn;
        public page ike_btn;
        public GTextField tipLab1;
        public GList list;
        public chose_quailty_btn chose_btn;
        public chose_qualirt chose_grp;
        public GGroup n35;
        public GTextField tipLab;
        public GTextField numLab;
        public add_btn add_btn;
        public GGroup n28;
        public GButton send_btn;
        public GGroup n40;
        public GImage n10;
        public GImage n7;
        public pro pro;
        public GTextField proLab;
        public GTextField proTitle;
        public GTextField lvName;
        public GTextField expPro;
        public GTextField nameLab;
        public GList style_list;
        public chat_bubble chat;
        public detail_btn detail;
        public btn role_btn;
        public GGroup n38;
        public role_list_view role_view;
        public GButton close_btn;
        public Transition chatShow;
        public Transition chatHide;
        public const string URL = "ui://pcr735xhcs1m2";

        public static customer_view CreateInstance()
        {
            return (customer_view)UIPackage.CreateObject("fun_Customer", "customer_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            tab = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            n36 = (GGroup)GetChildAt(5);
            bg1 = (GLoader)GetChildAt(6);
            n21 = (GImage)GetChildAt(7);
            gift_btn = (page)GetChildAt(8);
            ike_btn = (page)GetChildAt(9);
            tipLab1 = (GTextField)GetChildAt(10);
            list = (GList)GetChildAt(11);
            chose_btn = (chose_quailty_btn)GetChildAt(12);
            chose_grp = (chose_qualirt)GetChildAt(13);
            n35 = (GGroup)GetChildAt(14);
            tipLab = (GTextField)GetChildAt(15);
            numLab = (GTextField)GetChildAt(16);
            add_btn = (add_btn)GetChildAt(17);
            n28 = (GGroup)GetChildAt(18);
            send_btn = (GButton)GetChildAt(19);
            n40 = (GGroup)GetChildAt(20);
            n10 = (GImage)GetChildAt(21);
            n7 = (GImage)GetChildAt(22);
            pro = (pro)GetChildAt(23);
            proLab = (GTextField)GetChildAt(24);
            proTitle = (GTextField)GetChildAt(25);
            lvName = (GTextField)GetChildAt(26);
            expPro = (GTextField)GetChildAt(27);
            nameLab = (GTextField)GetChildAt(28);
            style_list = (GList)GetChildAt(29);
            chat = (chat_bubble)GetChildAt(30);
            detail = (detail_btn)GetChildAt(31);
            role_btn = (btn)GetChildAt(32);
            n38 = (GGroup)GetChildAt(33);
            role_view = (role_list_view)GetChildAt(34);
            close_btn = (GButton)GetChildAt(35);
            chatShow = GetTransitionAt(0);
            chatHide = GetTransitionAt(1);
        }
    }
}