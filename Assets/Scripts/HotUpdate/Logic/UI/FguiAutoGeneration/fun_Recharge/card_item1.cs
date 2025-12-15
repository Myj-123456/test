/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_item1 : GComponent
    {
        public Controller show;
        public Controller hasGet;
        public GLoader bg;
        public GImage n28;
        public GImage n32;
        public GImage n33;
        public GTextField sunLab;
        public GTextField buy_lab;
        public GImage n34;
        public GImage n35;
        public GTextField day_lab;
        public card_text_item txt_2;
        public card_text_item txt_3;
        public card_text_item txt_4;
        public card_text_item txt_5;
        public GList reward_list1;
        public GList reward_list2;
        public GTextField timeLab;
        public buy_btn buy_btn;
        public one_key_com show_com;
        public GImage n27;
        public GRichTextField tipLab;
        public GImage n30;
        public GImage n31;
        public GButton lok_btn;
        public GRichTextField tipLab2;
        public GImage hasGet_2;
        public const string URL = "ui://w3ox9yltdidl1d";

        public static card_item1 CreateInstance()
        {
            return (card_item1)UIPackage.CreateObject("fun_Recharge", "card_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            hasGet = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            n28 = (GImage)GetChildAt(1);
            n32 = (GImage)GetChildAt(2);
            n33 = (GImage)GetChildAt(3);
            sunLab = (GTextField)GetChildAt(4);
            buy_lab = (GTextField)GetChildAt(5);
            n34 = (GImage)GetChildAt(6);
            n35 = (GImage)GetChildAt(7);
            day_lab = (GTextField)GetChildAt(8);
            txt_2 = (card_text_item)GetChildAt(9);
            txt_3 = (card_text_item)GetChildAt(10);
            txt_4 = (card_text_item)GetChildAt(11);
            txt_5 = (card_text_item)GetChildAt(12);
            reward_list1 = (GList)GetChildAt(13);
            reward_list2 = (GList)GetChildAt(14);
            timeLab = (GTextField)GetChildAt(15);
            buy_btn = (buy_btn)GetChildAt(16);
            show_com = (one_key_com)GetChildAt(17);
            n27 = (GImage)GetChildAt(18);
            tipLab = (GRichTextField)GetChildAt(19);
            n30 = (GImage)GetChildAt(20);
            n31 = (GImage)GetChildAt(21);
            lok_btn = (GButton)GetChildAt(22);
            tipLab2 = (GRichTextField)GetChildAt(23);
            hasGet_2 = (GImage)GetChildAt(24);
        }
    }
}