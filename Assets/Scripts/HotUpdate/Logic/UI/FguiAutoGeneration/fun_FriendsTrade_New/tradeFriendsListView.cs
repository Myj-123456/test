/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeFriendsListView : GComponent
    {
        public GImage n2;
        public GImage n3;
        public GLoader bg;
        public GImage n5;
        public GButton close_btn;
        public GButton findBtn;
        public GTextInput inputLab;
        public GList list;
        public GComponent tip;
        public const string URL = "ui://jugv3wv4q9bj16";

        public static tradeFriendsListView CreateInstance()
        {
            return (tradeFriendsListView)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeFriendsListView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            findBtn = (GButton)GetChildAt(5);
            inputLab = (GTextInput)GetChildAt(6);
            list = (GList)GetChildAt(7);
            tip = (GComponent)GetChildAt(8);
        }
    }
}