/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade_New
{
    public partial class tradeSaleView : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n6;
        public GImage n5;
        public GImage n26;
        public GImage n27;
        public GImage n25;
        public GLoader img_item;
        public GImage n13;
        public GImage n16;
        public GImage n17;
        public GImage n29;
        public GLoader img_gold_sum;
        public GTextField lb_title;
        public GTextField lb_storageCount;
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
        public const string URL = "ui://jugv3wv4q9bjm";

        public static tradeSaleView CreateInstance()
        {
            return (tradeSaleView)UIPackage.CreateObject("fun_FriendsTrade_New", "tradeSaleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n6 = (GImage)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            n26 = (GImage)GetChildAt(5);
            n27 = (GImage)GetChildAt(6);
            n25 = (GImage)GetChildAt(7);
            img_item = (GLoader)GetChildAt(8);
            n13 = (GImage)GetChildAt(9);
            n16 = (GImage)GetChildAt(10);
            n17 = (GImage)GetChildAt(11);
            n29 = (GImage)GetChildAt(12);
            img_gold_sum = (GLoader)GetChildAt(13);
            lb_title = (GTextField)GetChildAt(14);
            lb_storageCount = (GTextField)GetChildAt(15);
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
        }
    }
}