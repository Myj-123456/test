/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Chat
{
    public partial class btn2 : GButton
    {
        public Controller type;
        public GImage n0;
        public GImage n1;
        public GImage n2;
        public GTextField titleLab;
        public const string URL = "ui://z9jypfq811rnu1yjp7xn";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_Chat", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}