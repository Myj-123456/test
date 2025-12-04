/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class itemGetBtn : GButton
    {
        public GImage n6;
        public GTextField titleLab;
        public const string URL = "ui://zieeydldeqnf1yjp7v9";

        public static itemGetBtn CreateInstance()
        {
            return (itemGetBtn)UIPackage.CreateObject("fun_FlowerRankingList", "itemGetBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n6 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
        }
    }
}