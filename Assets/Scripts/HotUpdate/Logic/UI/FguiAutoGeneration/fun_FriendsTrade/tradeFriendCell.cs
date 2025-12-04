/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeFriendCell : GComponent
    {
        public Controller sex;
        public GImage n22;
        public GComponent head;
        public GList ls_items;
        public GTextField lb_userName;
        public GButton btn_comeIn;
        public GImage img_new;
        public const string URL = "ui://tx86642v8xrstwpx8";

        public static tradeFriendCell CreateInstance()
        {
            return (tradeFriendCell)UIPackage.CreateObject("fun_FriendsTrade", "tradeFriendCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            sex = GetControllerAt(0);
            n22 = (GImage)GetChildAt(0);
            head = (GComponent)GetChildAt(1);
            ls_items = (GList)GetChildAt(2);
            lb_userName = (GTextField)GetChildAt(3);
            btn_comeIn = (GButton)GetChildAt(4);
            img_new = (GImage)GetChildAt(5);
        }
    }
}