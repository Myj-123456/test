/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_right1 : GButton
    {
        public GImage n3;
        public const string URL = "ui://mjiw43v9i9891yjp86m";

        public static common_right1 CreateInstance()
        {
            return (common_right1)UIPackage.CreateObject("common_New", "common_right1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n3 = (GImage)GetChildAt(0);
        }
    }
}