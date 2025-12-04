/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_GuildFlowerShare
{
    public partial class flowerShare_alert : GComponent
    {
        public Controller page;
        public GImage n29;
        public GImage n30;
        public GImage n25;
        public GRichTextField lb_title;
        public GRichTextField lb_count;
        public GLoader img_icon;
        public GGroup n19;
        public GList awardList;
        public flowerShare_cell_5 flower;
        public GRichTextField lb_info;
        public GRichTextField lb_info_1;
        public GButton btn_sure;
        public GButton btn_cancel;
        public GGroup n24;
        public GButton close_btn;
        public const string URL = "ui://zuzhxc13misapoe";

        public static flowerShare_alert CreateInstance()
        {
            return (flowerShare_alert)UIPackage.CreateObject("fun_GuildFlowerShare", "flowerShare_alert");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            page = GetControllerAt(0);
            n29 = (GImage)GetChildAt(0);
            n30 = (GImage)GetChildAt(1);
            n25 = (GImage)GetChildAt(2);
            lb_title = (GRichTextField)GetChildAt(3);
            lb_count = (GRichTextField)GetChildAt(4);
            img_icon = (GLoader)GetChildAt(5);
            n19 = (GGroup)GetChildAt(6);
            awardList = (GList)GetChildAt(7);
            flower = (flowerShare_cell_5)GetChildAt(8);
            lb_info = (GRichTextField)GetChildAt(9);
            lb_info_1 = (GRichTextField)GetChildAt(10);
            btn_sure = (GButton)GetChildAt(11);
            btn_cancel = (GButton)GetChildAt(12);
            n24 = (GGroup)GetChildAt(13);
            close_btn = (GButton)GetChildAt(14);
        }
    }
}