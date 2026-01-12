/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robPlayerList : GComponent
    {
        public Controller tap;
        public GLoader n31;
        public GTextField titleLab;
        public GImage n33;
        public GButton close_btn;
        public rob_item1 c_item;
        public GButton btn_Menu_0;
        public GButton btn_Menu_2;
        public GButton btn_Menu_1;
        public GRichTextField lb_tip_bottom;
        public GList list;
        public common_add btn_rob_plus;
        public emptyTip emptyTip;
        public const string URL = "ui://z1on8kwdku0fpjb";

        public static robPlayerList CreateInstance()
        {
            return (robPlayerList)UIPackage.CreateObject("fun_Rob", "robPlayerList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tap = GetControllerAt(0);
            n31 = (GLoader)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            n33 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            c_item = (rob_item1)GetChildAt(4);
            btn_Menu_0 = (GButton)GetChildAt(5);
            btn_Menu_2 = (GButton)GetChildAt(6);
            btn_Menu_1 = (GButton)GetChildAt(7);
            lb_tip_bottom = (GRichTextField)GetChildAt(8);
            list = (GList)GetChildAt(9);
            btn_rob_plus = (common_add)GetChildAt(10);
            emptyTip = (emptyTip)GetChildAt(11);
        }
    }
}