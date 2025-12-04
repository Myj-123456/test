/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeItemCell : GComponent
    {
        public GLoader bg;
        public GLoader img_Item;
        public GTextField lb_num;
        public const string URL = "ui://jugv3wv4q9bjt";

        public static tradeItemCell CreateInstance()
        {
            return (tradeItemCell)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeItemCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            img_Item = (GLoader)GetChildAt(1);
            lb_num = (GTextField)GetChildAt(2);
        }
    }
}