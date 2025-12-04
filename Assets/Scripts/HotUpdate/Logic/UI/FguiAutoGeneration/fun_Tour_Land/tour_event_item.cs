/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_event_item : GComponent
    {
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GTextField nameLab;
        public const string URL = "ui://oo5kr0yot5nh1k";

        public static tour_event_item CreateInstance()
        {
            return (tour_event_item)UIPackage.CreateObject("fun_Tour_Land", "tour_event_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}