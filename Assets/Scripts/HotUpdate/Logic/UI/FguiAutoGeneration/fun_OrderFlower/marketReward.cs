/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class marketReward : GComponent
    {
        public getReward_item marketRewardExpItem;
        public getReward_item marketRewardGoldItem;
        public const string URL = "ui://ypcg4u88u0i3b";

        public static marketReward CreateInstance()
        {
            return (marketReward)UIPackage.CreateObject("fun_OrderFlower", "marketReward");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            marketRewardExpItem = (getReward_item)GetChildAt(0);
            marketRewardGoldItem = (getReward_item)GetChildAt(1);
        }
    }
}