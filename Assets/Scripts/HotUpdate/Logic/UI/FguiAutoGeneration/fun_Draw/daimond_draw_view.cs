/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class daimond_draw_view : GComponent
    {
        public GLoader bg;
        public GLoader3D spine;
        public GLoader3D spine1;
        public GImage n29;
        public GLoader pic;
        public GTextField numLab;
        public GButton add_btn;
        public GGroup n34;
        public GImage n22;
        public GTextField timeLab;
        public GGroup n38;
        public btn detail_btn;
        public btn exchange_btn;
        public GGroup n52;
        public GImage n43;
        public GTextField times_Lab;
        public GTextField pre_lab;
        public GTextField after_lab;
        public GImage n47;
        public daimond_draw_btn one_com;
        public daimond_draw_btn ten_com;
        public skip_btn skin_btn;
        public GTextField skipLab;
        public GGroup n53;
        public GImage n39;
        public GTextField nameLab;
        public GGroup n54;
        public const string URL = "ui://97nah3khkeljv4";

        public static daimond_draw_view CreateInstance()
        {
            return (daimond_draw_view)UIPackage.CreateObject("fun_Draw", "daimond_draw_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            spine = (GLoader3D)GetChildAt(1);
            spine1 = (GLoader3D)GetChildAt(2);
            n29 = (GImage)GetChildAt(3);
            pic = (GLoader)GetChildAt(4);
            numLab = (GTextField)GetChildAt(5);
            add_btn = (GButton)GetChildAt(6);
            n34 = (GGroup)GetChildAt(7);
            n22 = (GImage)GetChildAt(8);
            timeLab = (GTextField)GetChildAt(9);
            n38 = (GGroup)GetChildAt(10);
            detail_btn = (btn)GetChildAt(11);
            exchange_btn = (btn)GetChildAt(12);
            n52 = (GGroup)GetChildAt(13);
            n43 = (GImage)GetChildAt(14);
            times_Lab = (GTextField)GetChildAt(15);
            pre_lab = (GTextField)GetChildAt(16);
            after_lab = (GTextField)GetChildAt(17);
            n47 = (GImage)GetChildAt(18);
            one_com = (daimond_draw_btn)GetChildAt(19);
            ten_com = (daimond_draw_btn)GetChildAt(20);
            skin_btn = (skip_btn)GetChildAt(21);
            skipLab = (GTextField)GetChildAt(22);
            n53 = (GGroup)GetChildAt(23);
            n39 = (GImage)GetChildAt(24);
            nameLab = (GTextField)GetChildAt(25);
            n54 = (GGroup)GetChildAt(26);
        }
    }
}