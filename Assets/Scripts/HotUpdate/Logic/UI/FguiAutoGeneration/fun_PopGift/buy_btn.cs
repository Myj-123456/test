/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_PopGift
{
    public partial class buy_btn : GButton
    {
        public Controller type;
        public GImage n1;
        public GTextField titleLab;
        public GTextField titleLab1;
        public GGroup n7;
        public GImage n4;
        public const string URL = "ui://ah12m40ag0s01ayr824";

        public static buy_btn CreateInstance()
        {
            return (buy_btn)UIPackage.CreateObject("fun_PopGift", "buy_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            titleLab = (GTextField)GetChildAt(1);
            titleLab1 = (GTextField)GetChildAt(2);
            n7 = (GGroup)GetChildAt(3);
            n4 = (GImage)GetChildAt(4);
        }
    }
}