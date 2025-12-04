/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class gmBtn : GButton
    {
        public GImage n2;
        public GTextField n1;
        public const string URL = "ui://fa0hi8ybgtg93j";

        public static gmBtn CreateInstance()
        {
            return (gmBtn)UIPackage.CreateObject("fun_MainUI", "gmBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            n1 = (GTextField)GetChildAt(1);
        }
    }
}