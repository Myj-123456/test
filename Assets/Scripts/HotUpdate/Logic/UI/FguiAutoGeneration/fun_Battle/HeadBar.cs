/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class HeadBar : GComponent
    {
        public Controller c1;
        public bloodbar myBlood;
        public Otherbloodbar otherBlood;
        public const string URL = "ui://z1b78orpf3otg";

        public static HeadBar CreateInstance()
        {
            return (HeadBar)UIPackage.CreateObject("fun_Battle", "HeadBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            c1 = GetControllerAt(0);
            myBlood = (bloodbar)GetChildAt(0);
            otherBlood = (Otherbloodbar)GetChildAt(1);
        }
    }
}