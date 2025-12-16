/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newFriendBlackView : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GButton close_btn;
        public GList list;
        public GComponent nullTip;
        public GTextField best_Title;
        public GImage n10;
        public const string URL = "ui://fteyf9nzi64uz";

        public static newFriendBlackView CreateInstance()
        {
            return (newFriendBlackView)UIPackage.CreateObject("fun_Friends", "newFriendBlackView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            list = (GList)GetChildAt(2);
            nullTip = (GComponent)GetChildAt(3);
            best_Title = (GTextField)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
        }
    }
}