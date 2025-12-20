/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contract_view : GComponent
    {
        public Controller show;
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
        public const string URL = "ui://w3ox9yltin5z1yjp870";

        public static contract_view CreateInstance()
        {
            return (contract_view)UIPackage.CreateObject("fun_Recharge", "contract_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            show = GetControllerAt(0);
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
        }
    }
}