/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class chose_treasure_item : GButton
    {
        public Controller button;
        public GLoader bg;
        public GLoader icon;
        public GImage n5;
        public GTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://o7kmyysdx92m10";

        public static chose_treasure_item CreateInstance()
        {
            return (chose_treasure_item)UIPackage.CreateObject("fun_Pet", "chose_treasure_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            n5 = (GImage)GetChildAt(2);
            numLab = (GTextField)GetChildAt(3);
            nameLab = (GTextField)GetChildAt(4);
        }
    }
}