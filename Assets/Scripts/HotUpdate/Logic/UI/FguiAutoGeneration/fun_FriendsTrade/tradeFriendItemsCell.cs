/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeFriendItemsCell : GComponent
    {
        public Controller status;
        public GImage n8;
        public GLoader img_item;
        public GImage password;
        public GImage n9;
        public const string URL = "ui://tx86642v8xrstwpx9";

        public static tradeFriendItemsCell CreateInstance()
        {
            return (tradeFriendItemsCell)UIPackage.CreateObject("fun_FriendsTrade", "tradeFriendItemsCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n8 = (GImage)GetChildAt(0);
            img_item = (GLoader)GetChildAt(1);
            password = (GImage)GetChildAt(2);
            n9 = (GImage)GetChildAt(3);
        }
    }
}