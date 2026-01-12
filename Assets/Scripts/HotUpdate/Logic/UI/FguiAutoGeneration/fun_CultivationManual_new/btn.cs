/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class btn : GButton
    {
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wri9891yjp7ym";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_CultivationManual_new", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}