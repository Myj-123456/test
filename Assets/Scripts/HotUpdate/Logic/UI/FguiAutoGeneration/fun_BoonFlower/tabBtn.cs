/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_BoonFlower
{
    public partial class tabBtn : GButton
    {
        public Controller button;
        public Controller status;
        public GImage n9;
        public GImage bg;
        public GImage n11;
        public GTextField titleLab;
        public GTextField titleLab1;
        public const string URL = "ui://fsc3a856e0lm1ayr88z";

        public static tabBtn CreateInstance()
        {
            return (tabBtn)UIPackage.CreateObject("fun_BoonFlower", "tabBtn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            button = GetControllerAt(0);
            status = GetControllerAt(1);
            n9 = (GImage)GetChildAt(0);
            bg = (GImage)GetChildAt(1);
            n11 = (GImage)GetChildAt(2);
            titleLab = (GTextField)GetChildAt(3);
            titleLab1 = (GTextField)GetChildAt(4);
        }
    }
}