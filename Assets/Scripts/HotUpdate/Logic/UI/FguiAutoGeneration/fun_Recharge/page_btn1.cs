/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn1 : GButton
    {
        public Controller button;
        public GImage n13;
        public GImage n14;
        public GTextField titleLab;
        public const string URL = "ui://w3ox9yltg0s01ayr82m";

        public static page_btn1 CreateInstance()
        {
            return (page_btn1)UIPackage.CreateObject("fun_Recharge", "page_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n13 = (GImage)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}