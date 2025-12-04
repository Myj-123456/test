/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_StoreRevenue
{
    public partial class StoreEarning : GComponent
    {
        public Controller status;
        public GImage n54;
        public GLoader bg;
        public GImage n55;
        public GImage n50;
        public StoreEarningDetail content;
        public GButton close_btn;
        public GButton leftBtn;
        public GButton rightBtn;
        public GComponent empty;
        public GTextField tipLab;
        public const string URL = "ui://6vo132lqrvqijtwq90";

        public static StoreEarning CreateInstance()
        {
            return (StoreEarning)UIPackage.CreateObject("fun_StoreRevenue", "StoreEarning");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            n54 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n55 = (GImage)GetChildAt(2);
            n50 = (GImage)GetChildAt(3);
            content = (StoreEarningDetail)GetChildAt(4);
            close_btn = (GButton)GetChildAt(5);
            leftBtn = (GButton)GetChildAt(6);
            rightBtn = (GButton)GetChildAt(7);
            empty = (GComponent)GetChildAt(8);
            tipLab = (GTextField)GetChildAt(9);
        }
    }
}