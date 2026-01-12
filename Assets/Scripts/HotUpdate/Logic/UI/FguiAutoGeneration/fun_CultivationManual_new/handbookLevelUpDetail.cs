/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbookLevelUpDetail : GComponent
    {
        public GLoader bg;
        public GImage n502;
        public GImage n503;
        public GImage n489;
        public GImage n490;
        public GImage n491;
        public GImage n492;
        public GImage n501;
        public GButton close_btn;
        public GList list;
        public GTextField titleLab;
        public GTextField levelLab;
        public GTextField timeLab;
        public GTextField seedLab;
        public GTextField flowerLab;
        public GTextField countLab;
        public GTextField n500;
        public const string URL = "ui://ekoic0wrqheb1yjp7ms";

        public static handbookLevelUpDetail CreateInstance()
        {
            return (handbookLevelUpDetail)UIPackage.CreateObject("fun_CultivationManual_new", "handbookLevelUpDetail");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n502 = (GImage)GetChildAt(1);
            n503 = (GImage)GetChildAt(2);
            n489 = (GImage)GetChildAt(3);
            n490 = (GImage)GetChildAt(4);
            n491 = (GImage)GetChildAt(5);
            n492 = (GImage)GetChildAt(6);
            n501 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            list = (GList)GetChildAt(9);
            titleLab = (GTextField)GetChildAt(10);
            levelLab = (GTextField)GetChildAt(11);
            timeLab = (GTextField)GetChildAt(12);
            seedLab = (GTextField)GetChildAt(13);
            flowerLab = (GTextField)GetChildAt(14);
            countLab = (GTextField)GetChildAt(15);
            n500 = (GTextField)GetChildAt(16);
        }
    }
}