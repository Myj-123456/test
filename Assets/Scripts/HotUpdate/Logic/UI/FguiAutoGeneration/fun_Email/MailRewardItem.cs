/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Email
{
    public partial class MailRewardItem : GComponent
    {
        public GLoader bg;
        public GLoader img;
        public GTextField count;
        public const string URL = "ui://u7aqh0mrs23ek";

        public static MailRewardItem CreateInstance()
        {
            return (MailRewardItem)UIPackage.CreateObject("fun_Email", "MailRewardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            img = (GLoader)GetChildAt(1);
            count = (GTextField)GetChildAt(2);
        }
    }
}