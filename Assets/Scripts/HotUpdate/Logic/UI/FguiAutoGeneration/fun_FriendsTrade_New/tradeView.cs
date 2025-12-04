/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeView : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n14;
        public GImage n15;
        public GImage n16;
        public GImage n17;
        public GGroup pos;
        public GList ls_sale;
        public GImage n7;
        public GLoader3D spine;
        public GImage n12;
        public GTextField lb_tradeName;
        public GGroup n19;
        public GImage n3;
        public GTextField title_txt;
        public GButton btn_help;
        public GButton close_btn;
        public btn recycle_btn;
        public btn btn_message;
        public btn btn_friendShop;
        public const string URL = "ui://jugv3wv4q9bja";

        public static tradeView CreateInstance()
        {
            return (tradeView)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            n16 = (GImage)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            pos = (GGroup)GetChildAt(5);
            ls_sale = (GList)GetChildAt(6);
            n7 = (GImage)GetChildAt(7);
            spine = (GLoader3D)GetChildAt(8);
            n12 = (GImage)GetChildAt(9);
            lb_tradeName = (GTextField)GetChildAt(10);
            n19 = (GGroup)GetChildAt(11);
            n3 = (GImage)GetChildAt(12);
            title_txt = (GTextField)GetChildAt(13);
            btn_help = (GButton)GetChildAt(14);
            close_btn = (GButton)GetChildAt(15);
            recycle_btn = (btn)GetChildAt(16);
            btn_message = (btn)GetChildAt(17);
            btn_friendShop = (btn)GetChildAt(18);
        }
    }
}