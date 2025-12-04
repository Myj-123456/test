/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class handbook_VaseItem : GComponent
    {
        public Controller unlockStatus;
        public Controller rewardStatus;
        public GLoader bg;
        public GLoader img1;
        public GImage n14;
        public GTextField name_txt;
        public GRichTextField process_txt;
        public vaseFlowerRewradBtn rewardBtn;
        public GImage n74;
        public GTextField getted;
        public GGroup n76;
        public const string URL = "ui://ekoic0wriust18";

        public static handbook_VaseItem CreateInstance()
        {
            return (handbook_VaseItem)UIPackage.CreateObject("fun_CultivationManual_new", "handbook_VaseItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            unlockStatus = GetControllerAt(0);
            rewardStatus = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            img1 = (GLoader)GetChildAt(1);
            n14 = (GImage)GetChildAt(2);
            name_txt = (GTextField)GetChildAt(3);
            process_txt = (GRichTextField)GetChildAt(4);
            rewardBtn = (vaseFlowerRewradBtn)GetChildAt(5);
            n74 = (GImage)GetChildAt(6);
            getted = (GTextField)GetChildAt(7);
            n76 = (GGroup)GetChildAt(8);
        }
    }
}