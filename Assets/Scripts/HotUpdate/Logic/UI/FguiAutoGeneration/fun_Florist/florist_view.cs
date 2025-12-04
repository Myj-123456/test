/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public level_view level_view;
        public florist_book_view book_view;
        public GImage n1;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n44;
        public GImage n3;
        public GImage n7;
        public GImage n8;
        public pageBtn1 level_btn;
        public pageBtn1 florist_btn;
        public pageBtn1 plant_btn;
        public GButton close_btn;
        public GGroup n45;
        public const string URL = "ui://nj16dzxym3gh2";

        public static florist_view CreateInstance()
        {
            return (florist_view)UIPackage.CreateObject("fun_Florist", "florist_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            level_view = (level_view)GetChildAt(1);
            book_view = (florist_book_view)GetChildAt(2);
            n1 = (GImage)GetChildAt(3);
            titleLab = (GTextField)GetChildAt(4);
            help_btn = (GButton)GetChildAt(5);
            n44 = (GGroup)GetChildAt(6);
            n3 = (GImage)GetChildAt(7);
            n7 = (GImage)GetChildAt(8);
            n8 = (GImage)GetChildAt(9);
            level_btn = (pageBtn1)GetChildAt(10);
            florist_btn = (pageBtn1)GetChildAt(11);
            plant_btn = (pageBtn1)GetChildAt(12);
            close_btn = (GButton)GetChildAt(13);
            n45 = (GGroup)GetChildAt(14);
        }
    }
}