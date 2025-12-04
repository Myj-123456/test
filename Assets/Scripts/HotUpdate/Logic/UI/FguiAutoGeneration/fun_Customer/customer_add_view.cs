/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Customer
{
    public partial class customer_add_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GButton close_btn;
        public GImage n5;
        public GImage n15;
        public GImage n4;
        public GLoader bg1;
        public GLoader pic;
        public GTextField numLab;
        public GTextField tipLab;
        public GButton addBtn;
        public GButton oddBtn;
        public GButton minBtn;
        public GButton maxBtn;
        public GButton sureBtn;
        public GButton quitBtn;
        public GTextField showLab;
        public GTextInput inputLab;
        public const string URL = "ui://pcr735xhcs1m12";

        public static customer_add_view CreateInstance()
        {
            return (customer_add_view)UIPackage.CreateObject("fun_Customer", "customer_add_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            close_btn = (GButton)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            n15 = (GImage)GetChildAt(4);
            n4 = (GImage)GetChildAt(5);
            bg1 = (GLoader)GetChildAt(6);
            pic = (GLoader)GetChildAt(7);
            numLab = (GTextField)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
            addBtn = (GButton)GetChildAt(10);
            oddBtn = (GButton)GetChildAt(11);
            minBtn = (GButton)GetChildAt(12);
            maxBtn = (GButton)GetChildAt(13);
            sureBtn = (GButton)GetChildAt(14);
            quitBtn = (GButton)GetChildAt(15);
            showLab = (GTextField)GetChildAt(16);
            inputLab = (GTextInput)GetChildAt(17);
        }
    }
}