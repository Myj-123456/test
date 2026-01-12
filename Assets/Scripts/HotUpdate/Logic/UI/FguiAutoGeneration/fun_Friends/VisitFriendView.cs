/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitFriendView : GComponent
    {
        public Controller popUpTap;
        public GImage n18;
        public GImage n17;
        public GComponent head;
        public GComponent picFrame;
        public GTextField txt_name;
        public GTextField n1;
        public GTextField txt_interactionTimes;
        public GImage icon;
        public GTextField txt_lv;
        public GGroup playerInfo;
        public VisitFriendListUI ui_friendList;
        public GImage n21;
        public GTextField FriendCoinNum;
        public GLoader pic;
        public btn_visitdetails btn_visitdetails;
        public btn_currency btn_currency;
        public GImage n26;
        public GTextField n27;
        public GGroup n29;
        public GGraph n30;
        public GLoader n46;
        public GTextField txt_1;
        public GButton EnterBtn;
        public GButton CancelBtn;
        public GButton bg_sign;
        public GTextField text_visitCount;
        public GTextField txt_Buyname;
        public btn_lessen btn_lessen;
        public btn_addNum btn_addNum;
        public GTextField text_count;
        public GTextField text_consume;
        public GImage n45;
        public GImage n47;
        public GTextField best_buyText;
        public GGroup n40;
        public const string URL = "ui://fteyf9nzk3gl1yjp7ta";

        public static VisitFriendView CreateInstance()
        {
            return (VisitFriendView)UIPackage.CreateObject("fun_Friends", "VisitFriendView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            popUpTap = GetControllerAt(0);
            n18 = (GImage)GetChildAt(0);
            n17 = (GImage)GetChildAt(1);
            head = (GComponent)GetChildAt(2);
            picFrame = (GComponent)GetChildAt(3);
            txt_name = (GTextField)GetChildAt(4);
            n1 = (GTextField)GetChildAt(5);
            txt_interactionTimes = (GTextField)GetChildAt(6);
            icon = (GImage)GetChildAt(7);
            txt_lv = (GTextField)GetChildAt(8);
            playerInfo = (GGroup)GetChildAt(9);
            ui_friendList = (VisitFriendListUI)GetChildAt(10);
            n21 = (GImage)GetChildAt(11);
            FriendCoinNum = (GTextField)GetChildAt(12);
            pic = (GLoader)GetChildAt(13);
            btn_visitdetails = (btn_visitdetails)GetChildAt(14);
            btn_currency = (btn_currency)GetChildAt(15);
            n26 = (GImage)GetChildAt(16);
            n27 = (GTextField)GetChildAt(17);
            n29 = (GGroup)GetChildAt(18);
            n30 = (GGraph)GetChildAt(19);
            n46 = (GLoader)GetChildAt(20);
            txt_1 = (GTextField)GetChildAt(21);
            EnterBtn = (GButton)GetChildAt(22);
            CancelBtn = (GButton)GetChildAt(23);
            bg_sign = (GButton)GetChildAt(24);
            text_visitCount = (GTextField)GetChildAt(25);
            txt_Buyname = (GTextField)GetChildAt(26);
            btn_lessen = (btn_lessen)GetChildAt(27);
            btn_addNum = (btn_addNum)GetChildAt(28);
            text_count = (GTextField)GetChildAt(29);
            text_consume = (GTextField)GetChildAt(30);
            n45 = (GImage)GetChildAt(31);
            n47 = (GImage)GetChildAt(32);
            best_buyText = (GTextField)GetChildAt(33);
            n40 = (GGroup)GetChildAt(34);
        }
    }
}