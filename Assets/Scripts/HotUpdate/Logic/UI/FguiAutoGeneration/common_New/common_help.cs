/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_help : GButton
    {
        public GImage n1;
        public const string URL = "ui://mjiw43v9kelj1yjp85c";

        public static common_help CreateInstance()
        {
            return (common_help)UIPackage.CreateObject("common_New", "common_help");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}