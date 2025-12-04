/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class style_sick_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n7;
        public GImage n8;
        public GImage n15;
        public GLoader style_my;
        public GLoader style_monster;
        public GButton close_btn;
        public GButton detail_btn;
        public emote_component emote;
        public GTextField nameLab;
        public GTextField monsterLab;
        public GTextField styleLab;
        public GTextField style1Lab;
        public GTextField style_num;
        public GTextField style_num1;
        public GTextField compareLab;
        public GTextField effectLab;
        public GTextField effectLab1;
        public const string URL = "ui://oo5kr0yox92m2l";

        public static style_sick_view CreateInstance()
        {
            return (style_sick_view)UIPackage.CreateObject("fun_Tour_Land", "style_sick_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n7 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n15 = (GImage)GetChildAt(5);
            style_my = (GLoader)GetChildAt(6);
            style_monster = (GLoader)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            detail_btn = (GButton)GetChildAt(9);
            emote = (emote_component)GetChildAt(10);
            nameLab = (GTextField)GetChildAt(11);
            monsterLab = (GTextField)GetChildAt(12);
            styleLab = (GTextField)GetChildAt(13);
            style1Lab = (GTextField)GetChildAt(14);
            style_num = (GTextField)GetChildAt(15);
            style_num1 = (GTextField)GetChildAt(16);
            compareLab = (GTextField)GetChildAt(17);
            effectLab = (GTextField)GetChildAt(18);
            effectLab1 = (GTextField)GetChildAt(19);
        }
    }
}