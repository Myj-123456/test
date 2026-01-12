/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class FlowerInfoShow : GComponent
    {
        public GLoader bg;
        public GImage n7;
        public GImage n21;
        public GLoader name_bg;
        public GLoader rareImg;
        public GLoader pot;
        public GLoader img;
        public GTextField nameLab;
        public GTextField titleLab;
        public GTextField declab;
        public GTextField keLab;
        public GTextField shuLab;
        public GTextField timeLab;
        public GTextField introLab;
        public GButton close_btn;
        public GImage n19;
        public GTextField n20;
        public const string URL = "ui://ekoic0wrq47x1yjp7wn";

        public static FlowerInfoShow CreateInstance()
        {
            return (FlowerInfoShow)UIPackage.CreateObject("fun_CultivationManual_new", "FlowerInfoShow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n7 = (GImage)GetChildAt(1);
            n21 = (GImage)GetChildAt(2);
            name_bg = (GLoader)GetChildAt(3);
            rareImg = (GLoader)GetChildAt(4);
            pot = (GLoader)GetChildAt(5);
            img = (GLoader)GetChildAt(6);
            nameLab = (GTextField)GetChildAt(7);
            titleLab = (GTextField)GetChildAt(8);
            declab = (GTextField)GetChildAt(9);
            keLab = (GTextField)GetChildAt(10);
            shuLab = (GTextField)GetChildAt(11);
            timeLab = (GTextField)GetChildAt(12);
            introLab = (GTextField)GetChildAt(13);
            close_btn = (GButton)GetChildAt(14);
            n19 = (GImage)GetChildAt(15);
            n20 = (GTextField)GetChildAt(16);
        }
    }
}