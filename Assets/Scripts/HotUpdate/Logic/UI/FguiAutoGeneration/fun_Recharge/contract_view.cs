/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contract_view : GComponent
    {
        public Controller show;
        public Controller contractBuyLevel;
        public GLoader bg;
        public GLoader huadianBg;
        public GImage n15;
        public GList list;
        public GList taskList;
        public pro2 pro;
        public GImage n17;
        public GTextField lvLab;
        public GTextField proLab;
        public GImage n18;
        public GButton addBtn;
        public GButton exBtn;
        public page_btn3 huadianBtn;
        public page_btn3 taskBtn;
        public GImage n26;
        public contractPreviewRootBtn previewBtn;
        public GRichTextField tipLab;
        public GTextField tipLab1;
        public GTextField tipLab2;
        public GTextField tipLab3;
        public GLoader buyLevelbg;
        public GTextField buyLevel_Title;
        public GImage n40;
        public GButton buyLevelClose;
        public GImage n41;
        public GImage n42;
        public GImage n43;
        public GImage n44;
        public GTextField level1;
        public GTextField level2;
        public GTextField text_title1;
        public GTextField text_title2;
        public GList addlist;
        public GList buylist;
        public GButton btn_buyLevel;
        public GImage n53;
        public btn_Opening btn_Opening;
        public GGroup n37;
        public const string URL = "ui://w3ox9yltin5z1yjp870";

        public static contract_view CreateInstance()
        {
            return (contract_view)UIPackage.CreateObject("fun_Recharge", "contract_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
            contractBuyLevel = GetControllerAt(1);
            bg = (GLoader)GetChildAt(0);
            huadianBg = (GLoader)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            list = (GList)GetChildAt(3);
            taskList = (GList)GetChildAt(4);
            pro = (pro2)GetChildAt(5);
            n17 = (GImage)GetChildAt(6);
            lvLab = (GTextField)GetChildAt(7);
            proLab = (GTextField)GetChildAt(8);
            n18 = (GImage)GetChildAt(9);
            addBtn = (GButton)GetChildAt(10);
            exBtn = (GButton)GetChildAt(11);
            huadianBtn = (page_btn3)GetChildAt(12);
            taskBtn = (page_btn3)GetChildAt(13);
            n26 = (GImage)GetChildAt(14);
            previewBtn = (contractPreviewRootBtn)GetChildAt(15);
            tipLab = (GRichTextField)GetChildAt(16);
            tipLab1 = (GTextField)GetChildAt(17);
            tipLab2 = (GTextField)GetChildAt(18);
            tipLab3 = (GTextField)GetChildAt(19);
            buyLevelbg = (GLoader)GetChildAt(20);
            buyLevel_Title = (GTextField)GetChildAt(21);
            n40 = (GImage)GetChildAt(22);
            buyLevelClose = (GButton)GetChildAt(23);
            n41 = (GImage)GetChildAt(24);
            n42 = (GImage)GetChildAt(25);
            n43 = (GImage)GetChildAt(26);
            n44 = (GImage)GetChildAt(27);
            level1 = (GTextField)GetChildAt(28);
            level2 = (GTextField)GetChildAt(29);
            text_title1 = (GTextField)GetChildAt(30);
            text_title2 = (GTextField)GetChildAt(31);
            addlist = (GList)GetChildAt(32);
            buylist = (GList)GetChildAt(33);
            btn_buyLevel = (GButton)GetChildAt(34);
            n53 = (GImage)GetChildAt(35);
            btn_Opening = (btn_Opening)GetChildAt(36);
            n37 = (GGroup)GetChildAt(37);
        }
    }
}