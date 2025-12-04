/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitFriendListUI : GComponent
    {
        public GImage n0;
        public GButton btn_left;
        public GButton btn_right;
        public GTextField txt_pageNum;
        public GList list_visitFriend;
        public btnHome btn_home;
        public GTextField txt_noFriendPrompt;
        public one_key_btn one_key_btn;
        public const string URL = "ui://fteyf9nzivvl1yjp7th";

        public static VisitFriendListUI CreateInstance()
        {
            return (VisitFriendListUI)UIPackage.CreateObject("fun_Friends", "VisitFriendListUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            btn_left = (GButton)GetChildAt(1);
            btn_right = (GButton)GetChildAt(2);
            txt_pageNum = (GTextField)GetChildAt(3);
            list_visitFriend = (GList)GetChildAt(4);
            btn_home = (btnHome)GetChildAt(5);
            txt_noFriendPrompt = (GTextField)GetChildAt(6);
            one_key_btn = (one_key_btn)GetChildAt(7);
        }
    }
}