/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class newRecharge : GComponent
    {
        public GLoader bg;
        public recharge_list revharge;
        public GGraph rect;
        public GImage n34;
        public GImage n35;
        public GTextField tipLab;
        public GImage n36;
        public const string URL = "ui://w3ox9yltqheb0";

        public static newRecharge CreateInstance()
        {
            return (newRecharge)UIPackage.CreateObject("fun_Recharge", "newRecharge");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            revharge = (recharge_list)GetChildAt(1);
            rect = (GGraph)GetChildAt(2);
            n34 = (GImage)GetChildAt(3);
            n35 = (GImage)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            n36 = (GImage)GetChildAt(6);
        }
    }
}