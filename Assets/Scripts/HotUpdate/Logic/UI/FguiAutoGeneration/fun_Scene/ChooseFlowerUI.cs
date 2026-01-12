/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class ChooseFlowerUI : GComponent
    {
        public GImage n21;
        public GImage n22;
        public toggleBtnOneKeyPlant1 toggleOneKeyPlant;
        public btn_flower_sort1 btn_sort_1;
        public btn_flower_sort1 btn_sort_2;
        public searchFlower1 searchFlower;
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

            n21 = (GImage)GetChildAt(0);
            n22 = (GImage)GetChildAt(1);
            toggleOneKeyPlant = (toggleBtnOneKeyPlant1)GetChildAt(2);
            btn_sort_1 = (btn_flower_sort1)GetChildAt(3);
            btn_sort_2 = (btn_flower_sort1)GetChildAt(4);
            searchFlower = (searchFlower1)GetChildAt(5);
            btn_left = (GButton)GetChildAt(6);
            btn_right = (GButton)GetChildAt(7);
            txt_pageNum = (GTextField)GetChildAt(8);
            list_flower = (GList)GetChildAt(9);
        }
    }
}