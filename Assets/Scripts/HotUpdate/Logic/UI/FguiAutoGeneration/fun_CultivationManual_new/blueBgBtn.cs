/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class blueBgBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://ekoic0wrqheb1yjp7v7";

        public static blueBgBtn CreateInstance()
        {
            return (blueBgBtn)UIPackage.CreateObject("fun_CultivationManual_new", "blueBgBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}