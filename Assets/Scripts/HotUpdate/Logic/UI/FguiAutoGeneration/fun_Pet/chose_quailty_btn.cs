/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class chose_quailty_btn : GButton
    {
        public Controller status;
        public GImage n1;
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://o7kmyysdx92m1yjp80j";

        public static chose_quailty_btn CreateInstance()
        {
            return (chose_quailty_btn)UIPackage.CreateObject("fun_Pet", "chose_quailty_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}