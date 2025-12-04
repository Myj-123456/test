/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class funRightBtn : GButton
    {
        public Controller type;
        public Controller status;
        public GGraph n104;
        public GImage n95;
        public GImage red_point;
        public GImage n97;
        public GTextField txtFunName;
        public GTextField timeLab;
        public GImage n99;
        public GImage n101;
        public GImage n102;
        public GImage n103;
        public const string URL = "ui://fa0hi8ybfm3f33";

        public static funRightBtn CreateInstance()
        {
            return (funRightBtn)UIPackage.CreateObject("fun_MainUI", "funRightBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            status = GetControllerAt(1);
            n104 = (GGraph)GetChildAt(0);
            n95 = (GImage)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
            n97 = (GImage)GetChildAt(3);
            txtFunName = (GTextField)GetChildAt(4);
            timeLab = (GTextField)GetChildAt(5);
            n99 = (GImage)GetChildAt(6);
            n101 = (GImage)GetChildAt(7);
            n102 = (GImage)GetChildAt(8);
            n103 = (GImage)GetChildAt(9);
        }
    }
}