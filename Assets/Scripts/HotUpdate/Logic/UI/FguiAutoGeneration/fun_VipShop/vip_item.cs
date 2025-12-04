/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_VipShop
{
    public partial class vip_item : GComponent
    {
        public Controller type;
        public GImage n0;
        public GImage n10;
        public GLoader pic;
        public GLoader cost_img;
        public GImage n8;
        public GImage n11;
        public GImage n12;
        public GTextField timeLab;
        public GGroup n14;
        public GTextField numLab;
        public GTextField limitLab;
        public GTextField nameLab;
        public GTextField costLab;
        public GTextField discount;
        public GGraph buy_btn;
        public const string URL = "ui://wm7arakyvedm1ayr7sm";

        public static vip_item CreateInstance()
        {
            return (vip_item)UIPackage.CreateObject("fun_VipShop", "vip_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n0 = (GImage)GetChildAt(0);
            n10 = (GImage)GetChildAt(1);
            pic = (GLoader)GetChildAt(2);
            cost_img = (GLoader)GetChildAt(3);
            n8 = (GImage)GetChildAt(4);
            n11 = (GImage)GetChildAt(5);
            n12 = (GImage)GetChildAt(6);
            timeLab = (GTextField)GetChildAt(7);
            n14 = (GGroup)GetChildAt(8);
            numLab = (GTextField)GetChildAt(9);
            limitLab = (GTextField)GetChildAt(10);
            nameLab = (GTextField)GetChildAt(11);
            costLab = (GTextField)GetChildAt(12);
            discount = (GTextField)GetChildAt(13);
            buy_btn = (GGraph)GetChildAt(14);
        }
    }
}