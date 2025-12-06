/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_back : GButton
    {
        public GImage n1;
        public const string URL = "ui://mjiw43v9kelj1yjp85g";

        public static common_back CreateInstance()
        {
            return (common_back)UIPackage.CreateObject("common_New", "common_back");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}