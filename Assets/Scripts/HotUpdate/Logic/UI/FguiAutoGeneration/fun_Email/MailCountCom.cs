/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Email
{
    public partial class MailCountCom : GComponent
    {
        public GTextField descLab;
        public const string URL = "ui://u7aqh0mrs23ej";

        public static MailCountCom CreateInstance()
        {
            return (MailCountCom)UIPackage.CreateObject("fun_Email", "MailCountCom");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            descLab = (GTextField)GetChildAt(0);
        }
    }
}