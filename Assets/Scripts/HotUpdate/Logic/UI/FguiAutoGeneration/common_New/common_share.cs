/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace common_New
{
    public partial class common_share : GButton
    {
        public GImage n2;
        public const string URL = "ui://mjiw43v9p2vh1yjp870";

        public static common_share CreateInstance()
        {
            return (common_share)UIPackage.CreateObject("common_New", "common_share");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
        }
    }
}