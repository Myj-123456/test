/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class task_info_view : GComponent
    {
        public Controller status;
        public GImage n10;
        public GLoader bg;
        public GImage n15;
        public GImage n11;
        public GImage n16;
        public GImage n14;
        public GImage n17;
        public GImage n19;
        public GButton close_btn;
        public GTextField decLab;
        public GRichTextField scoreLab;
        public GTextField needLab;
        public GTextField timeLab;
        public GTextField costLab;
        public GButton refresh_btn;
        public GButton getBtn;
        public GButton submit_btn;
        public GLoader icon;
        public GLoader rare_img;
        public GLoader costImg;
        public GButton jump_btn;
        public head head;
        public const string URL = "ui://qefze8qitewh5";

        public static task_info_view CreateInstance()
        {
            return (task_info_view)UIPackage.CreateObject("fun_Guild_Match", "task_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n10 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            n11 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n14 = (GImage)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            n19 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            decLab = (GTextField)GetChildAt(9);
            scoreLab = (GRichTextField)GetChildAt(10);
            needLab = (GTextField)GetChildAt(11);
            timeLab = (GTextField)GetChildAt(12);
            costLab = (GTextField)GetChildAt(13);
            refresh_btn = (GButton)GetChildAt(14);
            getBtn = (GButton)GetChildAt(15);
            submit_btn = (GButton)GetChildAt(16);
            icon = (GLoader)GetChildAt(17);
            rare_img = (GLoader)GetChildAt(18);
            costImg = (GLoader)GetChildAt(19);
            jump_btn = (GButton)GetChildAt(20);
            head = (head)GetChildAt(21);
        }
    }
}