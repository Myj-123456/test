/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Battle
{
    public partial class SettlementRewardItem : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GTextField numLab;
        public GTextField txtName;
        public const string URL = "ui://z1b78orp12e1r2z";

        public static SettlementRewardItem CreateInstance()
        {
            return (SettlementRewardItem)UIPackage.CreateObject("fun_Battle", "SettlementRewardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            txtName = (GTextField)GetChildAt(3);
        }
    }
}