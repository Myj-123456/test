/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankPreview : GComponent
    {
        public GImage n28;
        public GLoader bg;
        public GImage n27;
        public GTextField rewardTipTxt;
        public FlowerRankPreviewScrollPane panel;
        public GButton close_btn;
        public const string URL = "ui://zieeydldivxqpbq";

        public static FlowerRankPreview CreateInstance()
        {
            return (FlowerRankPreview)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankPreview");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n28 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n27 = (GImage)GetChildAt(2);
            rewardTipTxt = (GTextField)GetChildAt(3);
            panel = (FlowerRankPreviewScrollPane)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
        }
    }
}