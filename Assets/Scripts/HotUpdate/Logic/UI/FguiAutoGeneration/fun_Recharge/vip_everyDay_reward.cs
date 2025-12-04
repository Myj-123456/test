/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class vip_everyDay_reward : GComponent
    {
        public GTextField count;
        public GButton close_btn;
        public GButton get_btn;
        public GLoader icon;
        public const string URL = "ui://w3ox9yltnqrsy";

        public static vip_everyDay_reward CreateInstance()
        {
            return (vip_everyDay_reward)UIPackage.CreateObject("fun_Recharge", "vip_everyDay_reward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            count = (GTextField)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            get_btn = (GButton)GetChildAt(2);
            icon = (GLoader)GetChildAt(3);
        }
    }
}