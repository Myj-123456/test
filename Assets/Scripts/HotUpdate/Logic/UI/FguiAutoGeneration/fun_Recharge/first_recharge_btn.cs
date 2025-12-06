/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_recharge_btn : GComponent
    {
        public Controller status;
        public GButton buy_btn;
        public GImage n11;
        public GTextField getLab;
        public GImage n3;
        public GTextField countLab;
        public GImage n8;
        public GTextField tip_lab;
        public GGroup n10;
        public const string URL = "ui://w3ox9yltv01m1ayr83e";

        public static first_recharge_btn CreateInstance()
        {
            return (first_recharge_btn)UIPackage.CreateObject("fun_Recharge", "first_recharge_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            buy_btn = (GButton)GetChildAt(0);
            n11 = (GImage)GetChildAt(1);
            getLab = (GTextField)GetChildAt(2);
            n3 = (GImage)GetChildAt(3);
            countLab = (GTextField)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
            tip_lab = (GTextField)GetChildAt(6);
            n10 = (GGroup)GetChildAt(7);
        }
    }
}