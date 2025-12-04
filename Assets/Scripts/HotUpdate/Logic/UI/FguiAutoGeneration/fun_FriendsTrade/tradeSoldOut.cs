/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeSoldOut : GComponent
    {
        public GImage n5;
        public GTextField lb_info;
        public GButton btn_sure;
        public const string URL = "ui://tx86642vfaaw1ayr7ss";

        public static tradeSoldOut CreateInstance()
        {
            return (tradeSoldOut)UIPackage.CreateObject("fun_FriendsTrade", "tradeSoldOut");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            lb_info = (GTextField)GetChildAt(1);
            btn_sure = (GButton)GetChildAt(2);
        }
    }
}