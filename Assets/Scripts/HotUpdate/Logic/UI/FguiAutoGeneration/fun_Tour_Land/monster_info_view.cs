/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class monster_info_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n4;
        public GImage n5;
        public GImage n8;
        public GImage n10;
        public GImage n12;
        public GImage n14;
        public GButton close_btn;
        public GTextField powerLab;
        public GTextField powerNum;
        public GTextField txt_base;
        public GTextField txt_battle;
        public GTextField txt_defene;
        public GTextField txt_special;
        public GTextField txt_attack;
        public GTextField num_attack;
        public GTextField txt_hp;
        public GTextField num_hp;
        public GTextField txt_def;
        public GTextField num_def;
        public GTextField txt_speed;
        public GTextField num_speed;
        public GTextField txt_crit;
        public GTextField num_crit;
        public GTextField txt_dodge;
        public GTextField num_dodge;
        public GTextField txt_stun;
        public GTextField num_stun;
        public GTextField txt_lifeSteal;
        public GTextField num_lifeSteal;
        public GTextField txt_counter;
        public GTextField num_counter;
        public GTextField txt_combo;
        public GTextField num_combo;
        public GTextField txt_antiCrit;
        public GTextField num_antiCrit;
        public GTextField txt_antiDodge;
        public GTextField num_antiDodge;
        public GTextField txt_antiStun;
        public GTextField num_antiStun;
        public GTextField txt_antiLifeSteal;
        public GTextField num_antiLifeSteal;
        public GTextField txt_antiCounter;
        public GTextField num_antiCounter;
        public GTextField txt_petUp;
        public GTextField num_petUp;
        public GTextField txt_petDown;
        public GTextField num_petDown;
        public GTextField txt_cureUp;
        public GTextField num_cureUp;
        public GTextField txt_cureDown;
        public GTextField num_cureDown;
        public GTextField txt_finalUp;
        public GTextField num_finalUp;
        public GTextField txt_finalDown;
        public GTextField num_finalDown;
        public GTextField txt_ignoreAttributes;
        public GTextField num_ignoreAttributes;
        public GTextField txt_ignoreResistance;
        public GTextField num_ignoreResistance;
        public const string URL = "ui://oo5kr0yox92m2t";

        public static monster_info_view CreateInstance()
        {
            return (monster_info_view)UIPackage.CreateObject("fun_Tour_Land", "monster_info_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n4 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n10 = (GImage)GetChildAt(5);
            n12 = (GImage)GetChildAt(6);
            n14 = (GImage)GetChildAt(7);
            close_btn = (GButton)GetChildAt(8);
            powerLab = (GTextField)GetChildAt(9);
            powerNum = (GTextField)GetChildAt(10);
            txt_base = (GTextField)GetChildAt(11);
            txt_battle = (GTextField)GetChildAt(12);
            txt_defene = (GTextField)GetChildAt(13);
            txt_special = (GTextField)GetChildAt(14);
            txt_attack = (GTextField)GetChildAt(15);
            num_attack = (GTextField)GetChildAt(16);
            txt_hp = (GTextField)GetChildAt(17);
            num_hp = (GTextField)GetChildAt(18);
            txt_def = (GTextField)GetChildAt(19);
            num_def = (GTextField)GetChildAt(20);
            txt_speed = (GTextField)GetChildAt(21);
            num_speed = (GTextField)GetChildAt(22);
            txt_crit = (GTextField)GetChildAt(23);
            num_crit = (GTextField)GetChildAt(24);
            txt_dodge = (GTextField)GetChildAt(25);
            num_dodge = (GTextField)GetChildAt(26);
            txt_stun = (GTextField)GetChildAt(27);
            num_stun = (GTextField)GetChildAt(28);
            txt_lifeSteal = (GTextField)GetChildAt(29);
            num_lifeSteal = (GTextField)GetChildAt(30);
            txt_counter = (GTextField)GetChildAt(31);
            num_counter = (GTextField)GetChildAt(32);
            txt_combo = (GTextField)GetChildAt(33);
            num_combo = (GTextField)GetChildAt(34);
            txt_antiCrit = (GTextField)GetChildAt(35);
            num_antiCrit = (GTextField)GetChildAt(36);
            txt_antiDodge = (GTextField)GetChildAt(37);
            num_antiDodge = (GTextField)GetChildAt(38);
            txt_antiStun = (GTextField)GetChildAt(39);
            num_antiStun = (GTextField)GetChildAt(40);
            txt_antiLifeSteal = (GTextField)GetChildAt(41);
            num_antiLifeSteal = (GTextField)GetChildAt(42);
            txt_antiCounter = (GTextField)GetChildAt(43);
            num_antiCounter = (GTextField)GetChildAt(44);
            txt_petUp = (GTextField)GetChildAt(45);
            num_petUp = (GTextField)GetChildAt(46);
            txt_petDown = (GTextField)GetChildAt(47);
            num_petDown = (GTextField)GetChildAt(48);
            txt_cureUp = (GTextField)GetChildAt(49);
            num_cureUp = (GTextField)GetChildAt(50);
            txt_cureDown = (GTextField)GetChildAt(51);
            num_cureDown = (GTextField)GetChildAt(52);
            txt_finalUp = (GTextField)GetChildAt(53);
            num_finalUp = (GTextField)GetChildAt(54);
            txt_finalDown = (GTextField)GetChildAt(55);
            num_finalDown = (GTextField)GetChildAt(56);
            txt_ignoreAttributes = (GTextField)GetChildAt(57);
            num_ignoreAttributes = (GTextField)GetChildAt(58);
            txt_ignoreResistance = (GTextField)GetChildAt(59);
            num_ignoreResistance = (GTextField)GetChildAt(60);
        }
    }
}