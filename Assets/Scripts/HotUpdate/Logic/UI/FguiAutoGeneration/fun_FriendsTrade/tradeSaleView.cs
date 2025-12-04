/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_FriendsTrade
{
    public partial class tradeSaleView : GComponent
    {
        public GImage n49;
        public GImage n54;
        public GRichTextField lb_title;
        public GLoader img_item;
        public GTextField lb_storageCount;
        public GButton btn_submit;
        public GTextField title_0;
        public GImage n50;
        public GButton btn_sub;
        public GButton btn_add;
        public GTextField lb_Count;
        public GRichTextField lb_CountRange;
        public GGraph touch_Count;
        public GTextField title_1;
        public GImage n51;
        public GButton btn_max;
        public GButton btn_min;
        public GRichTextField lb_priceRange;
        public GLoader img_gold;
        public GTextField lb_price;
        public GGraph touch_price;
        public GTextField title_2;
        public GImage n52;
        public GLoader img_gold_sum;
        public GTextField lb_goldSum;
        public GButton close_btn;
        public GButton btn_password;
        public const string URL = "ui://tx86642v8xrstwpxt";

        public static tradeSaleView CreateInstance()
        {
            return (tradeSaleView)UIPackage.CreateObject("fun_FriendsTrade", "tradeSaleView");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n49 = (GImage)GetChildAt(0);
            n54 = (GImage)GetChildAt(1);
            lb_title = (GRichTextField)GetChildAt(2);
            img_item = (GLoader)GetChildAt(3);
            lb_storageCount = (GTextField)GetChildAt(4);
            btn_submit = (GButton)GetChildAt(5);
            title_0 = (GTextField)GetChildAt(6);
            n50 = (GImage)GetChildAt(7);
            btn_sub = (GButton)GetChildAt(8);
            btn_add = (GButton)GetChildAt(9);
            lb_Count = (GTextField)GetChildAt(10);
            lb_CountRange = (GRichTextField)GetChildAt(11);
            touch_Count = (GGraph)GetChildAt(12);
            title_1 = (GTextField)GetChildAt(13);
            n51 = (GImage)GetChildAt(14);
            btn_max = (GButton)GetChildAt(15);
            btn_min = (GButton)GetChildAt(16);
            lb_priceRange = (GRichTextField)GetChildAt(17);
            img_gold = (GLoader)GetChildAt(18);
            lb_price = (GTextField)GetChildAt(19);
            touch_price = (GGraph)GetChildAt(20);
            title_2 = (GTextField)GetChildAt(21);
            n52 = (GImage)GetChildAt(22);
            img_gold_sum = (GLoader)GetChildAt(23);
            lb_goldSum = (GTextField)GetChildAt(24);
            close_btn = (GButton)GetChildAt(25);
            btn_password = (GButton)GetChildAt(26);
        }
    }
}