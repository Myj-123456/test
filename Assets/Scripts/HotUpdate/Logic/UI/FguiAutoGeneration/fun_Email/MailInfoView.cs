/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Email
{
    public partial class MailInfoView : GComponent
    {
        public Controller type;
        public GImage n1;
        public GImage n7;
        public GTextField title2;
        public GTextField title3;
        public MailCountCom mailCountCom;
        public GList list;
        public GButton btn_sure;
        public const string URL = "ui://u7aqh0mrs23ei";

        public static MailInfoView CreateInstance()
        {
            return (MailInfoView)UIPackage.CreateObject("fun_Email", "MailInfoView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            title2 = (GTextField)GetChildAt(2);
            title3 = (GTextField)GetChildAt(3);
            mailCountCom = (MailCountCom)GetChildAt(4);
            list = (GList)GetChildAt(5);
            btn_sure = (GButton)GetChildAt(6);
        }
    }
}