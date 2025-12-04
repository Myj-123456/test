/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class moreBtn : GButton
    {
        public GImage n83;
        public GImage img_arrows;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybfm3f38";

        public static moreBtn CreateInstance()
        {
            return (moreBtn)UIPackage.CreateObject("fun_MainUI", "moreBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n83 = (GImage)GetChildAt(0);
            img_arrows = (GImage)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}