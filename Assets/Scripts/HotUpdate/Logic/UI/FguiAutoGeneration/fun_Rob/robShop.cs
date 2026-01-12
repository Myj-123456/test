/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robShop : GComponent
    {
        public Controller page;
        public GLoader bg;
        public GImage n42;
        public GLoader bg_rare;
        public GLoader bg_small;
        public GTextField lb_title;
        public GImage n32;
        public GList list;
        public GImage n36;
        public GTextField lb_shield_count;
        public ToggleButton_1 btn_switch;
        public GGroup n12;
        public GButton close_btn;
        public GLoader pic;
        public GImage n33;
        public GTextField n34;
        public GTextField txt_desc;
        public GTextField nameLab;
        public const string URL = "ui://z1on8kwdqqn4pkl";

        public static robShop CreateInstance()
        {
            return (robShop)UIPackage.CreateObject("fun_Rob", "robShop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            page = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            n42 = (GImage)GetChildAt(1);
            bg_rare = (GLoader)GetChildAt(2);
            bg_small = (GLoader)GetChildAt(3);
            lb_title = (GTextField)GetChildAt(4);
            n32 = (GImage)GetChildAt(5);
            list = (GList)GetChildAt(6);
            n36 = (GImage)GetChildAt(7);
            lb_shield_count = (GTextField)GetChildAt(8);
            btn_switch = (ToggleButton_1)GetChildAt(9);
            n12 = (GGroup)GetChildAt(10);
            close_btn = (GButton)GetChildAt(11);
            pic = (GLoader)GetChildAt(12);
            n33 = (GImage)GetChildAt(13);
            n34 = (GTextField)GetChildAt(14);
            txt_desc = (GTextField)GetChildAt(15);
            nameLab = (GTextField)GetChildAt(16);
        }
    }
}