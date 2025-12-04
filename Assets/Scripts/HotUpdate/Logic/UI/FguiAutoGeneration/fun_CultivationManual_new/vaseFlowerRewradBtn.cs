/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class vaseFlowerRewradBtn : GButton
    {
        public GImage n65;
        public const string URL = "ui://ekoic0wriust13";

        public static vaseFlowerRewradBtn CreateInstance()
        {
            return (vaseFlowerRewradBtn)UIPackage.CreateObject("fun_CultivationManual_new", "vaseFlowerRewradBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n65 = (GImage)GetChildAt(0);
        }
    }
}