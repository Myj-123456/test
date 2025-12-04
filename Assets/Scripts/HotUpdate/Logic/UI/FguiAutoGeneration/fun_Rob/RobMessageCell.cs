/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class RobMessageCell : GComponent
    {
        public Controller genderTab;
        public Controller ableSteal;
        public GImage n36;
        public GTextField txt_userName;
        public GTextField txt_info_0;
        public GTextField txt_info_1;
        public GTextField txt_date;
        public GTextField txt_info_2;
        public GComponent master_head;
        public GButton btn_rob;
        public const string URL = "ui://z1on8kwdoehgpl0";

        public static RobMessageCell CreateInstance()
        {
            return (RobMessageCell)UIPackage.CreateObject("fun_Rob", "RobMessageCell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            genderTab = GetControllerAt(0);
            ableSteal = GetControllerAt(1);
            n36 = (GImage)GetChildAt(0);
            txt_userName = (GTextField)GetChildAt(1);
            txt_info_0 = (GTextField)GetChildAt(2);
            txt_info_1 = (GTextField)GetChildAt(3);
            txt_date = (GTextField)GetChildAt(4);
            txt_info_2 = (GTextField)GetChildAt(5);
            master_head = (GComponent)GetChildAt(6);
            btn_rob = (GButton)GetChildAt(7);
        }
    }
}