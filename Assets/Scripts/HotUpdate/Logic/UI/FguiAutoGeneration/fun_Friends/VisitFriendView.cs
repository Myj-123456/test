/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitFriendView : GComponent
    {
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
        public const string URL = "ui://fteyf9nzk3gl1yjp7ta";

        public static VisitFriendView CreateInstance()
        {
            return (VisitFriendView)UIPackage.CreateObject("fun_Friends", "VisitFriendView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

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
        }
    }
}