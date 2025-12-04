/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robPlayerList : GComponent
    {
        public Controller tap;
        public GImage n29;
        public GButton close_btn;
        public rob_item1 c_item;
        public GButton btn_Menu_0;
        public GButton btn_Menu_2;
        public GButton btn_Menu_1;
        public GRichTextField lb_tip_bottom;
        public GList list;
        public GTextField txt_empty;
        public GTextField titleLab;
        public GButton btn_rob_plus;
        public const string URL = "ui://z1on8kwdku0fpjb";

        public static robPlayerList CreateInstance()
        {
            return (robPlayerList)UIPackage.CreateObject("fun_Rob", "robPlayerList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tap = GetControllerAt(0);
            n29 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            c_item = (rob_item1)GetChildAt(2);
            btn_Menu_0 = (GButton)GetChildAt(3);
            btn_Menu_2 = (GButton)GetChildAt(4);
            btn_Menu_1 = (GButton)GetChildAt(5);
            lb_tip_bottom = (GRichTextField)GetChildAt(6);
            list = (GList)GetChildAt(7);
            txt_empty = (GTextField)GetChildAt(8);
            titleLab = (GTextField)GetChildAt(9);
            btn_rob_plus = (GButton)GetChildAt(10);
        }
    }
}