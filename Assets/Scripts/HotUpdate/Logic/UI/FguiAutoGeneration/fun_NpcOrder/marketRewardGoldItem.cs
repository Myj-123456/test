/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_NpcOrder
{
    public partial class marketRewardGoldItem : GComponent
    {
        public Controller rewardType;
        public GImage n14;
        public GLoader pic;
        public GTextField lb_value;
        public GImage icon_up;
        public GTextField txtRate;
        public GGroup n17;
        public const string URL = "ui://asaicjgylyil3";

        public static marketRewardGoldItem CreateInstance()
        {
            return (marketRewardGoldItem)UIPackage.CreateObject("fun_NpcOrder", "marketRewardGoldItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rewardType = GetControllerAt(0);
            n14 = (GImage)GetChildAt(0);
            pic = (GLoader)GetChildAt(1);
            lb_value = (GTextField)GetChildAt(2);
            icon_up = (GImage)GetChildAt(3);
            txtRate = (GTextField)GetChildAt(4);
            n17 = (GGroup)GetChildAt(5);
        }
    }
}