/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class robShop : GComponent
    {
        public Controller page;
        public GImage n25;
        public GTextField lb_title;
        public GList list;
        public GTextField txt_shieldOpen;
        public ToggleButton_1 btn_switch;
        public GGroup n12;
        public GButton close_btn;
        public const string URL = "ui://z1on8kwdqqn4pkl";

        public static robShop CreateInstance()
        {
            return (robShop)UIPackage.CreateObject("fun_Rob", "robShop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            page = GetControllerAt(0);
            n25 = (GImage)GetChildAt(0);
            lb_title = (GTextField)GetChildAt(1);
            list = (GList)GetChildAt(2);
            txt_shieldOpen = (GTextField)GetChildAt(3);
            btn_switch = (ToggleButton_1)GetChildAt(4);
            n12 = (GGroup)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
        }
    }
}