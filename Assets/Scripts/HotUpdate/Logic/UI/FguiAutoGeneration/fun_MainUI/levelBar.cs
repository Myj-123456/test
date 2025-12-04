/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class levelBar : GComponent
    {
        public Controller stats;
        public GImage n32;
        public GImage n33;
        public GTextField txtNum;
        public GTextField txtLevel;
        public GGroup n38;
        public const string URL = "ui://fa0hi8ybfm3f1g";

        public static levelBar CreateInstance()
        {
            return (levelBar)UIPackage.CreateObject("fun_MainUI", "levelBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            stats = GetControllerAt(0);
            n32 = (GImage)GetChildAt(0);
            n33 = (GImage)GetChildAt(1);
            txtNum = (GTextField)GetChildAt(2);
            txtLevel = (GTextField)GetChildAt(3);
            n38 = (GGroup)GetChildAt(4);
        }
    }
}