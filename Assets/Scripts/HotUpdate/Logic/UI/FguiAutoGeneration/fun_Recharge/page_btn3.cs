/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class page_btn3 : GButton
    {
        public Controller button;
        public GImage n21;
        public GImage n22;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://w3ox9yltin5z1yjp87n";

        public static page_btn3 CreateInstance()
        {
            return (page_btn3)UIPackage.CreateObject("fun_Recharge", "page_btn3");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n21 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            red_point = (GImage)GetChildAt(3);
        }
    }
}