/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class clickBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public GImage n8;
        public const string URL = "ui://ztwqlwa2q9bj1yjp7uh";

        public static clickBtn CreateInstance()
        {
            return (clickBtn)UIPackage.CreateObject("fun_SellingFlowers", "clickBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n8 = (GImage)GetChildAt(2);
        }
    }
}