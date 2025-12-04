/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeItemCell : GComponent
    {
        public GImage n5;
        public GLoader img_Item;
        public GTextField lb_num;
        public const string URL = "ui://tx86642vkg4atwpw6";

        public static tradeItemCell CreateInstance()
        {
            return (tradeItemCell)UIPackage.CreateObject("fun_FriendsTrade", "tradeItemCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            img_Item = (GLoader)GetChildAt(1);
            lb_num = (GTextField)GetChildAt(2);
        }
    }
}