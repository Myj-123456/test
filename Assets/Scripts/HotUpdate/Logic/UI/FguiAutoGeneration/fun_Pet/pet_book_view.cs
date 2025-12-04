/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Pet
{
    public partial class pet_book_view : GComponent
    {
        public Controller showChose;
        public GLoader bg;
        public GImage n2;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n5;
        public GImage n9;
        public GButton close_btn;
        public GList list;
        public GImage n6;
        public chose_quailty_btn chose_btn;
        public chose_qualirt chose_grp;
        public GGroup n12;
        public const string URL = "ui://o7kmyysdx92mj";

        public static pet_book_view CreateInstance()
        {
            return (pet_book_view)UIPackage.CreateObject("fun_Pet", "pet_book_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            showChose = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            help_btn = (GButton)GetChildAt(3);
            n5 = (GGroup)GetChildAt(4);
            n9 = (GImage)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            list = (GList)GetChildAt(7);
            n6 = (GImage)GetChildAt(8);
            chose_btn = (chose_quailty_btn)GetChildAt(9);
            chose_grp = (chose_qualirt)GetChildAt(10);
            n12 = (GGroup)GetChildAt(11);
        }
    }
}