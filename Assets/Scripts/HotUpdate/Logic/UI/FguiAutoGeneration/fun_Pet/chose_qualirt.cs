/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class chose_qualirt : GComponent
    {
        public Controller quality;
        public GImage n1;
        public GList list;
        public const string URL = "ui://o7kmyysdx92m1yjp80k";

        public static chose_qualirt CreateInstance()
        {
            return (chose_qualirt)UIPackage.CreateObject("fun_Pet", "chose_qualirt");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            quality = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            list = (GList)GetChildAt(1);
        }
    }
}