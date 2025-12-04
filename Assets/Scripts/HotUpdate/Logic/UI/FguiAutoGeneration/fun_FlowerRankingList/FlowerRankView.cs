/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankView : GComponent
    {
        public Controller myRank;
        public Controller pageStatus;
        public GLoader bg;
        public GLoader bg1;
        public GImage n116;
        public GImage n117;
        public GImage n114;
        public GImage n115;
        public GGroup n118;
        public GImage n91;
        public GLoader3D spine;
        public GList rankList;
        public GButton close_btn;
        public GImage n95;
        public GImage n82;
        public GImage n108;
        public GImage n107;
        public GImage n123;
        public GImage n124;
        public GImage n125;
        public GImage n127;
        public GLoader3D spine1;
        public GLoader3D spine2;
        public GLoader3D spine3;
        public GLoader3D anim1;
        public GLoader3D anim2;
        public GLoader3D anim3;
        public GTextField updateTxt;
        public GTextField txt_info3;
        public GTextField txt_gold;
        public GTextField txt_cash;
        public GButton question_btn;
        public FlowerRankTopItem1 rank0;
        public FlowerRankTopItem1 rank1;
        public FlowerRankTopItem1 rank2;
        public GGroup n105;
        public GImage n59;
        public GImage n83;
        public GImage n84;
        public GComponent head;
        public GComponent picFrame;
        public GTextField txt_name;
        public GTextField txt_info1_tip;
        public GTextField txt_info1;
        public GTextField txt_point;
        public GTextField txt_rankTitle;
        public flowerRankIcon iconCom;
        public GGroup n136;
        public GImage n93;
        public GImage n94;
        public GImage n137;
        public pageBtn pros_tabBtn;
        public pageBtn cultivate_tabBtn;
        public pageBtn art_tabBtn;
        public pageBtn dressBtn;
        public GGroup n143;
        public const string URL = "ui://zieeydldj8rkpc7";

        public static FlowerRankView CreateInstance()
        {
            return (FlowerRankView)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            myRank = GetControllerAt(0);
            pageStatus = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n116 = (GImage)GetChildAt(2);
            n117 = (GImage)GetChildAt(3);
            n114 = (GImage)GetChildAt(4);
            n115 = (GImage)GetChildAt(5);
            n118 = (GGroup)GetChildAt(6);
            n91 = (GImage)GetChildAt(7);
            spine = (GLoader3D)GetChildAt(8);
            rankList = (GList)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            n95 = (GImage)GetChildAt(11);
            n82 = (GImage)GetChildAt(12);
            n108 = (GImage)GetChildAt(13);
            n107 = (GImage)GetChildAt(14);
            n123 = (GImage)GetChildAt(15);
            n124 = (GImage)GetChildAt(16);
            n125 = (GImage)GetChildAt(17);
            n127 = (GImage)GetChildAt(18);
            spine1 = (GLoader3D)GetChildAt(19);
            spine2 = (GLoader3D)GetChildAt(20);
            spine3 = (GLoader3D)GetChildAt(21);
            anim1 = (GLoader3D)GetChildAt(22);
            anim2 = (GLoader3D)GetChildAt(23);
            anim3 = (GLoader3D)GetChildAt(24);
            updateTxt = (GTextField)GetChildAt(25);
            txt_info3 = (GTextField)GetChildAt(26);
            txt_gold = (GTextField)GetChildAt(27);
            txt_cash = (GTextField)GetChildAt(28);
            question_btn = (GButton)GetChildAt(29);
            rank0 = (FlowerRankTopItem1)GetChildAt(30);
            rank1 = (FlowerRankTopItem1)GetChildAt(31);
            rank2 = (FlowerRankTopItem1)GetChildAt(32);
            n105 = (GGroup)GetChildAt(33);
            n59 = (GImage)GetChildAt(34);
            n83 = (GImage)GetChildAt(35);
            n84 = (GImage)GetChildAt(36);
            head = (GComponent)GetChildAt(37);
            picFrame = (GComponent)GetChildAt(38);
            txt_name = (GTextField)GetChildAt(39);
            txt_info1_tip = (GTextField)GetChildAt(40);
            txt_info1 = (GTextField)GetChildAt(41);
            txt_point = (GTextField)GetChildAt(42);
            txt_rankTitle = (GTextField)GetChildAt(43);
            iconCom = (flowerRankIcon)GetChildAt(44);
            n136 = (GGroup)GetChildAt(45);
            n93 = (GImage)GetChildAt(46);
            n94 = (GImage)GetChildAt(47);
            n137 = (GImage)GetChildAt(48);
            pros_tabBtn = (pageBtn)GetChildAt(49);
            cultivate_tabBtn = (pageBtn)GetChildAt(50);
            art_tabBtn = (pageBtn)GetChildAt(51);
            dressBtn = (pageBtn)GetChildAt(52);
            n143 = (GGroup)GetChildAt(53);
        }
    }
}