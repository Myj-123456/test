/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_into_view : GComponent
    {
        public Controller select;
        public GImage n2;
        public GLoader bg;
        public GImage n10;
        public GTextField titleLab;
        public GTextField tipLab;
        public GButton close_btn;
        public pet_into_item item1;
        public pet_into_item item2;
        public GButton sure_btn;
        public const string URL = "ui://o7kmyysdx92m2o";

        public static pet_into_view CreateInstance()
        {
            return (pet_into_view)UIPackage.CreateObject("fun_Pet", "pet_into_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            select = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n10 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            tipLab = (GTextField)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            item1 = (pet_into_item)GetChildAt(6);
            item2 = (pet_into_item)GetChildAt(7);
            sure_btn = (GButton)GetChildAt(8);
        }
    }
}