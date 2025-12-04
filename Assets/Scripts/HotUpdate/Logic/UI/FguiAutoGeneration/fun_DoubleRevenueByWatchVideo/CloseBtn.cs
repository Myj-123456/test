/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_DoubleRevenueByWatchVideo
{
    public partial class CloseBtn : GButton
    {
        public Controller button;
        public GImage n4;
        public const string URL = "ui://w1i8acwcqheb1yjp7v6";

        public static CloseBtn CreateInstance()
        {
            return (CloseBtn)UIPackage.CreateObject("fun_DoubleRevenueByWatchVideo", "CloseBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            n4 = (GImage)GetChildAt(0);
        }
    }
}