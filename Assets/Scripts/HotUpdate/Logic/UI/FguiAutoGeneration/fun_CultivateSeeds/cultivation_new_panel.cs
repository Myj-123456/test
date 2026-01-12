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
        public GImage n6;
        public GImage n9;
        public GTextField nullTip;
        public btn1 shop_btn;
        public GButton plant_btn;
        public GLoader effect_img;
        public GLoader flower_img1;
        public GLoader flower_img;
        public GLoader3D spine;
        public tweenCom tweenCom;
        public GButton leftBtn;
        public GButton rightBtn;
        public GGroup n84;
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
        public GImage n85;
        public GRichTextField tip;
        public GButton cultivation_btn;
        public cultivation_seed2 need_item_1;
        public cultivation_seed2 need_item_2;
        public cultivation_seed2 need_item_3;
        public cultivation_seed2 need_item_4;
        public GGroup n79;
        public GGroup n86;
        public GLoader speed_img;
        public cultivation_new_process process;
        public GTextField time_txt;
        public greenPicBtn skip_btn;
        public GImage n34;
        public GButton btn_video;
        public GTextField video_txt;
        public GGroup videoGrp;
        public GGroup n87;
        public GGroup n89;
        public GImage n82;
        public GTextField title;
        public GButton question_btn;
        public GGroup n83;
        public GButton close_btn;
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
            n6 = (GImage)GetChildAt(5);
            n9 = (GImage)GetChildAt(6);
            nullTip = (GTextField)GetChildAt(7);
            shop_btn = (btn1)GetChildAt(8);
            plant_btn = (GButton)GetChildAt(9);
            effect_img = (GLoader)GetChildAt(10);
            flower_img1 = (GLoader)GetChildAt(11);
            flower_img = (GLoader)GetChildAt(12);
            spine = (GLoader3D)GetChildAt(13);
            tweenCom = (tweenCom)GetChildAt(14);
            leftBtn = (GButton)GetChildAt(15);
            rightBtn = (GButton)GetChildAt(16);
            n84 = (GGroup)GetChildAt(17);
            n75 = (GImage)GetChildAt(18);
            n74 = (GImage)GetChildAt(19);
            spine1 = (GLoader3D)GetChildAt(20);
            nameBg = (GLoader)GetChildAt(21);
            flower_name = (GTextField)GetChildAt(22);
            completeLab = (GRichTextField)GetChildAt(23);
            n41 = (GImage)GetChildAt(24);
            backBtn = (GButton)GetChildAt(25);
            go_plant = (GButton)GetChildAt(26);
            n76 = (GGroup)GetChildAt(27);
            n85 = (GImage)GetChildAt(28);
            tip = (GRichTextField)GetChildAt(29);
            cultivation_btn = (GButton)GetChildAt(30);
            need_item_1 = (cultivation_seed2)GetChildAt(31);
            need_item_2 = (cultivation_seed2)GetChildAt(32);
            need_item_3 = (cultivation_seed2)GetChildAt(33);
            need_item_4 = (cultivation_seed2)GetChildAt(34);
            n79 = (GGroup)GetChildAt(35);
            n86 = (GGroup)GetChildAt(36);
            speed_img = (GLoader)GetChildAt(37);
            process = (cultivation_new_process)GetChildAt(38);
            time_txt = (GTextField)GetChildAt(39);
            skip_btn = (greenPicBtn)GetChildAt(40);
            n34 = (GImage)GetChildAt(41);
            btn_video = (GButton)GetChildAt(42);
            video_txt = (GTextField)GetChildAt(43);
            videoGrp = (GGroup)GetChildAt(44);
            n87 = (GGroup)GetChildAt(45);
            n89 = (GGroup)GetChildAt(46);
            n82 = (GImage)GetChildAt(47);
            title = (GTextField)GetChildAt(48);
            question_btn = (GButton)GetChildAt(49);
            n83 = (GGroup)GetChildAt(50);
            close_btn = (GButton)GetChildAt(51);
            tipCom = (tip)GetChildAt(52);
        }
    }
}