/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Email
{
    public partial class MailItem : GComponent
    {
        public Controller status;
        public Controller showStatus;
        public GImage n1;
        public GImage n2;
        public GImage n11;
        public GImage n12;
        public GImage n4;
        public GTextField title1;
        public GTextField title2;
        public GTextField read;
        public GTextField delete_info;
        public GButton readBtn;
        public GButton readEndBtn;
        public MailInfoView content;
        public GGraph anim;
        public Transition show;
        public Transition hide;
        public const string URL = "ui://u7aqh0mrs23eh";

        public static MailItem CreateInstance()
        {
            return (MailItem)UIPackage.CreateObject("fun_Email", "MailItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            showStatus = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n12 = (GImage)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
            title1 = (GTextField)GetChildAt(5);
            title2 = (GTextField)GetChildAt(6);
            read = (GTextField)GetChildAt(7);
            delete_info = (GTextField)GetChildAt(8);
            readBtn = (GButton)GetChildAt(9);
            readEndBtn = (GButton)GetChildAt(10);
            content = (MailInfoView)GetChildAt(11);
            anim = (GGraph)GetChildAt(12);
            show = GetTransitionAt(0);
            hide = GetTransitionAt(1);
        }
    }
}