/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class VisitFriendItem : GComponent
    {
        public GComponent head;
        public GComponent picFrame;
        public GImage icon;
        public GTextField txt_lv;
        public GTextField txt_name;
        public const string URL = "ui://fteyf9nzmz671yjp7tb";

        public static VisitFriendItem CreateInstance()
        {
            return (VisitFriendItem)UIPackage.CreateObject("fun_Friends", "VisitFriendItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            head = (GComponent)GetChildAt(0);
            picFrame = (GComponent)GetChildAt(1);
            icon = (GImage)GetChildAt(2);
            txt_lv = (GTextField)GetChildAt(3);
            txt_name = (GTextField)GetChildAt(4);
        }
    }
}