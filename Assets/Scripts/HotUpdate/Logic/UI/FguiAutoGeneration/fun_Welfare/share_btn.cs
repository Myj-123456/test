/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class share_btn : GButton
    {
        public Controller button;
        public GImage n16;
        public GImage n17;
        public GImage n18;
        public GTextField n12;
        public GImage n19;
        public GTextField n20;
        public const string URL = "ui://awswhm01ux711yjp84c";

        public static share_btn CreateInstance()
        {
            return (share_btn)UIPackage.CreateObject("fun_Welfare", "share_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n16 = (GImage)GetChildAt(0);
            n17 = (GImage)GetChildAt(1);
            n18 = (GImage)GetChildAt(2);
            n12 = (GTextField)GetChildAt(3);
            n19 = (GImage)GetChildAt(4);
            n20 = (GTextField)GetChildAt(5);
        }
    }
}