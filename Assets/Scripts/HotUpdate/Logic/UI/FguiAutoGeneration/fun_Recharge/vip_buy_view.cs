/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class vip_buy_view : GComponent
    {
        public GTextField vipTime;
        public GButton close_btn;
        public GButton buy_btn;
        public const string URL = "ui://w3ox9yltn5lkx";

        public static vip_buy_view CreateInstance()
        {
            return (vip_buy_view)UIPackage.CreateObject("fun_Recharge", "vip_buy_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            vipTime = (GTextField)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            buy_btn = (GButton)GetChildAt(2);
        }
    }
}