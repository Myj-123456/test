/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_brandNew_item1 : GComponent
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
        public GTextField noitem_txt;
        public GTextField haveLab;
        public GGroup n95;
        public GTextField lockLv_txt;
        public GGroup n101;
        public probar1 seedPro;
        public GLoader seed_img;
        public GImage n69;
        public GTextField level_txt;
        public GGroup n102;
        public const string URL = "ui://ekoic0wrvx641yjp7xq";

        public static handbook_brandNew_item1 CreateInstance()
        {
            return (handbook_brandNew_item1)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_brandNew_item1");
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
            noitem_txt = (GTextField)GetChildAt(11);
            haveLab = (GTextField)GetChildAt(12);
            n95 = (GGroup)GetChildAt(13);
            lockLv_txt = (GTextField)GetChildAt(14);
            n101 = (GGroup)GetChildAt(15);
            seedPro = (probar1)GetChildAt(16);
            seed_img = (GLoader)GetChildAt(17);
            n69 = (GImage)GetChildAt(18);
            level_txt = (GTextField)GetChildAt(19);
            n102 = (GGroup)GetChildAt(20);
        }
    }
}