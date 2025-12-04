/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class flower_gold_into_item : GButton
    {
        public Controller button;
        public GImage n1;
        public GLoader icon;
        public GLoader icon1;
        public const string URL = "ui://44kfvb3rx92m34";

        public static flower_gold_into_item CreateInstance()
        {
            return (flower_gold_into_item)UIPackage.CreateObject("fun_FlowerGold", "flower_gold_into_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            icon1 = (GLoader)GetChildAt(2);
        }
    }
}