/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newBestFriendView : GComponent
    {
        public Controller status;
        public Controller deteTip;
        public GImage n2;
        public GLoader bg;
        public GTextField titleLab;
        public GButton close_btn;
        public GList list;
        public GComponent nullTip;
        public GGraph n26;
        public GImage n27;
        public GImage n28;
        public GTextField setTitle;
        public GTextField txt_1;
        public GButton btn_determine;
        public GButton btn_cancel;
        public GButton bg_sign;
        public GTextField txt_2;
        public GTextField txt_Buyname;
        public GGroup n42;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tp";

        public static newBestFriendView CreateInstance()
        {
            return (newBestFriendView)UIPackage.CreateObject("fun_Friends", "newBestFriendView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            deteTip = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            nullTip = (GComponent)GetChildAt(5);
            n26 = (GGraph)GetChildAt(6);
            n27 = (GImage)GetChildAt(7);
            n28 = (GImage)GetChildAt(8);
            setTitle = (GTextField)GetChildAt(9);
            txt_1 = (GTextField)GetChildAt(10);
            btn_determine = (GButton)GetChildAt(11);
            btn_cancel = (GButton)GetChildAt(12);
            bg_sign = (GButton)GetChildAt(13);
            txt_2 = (GTextField)GetChildAt(14);
            txt_Buyname = (GTextField)GetChildAt(15);
            n42 = (GGroup)GetChildAt(16);
        }
    }
}