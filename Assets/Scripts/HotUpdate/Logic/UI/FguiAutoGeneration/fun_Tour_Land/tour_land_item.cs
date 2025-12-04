/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Tour_Land
{
    public partial class tour_land_item : GComponent
    {
        public Controller type;
        public tour_land_cell item;
        public const string URL = "ui://oo5kr0yot5nhz";

        public static tour_land_item CreateInstance()
        {
            return (tour_land_item)UIPackage.CreateObject("fun_Tour_Land", "tour_land_item");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            type = GetControllerAt(0);
            item = (tour_land_cell)GetChildAt(0);
        }
    }
}