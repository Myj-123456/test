/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class probar : GProgressBar
    {
        public GImage bar;
        public const string URL = "ui://ehkqmfbpiust1ayr867";

        public static probar CreateInstance()
        {
            return (probar)UIPackage.CreateObject("fun_MyInfo", "probar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChildAt(0);
        }
    }
}