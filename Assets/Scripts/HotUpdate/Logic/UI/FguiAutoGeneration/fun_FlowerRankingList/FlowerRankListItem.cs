/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankListItem : GComponent
    {
        public Controller self;
        public Controller rankStyle;
        public GImage n55;
        public GImage n52;
        public GImage n53;
        public GImage n51;
        public GComponent head;
        public GComponent frame;
        public flowerRankIcon iconCom;
        public GTextField txt_point;
        public GTextField txt_name;
        public GTextField titleTxt;
        public GTextField rankTxt;
        public const string URL = "ui://zieeydld8ublpc6";

        public static FlowerRankListItem CreateInstance()
        {
            return (FlowerRankListItem)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankListItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            self = GetControllerAt(0);
            rankStyle = GetControllerAt(1);
            n55 = (GImage)GetChildAt(0);
            n52 = (GImage)GetChildAt(1);
            n53 = (GImage)GetChildAt(2);
            n51 = (GImage)GetChildAt(3);
            head = (GComponent)GetChildAt(4);
            frame = (GComponent)GetChildAt(5);
            iconCom = (flowerRankIcon)GetChildAt(6);
            txt_point = (GTextField)GetChildAt(7);
            txt_name = (GTextField)GetChildAt(8);
            titleTxt = (GTextField)GetChildAt(9);
            rankTxt = (GTextField)GetChildAt(10);
        }
    }
}