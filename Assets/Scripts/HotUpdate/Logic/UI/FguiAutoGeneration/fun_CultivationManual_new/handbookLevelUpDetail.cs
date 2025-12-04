/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookLevelUpDetail : GComponent
    {
        public GImage n477;
        public GLoader bg;
        public GImage n485;
        public GImage n486;
        public GImage n488;
        public GImage n487;
        public GImage n489;
        public GImage n490;
        public GImage n491;
        public GImage n492;
        public GButton close_btn;
        public GList list;
        public GTextField titleLab;
        public GTextField levelLab;
        public GTextField timeLab;
        public GTextField seedLab;
        public GTextField flowerLab;
        public GTextField countLab;
        public const string URL = "ui://ekoic0wrqheb1yjp7ms";

        public static handbookLevelUpDetail CreateInstance()
        {
            return (handbookLevelUpDetail)UIPackage.CreateObject("fun_CultivationManual_new", "handbookLevelUpDetail");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n477 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n485 = (GImage)GetChildAt(2);
            n486 = (GImage)GetChildAt(3);
            n488 = (GImage)GetChildAt(4);
            n487 = (GImage)GetChildAt(5);
            n489 = (GImage)GetChildAt(6);
            n490 = (GImage)GetChildAt(7);
            n491 = (GImage)GetChildAt(8);
            n492 = (GImage)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            list = (GList)GetChildAt(11);
            titleLab = (GTextField)GetChildAt(12);
            levelLab = (GTextField)GetChildAt(13);
            timeLab = (GTextField)GetChildAt(14);
            seedLab = (GTextField)GetChildAt(15);
            flowerLab = (GTextField)GetChildAt(16);
            countLab = (GTextField)GetChildAt(17);
        }
    }
}