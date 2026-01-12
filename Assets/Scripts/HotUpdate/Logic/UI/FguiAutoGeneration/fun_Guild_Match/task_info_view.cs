/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_Match
{
    public partial class task_info_view : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n28;
        public GTextField txt_Title;
        public GImage n26;
        public GImage n16;
        public GImage n27;
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
            bg = (GLoader)GetChildAt(0);
            n28 = (GImage)GetChildAt(1);
            txt_Title = (GTextField)GetChildAt(2);
            n26 = (GImage)GetChildAt(3);
            n16 = (GImage)GetChildAt(4);
            n27 = (GImage)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            n17 = (GImage)GetChildAt(7);
            n19 = (GImage)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
            decLab = (GTextField)GetChildAt(10);
            scoreLab = (GRichTextField)GetChildAt(11);
            needLab = (GTextField)GetChildAt(12);
            timeLab = (GTextField)GetChildAt(13);
            costLab = (GTextField)GetChildAt(14);
            refresh_btn = (GButton)GetChildAt(15);
            getBtn = (GButton)GetChildAt(16);
            submit_btn = (GButton)GetChildAt(17);
            icon = (GLoader)GetChildAt(18);
            rare_img = (GLoader)GetChildAt(19);
            costImg = (GLoader)GetChildAt(20);
            jump_btn = (GButton)GetChildAt(21);
            head = (head)GetChildAt(22);
        }
    }
}