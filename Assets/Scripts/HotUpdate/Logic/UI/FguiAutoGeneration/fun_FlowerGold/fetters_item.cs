/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerGold
{
    public partial class fetters_item : GComponent
    {
        public Controller active;
        public GImage n1;
        public GImage n10;
        public GImage n6;
        public GTextField nameLab;
        public GTextField attrLab;
        public GTextField n9;
        public GTextField lvLab;
        public GList petList;
        public GButton level_btn;
        public GButton detail_btn;
        public const string URL = "ui://44kfvb3rv5lj1yjp81m";

        public static fetters_item CreateInstance()
        {
            return (fetters_item)UIPackage.CreateObject("fun_FlowerGold", "fetters_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            active = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
            n6 = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
            attrLab = (GTextField)GetChildAt(4);
            n9 = (GTextField)GetChildAt(5);
            lvLab = (GTextField)GetChildAt(6);
            petList = (GList)GetChildAt(7);
            level_btn = (GButton)GetChildAt(8);
            detail_btn = (GButton)GetChildAt(9);
        }
    }
}