/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newFriends_frendListItem : GComponent
    {
        public Controller stats;
        public Controller max;
        public GComponent head;
        public GComponent picFrame;
        public GImage n3;
        public GImage n19;
        public GImage icon_heart_bg;
        public GImage icon_heart;
        public GGroup n13;
        public GImage pic_sign;
        public GImage petIcon;
        public GImage timeStarIcon;
        public GGroup n14;
        public GTextField txt_lv;
        public GTextField txt_name;
        public GTextField titleTxt;
        public GTextField text_sign;
        public GTextField offlineTxt;
        public btn giftBtn;
        public btn btn_visit;
        public btn btn_setting;
        public GButton btn_no;
        public GButton btn_yes;
        public GButton btn_add;
        public const string URL = "ui://fteyf9nzi64uy";

        public static newFriends_frendListItem CreateInstance()
        {
            return (newFriends_frendListItem)UIPackage.CreateObject("fun_Friends", "newFriends_frendListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            stats = GetControllerAt(0);
            max = GetControllerAt(1);
            head = (GComponent)GetChildAt(0);
            picFrame = (GComponent)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n19 = (GImage)GetChildAt(3);
            icon_heart_bg = (GImage)GetChildAt(4);
            icon_heart = (GImage)GetChildAt(5);
            n13 = (GGroup)GetChildAt(6);
            pic_sign = (GImage)GetChildAt(7);
            petIcon = (GImage)GetChildAt(8);
            timeStarIcon = (GImage)GetChildAt(9);
            n14 = (GGroup)GetChildAt(10);
            txt_lv = (GTextField)GetChildAt(11);
            txt_name = (GTextField)GetChildAt(12);
            titleTxt = (GTextField)GetChildAt(13);
            text_sign = (GTextField)GetChildAt(14);
            offlineTxt = (GTextField)GetChildAt(15);
            giftBtn = (btn)GetChildAt(16);
            btn_visit = (btn)GetChildAt(17);
            btn_setting = (btn)GetChildAt(18);
            btn_no = (GButton)GetChildAt(19);
            btn_yes = (GButton)GetChildAt(20);
            btn_add = (GButton)GetChildAt(21);
        }
    }
}