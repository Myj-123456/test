/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class blueBgBtn : GButton
    {
        public GImage n6;
        public GImage n7;
        public const string URL = "ui://ztwqlwa2q9bj1yjp7ut";

        public static blueBgBtn CreateInstance()
        {
            return (blueBgBtn)UIPackage.CreateObject("fun_SellingFlowers", "blueBgBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
        }
    }
}