/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_item2 : GComponent
    {
        public Controller half;
        public GLoader bg;
        public GImage n40;
        public GTextField sunLab;
        public GRichTextField tipLab;
        public GImage n42;
        public GImage n43;
        public card_text_item txt_2;
        public card_text_item txt_3;
        public card_text_item txt_4;
        public card_text_item txt_5;
        public GImage n49;
        public GImage n54;
        public GImage n55;
        public GImage n56;
        public GImage n29;
        public GImage n31;
        public GImage n33;
        public GImage n35;
        public GTextField n30;
        public GTextField n32;
        public GTextField n34;
        public GTextField n36;
        public GImage n50;
        public buy_btn buy_btn;
        public GImage n44;
        public GTextField timeLab;
        public GImage n39;
        public GTextField sunLab2;
        public GRichTextField sunLab3;
        public GImage n51;
        public GImage n52;
        public GImage n53;
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
            n40 = (GImage)GetChildAt(1);
            sunLab = (GTextField)GetChildAt(2);
            tipLab = (GRichTextField)GetChildAt(3);
            n42 = (GImage)GetChildAt(4);
            n43 = (GImage)GetChildAt(5);
            txt_2 = (card_text_item)GetChildAt(6);
            txt_3 = (card_text_item)GetChildAt(7);
            txt_4 = (card_text_item)GetChildAt(8);
            txt_5 = (card_text_item)GetChildAt(9);
            n49 = (GImage)GetChildAt(10);
            n54 = (GImage)GetChildAt(11);
            n55 = (GImage)GetChildAt(12);
            n56 = (GImage)GetChildAt(13);
            n29 = (GImage)GetChildAt(14);
            n31 = (GImage)GetChildAt(15);
            n33 = (GImage)GetChildAt(16);
            n35 = (GImage)GetChildAt(17);
            n30 = (GTextField)GetChildAt(18);
            n32 = (GTextField)GetChildAt(19);
            n34 = (GTextField)GetChildAt(20);
            n36 = (GTextField)GetChildAt(21);
            n50 = (GImage)GetChildAt(22);
            buy_btn = (buy_btn)GetChildAt(23);
            n44 = (GImage)GetChildAt(24);
            timeLab = (GTextField)GetChildAt(25);
            n39 = (GImage)GetChildAt(26);
            sunLab2 = (GTextField)GetChildAt(27);
            sunLab3 = (GRichTextField)GetChildAt(28);
            n51 = (GImage)GetChildAt(29);
            n52 = (GImage)GetChildAt(30);
            n53 = (GImage)GetChildAt(31);
        }
    }
}