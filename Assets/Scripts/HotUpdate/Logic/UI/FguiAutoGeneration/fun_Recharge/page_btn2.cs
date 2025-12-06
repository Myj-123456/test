/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn2 : GButton
    {
        public Controller button;
        public GImage n17;
        public GImage n18;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://w3ox9yltv01m1ayr83g";

        public static page_btn2 CreateInstance()
        {
            return (page_btn2)UIPackage.CreateObject("fun_Recharge", "page_btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n17 = (GImage)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}