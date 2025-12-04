/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild_New
{
    public partial class guildContent : GComponent
    {
        public GLoader bg;
        public GImage n24;
        public GLoader3D spine;
        public GLoader shop_img;
        public GLoader match_img;
        public GImage n15;
        public GLoader3D anim;
        public GTextField txt_leaderName;
        public guildBtn btn_shop;
        public guildBtn1 btn_match;
        public btn_gift btn_gift;
        public bargin_btn btn_bargin;
        public GLoader plant_img;
        public guildBtn btn_plant;
        public Transition anim_2;
        public const string URL = "ui://qz6135j3eqnf1yjp7x1";

        public static guildContent CreateInstance()
        {
            return (guildContent)UIPackage.CreateObject("fun_Guild_New", "guildContent");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n24 = (GImage)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            shop_img = (GLoader)GetChildAt(3);
            match_img = (GLoader)GetChildAt(4);
            n15 = (GImage)GetChildAt(5);
            anim = (GLoader3D)GetChildAt(6);
            txt_leaderName = (GTextField)GetChildAt(7);
            btn_shop = (guildBtn)GetChildAt(8);
            btn_match = (guildBtn1)GetChildAt(9);
            btn_gift = (btn_gift)GetChildAt(10);
            btn_bargin = (bargin_btn)GetChildAt(11);
            plant_img = (GLoader)GetChildAt(12);
            btn_plant = (guildBtn)GetChildAt(13);
            anim_2 = GetTransitionAt(0);
        }
    }
}