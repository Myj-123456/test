/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class refer_com : GComponent
    {
        public GImage n9;
        public GTextField lab;
        public btn1 close_btn;
        public GImage n8;
        public const string URL = "ui://z9jypfq8bwsw1yjp7wr";

        public static refer_com CreateInstance()
        {
            return (refer_com)UIPackage.CreateObject("fun_Chat", "refer_com");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            lab = (GTextField)GetChildAt(1);
            close_btn = (btn1)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
        }
    }
}