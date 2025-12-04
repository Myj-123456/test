/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_OrderFlower
{
    public partial class com_refresh : GComponent
    {
        public Controller status;
        public GButton btn_reflush;
        public GButton btn_free;
        public const string URL = "ui://ypcg4u88u0i3a";

        public static com_refresh CreateInstance()
        {
            return (com_refresh)UIPackage.CreateObject("fun_OrderFlower", "com_refresh");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            btn_reflush = (GButton)GetChildAt(0);
            btn_free = (GButton)GetChildAt(1);
        }
    }
}