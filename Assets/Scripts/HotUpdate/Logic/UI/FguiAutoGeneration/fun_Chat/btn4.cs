/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class btn4 : GButton
    {
        public GImage n3;
        public GImage n5;
        public const string URL = "ui://z9jypfq8sh8h1yjp7x4";

        public static btn4 CreateInstance()
        {
            return (btn4)UIPackage.CreateObject("fun_Chat", "btn4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            n5 = (GImage)GetChildAt(1);
        }
    }
}