/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class level_list_item : GComponent
    {
        public Controller status;
        public Controller skill;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n8;
        public GTextField lvlab;
        public nature_item_txt nature;
        public GImage n6;
        public GTextField skillLab;
        public GGroup n10;
        public const string URL = "ui://44kfvb3rm3gh3y";

        public static level_list_item CreateInstance()
        {
            return (level_list_item)UIPackage.CreateObject("fun_FlowerGold", "level_list_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            skill = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
            lvlab = (GTextField)GetChildAt(4);
            nature = (nature_item_txt)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            skillLab = (GTextField)GetChildAt(7);
            n10 = (GGroup)GetChildAt(8);
        }
    }
}