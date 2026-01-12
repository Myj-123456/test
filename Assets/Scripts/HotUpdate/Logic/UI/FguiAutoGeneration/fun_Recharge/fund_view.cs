/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class fund_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GImage n14;
        public GImage n15;
        public GImage n20;
        public GImage n21;
        public GImage n23;
        public GImage n24;
        public page_btn4 cash_btn;
        public page_btn4 new_btn;
        public page_btn4 step_btn;
        public GImage n16;
        public GImage n17;
        public GTextField n25;
        public GImage n26;
        public GImage n27;
        public GImage n28;
        public GImage n29;
        public GImage n30;
        public GImage n31;
        public GGroup n32;
        public GList list;
        public GButton buy_btn;
        public const string URL = "ui://w3ox9yltcu3e1yjp889";

        public static fund_view CreateInstance()
        {
            return (fund_view)UIPackage.CreateObject("fun_Recharge", "fund_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n14 = (GImage)GetChildAt(1);
            n15 = (GImage)GetChildAt(2);
            n20 = (GImage)GetChildAt(3);
            n21 = (GImage)GetChildAt(4);
            n23 = (GImage)GetChildAt(5);
            n24 = (GImage)GetChildAt(6);
            cash_btn = (page_btn4)GetChildAt(7);
            new_btn = (page_btn4)GetChildAt(8);
            step_btn = (page_btn4)GetChildAt(9);
            n16 = (GImage)GetChildAt(10);
            n17 = (GImage)GetChildAt(11);
            n25 = (GTextField)GetChildAt(12);
            n26 = (GImage)GetChildAt(13);
            n27 = (GImage)GetChildAt(14);
            n28 = (GImage)GetChildAt(15);
            n29 = (GImage)GetChildAt(16);
            n30 = (GImage)GetChildAt(17);
            n31 = (GImage)GetChildAt(18);
            n32 = (GGroup)GetChildAt(19);
            list = (GList)GetChildAt(20);
            buy_btn = (GButton)GetChildAt(21);
        }
    }
}