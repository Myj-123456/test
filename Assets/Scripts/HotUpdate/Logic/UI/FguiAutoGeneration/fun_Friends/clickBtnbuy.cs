/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class clickBtnbuy : GButton
    {
        public GImage n6;
        public GImage n7;
        public GTextField titleLab;
        public const string URL = "ui://fteyf9nzg3sj1yjp7to";

        public static clickBtnbuy CreateInstance()
        {
            return (clickBtnbuy)UIPackage.CreateObject("fun_Friends", "clickBtnbuy");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}