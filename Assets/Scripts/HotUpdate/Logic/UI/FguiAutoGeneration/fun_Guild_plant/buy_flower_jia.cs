/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class buy_flower_jia : GComponent
    {
        public Controller tab;
        public GImage n2;
        public GLoader bg;
        public GImage n9;
        public GImage n3;
        public GButton close_btn;
        public GImage n5;
        public GImage n6;
        public GTextField timeLab;
        public GLoader title_img;
        public buy_jia_item item1;
        public buy_jia_item item2;
        public GButton btn;
        public const string URL = "ui://qfpad3q0tewhv";

        public static buy_flower_jia CreateInstance()
        {
            return (buy_flower_jia)UIPackage.CreateObject("fun_Guild_plant", "buy_flower_jia");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n9 = (GImage)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            n5 = (GImage)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            timeLab = (GTextField)GetChildAt(7);
            title_img = (GLoader)GetChildAt(8);
            item1 = (buy_jia_item)GetChildAt(9);
            item2 = (buy_jia_item)GetChildAt(10);
            btn = (GButton)GetChildAt(11);
        }
    }
}