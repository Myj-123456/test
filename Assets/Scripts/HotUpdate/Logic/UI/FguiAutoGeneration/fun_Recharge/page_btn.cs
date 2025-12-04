/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn : GButton
    {
        public Controller button;
        public Controller status;
        public GImage n20;
        public GImage n21;
        public GImage n22;
        public GImage n23;
        public GImage n24;
        public GImage n25;
        public GImage n26;
        public GTextField titleLab;
        public const string URL = "ui://w3ox9yltdidl18";

        public static page_btn CreateInstance()
        {
            return (page_btn)UIPackage.CreateObject("fun_Recharge", "page_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            n20 = (GImage)GetChildAt(0);
            n21 = (GImage)GetChildAt(1);
            n22 = (GImage)GetChildAt(2);
            n23 = (GImage)GetChildAt(3);
            n24 = (GImage)GetChildAt(4);
            n25 = (GImage)GetChildAt(5);
            n26 = (GImage)GetChildAt(6);
            titleLab = (GTextField)GetChildAt(7);
        }
    }
}