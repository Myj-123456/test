/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newBestFriendView : GComponent
    {
        public Controller status;
        public Controller deteTip;
        public GLoader bg;
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
        public GTextField best_Title;
        public GImage n47;
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
            bg = (GLoader)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            list = (GList)GetChildAt(2);
            nullTip = (GComponent)GetChildAt(3);
            n26 = (GGraph)GetChildAt(4);
            n27 = (GImage)GetChildAt(5);
            n28 = (GImage)GetChildAt(6);
            setTitle = (GTextField)GetChildAt(7);
            txt_1 = (GTextField)GetChildAt(8);
            btn_determine = (GButton)GetChildAt(9);
            btn_cancel = (GButton)GetChildAt(10);
            bg_sign = (GButton)GetChildAt(11);
            txt_2 = (GTextField)GetChildAt(12);
            txt_Buyname = (GTextField)GetChildAt(13);
            n42 = (GGroup)GetChildAt(14);
            best_Title = (GTextField)GetChildAt(15);
            n47 = (GImage)GetChildAt(16);
        }
    }
}