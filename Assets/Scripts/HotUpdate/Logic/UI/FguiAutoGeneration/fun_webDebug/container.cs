/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_webDebug
{
    public partial class container : GComponent
    {
        public GImage n97;
        public GImage n54;
        public GImage n0;
        public GImage n1;
        public GImage n28;
        public GImage n32;
        public GImage n105;
        public GTextField coins_txt;
        public GButton goldBtn;
        public GTextField gems_txt;
        public GButton cashBtn;
        public GTextField lv_txt;
        public GButton levelBtn;
        public GTextField a_txt;
        public GTextInput goldTxt;
        public GTextField n582;
        public GTextInput input_txt;
        public GTextInput cashTxt;
        public GTextInput levelTxt;
        public GTextInput GM;
        public GButton goldBtn_minus;
        public GButton cashBtn_minus;
        public GTextField a_txt_10;
        public GTextField a_txt_100;
        public GButton add_btn;
        public GButton add10_btn;
        public GButton add100_btn;
        public GTextField n3689;
        public GTextField exp_txt;
        public GButton expBtn;
        public GTextInput expTxt;
        public sale_select isDebris;
        public GTextField n104;
        public GButton time_btn;
        public GTextInput timeLab;
        public GTextField n583;
        public GTextField n584;
        public GImage n111;
        public GImage n112;
        public GButton task_btn;
        public GTextInput taskId;
        public GTextInput taskNum;
        public GImage n116;
        public GButton test_btn;
        public GTextInput test_time;
        public const string URL = "ui://658koyris5pajr";

        public static container CreateInstance()
        {
            return (container)UIPackage.CreateObject("fun_webDebug", "container");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n97 = (GImage)GetChildAt(0);
            n54 = (GImage)GetChildAt(1);
            n0 = (GImage)GetChildAt(2);
            n1 = (GImage)GetChildAt(3);
            n28 = (GImage)GetChildAt(4);
            n32 = (GImage)GetChildAt(5);
            n105 = (GImage)GetChildAt(6);
            coins_txt = (GTextField)GetChildAt(7);
            goldBtn = (GButton)GetChildAt(8);
            gems_txt = (GTextField)GetChildAt(9);
            cashBtn = (GButton)GetChildAt(10);
            lv_txt = (GTextField)GetChildAt(11);
            levelBtn = (GButton)GetChildAt(12);
            a_txt = (GTextField)GetChildAt(13);
            goldTxt = (GTextInput)GetChildAt(14);
            n582 = (GTextField)GetChildAt(15);
            input_txt = (GTextInput)GetChildAt(16);
            cashTxt = (GTextInput)GetChildAt(17);
            levelTxt = (GTextInput)GetChildAt(18);
            GM = (GTextInput)GetChildAt(19);
            goldBtn_minus = (GButton)GetChildAt(20);
            cashBtn_minus = (GButton)GetChildAt(21);
            a_txt_10 = (GTextField)GetChildAt(22);
            a_txt_100 = (GTextField)GetChildAt(23);
            add_btn = (GButton)GetChildAt(24);
            add10_btn = (GButton)GetChildAt(25);
            add100_btn = (GButton)GetChildAt(26);
            n3689 = (GTextField)GetChildAt(27);
            exp_txt = (GTextField)GetChildAt(28);
            expBtn = (GButton)GetChildAt(29);
            expTxt = (GTextInput)GetChildAt(30);
            isDebris = (sale_select)GetChildAt(31);
            n104 = (GTextField)GetChildAt(32);
            time_btn = (GButton)GetChildAt(33);
            timeLab = (GTextInput)GetChildAt(34);
            n583 = (GTextField)GetChildAt(35);
            n584 = (GTextField)GetChildAt(36);
            n111 = (GImage)GetChildAt(37);
            n112 = (GImage)GetChildAt(38);
            task_btn = (GButton)GetChildAt(39);
            taskId = (GTextInput)GetChildAt(40);
            taskNum = (GTextInput)GetChildAt(41);
            n116 = (GImage)GetChildAt(42);
            test_btn = (GButton)GetChildAt(43);
            test_time = (GTextInput)GetChildAt(44);
        }
    }
}