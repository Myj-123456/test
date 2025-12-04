/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_recharge_view : GComponent
    {
        public Controller tab;
        public Controller buy;
        public GLoader bg;
        public GGraph n26;
        public GLoader3D spine;
        public GImage n14;
        public GImage n15;
        public GImage n17;
        public GImage n19;
        public GImage n20;
        public GLoader show_btn;
        public GList list;
        public GList list1;
        public page_btn2 one_btn;
        public page_btn2 two_btn;
        public page_btn2 three_btn;
        public first_recharge_btn buy_btn1;
        public first_recharge_btn buy_btn2;
        public first_recharge_btn buy_btn3;
        public first_recharge_btn buy_btn4;
        public buy_btn get_btn;
        public GTextField nameLab;
        public GTextField tipLab;
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
            bg = (GLoader)GetChildAt(0);
            n26 = (GGraph)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            n14 = (GImage)GetChildAt(3);
            n15 = (GImage)GetChildAt(4);
            n17 = (GImage)GetChildAt(5);
            n19 = (GImage)GetChildAt(6);
            n20 = (GImage)GetChildAt(7);
            show_btn = (GLoader)GetChildAt(8);
            list = (GList)GetChildAt(9);
            list1 = (GList)GetChildAt(10);
            one_btn = (page_btn2)GetChildAt(11);
            two_btn = (page_btn2)GetChildAt(12);
            three_btn = (page_btn2)GetChildAt(13);
            buy_btn1 = (first_recharge_btn)GetChildAt(14);
            buy_btn2 = (first_recharge_btn)GetChildAt(15);
            buy_btn3 = (first_recharge_btn)GetChildAt(16);
            buy_btn4 = (first_recharge_btn)GetChildAt(17);
            get_btn = (buy_btn)GetChildAt(18);
            nameLab = (GTextField)GetChildAt(19);
            tipLab = (GTextField)GetChildAt(20);
        }
    }
}