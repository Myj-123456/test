/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_event_view : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GButton close_btn;
        public GImage n5;
        public GTextField tipLab;
        public GList list;
        public const string URL = "ui://oo5kr0yot5nh1g";

        public static tour_event_view CreateInstance()
        {
            return (tour_event_view)UIPackage.CreateObject("fun_Tour_Land", "tour_event_view");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            close_btn = (GButton)GetChildAt(3);
            n5 = (GImage)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            list = (GList)GetChildAt(6);
        }
    }
}