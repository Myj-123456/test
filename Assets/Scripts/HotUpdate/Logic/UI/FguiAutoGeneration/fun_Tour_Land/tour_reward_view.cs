/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_reward_view : GComponent
    {
        public GImage n5;
        public GLoader bg;
        public GImage n2;
        public GImage n7;
        public GImage n11;
        public GImage n12;
        public GImage n16;
        public GImage n20;
        public GImage n21;
        public GImage n19;
        public GLoader gold_img;
        public GLoader break_img;
        public GButton close_btn;
        public btn1 show_btn;
        public GTextField titileLab;
        public GTextField hookLab;
        public GTextField break_num;
        public GTextField gold_num;
        public GTextField hook_time_txt;
        public GTextField timeLab;
        public GTextField timeLimitLab;
        public GTextField gettedLab;
        public GButton get_btn;
        public GList list;
        public const string URL = "ui://oo5kr0yot5nh1m";

        public static tour_reward_view CreateInstance()
        {
            return (tour_reward_view)UIPackage.CreateObject("fun_Tour_Land", "tour_reward_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n5 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n2 = (GImage)GetChildAt(2);
            n7 = (GImage)GetChildAt(3);
            n11 = (GImage)GetChildAt(4);
            n12 = (GImage)GetChildAt(5);
            n16 = (GImage)GetChildAt(6);
            n20 = (GImage)GetChildAt(7);
            n21 = (GImage)GetChildAt(8);
            n19 = (GImage)GetChildAt(9);
            gold_img = (GLoader)GetChildAt(10);
            break_img = (GLoader)GetChildAt(11);
            close_btn = (GButton)GetChildAt(12);
            show_btn = (btn1)GetChildAt(13);
            titileLab = (GTextField)GetChildAt(14);
            hookLab = (GTextField)GetChildAt(15);
            break_num = (GTextField)GetChildAt(16);
            gold_num = (GTextField)GetChildAt(17);
            hook_time_txt = (GTextField)GetChildAt(18);
            timeLab = (GTextField)GetChildAt(19);
            timeLimitLab = (GTextField)GetChildAt(20);
            gettedLab = (GTextField)GetChildAt(21);
            get_btn = (GButton)GetChildAt(22);
            list = (GList)GetChildAt(23);
        }
    }
}