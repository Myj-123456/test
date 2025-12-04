/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeFriendShopView : GComponent
    {
        public GImage n39;
        public GImage n37;
        public GImage n38;
        public GTextField lb_tradeName;
        public GList ls_sale;
        public GButton close_btn;
        public const string URL = "ui://tx86642v8xrstwpxa";

        public static tradeFriendShopView CreateInstance()
        {
            return (tradeFriendShopView)UIPackage.CreateObject("fun_FriendsTrade", "tradeFriendShopView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n39 = (GImage)GetChildAt(0);
            n37 = (GImage)GetChildAt(1);
            n38 = (GImage)GetChildAt(2);
            lb_tradeName = (GTextField)GetChildAt(3);
            ls_sale = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}