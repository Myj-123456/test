/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class shopCell : GComponent
    {
        public Controller isVip;
        public Controller limit;
        public Controller discoubt;
        public GImage n7;
        public GImage n15;
        public GLoader img_bg;
        public GLoader img;
        public GTextField lb_count;
        public GTextField txt_name;
        public GTextField txt_desc;
        public GTextField txt_limit;
        public GImage n24;
        public GTextField rareNum;
        public GTextField rareLab;
        public GGroup n25;
        public btn_shop btn;
        public const string URL = "ui://z1on8kwdqqn4pkt";

        public static shopCell CreateInstance()
        {
            return (shopCell)UIPackage.CreateObject("fun_Rob", "shopCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            isVip = GetControllerAt(0);
            limit = GetControllerAt(1);
            discoubt = GetControllerAt(2);
            n7 = (GImage)GetChildAt(0);
            n15 = (GImage)GetChildAt(1);
            img_bg = (GLoader)GetChildAt(2);
            img = (GLoader)GetChildAt(3);
            lb_count = (GTextField)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_desc = (GTextField)GetChildAt(6);
            txt_limit = (GTextField)GetChildAt(7);
            n24 = (GImage)GetChildAt(8);
            rareNum = (GTextField)GetChildAt(9);
            rareLab = (GTextField)GetChildAt(10);
            n25 = (GGroup)GetChildAt(11);
            btn = (btn_shop)GetChildAt(12);
        }
    }
}