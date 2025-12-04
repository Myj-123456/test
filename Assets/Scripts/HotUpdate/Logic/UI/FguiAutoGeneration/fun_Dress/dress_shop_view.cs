/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Dress
{
    public partial class dress_shop_view : GComponent
    {
        public GLoader bg;
        public GImage n58;
        public GImage n61;
        public GLoader bg1;
        public GImage n17;
        public GTextField typeLab;
        public GImage n50;
        public probar4 pro;
        public GImage n51;
        public GTextField lvLab;
        public GTextField proLab;
        public GImage n52;
        public GImage n53;
        public GLoader icon;
        public GLoader rare_img;
        public GTextField nameLab;
        public GTextField charmLab;
        public GTextField charmNum;
        public GGroup n62;
        public GButton close_btn;
        public GImage n2;
        public GImage n5;
        public GLoader img;
        public GTextField titleLab;
        public GButton help_btn;
        public GTextField txt_num;
        public GGroup n57;
        public GList list_filter;
        public GList list;
        public GImage n60;
        public const string URL = "ui://argzn455hstt1yjp83x";

        public static dress_shop_view CreateInstance()
        {
            return (dress_shop_view)UIPackage.CreateObject("fun_Dress", "dress_shop_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n58 = (GImage)GetChildAt(1);
            n61 = (GImage)GetChildAt(2);
            bg1 = (GLoader)GetChildAt(3);
            n17 = (GImage)GetChildAt(4);
            typeLab = (GTextField)GetChildAt(5);
            n50 = (GImage)GetChildAt(6);
            pro = (probar4)GetChildAt(7);
            n51 = (GImage)GetChildAt(8);
            lvLab = (GTextField)GetChildAt(9);
            proLab = (GTextField)GetChildAt(10);
            n52 = (GImage)GetChildAt(11);
            n53 = (GImage)GetChildAt(12);
            icon = (GLoader)GetChildAt(13);
            rare_img = (GLoader)GetChildAt(14);
            nameLab = (GTextField)GetChildAt(15);
            charmLab = (GTextField)GetChildAt(16);
            charmNum = (GTextField)GetChildAt(17);
            n62 = (GGroup)GetChildAt(18);
            close_btn = (GButton)GetChildAt(19);
            n2 = (GImage)GetChildAt(20);
            n5 = (GImage)GetChildAt(21);
            img = (GLoader)GetChildAt(22);
            titleLab = (GTextField)GetChildAt(23);
            help_btn = (GButton)GetChildAt(24);
            txt_num = (GTextField)GetChildAt(25);
            n57 = (GGroup)GetChildAt(26);
            list_filter = (GList)GetChildAt(27);
            list = (GList)GetChildAt(28);
            n60 = (GImage)GetChildAt(29);
        }
    }
}