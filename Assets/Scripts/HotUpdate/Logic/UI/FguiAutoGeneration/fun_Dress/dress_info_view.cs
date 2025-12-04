/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_info_view : GComponent
    {
        public Controller skillShow;
        public GLoader bg;
        public GLoader3D role;
        public GImage n81;
        public GImage n34;
        public GImage n36;
        public GTextField up_title;
        public GList list;
        public GImage n38;
        public GImage n53;
        public GTextField skillLab;
        public nature_item2 skill;
        public GGroup n80;
        public GGroup n83;
        public GLoader rare_img;
        public GTextField nameLab;
        public GList dress_list;
        public GGroup n84;
        public GButton close_btn;
        public GImage n25;
        public GTextField titleLab;
        public GButton help_btn;
        public GGroup n68;
        public const string URL = "ui://argzn455m3gh1j";

        public static dress_info_view CreateInstance()
        {
            return (dress_info_view)UIPackage.CreateObject("fun_Dress", "dress_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            skillShow = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            role = (GLoader3D)GetChildAt(1);
            n81 = (GImage)GetChildAt(2);
            n34 = (GImage)GetChildAt(3);
            n36 = (GImage)GetChildAt(4);
            up_title = (GTextField)GetChildAt(5);
            list = (GList)GetChildAt(6);
            n38 = (GImage)GetChildAt(7);
            n53 = (GImage)GetChildAt(8);
            skillLab = (GTextField)GetChildAt(9);
            skill = (nature_item2)GetChildAt(10);
            n80 = (GGroup)GetChildAt(11);
            n83 = (GGroup)GetChildAt(12);
            rare_img = (GLoader)GetChildAt(13);
            nameLab = (GTextField)GetChildAt(14);
            dress_list = (GList)GetChildAt(15);
            n84 = (GGroup)GetChildAt(16);
            close_btn = (GButton)GetChildAt(17);
            n25 = (GImage)GetChildAt(18);
            titleLab = (GTextField)GetChildAt(19);
            help_btn = (GButton)GetChildAt(20);
            n68 = (GGroup)GetChildAt(21);
        }
    }
}