/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_view : GComponent
    {
        public GLoader bg;
        public card_item2 item2;
        public card_item1 item1;
        public const string URL = "ui://w3ox9yltdidl1a";

        public static card_view CreateInstance()
        {
            return (card_view)UIPackage.CreateObject("fun_Recharge", "card_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            item2 = (card_item2)GetChildAt(1);
            item1 = (card_item1)GetChildAt(2);
        }
    }
}