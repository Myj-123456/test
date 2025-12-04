/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class buy_btn1 : GButton
    {
        public Controller type;
        public GImage n1;
        public GImage n4;
        public GTextField titleLab;
        public const string URL = "ui://w3ox9yltdidl2p";

        public static buy_btn1 CreateInstance()
        {
            return (buy_btn1)UIPackage.CreateObject("fun_Recharge", "buy_btn1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            titleLab = (GTextField)GetChildAt(2);
        }
    }
}