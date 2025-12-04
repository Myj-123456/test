/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeView : GComponent
    {
        public Controller findComStatus;
        public GImage n64;
        public GImage n65;
        public GImage n66;
        public GImage n61;
        public GTextField title_txt;
        public GRichTextField lb_tradenName;
        public GList ls_ItemList;
        public GList page_list;
        public GList ls_sale;
        public GButton btn_help;
        public GButton close_btn;
        public btn_shop btn_friendShop;
        public btn_message btn_message;
        public GButton leftBtn;
        public GButton rightBtn;
        public GImage n68;
        public GTextInput inputLab;
        public findBtn findBtn;
        public GGroup findCom;
        public const string URL = "ui://tx86642vkg4atwpvp";

        public static tradeView CreateInstance()
        {
            return (tradeView)UIPackage.CreateObject("fun_FriendsTrade", "tradeView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            findComStatus = GetControllerAt(0);
            n64 = (GImage)GetChildAt(0);
            n65 = (GImage)GetChildAt(1);
            n66 = (GImage)GetChildAt(2);
            n61 = (GImage)GetChildAt(3);
            title_txt = (GTextField)GetChildAt(4);
            lb_tradenName = (GRichTextField)GetChildAt(5);
            ls_ItemList = (GList)GetChildAt(6);
            page_list = (GList)GetChildAt(7);
            ls_sale = (GList)GetChildAt(8);
            btn_help = (GButton)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            btn_friendShop = (btn_shop)GetChildAt(11);
            btn_message = (btn_message)GetChildAt(12);
            leftBtn = (GButton)GetChildAt(13);
            rightBtn = (GButton)GetChildAt(14);
            n68 = (GImage)GetChildAt(15);
            inputLab = (GTextInput)GetChildAt(16);
            findBtn = (findBtn)GetChildAt(17);
            findCom = (GGroup)GetChildAt(18);
        }
    }
}