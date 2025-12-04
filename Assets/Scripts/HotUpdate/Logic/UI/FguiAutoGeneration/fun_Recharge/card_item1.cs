/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_item1 : GComponent
    {
        public Controller show;
        public GLoader bg;
        public GImage n3;
        public GImage n4;
        public GImage n6;
        public GImage n7;
        public GImage n14;
        public GImage n16;
        public GTextField titleLab;
        public GTextField tipLab;
        public GTextField sunLab;
        public GTextField buy_lab;
        public GTextField day_lab;
        public card_text_item txt_1;
        public card_text_item txt_2;
        public card_text_item txt_3;
        public card_text_item txt_4;
        public card_text_item txt_5;
        public GList reward_list1;
        public GList reward_list2;
        public GTextField timeLab;
        public buy_btn buy_btn;
        public look_btn lok_btn;
        public one_key_com show_com;
        public const string URL = "ui://w3ox9yltdidl1d";

        public static card_item1 CreateInstance()
        {
            return (card_item1)UIPackage.CreateObject("fun_Recharge", "card_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n3 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            n14 = (GImage)GetChildAt(5);
            n16 = (GImage)GetChildAt(6);
            titleLab = (GTextField)GetChildAt(7);
            tipLab = (GTextField)GetChildAt(8);
            sunLab = (GTextField)GetChildAt(9);
            buy_lab = (GTextField)GetChildAt(10);
            day_lab = (GTextField)GetChildAt(11);
            txt_1 = (card_text_item)GetChildAt(12);
            txt_2 = (card_text_item)GetChildAt(13);
            txt_3 = (card_text_item)GetChildAt(14);
            txt_4 = (card_text_item)GetChildAt(15);
            txt_5 = (card_text_item)GetChildAt(16);
            reward_list1 = (GList)GetChildAt(17);
            reward_list2 = (GList)GetChildAt(18);
            timeLab = (GTextField)GetChildAt(19);
            buy_btn = (buy_btn)GetChildAt(20);
            lok_btn = (look_btn)GetChildAt(21);
            show_com = (one_key_com)GetChildAt(22);
        }
    }
}