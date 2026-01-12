/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class seventh_sign_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public seventh_sign_item item1;
        public seventh_sign_item item2;
        public seventh_sign_item item3;
        public seventh_sign_item item4;
        public seventh_sign_item item5;
        public seventh_sign_item item6;
        public seventh_sign_item item7;
        public GLoader3D spine;
        public GImage n12;
        public GImage n13;
        public GImage n14;
        public GLoader name_bg;
        public GLoader rare_img;
        public GTextField nameLab;
        public GTextField tiplab1;
        public GTextField tiplab2;
        public GGroup n31;
        public GImage n23;
        public GImage n24;
        public GImage n25;
        public GList list;
        public GTextField sub_title;
        public GGroup n30;
        public GButton getBtn;
        public const string URL = "ui://awswhm01s7sl1yjp848";

        public static seventh_sign_view CreateInstance()
        {
            return (seventh_sign_view)UIPackage.CreateObject("fun_Welfare", "seventh_sign_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            item1 = (seventh_sign_item)GetChildAt(1);
            item2 = (seventh_sign_item)GetChildAt(2);
            item3 = (seventh_sign_item)GetChildAt(3);
            item4 = (seventh_sign_item)GetChildAt(4);
            item5 = (seventh_sign_item)GetChildAt(5);
            item6 = (seventh_sign_item)GetChildAt(6);
            item7 = (seventh_sign_item)GetChildAt(7);
            spine = (GLoader3D)GetChildAt(8);
            n12 = (GImage)GetChildAt(9);
            n13 = (GImage)GetChildAt(10);
            n14 = (GImage)GetChildAt(11);
            name_bg = (GLoader)GetChildAt(12);
            rare_img = (GLoader)GetChildAt(13);
            nameLab = (GTextField)GetChildAt(14);
            tiplab1 = (GTextField)GetChildAt(15);
            tiplab2 = (GTextField)GetChildAt(16);
            n31 = (GGroup)GetChildAt(17);
            n23 = (GImage)GetChildAt(18);
            n24 = (GImage)GetChildAt(19);
            n25 = (GImage)GetChildAt(20);
            list = (GList)GetChildAt(21);
            sub_title = (GTextField)GetChildAt(22);
            n30 = (GGroup)GetChildAt(23);
            getBtn = (GButton)GetChildAt(24);
        }
    }
}