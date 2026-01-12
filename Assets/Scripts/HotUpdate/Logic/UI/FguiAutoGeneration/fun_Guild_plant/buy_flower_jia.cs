/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class buy_flower_jia : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GImage n9;
        public GButton close_btn;
        public GImage n5;
        public GImage n6;
        public GTextField timeLab;
        public GLoader title_img;
        public buy_jia_item item1;
        public buy_jia_item item2;
        public GButton btn;
        public GImage n13;
        public GTextField best_buyText;
        public const string URL = "ui://qfpad3q0tewhv";

        public static buy_flower_jia CreateInstance()
        {
            return (buy_flower_jia)UIPackage.CreateObject("fun_Guild_plant", "buy_flower_jia");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n9 = (GImage)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            timeLab = (GTextField)GetChildAt(5);
            title_img = (GLoader)GetChildAt(6);
            item1 = (buy_jia_item)GetChildAt(7);
            item2 = (buy_jia_item)GetChildAt(8);
            btn = (GButton)GetChildAt(9);
            n13 = (GImage)GetChildAt(10);
            best_buyText = (GTextField)GetChildAt(11);
        }
    }
}