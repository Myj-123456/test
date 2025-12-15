/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class vip_item : GComponent
    {
        public Controller type;
        public Controller dis;
        public Controller status;
        public GImage n17;
        public GImage n18;
        public GLoader bg;
        public GLoader pic;
        public GImage n20;
        public GTextField day_lab;
        public GGroup n30;
        public GImage n19;
        public GTextField discount;
        public GGroup n25;
        public GTextField timeLab;
        public GTextField limitLab;
        public GTextField nameLab;
        public GTextField numLab;
        public GImage n28;
        public greenPicBtn1 buy_btn;
        public greenPicBtn buy_btn1;
        public GGroup n31;
        public const string URL = "ui://wm7arakyvedm1ayr7sm";

        public static vip_item CreateInstance()
        {
            return (vip_item)UIPackage.CreateObject("fun_VipShop", "vip_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            dis = GetControllerAt(1);
            status = GetControllerAt(2);
            n17 = (GImage)GetChildAt(0);
            n18 = (GImage)GetChildAt(1);
            bg = (GLoader)GetChildAt(2);
            pic = (GLoader)GetChildAt(3);
            n20 = (GImage)GetChildAt(4);
            day_lab = (GTextField)GetChildAt(5);
            n30 = (GGroup)GetChildAt(6);
            n19 = (GImage)GetChildAt(7);
            discount = (GTextField)GetChildAt(8);
            n25 = (GGroup)GetChildAt(9);
            timeLab = (GTextField)GetChildAt(10);
            limitLab = (GTextField)GetChildAt(11);
            nameLab = (GTextField)GetChildAt(12);
            numLab = (GTextField)GetChildAt(13);
            n28 = (GImage)GetChildAt(14);
            buy_btn = (greenPicBtn1)GetChildAt(15);
            buy_btn1 = (greenPicBtn)GetChildAt(16);
            n31 = (GGroup)GetChildAt(17);
        }
    }
}