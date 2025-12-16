/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Friends
{
    public partial class newBestListView : GComponent
    {
        public Controller status;
        public Controller applybestTip;
        public GLoader bg;
        public GTextField best_Title;
        public GImage n56;
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
        public GLoader n61;
        public GLoader jieshu_bg;
        public GLoader n60;
        public GTextField n48;
        public GImage n46;
        public GTextField text_desc;
        public GImage n57;
        public GTextField best_buyText;
        public clickBtnbuy btn_bestbuy;
        public GButton bg_sign;
        public GImage n49;
        public GTextField text_best_buyBookCount;
        public GGroup n42;
        public GGraph n62;
        public GLoader n63;
        public GImage n64;
        public GTextField jieshu_txt;
        public GTextField best_desc;
        public GButton btn_bestjieshu;
        public GButton btn_bestTipClose1;
        public GButton btn_bestTipClose;
        public GGroup n70;
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
            bg = (GLoader)GetChildAt(0);
            best_Title = (GTextField)GetChildAt(1);
            n56 = (GImage)GetChildAt(2);
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
            n61 = (GLoader)GetChildAt(17);
            jieshu_bg = (GLoader)GetChildAt(18);
            n60 = (GLoader)GetChildAt(19);
            n48 = (GTextField)GetChildAt(20);
            n46 = (GImage)GetChildAt(21);
            text_desc = (GTextField)GetChildAt(22);
            n57 = (GImage)GetChildAt(23);
            best_buyText = (GTextField)GetChildAt(24);
            btn_bestbuy = (clickBtnbuy)GetChildAt(25);
            bg_sign = (GButton)GetChildAt(26);
            n49 = (GImage)GetChildAt(27);
            text_best_buyBookCount = (GTextField)GetChildAt(28);
            n42 = (GGroup)GetChildAt(29);
            n62 = (GGraph)GetChildAt(30);
            n63 = (GLoader)GetChildAt(31);
            n64 = (GImage)GetChildAt(32);
            jieshu_txt = (GTextField)GetChildAt(33);
            best_desc = (GTextField)GetChildAt(34);
            btn_bestjieshu = (GButton)GetChildAt(35);
            btn_bestTipClose1 = (GButton)GetChildAt(36);
            btn_bestTipClose = (GButton)GetChildAt(37);
            n70 = (GGroup)GetChildAt(38);
        }
    }
}