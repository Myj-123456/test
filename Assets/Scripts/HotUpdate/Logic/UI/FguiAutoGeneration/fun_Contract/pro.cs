/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Contract
{
    public partial class pro : GProgressBar
    {
        public GImage n3;
        public GImage bar;
        public const string URL = "ui://ju8ssus8kkb10";

        public static pro CreateInstance()
        {
            return (pro)UIPackage.CreateObject("fun_Contract", "pro");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}