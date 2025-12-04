/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_text_item : GComponent
    {
        public Controller type;
        public GImage n1;
        public GImage n4;
        public GRichTextField lab;
        public const string URL = "ui://w3ox9yltdidl1i";

        public static card_text_item CreateInstance()
        {
            return (card_text_item)UIPackage.CreateObject("fun_Recharge", "card_text_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            n1 = (GImage)GetChildAt(0);
            n4 = (GImage)GetChildAt(1);
            lab = (GRichTextField)GetChildAt(2);
        }
    }
}