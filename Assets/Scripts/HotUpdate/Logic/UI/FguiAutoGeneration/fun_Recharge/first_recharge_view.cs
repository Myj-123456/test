/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_recharge_view : GComponent
    {
        public Controller tab;
        public Controller buy;
        public Controller unlock;
        public GLoader bg;
        public GImage n29;
        public GGraph n26;
        public GLoader3D spine;
        public GLoader show_btn;
        public page_btn2 one_btn;
        public page_btn2 two_btn;
        public page_btn2 three_btn;
        public first_recharge_btn buy_btn1;
        public first_recharge_btn buy_btn2;
        public first_recharge_btn buy_btn3;
        public first_recharge_btn buy_btn4;
        public GImage n38;
        public GImage n39;
        public GTextField lab;
        public GGroup n41;
        public GButton get_btn;
        public GTextField nameLab;
        public GTextField tipLab;
        public GImage n30;
        public GImage n31;
        public GImage n32;
        public GImage n33;
        public GImage n34;
        public GList list;
        public GImage n42;
        public const string URL = "ui://w3ox9yltdidl25";

        public static first_recharge_view CreateInstance()
        {
            return (first_recharge_view)UIPackage.CreateObject("fun_Recharge", "first_recharge_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            buy = GetControllerAt(1);
            unlock = GetControllerAt(2);
            bg = (GLoader)GetChildAt(0);
            n29 = (GImage)GetChildAt(1);
            n26 = (GGraph)GetChildAt(2);
            spine = (GLoader3D)GetChildAt(3);
            show_btn = (GLoader)GetChildAt(4);
            one_btn = (page_btn2)GetChildAt(5);
            two_btn = (page_btn2)GetChildAt(6);
            three_btn = (page_btn2)GetChildAt(7);
            buy_btn1 = (first_recharge_btn)GetChildAt(8);
            buy_btn2 = (first_recharge_btn)GetChildAt(9);
            buy_btn3 = (first_recharge_btn)GetChildAt(10);
            buy_btn4 = (first_recharge_btn)GetChildAt(11);
            n38 = (GImage)GetChildAt(12);
            n39 = (GImage)GetChildAt(13);
            lab = (GTextField)GetChildAt(14);
            n41 = (GGroup)GetChildAt(15);
            get_btn = (GButton)GetChildAt(16);
            nameLab = (GTextField)GetChildAt(17);
            tipLab = (GTextField)GetChildAt(18);
            n30 = (GImage)GetChildAt(19);
            n31 = (GImage)GetChildAt(20);
            n32 = (GImage)GetChildAt(21);
            n33 = (GImage)GetChildAt(22);
            n34 = (GImage)GetChildAt(23);
            list = (GList)GetChildAt(24);
            n42 = (GImage)GetChildAt(25);
        }
    }
}