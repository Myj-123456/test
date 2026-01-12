/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class pro : GProgressBar
    {
        public GImage n3;
        public GImage bar;
        public const string URL = "ui://ekoic0wrp2vh1yjp86v";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_CultivationManual_new", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}