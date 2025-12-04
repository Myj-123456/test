/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_item2 : GComponent
    {
        public Controller half;
        public GLoader bg;
        public GImage n38;
        public GImage n4;
        public GImage n6;
        public GImage n7;
        public GImage n29;
        public GImage n31;
        public GImage n33;
        public GImage n35;
        public GTextField titleLab;
        public GTextField tipLab;
        public GTextField sunLab;
        public GTextField timeLab;
        public GTextField n30;
        public GTextField n32;
        public GTextField n34;
        public GTextField n36;
        public card_text_item txt_1;
        public card_text_item txt_2;
        public card_text_item txt_3;
        public card_text_item txt_4;
        public card_text_item txt_5;
        public buy_btn buy_btn;
        public GImage n27;
        public const string URL = "ui://w3ox9yltdidl1u";

        public static card_item2 CreateInstance()
        {
            return (card_item2)UIPackage.CreateObject("fun_Recharge", "card_item2");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            half = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n38 = (GImage)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n7 = (GImage)GetChildAt(4);
            n29 = (GImage)GetChildAt(5);
            n31 = (GImage)GetChildAt(6);
            n33 = (GImage)GetChildAt(7);
            n35 = (GImage)GetChildAt(8);
            titleLab = (GTextField)GetChildAt(9);
            tipLab = (GTextField)GetChildAt(10);
            sunLab = (GTextField)GetChildAt(11);
            timeLab = (GTextField)GetChildAt(12);
            n30 = (GTextField)GetChildAt(13);
            n32 = (GTextField)GetChildAt(14);
            n34 = (GTextField)GetChildAt(15);
            n36 = (GTextField)GetChildAt(16);
            txt_1 = (card_text_item)GetChildAt(17);
            txt_2 = (card_text_item)GetChildAt(18);
            txt_3 = (card_text_item)GetChildAt(19);
            txt_4 = (card_text_item)GetChildAt(20);
            txt_5 = (card_text_item)GetChildAt(21);
            buy_btn = (buy_btn)GetChildAt(22);
            n27 = (GImage)GetChildAt(23);
        }
    }
}