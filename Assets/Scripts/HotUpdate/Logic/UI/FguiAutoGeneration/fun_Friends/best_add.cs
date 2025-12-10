/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_add : GButton
    {
        public Controller button;
        public Controller addController;
        public GImage n2;
        public GImage n4;
        public BestFriendItem n3;
        public GImage n5;
        public const string URL = "ui://fteyf9nzfn3b1yjp7uu";

        public static best_add CreateInstance()
        {
            return (best_add)UIPackage.CreateObject("fun_Friends", "best_add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            addController = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n3 = (BestFriendItem)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
        }
    }
}