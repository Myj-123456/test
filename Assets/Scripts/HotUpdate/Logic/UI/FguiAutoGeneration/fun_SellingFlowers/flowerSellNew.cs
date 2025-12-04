/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_SellingFlowers
{
    public partial class flowerSellNew : GComponent
    {
        public Controller state;
        public Controller vipStatus;
        public Controller hasReduce;
        public GGraph hitArea;
        public GButton left_btn;
        public GButton right_btn;
        public GImage n289;
        public GImage n290;
        public GImage n291;
        public GImage n296;
        public GImage n297;
        public GImage n293;
        public GImage n294;
        public GImage n89;
        public GTextField txt_price;
        public GTextField txt_time;
        public GTextField info_txt;
        public GTextField gold_txt_1;
        public GTextField nameLab;
        public GTextField coolDown;
        public GTextField reduceTime;
        public oddBtn minus_btn;
        public addBtn plus_btn;
        public blueBgBtn btn_max;
        public clickBtn oneKey_done_btn;
        public clickBtn1 done_btn;
        public GGroup n305;
        public GGroup n301;
        public GGroup n299;
        public GImage n288;
        public GList list;
        public GList page_list;
        public GRichTextField txt_noFlower;
        public GGroup n300;
        public const string URL = "ui://ztwqlwa2qarjp39";

        public static flowerSellNew CreateInstance()
        {
            return (flowerSellNew)UIPackage.CreateObject("fun_SellingFlowers", "flowerSellNew");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            state = GetControllerAt(0);
            vipStatus = GetControllerAt(1);
            hasReduce = GetControllerAt(2);
            hitArea = (GGraph)GetChildAt(0);
            left_btn = (GButton)GetChildAt(1);
            right_btn = (GButton)GetChildAt(2);
            n289 = (GImage)GetChildAt(3);
            n290 = (GImage)GetChildAt(4);
            n291 = (GImage)GetChildAt(5);
            n296 = (GImage)GetChildAt(6);
            n297 = (GImage)GetChildAt(7);
            n293 = (GImage)GetChildAt(8);
            n294 = (GImage)GetChildAt(9);
            n89 = (GImage)GetChildAt(10);
            txt_price = (GTextField)GetChildAt(11);
            txt_time = (GTextField)GetChildAt(12);
            info_txt = (GTextField)GetChildAt(13);
            gold_txt_1 = (GTextField)GetChildAt(14);
            nameLab = (GTextField)GetChildAt(15);
            coolDown = (GTextField)GetChildAt(16);
            reduceTime = (GTextField)GetChildAt(17);
            minus_btn = (oddBtn)GetChildAt(18);
            plus_btn = (addBtn)GetChildAt(19);
            btn_max = (blueBgBtn)GetChildAt(20);
            oneKey_done_btn = (clickBtn)GetChildAt(21);
            done_btn = (clickBtn1)GetChildAt(22);
            n305 = (GGroup)GetChildAt(23);
            n301 = (GGroup)GetChildAt(24);
            n299 = (GGroup)GetChildAt(25);
            n288 = (GImage)GetChildAt(26);
            list = (GList)GetChildAt(27);
            page_list = (GList)GetChildAt(28);
            txt_noFlower = (GRichTextField)GetChildAt(29);
            n300 = (GGroup)GetChildAt(30);
        }
    }
}