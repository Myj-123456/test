/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Fund
{
    public partial class fund_view : GComponent
    {
        public Controller tab;
        public GLoader bg;
        public GButton cash_btn;
        public GButton new_btn;
        public GButton step_btn;
        public GList list;
        public GButton buy_btn;
        public GButton close_btn;
        public const string URL = "ui://9zkvgbkxbwsw0";

        public static fund_view CreateInstance()
        {
            return (fund_view)UIPackage.CreateObject("fun_Fund", "fund_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            tab = GetControllerAt(0);
            bg = (GLoader)GetChildAt(0);
            cash_btn = (GButton)GetChildAt(1);
            new_btn = (GButton)GetChildAt(2);
            step_btn = (GButton)GetChildAt(3);
            list = (GList)GetChildAt(4);
            buy_btn = (GButton)GetChildAt(5);
            close_btn = (GButton)GetChildAt(6);
        }
    }
}