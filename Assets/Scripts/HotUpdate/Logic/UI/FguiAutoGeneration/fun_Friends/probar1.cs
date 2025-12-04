/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class probar1 : GProgressBar
    {
        public GImage n2;
        public GImage bar;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tr";

        public static probar1 CreateInstance()
        {
            return (probar1)UIPackage.CreateObject("fun_Friends", "probar1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bar = (GImage)GetChildAt(1);
        }
    }
}