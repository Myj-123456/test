/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MyInfo
{
    public partial class probar1 : GProgressBar
    {
        public GImage n4;
        public GImage bar;
        public const string URL = "ui://ehkqmfbpj9p61yjp7xz";

        public static probar1 CreateInstance()
        {
            return (probar1)UIPackage.CreateObject("fun_MyInfo", "probar1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}