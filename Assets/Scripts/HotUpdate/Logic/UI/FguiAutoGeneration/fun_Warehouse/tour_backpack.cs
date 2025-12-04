/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Warehouse
{
    public partial class tour_backpack : GComponent
    {
        public GImage n2;
        public GLoader bg;
        public GImage n3;
        public GImage n5;
        public GButton close_btn;
        public GTextField tipLab;
        public GList list;
        public const string URL = "ui://6soq1zhgt5nh1ayr7s6";

        public static tour_backpack CreateInstance()
        {
            return (tour_backpack)UIPackage.CreateObject("fun_Warehouse", "tour_backpack");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            n2 = (GImage)GetChildAt(0);
            bg = (GLoader)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n5 = (GImage)GetChildAt(3);
            close_btn = (GButton)GetChildAt(4);
            tipLab = (GTextField)GetChildAt(5);
            list = (GList)GetChildAt(6);
        }
    }
}