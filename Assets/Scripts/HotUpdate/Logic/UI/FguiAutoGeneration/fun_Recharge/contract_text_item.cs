/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class contract_text_item : GComponent
    {
        public Controller type;
        public GImage n6;
        public GRichTextField lab;
        public const string URL = "ui://w3ox9yltm8ja1yjp88f";

        public static contract_text_item CreateInstance()
        {
            return (contract_text_item)UIPackage.CreateObject("fun_Recharge", "contract_text_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n6 = (GImage)GetChildAt(0);
            lab = (GRichTextField)GetChildAt(1);
        }
    }
}