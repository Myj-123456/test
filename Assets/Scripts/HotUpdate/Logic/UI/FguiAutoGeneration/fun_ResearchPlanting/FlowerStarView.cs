/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_ResearchPlanting
{
    public partial class FlowerStarView : GComponent
    {
        public Controller selectStatus;
        public Controller upgradeStatus;
        public GGraph n11;
        public GLoader img_flower;
        public GButton btn_addFlower;
        public GTextField lb_tip_2;
        public GList ls_property;
        public GButton close_btn;
        public GButton btn_change;
        public scientAward awardItem_0;
        public scientAward awardItem_1;
        public GButton btn_cancel;
        public GButton btn_sure;
        public GRichTextField lb_tip_3;
        public const string URL = "ui://vhii0yjunqrs2";

        public static FlowerStarView CreateInstance()
        {
            return (FlowerStarView)UIPackage.CreateObject("fun_ResearchPlanting", "FlowerStarView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            selectStatus = GetControllerAt(0);
            upgradeStatus = GetControllerAt(1);
            n11 = (GGraph)GetChildAt(0);
            img_flower = (GLoader)GetChildAt(1);
            btn_addFlower = (GButton)GetChildAt(2);
            lb_tip_2 = (GTextField)GetChildAt(3);
            ls_property = (GList)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            btn_change = (GButton)GetChildAt(6);
            awardItem_0 = (scientAward)GetChildAt(7);
            awardItem_1 = (scientAward)GetChildAt(8);
            btn_cancel = (GButton)GetChildAt(9);
            btn_sure = (GButton)GetChildAt(10);
            lb_tip_3 = (GRichTextField)GetChildAt(11);
        }
    }
}