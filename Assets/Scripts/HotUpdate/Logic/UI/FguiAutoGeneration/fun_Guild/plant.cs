/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace fun_Guild
{
    public partial class plant : GComponent
    {
        public Controller status;
        public GTextField placeholder;
        public plant_page page;
        public search_area search_area;
        public const string URL = "ui://6wv667gujpt92";

        public static plant CreateInstance()
        {
            return (plant)UIPackage.CreateObject("fun_Guild", "plant");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            status = GetControllerAt(0);
            placeholder = (GTextField)GetChildAt(0);
            page = (plant_page)GetChildAt(1);
            search_area = (search_area)GetChildAt(2);
        }
    }
}