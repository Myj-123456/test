/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Arena
{
    public partial class arena_rank_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GImage n116;
        public GImage n117;
        public GImage n114;
        public GImage n115;
        public GGroup n118;
        public GLoader3D spine;
        public GList rankList;
        public GImage n95;
        public GImage n107;
        public GLoader3D spine1;
        public GLoader3D spine2;
        public GLoader3D spine3;
        public GLoader3D anim1;
        public GLoader3D anim2;
        public GLoader3D anim3;
        public GButton question_btn;
        public arena_rank_top_item rank0;
        public arena_rank_top_item rank1;
        public arena_rank_top_item rank2;
        public GGroup n105;
        public GImage n59;
        public GImage n84;
        public GComponent head;
        public GComponent picFrame;
        public GTextField txt_name;
        public GTextField txt_info1_tip;
        public GTextField txt_info1;
        public GTextField txt_lastRank;
        public GTextField txt_point;
        public GComponent iconCom;
        public GImage n89;
        public GRichTextField txt_info4;
        public GGroup show;
        public GGroup n22;
        public GButton close_btn;
        public GButton reward_btn;
        public GButton battle_btn;
        public const string URL = "ui://dz2e3lzav5lj1yjp7vd";

        public static arena_rank_view CreateInstance()
        {
            return (arena_rank_view)UIPackage.CreateObject("fun_Arena", "arena_rank_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n116 = (GImage)GetChildAt(2);
            n117 = (GImage)GetChildAt(3);
            n114 = (GImage)GetChildAt(4);
            n115 = (GImage)GetChildAt(5);
            n118 = (GGroup)GetChildAt(6);
            spine = (GLoader3D)GetChildAt(7);
            rankList = (GList)GetChildAt(8);
            n95 = (GImage)GetChildAt(9);
            n107 = (GImage)GetChildAt(10);
            spine1 = (GLoader3D)GetChildAt(11);
            spine2 = (GLoader3D)GetChildAt(12);
            spine3 = (GLoader3D)GetChildAt(13);
            anim1 = (GLoader3D)GetChildAt(14);
            anim2 = (GLoader3D)GetChildAt(15);
            anim3 = (GLoader3D)GetChildAt(16);
            question_btn = (GButton)GetChildAt(17);
            rank0 = (arena_rank_top_item)GetChildAt(18);
            rank1 = (arena_rank_top_item)GetChildAt(19);
            rank2 = (arena_rank_top_item)GetChildAt(20);
            n105 = (GGroup)GetChildAt(21);
            n59 = (GImage)GetChildAt(22);
            n84 = (GImage)GetChildAt(23);
            head = (GComponent)GetChildAt(24);
            picFrame = (GComponent)GetChildAt(25);
            txt_name = (GTextField)GetChildAt(26);
            txt_info1_tip = (GTextField)GetChildAt(27);
            txt_info1 = (GTextField)GetChildAt(28);
            txt_lastRank = (GTextField)GetChildAt(29);
            txt_point = (GTextField)GetChildAt(30);
            iconCom = (GComponent)GetChildAt(31);
            n89 = (GImage)GetChildAt(32);
            txt_info4 = (GRichTextField)GetChildAt(33);
            show = (GGroup)GetChildAt(34);
            n22 = (GGroup)GetChildAt(35);
            close_btn = (GButton)GetChildAt(36);
            reward_btn = (GButton)GetChildAt(37);
            battle_btn = (GButton)GetChildAt(38);
        }
    }
}