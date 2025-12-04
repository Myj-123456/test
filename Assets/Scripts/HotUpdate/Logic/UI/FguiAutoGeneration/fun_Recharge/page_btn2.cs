/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn2 : GButton
    {
        public Controller button;
        public GImage n16;
        public GTextField titleLab;
        public const string URL = "ui://w3ox9yltv01m1ayr83g";

        public static page_btn2 CreateInstance()
        {
            return (page_btn2)UIPackage.CreateObject("fun_Recharge", "page_btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n16 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}