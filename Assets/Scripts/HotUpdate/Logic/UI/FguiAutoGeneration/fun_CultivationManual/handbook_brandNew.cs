/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_CultivationManual
{
    public partial class handbook_brandNew : GComponent
    {
        public Controller pageStatus;
        public GLoader fullScreenBg;
        public GImage n110;
        public GImage n105;
        public GImage n102;
        public GImage n104;
        public GImage n57;
        public GButton close_btn;
        public GButton help_btn;
        public GTextField pageTxt;
        public GGroup n44;
        public GTextField myFlowerLvSumTxt;
        public GTextField lb_starnum;
        public GList list;
        public GList page_list;
        public GButton rightBtn;
        public GButton leftBtn;
        public GGroup n96;
        public GButton btn_filter;
        public GButton flowerTab;
        public GButton succulentTab;
        public GButton vaseTab;
        public vasePanel vasePanel;
        public handbook_filter panel_filter;
        public const string URL = "ui://6q8q1ai6kbinwprh";

        public static handbook_brandNew CreateInstance()
        {
            return (handbook_brandNew)UIPackage.CreateObject("fun_CultivationManual", "handbook_brandNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            pageStatus = GetControllerAt(0);
            fullScreenBg = (GLoader)GetChildAt(0);
            n110 = (GImage)GetChildAt(1);
            n105 = (GImage)GetChildAt(2);
            n102 = (GImage)GetChildAt(3);
            n104 = (GImage)GetChildAt(4);
            n57 = (GImage)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
            help_btn = (GButton)GetChildAt(7);
            pageTxt = (GTextField)GetChildAt(8);
            n44 = (GGroup)GetChildAt(9);
            myFlowerLvSumTxt = (GTextField)GetChildAt(10);
            lb_starnum = (GTextField)GetChildAt(11);
            list = (GList)GetChildAt(12);
            page_list = (GList)GetChildAt(13);
            rightBtn = (GButton)GetChildAt(14);
            leftBtn = (GButton)GetChildAt(15);
            n96 = (GGroup)GetChildAt(16);
            btn_filter = (GButton)GetChildAt(17);
            flowerTab = (GButton)GetChildAt(18);
            succulentTab = (GButton)GetChildAt(19);
            vaseTab = (GButton)GetChildAt(20);
            vasePanel = (vasePanel)GetChildAt(21);
            panel_filter = (handbook_filter)GetChildAt(22);
        }
    }
}