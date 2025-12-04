/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeFriendsListView : GComponent
    {
        public GImage n44;
        public GTextField title;
        public GList list;
        public GButton close_btn;
        public const string URL = "ui://tx86642v8xrstwpwq";

        public static tradeFriendsListView CreateInstance()
        {
            return (tradeFriendsListView)UIPackage.CreateObject("fun_FriendsTrade", "tradeFriendsListView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n44 = (GImage)GetChildAt(0);
            title = (GTextField)GetChildAt(1);
            list = (GList)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
        }
    }
}