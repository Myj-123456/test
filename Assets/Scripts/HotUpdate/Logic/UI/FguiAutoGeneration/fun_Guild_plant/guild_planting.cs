/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_plant
{
    public partial class guild_planting : GComponent
    {
        public Controller chose;
        public GLoader bg;
        public GLoader bg1;
        public GImage n93;
        public GLoader title_img;
        public GImage n76;
        public GButton helpBtn;
        public GTextField numLab;
        public GLoader moneyIcon;
        public GGroup n107;
        public GImage n102;
        public GImage n92;
        public GImage n99;
        public GImage n100;
        public GTextField txt_time;
        public GTextField txt_jia;
        public GTextField timeLab;
        public GTextField jiaLab;
        public GButton leftBtn;
        public GButton rightBtn;
        public guild_flowerpot_item item0;
        public guild_flowerpot_item item1;
        public guild_flowerpot_item item2;
        public guild_flowerpot_item item3;
        public guild_flowerpot_item item4;
        public guild_flowerpot_item item5;
        public btn_pre_show btn_pre;
        public GGroup n108;
        public GButton getBtn;
        public GButton close_btn;
        public GList list;
        public guild_planting_item1 myInfo;
        public ChooseFlowerUI chose_flower;
        public GButton plantBtn;
        public GButton back_btn;
        public const string URL = "ui://qfpad3q0tewh1yjp7zk";

        public static guild_planting CreateInstance()
        {
            return (guild_planting)UIPackage.CreateObject("fun_Guild_plant", "guild_planting");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            chose = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            n93 = (GImage)GetChildAt(2);
            title_img = (GLoader)GetChildAt(3);
            n76 = (GImage)GetChildAt(4);
            helpBtn = (GButton)GetChildAt(5);
            numLab = (GTextField)GetChildAt(6);
            moneyIcon = (GLoader)GetChildAt(7);
            n107 = (GGroup)GetChildAt(8);
            n102 = (GImage)GetChildAt(9);
            n92 = (GImage)GetChildAt(10);
            n99 = (GImage)GetChildAt(11);
            n100 = (GImage)GetChildAt(12);
            txt_time = (GTextField)GetChildAt(13);
            txt_jia = (GTextField)GetChildAt(14);
            timeLab = (GTextField)GetChildAt(15);
            jiaLab = (GTextField)GetChildAt(16);
            leftBtn = (GButton)GetChildAt(17);
            rightBtn = (GButton)GetChildAt(18);
            item0 = (guild_flowerpot_item)GetChildAt(19);
            item1 = (guild_flowerpot_item)GetChildAt(20);
            item2 = (guild_flowerpot_item)GetChildAt(21);
            item3 = (guild_flowerpot_item)GetChildAt(22);
            item4 = (guild_flowerpot_item)GetChildAt(23);
            item5 = (guild_flowerpot_item)GetChildAt(24);
            btn_pre = (btn_pre_show)GetChildAt(25);
            n108 = (GGroup)GetChildAt(26);
            getBtn = (GButton)GetChildAt(27);
            close_btn = (GButton)GetChildAt(28);
            list = (GList)GetChildAt(29);
            myInfo = (guild_planting_item1)GetChildAt(30);
            chose_flower = (ChooseFlowerUI)GetChildAt(31);
            plantBtn = (GButton)GetChildAt(32);
            back_btn = (GButton)GetChildAt(33);
        }
    }
}