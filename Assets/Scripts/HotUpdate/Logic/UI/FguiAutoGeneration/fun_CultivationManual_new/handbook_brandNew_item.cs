/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_brandNew_item : GComponent
    {
        public Controller statius;
        public Controller rewardStatus;
        public Controller isRareStatus;
        public GLoader bg_1;
        public GLoader img1;
        public GLoader3D spine;
        public GTextField name_txt;
        public GImage n106;
        public GImage level_up;
        public GImage bg;
        public GTextField decLab;
        public GGroup n76;
        public vaseFlowerRewradBtn rewardBtn;
        public GTextField lockLv_txt;
        public GGroup n89;
        public GTextField noitem_txt;
        public GTextField haveLab;
        public GGroup n95;
        public GImage n103;
        public GLoader seed_img;
        public GTextField level_txt;
        public GTextField seed_num;
        public GGroup n105;
        public const string URL = "ui://ekoic0wriusty";

        public static handbook_brandNew_item CreateInstance()
        {
            return (handbook_brandNew_item)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_brandNew_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            statius = GetControllerAt(0);
            rewardStatus = GetControllerAt(1);
            isRareStatus = GetControllerAt(2);
            bg_1 = (GLoader)GetChildAt(0);
            img1 = (GLoader)GetChildAt(1);
            spine = (GLoader3D)GetChildAt(2);
            name_txt = (GTextField)GetChildAt(3);
            n106 = (GImage)GetChildAt(4);
            level_up = (GImage)GetChildAt(5);
            bg = (GImage)GetChildAt(6);
            decLab = (GTextField)GetChildAt(7);
            n76 = (GGroup)GetChildAt(8);
            rewardBtn = (vaseFlowerRewradBtn)GetChildAt(9);
            lockLv_txt = (GTextField)GetChildAt(10);
            n89 = (GGroup)GetChildAt(11);
            noitem_txt = (GTextField)GetChildAt(12);
            haveLab = (GTextField)GetChildAt(13);
            n95 = (GGroup)GetChildAt(14);
            n103 = (GImage)GetChildAt(15);
            seed_img = (GLoader)GetChildAt(16);
            level_txt = (GTextField)GetChildAt(17);
            seed_num = (GTextField)GetChildAt(18);
            n105 = (GGroup)GetChildAt(19);
        }
    }
}