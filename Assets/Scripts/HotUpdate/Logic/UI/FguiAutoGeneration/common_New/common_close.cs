/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_close : GButton
    {
        public GImage n0;
        public const string URL = "ui://mjiw43v9u25n1yjp848";

        public static common_close CreateInstance()
        {
            return (common_close)UIPackage.CreateObject("common_New", "common_close");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}