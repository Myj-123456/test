/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeSaleView : GComponent
    {
        public GLoader bg;
        public GImage n46;
        public GImage n41;
        public GImage n42;
        public GImage n44;
        public GImage n45;
        public GImage n47;
        public GImage n51;
        public GImage n55;
        public GImage n49;
        public GImage _1;
        public GImage n48;
        public GLoader img_item;
        public GLoader img_gold_sum;
        public GTextField lb_title;
        public GRichTextField lb_storageCount;
        public GTextField title_0;
        public GTextField title_1;
        public GTextField title_2;
        public GTextField title_3;
        public GTextField lb_Count;
        public GTextField lb_price;
        public GTextField lb_goldSum;
        public GTextInput inputLab;
        public GButton btn_add;
        public GButton btn_sub;
        public GButton btn_min;
        public GButton btn_max;
        public GButton close_btn;
        public GButton findBtn;
        public GList ls_ItemList;
        public GList page_list;
        public GButton leftBtn;
        public GButton rightBtn;
        public GButton btn_submit;
        public GButton btn_password;
        public GGraph touch_price;
        public GGraph touch_Count;
        public GTextField titleLab;
        public GButton flower_btn;
        public const string URL = "ui://jugv3wv4q9bjm";

        public static tradeSaleView CreateInstance()
        {
            return (tradeSaleView)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeSaleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n46 = (GImage)GetChildAt(1);
            n41 = (GImage)GetChildAt(2);
            n42 = (GImage)GetChildAt(3);
            n44 = (GImage)GetChildAt(4);
            n45 = (GImage)GetChildAt(5);
            n47 = (GImage)GetChildAt(6);
            n51 = (GImage)GetChildAt(7);
            n55 = (GImage)GetChildAt(8);
            n49 = (GImage)GetChildAt(9);
            _1 = (GImage)GetChildAt(10);
            n48 = (GImage)GetChildAt(11);
            img_item = (GLoader)GetChildAt(12);
            img_gold_sum = (GLoader)GetChildAt(13);
            lb_title = (GTextField)GetChildAt(14);
            lb_storageCount = (GRichTextField)GetChildAt(15);
            title_0 = (GTextField)GetChildAt(16);
            title_1 = (GTextField)GetChildAt(17);
            title_2 = (GTextField)GetChildAt(18);
            title_3 = (GTextField)GetChildAt(19);
            lb_Count = (GTextField)GetChildAt(20);
            lb_price = (GTextField)GetChildAt(21);
            lb_goldSum = (GTextField)GetChildAt(22);
            inputLab = (GTextInput)GetChildAt(23);
            btn_add = (GButton)GetChildAt(24);
            btn_sub = (GButton)GetChildAt(25);
            btn_min = (GButton)GetChildAt(26);
            btn_max = (GButton)GetChildAt(27);
            close_btn = (GButton)GetChildAt(28);
            findBtn = (GButton)GetChildAt(29);
            ls_ItemList = (GList)GetChildAt(30);
            page_list = (GList)GetChildAt(31);
            leftBtn = (GButton)GetChildAt(32);
            rightBtn = (GButton)GetChildAt(33);
            btn_submit = (GButton)GetChildAt(34);
            btn_password = (GButton)GetChildAt(35);
            touch_price = (GGraph)GetChildAt(36);
            touch_Count = (GGraph)GetChildAt(37);
            titleLab = (GTextField)GetChildAt(38);
            flower_btn = (GButton)GetChildAt(39);
        }
    }
}