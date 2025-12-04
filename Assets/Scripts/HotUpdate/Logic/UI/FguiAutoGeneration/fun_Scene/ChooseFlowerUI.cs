/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class ChooseFlowerUI : GComponent
    {
        public GImage n0;
        public toggleBtnOneKeyPlant toggleOneKeyPlant;
        public btn_flower_sort btn_sort_1;
        public btn_flower_sort btn_sort_2;
        public searchFlower searchFlower;
        public GButton btn_left;
        public GButton btn_right;
        public GTextField txt_pageNum;
        public GList list_flower;
        public const string URL = "ui://dpcxz2fiqgju1l";

        public static ChooseFlowerUI CreateInstance()
        {
            return (ChooseFlowerUI)UIPackage.CreateObject("fun_Scene", "ChooseFlowerUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            toggleOneKeyPlant = (toggleBtnOneKeyPlant)GetChildAt(1);
            btn_sort_1 = (btn_flower_sort)GetChildAt(2);
            btn_sort_2 = (btn_flower_sort)GetChildAt(3);
            searchFlower = (searchFlower)GetChildAt(4);
            btn_left = (GButton)GetChildAt(5);
            btn_right = (GButton)GetChildAt(6);
            txt_pageNum = (GTextField)GetChildAt(7);
            list_flower = (GList)GetChildAt(8);
        }
    }
}