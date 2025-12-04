/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class start_battle_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GLoader bg2;
        public GImage n3;
        public GLoader pic;
        public GLoader3D spine;
        public GImage n6;
        public GImage n9;
        public GImage n17;
        public GButton detail_btn;
        public GTextField monster_info_txt;
        public GTextField nameLab;
        public GTextField decLab;
        public GTextField titleLab;
        public GTextField powerLab;
        public GTextField powerNum;
        public GList list;
        public GButton battle_btn;
        public GButton close_btn;
        public emote_component emote_btn;
        public const string URL = "ui://oo5kr0yox92m27";

        public static start_battle_view CreateInstance()
        {
            return (start_battle_view)UIPackage.CreateObject("fun_Tour_Land", "start_battle_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            bg2 = (GLoader)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            pic = (GLoader)GetChildAt(4);
            spine = (GLoader3D)GetChildAt(5);
            n6 = (GImage)GetChildAt(6);
            n9 = (GImage)GetChildAt(7);
            n17 = (GImage)GetChildAt(8);
            detail_btn = (GButton)GetChildAt(9);
            monster_info_txt = (GTextField)GetChildAt(10);
            nameLab = (GTextField)GetChildAt(11);
            decLab = (GTextField)GetChildAt(12);
            titleLab = (GTextField)GetChildAt(13);
            powerLab = (GTextField)GetChildAt(14);
            powerNum = (GTextField)GetChildAt(15);
            list = (GList)GetChildAt(16);
            battle_btn = (GButton)GetChildAt(17);
            close_btn = (GButton)GetChildAt(18);
            emote_btn = (emote_component)GetChildAt(19);
        }
    }
}