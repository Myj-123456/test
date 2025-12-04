/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class probar2 : GProgressBar
    {
        public GImage n0;
        public GImage bar;
        public const string URL = "ui://44kfvb3rm3gh1yjp814";

        public static probar2 CreateInstance()
        {
            return (probar2)UIPackage.CreateObject("fun_FlowerGold", "probar2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}