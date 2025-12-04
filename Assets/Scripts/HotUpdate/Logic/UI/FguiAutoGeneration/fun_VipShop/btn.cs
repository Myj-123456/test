/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class btn : GButton
    {
        public GImage n1;
        public const string URL = "ui://wm7arakyvedm1ayr7st";

        public static btn CreateInstance()
        {
            return (btn)UIPackage.CreateObject("fun_VipShop", "btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
        }
    }
}