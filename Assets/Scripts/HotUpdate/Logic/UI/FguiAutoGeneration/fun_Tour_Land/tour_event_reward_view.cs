/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_event_reward_view : GComponent
    {
        public Controller status;
        public Controller tab;
        public GImage n3;
        public GLoader bg;
        public GImage n11;
        public GImage n4;
        public GImage n5;
        public GImage n6;
        public GTextField nameLab;
        public GTextField decLab;
        public GButton get_btn;
        public GButton close_btn;
        public tabBtn1 chose1;
        public tabBtn1 chose2;
        public GGroup n13;
        public GTextField getLab;
        public GList list;
        public GGroup n17;
        public const string URL = "ui://oo5kr0yot5nh1s";

        public static tour_event_reward_view CreateInstance()
        {
            return (tour_event_reward_view)UIPackage.CreateObject("fun_Tour_Land", "tour_event_reward_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            tab = GetControllerAt(1);
            n3 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n6 = (GImage)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            decLab = (GTextField)GetChildAt(7);
            get_btn = (GButton)GetChildAt(8);
            close_btn = (GButton)GetChildAt(9);
            chose1 = (tabBtn1)GetChildAt(10);
            chose2 = (tabBtn1)GetChildAt(11);
            n13 = (GGroup)GetChildAt(12);
            getLab = (GTextField)GetChildAt(13);
            list = (GList)GetChildAt(14);
            n17 = (GGroup)GetChildAt(15);
        }
    }
}