/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class probar : GProgressBar
    {
        public GImage n2;
        public GImage bar;
        public const string URL = "ui://44kfvb3rx92m2x";

        public static probar CreateInstance()
        {
            return (probar)UIPackage.CreateObject("fun_FlowerGold", "probar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}