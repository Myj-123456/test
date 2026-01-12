/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class btn_shop : GComponent
    {
        public Controller status;
        public GButton btn_buy;
        public GButton btn_buy1;
        public btn_vip btn_buy2;
        public GButton n4;
        public const string URL = "ui://z1on8kwdv0b51ayr8mx";

        public static btn_shop CreateInstance()
        {
            return (btn_shop)UIPackage.CreateObject("fun_Rob", "btn_shop");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            btn_buy = (GButton)GetChildAt(0);
            btn_buy1 = (GButton)GetChildAt(1);
            btn_buy2 = (btn_vip)GetChildAt(2);
            n4 = (GButton)GetChildAt(3);
        }
    }
}