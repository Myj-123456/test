/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class btn1 : GButton
    {
        public GImage n0;
        public const string URL = "ui://wm7arakyvedm1ayr7sw";

        public static btn1 CreateInstance()
        {
            return (btn1)UIPackage.CreateObject("fun_VipShop", "btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
        }
    }
}