/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class clickBtn1 : GButton
    {
        public GImage n8;
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://ztwqlwa2q9bj1yjp7ui";

        public static clickBtn1 CreateInstance()
        {
            return (clickBtn1)UIPackage.CreateObject("fun_SellingFlowers", "clickBtn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}