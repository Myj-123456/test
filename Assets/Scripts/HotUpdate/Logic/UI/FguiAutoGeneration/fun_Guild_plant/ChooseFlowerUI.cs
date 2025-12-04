/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class ChooseFlowerUI : GComponent
    {
        public GImage n0;
        public GButton btn_sort_1;
        public GButton btn_sort_2;
        public GComponent searchFlower;
        public GButton btn_left;
        public GButton btn_right;
        public GTextField txt_pageNum;
        public GList list_flower;
        public const string URL = "ui://qfpad3q0tewh1yjp7zp";

        public static ChooseFlowerUI CreateInstance()
        {
            return (ChooseFlowerUI)UIPackage.CreateObject("fun_Guild_plant", "ChooseFlowerUI");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n0 = (GImage)GetChildAt(0);
            btn_sort_1 = (GButton)GetChildAt(1);
            btn_sort_2 = (GButton)GetChildAt(2);
            searchFlower = (GComponent)GetChildAt(3);
            btn_left = (GButton)GetChildAt(4);
            btn_right = (GButton)GetChildAt(5);
            txt_pageNum = (GTextField)GetChildAt(6);
            list_flower = (GList)GetChildAt(7);
        }
    }
}