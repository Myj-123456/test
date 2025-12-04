/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class btn3 : GButton
    {
        public GImage n1;
        public const string URL = "ui://z9jypfq8sh8h1yjp7wv";

        public static btn3 CreateInstance()
        {
            return (btn3)UIPackage.CreateObject("fun_Chat", "btn3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}