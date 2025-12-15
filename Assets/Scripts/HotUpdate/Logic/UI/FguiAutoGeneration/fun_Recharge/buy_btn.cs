/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class buy_btn : GButton
    {
        public Controller type;
        public GButton priceBtn;
        public GButton normalBtn;
        public const string URL = "ui://w3ox9yltdidl1n";

        public static buy_btn CreateInstance()
        {
            return (buy_btn)UIPackage.CreateObject("fun_Recharge", "buy_btn");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            priceBtn = (GButton)GetChildAt(0);
            normalBtn = (GButton)GetChildAt(1);
        }
    }
}