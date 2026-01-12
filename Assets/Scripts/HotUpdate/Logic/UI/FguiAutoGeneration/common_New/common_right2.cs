/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_right2 : GButton
    {
        public GImage n4;
        public const string URL = "ui://mjiw43v9h3ye1yjp873";

        public static common_right2 CreateInstance()
        {
            return (common_right2)UIPackage.CreateObject("common_New", "common_right2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
        }
    }
}