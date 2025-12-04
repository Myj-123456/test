/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FlowerRankingList
{
    public partial class FlowerRankPreviewItem : GComponent
    {
        public Controller gradeTab;
        public Controller theLastOne;
        public GImage n69;
        public GImage n71;
        public GImage n70;
        public GTextField titleNameTxt;
        public GTextField r1;
        public GTextField r2;
        public GTextField r3;
        public GTextField r4;
        public GTextField r11;
        public GTextField r21;
        public GTextField r51;
        public GTextField r101;
        public GTextField r151;
        public GTextField r201;
        public GTextField r1001;
        public GTextField r5001;
        public GTextField r10001;
        public GComponent grid;
        public GList rewardList;
        public const string URL = "ui://zieeydldivxqpbs";

        public static FlowerRankPreviewItem CreateInstance()
        {
            return (FlowerRankPreviewItem)UIPackage.CreateObject("fun_FlowerRankingList", "FlowerRankPreviewItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            gradeTab = GetControllerAt(0);
            theLastOne = GetControllerAt(1);
            n69 = (GImage)GetChildAt(0);
            n71 = (GImage)GetChildAt(1);
            n70 = (GImage)GetChildAt(2);
            titleNameTxt = (GTextField)GetChildAt(3);
            r1 = (GTextField)GetChildAt(4);
            r2 = (GTextField)GetChildAt(5);
            r3 = (GTextField)GetChildAt(6);
            r4 = (GTextField)GetChildAt(7);
            r11 = (GTextField)GetChildAt(8);
            r21 = (GTextField)GetChildAt(9);
            r51 = (GTextField)GetChildAt(10);
            r101 = (GTextField)GetChildAt(11);
            r151 = (GTextField)GetChildAt(12);
            r201 = (GTextField)GetChildAt(13);
            r1001 = (GTextField)GetChildAt(14);
            r5001 = (GTextField)GetChildAt(15);
            r10001 = (GTextField)GetChildAt(16);
            grid = (GComponent)GetChildAt(17);
            rewardList = (GList)GetChildAt(18);
        }
    }
}