/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Email
{
    public partial class MailView : GComponent
    {
        public GLoader bg;
        public GImage n16;
        public GImage n14;
        public GTextField title;
        public GButton close_btn;
        public GGroup n13;
        public GButton btn_read;
        public GButton btn_delete;
        public GList list;
        public GComponent no_item;
        public const string URL = "ui://u7aqh0mrs23eg";

        public static MailView CreateInstance()
        {
            return (MailView)UIPackage.CreateObject("fun_Email", "MailView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n16 = (GImage)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            title = (GTextField)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            n13 = (GGroup)GetChildAt(5);
            btn_read = (GButton)GetChildAt(6);
            btn_delete = (GButton)GetChildAt(7);
            list = (GList)GetChildAt(8);
            no_item = (GComponent)GetChildAt(9);
        }
    }
}