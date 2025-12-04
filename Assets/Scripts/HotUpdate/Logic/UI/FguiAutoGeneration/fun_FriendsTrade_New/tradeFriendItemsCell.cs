/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeFriendItemsCell : GComponent
    {
        public Controller status;
        public GImage n1;
        public GImage n0;
        public GImage n2;
        public GLoader img_item;
        public GImage password;
        public const string URL = "ui://jugv3wv4q9bj1e";

        public static tradeFriendItemsCell CreateInstance()
        {
            return (tradeFriendItemsCell)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeFriendItemsCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n0 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            img_item = (GLoader)GetChildAt(3);
            password = (GImage)GetChildAt(4);
        }
    }
}