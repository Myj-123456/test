/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newFriendBlackView : GComponent
    {
        public Controller status;
        public GImage n2;
        public GLoader bg;
        public GImage n5;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GButton close_btn;
        public GList list;
        public GComponent nullTip;
        public const string URL = "ui://fteyf9nzi64uz";

        public static newFriendBlackView CreateInstance()
        {
            return (newFriendBlackView)UIPackage.CreateObject("fun_Friends", "newFriendBlackView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            titleLab1 = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            list = (GList)GetChildAt(6);
            nullTip = (GComponent)GetChildAt(7);
        }
    }
}