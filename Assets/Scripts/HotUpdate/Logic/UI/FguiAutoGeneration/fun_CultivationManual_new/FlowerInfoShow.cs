/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class FlowerInfoShow : GComponent
    {
        public GLoader bg;
        public GImage n2;
        public GImage n7;
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
        public const string URL = "ui://ekoic0wrq47x1yjp7wn";

        public static FlowerInfoShow CreateInstance()
        {
            return (FlowerInfoShow)UIPackage.CreateObject("fun_CultivationManual_new", "FlowerInfoShow");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n7 = (GImage)GetChildAt(2);
            rareImg = (GLoader)GetChildAt(3);
            pot = (GLoader)GetChildAt(4);
            img = (GLoader)GetChildAt(5);
            nameLab = (GTextField)GetChildAt(6);
            titleLab = (GTextField)GetChildAt(7);
            declab = (GTextField)GetChildAt(8);
            keLab = (GTextField)GetChildAt(9);
            shuLab = (GTextField)GetChildAt(10);
            timeLab = (GTextField)GetChildAt(11);
            introLab = (GTextField)GetChildAt(12);
            close_btn = (GButton)GetChildAt(13);
        }
    }
}