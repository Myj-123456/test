/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankPreviewScrollPane : GComponent
    {
        public GList rankList;
        public const string URL = "ui://zieeydldr2t8pdu";

        public static FlowerRankPreviewScrollPane CreateInstance()
        {
            return (FlowerRankPreviewScrollPane)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankPreviewScrollPane");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rankList = (GList)GetChildAt(0);
        }
    }
}