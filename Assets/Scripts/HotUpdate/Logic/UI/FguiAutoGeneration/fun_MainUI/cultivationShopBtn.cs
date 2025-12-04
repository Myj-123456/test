/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class cultivationShopBtn : GButton
    {
        public GImage n83;
        public GTextField titleLab;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybfm3f36";

        public static cultivationShopBtn CreateInstance()
        {
            return (cultivationShopBtn)UIPackage.CreateObject("fun_MainUI", "cultivationShopBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n83 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}