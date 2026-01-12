/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Welfare
{
    public partial class SeventhSign : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GImage n29;
        public GImage n24;
        public GImage n25;
        public GLoader3D spine;
        public GImage n32;
        public GList list;
        public GButton getBtn;
        public seventh_sign_item item1;
        public seventh_sign_item item2;
        public seventh_sign_item item3;
        public seventh_sign_item item4;
        public seventh_sign_item item5;
        public seventh_sign_item item6;
        public seventh_sign_item item7;
        public GImage n13;
        public GImage n14;
        public GLoader name_bg;
        public GLoader rare_img;
        public GTextField nameLab;
        public GTextField tiplab1;
        public GTextField tiplab2;
        public GTextField sub_title;
        public btn_close close_btn;
        public const string URL = "ui://awswhm01i9891yjp859";

        public static SeventhSign CreateInstance()
        {
            return (SeventhSign)UIPackage.CreateObject("fun_Welfare", "SeventhSign");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n29 = (GImage)GetChildAt(1);
            n24 = (GImage)GetChildAt(2);
            n25 = (GImage)GetChildAt(3);
            spine = (GLoader3D)GetChildAt(4);
            n32 = (GImage)GetChildAt(5);
            list = (GList)GetChildAt(6);
            getBtn = (GButton)GetChildAt(7);
            item1 = (seventh_sign_item)GetChildAt(8);
            item2 = (seventh_sign_item)GetChildAt(9);
            item3 = (seventh_sign_item)GetChildAt(10);
            item4 = (seventh_sign_item)GetChildAt(11);
            item5 = (seventh_sign_item)GetChildAt(12);
            item6 = (seventh_sign_item)GetChildAt(13);
            item7 = (seventh_sign_item)GetChildAt(14);
            n13 = (GImage)GetChildAt(15);
            n14 = (GImage)GetChildAt(16);
            name_bg = (GLoader)GetChildAt(17);
            rare_img = (GLoader)GetChildAt(18);
            nameLab = (GTextField)GetChildAt(19);
            tiplab1 = (GTextField)GetChildAt(20);
            tiplab2 = (GTextField)GetChildAt(21);
            sub_title = (GTextField)GetChildAt(22);
            close_btn = (btn_close)GetChildAt(23);
        }
    }
}