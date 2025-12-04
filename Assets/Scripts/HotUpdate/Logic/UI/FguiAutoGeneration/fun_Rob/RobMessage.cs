/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class RobMessage : GComponent
    {
        public GImage n79;
        public GButton close_btn;
        public GTextField msgTitle;
        public GList list;
        public GTextField retainTxt;
        public rob_item1 c_item;
        public GButton btn_rob_plus;
        public GTextField txt_empty;
        public GButton btn_robList;
        public const string URL = "ui://z1on8kwdoehgpkz";

        public static RobMessage CreateInstance()
        {
            return (RobMessage)UIPackage.CreateObject("fun_Rob", "RobMessage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n79 = (GImage)GetChildAt(0);
            close_btn = (GButton)GetChildAt(1);
            msgTitle = (GTextField)GetChildAt(2);
            list = (GList)GetChildAt(3);
            retainTxt = (GTextField)GetChildAt(4);
            c_item = (rob_item1)GetChildAt(5);
            btn_rob_plus = (GButton)GetChildAt(6);
            txt_empty = (GTextField)GetChildAt(7);
            btn_robList = (GButton)GetChildAt(8);
        }
    }
}