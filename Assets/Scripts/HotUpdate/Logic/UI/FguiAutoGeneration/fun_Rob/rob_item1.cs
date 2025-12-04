/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Rob
{
    public partial class rob_item1 : GComponent
    {
        public GImage n4;
        public GLoader icon_item;
        public GTextField lb_itemCount;
        public const string URL = "ui://z1on8kwdwpvd1ayr80j";

        public static rob_item1 CreateInstance()
        {
            return (rob_item1)UIPackage.CreateObject("fun_Rob", "rob_item1");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n4 = (GImage)GetChildAt(0);
            icon_item = (GLoader)GetChildAt(1);
            lb_itemCount = (GTextField)GetChildAt(2);
        }
    }
}