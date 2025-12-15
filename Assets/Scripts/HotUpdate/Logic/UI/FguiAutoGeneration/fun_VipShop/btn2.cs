/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class btn2 : GButton
    {
        public GImage n9;
        public GTextField titleLab;
        public const string URL = "ui://wm7arakydhbs1yjp83u";

        public static btn2 CreateInstance()
        {
            return (btn2)UIPackage.CreateObject("fun_VipShop", "btn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}