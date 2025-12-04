/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class NoticeScrollListItem : GComponent
    {
        public Controller gapTap;
        public GImage n3;
        public GRichTextField lb_content;
        public GRichTextField lb_dec;
        public const string URL = "ui://6q8q1ai6kgi5jtwq83";

        public static NoticeScrollListItem CreateInstance()
        {
            return (NoticeScrollListItem)UIPackage.CreateObject("fun_CultivationManual", "NoticeScrollListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            gapTap = GetControllerAt(0);
            n3 = (GImage)GetChildAt(0);
            lb_content = (GRichTextField)GetChildAt(1);
            lb_dec = (GRichTextField)GetChildAt(2);
        }
    }
}