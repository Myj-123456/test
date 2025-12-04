/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_add : GButton
    {
        public Controller addController;
        public Controller selectedCotrl;
        public GImage n2;
        public GImage n4;
        public BestFriendItem n3;
        public GImage n5;
        public const string URL = "ui://fteyf9nzg3sj1yjp7ts";

        public static best_add CreateInstance()
        {
            return (best_add)UIPackage.CreateObject("fun_Friends", "best_add");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            addController = GetControllerAt(0);
            selectedCotrl = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n3 = (BestFriendItem)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
        }
    }
}