/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class btn_recharge : GButton
    {
        public GImage n86;
        public const string URL = "ui://fa0hi8ybqheb3m";

        public static btn_recharge CreateInstance()
        {
            return (btn_recharge)UIPackage.CreateObject("fun_MainUI", "btn_recharge");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n86 = (GImage)GetChildAt(0);
        }
    }
}