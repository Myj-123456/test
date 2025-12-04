/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class ope_com : GComponent
    {
        public GImage n7;
        public btn2 quote_btn;
        public btn2 copy_btn;
        public btn2 report_btn;
        public const string URL = "ui://z9jypfq8bwsw1yjp7wq";

        public static ope_com CreateInstance()
        {
            return (ope_com)UIPackage.CreateObject("fun_Chat", "ope_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n7 = (GImage)GetChildAt(0);
            quote_btn = (btn2)GetChildAt(1);
            copy_btn = (btn2)GetChildAt(2);
            report_btn = (btn2)GetChildAt(3);
        }
    }
}