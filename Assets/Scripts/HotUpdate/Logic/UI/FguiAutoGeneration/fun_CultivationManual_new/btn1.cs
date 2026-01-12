/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class btn1 : GButton
    {
        public GImage n3;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wrp2vh1yjp86y";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_CultivationManual_new", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}