/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class chat_bubble : GComponent
    {
        public GImage n1;
        public GTextField decLab;
        public const string URL = "ui://pcr735xhcs1m9";

        public static chat_bubble CreateInstance()
        {
            return (chat_bubble)UIPackage.CreateObject("fun_Customer", "chat_bubble");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            decLab = (GTextField)GetChildAt(1);
        }
    }
}