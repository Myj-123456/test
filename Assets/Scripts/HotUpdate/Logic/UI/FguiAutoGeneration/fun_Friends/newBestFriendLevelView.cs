/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newBestFriendLevelView : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n20;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GTextField title1;
        public GTextField title2;
        public GTextField title3;
        public GTextField title4;
        public GButton close_btn;
        public GList list;
        public GTextField best_Title;
        public GImage n22;
        public const string URL = "ui://fteyf9nzg3sj1yjp7ub";

        public static newBestFriendLevelView CreateInstance()
        {
            return (newBestFriendLevelView)UIPackage.CreateObject("fun_Friends", "newBestFriendLevelView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n20 = (GImage)GetChildAt(1);
            n12 = (GImage)GetChildAt(2);
            n13 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            title1 = (GTextField)GetChildAt(5);
            title2 = (GTextField)GetChildAt(6);
            title3 = (GTextField)GetChildAt(7);
            title4 = (GTextField)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
            list = (GList)GetChildAt(10);
            best_Title = (GTextField)GetChildAt(11);
            n22 = (GImage)GetChildAt(12);
        }
    }
}