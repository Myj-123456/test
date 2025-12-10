/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitFriendView : GComponent
    {
        public Controller popUpTap;
        public VisitFriendListUI ui_friendList;
        public GImage n18;
        public GImage n17;
        public GComponent head;
        public GComponent picFrame;
        public GTextField txt_name;
        public GTextField n1;
        public GTextField txt_interactionTimes;
        public btn_introduce n33;
        public btn_convert n41;
        public GImage icon;
        public GTextField txt_lv;
        public GImage n42;
        public GTextField FriendCoinNum;
        public GImage n44;
        public GGroup playerInfo;
        public GImage n46;
        public GTextField n47;
        public GGroup n48;
        public GGraph n88;
        public GImage n64;
        public GTextField n65;
        public GTextField n66;
        public GTextField n68;
        public Num_add NumAddBtn;
        public Num_lessen LessenBtn;
        public GButton CloseBtn;
        public GButton EnterBtn;
        public GButton CancelBtn;
        public GImage n85;
        public GTextField n86;
        public GTextField n90;
        public GTextField n91;
        public GGroup n87;
        public const string URL = "ui://fteyf9nzk3gl1yjp7ta";

        public static VisitFriendView CreateInstance()
        {
            return (VisitFriendView)UIPackage.CreateObject("fun_Friends", "VisitFriendView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            popUpTap = GetControllerAt(0);
            ui_friendList = (VisitFriendListUI)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            n17 = (GImage)GetChildAt(2);
            head = (GComponent)GetChildAt(3);
            picFrame = (GComponent)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            n1 = (GTextField)GetChildAt(6);
            txt_interactionTimes = (GTextField)GetChildAt(7);
            n33 = (btn_introduce)GetChildAt(8);
            n41 = (btn_convert)GetChildAt(9);
            icon = (GImage)GetChildAt(10);
            txt_lv = (GTextField)GetChildAt(11);
            n42 = (GImage)GetChildAt(12);
            FriendCoinNum = (GTextField)GetChildAt(13);
            n44 = (GImage)GetChildAt(14);
            playerInfo = (GGroup)GetChildAt(15);
            n46 = (GImage)GetChildAt(16);
            n47 = (GTextField)GetChildAt(17);
            n48 = (GGroup)GetChildAt(18);
            n88 = (GGraph)GetChildAt(19);
            n64 = (GImage)GetChildAt(20);
            n65 = (GTextField)GetChildAt(21);
            n66 = (GTextField)GetChildAt(22);
            n68 = (GTextField)GetChildAt(23);
            NumAddBtn = (Num_add)GetChildAt(24);
            LessenBtn = (Num_lessen)GetChildAt(25);
            CloseBtn = (GButton)GetChildAt(26);
            EnterBtn = (GButton)GetChildAt(27);
            CancelBtn = (GButton)GetChildAt(28);
            n85 = (GImage)GetChildAt(29);
            n86 = (GTextField)GetChildAt(30);
            n90 = (GTextField)GetChildAt(31);
            n91 = (GTextField)GetChildAt(32);
            n87 = (GGroup)GetChildAt(33);
        }
    }
}