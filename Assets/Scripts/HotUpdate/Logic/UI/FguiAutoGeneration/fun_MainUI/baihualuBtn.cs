/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class baihualuBtn : GButton
    {
        public GImage n87;
        public GLoader3D spine;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybfm3f39";

        public static baihualuBtn CreateInstance()
        {
            return (baihualuBtn)UIPackage.CreateObject("fun_MainUI", "baihualuBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n87 = (GImage)GetChildAt(0);
            spine = (GLoader3D)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}