/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_brandNew_item : GComponent
    {
        public Controller locked;
        public Controller statius;
        public Controller rewardStatus;
        public Controller isRareStatus;
        public GLoader bg_1;
        public GLoader img_gray;
        public GLoader img1;
        public GLoader imgSeedBg;
        public GLoader img2;
        public GImage n72;
        public GImage n69;
        public GTextField level_txt;
        public GTextField name_txt;
        public GLoader img3;
        public GImage n23;
        public GImage n14;
        public GTextField noitem_txt;
        public GTextField lockLv_txt;
        public GImage level_up;
        public GLoader bg;
        public GTextField decLab;
        public GGroup n76;
        public GLoader img3_effect;
        public GList ls_star;
        public GRichTextField process_txt;
        public vaseFlowerRewradBtn rewardBtn;
        public const string URL = "ui://6q8q1ai6kbinwpri";

        public static handbook_brandNew_item CreateInstance()
        {
            return (handbook_brandNew_item)UIPackage.CreateObject("fun_CultivationManual", "handbook_brandNew_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            locked = GetControllerAt(0);
            statius = GetControllerAt(1);
            rewardStatus = GetControllerAt(2);
            isRareStatus = GetControllerAt(3);
            bg_1 = (GLoader)GetChildAt(0);
            img_gray = (GLoader)GetChildAt(1);
            img1 = (GLoader)GetChildAt(2);
            imgSeedBg = (GLoader)GetChildAt(3);
            img2 = (GLoader)GetChildAt(4);
            n72 = (GImage)GetChildAt(5);
            n69 = (GImage)GetChildAt(6);
            level_txt = (GTextField)GetChildAt(7);
            name_txt = (GTextField)GetChildAt(8);
            img3 = (GLoader)GetChildAt(9);
            n23 = (GImage)GetChildAt(10);
            n14 = (GImage)GetChildAt(11);
            noitem_txt = (GTextField)GetChildAt(12);
            lockLv_txt = (GTextField)GetChildAt(13);
            level_up = (GImage)GetChildAt(14);
            bg = (GLoader)GetChildAt(15);
            decLab = (GTextField)GetChildAt(16);
            n76 = (GGroup)GetChildAt(17);
            img3_effect = (GLoader)GetChildAt(18);
            ls_star = (GList)GetChildAt(19);
            process_txt = (GRichTextField)GetChildAt(20);
            rewardBtn = (vaseFlowerRewradBtn)GetChildAt(21);
        }
    }
}