/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class probar : GProgressBar
    {
        public GImage bar;
        public const string URL = "ui://vhii0yjunqrs1yjp7xh";

        public static probar CreateInstance()
        {
            return (probar)UIPackage.CreateObject("fun_ResearchPlanting", "probar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChildAt(0);
        }
    }
}