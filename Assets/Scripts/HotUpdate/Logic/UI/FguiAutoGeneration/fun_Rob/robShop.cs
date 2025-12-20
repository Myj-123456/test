/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robShop : GComponent
    {
        public Controller page;
        public GLoader n26;
        public GLoader n28;
        public GLoader n27;
        public GTextField lb_title;
        public GImage n32;
        public GList list;
        public GImage n36;
        public GTextField lb_shield_count;
        public ToggleButton_1 btn_switch;
        public GGroup n12;
        public GButton close_btn;
        public GLoader kongjun_bg;
        public GLoader pic;
        public GImage n33;
        public GTextField n34;
        public GTextField txt_desc;
        public GTextField n38;
        public const string URL = "ui://z1on8kwdqqn4pkl";

        public static robShop CreateInstance()
        {
            return (robShop)UIPackage.CreateObject("fun_Rob", "robShop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            page = GetControllerAt(0);
            n26 = (GLoader)GetChildAt(0);
            n28 = (GLoader)GetChildAt(1);
            n27 = (GLoader)GetChildAt(2);
            lb_title = (GTextField)GetChildAt(3);
            n32 = (GImage)GetChildAt(4);
            list = (GList)GetChildAt(5);
            n36 = (GImage)GetChildAt(6);
            lb_shield_count = (GTextField)GetChildAt(7);
            btn_switch = (ToggleButton_1)GetChildAt(8);
            n12 = (GGroup)GetChildAt(9);
            close_btn = (GButton)GetChildAt(10);
            kongjun_bg = (GLoader)GetChildAt(11);
            pic = (GLoader)GetChildAt(12);
            n33 = (GImage)GetChildAt(13);
            n34 = (GTextField)GetChildAt(14);
            txt_desc = (GTextField)GetChildAt(15);
            n38 = (GTextField)GetChildAt(16);
        }
    }
}