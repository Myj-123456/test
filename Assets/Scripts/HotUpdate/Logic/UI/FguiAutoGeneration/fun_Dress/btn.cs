/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class btn : GButton
    {
        public Controller type;
        public GImage n86;
        public GImage n89;
        public GImage n90;
        public GTextField titleLab;
        public const string URL = "ui://argzn455ojbq17";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_Dress", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n86 = (GImage)GetChildAt(0);
            n89 = (GImage)GetChildAt(1);
            n90 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
        }
    }
}