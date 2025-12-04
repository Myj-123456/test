/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class first_recharge_btn : GComponent
    {
        public Controller status;
        public buy_btn2 buy_btn;
        public GTextField getLab;
        public GImage n3;
        public GTextField countLab;
        public GImage n5;
        public const string URL = "ui://w3ox9yltv01m1ayr83e";

        public static first_recharge_btn CreateInstance()
        {
            return (first_recharge_btn)UIPackage.CreateObject("fun_Recharge", "first_recharge_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            buy_btn = (buy_btn2)GetChildAt(0);
            getLab = (GTextField)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            countLab = (GTextField)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
        }
    }
}