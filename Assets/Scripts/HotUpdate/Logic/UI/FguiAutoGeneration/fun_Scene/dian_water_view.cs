/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Scene
{
    public partial class dian_water_view : GComponent
    {
        public GLoader bg;
        public GImage n6;
        public GImage n7;
        public GImage n8;
        public GImage n9;
        public GButton close_btn;
        public dian_water_item item1;
        public dian_water_item item2;
        public dian_water_item item3;
        public const string URL = "ui://dpcxz2fikkb12p";

        public static dian_water_view CreateInstance()
        {
            return (dian_water_view)UIPackage.CreateObject("fun_Scene", "dian_water_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n6 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            n8 = (GImage)GetChildAt(3);
            n9 = (GImage)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            item1 = (dian_water_item)GetChildAt(6);
            item2 = (dian_water_item)GetChildAt(7);
            item3 = (dian_water_item)GetChildAt(8);
        }
    }
}