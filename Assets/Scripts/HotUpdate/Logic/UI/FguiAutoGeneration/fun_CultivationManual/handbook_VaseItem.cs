/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_VaseItem : GComponent
    {
        public Controller unlockStatus;
        public Controller rewardStatus;
        public GImage n71;
        public GImage n73;
        public GLoader img1;
        public GImage n72;
        public GImage n14;
        public GTextField name_txt;
        public GRichTextField process_txt;
        public vaseFlowerRewradBtn rewardBtn;
        public GImage n74;
        public GTextField n75;
        public GGroup n76;
        public const string URL = "ui://6q8q1ai6ftbu1ayr85d";

        public static handbook_VaseItem CreateInstance()
        {
            return (handbook_VaseItem)UIPackage.CreateObject("fun_CultivationManual", "handbook_VaseItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlockStatus = GetControllerAt(0);
            rewardStatus = GetControllerAt(1);
            n71 = (GImage)GetChildAt(0);
            n73 = (GImage)GetChildAt(1);
            img1 = (GLoader)GetChildAt(2);
            n72 = (GImage)GetChildAt(3);
            n14 = (GImage)GetChildAt(4);
            name_txt = (GTextField)GetChildAt(5);
            process_txt = (GRichTextField)GetChildAt(6);
            rewardBtn = (vaseFlowerRewradBtn)GetChildAt(7);
            n74 = (GImage)GetChildAt(8);
            n75 = (GTextField)GetChildAt(9);
            n76 = (GGroup)GetChildAt(10);
        }
    }
}