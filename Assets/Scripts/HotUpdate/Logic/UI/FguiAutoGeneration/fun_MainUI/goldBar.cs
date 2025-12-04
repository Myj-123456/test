/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class goldBar : GComponent
    {
        public GImage n24;
        public GImage gold_icon;
        public GTextField txtNum;
        public btn_recharge btnBuyCoin;
        public const string URL = "ui://fa0hi8ybfm3f16";

        public static goldBar CreateInstance()
        {
            return (goldBar)UIPackage.CreateObject("fun_MainUI", "goldBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n24 = (GImage)GetChildAt(0);
            gold_icon = (GImage)GetChildAt(1);
            txtNum = (GTextField)GetChildAt(2);
            btnBuyCoin = (btn_recharge)GetChildAt(3);
        }
    }
}