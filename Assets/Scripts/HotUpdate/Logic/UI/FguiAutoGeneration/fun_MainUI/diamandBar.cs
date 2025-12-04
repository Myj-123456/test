/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_MainUI
{
    public partial class diamandBar : GComponent
    {
        public GImage n24;
        public GImage cash_icon;
        public GTextField txtNum;
        public btn_recharge btn_recharge;
        public const string URL = "ui://fa0hi8ybfm3f1a";

        public static diamandBar CreateInstance()
        {
            return (diamandBar)UIPackage.CreateObject("fun_MainUI", "diamandBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n24 = (GImage)GetChildAt(0);
            cash_icon = (GImage)GetChildAt(1);
            txtNum = (GTextField)GetChildAt(2);
            btn_recharge = (btn_recharge)GetChildAt(3);
        }
    }
}