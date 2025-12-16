/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class best_clickBtn2 : GButton
    {
        public GImage n11;
        public GTextField n10;
        public const string URL = "ui://fteyf9nzs5f01yjp7vk";

        public static best_clickBtn2 CreateInstance()
        {
            return (best_clickBtn2)UIPackage.CreateObject("fun_Friends", "best_clickBtn2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n11 = (GImage)GetChildAt(0);
            n10 = (GTextField)GetChildAt(1);
        }
    }
}