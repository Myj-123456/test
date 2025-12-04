/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class vaseFlowerRewradBtn : GButton
    {
        public GImage n65;
        public const string URL = "ui://6q8q1ai6ftbu1ayr850";

        public static vaseFlowerRewradBtn CreateInstance()
        {
            return (vaseFlowerRewradBtn)UIPackage.CreateObject("fun_CultivationManual", "vaseFlowerRewradBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n65 = (GImage)GetChildAt(0);
        }
    }
}