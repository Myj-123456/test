/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class greenPicBtn1 : GButton
    {
        public GImage n9;
        public GLoader pic;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GGroup n13;
        public GImage n12;
        public const string URL = "ui://wm7arakydhbs1yjp842";

        public static greenPicBtn1 CreateInstance()
        {
            return (greenPicBtn1)UIPackage.CreateObject("fun_VipShop", "greenPicBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n9 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            titleLab1 = (GTextField)GetChildAt(3);
            n13 = (GGroup)GetChildAt(4);
            n12 = (GImage)GetChildAt(5);
        }
    }
}