/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class baihualuBtn : GButton
    {
        public GLoader3D spine;
        public GLoader n85;
        public GImage red_point;
        public const string URL = "ui://fa0hi8ybfm3f39";

        public static baihualuBtn CreateInstance()
        {
            return (baihualuBtn)UIPackage.CreateObject("fun_MainUI", "baihualuBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            spine = (GLoader3D)GetChildAt(0);
            n85 = (GLoader)GetChildAt(1);
            red_point = (GImage)GetChildAt(2);
        }
    }
}