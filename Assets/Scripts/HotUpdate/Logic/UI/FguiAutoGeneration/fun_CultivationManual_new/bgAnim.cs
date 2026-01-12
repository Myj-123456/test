/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual_new
{
    public partial class bgAnim : GComponent
    {
        public Controller pageStatus;
        public tabBtn flowerTab;
        public tabBtn vaseTab;
        public GLoader bg;
        public vasePanel vasePanel;
        public GGraph rect;
        public GList list;
        public GList page_list;
        public GButton rightBtn;
        public GButton leftBtn;
        public GGroup n32;
        public GImage n29;
        public GImage n4;
        public handbook_filter panel_filter;
        public btn btn_filter;
        public GTextField myFlowerLvSumTxt;
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
            flowerTab = (tabBtn)GetChildAt(0);
            vaseTab = (tabBtn)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            vasePanel = (vasePanel)GetChildAt(3);
            rect = (GGraph)GetChildAt(4);
            list = (GList)GetChildAt(5);
            page_list = (GList)GetChildAt(6);
            rightBtn = (GButton)GetChildAt(7);
            leftBtn = (GButton)GetChildAt(8);
            n32 = (GGroup)GetChildAt(9);
            n29 = (GImage)GetChildAt(10);
            n4 = (GImage)GetChildAt(11);
            panel_filter = (handbook_filter)GetChildAt(12);
            btn_filter = (btn)GetChildAt(13);
            myFlowerLvSumTxt = (GTextField)GetChildAt(14);
            page = GetTransitionAt(0);
        }
    }
}