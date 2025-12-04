/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class waterBar : GComponent
    {
        public Controller stats;
        public GImage n36;
        public GImage n33;
        public GTextField txtNum;
        public GGroup n37;
        public const string URL = "ui://fa0hi8ybfm3f3d";

        public static waterBar CreateInstance()
        {
            return (waterBar)UIPackage.CreateObject("fun_MainUI", "waterBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            stats = GetControllerAt(0);
            n36 = (GImage)GetChildAt(0);
            n33 = (GImage)GetChildAt(1);
            txtNum = (GTextField)GetChildAt(2);
            n37 = (GGroup)GetChildAt(3);
        }
    }
}