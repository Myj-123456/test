/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class flowerRankIcon : GComponent
    {
        public Controller status;
        public GImage n16;
        public GImage n17;
        public GImage n18;
        public const string URL = "ui://zieeydlde87c1ayr7z7";

        public static flowerRankIcon CreateInstance()
        {
            return (flowerRankIcon)UIPackage.CreateObject("fun_FlowerRankingList", "flowerRankIcon");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n16 = (GImage)GetChildAt(0);
            n17 = (GImage)GetChildAt(1);
            n18 = (GImage)GetChildAt(2);
        }
    }
}