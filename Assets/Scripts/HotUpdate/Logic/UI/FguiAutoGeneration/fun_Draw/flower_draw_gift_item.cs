/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class flower_draw_gift_item : GComponent
    {
        public Controller status;
        public GImage n0;
        public GTextField nameLab;
        public reward_item item1;
        public reward_item item2;
        public reward_item item3;
        public reward_item item4;
        public GTextField limitLab;
        public GButton buy_btn;
        public const string URL = "ui://97nah3khkeljuz";

        public static flower_draw_gift_item CreateInstance()
        {
            return (flower_draw_gift_item)UIPackage.CreateObject("fun_Draw", "flower_draw_gift_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            nameLab = (GTextField)GetChildAt(1);
            item1 = (reward_item)GetChildAt(2);
            item2 = (reward_item)GetChildAt(3);
            item3 = (reward_item)GetChildAt(4);
            item4 = (reward_item)GetChildAt(5);
            limitLab = (GTextField)GetChildAt(6);
            buy_btn = (GButton)GetChildAt(7);
        }
    }
}