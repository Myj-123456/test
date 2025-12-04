/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_land_cell : GComponent
    {
        public Controller status;
        public Controller selected;
        public GImage n1;
        public GImage n2;
        public GImage n3;
        public GImage n4;
        public GImage max_img;
        public GGraph n7;
        public GImage n8;
        public GTextField nameLab;
        public const string URL = "ui://oo5kr0yot5nhu";

        public static tour_land_cell CreateInstance()
        {
            return (tour_land_cell)UIPackage.CreateObject("fun_Tour_Land", "tour_land_cell");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            selected = GetControllerAt(1);
            n1 = (GImage)GetChildAt(0);
            n2 = (GImage)GetChildAt(1);
            n3 = (GImage)GetChildAt(2);
            n4 = (GImage)GetChildAt(3);
            max_img = (GImage)GetChildAt(4);
            n7 = (GGraph)GetChildAt(5);
            n8 = (GImage)GetChildAt(6);
            nameLab = (GTextField)GetChildAt(7);
        }
    }
}