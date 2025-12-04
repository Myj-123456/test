/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class into_battle_item : GButton
    {
        public Controller type;
        public Controller button;
        public Controller into;
        public GLoader quality_img;
        public GImage n4;
        public GLoader pet_img;
        public GLoader flower_god_img;
        public GImage n6;
        public GTextField nameLab;
        public GTextField levelLab;
        public GImage n10;
        public const string URL = "ui://oo5kr0yot5nh19";

        public static into_battle_item CreateInstance()
        {
            return (into_battle_item)UIPackage.CreateObject("fun_Tour_Land", "into_battle_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            button = GetControllerAt(1);
            into = GetControllerAt(2);
            quality_img = (GLoader)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            pet_img = (GLoader)GetChildAt(2);
            flower_god_img = (GLoader)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            nameLab = (GTextField)GetChildAt(5);
            levelLab = (GTextField)GetChildAt(6);
            n10 = (GImage)GetChildAt(7);
        }
    }
}