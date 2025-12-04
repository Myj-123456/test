/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class greenPicBtn : GButton
    {
        public GImage n6;
        public GLoader pic;
        public GTextField titleLab;
        public const string URL = "ui://wm7arakyvedm1yjp83p";

        public static greenPicBtn CreateInstance()
        {
            return (greenPicBtn)UIPackage.CreateObject("fun_VipShop", "greenPicBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}