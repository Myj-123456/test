/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivateSeeds
{
    public partial class cultivation_new_panel : GComponent
    {
        public Controller status;
        public GLoader bg;
        public GImage n59;
        public GImage n61;
        public GImage n62;
        public GImage n63;
        public GImage n2;
        public GTextField title;
        public GButton question_btn;
        public GGroup n50;
        public GImage n6;
        public GImage n9;
        public tweenCom tweenCom;
        public GButton leftBtn;
        public GButton rightBtn;
        public GGroup n16;
        public GTextField nullTip;
        public btn1 shop_btn;
        public GButton plant_btn;
        public GLoader effect_img;
        public GLoader flower_img1;
        public GLoader flower_img;
        public GLoader3D spine;
        public GImage n75;
        public GImage n74;
        public GLoader3D spine1;
        public GLoader nameBg;
        public GTextField flower_name;
        public GRichTextField completeLab;
        public GImage n41;
        public GButton backBtn;
        public GButton go_plant;
        public GGroup n76;
        public GImage n69;
        public GImage n70;
        public GRichTextField tip;
        public GButton cultivation_btn;
        public cultivation_seed2 need_item_1;
        public cultivation_seed2 need_item_2;
        public cultivation_seed2 need_item_3;
        public cultivation_seed2 need_item_4;
        public GGroup n79;
        public GGroup n71;
        public GLoader n72;
        public cultivation_new_process process;
        public GTextField time_txt;
        public GButton skip_btn;
        public GImage n34;
        public GButton btn_video;
        public GTextField video_txt;
        public GGroup videoGrp;
        public GGroup n73;
        public GGroup n77;
        public GButton close_btn;
        public GButton share_btn;
        public tip tipCom;
        public const string URL = "ui://udmgdnw2s23ek";

        public static cultivation_new_panel CreateInstance()
        {
            return (cultivation_new_panel)UIPackage.CreateObject("fun_CultivateSeeds", "cultivation_new_panel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n59 = (GImage)GetChildAt(1);
            n61 = (GImage)GetChildAt(2);
            n62 = (GImage)GetChildAt(3);
            n63 = (GImage)GetChildAt(4);
            n2 = (GImage)GetChildAt(5);
            title = (GTextField)GetChildAt(6);
            question_btn = (GButton)GetChildAt(7);
            n50 = (GGroup)GetChildAt(8);
            n6 = (GImage)GetChildAt(9);
            n9 = (GImage)GetChildAt(10);
            tweenCom = (tweenCom)GetChildAt(11);
            leftBtn = (GButton)GetChildAt(12);
            rightBtn = (GButton)GetChildAt(13);
            n16 = (GGroup)GetChildAt(14);
            nullTip = (GTextField)GetChildAt(15);
            shop_btn = (btn1)GetChildAt(16);
            plant_btn = (GButton)GetChildAt(17);
            effect_img = (GLoader)GetChildAt(18);
            flower_img1 = (GLoader)GetChildAt(19);
            flower_img = (GLoader)GetChildAt(20);
            spine = (GLoader3D)GetChildAt(21);
            n75 = (GImage)GetChildAt(22);
            n74 = (GImage)GetChildAt(23);
            spine1 = (GLoader3D)GetChildAt(24);
            nameBg = (GLoader)GetChildAt(25);
            flower_name = (GTextField)GetChildAt(26);
            completeLab = (GRichTextField)GetChildAt(27);
            n41 = (GImage)GetChildAt(28);
            backBtn = (GButton)GetChildAt(29);
            go_plant = (GButton)GetChildAt(30);
            n76 = (GGroup)GetChildAt(31);
            n69 = (GImage)GetChildAt(32);
            n70 = (GImage)GetChildAt(33);
            tip = (GRichTextField)GetChildAt(34);
            cultivation_btn = (GButton)GetChildAt(35);
            need_item_1 = (cultivation_seed2)GetChildAt(36);
            need_item_2 = (cultivation_seed2)GetChildAt(37);
            need_item_3 = (cultivation_seed2)GetChildAt(38);
            need_item_4 = (cultivation_seed2)GetChildAt(39);
            n79 = (GGroup)GetChildAt(40);
            n71 = (GGroup)GetChildAt(41);
            n72 = (GLoader)GetChildAt(42);
            process = (cultivation_new_process)GetChildAt(43);
            time_txt = (GTextField)GetChildAt(44);
            skip_btn = (GButton)GetChildAt(45);
            n34 = (GImage)GetChildAt(46);
            btn_video = (GButton)GetChildAt(47);
            video_txt = (GTextField)GetChildAt(48);
            videoGrp = (GGroup)GetChildAt(49);
            n73 = (GGroup)GetChildAt(50);
            n77 = (GGroup)GetChildAt(51);
            close_btn = (GButton)GetChildAt(52);
            share_btn = (GButton)GetChildAt(53);
            tipCom = (tip)GetChildAt(54);
        }
    }
}