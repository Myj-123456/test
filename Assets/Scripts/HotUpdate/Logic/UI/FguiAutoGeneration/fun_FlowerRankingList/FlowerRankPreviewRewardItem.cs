/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankPreviewRewardItem : GComponent
    {
        public GLoader pic;
        public GTextField txt_num;
        public const string URL = "ui://zieeydldstsw1ayr7z1";

        public static FlowerRankPreviewRewardItem CreateInstance()
        {
            return (FlowerRankPreviewRewardItem)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankPreviewRewardItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pic = (GLoader)GetChildAt(0);
            txt_num = (GTextField)GetChildAt(1);
        }
    }
}