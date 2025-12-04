/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class probar4 : GProgressBar
    {
        public GImage bar;
        public const string URL = "ui://argzn455hstt1yjp840";

        public static probar4 CreateInstance()
        {
            return (probar4)UIPackage.CreateObject("fun_Dress", "probar4");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bar = (GImage)GetChildAt(0);
        }
    }
}