/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Player
{
    public partial class grade_show_nature : GComponent
    {
        public GImage n8;
        public GImage n4;
        public GImage n32;
        public GImage n30;
        public GImage n31;
        public GImage n11;
        public GTextField cur_grade;
        public GTextField next_grade;
        public GTextField cur_lm_name;
        public GTextField next_lm_name;
        public GTextField cur_lm_num;
        public GTextField next_lm_num;
        public GTextField cur_attack;
        public GTextField next_attack;
        public GTextField cur_defense;
        public GTextField next_defense;
        public GTextField cur_hp;
        public GTextField next_hp;
        public GTextField cur_speed;
        public GTextField next_speed;
        public GTextField cur_attack_num;
        public GTextField cur_defense_num;
        public GTextField cur_hp_num;
        public GTextField cur_speed_num;
        public GTextField next_attack_num;
        public GTextField next_defense_num;
        public GTextField next_hp_num;
        public GTextField next_speed_num;
        public GButton level_btn;
        public const string URL = "ui://0svwl9suefvrd";

        public static grade_show_nature CreateInstance()
        {
            return (grade_show_nature)UIPackage.CreateObject("fun_Player", "grade_show_nature");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n8 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            n32 = (GImage)GetChildAt(2);
            n30 = (GImage)GetChildAt(3);
            n31 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            cur_grade = (GTextField)GetChildAt(6);
            next_grade = (GTextField)GetChildAt(7);
            cur_lm_name = (GTextField)GetChildAt(8);
            next_lm_name = (GTextField)GetChildAt(9);
            cur_lm_num = (GTextField)GetChildAt(10);
            next_lm_num = (GTextField)GetChildAt(11);
            cur_attack = (GTextField)GetChildAt(12);
            next_attack = (GTextField)GetChildAt(13);
            cur_defense = (GTextField)GetChildAt(14);
            next_defense = (GTextField)GetChildAt(15);
            cur_hp = (GTextField)GetChildAt(16);
            next_hp = (GTextField)GetChildAt(17);
            cur_speed = (GTextField)GetChildAt(18);
            next_speed = (GTextField)GetChildAt(19);
            cur_attack_num = (GTextField)GetChildAt(20);
            cur_defense_num = (GTextField)GetChildAt(21);
            cur_hp_num = (GTextField)GetChildAt(22);
            cur_speed_num = (GTextField)GetChildAt(23);
            next_attack_num = (GTextField)GetChildAt(24);
            next_defense_num = (GTextField)GetChildAt(25);
            next_hp_num = (GTextField)GetChildAt(26);
            next_speed_num = (GTextField)GetChildAt(27);
            level_btn = (GButton)GetChildAt(28);
        }
    }
}