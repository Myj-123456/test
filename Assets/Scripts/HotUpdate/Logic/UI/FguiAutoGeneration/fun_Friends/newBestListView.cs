/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newBestListView : GComponent
    {
        public Controller status;
        public Controller applybestTip;
        public GImage n2;
        public GLoader bg;
        public GTextField titleLab;
        public GButton close_btn;
        public GList list;
        public GComponent nullTip;
        public GImage n14;
        public GTextInput n16;
        public GTextField n17;
        public btn_lookup btn_lookup;
        public GTextField n20;
        public GImage n21;
        public GTextField n22;
        public GImage n23;
        public btn_best_book btn_best_buyBook;
        public GTextField n25;
        public GGraph n26;
        public GImage n43;
        public GTextField text_desc;
        public GButton btn_bestbuy;
        public GButton btn_bestjieshu;
        public GButton bg_sign;
        public GImage n46;
        public GImage n47;
        public GTextField n48;
        public GImage n49;
        public GTextField text_best_buyBookCount;
        public GImage n52;
        public GTextField n53;
        public GGroup n42;
        public const string URL = "ui://fteyf9nzg3sj1yjp7tq";

        public static newBestListView CreateInstance()
        {
            return (newBestListView)UIPackage.CreateObject("fun_Friends", "newBestListView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            applybestTip = GetControllerAt(1);
            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            nullTip = (GComponent)GetChildAt(5);
            n14 = (GImage)GetChildAt(6);
            n16 = (GTextInput)GetChildAt(7);
            n17 = (GTextField)GetChildAt(8);
            btn_lookup = (btn_lookup)GetChildAt(9);
            n20 = (GTextField)GetChildAt(10);
            n21 = (GImage)GetChildAt(11);
            n22 = (GTextField)GetChildAt(12);
            n23 = (GImage)GetChildAt(13);
            btn_best_buyBook = (btn_best_book)GetChildAt(14);
            n25 = (GTextField)GetChildAt(15);
            n26 = (GGraph)GetChildAt(16);
            n43 = (GImage)GetChildAt(17);
            text_desc = (GTextField)GetChildAt(18);
            btn_bestbuy = (GButton)GetChildAt(19);
            btn_bestjieshu = (GButton)GetChildAt(20);
            bg_sign = (GButton)GetChildAt(21);
            n46 = (GImage)GetChildAt(22);
            n47 = (GImage)GetChildAt(23);
            n48 = (GTextField)GetChildAt(24);
            n49 = (GImage)GetChildAt(25);
            text_best_buyBookCount = (GTextField)GetChildAt(26);
            n52 = (GImage)GetChildAt(27);
            n53 = (GTextField)GetChildAt(28);
            n42 = (GGroup)GetChildAt(29);
        }
    }
}