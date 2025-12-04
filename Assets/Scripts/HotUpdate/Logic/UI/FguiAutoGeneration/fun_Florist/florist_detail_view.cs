/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Florist
{
    public partial class florist_detail_view : GComponent
    {
        public Controller have;
        public Controller status;
        public GLoader bg;
        public GLoader bg1;
        public GImage n4;
        public GImage n17;
        public GImage n20;
        public GLoader rare_img;
        public GButton close_btn;
        public GLoader icon;
        public GTextField nameLab;
        public GTextField floristLab;
        public GTextField decLab;
        public GTextField haveLab;
        public GButton btn;
        public florist_detail_item item0;
        public florist_detail_item item1;
        public florist_detail_item item2;
        public GGroup n28;
        public const string URL = "ui://nj16dzxym3gh50";

        public static florist_detail_view CreateInstance()
        {
            return (florist_detail_view)UIPackage.CreateObject("fun_Florist", "florist_detail_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            have = GetControllerAt(0);
            status = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n17 = (GImage)GetChildAt(3);
            n20 = (GImage)GetChildAt(4);
            rare_img = (GLoader)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            icon = (GLoader)GetChildAt(7);
            nameLab = (GTextField)GetChildAt(8);
            floristLab = (GTextField)GetChildAt(9);
            decLab = (GTextField)GetChildAt(10);
            haveLab = (GTextField)GetChildAt(11);
            btn = (GButton)GetChildAt(12);
            item0 = (florist_detail_item)GetChildAt(13);
            item1 = (florist_detail_item)GetChildAt(14);
            item2 = (florist_detail_item)GetChildAt(15);
            n28 = (GGroup)GetChildAt(16);
        }
    }
}