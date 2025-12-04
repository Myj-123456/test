/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankTopItem1 : GComponent
    {
        public Controller rankStyle;
        public GImage n63;
        public GImage n65;
        public GImage n66;
        public GImage n64;
        public GImage n53;
        public GImage n59;
        public GImage n60;
        public GImage n61;
        public flowerRankIcon iconCom;
        public GTextField txt_point;
        public GTextField txt_name;
        public GTextField titleTxt;
        public const string URL = "ui://zieeydldstsw1ayr7yy";

        public static FlowerRankTopItem1 CreateInstance()
        {
            return (FlowerRankTopItem1)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankTopItem1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            rankStyle = GetControllerAt(0);
            n63 = (GImage)GetChildAt(0);
            n65 = (GImage)GetChildAt(1);
            n66 = (GImage)GetChildAt(2);
            n64 = (GImage)GetChildAt(3);
            n53 = (GImage)GetChildAt(4);
            n59 = (GImage)GetChildAt(5);
            n60 = (GImage)GetChildAt(6);
            n61 = (GImage)GetChildAt(7);
            iconCom = (flowerRankIcon)GetChildAt(8);
            txt_point = (GTextField)GetChildAt(9);
            txt_name = (GTextField)GetChildAt(10);
            titleTxt = (GTextField)GetChildAt(11);
        }
    }
}