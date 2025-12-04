/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class bgAnim : GComponent
    {
        public Controller pageStatus;
        public GLoader bg;
        public tabBtn flowerTab;
        public tabBtn vaseTab;
        public vasePanel vasePanel;
        public GImage n20;
        public GGraph rect;
        public GList list;
        public GList page_list;
        public GButton rightBtn;
        public GButton leftBtn;
        public GGroup n23;
        public GImage n3;
        public GImage n4;
        public GButton btn_filter;
        public GTextField myFlowerLvSumTxt;
        public handbook_filter panel_filter;
        public Transition page;
        public const string URL = "ui://ekoic0wru0i31yjp7tz";

        public static bgAnim CreateInstance()
        {
            return (bgAnim)UIPackage.CreateObject("fun_CultivationManual_new", "bgAnim");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pageStatus = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            flowerTab = (tabBtn)GetChildAt(1);
            vaseTab = (tabBtn)GetChildAt(2);
            vasePanel = (vasePanel)GetChildAt(3);
            n20 = (GImage)GetChildAt(4);
            rect = (GGraph)GetChildAt(5);
            list = (GList)GetChildAt(6);
            page_list = (GList)GetChildAt(7);
            rightBtn = (GButton)GetChildAt(8);
            leftBtn = (GButton)GetChildAt(9);
            n23 = (GGroup)GetChildAt(10);
            n3 = (GImage)GetChildAt(11);
            n4 = (GImage)GetChildAt(12);
            btn_filter = (GButton)GetChildAt(13);
            myFlowerLvSumTxt = (GTextField)GetChildAt(14);
            panel_filter = (handbook_filter)GetChildAt(15);
            page = GetTransitionAt(0);
        }
    }
}