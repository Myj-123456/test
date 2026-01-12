/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class RobMessage : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GTextField msgTitle;
        public GImage n82;
        public GButton close_btn;
        public rob_item1 c_item;
        public GList list;
        public GList list1;
        public common_add btn_rob_plus;
        public GButton btn_robList;
        public GButton btn_robList1;
        public emptyTip emptyTip;
        public const string URL = "ui://z1on8kwdoehgpkz";

        public static RobMessage CreateInstance()
        {
            return (RobMessage)UIPackage.CreateObject("fun_Rob", "RobMessage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            msgTitle = (GTextField)GetChildAt(1);
            n82 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            c_item = (rob_item1)GetChildAt(4);
            list = (GList)GetChildAt(5);
            list1 = (GList)GetChildAt(6);
            btn_rob_plus = (common_add)GetChildAt(7);
            btn_robList = (GButton)GetChildAt(8);
            btn_robList1 = (GButton)GetChildAt(9);
            emptyTip = (emptyTip)GetChildAt(10);
        }
    }
}