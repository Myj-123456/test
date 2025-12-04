/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Warehouse
{
    public partial class tour_backpack_item : GComponent
    {
        public GLoader bg;
        public GLoader icon;
        public GTextField numLab;
        public GTextField nameLab;
        public const string URL = "ui://6soq1zhgt5nh1ayr7sa";

        public static tour_backpack_item CreateInstance()
        {
            return (tour_backpack_item)UIPackage.CreateObject("fun_Warehouse", "tour_backpack_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            bg = (GLoader)GetChildAt(0);
            icon = (GLoader)GetChildAt(1);
            numLab = (GTextField)GetChildAt(2);
            nameLab = (GTextField)GetChildAt(3);
        }
    }
}