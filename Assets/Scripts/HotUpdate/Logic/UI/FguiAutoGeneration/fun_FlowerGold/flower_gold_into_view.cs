/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_into_view : GComponent
    {
        public Controller select;
        public GImage n2;
        public GLoader bg;
        public GImage n14;
        public GImage n10;
        public GTextField tipLab;
        public GButton close_btn;
        public flower_gold_into_item item1;
        public flower_gold_into_item item2;
        public flower_gold_into_item item3;
        public GButton sure_btn;
        public const string URL = "ui://44kfvb3rx92m33";

        public static flower_gold_into_view CreateInstance()
        {
            return (flower_gold_into_view)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_into_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            n10 = (GImage)GetChildAt(3);
            tipLab = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            item1 = (flower_gold_into_item)GetChildAt(6);
            item2 = (flower_gold_into_item)GetChildAt(7);
            item3 = (flower_gold_into_item)GetChildAt(8);
            sure_btn = (GButton)GetChildAt(9);
        }
    }
}