/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class oddBtn : GButton
    {
        public Controller button;
        public GImage n0;
        public GImage n1;
        public const string URL = "ui://ztwqlwa2q9bj1yjp7us";

        public static oddBtn CreateInstance()
        {
            return (oddBtn)UIPackage.CreateObject("fun_SellingFlowers", "oddBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n1 = (GImage)GetChildAt(1);
        }
    }
}