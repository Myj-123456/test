/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class card_view : GComponent
    {
        public GLoader bg;
        public GLoader bg2;
        public card_item2 item2;
        public card_item1 item1;
        public GLoader bg1;
        public GImage n8;
        public const string URL = "ui://w3ox9yltdidl1a";

        public static card_view CreateInstance()
        {
            return (card_view)UIPackage.CreateObject("fun_Recharge", "card_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg2 = (GLoader)GetChildAt(1);
            item2 = (card_item2)GetChildAt(2);
            item1 = (card_item1)GetChildAt(3);
            bg1 = (GLoader)GetChildAt(4);
            n8 = (GImage)GetChildAt(5);
        }
    }
}