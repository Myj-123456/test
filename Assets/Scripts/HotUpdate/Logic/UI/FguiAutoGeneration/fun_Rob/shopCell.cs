/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class shopCell : GComponent
    {
        public Controller isLastStatus;
        public Controller status;
        public Controller limitCtrl;
        public GImage n7;
        public GImage n15;
        public GLoader img_bg;
        public GLoader img;
        public GTextField lb_count;
        public GTextField txt_name;
        public GTextField txt_nameVip;
        public GTextField txt_desc;
        public GTextField txt_vipdesc;
        public GTextField txt_limit;
        public GButton btn_buy;
        public btn_large btn_buy1;
        public btn_vip btn_buy2;
        public GLoader n12;
        public GTextField rareNum;
        public GTextField rareLab;
        public GTextField rareNum1;
        public GTextField rareLab1;
        public const string URL = "ui://z1on8kwdqqn4pkt";

        public static shopCell CreateInstance()
        {
            return (shopCell)UIPackage.CreateObject("fun_Rob", "shopCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isLastStatus = GetControllerAt(0);
            status = GetControllerAt(1);
            limitCtrl = GetControllerAt(2);
            n7 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            img_bg = (GLoader)GetChildAt(2);
            img = (GLoader)GetChildAt(3);
            lb_count = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_nameVip = (GTextField)GetChildAt(6);
            txt_desc = (GTextField)GetChildAt(7);
            txt_vipdesc = (GTextField)GetChildAt(8);
            txt_limit = (GTextField)GetChildAt(9);
            btn_buy = (GButton)GetChildAt(10);
            btn_buy1 = (btn_large)GetChildAt(11);
            btn_buy2 = (btn_vip)GetChildAt(12);
            n12 = (GLoader)GetChildAt(13);
            rareNum = (GTextField)GetChildAt(14);
            rareLab = (GTextField)GetChildAt(15);
            rareNum1 = (GTextField)GetChildAt(16);
            rareLab1 = (GTextField)GetChildAt(17);
        }
    }
}