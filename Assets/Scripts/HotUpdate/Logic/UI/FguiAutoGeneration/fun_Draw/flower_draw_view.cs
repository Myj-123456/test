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
        public btn detail_btn;
        public btn change_btn;
        public GGroup n19;
        public draw_one_btn one_btn;
        public draw_ten_btn ten_btn;
        public skip_btn skip_btn;
        public GTextField skipLab;
        public GGroup n20;
        public GImage n22;
        public GTextField timeLab;
        public GGroup n24;
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
            detail_btn = (btn)GetChildAt(7);
            change_btn = (btn)GetChildAt(8);
            n19 = (GGroup)GetChildAt(9);
            one_btn = (draw_one_btn)GetChildAt(10);
            ten_btn = (draw_ten_btn)GetChildAt(11);
            skip_btn = (skip_btn)GetChildAt(12);
            skipLab = (GTextField)GetChildAt(13);
            n20 = (GGroup)GetChildAt(14);
            n22 = (GImage)GetChildAt(15);
            timeLab = (GTextField)GetChildAt(16);
            n24 = (GGroup)GetChildAt(17);
        }
    }
}