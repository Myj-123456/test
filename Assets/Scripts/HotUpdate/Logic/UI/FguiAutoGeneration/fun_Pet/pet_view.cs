/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_view : GComponent
    {
        public pet_content main;
        public GButton close_btn;
        public GImage n1;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n13;
        public btn fetters_btn;
        public btn book_btn;
        public GGroup n14;
        public const string URL = "ui://o7kmyysdt5nh1";

        public static pet_view CreateInstance()
        {
            return (pet_view)UIPackage.CreateObject("fun_Pet", "pet_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            main = (pet_content)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            n1 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            help_btn = (GButton)GetChildAt(4);
            n13 = (GGroup)GetChildAt(5);
            fetters_btn = (btn)GetChildAt(6);
            book_btn = (btn)GetChildAt(7);
            n14 = (GGroup)GetChildAt(8);
        }
    }
}