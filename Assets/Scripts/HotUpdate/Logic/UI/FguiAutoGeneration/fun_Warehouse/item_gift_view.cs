/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Warehouse
{
    public partial class item_gift_view : GComponent
    {
        public GLoader bg;
        public GImage n50;
        public GImage n48;
        public GButton close_btn;
        public GLoader img_icon;
        public GTextField txt_name;
        public GTextField txt_des;
        public GTextField txt_ownNum;
        public GLoader rare_img;
        public GImage n56;
        public GTextInput numLab;
        public GButton add_btn;
        public GButton odd_btn;
        public GButton max_btn;
        public GButton min_btn;
        public GButton get_btn;
        public const string URL = "ui://6soq1zhgv01m1yjp840";

        public static item_gift_view CreateInstance()
        {
            return (item_gift_view)UIPackage.CreateObject("fun_Warehouse", "item_gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            n50 = (GImage)GetChildAt(1);
            n48 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            img_icon = (GLoader)GetChildAt(4);
            txt_name = (GTextField)GetChildAt(5);
            txt_des = (GTextField)GetChildAt(6);
            txt_ownNum = (GTextField)GetChildAt(7);
            rare_img = (GLoader)GetChildAt(8);
            n56 = (GImage)GetChildAt(9);
            numLab = (GTextInput)GetChildAt(10);
            add_btn = (GButton)GetChildAt(11);
            odd_btn = (GButton)GetChildAt(12);
            max_btn = (GButton)GetChildAt(13);
            min_btn = (GButton)GetChildAt(14);
            get_btn = (GButton)GetChildAt(15);
        }
    }
}