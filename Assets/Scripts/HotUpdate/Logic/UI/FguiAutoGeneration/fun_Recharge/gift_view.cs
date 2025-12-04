/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Recharge
{
    public partial class gift_view : GComponent
    {
        public GLoader bg;
        public GLoader bg1;
        public GLoader bg2;
        public GImage n4;
        public GImage n6;
        public GList list;
        public const string URL = "ui://w3ox9yltdidl21";

        public static gift_view CreateInstance()
        {
            return (gift_view)UIPackage.CreateObject("fun_Recharge", "gift_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            bg1 = (GLoader)GetChildAt(1);
            bg2 = (GLoader)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            n6 = (GImage)GetChildAt(4);
            list = (GList)GetChildAt(5);
        }
    }
}