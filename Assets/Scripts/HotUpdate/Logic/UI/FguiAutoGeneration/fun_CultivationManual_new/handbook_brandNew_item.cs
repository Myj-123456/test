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
        public GImage n14;
        public GLoader style_img;
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
        public probar1 seedPro;
        public GLoader seed_img;
        public GImage n69;
        public GTextField level_txt;
        public GGroup n100;
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
            n14 = (GImage)GetChildAt(4);
            style_img = (GLoader)GetChildAt(5);
            level_up = (GImage)GetChildAt(6);
            bg = (GImage)GetChildAt(7);
            decLab = (GTextField)GetChildAt(8);
            n76 = (GGroup)GetChildAt(9);
            rewardBtn = (vaseFlowerRewradBtn)GetChildAt(10);
            lockLv_txt = (GTextField)GetChildAt(11);
            n89 = (GGroup)GetChildAt(12);
            noitem_txt = (GTextField)GetChildAt(13);
            haveLab = (GTextField)GetChildAt(14);
            n95 = (GGroup)GetChildAt(15);
            seedPro = (probar1)GetChildAt(16);
            seed_img = (GLoader)GetChildAt(17);
            n69 = (GImage)GetChildAt(18);
            level_txt = (GTextField)GetChildAt(19);
            n100 = (GGroup)GetChildAt(20);
        }
    }
}