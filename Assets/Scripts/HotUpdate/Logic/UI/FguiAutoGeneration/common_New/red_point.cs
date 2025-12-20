/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class red_point : GComponent
    {
        public GImage n0;
        public const string URL = "ui://mjiw43v99sto1yjp86e";

        public static red_point CreateInstance()
        {
            return (red_point)UIPackage.CreateObject("common_New", "red_point");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}