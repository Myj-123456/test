/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Draw
{
    public partial class flower_draw_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GLoader3D spine;
        public GLoader3D spine1;
        public GRichTextField tipLab;
        public GImage n10;
        public GTextField nameLab;
        public GGroup n19;
        public GImage n22;
        public GTextField timeLab;
        public GGroup n24;
        public GImage n29;
        public GLoader pic;
        public GTextField numLab;
        public GButton add_btn;
        public GGroup n34;
        public draw_one_btn one_btn;
        public draw_ten_btn ten_btn;
        public btn1 gift_btn;
        public skip_btn skip_btn;
        public GTextField skipLab;
        public GGroup n35;
        public btn detail_btn;
        public btn change_btn;
        public GGroup n36;
        public const string URL = "ui://97nah3kh11rnup";

        public static flower_draw_view CreateInstance()
        {
            return (flower_draw_view)UIPackage.CreateObject("fun_Draw", "flower_draw_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            spine1 = (GLoader3D)GetChildAt(3);
            tipLab = (GRichTextField)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            n19 = (GGroup)GetChildAt(7);
            n22 = (GImage)GetChildAt(8);
            timeLab = (GTextField)GetChildAt(9);
            n24 = (GGroup)GetChildAt(10);
            n29 = (GImage)GetChildAt(11);
            pic = (GLoader)GetChildAt(12);
            numLab = (GTextField)GetChildAt(13);
            add_btn = (GButton)GetChildAt(14);
            n34 = (GGroup)GetChildAt(15);
            one_btn = (draw_one_btn)GetChildAt(16);
            ten_btn = (draw_ten_btn)GetChildAt(17);
            gift_btn = (btn1)GetChildAt(18);
            skip_btn = (skip_btn)GetChildAt(19);
            skipLab = (GTextField)GetChildAt(20);
            n35 = (GGroup)GetChildAt(21);
            detail_btn = (btn)GetChildAt(22);
            change_btn = (btn)GetChildAt(23);
            n36 = (GGroup)GetChildAt(24);
        }
    }
}